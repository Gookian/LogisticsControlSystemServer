using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : GenericApiController<Warehouse>
    {
        public WarehouseController() : base()
        {
        }
    }
}
