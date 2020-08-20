using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nCov1._0.API.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public double TemperatureC { get; set; }

        public double TemperatureF => 32 + (TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
