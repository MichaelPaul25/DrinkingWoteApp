﻿using ClientSide_DrinkingWoteApp.Models;
using ClientSide_DrinkingWoteApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ClientSide_DrinkingWoteApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository _orderRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository();
        }
        public async Task<IActionResult> Index()
        {
            List<Order> orderList = new List<Order>();

            orderList = _orderRepository.GetOrders();

            return View(orderList);
        }
    }
}
