using SerieList.Domain.Entitites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig
{
    public class ConfigurationConfiguration : EntityTypeConfiguration<ConfigurationModel>
    {
        public ConfigurationConfiguration()
        {
            ToTable("Configuration");

            HasKey(c => c.IdConfiguration);

            Property(c => c.Excluded)
                .IsRequired();

            Property(c => c.Key)
                .IsRequired()
                .HasMaxLength(256);

            Property(c => c.Value)
                .IsRequired()
                .HasMaxLength(256);

            Property(c => c.IdConfiguration).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
