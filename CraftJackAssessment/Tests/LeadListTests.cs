using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class LeadListTests
    {
        [TestMethod]
        public void CreateLeadList()
        {
            LeadList leads = new LeadList();

            CollectionAssert.AreEqual(new List<Lead>(), leads.GetLeads());
        }
    }
}