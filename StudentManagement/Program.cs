using StudentManagement.Model;
using StudentManagement.Services;
using StudentManagement.Services.Impl;
using System;

namespace Studentmanagement
{
    class Program
    {
        public static void Main(string[] args)
        {

           Console.WriteLine("Welcome to Student Management System");
            int choice = 0;
            IStudentService studentService = new StudentService();
            ICourseService courseService = new CourseService();
            do
            { 
                Console.WriteLine("Select the following services:");
                Console.WriteLine("1. Student Services");
                Console.WriteLine("2. Course Services");
                Console.WriteLine("3. Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int subChoice = 0;
                        Console.WriteLine("Student Services Options");
                        Console.WriteLine("1. Add Student");
                        Console.WriteLine("2. Delete Student");
                        Console.WriteLine("3. View All Students");
                        Console.WriteLine("4. View Student by Id");
                        Console.WriteLine("5. View Students by Age");
                        Console.WriteLine("6. View Students by Course Name");
                        Console.WriteLine("7. View Courses by Student Id");
                        Console.WriteLine("8. Update Student");
                        Console.WriteLine("9. Add Courses to Student");

                        subChoice = Convert.ToInt32(Console.ReadLine());

                        switch (subChoice)
                        {
                            case 1:
                                Console.WriteLine("Enter Student Id:");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Student Name:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter Student Age:");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Student M1 Marks:");
                                double m1Marks = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter Student M2 Marks:");
                                double m2Marks = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter Student M3 Marks:");
                                double m3Marks = Convert.ToDouble(Console.ReadLine());

                                Student s = new Student(id, name, age, m1Marks, m2Marks, m3Marks);

                                Console.WriteLine(studentService.AddStudent(s));
                                break;

                            case 2:
                                Console.WriteLine("Enter Student Id to delete:");
                                int deleteId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(studentService.DeleteStudent(deleteId));
                                break;

                            case 3:
                                List<Student> students = studentService.GetAllStudents();
                                foreach (Student student in students)
                                {
                                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, M1 Marks: {student.M1Marks}, M2 Marks: {student.M2Marks}, M3 Marks: {student.M3Marks}");
                                }
                                break;

                            case 4:
                                Console.WriteLine("Enter Student Id to view:");
                                s = studentService.GetStudent(Convert.ToInt32(Console.ReadLine()));
                                if (s != null)
                                {
                                    Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}, M1 Marks: {s.M1Marks}, M2 Marks: {s.M2Marks}, M3 Marks: {s.M3Marks}");
                                }
                                else
                                {
                                    Console.WriteLine("Student not found with given Id");
                                }
                                break;

                            case 5:
                                Console.WriteLine("Enter Age to view students:");
                                students = studentService.GetStudentsByAge(Convert.ToInt32(Console.ReadLine()));
                                if (students.Count > 0)
                                {
                                    foreach (Student student in students)
                                    {
                                        Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, M1 Marks: {student.M1Marks}, M2 Marks: {student.M2Marks}, M3 Marks: {student.M3Marks}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No students found with given age");
                                }
                                break;

                            case 6:
                                Console.WriteLine("Enter Course Name to view students:");
                                students = studentService.GetStudnetsByCourseName(Console.ReadLine());
                                if (students.Count > 0)
                                {
                                    foreach (Student student in students)
                                    {
                                        Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, M1 Marks: {student.M1Marks}, M2 Marks: {student.M2Marks}, M3 Marks: {student.M3Marks}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No students found enrolled in given course");
                                }
                                break;

                            case 7:
                                Console.WriteLine("Enter Student Id to view courses:");
                                List<Course> courses = studentService.GetCoursesbyStudentId(Convert.ToInt32(Console.ReadLine()));
                                if (courses != null && courses.Count > 0)
                                {
                                    foreach (Course course in courses)
                                    {
                                        Console.WriteLine($"Id: {course.Id}, Name: {course.Name}, Description: {course.Description}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No courses found for given student Id");
                                }
                                break;
                            case 8:
                                Console.WriteLine("Enter Student Id to update:");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Student Name:");
                                name = Console.ReadLine();
                                Console.WriteLine("Enter Student Age:");
                                age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Student M1 Marks:");
                                m1Marks = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter Student M2 Marks:");
                                m2Marks = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter Student M3 Marks:");
                                m3Marks = Convert.ToDouble(Console.ReadLine());

                                s = new Student(id, name, age, m1Marks, m2Marks, m3Marks);
                                Console.WriteLine(studentService.UpdateStudent(s));
                                break;

                            case 9:
                                Console.WriteLine("Enter Student Id to add courses:");
                                int studentId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Course Ids to add (comma separated):");
                                string[] courseIdsStr = Console.ReadLine().Split(',');
                                List<int> courseIds = new List<int>();
                                foreach (string courseIdStr in courseIdsStr)
                                {
                                    courseIds.Add(Convert.ToInt32(courseIdStr));
                                }
                                Console.WriteLine(studentService.AddCoursesToStudent(studentId, courseIds));
                                break;

                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }

                        break;

                    case 2:
                        int courseChoice = 0;
                        Console.WriteLine("Course Services Options");
                        Console.WriteLine("1. Add Course");
                        Console.WriteLine("2. Delete Course");
                        Console.WriteLine("3. View All Courses");
                        Console.WriteLine("4. View Course by Id");
                        Console.WriteLine("5. Update Course");
                        courseChoice = Convert.ToInt32(Console.ReadLine());

                        switch(courseChoice)
                        {
                            case 1:
                                Console.WriteLine("Enter Course Id:");
                                int courseId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Course Name:");
                                string courseName = Console.ReadLine();
                                Console.WriteLine("Enter Course Description:");
                                string courseDescription = Console.ReadLine();
                                Course c = new Course(courseId, courseName, courseDescription);
                                Console.WriteLine(courseService.AddCourse(c));
                                break;
                            case 2:
                                Console.WriteLine("Enter Course Id to delete:");
                                int deleteCourseId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(courseService.DeleteCourse(deleteCourseId));
                                break;
                            case 3:
                                List<Course> courses = courseService.GetAllCourses();
                                foreach (Course course in courses)
                                {
                                    Console.WriteLine($"Id: {course.Id}, Name: {course.Name}, Description: {course.Description}");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Enter Course Id to view:");
                                c = courseService.GetCourse(Convert.ToInt32(Console.ReadLine()));
                                if (c != null)
                                {
                                    Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Description: {c.Description}");
                                }
                                else
                                {
                                    Console.WriteLine("Course not found with given Id");
                                }
                                break;
                            case 5:
                                Console.WriteLine("Enter Course Id to update:");
                                courseId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Course Name:");
                                courseName = Console.ReadLine();
                                Console.WriteLine("Enter Course Description:");
                                courseDescription = Console.ReadLine();
                                 c = new Course(courseId, courseName, courseDescription);
                                Console.WriteLine(courseService.UpdateCourse(c));
                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using Student Management System");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 3);
        }

    }
}