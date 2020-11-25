using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Join
{
    class Program
    {
        static void Main(string[] args)
        {
            //Group Join

            var employeesByDepartment = Department.GetAllDepartments().GroupJoin(Employee.GetAllEmployees(), x => x.ID, y => y.DepartmentID,
                                        (department, employees) => new
                                        {
                                            dept = department,
                                            emp = employees
                                        });

            foreach(var department in employeesByDepartment)
            {
                Console.WriteLine(department.dept.Name + " - \n"+string.Join("\n",department.emp.Select(x=>x.Name)));
                Console.WriteLine();
            }

            //using Sql like syntax....
            var employeesByDepartmentUsingSqlLikeSyntax = from d in Department.GetAllDepartments()
                                                          join e in Employee.GetAllEmployees()
                                                          on d.ID equals e.DepartmentID into egroup
                                                          select new
                                                          {
                                                              employees = egroup,
                                                              department = d
                                                          };

            foreach (var department in employeesByDepartmentUsingSqlLikeSyntax)
            {
                Console.WriteLine(department.department.Name + " - \n" + string.Join("\n", department.employees.Select(x=>x.Name)));
                
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
