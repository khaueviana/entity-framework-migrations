using System;
using System.Collections.Generic;

namespace KV.Ef6Migrations.Domain.Entities
{
    public class Course
    {
        public Course()
        {
            TeacherList = new List<Teacher>();
            Active = true;
        }

        public Guid CourseId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Teacher> TeacherList { get; set; }
        public override string ToString()
        {
            return Description;
        }
    }
}