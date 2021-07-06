using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ceremedullum.Api.Models;
using Ceremedullum.Api.Services.CosmosDbService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ceremedullum.Api.Controllers
{
    [Route("patientapi/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        // GET: api/Patient
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Patient/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            var cosmosDb = new CosmosDbService();
            Task<Patient> thisTask = cosmosDb.QueryReadPatientFile(id);

            if (thisTask.Result != null)
            {
                var result = thisTask.Result.PatientId.ToString();
                result += ",";
                result += thisTask.Result.Sex.ToString();
                result += ",";
                result += thisTask.Result.BirthYear.ToString();
                result += ",";
                var ptHistory = thisTask.Result.PatientHistory;

                foreach (var pt in ptHistory) // Loop through List with foreach
                {
                    result += pt.PatientId;
                    result += ",";
                    result += pt.VisitDate;
                    result += ",";
                    result += pt.VisitTime;
                    result += ",";
                    result += pt.VisitDescription;
                    result += ",";
                }
                
                return result;
            }

            return "Not found";
        }

        // POST: api/Patient
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
