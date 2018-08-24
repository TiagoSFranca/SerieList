using SerieList.Domain.Entitites.Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Product
{
    public class ProductConfiguration : EntityTypeConfiguration<ProductModel>
    {
        public ProductConfiguration()
        {
            ToTable("Product");

            HasKey(pt => pt.IdProduct);

            Property(pt => pt.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.UpdatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.Excluded)
                .IsRequired();

            HasRequired(s => s.ProductInfo)
                .WithRequiredPrincipal(ad => ad.Product);

            HasRequired(pt => pt.ProductStatus)
                .WithMany(v => v.Products)
                .HasForeignKey(pt => pt.IdProductStatus);

            HasRequired(pt => pt.ProductType)
                .WithMany(v => v.Products)
                .HasForeignKey(pt => pt.IdProductType);

            HasRequired(pt => pt.Visibility)
                .WithMany(v => v.Products)
                .HasForeignKey(pt => pt.IdVisibility);

            HasRequired(pt => pt.User)
                .WithMany(v => v.Products)
                .HasForeignKey(pt => pt.IdUser);

            HasMany(pt => pt.Categories)
                .WithRequired(c => c.Product)
                .HasForeignKey(c => c.IdProduct);

            HasMany(pt => pt.Seasons)
                .WithRequired(s => s.Product)
                .HasForeignKey(s => s.IdProduct);

            HasMany(pt => pt.Episodes)
                .WithRequired(s => s.Product)
                .HasForeignKey(s => s.IdProduct);

            Property(pt => pt.IdProduct)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
