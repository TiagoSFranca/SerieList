using SerieList.Domain.Entitites.Token;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Token
{
    public class ApplicationTypeConfiguration : EntityTypeConfiguration<ApplicationTypeModel>
    {
        public ApplicationTypeConfiguration()
        {
            ToTable("ApplicationType");

            HasKey(pt => pt.IdApplicationType);

            Property(pt => pt.Description)
                .IsRequired()
                .HasMaxLength(64);

            Property(pt => pt.Excluded)
                .IsRequired();
            
            HasMany(pt => pt.TokenProviders)
                .WithRequired(p => p.ApplicationType)
                .HasForeignKey(p => p.IdApplicationType);

            Property(pt => pt.IdApplicationType)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
