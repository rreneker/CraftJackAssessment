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
    }
}
