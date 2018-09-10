using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.User
{
    public class UserEpisodeStatusSeed
    {
        public static UserEpisodeStatusModel Watching { get { return new UserEpisodeStatusModel() { IdUserEpisodeStatus = 1, Description = "Assistindo", Excluded = false }; } }
        public static UserEpisodeStatusModel ToWatch { get { return new UserEpisodeStatusModel() { IdUserEpisodeStatus = 2, Description = "Pretendo Assistir", Excluded = false }; } }
        public static UserEpisodeStatusModel Watched { get { return new UserEpisodeStatusModel() { IdUserEpisodeStatus = 3, Description = "Já Assisti", Excluded = false }; } }
        public static UserEpisodeStatusModel Quit { get { return new UserEpisodeStatusModel() { IdUserEpisodeStatus = 4, Description = "Desisti", Excluded = false }; } }
        public static UserEpisodeStatusModel Paused { get { return new UserEpisodeStatusModel() { IdUserEpisodeStatus = 5, Description = "Parei um Tempo", Excluded = false }; } }

        public static List<UserEpisodeStatusModel> Seeds
        {
            get
            {
                return new List<UserEpisodeStatusModel>()
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
