using KV.Ef6Migrations.DataAccess;
using KV.Ef6Migrations.Domain.Entities;
using System;
using System.Linq;

namespace KV.Ef6Migrations.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext db = new DataContext();

            var courses = db.Courses
                    .Include("TeacherList")
                    .ToList();

            var course = courses.FirstOrDefault(x => x.Number == "70-486");
            var teacher = course.TeacherList.FirstOrDefault(x => x.TeacherId == 2);

            StudentClass studentClass = new StudentClass();
            studentClass.InitialDate = DateTime.Now;
            studentClass.EndDate = DateTime.Now.AddDays(10);
            studentClass.Course = course;
            studentClass.Teacher = teacher;

            Student student1 = new Student();
            student1.Name = "Khauê Viana";

            User user = new User();
            user.Mail = "khaueviana@gmail.com";
            user.Password = "123456";

            student1.User = user;

            Student student2 = new Student();
            student2.Name = "Juliane Albuquerque";

            User user2 = new User();
            user2.Mail = "juliane.albq@gmail.com";
            user2.Password = "123456";

            student2.User = user2;

            studentClass.StudentList.Add(student1);
            studentClass.StudentList.Add(student2);

            db.StudentClasses.Add(studentClass);
            db.SaveChanges();

            var studentClasses = db.StudentClasses
                 .Include("Teacher")
                 .Include("Course")
                 .Include("StudentList")
                 .ToList();

            var users = db.Users
                         .ToList();

            foreach (var studentClassItem in studentClasses)
            {
                Console.WriteLine("Turma: " + studentClassItem.Course.Description);
                Console.WriteLine("Início: " + studentClassItem.InitialDate.ToShortDateString());
                Console.WriteLine("Previsto: " + studentClassItem.EndDate.ToShortDateString());
                Console.WriteLine("Professor: " + studentClassItem.Teacher.Name);

                Console.WriteLine("------------------------ Alunos Matriculados ------------------------");

                foreach (var studentItem in studentClassItem.StudentList)
                {
                    Console.WriteLine(String.Format("Nome: {0} - E-mail: {1}", studentItem.Name, users.FirstOrDefault(x => x.UserId == studentItem.StudentId).Mail));
                }
                Console.WriteLine(Environment.NewLine);
            }

            Console.ReadKey();
        }
    }
}