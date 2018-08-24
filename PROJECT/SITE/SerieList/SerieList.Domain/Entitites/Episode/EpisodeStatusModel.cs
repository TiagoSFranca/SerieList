using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Episode
{
    public partial class EpisodeStatusModel
    {
        public int IdEpisodeStatus { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<EpisodeModel> Episodes { get; set; }
    }
}
