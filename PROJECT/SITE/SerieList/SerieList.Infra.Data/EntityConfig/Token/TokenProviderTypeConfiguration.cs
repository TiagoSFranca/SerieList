using SerieList.Domain.Entitites.Token;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Token
{
    public class TokenProviderTypeConfiguration : EntityTypeConfiguration<TokenProviderTypeModel>
    {
        public TokenProviderTypeConfiguration()
        {
            ToTable("TokenProviderType");

            HasKey(pt => pt.IdTokenProviderType);

            Property(pt => pt.Description)
                .IsRequired()
                .HasMaxLength(64);

            Property(pt => pt.Excluded)
                .IsRequired();

            Property(pt => pt.HoursValid)
                .IsRequired();

            HasMany(pt => pt.TokenProviders)
                .WithRequired(p => p.TokenProviderType)
                .HasForeignKey(p => p.IdTokenProviderType);

            Property(pt => pt.IdTokenProviderType)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
