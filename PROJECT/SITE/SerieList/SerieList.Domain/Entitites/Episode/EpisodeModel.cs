using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces;
using System;

namespace SerieList.Domain.Entitites.Episode
{
    public partial class EpisodeModel : IAssociation<EpisodeModel>
    {
        public int IdEpisode { get; set; }
        public int IdVisibility { get; set; }
        public int IdEpisodeStatus { get; set; }
        public int IdProduct { get; set; }
        public int IdUser { get; set; }
        public int? IdSeason { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual VisibilityModel Visibility { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual EpisodeStatusModel EpisodeStatus { get; set; }
        public virtual UserModel User { get; set; }
        public virtual SeasonModel Season { get; set; }

        public virtual EpisodeModel AssociationExcluded(bool excluded)
        {
            if (Visibility.Excluded == excluded
                && EpisodeStatus.Excluded == excluded
                && Product.AssociationExcluded(excluded) != null && User.AssociationExcluded(excluded) != null)
                if (Season != null)
                {
                    if (Season.Excluded == excluded && Season.AssociationExcluded(excluded) != null)
                        return this;
                }
                else return this;
            return null;
        }
    }
}
