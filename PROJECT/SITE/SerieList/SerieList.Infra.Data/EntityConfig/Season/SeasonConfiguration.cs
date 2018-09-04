using SerieList.Domain.Entitites.Season;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Season
{
    public class SeasonConfiguration : EntityTypeConfiguration<SeasonModel>
    {
        public SeasonConfiguration()
        {
            ToTable("Season");

            HasKey(s => s.IdSeason);

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
                .WithMany(p => p.Seasons)
                .HasForeignKey(s => s.IdProduct);

            HasRequired(s => s.Visibility)
                .WithMany(v => v.Seasons)
                .HasForeignKey(s => s.IdVisibility);

            HasRequired(s => s.SeasonStatus)
                .WithMany(ss => ss.Seasons)
                .HasForeignKey(s => s.IdSeasonStatus);

            HasRequired(pt => pt.User)
                .WithMany(v => v.Seasons)
                .HasForeignKey(pt => pt.IdUser);

            HasMany(pt => pt.Episodes)
                .WithOptional(s => s.Season)
                .HasForeignKey(s => s.IdSeason);

            HasMany(pt => pt.UserSeasons)
                .WithRequired(s => s.Season)
                .HasForeignKey(s => s.IdSeason);

            Property(s => s.IdSeason)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
