using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class LeadList
    {
        private List<Lead> Leads;

        public LeadList()
        {
            Leads = new List<Lead>();
        }

        public List<Lead> GetLeads()
        {
            return Leads;
        }

        public void AddLead(Lead lead1)
        {
            Leads.Add(lead1);
        }

        public void AddLead(string leadLine)
        {
            string[] leadEntries = leadLine.Split('|');
            
            string[] stringDate = leadEntries[4].Split('/');
            DateTime date = new DateTime(Convert.ToInt32(stringDate[2]), Convert.ToInt32(stringDate[0]), Convert.ToInt32(stringDate[1]));
            Lead newLead = new Lead(leadEntries[0], leadEntries[1], leadEntries[2], leadEntries[3], date);
            Leads.Add(newLead);
        }
    }
}
