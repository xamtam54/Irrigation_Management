using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Irrigation_management_app.Controllers
{
    [Authorize]
    public class Planting_AreasController : Controller
    {
        private readonly HttpClient _httpClient;

        public Planting_AreasController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.irrigationmanagementudec.somee.com/api/");
        }
        
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Planting_Areas");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var plantingAreas = JsonConvert.DeserializeObject<List<Planting_AreasVModel>>(content);

                foreach (var area in plantingAreas)
                {
                    var cropStatusResponse = await _httpClient.GetAsync($"Crop/{area.Crop_Status_Id}");
                    if (cropStatusResponse.IsSuccessStatusCode)
                    {
                        var cropStatusContent = await cropStatusResponse.Content.ReadAsStringAsync();
                        area.Crop_Statu = JsonConvert.DeserializeObject<Crop_StatusVModel>(cropStatusContent);
                    }

                    var plantResponse = await _httpClient.GetAsync($"Plants/{area.Plant_Id}");
                    if (plantResponse.IsSuccessStatusCode)
                    {
                        var plantContent = await plantResponse.Content.ReadAsStringAsync();
                        area.Plant = JsonConvert.DeserializeObject<PlantsVModel>(plantContent);
                    }
                }

                return View(plantingAreas);
            }
            return View("Error");
        }

        // Create GET
        public async Task<IActionResult> Create()
        {
            var cropStatusResponse = await _httpClient.GetAsync("Crop");
            var plantsResponse = await _httpClient.GetAsync("Plants");

            if (cropStatusResponse.IsSuccessStatusCode && plantsResponse.IsSuccessStatusCode)
            {
                var cropStatusContent = await cropStatusResponse.Content.ReadAsStringAsync();
                var plantsContent = await plantsResponse.Content.ReadAsStringAsync();

                var cropStatuses = JsonConvert.DeserializeObject<IEnumerable<Crop_StatusVModel>>(cropStatusContent);
                var plants = JsonConvert.DeserializeObject<IEnumerable<PlantsVModel>>(plantsContent);

                ViewData["CropStatuses"] = new SelectList(cropStatuses, "Crop_Status_Id", "Crop_Status_Name");
                ViewData["Plants"] = new SelectList(plants, "Plant_Id", "Plant_Name");

                return View();
            }
            return View("Error");
        }

        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Planting_AreasVModel plantingArea)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(plantingArea);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Planting_Areas", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear área de plantación");
                }
            }

            return await Create();
        }

        // Edit GET
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"Planting_Areas/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var plantingArea = JsonConvert.DeserializeObject<Planting_AreasVModel>(content);

                var cropStatusResponse = await _httpClient.GetAsync("Crop");
                var plantsResponse = await _httpClient.GetAsync("Plants");

                if (cropStatusResponse.IsSuccessStatusCode && plantsResponse.IsSuccessStatusCode)
                {
                    var cropStatusContent = await cropStatusResponse.Content.ReadAsStringAsync();
                    var plantsContent = await plantsResponse.Content.ReadAsStringAsync();

                    var cropStatuses = JsonConvert.DeserializeObject<IEnumerable<Crop_StatusVModel>>(cropStatusContent);
                    var plants = JsonConvert.DeserializeObject<IEnumerable<PlantsVModel>>(plantsContent);

                    ViewData["CropStatuses"] = new SelectList(cropStatuses, "Crop_Status_Id", "Crop_Status_Name", plantingArea.Crop_Status_Id);
                    ViewData["Plants"] = new SelectList(plants, "Plant_Id", "Plant_Name", plantingArea.Plant_Id);

                    return View(plantingArea);
                }
            }

            return View("Error");
        }

        // Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Planting_AreasVModel plantingArea)
        {
            if (id != plantingArea.Area_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(plantingArea);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Planting_Areas/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return await Edit(id);
        }

        // Delete GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"Planting_Areas/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var plantingArea = JsonConvert.DeserializeObject<Planting_AreasVModel>(content);

                var cropStatusResponse = await _httpClient.GetAsync($"Crop/{plantingArea.Crop_Status_Id}");
                if (cropStatusResponse.IsSuccessStatusCode)
                {
                    var cropStatusContent = await cropStatusResponse.Content.ReadAsStringAsync();
                    plantingArea.Crop_Statu = JsonConvert.DeserializeObject<Crop_StatusVModel>(cropStatusContent);
                }

                var plantResponse = await _httpClient.GetAsync($"Plants/{plantingArea.Plant_Id}");
                if (plantResponse.IsSuccessStatusCode)
                {
                    var plantContent = await plantResponse.Content.ReadAsStringAsync();
                    plantingArea.Plant = JsonConvert.DeserializeObject<PlantsVModel>(plantContent);
                }

                return View(plantingArea);
            }

            return View("Error");
        }

        // Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"Planting_Areas/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("Error");
        }

    }
}
