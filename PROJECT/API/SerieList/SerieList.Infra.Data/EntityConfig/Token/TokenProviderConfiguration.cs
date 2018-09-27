using SerieList.Domain.Entitites.Token;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.Token
{
    public class TokenProviderConfiguration : EntityTypeConfiguration<TokenProviderModel>
    {
        public TokenProviderConfiguration()
        {
            ToTable("TokenProvider");

            HasKey(t => t.IdTokenProvider);

            Property(s => s.Token)
                .IsRequired()
                .HasMaxLength(512);

            Property(s => s.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(s => s.UpdatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(s => s.Excluded)
                .IsRequired();

            Property(s => s.Valid)
                .IsRequired();

            HasRequired(s => s.TokenProviderType)
                .WithMany(v => v.TokenProviders)
                .HasForeignKey(s => s.IdTokenProviderType);

            HasRequired(s => s.ApplicationType)
                .WithMany(v => v.TokenProviders)
                .HasForeignKey(s => s.IdApplicationType);

            HasOptional(s => s.User)
                .WithMany(ss => ss.TokenProviders)
                .HasForeignKey(s => s.IdUser);

            Property(s => s.IdTokenProvider)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
