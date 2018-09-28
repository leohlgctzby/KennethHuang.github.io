using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Model
{
    public class Enrollment
    {
       // public enum grade { A,B,C,D,E };

        //public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
       // public grade? Grade { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
