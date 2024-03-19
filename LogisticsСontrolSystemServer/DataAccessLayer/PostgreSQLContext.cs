using LogisticsСontrolSystemServer.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsСontrolSystemServer.DataAccessLayer
{
    public class PostgreSQLContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        //public DbSet<Board> Boards { get; set; }

        //public DbSet<Column> Columns { get; set; }

        //public DbSet<Card> Cards { get; set; }

        //public DbSet<User> Users { get; set; }

        public PostgreSQLContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Server=localhost;Port=5432;Database=logistics_control_system_database;User Id=postgres;Password=root");
        }
    }
}
