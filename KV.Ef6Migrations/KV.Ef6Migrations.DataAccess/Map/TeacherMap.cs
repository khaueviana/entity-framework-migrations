using KV.Ef6Migrations.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KV.Ef6Migrations.DataAccess.Map
{
    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            ToTable("Teacher");

            //Id gerado na aplicação através do Guid
            Property(x => x.TeacherId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }
}