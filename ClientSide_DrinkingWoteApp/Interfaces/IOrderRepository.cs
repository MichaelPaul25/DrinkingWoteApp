﻿using ClientSide_DrinkingWoteApp.Dto;
using ClientSide_DrinkingWoteApp.Models;

namespace ClientSide_DrinkingWoteApp.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Task<Order> GetById(int id);
        bool CreateOrder(Order order, int consumentId, int crewId);
    }
}
