using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class Student
    {
        //private int studentID;
        private int age;
        //private int creditLimit;

        public Student(int studentID, string name, int age, int cL)
        {
            this.StudentID = studentID;
            this.Name = name;
            this.age = age;
            this.CreditLimit = cL;

        }

        public Student(string name, int age, int cL)
        {
            this.StudentID = 0;
            this.Name = name;
            this.age = age;
            this.CreditLimit = cL;

        }

        //public string Name { get; set; }
        public string Name { get; }

        //public string GetName()
        //{
        //    return this.Name;
        //}

        public int StudentID { get; }

        public int CreditLimit { get; }// equals ShowCreditLimit()

        //public int ShowCreditLimit()
        //{
        //    return creditLimit;
        //}

        public double showGPA()
        {
            return 5.0;
        }

    }
}
