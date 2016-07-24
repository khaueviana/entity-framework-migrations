using KV.Ef6Migrations.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace KV.Ef6Migrations.DataAccess.Map
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            /*O método ToTable define qual o nome que será
            dado a tabela no banco de dados*/
            ToTable("Course");

            //Definimos a propriedade CourseId como chave primária
            HasKey(x => x.CourseId);

            //Description terá no máximo 150 caracteres e será um campo "NOT NULL"
            Property(x => x.Description).HasMaxLength(150).IsRequired();

            HasMany(x => x.TeacherList)
                      .WithMany(x => x.CourseList)
                      .Map(m =>
                      {
                          m.MapLeftKey("CourseId");
                          m.MapRightKey("TeacherId");
                          m.ToTable("CourseTeacher");
                      });
        }
    }
}