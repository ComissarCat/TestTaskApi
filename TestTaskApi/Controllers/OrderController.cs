using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskApi.Models;
using TestTaskApi.ViewModels;

namespace TestTaskApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController(ApplicationContext applicationContext) : ControllerBase
    {
        public async Task<ActionResult> AddOrderAsync(NewOrder newOrder)
        {
            var customer = await applicationContext.Customers.FirstOrDefaultAsync(c => c.Id == newOrder.CustomerId);
            if (customer is null)
                return BadRequest();
            Order order = new() { Customer = customer, Status = OrderStatus.New, OrderDate = DateOnly.FromDateTime(DateTime.Now) };
            await applicationContext.Orders.AddAsync(order);
            bool atLeastOneItem = false;
            foreach (var item in newOrder.OrderItems)
            {
                if (item.ItemsCount <= 0)
                    continue;
                var newItem = await applicationContext.Items.FirstOrDefaultAsync(i => i.Id == item.ItemId);
                if (newItem is null)
                    continue;
                if (newItem.Price is null)
                    continue;
                Models.OrderItem newOrderItem = new() { Order = order, Item = newItem, ItemsCount = item.ItemsCount };
                newOrderItem.CalculateItemPrice(newItem.Price.Value, customer.Discount);
                await applicationContext.OrderItems.AddAsync(newOrderItem);
                atLeastOneItem = true;
            }
            if (atLeastOneItem)
            {
                await applicationContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        public async Task<ActionResult> RemoveOrderAsync(ExistingOrder order)
        {
            if (order.CustomerId is null)
                return BadRequest();
            var orderToRemove = await applicationContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderToRemove is null)
                return BadRequest();
            if (orderToRemove.Customer.Id == order.CustomerId && orderToRemove.Status == OrderStatus.New)
            {
                applicationContext.Remove(orderToRemove);
                await applicationContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        public async Task<IActionResult> ConfirmOrderAsync(ExistingOrder order)
        {
            if (order.ShipmentDate is null)
                return BadRequest();
            var orderToConfirm = await applicationContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderToConfirm is null)
                return BadRequest();
            orderToConfirm.ShipmentDate = order.ShipmentDate;
            orderToConfirm.Status = OrderStatus.InProgress;
            await applicationContext.SaveChangesAsync();
            return Ok();
        }

        public async Task<IActionResult> CompleteOrderAsync(ExistingOrder order)
        {
            var orderToConfirm = await applicationContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderToConfirm is null)
                return BadRequest();
            orderToConfirm.Status = OrderStatus.Complete;
            await applicationContext.SaveChangesAsync();
            return Ok();
        }
    }
}
