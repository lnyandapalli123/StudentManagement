using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Impl
{
    public class StudentService : IStudentService
    {
        public static List<Student> students = new List<Student>();
        public string AddStudent(Student s)
        {
            if (GetStudent(s.Id) == null)
            {
                students.Add(s);
                return "Student Added Successfully";
            }
            else {
                return "Student already exist with given student Id";
            }
        }

        public string DeleteStudent(int id)
        {
            Student resultStudent = GetStudent(id);
            if (resultStudent == null)
            {
                return "Student does not exist with given Id";
            }
            else
            {
                students.Remove(resultStudent);
                return "Student Deleted Successfully";
            }
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public List<Course>? GetCoursesbyStudentId(int id)
        {
            Student resultStudent = GetStudent(id);
            if (resultStudent == null)
            {
                return null;
            }
            else
            {
                return resultStudent.Courses;
            }
        }

        public Student GetStudent(int id)
        {
            foreach(Student s in students) {
                if (s.Id == id) {
                    return s;
                }
            }
            return null;
        }

        public List<Student> GetStudentsByAge(int age)
        {
            List<Student> resultStudents = new List<Student>();
            foreach (Student s in students)
            {
                if (s.Age == age)
                {
                    resultStudents.Add(s);
                }
            }
            return resultStudents;
        }

        public List<Student> GetStudnetsByCourseName(string courseName)
        {
            List<Student> resultStudents = new List<Student>();
            foreach (Student s in students)
            {
                foreach (Course c in s.Courses)
                {
                    if (c.Name.Equals(courseName))
                    {
                        resultStudents.Add(s);
                        break;
                    }
                }
            }
            return resultStudents;
        }

        public string UpdateStudent(Student s)
        {
            Student resultStudent = GetStudent(s.Id);

            if (resultStudent != null)
            {
                resultStudent.Name = s.Name;
                resultStudent.Age = s.Age;
                resultStudent.M1Marks = s.M1Marks;
                resultStudent.M2Marks = s.M2Marks;
                resultStudent.M3Marks = s.M3Marks;
                resultStudent.Courses = s.Courses;
                return "Student Updated Successfully";
            }
            else
            {
                return "Student does not exist with given Id";
            }
        }
        public string AddCoursesToStudent(int studentId, List<int> courseIds)
        {
            Student resultStudent = GetStudent(studentId);
            if (resultStudent == null)
            {
                return "Student does not exist with given Id";
            }
            else
            {
                if (resultStudent.Courses == null)
                {
                    resultStudent.Courses = new List<Course>();
                }
                foreach (int courseId in courseIds)
                {
                    foreach (Course c in CourseService.courses)
                    {
                        if (c.Id == courseId)
                        {
                            
                            resultStudent.Courses.Add(c);
                        
                        }
                    }
                }
                return "Courses added to student successfully";
            }
        }
    }
}
