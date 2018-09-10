using SerieList.Domain.Entitites.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class UserProductConfiguration : EntityTypeConfiguration<UserProductModel>
    {
        public UserProductConfiguration()
        {
            ToTable("UserProduct");

            HasKey(ui => new { ui.IdUser, ui.IdProduct });

            Property(pt => pt.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.UpdatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            HasRequired(pt => pt.UserProductStatus)
                .WithMany(v => v.UserProducts)
                .HasForeignKey(pt => pt.IdUserProductStatus);

            Property(pt => pt.IdUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(pt => pt.IdProduct)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(pt => pt.IdUserProductStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
