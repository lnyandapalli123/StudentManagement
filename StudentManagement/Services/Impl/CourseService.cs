using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Impl
{
    public class CourseService : ICourseService
    {
        public static List<Course> courses = new List<Course>();
        public string AddCourse(Course c)
        {
            Course resultCourse = GetCourse(c.Id);
            if (resultCourse == null)
            {
                courses.Add(c);
                return "Course Added Successfully";
            }
            else
            {
                return "Course with given Id already exists";
            }
        }

        public string DeleteCourse(int id)
        {
            Course resultCourse = GetCourse(id);
            if (resultCourse != null)
            {
                foreach (var student in StudentService.students)
                {
                    if (student.Courses != null)
                    {
                        foreach (var course in student.Courses)
                        {
                            if (course.Id == id)
                            {
                                return "Can not delete course one or more students registered with the course";
                            }
                        }
                    }
                }
                courses.Remove(resultCourse);
                return "Course Deleted Successfully";
            }
            else
            {
                return "Course with given Id does not exist";
            }
        }

        public List<Course> GetAllCourses()
        {
            return courses;
        }

        public Course GetCourse(int id)
        {
            foreach (Course c in courses)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }

        public string UpdateCourse(Course c)
        {
            Course resultCourse = GetCourse(c.Id);
            if (resultCourse != null)
            {
                resultCourse.Name = c.Name;
                resultCourse.Description = c.Description;
                return "Course Updated Successfully";
            }
            else
            {
                return "Course with given Id does not exist";
            }
        }
    }
}
