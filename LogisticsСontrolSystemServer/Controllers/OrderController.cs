using LogisticsСontrolSystemServer.DataAccessLayer.Repositories;
using LogisticsСontrolSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    public class OrderController : Controller
    {
        OrderRepository repository = new OrderRepository();

        public string Add(Order order)
        {
            repository.Add(order);
            return "Added";
        }

        public string GetAll()
        {
            List<Order> orders = repository.GetAll();
            return orders.Count.ToString();
        }
    }
}
