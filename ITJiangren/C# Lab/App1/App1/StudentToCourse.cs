using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class StudentToCourse
    {
        //private int studentID;
        private string studentName;
        // private string courseName;
        // private int grade;

        public StudentToCourse(int studentID, string courseName, int grade)
        {
            this.StudentID = studentID;
            this.CourseName = courseName;
            this.Grade = grade;
        }

        public StudentToCourse(string studentName, string courseName, int grade)
        {
            this.studentName = studentName;
            this.CourseName = courseName;
            this.Grade = grade;
        }

        public int Grade { get; set; }

        public int StudentID { get; set; }

        public string CourseName { get; set; }

    }
}
