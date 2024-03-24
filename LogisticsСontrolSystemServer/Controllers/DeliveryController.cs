using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : GenericApiController<Delivery>
    {
        public DeliveryController() : base()
        {
        }

        public override ActionResult<IEnumerable<Delivery>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = base.repository.GetWithInclude(
                x => x.Warehouse,
                y => y.DeliveryPoint,
                z => z.Package,
                w => w.Flight);

            return Ok(entities);
        }

        public override ActionResult<Delivery> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.DeliveryPointId == id,
                y => y.Warehouse,
                z => z.DeliveryPoint,
                w => w.Package,
                v => v.Flight)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
