namespace LogisticsСontrolSystemServer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public DateTime DeliveryDateTime { get; set; }
    }
}
