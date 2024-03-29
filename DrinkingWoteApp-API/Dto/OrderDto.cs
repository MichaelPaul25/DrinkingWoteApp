﻿using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ConsumentId { get; set; }
        public string? StatusOrder { get; set; }
        public int? Qty { get; set; }
        public DateTime? TimeOrder { get; set; }
        public DateTime? OrderDone { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public int CrewId { get; set; }

    }
}
