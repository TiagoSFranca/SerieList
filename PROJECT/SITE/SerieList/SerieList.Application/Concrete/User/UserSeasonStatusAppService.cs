using SerieList.Application.AppModels.User;
using SerieList.Application.Interfaces.User;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using SerieList.Application.Extensions.User;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.CommonEntities;
using SerieList.Application.CommonAppModels;

namespace SerieList.Application.Concrete.User
{
    public class UserSeasonStatusAppService : AppServiceBase<UserSeasonStatusModel>, IUserSeasonStatusAppService
    {
        private readonly IUserSeasonStatusService _userSeasonStatusService;
        private readonly ITokenProviderService _tokenProviderService;

        public UserSeasonStatusAppService(IUserSeasonStatusService userSeasonStatusService, ITokenProviderService tokenProviderService)
            : base(userSeasonStatusService, tokenProviderService)
        {
            _userSeasonStatusService = userSeasonStatusService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(UserSeasonStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userSeasonStatus = obj.MapperToDomain();
                _userSeasonStatusService.Add(userSeasonStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserSeasonStatusAppModel GetById(int id)
        {
            try
            {
                return _userSeasonStatusService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<UserSeasonStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _userSeasonStatusService.Query(idList, description, excluded, paging);
                return result.MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Remove(int id, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userSeasonStatus = _userSeasonStatusService.GetById(id);
                _userSeasonStatusService.Remove(userSeasonStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(UserSeasonStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userSeasonStatus = obj.MapperToDomain();
                _userSeasonStatusService.Update(userSeasonStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
