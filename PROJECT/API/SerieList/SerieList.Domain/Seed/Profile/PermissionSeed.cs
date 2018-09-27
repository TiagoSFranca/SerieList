using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Profile
{
    public class PermissionSeed
    {
        #region Product

        public static List<PermissionModel> ProductPermissions
        {
            get
            {
                return new List<PermissionModel>()
                {
                    ProductAdd,
                    ProductUpdate,
                    ProductRemove,
                };
            }
        }

        public static PermissionModel ProductAdd
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 3,
                    IdPermissionGroup = PermissionGroupSeed.Product.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Add.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel ProductUpdate
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 4,
                    IdPermissionGroup = PermissionGroupSeed.Product.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Update.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel ProductRemove
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 5,
                    IdPermissionGroup = PermissionGroupSeed.Product.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Remove.IdPermissionType,
                    Excluded = false
                };
            }
        }

        #endregion

        #region Season

        public static List<PermissionModel> SeasonPermissions
        {
            get
            {
                return new List<PermissionModel>()
                {
                    SeasonAdd,
                    SeasonUpdate,
                    SeasonRemove,
                };
            }
        }

        public static PermissionModel SeasonAdd
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 13,
                    IdPermissionGroup = PermissionGroupSeed.Season.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Add.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel SeasonUpdate
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 14,
                    IdPermissionGroup = PermissionGroupSeed.Season.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Update.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel SeasonRemove
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 15,
                    IdPermissionGroup = PermissionGroupSeed.Season.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Remove.IdPermissionType,
                    Excluded = false
                };
            }
        }

        #endregion

        #region Episode

        public static List<PermissionModel> EpisodePermissions
        {
            get
            {
                return new List<PermissionModel>()
                {
                    EpisodeAdd,
                    EpisodeUpdate,
                    EpisodeRemove,
                };
            }
        }

        public static PermissionModel EpisodeAdd
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 23,
                    IdPermissionGroup = PermissionGroupSeed.Episode.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Add.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel EpisodeUpdate
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 24,
                    IdPermissionGroup = PermissionGroupSeed.Episode.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Update.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel EpisodeRemove
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 25,
                    IdPermissionGroup = PermissionGroupSeed.Episode.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Remove.IdPermissionType,
                    Excluded = false
                };
            }
        }

        #endregion

        #region ProductCategory

        public static List<PermissionModel> ProductCategoryPermissions
        {
            get
            {
                return new List<PermissionModel>()
                {
                    ProductCategoryAdd,
                    ProductCategoryUpdate,
                    ProductCategoryRemove,
                };
            }
        }

        public static PermissionModel ProductCategoryAdd
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 33,
                    IdPermissionGroup = PermissionGroupSeed.ProductCategory.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Add.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel ProductCategoryUpdate
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 34,
                    IdPermissionGroup = PermissionGroupSeed.ProductCategory.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Update.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel ProductCategoryRemove
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 35,
                    IdPermissionGroup = PermissionGroupSeed.ProductCategory.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Remove.IdPermissionType,
                    Excluded = false
                };
            }
        }

        #endregion

        #region Profile

        public static List<PermissionModel> ProfilePermissions
        {
            get
            {
                return new List<PermissionModel>()
                {
                    ProfileAdd,
                    ProfileUpdate,
                    ProfileRemove,
                };
            }
        }

        public static PermissionModel ProfileAdd
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 43,
                    IdPermissionGroup = PermissionGroupSeed.Profile.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Add.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel ProfileUpdate
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 44,
                    IdPermissionGroup = PermissionGroupSeed.Profile.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Update.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel ProfileRemove
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 45,
                    IdPermissionGroup = PermissionGroupSeed.Profile.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Remove.IdPermissionType,
                    Excluded = false
                };
            }
        }

        #endregion

        #region User

        public static List<PermissionModel> UserPermissions
        {
            get
            {
                return new List<PermissionModel>()
                {
                    UserUpdate,
                    UserRemove,
                };
            }
        }

        public static PermissionModel UserUpdate
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 54,
                    IdPermissionGroup = PermissionGroupSeed.User.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Update.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel UserRemove
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 55,
                    IdPermissionGroup = PermissionGroupSeed.User.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Remove.IdPermissionType,
                    Excluded = false
                };
            }
        }

        #endregion


        public static PermissionModel Admin
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 666,
                    IdPermissionGroup = PermissionGroupSeed.Admin.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Admin.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static PermissionModel UseAPI
        {
            get
            {
                return new PermissionModel()
                {
                    IdPermission = 333,
                    IdPermissionGroup = PermissionGroupSeed.Admin.IdPermissionGroup,
                    IdPermissionType = PermissionTypeSeed.Admin.IdPermissionType,
                    Excluded = false
                };
            }
        }

        public static List<PermissionModel> Seeds
        {
            get
            {
                var list = new List<PermissionModel>();
                list.AddRange(ProductPermissions);
                list.AddRange(SeasonPermissions);
                list.AddRange(EpisodePermissions);
                list.AddRange(ProductCategoryPermissions);
                list.AddRange(ProfilePermissions);
                list.AddRange(UserPermissions);
                list.Add(Admin);
                list.Add(UseAPI);
                return list;
            }
        }
    }
}
