using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            //Total employee based on department
            var result = Employee.GetAllEmployees().GroupBy(x => x.Department);
            foreach (var group in result)
            {
                Console.WriteLine(group.Key + " - - " + group.Count());
            }
            //:Output ->> 6 - IT , 4 - HR

            //group.Count(x=>x.Gender == "Male") ---<<<< you will get all the "Male" employee count w.r.t Department

            //Using Sql like Syntax.

            var result1 = from emp in Employee.GetAllEmployees()
                          group emp by emp.Department;
            foreach (var group in result1)
            {
                Console.WriteLine(group.Key + " - - " + group.Count());
            }
            Console.WriteLine();

            //maximum salary paid to an employee within each department.
            var result2 = Employee.GetAllEmployees().GroupBy(x => x.Department);
            foreach (var group in result2)
            {
                Console.WriteLine(group.Key + " - - " + group.Max(x => x.Salary));
            }
            Console.WriteLine();
            //All Employees within departments
            var result3 = Employee.GetAllEmployees().GroupBy(x => x.Department);
            foreach (var group in result3)
            {
                Console.WriteLine(group.Key + " - - " + string.Join("\n", group.Select(x => x.Name + " " + x.Department + " " + x.Salary)));
            }
            Console.WriteLine();
            Console.WriteLine();
            //Sorting --
            var result4 = from emp in Employee.GetAllEmployees()
                          group emp by emp.Department into eGroup
                          orderby eGroup.Key
                          select new
                          {
                              key = eGroup.Key,
                              employee = eGroup.OrderBy(x=>x.Name)
                          };

            foreach (var group in result4)
            {
                Console.WriteLine(group.key + " - - " + string.Join("\n", group.employee.Select(x => x.Name + " " + x.Department + " " + x.Salary)));
            }
            Console.ReadKey();
        }
    }
}
