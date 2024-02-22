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

        public IActionResult Index()
        {
            List<Order> orderList = new List<Order>();

            orderList = _orderRepository.GetOrders();

            return View(orderList);
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
