using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<List<string>> re = Student.getAllStudents.Select(x => x.Subjects);
            foreach (var k1 in re)
            {
                foreach (var k2 in k1)
                {
                    Console.WriteLine(k2);
                }
            }

            IEnumerable<string> rr = Student.getAllStudents.SelectMany(x => x.Subjects);
            foreach (var k3 in rr)
            {
                Console.WriteLine(k3);
            }

            //var EmployeeBySubjects = Student.getAllStudents.SelectMany(s=> s.Subjects , (stud, sub) => new { studentName = stud.Name , Subjects = sub });
            //Console.WriteLine(string.Join(" ",EmployeeBySubjects));

            var kkkk = from stud in Student.getAllStudents
                       from s in stud.Subjects
                       select new { NAME = stud.Name, SUB = s };

            Console.WriteLine(string.Join(" ", kkkk));


            List<int> mlist = new List<int>() { 1, 2, 34, 5, 6, 8, 3, 2 };
            string str = "140-3";
            //1403
            str = str.Replace("-", "");
            Console.WriteLine("Count => " + str.Sum(x => (int)x));

            Console.WriteLine(string.Join(" ", str.Select(x => new { Character = x, value = (int)x })));
            //1403
            int kk = int.Parse(str);
            int sum = 0;
            while (kk > 0)
            {
                sum += kk % 10;
                kk = kk / 10;
            }
            Console.WriteLine("SUM => " + sum);
            //str.GroupBy()


            //Console.WriteLine("Group By" + string.Join(" ", korpe));
            Console.ReadKey();
            #region SelectMany
            IEnumerable<string> subjects = Student.getAllStudents.SelectMany(x => x.Subjects);
            Console.WriteLine(string.Join(" ", subjects.Distinct()));

            var result = from stud in Student.getAllStudents
                         from subject in stud.Subjects
                         select subject;

            Console.WriteLine(string.Join(" ", result.Distinct()));


            string[] array = { "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "0123456789" };
            //IEnumerable<char> kp = array.SelectMany(x => x);

            //foreach(char k in kp)
            //{
            //    Console.WriteLine(k);
            //}

            var kop = from item in array
                      from ch in item
                      where ch.Equals('O')
                      select item;

            Console.WriteLine(string.Join(" ", kop));


            Console.ReadKey();
            #endregion


            int iterate = 0;
            do
            {
                Console.WriteLine("Enter your Choice");
                Console.WriteLine("1. get All Employees");
                Console.WriteLine("2. get FirstName And Gender");
                Console.WriteLine("3. get Name, Gender and Salary");
                Console.WriteLine("4. get Full Name and Monthly Salary");
                Console.WriteLine("5. get Employee whose monthly salary is greater than 3000");
                Console.WriteLine("6. get Employee with even Index");

                int i = int.Parse(Console.ReadLine());
                Employee employee = new Employee();
                switch (i)
                {
                    case 1:
                        var records = employee.getRecords().ToList();
                        Console.WriteLine(string.Join("\n", records.Select(x => x.ID + " - " + x.FirstName + " - " + x.LastName + " - " + x.Salary + " - " + x.Gender)));
                        break;
                    case 2:
                        var rec = employee.getRecords().Select(x => x.FirstName + " - " + x.Gender);
                        Console.WriteLine(String.Join("\n", rec));
                        break;
                    case 3:
                        var rex = employee.getRecords().Select(x => new { x.FirstName, x.Gender, x.Salary });
                        Console.WriteLine(string.Join(" ", rex));
                        break;

                    case 4:
                        var Ret = employee.getRecords().Select(x => new
                        {
                            fullname = x.FirstName + " " + x.LastName,
                            MonthlySalary = x.Salary / 12
                        });
                        foreach (var item in Ret)
                        {
                            Console.WriteLine("Name : " + item.fullname + " Monthly Salary : " + item.MonthlySalary);
                        }
                        break;

                    case 5:
                        var rey = employee.getRecords().Where(x => x.Salary / 12 >= 3000).Select(x => new
                        {
                            Name = x.FirstName,
                            AnnualSalary = x.Salary,
                            Bonus = ((x.Salary / 12) * 0.1)
                        });
                        Console.WriteLine("Name , AnnualSalary , Bonus");
                        Console.WriteLine(string.Join("\n", rey.Select(x => x.Name + " , " + x.AnnualSalary + " , " + x.Bonus)));
                        break;

                    case 6:
                        var getToWork = employee.getRecords()
                            .Select((x, y) => new { mEmployee = x, index = y })
                            .Where(x => x.index % 2 == 0).Select(x => new { EmployeeName = x.mEmployee.FirstName + " " + x.mEmployee.LastName });
                        Console.WriteLine(string.Join(" ", getToWork));
                        break;
                }
                int k = 0;
                bool IsEnterValid = int.TryParse(Console.ReadLine(), out k);
                iterate = k;
            } while (iterate == 1);
            Console.ReadKey();
        }
    }
}
