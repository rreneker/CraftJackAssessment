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
