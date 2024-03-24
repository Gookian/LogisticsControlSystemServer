using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryPointController : GenericApiController<DeliveryPoint>
    {
        public DeliveryPointController() : base()
        {
        }
    }
}
