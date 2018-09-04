using SerieList.Domain.Entitites.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class UserConfiguration : EntityTypeConfiguration<UserModel>
    {
        public UserConfiguration()
        {
            ToTable("User");

            HasKey(pt => pt.IdUser);

            Property(pt => pt.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.UpdatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.Excluded)
                .IsRequired();

            HasRequired(s => s.UserInfo)
                .WithRequiredPrincipal(ad => ad.User);

            HasRequired(pt => pt.UserStatus)
                .WithMany(v => v.Users)
                .HasForeignKey(pt => pt.IdUserStatus);

            HasRequired(pt => pt.Profile)
                .WithMany(v => v.Users)
                .HasForeignKey(pt => pt.IdProfile);

            HasMany(pt => pt.TokenProviders)
                .WithOptional(s => s.User)
                .HasForeignKey(s => s.IdUser);

            HasMany(pt => pt.Products)
                .WithRequired(s => s.User)
                .HasForeignKey(s => s.IdUser);

            HasMany(pt => pt.Seasons)
                .WithRequired(s => s.User)
                .HasForeignKey(s => s.IdUser);

            HasMany(pt => pt.Episodes)
                .WithRequired(s => s.User)
                .HasForeignKey(s => s.IdUser);

            HasMany(pt => pt.UserProducts)
                .WithRequired(s => s.User)
                .HasForeignKey(s => s.IdUser);

            HasMany(us => us.UserEpisodes)
                .WithRequired(p => p.User)
                .HasForeignKey(p => p.IdUser);

            Property(pt => pt.IdUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
