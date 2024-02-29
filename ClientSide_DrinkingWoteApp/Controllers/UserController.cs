using ClientSide_DrinkingWoteApp.Dto;
using ClientSide_DrinkingWoteApp.Models;
using ClientSide_DrinkingWoteApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClientSide_DrinkingWoteApp.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7280/api");
        private readonly HttpClient _client;
        private readonly UserRepository _userRepository;
        public UserController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _userRepository = new UserRepository();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/User/GetUsers").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(data);
            }

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserDto newUser)
        {
            var user = _userRepository.SignUp(newUser);

            if (user)
                return RedirectToAction("Index", "Home");

            else return View();
        }

    }
}
