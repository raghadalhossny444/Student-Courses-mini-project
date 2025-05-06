using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentCourses.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }




    }
}