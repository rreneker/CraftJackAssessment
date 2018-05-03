using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Lead
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PropertyType { get; set; }
        public string Project { get; set; }
        public DateTime StartDate { get; set; }

        public Lead(string firstName, string lastName,string propertyType,string project,DateTime startDate)
        {
            FirstName = firstName;
            LastName = lastName;
            PropertyType = propertyType;
            Project = project;
            StartDate = startDate;
        }

        public string StringToPrint()
        {
            string result = FirstName + " " + LastName + " " + PropertyType + " " + Project + " "+StartDate.ToString("MM/dd/yyyy");
            return result;
            
        }

        public override bool Equals(object obj)
        {
            Lead lead = (Lead)obj;
            if(lead.FirstName == FirstName && lead.LastName == LastName && lead.Project == Project && lead.PropertyType == PropertyType && lead.StartDate == StartDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
}
