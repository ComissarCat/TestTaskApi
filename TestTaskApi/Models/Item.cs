﻿using System.Data;

namespace TestTaskApi.Models
{
    public class Item : DataSet
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public string? Category { get; set; }
    }
}
