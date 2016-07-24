using KV.Ef6Migrations.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace KV.Ef6Migrations.DataAccess.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.UserId);
            Property(x => x.Mail).IsRequired().HasMaxLength(150);
            Property(u => u.Password).HasMaxLength(20).IsRequired();
        }
    }
}