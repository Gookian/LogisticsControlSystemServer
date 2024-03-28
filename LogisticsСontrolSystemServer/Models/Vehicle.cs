using LogisticsСontrolSystemServer.Models.Enum;

namespace LogisticsСontrolSystemServer.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [StringValue("Владелец")]
        public string Name { get; set; }

        [StringValue("Тип")]
        public string Type { get; set; }

        [StringValue("Марка")]
        public string Brand { get; set; }

        [IdTargetValue]
        [StringValue("Регистрационный номер")]
        public string RegistrationNumber { get; set; }

        [StringValue("Вместимость")]
        public int Capacity { get; set; }

        [StringValue("Грузоподемность")]
        public int LoadCapacity { get; set; }
}
}
