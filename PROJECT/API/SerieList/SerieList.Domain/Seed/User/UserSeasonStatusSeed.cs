using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.User
{
    public class UserSeasonStatusSeed
    {
        public static UserSeasonStatusModel Watching { get { return new UserSeasonStatusModel() { IdUserSeasonStatus = 1, Description = "Assistindo", Excluded = false }; } }
        public static UserSeasonStatusModel ToWatch { get { return new UserSeasonStatusModel() { IdUserSeasonStatus = 2, Description = "Pretendo Assistir", Excluded = false }; } }
        public static UserSeasonStatusModel Watched { get { return new UserSeasonStatusModel() { IdUserSeasonStatus = 3, Description = "Já Assisti", Excluded = false }; } }
        public static UserSeasonStatusModel Quit { get { return new UserSeasonStatusModel() { IdUserSeasonStatus = 4, Description = "Desisti", Excluded = false }; } }
        public static UserSeasonStatusModel Paused { get { return new UserSeasonStatusModel() { IdUserSeasonStatus = 5, Description = "Parei um Tempo", Excluded = false }; } }

        public static List<UserSeasonStatusModel> Seeds
        {
            get
            {
                return new List<UserSeasonStatusModel>()
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
