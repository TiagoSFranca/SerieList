using SerieList.Domain.Entitites.Episode;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Episode
{
    public class EpisodeStatusConfiguration : EntityTypeConfiguration<EpisodeStatusModel>
    {
        public EpisodeStatusConfiguration()
        {
            ToTable("EpisodeStatus");

            HasKey(ss => ss.IdEpisodeStatus);

            Property(ss => ss.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(ss => ss.Excluded)
                .IsRequired();

            HasMany(ss => ss.Episodes)
                .WithRequired(p => p.EpisodeStatus)
                .HasForeignKey(p => p.IdEpisodeStatus);

            Property(ss => ss.IdEpisodeStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
