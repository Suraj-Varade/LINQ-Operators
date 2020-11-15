using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partitioning_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. take
            string[] countries = { "India","Australia","US","UK","Canada","Itely"};
       
            IEnumerable<string> result = countries.Take(3);
            Console.WriteLine("First 3 countries => "+string.Join(" ",result));

            //Rewrite the same using SQL like Syntax
           IEnumerable<string> resultUsingSqlSyntax =  (from country in countries
             select country).Take(3);
            Console.WriteLine("First 3 countries using SqlSyntax => " + string.Join(" ", resultUsingSqlSyntax));

            //2. Skip
            IEnumerable<string> result1 = countries.Skip(3);
            Console.WriteLine("Last/Skip 3 countries => " + string.Join(" ", result1));

            //Rewrite the same using SQL like Syntax
            IEnumerable<string> result1UsingSqlSyntax = (from country in countries
                                                         select country).Skip(3);

            Console.WriteLine("Last/Skip 3 countries using SqlSyntax => " + string.Join(" ", result1UsingSqlSyntax));

            Console.WriteLine("**** Order the country list based on their length and get the second country from the list ****");

            var updatedResult = countries.OrderBy(x => x.Length).Skip(1).Take(1);
            Console.WriteLine("Result ==> "+string.Join(" ",updatedResult));
            Console.WriteLine("*******************");

            Console.WriteLine();
            //3. TakeWhile - get the elements based on condition
            Console.WriteLine("Here is the List =>> "+string.Join(",",countries));
            //"India","Australia","US","UK","Canada","Itely"
            Console.WriteLine("=>> "+string.Join(" ",countries.TakeWhile(x => x.Length >= 3)));
            Console.WriteLine("");

            //4. SkipWhile
            Console.WriteLine("=>> " + string.Join(" ", countries.SkipWhile(x => x.Length >= 3)));
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}
