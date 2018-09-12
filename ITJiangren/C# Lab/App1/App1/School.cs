using System;
using System.Collections.Generic;

namespace App1
{
    public class School
    {
        private List<Student> students;
        private List<Course> courses;
        private List<StudentToCourse> studentToCourses;
        private int studentID;

        public School()
        {
            students = new List<Student>();
            courses = new List<Course>();
            studentToCourses = new List<StudentToCourse>();
            studentID = 0;
        }

        public void AddCourse(string courseName, int maxStudents, int credit)
        {
            if (courses != null)
            {
                courses.Add(new Course(courseName, maxStudents, credit));
                Console.WriteLine("A course added.");
                // return true;            
            }
            else
            {
                Console.WriteLine("Error! New a course list first.");
                // return false;
            }

        }

        public void AddStudent(string name, int age, int cL)
        {
            if (students != null)
            {
                studentID++;
                students.Add(new Student(studentID, name, age, cL));
                //students.Add(new Student(name, age, cL));
                Console.WriteLine("A student added.");
                // return true;
            }
            else
            {
                Console.WriteLine("Error! New a student list first.");
                // return false;
            }
        }

        public void AddStudentToCourse(int studentID, string courseName, int grade)
        {
            if (studentToCourses != null)
            {
                // need a check for whether the corresponding student data and course exist in database
                //add here later.
                studentToCourses.Add(new StudentToCourse(studentID, courseName, grade));
                Console.WriteLine(students.Find(x => x.StudentID == studentID).Name
                    + " has been added to course:'" + courseName + "',and got a grade:" + grade + " point.");
            }
            else
            {
                Console.WriteLine("Error! New a studentToCourses list first.");
            }
        }

        public void AddStudentToCourse(string studentName, string courseName, int grade)
        {
            if (studentToCourses != null)
            {
                // need a check for whether the corresponding student data and course exist in database
                //add here later.
                studentToCourses.Add(new StudentToCourse(studentName, courseName, grade));
                Console.WriteLine(studentName + "has been added to" + courseName + ",and got a grade:" + grade + " point.");
            }
            else
            {
                Console.WriteLine("Error! New a studentToCourses list first.");
            }
        }

        public int GetStudent(string studentName)
        {
            return students.FindIndex(x => x.Name.ToString() == studentName);
        }


        public void DelStudent(int studentID)
        {
            bool isStudentDel = false;
            Console.WriteLine("Before DelStudent：");
            foreach (var sl in students)
                Console.WriteLine(sl.StudentID + ":" + sl.Name);

            foreach (var sl in students)
            {
                if (sl.StudentID == studentID)
                {
                    students.Remove(sl);
                    isStudentDel = true;
                    break;
                }
            }
            if (isStudentDel)
            {
                Console.WriteLine("After DelStudent：");
                foreach (var sl in students)
                    Console.WriteLine(sl.StudentID + ":" + sl.Name);
                DelStudentToCourse(studentID);
            }
        }

        public void DelStudentToCourse(int studentID)
        {
            Console.WriteLine("Before DelStudentToCourse：");
            foreach (var stc in studentToCourses)
                Console.WriteLine(stc.StudentID + "@" + stc.CourseName);

            Console.WriteLine("-------------------------");
            for (int i = (studentToCourses.Count - 1); i >= 0; i--)
            {
                if (studentToCourses[i].StudentID == studentID)
                    studentToCourses.Remove(studentToCourses[i]);
            }


            Console.WriteLine("After DelStudentToCourse：");
            foreach (var stc in studentToCourses)
                Console.WriteLine(stc.StudentID + "@" + stc.CourseName);
        }


        public void removeCourse(string courseName)
        {
            bool isCourseRemoved = false;
            Console.WriteLine("--Before a course been removed--");
            foreach (var course in courses)
            {
                Console.WriteLine("Course:" + course.CourseName.ToString());
            }

            foreach (var course in courses)
            {
                if (course.CourseName == courseName)
                {
                    courses.Remove(course);
                    isCourseRemoved = true;
                    break;
                }
            }

            if (isCourseRemoved)
            {
                Console.WriteLine("--after a course been removed--");
                foreach (var course in courses)
                {
                    Console.WriteLine("Course:" + course.CourseName.ToString());
                }
                DelStudentToCourse(courseName);
            }
            else
                Console.WriteLine("--fail to remove a course--");
        }

        public void DelStudentToCourse(string courseName)
        {
            Console.WriteLine("Before DelStudentToCourse：");
            foreach (var stc in studentToCourses)
                Console.WriteLine(stc.StudentID + "@" + stc.CourseName);

            Console.WriteLine("-------------------------");
            for (int i = (studentToCourses.Count - 1); i >= 0; i--)
            {
                if (studentToCourses[i].CourseName == courseName)
                    studentToCourses.Remove(studentToCourses[i]);
            }


            Console.WriteLine("After DelStudentToCourse：");
            foreach (var stc in studentToCourses)
                Console.WriteLine(stc.StudentID + "@" + stc.CourseName);
        }

        public void PrintRecipt(int studentID)
        {
            int totalFee = 0;
            int totalCourse = 0;
            if (students.Count > 0 && courses.Count > 0)
            {
                foreach (StudentToCourse stc in studentToCourses)
                {
                    if (stc.StudentID == studentID)
                    {
                        totalFee +=
                        courses.Find(x => x.CourseName.ToString() == stc.CourseName).CourseFee;
                        totalCourse++;
                    }
                }
            }
            Console.WriteLine("Student #" + studentID + " had selected " + totalCourse + " courses. The tuition fee is " + totalFee + " AUD.");

        }

        public void PrintGPA(int studentID)
        {

            bool hasGPA = false;
            int gradeTimesCredit = 0; //to store the summary of grade times credit
            int courseCredit = 0; //to store the Credit of current course in foreach loop
            int totalCredits = 0; //to store total credits of all courses
            if (students.Count > 0 && courses.Count > 0)
            {
                foreach (StudentToCourse stc in studentToCourses)
                {
                    if (stc.StudentID == studentID)
                    {
                        courseCredit =
                        courses.Find(x => x.CourseName.ToString() == stc.CourseName).Credit;

                        totalCredits += courseCredit;
                        gradeTimesCredit += stc.Grade * courseCredit;
                        hasGPA = true;
                    }
                }
            }
            if (hasGPA && totalCredits != 0)
                Console.WriteLine("GPA of student #" + studentID + " is:" + (double)(gradeTimesCredit / totalCredits));
            else
                Console.WriteLine("Fail to print GPA of student #" + studentID);

        }


    }

}

