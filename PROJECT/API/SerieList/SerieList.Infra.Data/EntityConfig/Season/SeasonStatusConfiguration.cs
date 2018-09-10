using SerieList.Domain.Entitites.Season;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Season
{
    public class SeasonStatusConfiguration : EntityTypeConfiguration<SeasonStatusModel>
    {
        public SeasonStatusConfiguration()
        {
            ToTable("SeasonStatus");

            HasKey(ss => ss.IdSeasonStatus);

            Property(ss => ss.Description)
                .IsRequired()
                .HasMaxLength(32);

            Property(ss => ss.Excluded)
                .IsRequired();

            HasMany(ss => ss.Seasons)
                .WithRequired(p => p.SeasonStatus)
                .HasForeignKey(p => p.IdSeasonStatus);

            Property(ss => ss.IdSeasonStatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
