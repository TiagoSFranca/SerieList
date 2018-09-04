using SerieList.Domain.Entitites.Episode;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Episode
{
    public class EpisodeConfiguration : EntityTypeConfiguration<EpisodeModel>
    {
        public EpisodeConfiguration()
        {
            ToTable("Episode");

            HasKey(s => s.IdEpisode);

            Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(128);

            Property(s => s.Description)
                .IsOptional()
                .HasMaxLength(512);

            Property(s => s.Order)
                .IsRequired();

            Property(s => s.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(s => s.UpdatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(s => s.Excluded)
                .IsRequired();

            HasRequired(s => s.Product)
                .WithMany(p => p.Episodes)
                .HasForeignKey(s => s.IdProduct);

            HasRequired(s => s.Visibility)
                .WithMany(v => v.Episodes)
                .HasForeignKey(s => s.IdVisibility);

            HasRequired(s => s.EpisodeStatus)
                .WithMany(ss => ss.Episodes)
                .HasForeignKey(s => s.IdEpisodeStatus);

            HasRequired(pt => pt.User)
                .WithMany(v => v.Episodes)
                .HasForeignKey(pt => pt.IdUser);

            HasOptional(s => s.Season)
                .WithMany(ss => ss.Episodes)
                .HasForeignKey(s => s.IdSeason);

            HasMany(us => us.UserEpisodes)
                .WithRequired(p => p.Episode)
                .HasForeignKey(p => p.IdEpisode);

            Property(s => s.IdEpisode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
