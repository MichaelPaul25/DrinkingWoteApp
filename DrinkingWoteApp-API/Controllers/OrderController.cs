using AutoMapper;
using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Dto;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;
using DrinkingWoteApp_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DrinkingWoteApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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
        //Get Order By Consument Id
        [HttpGet("ConsumentId")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderByConsument(int consumentId)
        {
            var orders = _orderRepository.GetOrdersbyConsument(consumentId);

            if (orders == null)
                return NotFound("Customer don't have any Order");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orders);
        }

        //Get Home Page Data
        [HttpGet("GetHomePageData")]
        [ProducesResponseType(200, Type = typeof(HomePageDataDto))]
        [ProducesResponseType(400)]
        public IActionResult GetHomePageData()
        {
            HomePageDataDto homePageData = new HomePageDataDto();
            homePageData.Orders = _orderRepository.GetAllOrders();

            homePageData.QuickCount = _orderRepository.quickcount();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(homePageData);
        }
        //Get Order Today
        [HttpGet("CountOrderToday/")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult CountOrdersToday()
        {
            var count = _orderRepository.CountOrderToday();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(count);
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
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult CountProcessOrder()
        {
            var count = _orderRepository.CountProcessOrder();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(count);
        }

        //Create new Consument
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromBody] OrderDto createOrder, int ConsumentId, int CrewId)
        {
            if (createOrder == null || ConsumentId == 0 || CrewId ==0)
                return BadRequest("Request Not Valid!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Inject to Consument DTO
            var order = _mapper.Map<Order>(createOrder);

            if (!_orderRepository.CreateOrder(order, ConsumentId, CrewId))
            {
                ModelState.AddModelError("", "Can't Add new Order!");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Create new Order");
        }

        //Update the Order
        [HttpPut("{OrderId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOrder([FromBody] OrderDto updateOrder,
            [FromQuery] int consumentId,
            int OrderId)
        {
            if (updateOrder == null)
                return BadRequest(ModelState);

            if (OrderId != updateOrder.OrderId)
                return BadRequest(ModelState);

            if (!_orderRepository.OrderExist(OrderId))
                return NotFound($"Order Id {OrderId} Not Found!");

            if (!ModelState.IsValid)
                return BadRequest();

            var order = _mapper.Map<Order>(updateOrder);

            if (!_orderRepository.UpdateOrder(order, consumentId, OrderId))
            {
                ModelState.AddModelError("", "Update Order data error!");
                return StatusCode(500, ModelState);
            }

            return Ok("Update Order Successfully");
        }

        //Delete Order
        [HttpDelete("{OrderId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOrder(int OrderId)
        {
            if (!_orderRepository.OrderExist(OrderId))
                return NotFound();

            var orderToDelete = _orderRepository.GetOrderDetail(OrderId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_orderRepository.DeleteOrder(orderToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting order!");
            }

            return Ok("Delete Order Successfully!");
        }
    }
}
