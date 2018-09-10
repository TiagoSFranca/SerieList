using SerieList.Domain.Entitites.Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Product
{
    public class VisibilityConfiguration : EntityTypeConfiguration<VisibilityModel>
    {
        public VisibilityConfiguration()
        {
            ToTable("Visibility");

            HasKey(v => v.IdVisibility);

            Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(64);

            Property(v => v.Excluded)
                .IsRequired();

            HasMany(v => v.Products)
                .WithRequired(p => p.Visibility)
                .HasForeignKey(p => p.IdVisibility);

            HasMany(v => v.Seasons)
                .WithRequired(p => p.Visibility)
                .HasForeignKey(p => p.IdVisibility);

            HasMany(v => v.Episodes)
                .WithRequired(p => p.Visibility)
                .HasForeignKey(p => p.IdVisibility);

            Property(v => v.IdVisibility)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
