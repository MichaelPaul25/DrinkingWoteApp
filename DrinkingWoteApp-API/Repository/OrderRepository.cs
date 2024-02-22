using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkingWoteApp_API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        //Get all
        public ICollection<Order> GetAllOrders()
        {
            return _context.Orders.Include(c => c.Consument).ToList();
        }

        //Get Order Detail
        public Order GetOrderDetail(int id)
        {
            return _context.Orders.Find(id);
        }

        //Get all Process Order
        public ICollection<Order> GetProcessOrder() 
        {
            var orders = _context.Orders.Where(o => o.StatusOrder == "PROCESS");

            return orders.ToList();
        }

        //Count process Order
        public decimal CountProcessOrder()
        {
            var orders = _context.Orders.Where(o => o.StatusOrder == "PROCESS");

            return orders.Count();
        }

        //Find Exist Order
        public bool OrderExist(int OrderId)
        {
            return _context.Orders.Any(o => o.OrderId == OrderId);
        }

        public bool CreateOrder(Order order, int consumentId, int crewId)
        {
            var consument = _context.Consuments.Where(c => c.Id == consumentId)
                                .Include(a => a.Address).FirstOrDefault();
            var crew = _context.Crewers.Where(a => a.CrewId == crewId).FirstOrDefault();

            order.Consument = consument;
            order.Crew = crew;

            //Total paid
            var price = 5000;
            var totalPaid = order.Qty * price;

            //Create Order Bill
            order.Bill = new Bill()
            {
                Consument = consument,
                TotalPaid = totalPaid,
                Qty = order.Qty,
            };

            _context.Add(order);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Order> GetOrdersbyConsument(int consumentId)
        {
            return _context.Orders.Where(o => o.Consument.Id == consumentId).ToList();
        }

        public bool UpdateOrder(Order order, int consumentId, int OrderId)
        {
            _context.Update(order);
            return Save();
        }

        public bool DeleteOrder(Order order)
        {
            _context.Remove(order);
            return Save();
        }
    }
}
