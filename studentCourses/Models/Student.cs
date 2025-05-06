using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentCourses.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string Name { get; set; }
        public double GPA { get; set; }
        public required string Email { get; set; }


    }
}