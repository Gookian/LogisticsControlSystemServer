using LogisticsСontrolSystemServer.Models.Enum;

namespace LogisticsСontrolSystemServer.Models
{
    public class Flight
    {
        public int FlightId { get; set; }

        [IdTargetValue]
        public string Number { get; set; }

        // Внешние ключи
        [StringValue("Транспортное средство")]
        public int VehicleId { get; set; }

        // Ссылки на объекты внешнего ключа
        public Vehicle? Vehicle { get; set; }
    }
}
