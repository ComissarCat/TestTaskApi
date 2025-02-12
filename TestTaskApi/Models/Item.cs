﻿namespace TestTaskApi.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public string? Category { get; set; }
        public Item(ViewModels.Item item)
        {
            Code = item.Code;
            Name = item.Name;
            Price = item.Price;
            Category = item.Category;
        }
    }
}
