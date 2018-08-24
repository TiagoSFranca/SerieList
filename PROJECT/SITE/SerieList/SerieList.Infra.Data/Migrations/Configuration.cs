namespace SerieList.Infra.Data.Migrations
{
    using Data.Context;
    using System.Data.Entity.Migrations;
    using SerieList.Domain.Seed.Product;
    using SerieList.Domain.Seed.Season.Season;
    using SerieList.Domain.Seed.Episode;
    using SerieList.Domain.Seed.Profile;
    using SerieList.Domain.Seed.User;
    using SerieList.Domain.Seed;
    using SerieList.Domain.Seed.Token;

    internal sealed class Configuration : DbMigrationsConfiguration<SerieListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SerieListContext context)
        {
            #region ProductType

            context.ProductType.AddOrUpdate(ProductTypeSeed.Seeds.ToArray());

            #endregion

            #region ProductStatus

            context.ProductStatus.AddOrUpdate(ProductStatusSeed.Seeds.ToArray());

            #endregion

            #region Visibility

            context.Visibility.AddOrUpdate(VisibilitySeed.Seeds.ToArray());

            #endregion

            #region SeasonStatus

            context.SeasonStatus.AddOrUpdate(SeasonStatusSeed.Seeds.ToArray());

            #endregion

            #region EpisodeStatus

            context.EpisodeStatus.AddOrUpdate(EpisodeStatusSeed.Seeds.ToArray());

            #endregion

            #region PeermissionGroup

            context.PermissionGroup.AddOrUpdate(PermissionGroupSeed.Seeds.ToArray());

            #endregion

            #region PermissionType

            context.PermissionType.AddOrUpdate(PermissionTypeSeed.Seeds.ToArray());

            #endregion

            #region Permission

            context.Permission.AddOrUpdate(PermissionSeed.Seeds.ToArray());

            #endregion

            #region Profile

            context.Profile.AddOrUpdate(ProfileSeed.Seeds.ToArray());

            #endregion

            #region ProfilePermission

            context.ProfilePermission.AddOrUpdate(ProfilePermissionSeed.Seeds.ToArray());

            #endregion

            #region UserStatus

            context.UserStatus.AddOrUpdate(UserStatusSeed.Seeds.ToArray());

            #endregion

            #region Configuration

            context.ConfigurationSet.AddOrUpdate(ConfigurationSeed.Seeds.ToArray());

            #endregion

            #region TokenProviderType

            context.TokenProviderType.AddOrUpdate(TokenProviderTypeSeed.Seeds.ToArray());

            #endregion
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
