using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------- InnerJoin -----------");
            //var result = Employee.GetAllEmployees().Join(Department.GetAllDepartments(),
            //                        e => e.DepartmentID,
            //                        d => d.ID,
            //                        (employee, department) => new
            //                        {
            //                           EmployeeName = employee.Name,
            //                           DepartmentName = department.Name
            //                        });

            Console.WriteLine("--------- Sql Like Syntax ------------");
            var resultUsingSqlLikeSyntax = from e in Employee.GetAllEmployees()
                                           join d in Department.GetAllDepartments() on
                                           e.DepartmentID equals d.ID 
                                           select new {
                                               DepartmentName = d.Name,
                                               EmployeeName = e.Name
                                           };


            foreach(var res in resultUsingSqlLikeSyntax)
            {
                Console.WriteLine(res.EmployeeName+"    "+res.DepartmentName);
            }

            Console.ReadKey();
        }
    }
}
