using KV.Ef6Migrations.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace KV.Ef6Migrations.DataAccess.Map
{
    public class StudentClassMap : EntityTypeConfiguration<StudentClass>
    {
        public StudentClassMap()
        {
            ToTable("StudentClass");
            HasKey(x => x.StudentClassId);

            /*Na entidade StudentClass, a propriedade do tipo Course é obrigatória*/
            HasRequired(x => x.Course)
               .WithMany() //Course pode ter muitas StudentClasses
               .Map(m => m.MapKey("CourseId"));//a chave estrangeira em StudentClass é CourseId

            /*Novamente, em StudentClass a propriedade do tipo Teacher é requerida*/
            HasRequired(x => x.Teacher)
               .WithMany(x => x.StudentClassList) //a classe Teacher pode ter uma lista de Turma
               .Map(m => m.MapKey("TeacherId"));//a chave estrangeira é TeacherId
        }
    }
}