using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nCov1._0.API.Models;
using nCov1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nCov1._0.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ncsdGetController : ControllerBase
    {


        private readonly nCov10Context _context;

        public ncsdGetController(nCov10Context context)
        {
            _context = context;
        }

        // GET: api/NCovStateDatas
        [HttpGet]
        public List<List<double?>> GetNCovStateData()
        {
            List<NCovStateData> ncovlist = _context.NCovStateData.ToList();
            List<List<double?>> result = new List<List<double?>>();
            foreach (NCovStateData item in ncovlist)
            {
                List<double?> aList = new List<double?>();
                aList.Add(item.LatCoordinates);
                aList.Add(item.LongCoordinates);
                aList.Add(item.TotalCases);
                result.Add(aList);
            }

            return result;
            //return await _context.NCovStateData.ToListAsync();
        }
    }
}
