using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restrictions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 12, 33, 54, 75, 21, 71, 82, 90, 19999 };

            Console.WriteLine("Index of Max element in array");
            Console.WriteLine(numbers.Max(x => x));

            var second = numbers.OrderByDescending(x => x).Skip(1).Take(1);
            Console.WriteLine("Second Highest => "+ string.Join(" ", second));


            Console.WriteLine("Power of 2 => " + string.Join(" ", numbers.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key)));

            IEnumerable<int> result = numbers.Where(x => x % 2 == 0);
            Console.WriteLine(string.Join(" ", result));

            //fetch the Even Number
            Console.WriteLine("Even Numbers => " + String.Join(" ", numbers.Where(x => x % 2 == 0)));
            //All the numbers at even index Position
            //33,75,71,90
            var outputA = numbers.Select((x, y) => new { num = x, index = y }).Where(x => x.index % 2 == 0 && x.index > 0).Select(y => y.num);
            Console.WriteLine("Even Index Numbers => " + String.Join(" ",outputA));

            var neo = numbers.Select((num, index) => new { x = num, y = index }).Where(i => i.y % 2 == 0).Select(x => x.x);

            //neo = numbers.Where((num,index) => num % 2 == 0)
            Console.WriteLine(string.Join(" ", neo));
            //foreach(var item in neo)
            //{
            //    Console.WriteLine(item.x +" - "+item.y);
            //}

            Console.ReadKey();
        }
    }
}
