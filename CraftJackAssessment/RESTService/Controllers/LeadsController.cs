using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic;
using Newtonsoft.Json;

namespace RESTService.Controllers
{
    public class LeadsController : ApiController
    {
        LeadList leadList;
        public LeadsController()
        {
            leadList = new LeadList();
            string[] inputValues = {"Rusty Shackleford House Bunker 05/15/2018",
                                    "Jim Harbaugh House Siding 07/19/2018",
                                    "Dante Hicks Trailer Plumbing 05/27/2018",
                                    "Phillip Fry Condo Plumbing 10/21/2018",
                                    "Homer Simpson House Foundation 06/01/2018"};
            foreach (string line in inputValues)
            {
                leadList.AddLead(line);
            }
            
        }
        // GET: api/Leads
        [Route("leads/propertytype")]
        public IEnumerable<string> GetLeadsByPropertyType()
        {
            List<Lead> result = leadList.SortByPropertyTypeThenProject();
            List<string> finalResults = new List<string>();
            foreach(Lead lead in result)
            {
                finalResults.Add(lead.StringToPrint());
            }

            yield return JsonConvert.SerializeObject(finalResults);
        }

        [Route("leads/startdate")]
        public IEnumerable<string> GetLeadsByStartDate()
        {
            List<Lead> result = leadList.SortByStartDate();
            List<string> finalResults = new List<string>();
            foreach (Lead lead in result)
            {
                finalResults.Add(lead.StringToPrint());
            }

            yield return JsonConvert.SerializeObject(finalResults);
        }
        [Route("leads/project")]
        public IEnumerable<string> GetLeadsByProject()
        {
            List<Lead> result = leadList.SortByProject();
            List<string> finalResults = new List<string>();
            foreach (Lead lead in result)
            {
                finalResults.Add(lead.StringToPrint());
            }

            yield return JsonConvert.SerializeObject(finalResults);
        }

        // POST: api/Leads
        [Route("leads")]
        [HttpPost]
        public void Post([FromBody]string value)
        {
            leadList.AddLead(value);
        }
    }
}
