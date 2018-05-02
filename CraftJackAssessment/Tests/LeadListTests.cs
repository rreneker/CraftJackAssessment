using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class LeadListTests
    {
        LeadList leads;
        [TestInitialize]
        public void LeadListTestInitialize()
        {
            leads = new LeadList();
        }
        [TestMethod]
        public void CreateLeadList()
        {
            CollectionAssert.AreEqual(new List<Lead>(), leads.GetLeads());
        }
        [TestMethod]
        public void AddLeadToLeadList()
        {
            Lead lead1 = new Lead("Rusty", "Shackleford", "House", "Bunker", new System.DateTime(2018, 6, 10));
            List<Lead> expectedResult = new List<Lead>();
            leads.Add(lead1);
            expectedResult.Add(lead1);
            CollectionAssert.AreEqual(expectedResult, leads.GetLeads());
        }
    }
}