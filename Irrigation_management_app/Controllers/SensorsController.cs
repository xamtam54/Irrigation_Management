using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Irrigation_management_app.Controllers
{ [Authorize]
    public class SensorsController : Controller
    {
       
        private readonly HttpClient _httpClient;

        public SensorsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new System.Uri("http://www.irrigationmanagementudec.somee.com/api/");
        }
        
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Sensors");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var sensors = JsonConvert.DeserializeObject<List<SensorsVModel>>(content);

                foreach (var sensor in sensors)
                {
                    var deviceResponse = await _httpClient.GetAsync($"Devices/{sensor.Device_Id}");
                    if (deviceResponse.IsSuccessStatusCode)
                    {
                        var deviceContent = await deviceResponse.Content.ReadAsStringAsync();
                        sensor.Device = JsonConvert.DeserializeObject<DevicesVModel>(deviceContent);
                    }

                    var typeResponse = await _httpClient.GetAsync($"Sensor_Types/{sensor.Sensor_Type_Id}");
                    if (typeResponse.IsSuccessStatusCode)
                    {
                        var typeContent = await typeResponse.Content.ReadAsStringAsync();
                        sensor.Sensor_Type = JsonConvert.DeserializeObject<Sensor_TypesVModel>(typeContent);
                    }
                }

                return View(sensors);
            }

            return View("Error");
        }

        public async Task<IActionResult> Create()
        {
            var devicesResponse = await _httpClient.GetAsync("Devices");
            var typesResponse = await _httpClient.GetAsync("Sensor_Types");

            if (devicesResponse.IsSuccessStatusCode && typesResponse.IsSuccessStatusCode)
            {
                var devicesContent = await devicesResponse.Content.ReadAsStringAsync();
                var typesContent = await typesResponse.Content.ReadAsStringAsync();

                var devices = JsonConvert.DeserializeObject<IEnumerable<DevicesVModel>>(devicesContent);
                var types = JsonConvert.DeserializeObject<IEnumerable<Sensor_TypesVModel>>(typesContent);

                ViewData["Devices"] = new SelectList(devices, "Device_Id", "Device_Name");
                ViewData["SensorTypes"] = new SelectList(types, "Sensor_Type_Id", "Sensor_Type");

                return View();
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SensorsVModel sensor)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(sensor);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Sensors", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear sensor");
                }
            }

            return View(sensor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"Sensors/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var sensor = JsonConvert.DeserializeObject<SensorsVModel>(content);

                var devicesResponse = await _httpClient.GetAsync("Devices");
                var typesResponse = await _httpClient.GetAsync("Sensor_Types");

                if (devicesResponse.IsSuccessStatusCode && typesResponse.IsSuccessStatusCode)
                {
                    var devicesContent = await devicesResponse.Content.ReadAsStringAsync();
                    var typesContent = await typesResponse.Content.ReadAsStringAsync();

                    var devices = JsonConvert.DeserializeObject<IEnumerable<DevicesVModel>>(devicesContent);
                    var types = JsonConvert.DeserializeObject<IEnumerable<Sensor_TypesVModel>>(typesContent);

                    ViewData["Devices"] = new SelectList(devices, "Device_Id", "Device_Name", sensor.Device_Id);
                    ViewData["SensorTypes"] = new SelectList(types, "Sensor_Type_Id", "Sensor_Type", sensor.Sensor_Type_Id);
                }

                return View(sensor);
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SensorsVModel sensor)
        {
            if (id != sensor.Sensor_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(sensor);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Sensors/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(sensor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"Sensors/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var sensor = JsonConvert.DeserializeObject<SensorsVModel>(content);

                var deviceResponse = await _httpClient.GetAsync($"Devices/{sensor.Device_Id}");
                if (deviceResponse.IsSuccessStatusCode)
                {
                    var deviceContent = await deviceResponse.Content.ReadAsStringAsync();
                    sensor.Device = JsonConvert.DeserializeObject<DevicesVModel>(deviceContent);
                }

                var typeResponse = await _httpClient.GetAsync($"Sensor_Types/{sensor.Sensor_Type_Id}");
                if (typeResponse.IsSuccessStatusCode)
                {
                    var typeContent = await typeResponse.Content.ReadAsStringAsync();
                    sensor.Sensor_Type = JsonConvert.DeserializeObject<Sensor_TypesVModel>(typeContent);
                }

                var responseDelete = await _httpClient.DeleteAsync($"Sensors/{id}");
                if (responseDelete.IsSuccessStatusCode)
                {
                    return View(sensor);
                }
                return View(sensor);
            }

            return View("Error");
        }

    }
}
