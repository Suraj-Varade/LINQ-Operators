using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projection_Select_SelectMany;
namespace Ordering_Operators
{
    interface IEntity
    {
        int add();
    }
    public abstract class EntityClass
    {
       public abstract int add();
    }
    class ChildClass : EntityClass,IEntity
    {
        public override int add()
        {
            Console.WriteLine("InSide the Add");return 2;
            //throw new NotImplementedException();
        }

        
    }

    class Program 
    {
        static int pairs(int k, int[] arr)
        {
            int count = 0, j = 1, i = 0;
            Array.Sort(arr);
            while (i < arr.Length)
            {
                if (j < arr.Length && Math.Abs(arr[j] - arr[i]) == k)
                {
                    count++;
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {

            //Console.WriteLine(pairs(2, new int[] { 1 ,3 ,5 ,8 ,6 ,4 ,2 }));
            //ChildClass cs = new ChildClass();
            //cs.add();

            
            //Name of student
            Console.WriteLine(string.Join("\n",Student.getAllStudents.OrderBy(x=>x.Name).Select(x=> new { ID = x.StudentID, NAME = x.Name })));

            Console.WriteLine("******************");

            var k1 = from stud in Student.getAllStudents
                     orderby stud.Name
                     select stud.Name;

            Console.WriteLine(string.Join("\n",k1));
            Console.WriteLine("Descending Order");

            Console.WriteLine(string.Join("\n", Student.getAllStudents.OrderByDescending(x=>x.Name).Select(x=>x.Name)));
            string st = "I LOVE MY INDIA";
            Console.WriteLine(string.Join("", st.Reverse()));

          var l =  from kq in Student.getAllStudents
            orderby kq.Name descending
            select kq.Name;
            Console.WriteLine(string.Join("\n", l));
            
            Console.ReadKey();
        }
    }
}
