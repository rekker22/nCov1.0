using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nCov1._0.Models;
using Newtonsoft.Json;

namespace nCov1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCovStateDatasController : ControllerBase
    {
        private readonly nCov10Context _context;

        public NCovStateDatasController(nCov10Context context)
        {
            _context = context;
        }

        // GET: api/NCovStateDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NCovStateData>>> GetNCovStateData()
        {
            return await _context.NCovStateData.ToListAsync();
        }

        // GET: api/NCovStateDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NCovStateData>> GetNCovStateData(string id)
        {
            var nCovStateData = await _context.NCovStateData.FindAsync(id);

            if (nCovStateData == null)
            {
                return NotFound();
            }

            return nCovStateData;
        }

        // PUT: api/NCovStateDatas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNCovStateData(string id, NCovStateData nCovStateData)
        {
            if (id != nCovStateData.SdCode)
            {
                return BadRequest();
            }

            _context.Entry(nCovStateData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCovStateDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NCovStateDatas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEnumerable<NCovStateData>>> PostNCovStateData()
        {
            //_context.NCovStateData.Add(nCovStateData);
            try
            {
                string json = new WebClient().DownloadString("https://api.covid19india.org/v2/state_district_wise.json");
                List<stateData> stateDatas = JsonConvert.DeserializeObject<List<stateData>>(json);
                //dynamic d = JObject.Parse(json);
                //await _context.SaveChangesAsync();
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

                                NCovStateData ncsd = new NCovStateData();
                                string url = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
                                string key = ".json?access_token=pk.eyJ1IjoicmVra2VyMjIiLCJhIjoiY2tjMXgzZTBmMWY5NDMwbjR2dzM0YjN3aiJ9.7l8XoNMK16WzYeYlE9mahQ";
                                ncsd.SName = item.state;
                                string dsplit = "";
                                string ssplit = "";
                                foreach (string s in dD.district.Split(null))
                                {
                                    dsplit += s + "+";
                                }
                                foreach (string s in item.state.Split(null))
                                {
                                    ssplit += s + "+";
                                }
                                using (HttpClient client = new HttpClient())
                                {
                                    using (HttpResponseMessage response = await client.GetAsync(url + dsplit + "+" + ssplit + "+" + "India" + key))
                                    {
                                        if (response.IsSuccessStatusCode)
                                        {
                                            dynamic data = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                                            ncsd.LatCoordinates = data.features[0].center[1];
                                            ncsd.LongCoordinates = data.features[0].center[0];
                                            ncsd.SdCode = item.stateCode + "_" + dD.district;
                                            //ncsd.SdCode = i.ToString();
                                            ncsd.DName = dD.district;
                                            ncsd.TotalCases = dD.confirmed;
                                            await _context.NCovStateData.AddAsync(ncsd);
                                        }
                                        else
                                        {
                                            NoDistrict.Add(dD.district + item.state);
                                        }
                                    }
                                }


                            }


                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                //if (NCovStateDataExists(nCovStateData.SdCode))
                //{
                //    return Conflict();
                //}
                //else
                //{
                //    throw;
                //}
                throw;
            }

            return await _context.NCovStateData.ToListAsync();

            //return CreatedAtAction("GetNCovStateData", new { id = nCovStateData.SdCode }, nCovStateData);
        }

        [HttpPatch]
        public async Task<ActionResult<IEnumerable<NCovStateData>>> PatchNCovStateData()
        {
            try
            {
                string json = new WebClient().DownloadString("https://api.covid19india.org/v2/state_district_wise.json");
                List<stateData> stateDatas = JsonConvert.DeserializeObject<List<stateData>>(json);
                //dynamic d = JObject.Parse(json);
                //await _context.SaveChangesAsync();
                List<NCovStateData> ncovlist = _context.NCovStateData.ToList();
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
                                if(result != null)
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
                //if (NCovStateDataExists(nCovStateData.SdCode))
                //{
                //    return Conflict();
                //}
                //else
                //{
                //    throw;
                //}
                throw;
            }

            return await _context.NCovStateData.ToListAsync();
        }

        // DELETE: api/NCovStateDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NCovStateData>> DeleteNCovStateData(string id)
        {
            var nCovStateData = await _context.NCovStateData.FindAsync(id);
            if (nCovStateData == null)
            {
                return NotFound();
            }

            _context.NCovStateData.Remove(nCovStateData);
            await _context.SaveChangesAsync();

            return nCovStateData;
        }

        private bool NCovStateDataExists(string id)
        {
            return _context.NCovStateData.Any(e => e.SdCode == id);
        }
    }
}
