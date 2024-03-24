﻿using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : GenericApiController<Order>
    {
        public OrderController() : base()
        {
        }
    }
}
