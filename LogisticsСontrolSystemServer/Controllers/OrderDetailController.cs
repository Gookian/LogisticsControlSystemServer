﻿using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : GenericApiController<OrderDetail>
    {
        public OrderDetailController() : base()
        {
        }

        public override ActionResult<IEnumerable<OrderDetail>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = base.repository.GetWithInclude(
                x => x.Order,
                y => y.ProductData);

            return Ok(entities);
        }

        public override ActionResult<OrderDetail> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.OrderDetailId == id,
                y => y.Order,
                z => z.ProductData)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
