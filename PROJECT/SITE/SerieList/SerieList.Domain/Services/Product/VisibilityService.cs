﻿using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Repositories.Product;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.CommonEntities;

namespace SerieList.Domain.Services.Product
{
    public class VisibilityService : ServiceBase<VisibilityModel>, IVisibilityService
    {
        private readonly IVisibilityRepository _visibilityRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public VisibilityService(IVisibilityRepository visibilityRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService, IConfigurationRepository configurationRepo)
            : base(visibilityRepo, tokenProviderRepo, configurationRepo)
        {
            _visibilityRepo = visibilityRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public PagingResultModel<VisibilityModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging)
        {
            var query = _visibilityRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdVisibility));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            query = query.OrderBy(e => e.Description);

            return Paginate(query, paging);
        }

        public void Remove(VisibilityModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _visibilityRepo.Remove(obj);
        }
    }
}
