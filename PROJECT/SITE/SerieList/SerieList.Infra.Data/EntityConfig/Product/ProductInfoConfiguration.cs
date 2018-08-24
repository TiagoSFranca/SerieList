using SerieList.Domain.Entitites.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerieList.Infra.Data.EntityConfig.Product
{
    public class ProductInfoConfiguration : EntityTypeConfiguration<ProductInfoModel>
    {
        public ProductInfoConfiguration()
        {
            ToTable("ProductInfo");

            HasKey(pi => pi.IdProduct);

            Property(pi => pi.Title)
                .IsRequired()
                .HasMaxLength(128);

            Property(pi => pi.Description)
                .IsOptional()
                .HasMaxLength(512);

            Property(pi => pi.BeginAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pi => pi.EndAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.IdProduct)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
