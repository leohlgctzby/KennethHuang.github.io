using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Model
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credit { get; set; }
        public int MaxStudentNum { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
    }
}
