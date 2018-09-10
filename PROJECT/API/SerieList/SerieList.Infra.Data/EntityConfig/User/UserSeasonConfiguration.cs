using SerieList.Domain.Entitites.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class UserSeasonConfiguration : EntityTypeConfiguration<UserSeasonModel>
    {
        public UserSeasonConfiguration()
        {
            ToTable("UserSeason");

            HasKey(ui => new { ui.IdUser, ui.IdSeason });

            Property(pt => pt.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.UpdatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            HasRequired(pt => pt.UserSeasonStatus)
                .WithMany(v => v.UserSeasons)
                .HasForeignKey(pt => pt.IdUserSeasonStatus);

            Property(pt => pt.IdUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(pt => pt.IdSeason)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(pt => pt.IdUserSeasonStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
