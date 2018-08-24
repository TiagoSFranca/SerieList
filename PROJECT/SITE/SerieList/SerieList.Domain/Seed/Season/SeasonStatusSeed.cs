using SerieList.Domain.Entitites.Season;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Season.Season
{
    public class SeasonStatusSeed
    {
        public static SeasonStatusModel InProgress { get { return new SeasonStatusModel() { IdSeasonStatus = 1, Description = "Em andamento", Excluded = false }; } }
        public static SeasonStatusModel Canceled { get { return new SeasonStatusModel() { IdSeasonStatus = 2, Description = "Cancelado", Excluded = false }; } }
        public static SeasonStatusModel Completed { get { return new SeasonStatusModel() { IdSeasonStatus = 3, Description = "Concluído", Excluded = false }; } }
        public static SeasonStatusModel Waiting { get { return new SeasonStatusModel() { IdSeasonStatus = 4, Description = "Aguardando lançamento", Excluded = false }; } }

        public static List<SeasonStatusModel> Seeds
        {
            get
            {
                return new List<SeasonStatusModel>()
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
