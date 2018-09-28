using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public int CreditLimit { get; set; }
        //showGPA()
        //showCreditLimit()

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
