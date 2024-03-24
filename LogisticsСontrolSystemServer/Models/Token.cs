namespace LogisticsСontrolSystemServer.Models
{
    public class Token
    {
        public Guid TokenId { get; set; }
        public DateTime LifeTime { get; set; }
        public User User { get; set; }
    }
}
