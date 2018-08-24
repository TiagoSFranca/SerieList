using SerieList.Domain.Entitites.Profile;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Profile
{
    public class PermissionConfiguration : EntityTypeConfiguration<PermissionModel>
    {
        public PermissionConfiguration()
        {
            ToTable("Permission");

            HasKey(p => p.IdPermission);

            Property(p => p.Excluded)
                .IsRequired();

            HasRequired(p => p.PermissionGroup)
                .WithMany(v => v.Permissions)
                .HasForeignKey(p => p.IdPermissionGroup);

            HasRequired(p => p.PermissionType)
                .WithMany(v => v.Permissions)
                .HasForeignKey(p => p.IdPermissionType);

            HasMany(p => p.Profiles)
                .WithRequired(p => p.Permission)
                .HasForeignKey(p => p.IdPermission);

            Property(p => p.IdPermission)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
