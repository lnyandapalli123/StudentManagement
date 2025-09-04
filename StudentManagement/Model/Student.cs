using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public double M1Marks { get; set; }
        public double M2Marks { get; set; }
        public double M3Marks { get; set; }
        public static int NumOfStudents { get; private set; } = 0;
        public const string schoolName = "Narayana Education";
        public List<Course> Courses {  get; set; } 

        public Student(int id, string? name, int age, double m1Marks, double m2Marks, double m3Marks)
        {
            Id = id;
            Name = name;
            Age = age;
            M1Marks = m1Marks;
            M2Marks = m2Marks;
            M3Marks = m3Marks;
            NumOfStudents++;
        }

        public Student(int id, string? name, int age, double m1Marks, double m2Marks, double m3Marks, List<Course> courses) {
            Id = id;
            Name = name;
            Age = age;
            M1Marks = m1Marks;
            M2Marks = m2Marks;
            M3Marks = m3Marks;
            Courses = courses;
            NumOfStudents++;
        }

    }
}
