using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nCov1._0.Models;
using Newtonsoft.Json;

namespace nCov1._0.Pages
{
    public class IndexModel : PageModel
    {
        private nCov10Context _context { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, nCov10Context context)
        {
            _logger = logger;
            _context = context;
        }
        public string url = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
        public string key = ".json?access_token=pk.eyJ1IjoicmVra2VyMjIiLCJhIjoiY2tjMXgzZTBmMWY5NDMwbjR2dzM0YjN3aiJ9.7l8XoNMK16WzYeYlE9mahQ";
        string todaysdate = "22-09-2020";
        NCovStateData nc = new NCovStateData
        {
            SdCode = "None",
            SName = "None",
            DName = "None",
            TotalCases = 0,
            LatCoordinates = 0,
            LongCoordinates = 0
        };

        public async Task OnGet()
        {
            if(DateTime.UtcNow.ToString("d") != todaysdate)
            {
                todaysdate = DateTime.UtcNow.ToString("d");
                try
                {
                    string json = new WebClient().DownloadString("https://api.covid19india.org/v2/state_district_wise.json");
                    List<stateData> stateDatas = JsonConvert.DeserializeObject<List<stateData>>(json);
                    List<NCovStateData> ncovlist = _context.NCovStateData.ToList();
                    List<string> badDistrict = new List<string>() { "Unassigned", "Unknown", "Foreign Evacuees", "Other State", "Airport Quarantine" };
                    List<string> NoDistrict = new List<string>();
                    foreach (stateData item in stateDatas)
                    {
                        if (item.state != "State Unassigned")
                        {
                            foreach (Districtdata dD in item.districtData)
                            {
                                if (!badDistrict.Contains(dD.district))
                                {
                                    var result = _context.NCovStateData.SingleOrDefault(b => b.SdCode == (item.stateCode + "_" + dD.district));
                                    if (result != null)
                                    {
                                        result.TotalCases = dD.confirmed;
                                    }

                                }
                                await _context.SaveChangesAsync();

                            }
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }

                
            }

        }
    }
}
