using KV.Ef6Migrations.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace KV.Ef6Migrations.DataAccess.Map
{
    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            ToTable("Teacher");
            HasKey(x => x.TeacherId);
            Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }
}