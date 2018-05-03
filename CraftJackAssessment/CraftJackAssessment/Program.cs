using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace CraftJackAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            LeadList leads = new LeadList();

            try
            {

                foreach (string line in File.ReadLines(args[0]))
                {
                    leads.AddLead(line);
                }

                Console.WriteLine("");
                Console.WriteLine("Sorted by Property Type Then Project:");
                foreach (Lead l in leads.SortByPropertyTypeThenProject())
                {
                    Console.WriteLine(l.StringToPrint());
                }
                Console.WriteLine("");
                Console.WriteLine("Sorted by Start Date:");
                foreach (Lead l in leads.SortByStartDate())
                {
                    Console.WriteLine(l.StringToPrint());
                }
                Console.WriteLine("");
                Console.WriteLine("Sorted by Last Name Descending:");
                foreach (Lead l in leads.SortByLastNameDescending())
                {
                    Console.WriteLine(l.StringToPrint());
                }

                Console.ReadLine();

            }
            catch
            {
                Console.WriteLine("Please Specify the file in the command line");
            }
            
            
        }
    }
}
