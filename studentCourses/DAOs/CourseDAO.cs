using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using studentCourses.Infrastructure;
using studentCourses.Models;

namespace studentCourses.DAOs
{
    public class CoursesDAO
    {
        private readonly SQLConnector _connector;

        public CoursesDAO(SQLConnector connector)
        {
            _connector = connector;
        }

        public Courses GetCourseById(int id)
        {
            using var conn = _connector.Connect();
            var cmd = new MySqlCommand("SELECT * FROM course WHERE CourseId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            reader.Read();
            return new Courses
            {
                CourseId = reader.GetInt32("CourseId"),
                Name = reader.GetString("Name"),
                Hours = reader.GetInt32("Hours")
            };
        }
    }
}

