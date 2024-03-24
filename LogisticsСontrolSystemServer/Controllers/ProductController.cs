using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : GenericApiController<Product>
    {
        public ProductController() : base()
        {
        }

        public override ActionResult<IEnumerable<Product>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = base.repository.GetWithInclude(
                x => x.ProductData,
                y => y.ProductState);

            return Ok(entities);
        }

        public override ActionResult<Product> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.ProductId == id,
                y => y.ProductData,
                z => z.ProductState)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
