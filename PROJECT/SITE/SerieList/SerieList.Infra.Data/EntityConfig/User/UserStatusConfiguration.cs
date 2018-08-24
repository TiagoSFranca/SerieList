using SerieList.Domain.Entitites.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class UserStatusConfiguration : EntityTypeConfiguration<UserStatusModel>
    {
        public UserStatusConfiguration()
        {
            ToTable("UserStatus");

            HasKey(us => us.IdUserStatus);

            Property(us => us.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(us => us.Excluded)
                .IsRequired();

            HasMany(us => us.Users)
                .WithRequired(p => p.UserStatus)
                .HasForeignKey(p => p.IdUserStatus);

            Property(us => us.IdUserStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
