using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Profile
{
    public class PermissionGroupSeed
    {
        public static PermissionGroupModel Product { get { return new PermissionGroupModel() { IdPermissionGroup = 1, Description = "Produto", Excluded = false }; } }
        public static PermissionGroupModel Season { get { return new PermissionGroupModel() { IdPermissionGroup = 2, Description = "Temporada", Excluded = false }; } }
        public static PermissionGroupModel Episode { get { return new PermissionGroupModel() { IdPermissionGroup = 3, Description = "Episódio", Excluded = false }; } }
        public static PermissionGroupModel ProductCategory { get { return new PermissionGroupModel() { IdPermissionGroup = 4, Description = "Categoria", Excluded = false }; } }
        public static PermissionGroupModel Profile { get { return new PermissionGroupModel() { IdPermissionGroup = 5, Description = "Perfil", Excluded = false }; } }
        public static PermissionGroupModel User { get { return new PermissionGroupModel() { IdPermissionGroup = 6, Description = "Usuário", Excluded = false }; } }
        public static PermissionGroupModel Admin { get { return new PermissionGroupModel() { IdPermissionGroup = 7, Description = "Administrador", Excluded = false }; } }

        public static List<PermissionGroupModel> Seeds
        {
            get
            {
                return new List<PermissionGroupModel>()
                {
                    Product,
                    Season,
                    Episode,
                    ProductCategory,
                    Profile,
                    User,
                    Admin
                };
            }
        }
    }
}
