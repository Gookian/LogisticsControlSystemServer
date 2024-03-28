using LogisticsСontrolSystemServer.Models.Enum;

namespace LogisticsСontrolSystemServer.Models
{
    public class ProductState
    {
        public int ProductStateId { get; set; }

        [IdTargetValue]
        public string Name { get; set; }
    }
}
