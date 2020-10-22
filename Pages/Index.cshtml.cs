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
using Microsoft.Extensions.Configuration;
using nCov1._0.Models;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace nCov1._0.Pages
{
    public class IndexModel : PageModel
    {
        private nCov10Context _context { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, nCov10Context context, IConfiguration Configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = Configuration;
        }
        public string url = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
        public string key = ".json?access_token=pk.eyJ1IjoicmVra2VyMjIiLCJhIjoiY2tjMXgzZTBmMWY5NDMwbjR2dzM0YjN3aiJ9.7l8XoNMK16WzYeYlE9mahQ";

        public async Task OnGet()
        {
            var todaysdate = "";
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "LastupdateDatabase.xml");
            }
            catch (Exception)
            {
                new XDocument(new XElement("date", "21-10-20")).Save(AppDomain.CurrentDomain.BaseDirectory + "LastupdateDatabase.xml"); ;
                xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "LastupdateDatabase.xml");
                todaysdate = xmlDoc.SelectSingleNode("date").InnerText;
            }


            if (DateTime.UtcNow.ToString("d") != todaysdate)
            {
                xmlDoc.SelectSingleNode("date").InnerText = DateTime.UtcNow.ToString("d");

                xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "LastupdateDatabase.xml");
                
                try
                {
                    HttpClient client = new HttpClient();
                    var responseString = await client.GetStringAsync("https://api.covid19india.org/v2/state_district_wise.json");
                    List<NCovStateData> ncovlist = _context.NCovStateData.ToList();
                    List<stateData> stateDatas = JsonConvert.DeserializeObject<List<stateData>>(responseString);
                    List<string> badDistrict = new List<string>() { "Unassigned", "Unknown", "Foreign Evacuees", "Other State", "Airport Quarantine" };
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
                                //await _context.SaveChangesAsync();
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
