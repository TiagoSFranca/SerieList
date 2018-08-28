﻿using AutoMapper;
using SerieList.Application.AppModels.Episode;
using SerieList.Application.AppModels.Product;
using SerieList.Application.AppModels.Profile;
using SerieList.Application.AppModels.Season;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Entitites.Season;

namespace SerieList.Application.Mapper
{
    public class PagingProfileApplication : Profile
    {
        public PagingProfileApplication()
        {
            CreateMap<PagingResultModel<EpisodeStatusModel>, PagingResultAppModel<EpisodeStatusAppModel>>();
            CreateMap<PagingResultModel<EpisodeModel>, PagingResultAppModel<EpisodeAppModel>>();

            CreateMap<PagingResultModel<ProductCategoryModel>, PagingResultAppModel<ProductCategoryAppModel>>();
            CreateMap<PagingResultModel<ProductModel>, PagingResultAppModel<ProductAppModel>>();
            CreateMap<PagingResultModel<ProductStatusModel>, PagingResultAppModel<ProductStatusAppModel>>();
            CreateMap<PagingResultModel<ProductTypeModel>, PagingResultAppModel<ProductTypeAppModel>>();
            CreateMap<PagingResultModel<VisibilityModel>, PagingResultAppModel<VisibilityAppModel>>();

            CreateMap<PagingResultModel<PermissionGroupModel>, PagingResultAppModel<PermissionGroupAppModel>>();
            CreateMap<PagingResultModel<PermissionModel>, PagingResultAppModel<PermissionAppModel>>();
            CreateMap<PagingResultModel<PermissionTypeModel>, PagingResultAppModel<PermissionTypeAppModel>>();
            CreateMap<PagingResultModel<ProfileModel>, PagingResultAppModel<ProfileAppModel>>();

            CreateMap<PagingResultModel<SeasonModel>, PagingResultAppModel<SeasonAppModel>>();
            CreateMap<PagingResultModel<SeasonStatusModel>, PagingResultAppModel<SeasonStatusAppModel>>();
        }
    }
}
