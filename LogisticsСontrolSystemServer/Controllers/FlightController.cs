using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : GenericApiController<Flight>
    {
        public FlightController() : base()
        {
        }

        public override ActionResult<IEnumerable<Flight>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = base.repository.GetWithInclude(
                x => x.Vehicle);

            return Ok(entities);
        }

        public override ActionResult<Flight> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.FlightId == id,
                y => y.Vehicle)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
