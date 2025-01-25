using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskApi.Models;

namespace TestTaskApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public partial class ItemsController(ApplicationContext applicationContext) : ControllerBase
    {
        [GeneratedRegex(@"[0-9]{2}-[0-9]{4}-[A-Z]{2}[0-9]{2}")]
        private static partial Regex ItemCodeRegex();

        public async Task<IActionResult> GetItemsAsync()
        {
            return new JsonResult(await applicationContext.Items.ToListAsync());
        }

        public async Task<IActionResult> AddItemAsync(ViewModels.Item item)
        {
            Regex regex = ItemCodeRegex();
            if (!regex.IsMatch(item.Code))
                return BadRequest();
            await applicationContext.Items.AddAsync(new Item(item));
            await applicationContext.SaveChangesAsync();
            return Ok();
        }

        public async Task<IActionResult> EditItemAsync(ViewModels.Item item)
        {
            if (item.Id is null)
                return BadRequest();
            var itemToEdit = await applicationContext.Items.FirstOrDefaultAsync(i => i.Id == item.Id);
            if (itemToEdit is null)
                return BadRequest();
            Regex regex = ItemCodeRegex();
            if (!regex.IsMatch(item.Code))
                return BadRequest();
            itemToEdit.Code = item.Code;
            itemToEdit.Name = item.Name;
            itemToEdit.Price = item.Price;
            itemToEdit.Category = item.Category;
            await applicationContext.SaveChangesAsync();
            return Ok();
        }

        public async Task<IActionResult> RemoveItemAsync(ViewModels.Item item)
        {
            if (item.Id is null)
                return BadRequest();
            var itemToEdit = await applicationContext.Items.FirstOrDefaultAsync(i => i.Id == item.Id);
            if (itemToEdit is null)
                return BadRequest();
            applicationContext.Items.Remove(itemToEdit);
            await applicationContext.SaveChangesAsync();
            return Ok();
        }
    }
}
