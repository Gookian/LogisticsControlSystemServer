using LogisticsСontrolSystemServer.DataAccessLayer;
using LogisticsСontrolSystemServer.DataAccessLayer.Repositories;
using LogisticsСontrolSystemServer.Models;
using LogisticsСontrolSystemServer.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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

        [HttpGet("Structure")]
        public virtual ActionResult<List<StructureItem>> GetStructure()
        {
            Type type = typeof(TEntity);

            PropertyInfo[] properties = type.GetProperties();

            List<StructureItem> results = new List<StructureItem>();

            foreach (PropertyInfo property in properties)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(StringValueAttribute)) as StringValueAttribute;

                if (attribute != null)
                {
                    string title = attribute.Value;

                    results.Add(new StructureItem()
                    {
                        Type = property.PropertyType.Name,
                        Name = property.Name,
                        Title = title,
                    });
                }
            }

            return Ok(results);
        }

        [HttpGet("IdTargetValue")]
        public virtual ActionResult<List<IdTargetValueItem>> GetIdTargetValue()
        {
            List<IdTargetValueItem> results = new List<IdTargetValueItem>();

            var entities = repository.Get();

            foreach (var entity in entities)
            {
                int id = 0;
                string value = "";

                Type type = entity.GetType();

                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    var attribute = Attribute.GetCustomAttribute(property, typeof(IdTargetValueAttribute)) as IdTargetValueAttribute;

                    if (typeof(TEntity).Name + "Id" == property.Name)
                    {
                        id = Convert.ToUInt16(property.GetValue(entity));
                    }

                    if (attribute != null)
                    {
                        value = Convert.ToString(property.GetValue(entity));
                    }
                }

                results.Add(new IdTargetValueItem()
                {
                    Id = id,
                    Value = value,
                });
            }

            return Ok(results);
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
