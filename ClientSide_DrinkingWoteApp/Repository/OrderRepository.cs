using ClientSide_DrinkingWoteApp.Dto;
using ClientSide_DrinkingWoteApp.Interfaces;
using ClientSide_DrinkingWoteApp.Models;
using Newtonsoft.Json;

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

        public async Task<HomePageDataDTO?> GetHomePageData()
        {
            HomePageDataDTO dataDTO = new HomePageDataDTO();

            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Order/GetHomePageData").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                dataDTO = JsonConvert.DeserializeObject<HomePageDataDTO>(data);
            }

            return dataDTO;
        }

        private string convertToCurrency(double number)
        {
            string resultCurrency = number.ToString("C0");
            return resultCurrency;
        }
    }
}
