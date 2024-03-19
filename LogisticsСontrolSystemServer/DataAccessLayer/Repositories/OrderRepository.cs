using LogisticsСontrolSystemServer.Models;

namespace LogisticsСontrolSystemServer.DataAccessLayer.Repositories
{
    public class OrderRepository
    {
        public PostgreSQLContext db = new PostgreSQLContext();

        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public Order Add(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();

            return order;
        }
    }
}
