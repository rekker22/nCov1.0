using System.Collections.Generic;

namespace nCov1._0.Models
{
    public class stateData
    {
        public string state { get; set; }
        public string stateCode { get; set; }
        public List<Districtdata> districtData { get; set; }
    }
    public class Districtdata
    {
        public string district { get; set; }
        public string notes { get; set; }
        public int active { get; set; }
        public int confirmed { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
        public Delta delta { get; set; }
    }
    public class Delta
    {
        public int confirmed { get; set; }
        public int deceased { get; set; }
        public int recovered { get; set; }
    }

}
