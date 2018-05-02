using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;
using System;

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
            leads.AddLead(lead1);
            expectedResult.Add(lead1);
            CollectionAssert.AreEqual(expectedResult, leads.GetLeads());
        }
        [TestMethod]
        public void AddLeadFromPipeDelimitedLine()
        {
            string leadLine = "Rusty|Shackleford|House|Bunker|05/15/2018";
            leads.AddLead(leadLine);
            List<Lead> expectedResult = new List<Lead>();
            expectedResult.Add(new Lead("Rusty", "Shackleford", "House", "Bunker", new System.DateTime(2018, 5, 15)));
            List<Lead> actualResult = leads.GetLeads();
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void AddLeadFromCommaDelimitedLine()
        {
            string leadLine = "Rusty,Shackleford,House,Bunker,05/15/2018";
            leads.AddLead(leadLine);
            List<Lead> expectedResult = new List<Lead>();
            expectedResult.Add(new Lead("Rusty", "Shackleford", "House", "Bunker", new System.DateTime(2018, 5, 15)));
            List<Lead> actualResult = leads.GetLeads();
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}