using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Irrigation_management_app.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {

        private readonly HttpClient _httpClient;

        public DevicesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.irrigationmanagementudec.somee.com/api/");
        }
        
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Devices");
            var systemsResponse = await _httpClient.GetAsync("Systems");

            if (response.IsSuccessStatusCode && systemsResponse.IsSuccessStatusCode)
            {
                var systemsContent = await systemsResponse.Content.ReadAsStringAsync();
                var systems = JsonConvert.DeserializeObject<IEnumerable<SystemsVModel>>(systemsContent);
                ViewBag.Systems = systems;

                var content = await response.Content.ReadAsStringAsync();
                var devices = JsonConvert.DeserializeObject<IEnumerable<DevicesVModel>>(content);
                return View("Index", devices);
            }
            return View("Error");
        }
        
        public async Task<IActionResult> Create()
        {
            var systemsResponse = await _httpClient.GetAsync("Systems");
            var plantingAreasResponse = await _httpClient.GetAsync("Planting_Areas");

            if (systemsResponse.IsSuccessStatusCode && plantingAreasResponse.IsSuccessStatusCode)
            {
                var systemsContent = await systemsResponse.Content.ReadAsStringAsync();
                var plantingAreasContent = await plantingAreasResponse.Content.ReadAsStringAsync();

                var systems = JsonConvert.DeserializeObject<IEnumerable<SystemsVModel>>(systemsContent);
                var plantingAreas = JsonConvert.DeserializeObject<IEnumerable<Planting_AreasVModel>>(plantingAreasContent);

                ViewBag.Systems = systems;
                ViewBag.PlantingAreas = plantingAreas;

                return View();
            }

            ViewBag.Error = "Error al obtener datos necesarios para crear dispositivo.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DevicesVModel device)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(device);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Devices", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear dispositivo");
                }
            }

            var systemsResponse = await _httpClient.GetAsync("Systems");
            var plantingAreasResponse = await _httpClient.GetAsync("Planting_Areas");

            if (systemsResponse.IsSuccessStatusCode && plantingAreasResponse.IsSuccessStatusCode)
            {
                var systemsContent = await systemsResponse.Content.ReadAsStringAsync();
                var plantingAreasContent = await plantingAreasResponse.Content.ReadAsStringAsync();

                var systems = JsonConvert.DeserializeObject<IEnumerable<SystemsVModel>>(systemsContent);
                var plantingAreas = JsonConvert.DeserializeObject<IEnumerable<Planting_AreasVModel>>(plantingAreasContent);

                ViewBag.Systems = systems;
                ViewBag.PlantingAreas = plantingAreas;
            }
            else
            {
                ViewBag.Error = "Error al obtener datos necesarios para crear dispositivo.";
            }

            return View(device);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"Devices/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var device = JsonConvert.DeserializeObject<DevicesVModel>(content);

                var responseDelete = await _httpClient.DeleteAsync($"Devices/{id}");
                if (responseDelete.IsSuccessStatusCode)
                {
                    return View(device);
                }
            }

            ModelState.AddModelError(string.Empty, "No se pudo eliminar el dispositivo. Por favor, inténtalo de nuevo.");
            return View("Error");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"Devices/{id}");
            var systemsResponse = await _httpClient.GetAsync("Systems");
            var plantingAreasResponse = await _httpClient.GetAsync("Planting_Areas");

            if (response.IsSuccessStatusCode && systemsResponse.IsSuccessStatusCode && plantingAreasResponse.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var device = JsonConvert.DeserializeObject<DevicesVModel>(content);

                var systemsContent = await systemsResponse.Content.ReadAsStringAsync();
                var plantingAreasContent = await plantingAreasResponse.Content.ReadAsStringAsync();

                var systems = JsonConvert.DeserializeObject<IEnumerable<SystemsVModel>>(systemsContent);
                var plantingAreas = JsonConvert.DeserializeObject<IEnumerable<Planting_AreasVModel>>(plantingAreasContent);

                ViewBag.Systems = systems;
                ViewBag.PlantingAreas = plantingAreas;

                return View(device);
            }

            ModelState.AddModelError(string.Empty, "No se pudo recuperar el dispositivo para editar. Por favor, inténtalo de nuevo.");
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DevicesVModel device)
        {
            if (id != device.Device_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(device);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Devices/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var systemsResponse = await _httpClient.GetAsync("Systems");
            var plantingAreasResponse = await _httpClient.GetAsync("Planting_Areas");

            if (systemsResponse.IsSuccessStatusCode && plantingAreasResponse.IsSuccessStatusCode)
            {
                var systemsContent = await systemsResponse.Content.ReadAsStringAsync();
                var plantingAreasContent = await plantingAreasResponse.Content.ReadAsStringAsync();

                var systems = JsonConvert.DeserializeObject<IEnumerable<SystemsVModel>>(systemsContent);
                var plantingAreas = JsonConvert.DeserializeObject<IEnumerable<Planting_AreasVModel>>(plantingAreasContent);

                ViewBag.Systems = systems;
                ViewBag.PlantingAreas = plantingAreas;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al obtener datos necesarios para editar dispositivo.");
            }

            return View(device);
        }
    }
}
