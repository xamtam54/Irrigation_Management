using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Irrigation_management_app.Controllers
{
    [Authorize]
    public class Water_ManagementController : Controller
    {
        private readonly HttpClient _httpClient;

        public Water_ManagementController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.irrigationmanagementudec.somee.com/api/");
        }
        
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Water_Management");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var waterManagementList = JsonConvert.DeserializeObject<List<Water_ManagementVModel>>(content);

                foreach (var waterManagement in waterManagementList)
                {
                    var deviceResponse = await _httpClient.GetAsync($"Devices/{waterManagement.Device_Id}");
                    if (deviceResponse.IsSuccessStatusCode)
                    {
                        var deviceContent = await deviceResponse.Content.ReadAsStringAsync();
                        waterManagement.Device = JsonConvert.DeserializeObject<DevicesVModel>(deviceContent);
                    }

                    var typeResponse = await _httpClient.GetAsync($"Water_Management_Types/{waterManagement.Water_Management_Type_Id}");
                    if (typeResponse.IsSuccessStatusCode)
                    {
                        var typeContent = await typeResponse.Content.ReadAsStringAsync();
                        waterManagement.Water_Management_Type = JsonConvert.DeserializeObject<Water_Management_TypesVModel>(typeContent);
                    }
                }

                return View(waterManagementList);
            }
            return View("Error");
        }

        public async Task<IActionResult> Create()
        {
            var devicesResponse = await _httpClient.GetAsync("Devices");
            var typesResponse = await _httpClient.GetAsync("Water_Management_Types");

            if (devicesResponse.IsSuccessStatusCode && typesResponse.IsSuccessStatusCode)
            {
                var devicesContent = await devicesResponse.Content.ReadAsStringAsync();
                var typesContent = await typesResponse.Content.ReadAsStringAsync();

                var devices = JsonConvert.DeserializeObject<IEnumerable<DevicesVModel>>(devicesContent);
                var types = JsonConvert.DeserializeObject<IEnumerable<Water_Management_TypesVModel>>(typesContent);

                ViewBag.Devices = new SelectList(devices, "Device_Id", "Device_Name");
                ViewBag.WaterManagementTypes = new SelectList(types, "Water_Management_Type_Id", "Type_Name");

                return View();
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Water_ManagementVModel waterManagement)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(waterManagement);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Water_Management", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear la gestión de agua");
                }
            }

            var devicesResponse = await _httpClient.GetAsync("Devices");
            var typesResponse = await _httpClient.GetAsync("Water_Management_Types");

            if (devicesResponse.IsSuccessStatusCode && typesResponse.IsSuccessStatusCode)
            {
                var devicesContent = await devicesResponse.Content.ReadAsStringAsync();
                var typesContent = await typesResponse.Content.ReadAsStringAsync();

                var devices = JsonConvert.DeserializeObject<IEnumerable<DevicesVModel>>(devicesContent);
                var types = JsonConvert.DeserializeObject<IEnumerable<Water_Management_TypesVModel>>(typesContent);

                ViewBag.Devices = new SelectList(devices, "Device_Id", "Device_Name", waterManagement.Device_Id);
                ViewBag.WaterManagementTypes = new SelectList(types, "Water_Management_Type_Id", "Type_Name", waterManagement.Water_Management_Type_Id);
            }

            return View(waterManagement);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"Water_Management/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var waterManagement = JsonConvert.DeserializeObject<Water_ManagementVModel>(content);

                var devicesResponse = await _httpClient.GetAsync("Devices");
                var typesResponse = await _httpClient.GetAsync("Water_Management_Types");

                if (devicesResponse.IsSuccessStatusCode && typesResponse.IsSuccessStatusCode)
                {
                    var devicesContent = await devicesResponse.Content.ReadAsStringAsync();
                    var typesContent = await typesResponse.Content.ReadAsStringAsync();

                    var devices = JsonConvert.DeserializeObject<IEnumerable<DevicesVModel>>(devicesContent);
                    var types = JsonConvert.DeserializeObject<IEnumerable<Water_Management_TypesVModel>>(typesContent);

                    ViewBag.Devices = new SelectList(devices, "Device_Id", "Device_Name", waterManagement.Device_Id);
                    ViewBag.WaterManagementTypes = new SelectList(types, "Water_Management_Type_Id", "Type_Name", waterManagement.Water_Management_Type_Id);
                }

                return View(waterManagement);
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Water_ManagementVModel waterManagement)
        {
            if (id != waterManagement.Water_Management_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(waterManagement);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Water_Management/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var devicesResponse = await _httpClient.GetAsync("Devices");
            var typesResponse = await _httpClient.GetAsync("Water_Management_Types");

            if (devicesResponse.IsSuccessStatusCode && typesResponse.IsSuccessStatusCode)
            {
                var devicesContent = await devicesResponse.Content.ReadAsStringAsync();
                var typesContent = await typesResponse.Content.ReadAsStringAsync();

                var devices = JsonConvert.DeserializeObject<IEnumerable<DevicesVModel>>(devicesContent);
                var types = JsonConvert.DeserializeObject<IEnumerable<Water_Management_TypesVModel>>(typesContent);

                ViewBag.Devices = new SelectList(devices, "Device_Id", "Device_Name", waterManagement.Device_Id);
                ViewBag.WaterManagementTypes = new SelectList(types, "Water_Management_Type_Id", "Type_Name", waterManagement.Water_Management_Type_Id);
            }

            return View(waterManagement);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"Water_Management/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var waterManagement = JsonConvert.DeserializeObject<Water_ManagementVModel>(content);

                var deviceResponse = await _httpClient.GetAsync($"Devices/{waterManagement.Device_Id}");
                if (deviceResponse.IsSuccessStatusCode)
                {
                    var deviceContent = await deviceResponse.Content.ReadAsStringAsync();
                    waterManagement.Device = JsonConvert.DeserializeObject<DevicesVModel>(deviceContent);
                }

                var typeResponse = await _httpClient.GetAsync($"Water_Management_Types/{waterManagement.Water_Management_Type_Id}");
                if (typeResponse.IsSuccessStatusCode)
                {
                    var typeContent = await typeResponse.Content.ReadAsStringAsync();
                    waterManagement.Water_Management_Type = JsonConvert.DeserializeObject<Water_Management_TypesVModel>(typeContent);
                }
                var responseDelete = await _httpClient.DeleteAsync($"Water_Management/{id}");
                if (responseDelete.IsSuccessStatusCode)
                {
                    return View(waterManagement);
                }
                return View(waterManagement);
            }

            return View("Error");
        }

    }
}
