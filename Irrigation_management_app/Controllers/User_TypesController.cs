using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Irrigation_management_app.Controllers
{
    public class User_TypesController : Controller
    {
        private readonly HttpClient _httpClient;

        public User_TypesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.irrigationmanagementudec.somee.com/api/");
        }

        // GET: User_Types
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("User_Types");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var userTypes = JsonConvert.DeserializeObject<IEnumerable<User_TypesVModel>>(content);
                return View("Index", userTypes);
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
        public async Task<IActionResult> Create(User_TypesVModel user_Type)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(user_Type);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/User_Types", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "error al crear producto");
                }
            }
            return View(user_Type);
        }

        // GET: User_Types/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"User_Types/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var user_Type = JsonConvert.DeserializeObject<User_TypesVModel>(content);

                // Si la solicitud GET es exitosa, procedemos a la eliminación del tipo de usuario
                var responseDelete = await _httpClient.DeleteAsync($"User_Types/{id}");
                if (responseDelete.IsSuccessStatusCode)
                {
                    return View(user_Type);
                }
            }

            ModelState.AddModelError(string.Empty, "No se pudo eliminar el tipo de usuario. Por favor, inténtalo de nuevo.");
            return View("Error");
        }



        // GET: User_Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"User_Types/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var user_Type = JsonConvert.DeserializeObject<User_TypesVModel>(content);
                return View(user_Type);
            }

            ModelState.AddModelError(string.Empty, "No se pudo recuperar el tipo de usuario para editar. Por favor, inténtalo de nuevo.");
            return View("Error");
        }

        // POST: User_Types/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User_TypesVModel user_Type)
        {
            if (id != user_Type.User_Type_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(user_Type);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"User_Types/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ModelState.AddModelError(string.Empty, "No se pudo editar el tipo de usuario. Por favor, inténtalo de nuevo.");
            return View(user_Type);
        }

    }
}