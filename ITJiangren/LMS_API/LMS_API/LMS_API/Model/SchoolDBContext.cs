using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Model
{
    public class SchoolDBContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Teaching> Teachings { get; set; }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) :base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(a=>a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>().HasKey(a => a.Id);

            modelBuilder.Entity<Course>().Property(a => a.CourseId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Course>().HasKey(a => a.CourseId);

            modelBuilder.Entity<Enrollment>().HasKey(a => new {  a.StudentId, a.CourseId });//student to course
            modelBuilder.Entity<Enrollment>().HasOne(a => a.Student)
                                             .WithMany(b => b.Enrollments)
                                             .HasForeignKey(ab => ab.StudentId);

            modelBuilder.Entity<Enrollment>().HasOne(a => a.Course)
                                             .WithMany(b => b.Enrollments)
                                             .HasForeignKey(ab => ab.CourseId);

            modelBuilder.Entity<Lecturer>().Property(lecturer => lecturer.LecturerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Lecturer>().HasKey(lecturer => lecturer.LecturerId);

            modelBuilder.Entity<Teaching>().HasKey(teaching => new { teaching.LecturerId, teaching.CourseId }); //leturer to course
            modelBuilder.Entity<Teaching>().HasOne(teaching => teaching.Lecturer)
                                           .WithMany(lecturer => lecturer.Teachings)
                                           .HasForeignKey(teaching => teaching.LecturerId);
            modelBuilder.Entity<Teaching>().HasOne(teaching => teaching.Course)
                                           .WithMany(course => course.Teachings)
                                           .HasForeignKey(teaching => teaching.CourseId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;userid=root;pwd=abi820830;port=3306;database=lms;sslmode=none";
            optionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(optionsBuilder);
        }



    }
}
