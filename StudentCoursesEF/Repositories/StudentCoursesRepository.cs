using Microsoft.EntityFrameworkCore;
using studentCoursesEF.Data;
using studentCoursesEF.Models;

namespace studentCoursesEF.Repositories
{
    public class StudentCoursesRepository
    {
        private readonly AppDbContext _context;
        public StudentCoursesRepository()
        {
            _context = new AppDbContext();
        }
        public List<Course> GetStudentCourses(int studentId)
        {
            DateTime semesterStart = new DateTime(2025, 2, 1);
            var student = _context.Student
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found!");
                throw new InvalidOperationException($"Student with ID {studentId} was not found.");
            }
            var courses = student.Enrollments
                .Where(e => e.Date > semesterStart)
                .Select(e => e.Course)
                .ToList();
            return courses;
        }
    }
}
