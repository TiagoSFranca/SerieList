using SerieList.Domain.Entitites.Profile;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Profile
{
    public class PermissionGroupConfiguration : EntityTypeConfiguration<PermissionGroupModel>
    {
        public PermissionGroupConfiguration()
        {
            ToTable("PermissionGroup");

            HasKey(pg => pg.IdPermissionGroup);

            Property(pg => pg.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(pg => pg.Excluded)
                .IsRequired();

            HasMany(pg => pg.Permissions)
                .WithRequired(p => p.PermissionGroup)
                .HasForeignKey(p => p.IdPermissionGroup);

            Property(pg => pg.IdPermissionGroup)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
