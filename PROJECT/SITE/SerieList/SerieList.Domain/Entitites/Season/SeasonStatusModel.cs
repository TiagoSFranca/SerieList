using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Season
{
    public partial class SeasonStatusModel
    {
        public int IdSeasonStatus { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<SeasonModel> Seasons { get; set; }
    }
}
