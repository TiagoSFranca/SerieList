using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.User
{
    public class UserStatusSeed
    {
        public static UserStatusModel Active { get { return new UserStatusModel() { IdUserStatus = 1, Description = "Ativo", Excluded = false }; } }
        public static UserStatusModel Inactive { get { return new UserStatusModel() { IdUserStatus = 2, Description = "Inativo", Excluded = false }; } }
        public static UserStatusModel Blocked { get { return new UserStatusModel() { IdUserStatus = 3, Description = "Bloqueado", Excluded = false }; } }
        public static UserStatusModel Suspended { get { return new UserStatusModel() { IdUserStatus = 4, Description = "Suspenso", Excluded = false }; } }

        public static List<UserStatusModel> Seeds
        {
            get
            {
                return new List<UserStatusModel>()
                {
                    Active,
                    Inactive,
                    Blocked,
                    Suspended
                };
            }
        }
    }
}
