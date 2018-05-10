using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTService.Controllers;
using BusinessLogic;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RESTService.Tests
{
    [TestClass]
    public class UnitTest1
    {
        LeadsController leadsController;
        [TestInitialize]
        public void TestSetup()
        {
            leadsController = new LeadsController();
        }
        [Ignore]
        [TestMethod]
        public void GetLeadsByPropertyTypeTest()
        {
            List<Lead> expectedResult = new List<Lead>();
            expectedResult.Add(new Lead("Phillip", "Fry", "Condo", "Plumbing", new DateTime(2018, 10, 21)));
            expectedResult.Add(new Lead("Rusty", "Shackleford", "House", "Bunker", new DateTime(2018, 5, 15)));
            expectedResult.Add(new Lead("Homer", "Simpson", "House", "Foundation", new DateTime(2018, 6, 1)));
            expectedResult.Add(new Lead("Jim", "Harbaugh", "House", "Siding", new DateTime(2018, 7, 19)));
            expectedResult.Add(new Lead("Dante", "Hicks", "Trailer", "Plumbing", new DateTime(2018, 5, 27)));
            List<string> finalResults = new List<string>();
            foreach (Lead lead in expectedResult)
            {
                finalResults.Add(lead.StringToPrint());
            }

            var ExpectedJson = JsonConvert.SerializeObject(finalResults);

            var actualResult = leadsController.GetLeadsByPropertyType();

            Assert.AreEqual(ExpectedJson, actualResult);
        }

        [TestMethod]
        public void PostAddLeadPipes()
        {
            leadsController.Post("Jim|Raynor|House|Plumbing|05/19/2018");
            Assert.AreEqual(6, leadsController.leadList.LeadCount());
        }

        [TestMethod]
        public void PostAddLeadCommas()
        {
            leadsController.Post("Jim,Raynor,House,Plumbing,05/19/2018");
            Assert.AreEqual(6, leadsController.leadList.LeadCount());
        }

        [TestMethod]
        public void PostAddLeadSpaces()
        {
            leadsController.Post("Jim Raynor House Plumbing 05/19/2018");
            Assert.AreEqual(6, leadsController.leadList.LeadCount());
        }
    }
}
