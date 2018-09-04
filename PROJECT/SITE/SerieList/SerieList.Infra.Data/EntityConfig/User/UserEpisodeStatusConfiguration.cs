using SerieList.Domain.Entitites.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class UserEpisodeStatusConfiguration : EntityTypeConfiguration<UserEpisodeStatusModel>
    {
        public UserEpisodeStatusConfiguration()
        {
            ToTable("UserEpisodeStatus");

            HasKey(us => us.IdUserEpisodeStatus);

            Property(us => us.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(us => us.Excluded)
                .IsRequired();

            HasMany(us => us.UserEpisodes)
                .WithRequired(p => p.UserEpisodeStatus)
                .HasForeignKey(p => p.IdUserEpisodeStatus);

            Property(us => us.IdUserEpisodeStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
