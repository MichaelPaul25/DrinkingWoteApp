using ClientSide_DrinkingWoteApp.Dto;
using ClientSide_DrinkingWoteApp.Models;
using ClientSide_DrinkingWoteApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClientSide_DrinkingWoteApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderRepository _orderRepository;

        public HomeController()
        {
            _orderRepository = new OrderRepository();
        }

        public async Task<IActionResult> Index()
        {
            HomePageDataDTO dataDto = new HomePageDataDTO();

            dataDto = await _orderRepository.GetHomePageData();
            
            return View(dataDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
