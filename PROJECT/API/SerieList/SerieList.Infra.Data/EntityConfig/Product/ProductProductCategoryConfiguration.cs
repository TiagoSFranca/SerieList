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
    public class ProductProductCategoryConfiguration : EntityTypeConfiguration<ProductProductCategoryModel>
    {
        public ProductProductCategoryConfiguration()
        {
            ToTable("ProductProductCategory");
            HasKey(ppc => new { ppc.IdProduct, ppc.IdCategory });

            Property(ppc => ppc.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(ppc => ppc.UpdatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(ppc => ppc.Excluded)
                .IsRequired();

            Property(ppc => ppc.IdProduct)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(ppc => ppc.IdCategory)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
