using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskApi.Models;

namespace TestTaskApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ApplicationContext applicationContext;
        public ManagerController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<IActionResult> ConfirmOrderAsync(ViewModels.Order order)
        {
            if (order.Id is null)
                return BadRequest();
            var orderToConfirm = await applicationContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderToConfirm is null)
                return BadRequest();
            orderToConfirm.ShipmentDate = order.ShipmentDate;
            orderToConfirm.Status = OrderStatus.InProgress;
            await applicationContext.SaveChangesAsync();
            return Ok();
        }

        public async Task<IActionResult> CompleteOrderAsync(ViewModels.Order order)
        {
            if (order.Id is null)
                return BadRequest();
            var orderToConfirm = await applicationContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderToConfirm is null)
                return BadRequest();
            orderToConfirm.Status = OrderStatus.Complete;
            await applicationContext.SaveChangesAsync();
            return Ok();
        }
    }
}
