using System;
using System.Collections.Generic;

namespace KV.Ef6Migrations.Domain.Entities
{
    public class Teacher : Person
    {
        public Teacher()
        {
            CourseList = new List<Course>();
            StudentClassList = new List<StudentClass>();
        }

        public Guid TeacherId { get; set; }
        public virtual ICollection<Course> CourseList { get; set; }
        public virtual ICollection<StudentClass> StudentClassList { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}