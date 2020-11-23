using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            //1, 2, 3, 4, 5, 6, 7, 8, 9 
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("Array =>> " + string.Join(",", numbers));
            //Element Operators
            #region First()
            //Console.WriteLine("First() -- Operator");
            //Console.WriteLine(numbers.First());
            ////first even number
            //int result = numbers.First(x => x % 2 == 0);
            //Console.WriteLine("First Even number => "+result);
            ////If sequence contains no matching elements or no elements then - using First() will throw an exception - InvalidOperation

            Console.WriteLine("FirstOrDefault() -- Operator");
            // numbers = null;
            Console.WriteLine("First or Default =>> " + numbers.FirstOrDefault());
            Console.WriteLine("First Or Default with predicate =>> " + numbers.FirstOrDefault(x => x % 2 == 0));

            #endregion
            //Last and LastOrDefault() --- same as first and FirstOrDefault()
            #region ElementAt
            Console.WriteLine("--------- Element At --------");
            Console.WriteLine("Element At index 5 =>> " + numbers.ElementAt(5));
            Console.WriteLine("ElementAtOrDefault =>> " + numbers.ElementAtOrDefault(25));
            #endregion

            #region Single
            Console.WriteLine("--------- Single ----------");
            Console.WriteLine("Single =>> " + numbers.Single(x => x > 8));
            //System.InvalidOperationException = Message = Sequence contains more than one matching element
            Console.WriteLine("SingleOrDefault =>> " + numbers.SingleOrDefault(x => x > 8));
            #endregion


            Console.WriteLine("--------- DefaultIfEmpty ---------");
            //if array is empty then return the defult value of that type
            int[] arr = { };
            Console.WriteLine("defaultIfEmpty =>> "+string.Join(" ",arr.DefaultIfEmpty(100)));
            Console.ReadKey();
        }
    }
}
