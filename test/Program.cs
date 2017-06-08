using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using ORM;
using ORM.Entities;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new StudentContext())
            {
                var student = new Student() {Name = "123"};
                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
        }

        public class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
        }

        public class StudentContext : DbContext
        {
            public DbSet<Student> Students { get; set; }
        }
    }
}
