using studentCourses.Infrastructure;
using studentCourses.Models;
using MySql.Data.MySqlClient;


namespace studentCourses.DAOs
{
    public class StudentDAO
    {
        private readonly SQLConnector _connector;
        public StudentDAO(SQLConnector connector)
        {
            _connector = connector;
        }
        public Student? GetStudentById(int id)
        {
            using var conn = _connector.Connect();
            var cmd = new MySqlCommand("SELECT * FROM student WHERE StudentId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Student
                {
                    StudentId = reader.GetInt32("StudentId"),
                    Name = reader.GetString("Name"),
                    GPA = reader.GetDouble("GPA"),
                    Email = reader.GetString("Email")
                };
            }
            return null;
        }
    }
}
