using System.ComponentModel.DataAnnotations;

namespace nCov1._0.Models
{
    public partial class NCovStateData
    {
        public string SdCode { get; set; }
        public string SName { get; set; }
        public string DName { get; set; }
        public long TotalCases { get; set; }
        public double LatCoordinates { get; set; }
        public double LongCoordinates { get; set; }
    }
}
