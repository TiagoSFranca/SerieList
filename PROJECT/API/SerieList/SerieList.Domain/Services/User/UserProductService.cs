using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Services.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SerieList.Domain.Services.User
{
    public class UserProductService : ServiceBase<UserProductModel>, IUserProductService
    {
        private readonly IUserProductRepository _userProductRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        private UserProductServiceMessage userProductMessage;

        public UserProductService(IUserProductRepository userProductRepo, ITokenProviderRepository tokenProviderRepo,
            IAccessControlService accessControlService, IConfigurationRepository configurationRepo)
            : base(userProductRepo, tokenProviderRepo, configurationRepo)
        {
            _userProductRepo = userProductRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
            userProductMessage = new UserProductServiceMessage();
        }

        public PagingResultModel<UserProductModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idProductList,
            IEnumerable<int> idUserProductStatusList, bool? excluded, bool? associatedExcluded, PagingModel paging)
        {
            var query = _userProductRepo.Query();

            if (excluded != null)
                query = query.Where(p => p.Excluded == excluded);

            if (idUserList?.Count() > 0)
                query = query.Where(p => idUserList.Contains(p.IdUser));

            if (idProductList?.Count() > 0)
                query = query.Where(p => idProductList.Contains(p.IdProduct));

            if (idUserProductStatusList?.Count() > 0)
                query = query.Where(p => idUserProductStatusList.Contains(p.UserProductStatus.IdUserProductStatus));

            if (associatedExcluded != null)
            {
                var assocQuery = _userProductRepo.AssociationExcluded((bool)associatedExcluded);
                query = query.Where(e => assocQuery.Contains(e));
            }

            return Paginate(query, paging);
        }

        public void Add(UserProductModel obj, UserModel userCredentials)
        {
            userCredentials.IsGranted();
            obj.IdUser = userCredentials.IdUser;
            _userProductRepo.Add(obj);
        }

        public void Update(UserProductModel obj, UserModel userCredentials)
        {
            var userProduct = _userProductRepo.GetById(userCredentials.IdUser, obj.IdProduct, true);
            if (userProduct == null)
                throw new ServiceException(userProductMessage.NotFound);
            userProduct.ValidateExcluded();
            this.ValidateUser(userCredentials, obj);
            obj.IdUser = userProduct.IdUser;
            _userProductRepo.Update(obj);
        }

        public void Remove(UserProductModel obj, UserModel userCredentials)
        {
            this.ValidateUser(userCredentials, obj);
            _userProductRepo.Remove(obj);
        }

        private void ValidateUser(UserModel userCredentials, UserProductModel obj)
        {
            userCredentials.IsGranted();
            var userProduct = _userProductRepo.GetById(userCredentials.IdUser, obj.IdProduct, true);
            if (userProduct == null)
                throw new ServiceException(userProductMessage.NotFound);
            if (userProduct.IdUser != userCredentials.IdUser && !IsAdmin(userCredentials))
                throw new ServiceException(userProductMessage.UserInvalid);
        }

        public UserProductModel GetById(int idUser, int idProduct)
        {
            return _userProductRepo.GetById(idUser, idProduct);
        }
    }
}
