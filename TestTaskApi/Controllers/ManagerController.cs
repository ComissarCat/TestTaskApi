using Microsoft.AspNetCore.Mvc;
using TestTaskApi.Models;

namespace TestTaskApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ManagerController(ApplicationContext applicationContext) : ControllerBase
    {
    }
}
