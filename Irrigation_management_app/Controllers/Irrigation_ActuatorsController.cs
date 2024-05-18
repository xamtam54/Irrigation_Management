using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Irrigation_management_app.Controllers
{
    public class Irrigation_ActuatorsController : Controller
    {
        private readonly HttpClient _httpClient;

        public Irrigation_ActuatorsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.irrigationmanagementudec.somee.com/api/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Irrigation_Actuators");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var irrigationActuators = JsonConvert.DeserializeObject<List<Irrigation_ActuatorsVModel>>(content);

                // Ahora que hemos obtenido los actuadores de riego, necesitamos obtener también los nombres de los dispositivos y tipos de actuadores
                foreach (var actuator in irrigationActuators)
                {
                    var deviceResponse = await _httpClient.GetAsync($"Devices/{actuator.Device_Id}");
                    if (deviceResponse.IsSuccessStatusCode)
                    {
                        var deviceContent = await deviceResponse.Content.ReadAsStringAsync();
                        actuator.Device = JsonConvert.DeserializeObject<DevicesVModel>(deviceContent);
                    }

                    var typeResponse = await _httpClient.GetAsync($"Irrigation_Actuators_Types/{actuator.Irrigation_Actuators_Type_Id}");
                    if (typeResponse.IsSuccessStatusCode)
                    {
                        var typeContent = await typeResponse.Content.ReadAsStringAsync();
                        actuator.Irrigation_Actuators_Type = JsonConvert.DeserializeObject<Irrigation_Actuators_TypesVModel>(typeContent);
                    }
                }

                return View(irrigationActuators);
            }
            return View("Error");
        }


        public async Task<IActionResult> Create()
        {
            // Obtener los datos de las llaves foráneas para pasarlos a la vista de creación
            var devicesResponse = await _httpClient.GetAsync("Devices");
            var typesResponse = await _httpClient.GetAsync("Irrigation_Actuators_Types");

            if (devicesResponse.IsSuccessStatusCode && typesResponse.IsSuccessStatusCode)
            {
                var devicesContent = await devicesResponse.Content.ReadAsStringAsync();
                var typesContent = await typesResponse.Content.ReadAsStringAsync();

                var devices = JsonConvert.DeserializeObject<IEnumerable<DevicesVModel>>(devicesContent);
                var types = JsonConvert.DeserializeObject<IEnumerable<Irrigation_Actuators_TypesVModel>>(typesContent);

                ViewData["Devices"] = new SelectList(devices, "Device_Id", "Device_Name");
                ViewData["Types"] = new SelectList(types, "Irrigation_Actuators_Type_Id", "Type_Name");

                return View();
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Irrigation_ActuatorsVModel irrigationActuator)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(irrigationActuator);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Irrigation_Actuators", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear actuador de riego");
                }
            }

            // Si hay un error, volver a cargar los datos de las llaves foráneas
            return await Create();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"Irrigation_Actuators/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var irrigationActuator = JsonConvert.DeserializeObject<Irrigation_ActuatorsVModel>(content);

                // Obtener los datos de las llaves foráneas para pasarlos a la vista de edición
                var devicesResponse = await _httpClient.GetAsync("Devices");
                var typesResponse = await _httpClient.GetAsync("Irrigation_Actuators_Types");

                if (devicesResponse.IsSuccessStatusCode && typesResponse.IsSuccessStatusCode)
                {
                    var devicesContent = await devicesResponse.Content.ReadAsStringAsync();
                    var typesContent = await typesResponse.Content.ReadAsStringAsync();

                    var devices = JsonConvert.DeserializeObject<IEnumerable<DevicesVModel>>(devicesContent);
                    var types = JsonConvert.DeserializeObject<IEnumerable<Irrigation_Actuators_TypesVModel>>(typesContent);

                    ViewData["Devices"] = new SelectList(devices, "Device_Id", "Device_Name", irrigationActuator.Device_Id);
                    ViewData["Types"] = new SelectList(types, "Irrigation_Actuators_Type_Id", "Type_Name", irrigationActuator.Irrigation_Actuators_Type_Id);
                }

                return View(irrigationActuator);
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Irrigation_ActuatorsVModel irrigationActuator)
        {
            if (id != irrigationActuator.Irrigation_Actuator_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(irrigationActuator);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Irrigation_Actuators/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            // Si hay un error, volver a cargar los datos de las llaves foráneas
            return await Edit(id);
        }
        // GET: Irrigation_Actuators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responseActuator = await _httpClient.GetAsync($"Irrigation_Actuators/{id}");
            if (responseActuator.IsSuccessStatusCode)
            {
                var contentActuator = await responseActuator.Content.ReadAsStringAsync();
                var irrigationActuator = JsonConvert.DeserializeObject<Irrigation_ActuatorsVModel>(contentActuator);

                // Ahora que hemos obtenido el actuador de riego, necesitamos obtener también el nombre del dispositivo y tipo de actuador
                var deviceResponse = await _httpClient.GetAsync($"Devices/{irrigationActuator.Device_Id}");
                if (deviceResponse.IsSuccessStatusCode)
                {
                    var deviceContent = await deviceResponse.Content.ReadAsStringAsync();
                    irrigationActuator.Device = JsonConvert.DeserializeObject<DevicesVModel>(deviceContent);
                }

                var typeResponse = await _httpClient.GetAsync($"Irrigation_Actuators_Types/{irrigationActuator.Irrigation_Actuators_Type_Id}");
                if (typeResponse.IsSuccessStatusCode)
                {
                    var typeContent = await typeResponse.Content.ReadAsStringAsync();
                    irrigationActuator.Irrigation_Actuators_Type = JsonConvert.DeserializeObject<Irrigation_Actuators_TypesVModel>(typeContent);
                }
                var responseDelete = await _httpClient.DeleteAsync($"Irrigation_Actuators/{id}");
                if (responseDelete.IsSuccessStatusCode)
                {
                    return View(irrigationActuator);
                }
                return View(irrigationActuator);
            }

            return View("Error");
        }







    }
}

