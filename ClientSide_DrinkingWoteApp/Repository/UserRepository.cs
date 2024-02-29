using ClientSide_DrinkingWoteApp.Dto;
using ClientSide_DrinkingWoteApp.Interfaces;
using ClientSide_DrinkingWoteApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace ClientSide_DrinkingWoteApp.Repository
{
    public class UserRepository 
    {
        Uri baseAddress = new Uri("https://localhost:7280/api");
        private readonly HttpClient _client;
        public UserRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public bool SignUp(UserDto user)
        {
            try
            {
                string newUser = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(newUser, Encoding.UTF8, "application/json");

                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/User/CreateUser", content).Result;

                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<User> GetAllUsers()
        //{
        //    //IEnumerable<User> userList = new IEnumerable<User>();
        //    //HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/User").Result;

        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    string data = response.Content.ReadAsStringAsync().Result;
        //    //    userList = JsonConvert.DeserializeObject<IEnumerable<User>>(data);
        //    //}

        //    //return userList;
        //}

        public Task<User> GetUserDetail(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
