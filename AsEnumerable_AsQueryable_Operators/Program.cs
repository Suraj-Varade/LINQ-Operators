using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsEnumerable_AsQueryable_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeContextDBClassDataContext employeeContext = new EmployeeContextDBClassDataContext();
            //If i use AsEnumerable then my query(where/Orderby) will be execute at client side.
            //filter logic will be executed at client side.
            var result = employeeContext.Employees.AsEnumerable().Where(x => string.Equals(x.Gender, "Male")).OrderByDescending(x => x.Salary).Take(5);
            foreach(Employee emp in result)
            {
                Console.WriteLine("ID : "+emp.ID+" , NAME : "+emp.Name+" , GENDER : "+emp.Gender+" , Salary : "+emp.Salary);
            }

            //filter logic will be executed at server side.
            var result1 = employeeContext.Employees.AsQueryable().Where(x => string.Equals(x.Gender, "Male")).OrderByDescending(x => x.Salary).Take(5);
            foreach (Employee emp in result1)
            {
                Console.WriteLine("ID : " + emp.ID + " , NAME : " + emp.Name + " , GENDER : " + emp.Gender + " , Salary : " + emp.Salary);
            }


            Console.ReadKey();
        }
    }
}
