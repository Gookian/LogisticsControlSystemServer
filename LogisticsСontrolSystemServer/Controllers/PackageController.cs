using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : GenericApiController<Package>
    {
        public PackageController() : base()
        {
        }

        public override ActionResult<IEnumerable<Package>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = base.repository.GetWithInclude(
                x => x.PackageState);

            return Ok(entities);
        }

        public override ActionResult<Package> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.PackageId == id,
                y => y.PackageState)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
