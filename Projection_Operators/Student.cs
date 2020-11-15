using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_Operators
{
    public class Student
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public List<string> Subjects { get; set; }

        public static List<Student> getAllStudents
        {
            get
            {
                List<Student> students = new List<Student>();
                students.Add(new Student() { Name = "Tom", Gender = "Male", Subjects = new List<string>() { "ASP.net", "C#" } });
                students.Add(new Student() { Name = "Mike", Gender = "Male", Subjects = new List<string>() { "ASP.net", "C#","ADO.net" } });
                students.Add(new Student() { Name = "Garry", Gender = "Male", Subjects = new List<string>() { "ASP.net", "C#","MVC" } });
                students.Add(new Student() { Name = "Kent", Gender = "Male", Subjects = new List<string>() { "ASP.net", "C#","SQL" } });
                students.Add(new Student() { Name = "Harry", Gender = "Male", Subjects = new List<string>() { "ASP.net", "VB.Net" } });
                students.Add(new Student() { Name = "MJ", Gender = "Female", Subjects = new List<string>() { "SQL", "ADO.net","JAVA" } });
                return students;
            }
        }
    }
}
