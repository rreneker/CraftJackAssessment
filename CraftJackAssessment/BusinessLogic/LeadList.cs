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

        public void Add(Lead lead1)
        {
            Leads.Add(lead1);
        }
    }
}
