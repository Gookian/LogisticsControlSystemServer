using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageСontentController : GenericApiController<PackageСontent>
    {
        public PackageСontentController() : base()
        {
        }

        public override ActionResult<IEnumerable<PackageСontent>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = base.repository.GetWithInclude(
                x => x.Product,
                y => y.Package);

            return Ok(entities);
        }

        public override ActionResult<PackageСontent> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.PackageСontentId == id,
                y => y.Product,
                z => z.Package)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
