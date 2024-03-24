using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStateController : GenericApiController<ProductState>
    {
        public ProductStateController() : base()
        {
        }
    }
}
