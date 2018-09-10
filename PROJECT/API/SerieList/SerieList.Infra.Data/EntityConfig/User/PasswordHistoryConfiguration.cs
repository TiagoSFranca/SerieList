using SerieList.Domain.Entitites.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class PasswordHistoryConfiguration : EntityTypeConfiguration<PasswordHistoryModel>
    {
        public PasswordHistoryConfiguration()
        {
            ToTable("PasswordHistory");

            HasKey(pt => pt.IdPasswordHistory);

            Property(pt => pt.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME");

            Property(ui => ui.Password)
                .IsRequired()
                .HasMaxLength(256);

            HasRequired(pt => pt.User)
                .WithMany(v => v.PasswordResets)
                .HasForeignKey(pt => pt.IdUser);

            Property(pt => pt.IdPasswordHistory)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
