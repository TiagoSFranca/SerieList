using SerieList.Domain.Entitites.Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Product
{
    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategoryModel>
    {
        public ProductCategoryConfiguration()
        {
            ToTable("ProductCategory");

            HasKey(pt => pt.IdProductCategory);

            Property(pt => pt.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(pt => pt.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.Excluded)
                .IsRequired();

            HasMany(pt => pt.Products)
                .WithRequired(p => p.Category)
                .HasForeignKey(p => p.IdCategory);

            Property(pt => pt.IdProductCategory)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
