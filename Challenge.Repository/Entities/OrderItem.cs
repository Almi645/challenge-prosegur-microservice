﻿namespace Challenge.Repository.Entities
{
    public class OrderItem : BaseEntity
    {
        public int productId { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }
    }
}
