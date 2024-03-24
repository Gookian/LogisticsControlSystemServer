using LogisticsСontrolSystemServer.DataAccessLayer;
using LogisticsСontrolSystemServer.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    public abstract class GenericApiController<TEntity> : ControllerBase
        where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> repository;

        protected GenericApiController()
        {
            this.repository = new EFGenericRepository<TEntity>(new PostgreSQLContext());
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<TEntity>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.Get();

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual ActionResult<TEntity> GetOne(int id)
        {
            var foundEntity = repository.FindById(id);

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }


        [HttpPost]
        public ActionResult<TEntity> Create([FromBody] TEntity toCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = repository.Create(toCreate);

            return Ok(created);
        }

        [HttpPut]
        public ActionResult<TEntity> Update([FromBody] TEntity toUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = repository.Update(toUpdate);

            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }


        [HttpDelete("{id}")]
        public ActionResult<TEntity> Delete(int id)
        {
            var entity = repository.FindById(id);

            if (entity == null)
            {
                return NotFound();
            }

            repository.Remove(entity);

            return Ok(entity);
        }
    }
}
