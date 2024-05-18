using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Irrigation_management_app.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;

        public UsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.irrigationmanagementudec.somee.com/api/");
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Users");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<IEnumerable<UsersVModel>>(content);
                return View("Index", users);
            }
            return View("Error");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userResponse = await _httpClient.GetAsync($"Users/{id}");
            var userTypeResponse = await _httpClient.GetAsync($"User_Types");

            if (userResponse.IsSuccessStatusCode && userTypeResponse.IsSuccessStatusCode)
            {
                var userContent = await userResponse.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UsersVModel>(userContent);

                var userTypeContent = await userTypeResponse.Content.ReadAsStringAsync();
                var userTypes = JsonConvert.DeserializeObject<List<User_TypesVModel>>(userTypeContent);

                ViewBag.UserTypes = userTypes;
                return View(user);
            }

            ModelState.AddModelError(string.Empty, "No se pudo recuperar el usuario para editar. Por favor, inténtalo de nuevo.");
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsersVModel user)
        {
            if (id != user.Users_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Users/app/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ModelState.AddModelError(string.Empty, "No se pudo editar el usuario. Por favor, inténtalo de nuevo.");
            return View(user);
        }

        public async Task<IActionResult> Create()
        {
            var userTypeResponse = await _httpClient.GetAsync($"User_Types");
            if (userTypeResponse.IsSuccessStatusCode)
            {
                var userTypeContent = await userTypeResponse.Content.ReadAsStringAsync();
                var userTypes = JsonConvert.DeserializeObject<List<User_TypesVModel>>(userTypeContent);

                ViewBag.UserTypes = userTypes;
                return View();
            }

            ModelState.AddModelError(string.Empty, "Error al recuperar los tipos de usuario. Por favor, inténtalo de nuevo.");
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersVModel user)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Users/app", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Error al crear usuario");
                }
            }

            var userTypeResponse = await _httpClient.GetAsync($"User_Types");
            if (userTypeResponse.IsSuccessStatusCode)
            {
                var userTypeContent = await userTypeResponse.Content.ReadAsStringAsync();
                var userTypes = JsonConvert.DeserializeObject<List<User_TypesVModel>>(userTypeContent);

                ViewBag.UserTypes = userTypes;
            }

            return View(user);
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"Users/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UsersVModel>(content);

                // If GET request is successful, proceed to delete the user
                var responseDelete = await _httpClient.DeleteAsync($"Users/{id}");
                if (responseDelete.IsSuccessStatusCode)
                {
                    return View(user);
                }
            }

            ModelState.AddModelError(string.Empty, "No se pudo eliminar el usuario. Por favor, inténtalo de nuevo.");
            return View("Error");
        }
    }
}
