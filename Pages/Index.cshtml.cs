using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace nCov1._0.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string url = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
        public string key = ".json?access_token=pk.eyJ1IjoicmVra2VyMjIiLCJhIjoiY2tjMXgzZTBmMWY5NDMwbjR2dzM0YjN3aiJ9.7l8XoNMK16WzYeYlE9mahQ";
        public void OnGet()
        {

        }
    }
}
