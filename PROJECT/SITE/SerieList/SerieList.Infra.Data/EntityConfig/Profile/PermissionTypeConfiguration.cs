using SerieList.Domain.Entitites.Profile;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Profile
{
    public class PermissionTypeConfiguration : EntityTypeConfiguration<PermissionTypeModel>
    {
        public PermissionTypeConfiguration()
        {
            ToTable("PermissionType");

            HasKey(pt => pt.IdPermissionType);

            Property(pt => pt.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(pt => pt.Excluded)
                .IsRequired();

            HasMany(pt => pt.Permissions)
                .WithRequired(p => p.PermissionType)
                .HasForeignKey(p => p.IdPermissionType);

            Property(pt => pt.IdPermissionType)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
