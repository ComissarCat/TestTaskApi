﻿using Microsoft.EntityFrameworkCore;

namespace TestTaskApi.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
