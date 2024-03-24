using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageStateController : GenericApiController<PackageState>
    {
        public PackageStateController() : base()
        {
        }
    }
}
