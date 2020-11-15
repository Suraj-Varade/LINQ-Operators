using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_Select_SelectMany
{
    public class Student
    {
        public string Name { get; set; }
        public int StudentID { get; set; }
        public int TotalMarks { get; set; }
        //public List<string> Subjects { get; set; }

        public static List<Student> getAllStudents
        {
            get
            {
                List<Student> students = new List<Student>();
                students.Add(new Student() { Name = "Tom", StudentID = 101, TotalMarks = 800 });
                students.Add(new Student() { Name = "Mike", StudentID = 102, TotalMarks = 900 });
                students.Add(new Student() { Name = "Garry", StudentID = 103, TotalMarks = 1000 });
                students.Add(new Student() { Name = "Kent", StudentID = 104, TotalMarks = 800 });
                students.Add(new Student() { Name = "Harry", StudentID = 105, TotalMarks = 700 });
                students.Add(new Student() { Name = "MJ", StudentID = 106, TotalMarks = 1500 });
                return students;
            }
        }
    }
}
