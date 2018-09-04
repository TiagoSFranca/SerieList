using SerieList.Domain.Entitites.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class UserEpisodeConfiguration : EntityTypeConfiguration<UserEpisodeModel>
    {
        public UserEpisodeConfiguration()
        {
            ToTable("UserEpisode");

            HasKey(ui => new { ui.IdUser, ui.IdEpisode });

            Property(pt => pt.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.UpdatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            HasRequired(pt => pt.UserEpisodeStatus)
                .WithMany(v => v.UserEpisodes)
                .HasForeignKey(pt => pt.IdUserEpisodeStatus);

            Property(pt => pt.IdUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(pt => pt.IdEpisode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(pt => pt.IdUserEpisodeStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
