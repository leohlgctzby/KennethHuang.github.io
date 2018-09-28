using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMS_API.Model
{
    public interface ISchoolDataStore
    {
        //for Student 
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        Student UpdateStudent(int id, Student student);
        bool DelStudent(int id);
        

        //for course
        IEnumerable<Course> GetCourses();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        Course UpdataCourse(int id, Course course);
        bool DelCourse(int id);

        //for Enrollment
        Enrollment GetEnrollment(int studentId, int courseId);
        void AddEnrollment(int studentId, int courseId);
        //Enrollment UpdateEnrollment(int studentId, int courseId, Enrollment enrollment);
        bool DelEnrollment(int stdentId, int courseId);

        //for lecturer
        IEnumerable<Lecturer> GetAllLecturers();
        Lecturer GetLecturerById(int id);
        void AddLectuer(Lecturer lecturer);
        Lecturer updateLecturer(int id, Lecturer lecturer);
        bool DelLecturer(int id);

        //for teaching
        Teaching GetTeaching(int lecturerId, int courseId);
        void AddTeaching(int lecturerId, int courseId);
        bool DelTeaching(int lecturerId, int courseId);


        bool save();



    }

    public class SchoolDataStore:ISchoolDataStore
    {
        private SchoolDBContext _ctx;

        public SchoolDataStore(SchoolDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public void AddStudent(Student student)
        {
            _ctx.Students.Add(student);
            save();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            //throw new NotImplementedException();
            return _ctx.Students
                .Include(student => student.Enrollments)
                .ThenInclude(enrollment => enrollment.Course)
                .ToList();
        }

        public Student GetStudentById(int id)
        {
            // throw new NotImplementedException();
           return _ctx.Students.Find(id);

        }

        public Student UpdateStudent(int id, Student student)
        {
            // throw new NotImplementedException();
            Student tempStudent = _ctx.Students.Find(id);
            if (tempStudent != null)
            {
                tempStudent.FirstName = student.FirstName;
                tempStudent.LastName = student.LastName;
                tempStudent.CreditLimit = student.CreditLimit;
                save();
            }
            return _ctx.Students.Find(id);//why not tempStudent?
        }


        public bool DelStudent(int id)
        {
            //throw new NotImplementedException();
            Student delStudent = _ctx.Students.Find(id);
            if (delStudent != null)
                _ctx.Students.Remove(delStudent);

            //how about enrollment?
            return save();
        }

        public void AddCourse(Course course)
        {
            _ctx.Courses.Add(course);
            save();
        }

        public Course GetCourseById(int id)
        {
            // throw new NotImplementedException();
            return _ctx.Courses.Find(id);
        }

        public IEnumerable<Course> GetCourses()
        {
            //throw new NotImplementedException();
            return _ctx.Courses.ToList();
        }

        public Course UpdataCourse(int id, Course course)
        {
            //throw new NotImplementedException();
            Course tempCourse = _ctx.Courses.Find(id);
            if (tempCourse != null)
            {
                tempCourse.Title = course.Title;
                tempCourse.Credit = course.Credit;
                tempCourse.MaxStudentNum = course.MaxStudentNum;
                save();
            }
            return _ctx.Courses.Find(id);

        }

        public bool DelCourse(int id)
        {
            //throw new NotImplementedException();
            Course delCourse = _ctx.Courses.Find(id);
            if (delCourse != null)
                _ctx.Courses.Remove(delCourse);
            return save();
        }


        public void AddEnrollment(int studentId, int courseId)
        {
            Student student = _ctx.Students.Find(studentId);
            Course course = _ctx.Courses.Find(courseId);
            var enrollment = new Enrollment()
            {
                StudentId = studentId,
                CourseId = courseId,
                Student = student,
                Course = course
            };

            _ctx.Enrollments.Add(enrollment);
            save();
        }

        public Enrollment GetEnrollment(int studentId, int courseId)
        {
            return _ctx.Enrollments.Find(studentId, courseId);
        }

        public bool DelEnrollment(int studentId, int courseId)
        {
            // throw new NotImplementedException();
            Enrollment delEnrollemnt = _ctx.Enrollments.Find(studentId, courseId);
            if (delEnrollemnt != null)
                _ctx.Enrollments.Remove(delEnrollemnt);
            return save();
        }

        //public Enrollment UpdateEnrollment(int studentId, int courseId, Enrollment enrollment)
        //{
        //    throw new NotImplementedException();
        //}

        public bool save()
        {
            // throw new NotImplementedException();
            return (_ctx.SaveChanges() >= 0);
        }

        public IEnumerable<Lecturer> GetAllLecturers()
        {
            return _ctx.Lecturers.ToList();
            
        }

        public Lecturer GetLecturerById(int id)
        {
            return _ctx.Lecturers.Find(id);
        }

        public void AddLectuer(Lecturer lecturer)
        {
            _ctx.Lecturers.Add(lecturer);
            save();
        }

        public Lecturer updateLecturer(int id, Lecturer lecturer)
        {
            Lecturer tempLecturer = _ctx.Lecturers.Find(id);
            if (tempLecturer != null)
            {
                tempLecturer.FirstName = lecturer.FirstName;
                tempLecturer.LastName = lecturer.LastName;
                save();
            }
            return _ctx.Lecturers.Find(id);

        }

        public bool DelLecturer(int id)
        {
            Lecturer tempLecturer = _ctx.Lecturers.Find(id);
            if (tempLecturer != null)
                 _ctx.Lecturers.Remove(tempLecturer);
            return save();            
        }

        public Teaching GetTeaching(int lecturerId, int courseId)
        {
            return _ctx.Teachings.Find(lecturerId, courseId);
        }

        public void AddTeaching(int lecturerId, int courseId)
        {
            Lecturer lecturer = _ctx.Lecturers.Find(lecturerId);
            Course course = _ctx.Courses.Find(courseId);
            Teaching teaching = new Teaching
            {
                LecturerId = lecturerId,
                CourseId = courseId,
                Lecturer = lecturer,
                Course = course
            };
            _ctx.Teachings.Add(teaching);
            save();

        }

        public bool DelTeaching(int lecturerId, int courseId)
        {
            Teaching teaching = _ctx.Teachings.Find(lecturerId, courseId);
            if(teaching != null)
            {
                _ctx.Teachings.Remove(teaching);
            }
            return save()
                ;
        }
    }

    
}
