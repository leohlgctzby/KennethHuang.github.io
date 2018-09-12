using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class Course
    {
        // private string courseName;
        //private int maxStudents;
        private int credit;
        private readonly int courseFee = 100;

        public Course(string courseName, int maxStudents, int credit)
        {
            this.CourseName = courseName;
            this.MaxStudents = maxStudents;
            this.Credit = credit;
        }



        public int CourseFee { get => courseFee; }

        public int Credit { get; }//equals GetCredit();

        public int GetCredit()
        {
            return credit;
        }

        public int MaxStudents { get; set; }//equals GetMaxStudents

        //public int GetMaxStudents ()
        //{
        //    return maxStudents;
        //}

        public string CourseName { get; set; }
    }
}
