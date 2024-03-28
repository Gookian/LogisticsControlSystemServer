using LogisticsСontrolSystemServer.Models.Enum;

namespace LogisticsСontrolSystemServer.Models
{
    public class PackageState
    {
        public int PackageStateId { get; set; }

        [IdTargetValue]
        public string Name { get; set; }
    }
}
