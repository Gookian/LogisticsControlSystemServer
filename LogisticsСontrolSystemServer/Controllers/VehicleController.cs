using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : GenericApiController<Vehicle>
    {
        public VehicleController() : base()
        {
        }
    }
}
