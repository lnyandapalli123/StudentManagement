using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public interface IStudentService
    {
        public String AddStudent(Student s);
        public String DeleteStudent(int id);
        public String UpdateStudent(Student s);
        public Student GetStudent(int id);
        public List<Student> GetAllStudents();
        public List<Student> GetStudentsByAge(int age);
        public List<Student> GetStudnetsByCourseName(string courseName);
        public List<Course>? GetCoursesbyStudentId(int id);
        public String AddCoursesToStudent(int studentId, List<int> courseIds);
    }
}
