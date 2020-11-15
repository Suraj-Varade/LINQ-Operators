using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_Operators
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }

        
        public Employee()
        {
           
        }

        public List<Employee> getRecords()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 101, FirstName = "Suraj", LastName="Goyal", Gender = "Male",Salary=25000 });
            empList.Add(new Employee() { ID = 102, FirstName = "Sagar", LastName = "Varade", Gender = "Male", Salary = 35000 });
            empList.Add(new Employee() { ID = 103, FirstName = "Jatin", LastName = "Varade", Gender = "Male", Salary = 45000 });
            empList.Add(new Employee() { ID = 104, FirstName = "Snehal", LastName = "Bari", Gender = "Female", Salary = 55000 });
            empList.Add(new Employee() { ID = 105, FirstName = "Nivedita", LastName = "Bari", Gender = "Female", Salary = 65000 });
            empList.Add(new Employee() { ID = 106, FirstName = "Mohan", LastName = "Aswar", Gender = "Male", Salary = 65000 });
            return empList;
        }
    }
}
