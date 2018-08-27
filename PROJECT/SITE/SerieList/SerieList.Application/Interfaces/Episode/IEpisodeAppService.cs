﻿using SerieList.Application.AppModels.Episode;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Episode
{
    public interface IEpisodeAppService : IAppServiceBase<EpisodeAppModel>
    {
        PagingResultAppModel<EpisodeAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductList,
            IEnumerable<int> idEpisodeStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idSeasonList,
            IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage);
    }
}
