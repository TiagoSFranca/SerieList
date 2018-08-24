using SerieList.Domain.Entitites.Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Product
{
    public class ProductStatusConfiguration : EntityTypeConfiguration<ProductStatusModel>
    {
        public ProductStatusConfiguration()
        {
            ToTable("ProductStatus");

            HasKey(ps => ps.IdProductStatus);

            Property(ps => ps.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(ps => ps.Excluded)
                .IsRequired();

            HasMany(ps => ps.Products)
                .WithRequired(p => p.ProductStatus)
                .HasForeignKey(p => p.IdProductStatus);

            Property(ps => ps.IdProductStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
