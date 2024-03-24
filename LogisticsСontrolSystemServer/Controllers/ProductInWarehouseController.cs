using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInWarehouseController : GenericApiController<ProductInWarehouse>
    {
        public ProductInWarehouseController() : base()
        {
        }

        public override ActionResult<IEnumerable<ProductInWarehouse>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = base.repository.GetWithInclude(
                x => x.Product,
                y => y.Warehouse);

            return Ok(entities);
        }

        public override ActionResult<ProductInWarehouse> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.ProductInWarehouseId == id,
                y => y.Product,
                z => z.Warehouse)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
