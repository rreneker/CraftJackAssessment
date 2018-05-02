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
    }
}
