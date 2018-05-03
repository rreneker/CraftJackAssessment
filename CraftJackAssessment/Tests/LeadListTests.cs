using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;
using System;
using System.IO;

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
        [TestMethod]
        public void AddLeadFromSpaceDelimitedLine()
        {
            string leadLine = "Rusty Shackleford House Bunker 05/15/2018";
            leads.AddLead(leadLine);
            List<Lead> expectedResult = new List<Lead>();
            expectedResult.Add(new Lead("Rusty", "Shackleford", "House", "Bunker", new System.DateTime(2018, 5, 15)));
            List<Lead> actualResult = leads.GetLeads();
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        
        [TestMethod]
        public void SortLeadsByPropertTypeThenByProject()
        {
            foreach(string line in File.ReadLines("TestInput1.txt"))
            {
                leads.AddLead(line);
            }

            List<Lead> sortedResult = leads.SortByPropertyTypeThenProject();

            List<Lead> expectedResult = new List<Lead>();
            expectedResult.Add(new Lead("Phillip", "Fry", "Condo", "Plumbing", new DateTime(2018, 10, 21)));
            expectedResult.Add(new Lead("Rusty", "Shackleford", "House", "Bunker", new DateTime(2018, 5, 15)));
            expectedResult.Add(new Lead("Homer", "Simpson", "House", "Foundation", new DateTime(2018, 6, 1)));
            expectedResult.Add(new Lead("Jim", "Harbaugh", "House", "Siding", new DateTime(2018, 7, 19)));
            expectedResult.Add(new Lead("Dante", "Hicks", "Trailer", "Plumbing", new DateTime(2018, 5, 27)));

            CollectionAssert.AreEqual(expectedResult, sortedResult);

        }
        [TestMethod]
        public void SortLeadsByStartDate()
        {
            foreach (string line in File.ReadLines("TestInput1.txt"))
            {
                leads.AddLead(line);
            }
            List<Lead> sortedResult = leads.SortByStartDate();
            List<Lead> expectedResult = new List<Lead>();
            
            expectedResult.Add(new Lead("Rusty", "Shackleford", "House", "Bunker", new DateTime(2018, 5, 15)));
            expectedResult.Add(new Lead("Dante", "Hicks", "Trailer", "Plumbing", new DateTime(2018, 5, 27)));
            expectedResult.Add(new Lead("Homer", "Simpson", "House", "Foundation", new DateTime(2018, 6, 1)));
            expectedResult.Add(new Lead("Jim", "Harbaugh", "House", "Siding", new DateTime(2018, 7, 19)));
            expectedResult.Add(new Lead("Phillip", "Fry", "Condo", "Plumbing", new DateTime(2018, 10, 21)));

            CollectionAssert.AreEqual(expectedResult, sortedResult);
        }
        [Ignore]
        [TestMethod]
        public void SortLeadsByLastName()
        {
            foreach (string line in File.ReadLines("TestInput1.txt"))
            {
                leads.AddLead(line);
            }
        }
    }
}