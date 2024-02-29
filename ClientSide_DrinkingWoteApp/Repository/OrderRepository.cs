using ClientSide_DrinkingWoteApp.Dto;
using ClientSide_DrinkingWoteApp.Interfaces;
using ClientSide_DrinkingWoteApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ClientSide_DrinkingWoteApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        Uri baseAddress = new Uri("https://localhost:7280/api");
        private readonly HttpClient _client;
        public OrderRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public Task<Order> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            List<Order> orderList = new List<Order>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Order").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                orderList = JsonConvert.DeserializeObject<List<Order>>(data);
            }

            return orderList;
        }

        public bool CreateOrder(Order order, int consumentId, int crewId)
        {
            try
            {
                string dataOrder = JsonConvert.SerializeObject(order);
                StringContent content = new StringContent(dataOrder, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Order/CreateOrder/"+ consumentId + "/" + crewId, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
