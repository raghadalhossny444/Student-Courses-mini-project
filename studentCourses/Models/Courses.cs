using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentCourses.Models
{
    public class Courses
    {
        public int CourseId { get; set; }
        public required string Name { get; set; }
        public int Hours { get; set; }



    }
}