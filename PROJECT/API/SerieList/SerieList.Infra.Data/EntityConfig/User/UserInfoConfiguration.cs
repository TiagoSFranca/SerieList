using SerieList.Domain.Entitites.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerieList.Infra.Data.EntityConfig.User
{
    public class UserInfoConfiguration : EntityTypeConfiguration<UserInfoModel>
    {
        public UserInfoConfiguration()
        {
            ToTable("UserInfo");

            HasKey(ui => ui.IdUser);

            Property(ui => ui.FirstName)
                .IsRequired()
                .HasMaxLength(64);

            Property(ui => ui.LastName)
                .IsRequired()
                .HasMaxLength(128);

            Property(ui => ui.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(ui => ui.EmailConfirmed)
                .IsRequired();

            Property(ui => ui.SecurityStamp)
                .IsRequired()
                .HasMaxLength(256);

            Property(pt => pt.LockoutEndDateUtc)
                .IsOptional()
                .HasColumnType("DATETIME");

            Property(ui => ui.UserName)
                .IsRequired()
                .HasMaxLength(32);

            Property(ui => ui.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);

            Property(ui => ui.AccessFaliedCount)
                .IsRequired();

            Property(pt => pt.IdUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
