using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Profile
{
    public class ProfilePermissionSeed
    {
        public static List<ProfilePermissionModel> AdminPermissions
        {
            get
            {
                return new List<ProfilePermissionModel>()
                {
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.Admin.IdPermission
                    },

                    #region Product

                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.ProductAdd.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.ProductUpdate.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.ProductRemove.IdPermission
                    },

                    #endregion
                    
                    #region Season
                    
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.SeasonAdd.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.SeasonUpdate.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.SeasonRemove.IdPermission
                    },

                    #endregion

                    #region Episode

                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.EpisodeAdd.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.EpisodeUpdate.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.EpisodeRemove.IdPermission
                    },

                    #endregion
                    
                    #region ProductCategory
                    
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.ProductCategoryAdd.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.ProductCategoryUpdate.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.ProductCategoryRemove.IdPermission
                    },

                    #endregion

                    #region Profile
                    
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.ProfileAdd.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.ProfileUpdate.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.ProfileRemove.IdPermission
                    },

                    #endregion
                    
                    #region User
                    
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.UserUpdate.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.Admin.IdProfile,
                        IdPermission = PermissionSeed.UserRemove.IdPermission
                    },

                    #endregion
                };
            }
        }

        public static List<ProfilePermissionModel> CommomUserPermissions
        {
            get
            {
                return new List<ProfilePermissionModel>()
                {
                    #region Product
                    
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.CommomUser.IdProfile,
                        IdPermission = PermissionSeed.ProductAdd.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.CommomUser.IdProfile,
                        IdPermission = PermissionSeed.ProductUpdate.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.CommomUser.IdProfile,
                        IdPermission = PermissionSeed.ProductRemove.IdPermission
                    },

                    #endregion
                    
                    #region Season
                    
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.CommomUser.IdProfile,
                        IdPermission = PermissionSeed.SeasonAdd.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.CommomUser.IdProfile,
                        IdPermission = PermissionSeed.SeasonUpdate.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.CommomUser.IdProfile,
                        IdPermission = PermissionSeed.SeasonRemove.IdPermission
                    },

                    #endregion

                    #region Episode
                    
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.CommomUser.IdProfile,
                        IdPermission = PermissionSeed.EpisodeAdd.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.CommomUser.IdProfile,
                        IdPermission = PermissionSeed.EpisodeUpdate.IdPermission
                    },
                    new ProfilePermissionModel()
                    {
                        IdProfile = ProfileSeed.CommomUser.IdProfile,
                        IdPermission = PermissionSeed.EpisodeRemove.IdPermission
                    },

                    #endregion
                    
                };
            }
        }

        public static List<ProfilePermissionModel> Seeds
        {
            get
            {
                var list = new List<ProfilePermissionModel>();
                list.AddRange(AdminPermissions);
                list.AddRange(CommomUserPermissions);
                return list;
            }
        }
    }
}
