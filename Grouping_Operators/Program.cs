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

            //Group By
            int[] arrCol = { 1,2,2,3,2,3,2,4,5,6,7,8,9,2,33,44,54,67};
            //Get the duplicate items


            Console.WriteLine("\n\n Get the Duplicate ");
            var resultIterations = arrCol.GroupBy(x => x);
            foreach(var item in resultIterations)
            {
                //Console.WriteLine("Key ->> "+item.Key + " Iterations ->> "+item.Count());
                if(item.Count() > 1)
                {
                    Console.WriteLine("Item with duplicate values ->> "+item.Key);
                }
            }

            //Fetch all the element whose index value is even - Exclude 0

            var getAllEvenIndexedValues = arrCol.Where((x, index) => index % 2 == 0 && index != 0).Select(x=>x);
            Console.WriteLine("Values at Even index =>> "+string.Join(" ",getAllEvenIndexedValues));


            //Group by Multiple keys

            Console.WriteLine("*********************** Group Record by Multiple Keys ************************");
            //Group Employees by Department and Then by Gender.
            //dynamic resultOfGroupByMultipleKeys = Employee.GetAllEmployees().GroupBy(x => new { x.Department, x.Gender })
            //                                    .OrderBy(x => x.Key.Department).ThenBy(y => y.Key.Gender)
            //                                    .Select(g => new
            //                                    {
            //                                        Dept = g.Key.Department,
            //                                        gender = g.Key.Gender,
            //                                        employees = g.OrderBy(x=>x.Name) 
            //                                    });

            var resultOfGroupByMultipleKeys = from emp in Employee.GetAllEmployees()
                                          group emp by new { emp.Department, emp.Gender } into egroup
                                          orderby egroup.Key.Department, egroup.Key.Gender
                                          select new {
                                              Dept = egroup.Key.Department,
                                              gender = egroup.Key.Gender,
                                              employees = egroup.OrderBy(x=>x.Name)
                                          };


            Console.WriteLine("\n\n");
            foreach(var item in resultOfGroupByMultipleKeys)
            {
                Console.WriteLine(item.Dept+" department,"+item.gender+" count "+item.employees.Count());
                Console.WriteLine("----------------------------------");
                foreach(var e in item.employees)
                {
                    Console.WriteLine(e.Name+" - "+e.Department);
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
            }








            Console.ReadKey();
        }
    }
}
