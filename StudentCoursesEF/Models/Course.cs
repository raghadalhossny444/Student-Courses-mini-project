using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentCoursesEF.Models
{


    public class Course
    {
        public int CourseId { get; set; }
        public required string Name { get; set; }
        public int Hours { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }




    }
}