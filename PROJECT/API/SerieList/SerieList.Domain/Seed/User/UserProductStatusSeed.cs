using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.User
{
    public class UserProductStatusSeed
    {
        public static UserProductStatusModel Watching { get { return new UserProductStatusModel() { IdUserProductStatus = 1, Description = "Assistindo", Excluded = false }; } }
        public static UserProductStatusModel ToWatch { get { return new UserProductStatusModel() { IdUserProductStatus = 2, Description = "Pretendo Assistir", Excluded = false }; } }
        public static UserProductStatusModel Watched { get { return new UserProductStatusModel() { IdUserProductStatus = 3, Description = "Já Assisti", Excluded = false }; } }
        public static UserProductStatusModel Quit { get { return new UserProductStatusModel() { IdUserProductStatus = 4, Description = "Desisti", Excluded = false }; } }
        public static UserProductStatusModel Paused { get { return new UserProductStatusModel() { IdUserProductStatus = 5, Description = "Parei um Tempo", Excluded = false }; } }

        public static List<UserProductStatusModel> Seeds
        {
            get
            {
                return new List<UserProductStatusModel>()
                {
                    Watching,
                    ToWatch,
                    Watched,
                    Quit,
                    Paused
                };
            }
        }
    }
}
