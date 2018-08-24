using SerieList.Domain.Entitites.Episode;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Episode
{
    public class EpisodeStatusSeed
    {
        public static EpisodeStatusModel InProgress { get { return new EpisodeStatusModel() { IdEpisodeStatus = 1, Description = "Em andamento", Excluded = false }; } }
        public static EpisodeStatusModel Canceled { get { return new EpisodeStatusModel() { IdEpisodeStatus = 2, Description = "Cancelado", Excluded = false }; } }
        public static EpisodeStatusModel Completed { get { return new EpisodeStatusModel() { IdEpisodeStatus = 3, Description = "Concluído", Excluded = false }; } }
        public static EpisodeStatusModel Waiting { get { return new EpisodeStatusModel() { IdEpisodeStatus = 4, Description = "Aguardando lançamento", Excluded = false }; } }

        public static List<EpisodeStatusModel> Seeds
        {
            get
            {
                return new List<EpisodeStatusModel>()
                {
                    InProgress,
                    Canceled,
                    Completed,
                    Waiting
                };
            }
        }
    }
}
