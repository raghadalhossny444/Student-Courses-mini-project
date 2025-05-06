using studentCourses.Models;
using MySql.Data.MySqlClient;
using studentCourses.Infrastructure;


namespace studentCourses.DAOs
{
    public class EnrollmentDAO
    {
        private readonly SQLConnector _connector;

        public EnrollmentDAO(SQLConnector connector)
        {
            _connector = connector;
        }

        public List<Enrollment> GetEnrollmentsByStudentId(int studentId)
        {
            var enrollments = new List<Enrollment>();
            using var conn = _connector.Connect();
            var cmd = new MySqlCommand("SELECT * FROM enrollment WHERE StudentId = @studentId", conn);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                enrollments.Add(new Enrollment
                {
                    StudentId = reader.GetInt32("StudentId"),
                    CourseId = reader.GetInt32("CourseId"),
                    Date = reader.GetDateTime("Date")
                });
            }

            return enrollments;
        }
    }
}
