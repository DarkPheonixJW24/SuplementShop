﻿namespace SuplementShop.Application.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
    }
}