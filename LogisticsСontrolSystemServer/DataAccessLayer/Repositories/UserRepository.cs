using LogisticsСontrolSystemServer.Models;

namespace LogisticsСontrolSystemServer.DataAccessLayer.Repositories
{
    public class UserRepository
    {
        public PostgreSQLContext context = new PostgreSQLContext();

        public User? Get(string userName, string password)
        {
            return context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }
    }
}
