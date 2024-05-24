using Irrigation_management_app.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Irrigation_management_app.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;

        public UsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://www.irrigationmanagementudec.somee.com/api/");
            //_httpClient.BaseAddress = new Uri("http://localhost:5011/api/");

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Users/login?username={username}&password={password}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UsersVModel>(content);

                    // Verificar si el usuario es válido y está activo
                    if (user != null && user.User_Type_Id == 2)
                    {
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                    // Puedes agregar más reclamaciones aquí si es necesario
                };

                        var claimsIdentity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "El usuario no tiene permiso para acceder.";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Credenciales inválidas. Por favor, inténtalo de nuevo.";
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada, como registrarla o notificar al usuario
                TempData["ErrorMessage"] = "Ocurrió un error durante el proceso de autenticación. Por favor, inténtalo de nuevo.";
                // También puedes registrar el mensaje de error para fines de depuración
                Console.WriteLine($"Error during authentication: {ex.Message}");
            }

            return RedirectToAction("Login");
        }

        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

                
            if (User.Identity.IsAuthenticated)
            {
                return View(user);
            }
            else
            {
                // Usuario no autenticado, redirigir a la vista de login
                return RedirectToAction("Login", "Users");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Users"); 
        }
        [Authorize]
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
