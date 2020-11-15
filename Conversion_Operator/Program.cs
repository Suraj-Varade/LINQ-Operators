using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conversion_Operator - ToList(), ToArray(), 
            int[] numbers = { 1, 2, 3, 4, 5 };
            List<int> listOfNumbers = numbers.ToList();
            Console.WriteLine(string.Join("-",listOfNumbers));


            List<string> countries = new List<string> { "US","UK","Australia","Canada","India"};
            //Convert this List to array in ascending order
            string[] result = countries.OrderBy(x => x).ToArray();
            Console.WriteLine("result ==>> " + string.Join("\n",result));

            int index = 0;
            //ToDictionary - Key Value Pair
            var k = countries.ToDictionary(x=> index++);
            foreach(var item in k)
            {
                Console.WriteLine(item.Key +" - "+item.Value);
            }

            var re = countries.Select((name, ind) => new { NAME = name, INDE = ind }).ToDictionary(x => x.INDE+1, y => y.NAME);

            foreach (var item in re)
            {
                Console.WriteLine(item.Key + " ->> " + item.Value);
            }

            Console.WriteLine("------------- Employees ----------------");
            List<Employee> emp = new List<Employee>();
            emp.Add(new Employee { ID = 100, Name = "Lajapathy", CompanyName = "FE" });
            emp.Add(new Employee { ID = 200, Name = "Parthiban", CompanyName = "FE" });
            emp.Add(new Employee { ID = 400, Name = "Sathiya", CompanyName = "FE" });
            emp.Add(new Employee { ID = 300, Name = "Anand Babu", CompanyName = "FE" });
            emp.Add(new Employee { ID = 300, Name = "Naveen", CompanyName = "HCL" });
            

            //Lookup - keyvalue pair - but can have duplicate entries
            Console.WriteLine("<< --------------- ToLookUp() ---------------- >>");
            
            var getCountryLookup = emp.ToLookup(x=>x.CompanyName);
            foreach(var item in getCountryLookup["FE"])
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("*********************************");

            var resultBasedOnCompanyName = emp.ToLookup(x => x.CompanyName);
            Console.WriteLine(string.Join(" ",resultBasedOnCompanyName["FE"].Where(x=>x.ID >= 300).Select(x=>x.Name)));

            Console.WriteLine("<<----------- Group Employee by their Employment ------->> ");
            foreach(var kvp in getCountryLookup)
            {
                Console.WriteLine(kvp.Key);
                foreach(var item in getCountryLookup[kvp.Key])
                {
                    Console.WriteLine(item.ID +" - "+item.Name+" - "+item.CompanyName);
                }
            }

            Console.ReadKey();
        }
    }
}
