using KV.Ef6Migrations.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace KV.Ef6Migrations.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {

            /*
             * If DbContext.Configuration.ProxyCreationEnabled is set to false, DbContext will not load child objects 
             * for some parent object unless Include method is called on parent object.Setting DbContext.Configuration.LazyLoadingEnabled 
             * to true or false will have no impact on its behaviours.
             * 
             * If DbContext.Configuration.ProxyCreationEnabled is set to true, child objects will be loaded automatically, and 
             * DbContext.Configuration.LazyLoadingEnabled value will control when child objects are loaded.
             * 
             * Thread StackOverflow *-* = http://stackoverflow.com/questions/4596371/what-are-the-downsides-to-turning-off-proxycreationenabled-for-ctp5-of-ef-code-f
             */

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Aqui vamos remover a pluralização padrão do Etity Framework que é em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Desabilitamos o delete em cascata em relacionamentos 1:N evitando
            ter registros filhos     sem registros pai*/
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Basicamente a mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /*Definimos usando reflexão que toda propriedade que contenha
            "Nome da classe" + Id como "CursoId" por exemplo, seja dada como
            chave primária, caso não tenha sido especificado*/
            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());

            /*Toda propriedade do tipo string na entidade POCO
            seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));

            /*Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR (150) no banco de dados */
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(150));
        }
    }
}