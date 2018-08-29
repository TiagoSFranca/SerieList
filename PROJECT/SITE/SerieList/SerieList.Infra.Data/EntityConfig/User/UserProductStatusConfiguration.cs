using SerieList.Domain.Entitites.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class UserProductStatusConfiguration : EntityTypeConfiguration<UserProductStatusModel>
    {
        public UserProductStatusConfiguration()
        {
            ToTable("UserProductStatus");

            HasKey(us => us.IdUserProductStatus);

            Property(us => us.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(us => us.Excluded)
                .IsRequired();

            //HasMany(us => us.Users)
            //    .WithRequired(p => p.UserProductStatus)
            //    .HasForeignKey(p => p.IdUserProductStatus);

            Property(us => us.IdUserProductStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
