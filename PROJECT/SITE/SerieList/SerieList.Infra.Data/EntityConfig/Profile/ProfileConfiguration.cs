using SerieList.Domain.Entitites.Profile;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Profile
{
    public class ProfileConfiguration : EntityTypeConfiguration<ProfileModel>
    {
        public ProfileConfiguration()
        {
            ToTable("Profile");

            HasKey(p => p.IdProfile);

            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(64);

            Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(p => p.Excluded)
                .IsRequired();

            HasMany(p => p.Permissions)
                .WithRequired(p => p.Profile)
                .HasForeignKey(p => p.IdProfile);

            HasMany(us => us.Users)
                .WithRequired(p => p.Profile)
                .HasForeignKey(p => p.IdProfile);

            Property(p => p.IdProfile)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
