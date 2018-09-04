using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories.User;
using System.Collections.Generic;
using System.Linq;
using SerieList.Infra.Data.Data.Context;
using SerieList.Infra.Data.Repositories.Episode;
using System.Data.Entity;

namespace SerieList.Infra.Data.Repositories.User
{
    public class UserEpisodeRepository : RepositoryBase<UserEpisodeModel>, IUserEpisodeRepository
    {
        public UserEpisodeRepository(SerieListContext context)
            : base(context)
        {
        }

        public IEnumerable<UserEpisodeModel> AssociationExcluded(bool excluded)
        {
            return AssociationExcluded(excluded, _context);
        }

        public static IEnumerable<UserEpisodeModel> AssociationExcluded(bool excluded, SerieListContext context)
        {
            var query = context.UserEpisode.AsQueryable();
            var users = UserRepository.AssociationExcluded(excluded, context);
            var products = EpisodeRepository.AssociationExcluded(excluded, context);
            query = query.Where(UserEpisodeModel.AssociationExcludedExpression(excluded));
            query = query.Where(e => users.Contains(e.User));
            query = query.Where(e => products.Contains(e.Episode));

            return query;
        }

        public UserEpisodeModel GetById(int idUser, int idEpisode, bool detached = false)
        {
            var query = this.Query();
            var userEpisode = query.FirstOrDefault(e => e.IdUser == idUser && e.IdEpisode == idEpisode);

            if (userEpisode != null && detached)
                _context.Entry(userEpisode).State = EntityState.Detached;

            return userEpisode;
        }
    }
}
