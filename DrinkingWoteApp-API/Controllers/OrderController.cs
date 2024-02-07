using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkingWoteApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //Get All Order
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orders);
        }

        //Get Details Order by Id
        [HttpGet("OrderId")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderDetail(int OrderId)
        {
            var orderDetail = _orderRepository.GetOrderDetail(OrderId);

            if(orderDetail == null)
                return NotFound($"Order Not {OrderId} Found!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orderDetail);
        }

        //Get Process Order
        [HttpGet("ProcessOrders/")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetProcessOrder()
        {
            var processOrder = _orderRepository.GetProcessOrder();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(processOrder);
        }

        //Get Process Order
        [HttpGet("CountProcess/")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult CountProcessOrder()
        {
            var count = _orderRepository.CountProcessOrder();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(count);
        }
    }
}
