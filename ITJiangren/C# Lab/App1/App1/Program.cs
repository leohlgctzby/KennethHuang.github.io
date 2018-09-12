using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//IntroductionHomework/Lab 
//1.Create a School object which can 
//    1.Add / Remove course
//    2.Enrol the student/ Remove student
//      With limitation on credit
//    3.Print the all student with Different GPA grade
//    4.Generate student fee receipt course for $100 etc 
//2.Create a Course object which can 
//    1.Has maximum number of student 
//    2.has its own credit
//
//3.Create a Student object which can 
//    1.show its own credit limit  
//    2.show GPA       //later


namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            School s1 = new School();
            s1.AddStudent("Kenneth", 39, 10);
            s1.AddStudent("Mark", 35, 10);
            s1.AddStudent("Mike", 23, 10);
            s1.AddCourse("web dev", 40, 3);
            s1.AddCourse("java", 20, 3);
            s1.AddStudentToCourse(1, "web dev", 8);
            s1.AddStudentToCourse(1, "java", 5);
            s1.AddStudentToCourse(3, "java", 9);
            s1.AddStudentToCourse(2, "web dev", 8);
            //int temp = s1.GetStudent("Mike");
            // Console.WriteLine(temp.ToString());

            //s1.DelStudent(1);
            //s1.removeCourse("Java");
            s1.PrintRecipt(1);
            s1.PrintGPA(1);
            Console.WriteLine("End");
            
        }
    }
}








