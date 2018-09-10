using SerieList.Domain.Entitites.Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Product
{
    public class ProductTypeConfiguration : EntityTypeConfiguration<ProductTypeModel>
    {
        public ProductTypeConfiguration()
        {
            ToTable("ProductType");

            HasKey(pt => pt.IdProductType);

            Property(pt => pt.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(pt => pt.Excluded)
                .IsRequired();

            HasMany(pt => pt.Products)
                .WithRequired(p => p.ProductType)
                .HasForeignKey(p => p.IdProductType);

            Property(pt => pt.IdProductType)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
