using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Entitites.Season;
using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Product
{
    public partial class VisibilityModel
    {
        public int IdVisibility { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
        public virtual ICollection<SeasonModel> Seasons { get; set; }
        public virtual ICollection<EpisodeModel> Episodes { get; set; }
    }
}
