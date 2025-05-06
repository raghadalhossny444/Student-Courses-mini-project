using studentCourses.DAOs;
using studentCourses.Models;
using studentCourses.Infrastructure;

namespace studentCourses.Repositories
{
    public class StudentCoursesRepository
    {
        private readonly StudentDAO _studentDAO;
        private readonly CoursesDAO _coursesDAO;
        private readonly EnrollmentDAO _enrollmentDAO;

        public StudentCoursesRepository()
        {
            var connectionString = "server=localhost;uid=root;pwd=1234raghad;database=StudentCourses";
            var sqlConnector = new SQLConnector(connectionString);
            _studentDAO = new StudentDAO(sqlConnector);
            _coursesDAO = new CoursesDAO(sqlConnector);
            _enrollmentDAO = new EnrollmentDAO(sqlConnector);
        }
        public List<Courses> GetStudentCourses(int studentId)
        {
            var student = _studentDAO.GetStudentById(studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found!");
                throw new InvalidOperationException($"Student with ID {studentId} was not found.");
            }
            var enrollments = _enrollmentDAO.GetEnrollmentsByStudentId(studentId);
            var courses = new List<Courses>();
            foreach (var enrollment in enrollments)
            {
                DateTime semesterStart = new DateTime(2025, 2, 1);
                if (enrollment.Date > semesterStart)
                    courses.Add(_coursesDAO.GetCourseById(enrollment.CourseId));
            }
            return courses;
        }
    }
}
