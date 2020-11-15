using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast_And_OfType_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Cast
            ArrayList list = new ArrayList();
            list.Add(1);list.Add(2);list.Add(3);
            IEnumerable<int> result = list.Cast<int>(); //do deferred Execution

            list.Add(4);
            //list.Add("Exe");
            foreach(int i in result)
            {
                Console.Write(" "+i);
            }
            //output =>> 1 2 3 4
            Console.ReadLine();

            //2. OfType
            //return only element of specified type, other type of elements are ignored
            //Not throw exception
            list.Add(5);
            list.Add("ABC");
            list.Add("XYZ");

            IEnumerable<int> result1 = list.OfType<int>(); //Deferred Execution

            list.Add(7);

            foreach (int i in result1)
            {
                Console.Write(" " + i);
            }
            Console.ReadKey();
        }
    }
}
