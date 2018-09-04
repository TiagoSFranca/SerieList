using SerieList.Domain.Entitites.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class UserSeasonStatusConfiguration : EntityTypeConfiguration<UserSeasonStatusModel>
    {
        public UserSeasonStatusConfiguration()
        {
            ToTable("UserSeasonStatus");

            HasKey(us => us.IdUserSeasonStatus);

            Property(us => us.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(us => us.Excluded)
                .IsRequired();

            //HasMany(us => us.UserSeasons)
            //    .WithRequired(p => p.UserSeasonStatus)
            //    .HasForeignKey(p => p.IdUserSeasonStatus);

            Property(us => us.IdUserSeasonStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
