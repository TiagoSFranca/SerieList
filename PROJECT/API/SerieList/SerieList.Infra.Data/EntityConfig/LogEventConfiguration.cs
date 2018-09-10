using SerieList.Domain.Entitites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig
{
    public class LogEventConfiguration : EntityTypeConfiguration<LogEvent>
    {
        public LogEventConfiguration()
        {
            ToTable("LogEvent");

            HasKey(pt => pt.IdEvent);

            Property(pt => pt.Exception)
                .IsRequired()
                .HasMaxLength(8000);

            Property(pt => pt.Level)
                .IsRequired()
                .HasMaxLength(50);

            Property(pt => pt.Logger)
                .IsRequired()
                .HasMaxLength(255);

            Property(pt => pt.Message)
                .IsRequired()
                .HasMaxLength(4000);
            
            Property(pt => pt.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(pt => pt.Excluded)
                .IsRequired();

            Property(pt => pt.IdEvent)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
