using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Irrigation_management_app.Controllers
{
    [Authorize]
    public class SystemsController : Controller
    {
        private readonly HttpClient _httpClient;

        public SystemsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.irrigationmanagementudec.somee.com/api/");
        }
        
        // GET: User_Types
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Systems");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var systems = JsonConvert.DeserializeObject<List<SystemsVModel>>(content);
                return View("Index", systems);
            }
            return View("Error");
        }

        // GET: User_Types/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User_Types/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Systems_Name)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(new { Systems_Name });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Systems", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Error al crear el sistema");
                }
            }
            return View();
        }

        // GET: User_Types/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"Systems/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var system = JsonConvert.DeserializeObject<SystemsVModel>(content);

                // Si la solicitud GET es exitosa, procedemos a la eliminación del sistema
                var responseDelete = await _httpClient.DeleteAsync($"Systems/{id}");
                if (responseDelete.IsSuccessStatusCode)
                {
                    return View(system);
                }
            }

            ModelState.AddModelError(string.Empty, "No se pudo eliminar el sistema. Por favor, inténtalo de nuevo.");
            return View("Error");
        }

        // GET: User_Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"Systems/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var system = JsonConvert.DeserializeObject<SystemsVModel>(content);
                return View(system);
            }

            ModelState.AddModelError(string.Empty, "No se pudo recuperar el sistema para editar. Por favor, inténtalo de nuevo.");
            return View("Error");
        }

        // POST: User_Types/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Systems_Name)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(new { Systems_Name });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Systems/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ModelState.AddModelError(string.Empty, "No se pudo editar el sistema. Por favor, inténtalo de nuevo.");
            return View();
        }
    }
}
