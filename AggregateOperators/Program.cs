using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aggregate
            int[] arr = { 2,3,4,5 };

            var aggresult = arr.Aggregate(10,(a, b) => a * b);
            Console.WriteLine(aggresult);

            Console.WriteLine("**************** Aggregate *******************");
            string[] countries = { "America", "China", "UK", "Zebra", "Canada" };
            string result = countries.Aggregate((a, b) => a + "," + b);
            Console.WriteLine(result);
            var output = arr.Distinct().Aggregate((a, b) => a + b);
            Console.WriteLine(output);
            Console.WriteLine("**********************************************");


            Console.WriteLine(arr.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).Max());
        
            string[] @string = { "America", "China", "UK", "Zebra","Canada" };
            Console.WriteLine("Largest String => "+String.Join(" ",@string.OrderByDescending(x=>x.Length)));

           var VowelsRecords = @string.Where(x => x.Contains("a") || x.Contains("e") || x.Contains("i") || x.Contains("o") || x.Contains("u"));
            Console.WriteLine(string.Join(" ",VowelsRecords));

            Console.WriteLine("***********************************");
            

            foreach(var mk in @string.ToDictionary(x => x, y => y))
            {
                Console.WriteLine(mk.Key+" "+mk.Value);
            }

            Console.WriteLine("***********************************");


            string mil = string.Join(",", @string).ToString();
            Console.WriteLine("Formatted String => "+mil);


            var oo = @string.Min(x => x.Length);
            var tt = @string.Max(x => x.Length);

            Console.WriteLine(oo);



            Console.WriteLine("Largest Country => {0} and {1}", @string.Min(), @string.Min().Length);

            var ki = from i in arr
                     group i by i into y
                     select y;

            foreach (var mm in ki)
            {
                Console.WriteLine("Key : " + mm.Key + " Occurance : " + mm.Count());
            }


            //int ? min = null;
            //foreach(int i in arr)
            //{
            //    if(!min.HasValue || min > i)
            //    {
            //        min = i;
            //    }
            //}
            Console.WriteLine(arr.Where(x => x % 2 == 0).Average());
            Console.WriteLine("Result => " + arr.Where(x => x % 2 == 0).Sum());
            Console.ReadKey();
        }
    }
}
