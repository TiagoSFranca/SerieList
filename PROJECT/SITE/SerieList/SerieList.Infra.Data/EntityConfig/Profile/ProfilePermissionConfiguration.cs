using SerieList.Domain.Entitites.Profile;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Profile
{
    public class ProfilePermissionConfiguration : EntityTypeConfiguration<ProfilePermissionModel>
    {
        public ProfilePermissionConfiguration()
        {
            ToTable("ProfilePermission");
            HasKey(pp => new { pp.IdProfile, pp.IdPermission });

            Property(pp => pp.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pp => pp.UpdatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pp => pp.Excluded)
                .IsRequired();

            Property(pp => pp.IdProfile)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(pp => pp.IdPermission)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
