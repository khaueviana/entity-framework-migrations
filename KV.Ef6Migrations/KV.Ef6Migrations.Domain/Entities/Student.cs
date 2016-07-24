using System;

namespace KV.Ef6Migrations.Domain.Entities
{
    public class Student : Person
    {
        public Student()
        {
            User = new User();
        }

        public Guid StudentId { get; set; }
        public virtual StudentClass StudentClass { get; set; }
        public virtual User User { get; set; }
    }
}
