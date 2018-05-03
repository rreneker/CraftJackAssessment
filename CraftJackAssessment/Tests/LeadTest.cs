using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class LeadTest
    {
        [TestMethod]
        public void CreateLead()
        {
            Lead lead1 = new Lead("Rusty", "Shackleford", "House", "Plumbing", new System.DateTime(2018, 5, 25));
            Assert.AreEqual("Plumbing", lead1.Project);
        }
        [TestMethod]
        public void CreateStringOfLeadToPrint()
        {
            Lead lead1 = new Lead("Rusty", "Shackleford", "House", "Plumbing", new System.DateTime(2018, 5, 25));
            string result = lead1.StringToPrint();
            string expectedResult = "Rusty Shackleford House Plumbing 05/25/2018";
            Assert.AreEqual(expectedResult, result);
        }
    }
}
