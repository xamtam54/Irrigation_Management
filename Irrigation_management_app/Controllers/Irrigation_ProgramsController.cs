using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Irrigation_management_app.Controllers
{
    [Authorize]
    public class Irrigation_ProgramsController : Controller
    {
        private readonly HttpClient _httpClient;

        public Irrigation_ProgramsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.irrigationmanagementudec.somee.com/api/");
        }
        
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Irrigation_Programs");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var irrigationPrograms = JsonConvert.DeserializeObject<List<Irrigation_ProgramsVModel>>(content);

                foreach (var program in irrigationPrograms)
                {
                    var areaResponse = await _httpClient.GetAsync($"Planting_Areas/{program.Area_Id}");
                    if (areaResponse.IsSuccessStatusCode)
                    {
                        var areaContent = await areaResponse.Content.ReadAsStringAsync();
                        program.Planting_Area = JsonConvert.DeserializeObject<Planting_AreasVModel>(areaContent);
                    }
                }

                return View(irrigationPrograms);
            }
            return View("Error");
        }

        public async Task<IActionResult> Create()
        {
            var areasResponse = await _httpClient.GetAsync("Planting_Areas");

            if (areasResponse.IsSuccessStatusCode)
            {
                var areasContent = await areasResponse.Content.ReadAsStringAsync();
                var areas = JsonConvert.DeserializeObject<IEnumerable<Planting_AreasVModel>>(areasContent);

                ViewData["Areas"] = new SelectList(areas, "Area_Id", "Area_Name");
                return View();
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Irrigation_ProgramsVModel irrigationProgram)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(irrigationProgram);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Irrigation_Programs", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el programa de riego");
                }
            }

            return await Create();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"Irrigation_Programs/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var irrigationProgram = JsonConvert.DeserializeObject<Irrigation_ProgramsVModel>(content);

                var areasResponse = await _httpClient.GetAsync("Planting_Areas");
                if (areasResponse.IsSuccessStatusCode)
                {
                    var areasContent = await areasResponse.Content.ReadAsStringAsync();
                    var areas = JsonConvert.DeserializeObject<IEnumerable<Planting_AreasVModel>>(areasContent);

                    ViewData["Areas"] = new SelectList(areas, "Area_Id", "Area_Name", irrigationProgram.Area_Id);
                    return View(irrigationProgram);
                }
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Irrigation_ProgramsVModel irrigationProgram)
        {
            if (id != irrigationProgram.Irrigation_Program_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(irrigationProgram);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Irrigation_Programs/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return await Edit(id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"Irrigation_Programs/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var irrigationProgram = JsonConvert.DeserializeObject<Irrigation_ProgramsVModel>(content);

                var areaResponse = await _httpClient.GetAsync($"Planting_Areas/{irrigationProgram.Area_Id}");
                if (areaResponse.IsSuccessStatusCode)
                {
                    var areaContent = await areaResponse.Content.ReadAsStringAsync();
                    irrigationProgram.Planting_Area = JsonConvert.DeserializeObject<Planting_AreasVModel>(areaContent);
                }

                var responseDelete = await _httpClient.DeleteAsync($"Irrigation_Programs/{id}");
                if (responseDelete.IsSuccessStatusCode)
                {
                    return View("DeleteConfirmed", irrigationProgram);
                }
                return View(irrigationProgram);
            }

            return View("Error");
        }
    }
}
