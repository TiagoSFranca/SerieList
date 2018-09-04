using SerieList.Domain.Entitites;
using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Entitites.Profile;
using SerieList.Infra.Data.EntityConfig;
using SerieList.Infra.Data.EntityConfig.Product;
using SerieList.Infra.Data.EntityConfig.Episode;
using SerieList.Infra.Data.EntityConfig.Season;
using SerieList.Infra.Data.EntityConfig.Profile;
using MySql.Data.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SerieList.Domain.Entitites.User;
using SerieList.Infra.Data.EntityConfig.User;
using SerieList.Domain.Entitites.Token;
using SerieList.Infra.Data.EntityConfig.Token;

namespace SerieList.Infra.Data.Data.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SerieListContext : DbContext
    {
        public SerieListContext()
            : base("SerieListConnection")
        {

        }

        #region Product

        public DbSet<ProductModel> Product { get; set; }
        public DbSet<VisibilityModel> Visibility { get; set; }
        public DbSet<ProductTypeModel> ProductType { get; set; }
        public DbSet<ProductStatusModel> ProductStatus { get; set; }
        public DbSet<ProductCategoryModel> ProductCategory { get; set; }
        public DbSet<ProductProductCategoryModel> ProductProductCategory { get; set; }

        #endregion

        #region Season

        public DbSet<SeasonStatusModel> SeasonStatus { get; set; }
        public DbSet<SeasonModel> Season { get; set; }

        #endregion

        #region Episode

        public DbSet<EpisodeStatusModel> EpisodeStatus { get; set; }
        public DbSet<EpisodeModel> Episode { get; set; }

        #endregion

        #region Profile

        public DbSet<PermissionGroupModel> PermissionGroup { get; set; }
        public DbSet<PermissionTypeModel> PermissionType { get; set; }
        public DbSet<PermissionModel> Permission { get; set; }
        public DbSet<ProfilePermissionModel> ProfilePermission { get; set; }
        public DbSet<ProfileModel> Profile { get; set; }

        #endregion

        #region User

        public DbSet<UserStatusModel> UserStatus { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<PasswordHistoryModel> PasswordReset { get; set; }
        public DbSet<UserProductStatusModel> UserProductStatus { get; set; }
        public DbSet<UserProductModel> UserProduct { get; set; }
        public DbSet<UserEpisodeStatusModel> UserEpisodeStatus { get; set; }
        public DbSet<UserEpisodeModel> UserEpisode { get; set; }

        #endregion

        #region Token

        public DbSet<TokenProviderTypeModel> TokenProviderType { get; set; }
        public DbSet<TokenProviderModel> TokenProvider { get; set; }

        #endregion

        public DbSet<LogEvent> LogEvent { get; set; }

        public DbSet<ConfigurationModel> ConfigurationSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Generic Config

            modelBuilder.HasDefaultSchema(String.Empty);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id" + p.ReflectedType.Name)
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("VARCHAR"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(256));

            #endregion

            #region EntityConfig

            #region Product

            modelBuilder.Configurations.Add(new ProductTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductStatusConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new VisibilityConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductInfoConfiguration());
            modelBuilder.Configurations.Add(new ProductProductCategoryConfiguration());

            #endregion

            #region Season

            modelBuilder.Configurations.Add(new SeasonStatusConfiguration());
            modelBuilder.Configurations.Add(new SeasonConfiguration());

            #endregion

            #region Episode

            modelBuilder.Configurations.Add(new EpisodeStatusConfiguration());
            modelBuilder.Configurations.Add(new EpisodeConfiguration());

            #endregion

            #region Profile

            modelBuilder.Configurations.Add(new PermissionGroupConfiguration());
            modelBuilder.Configurations.Add(new PermissionTypeConfiguration());
            modelBuilder.Configurations.Add(new PermissionConfiguration());
            modelBuilder.Configurations.Add(new ProfilePermissionConfiguration());
            modelBuilder.Configurations.Add(new ProfileConfiguration());

            #endregion

            #region User

            modelBuilder.Configurations.Add(new UserStatusConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserInfoConfiguration());
            modelBuilder.Configurations.Add(new PasswordHistoryConfiguration());
            modelBuilder.Configurations.Add(new UserProductStatusConfiguration());
            modelBuilder.Configurations.Add(new UserProductConfiguration());
            modelBuilder.Configurations.Add(new UserEpisodeStatusConfiguration());
            modelBuilder.Configurations.Add(new UserEpisodeConfiguration());

            #endregion

            #region Token

            modelBuilder.Configurations.Add(new TokenProviderTypeConfiguration());
            modelBuilder.Configurations.Add(new TokenProviderConfiguration());

            #endregion

            modelBuilder.Configurations.Add(new LogEventConfiguration());
            modelBuilder.Configurations.Add(new ConfigurationConfiguration());

            #endregion

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity.GetType().GetProperty("CreatedAt") != null)
                        entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    if (entry.Entity.GetType().GetProperty("UpdatedAt") != null)
                        entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                    if (entry.Entity.GetType().GetProperty("Excluded") != null)
                        entry.Property("Excluded").CurrentValue = false;
                }

                if (entry.State == EntityState.Deleted)
                {
                    if (entry.Entity.GetType().GetProperty("Excluded") != null)
                    {
                        entry.Property("Excluded").CurrentValue = !(bool)entry.Property("Excluded").CurrentValue;
                        entry.State = EntityState.Modified;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity.GetType().GetProperty("CreatedAt") != null)
                        entry.Property("CreatedAt").IsModified = false;
                    if (entry.Entity.GetType().GetProperty("UpdatedAt") != null)
                        entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
