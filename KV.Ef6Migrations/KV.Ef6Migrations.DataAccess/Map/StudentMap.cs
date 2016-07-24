using KV.Ef6Migrations.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KV.Ef6Migrations.DataAccess.Map
{
    class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            ToTable("Student");

            //Id gerado na aplicação através do Guid
            Property(x => x.StudentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //1:N - 1 student DEVE ter 1 student class e 1 student class pode ter muitos students 
            HasRequired(x => x.StudentClass)
              .WithMany(x => x.StudentList)
              .Map(m => m.MapKey("StudentClassId"));

            //1:1 - 1 student deve ter apenas 1 user
            HasRequired(x => x.User)
              .WithRequiredPrincipal();
        }
    }
}