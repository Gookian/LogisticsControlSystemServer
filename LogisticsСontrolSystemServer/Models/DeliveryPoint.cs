using LogisticsСontrolSystemServer.Models.Enum;

namespace LogisticsСontrolSystemServer.Models
{
    public class DeliveryPoint
    {
        public int DeliveryPointId { get; set; }

        [IdTargetValue]
        [StringValue("Наименование")]
        public string Name { get; set; }

        [StringValue("Адрес")]
        public string Address { get; set; }

        [StringValue("Широта")]
        public float Latitude { get; set; }

        [StringValue("Долгота")]
        public float Longitude { get; set; }
    }
}
