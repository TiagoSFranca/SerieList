﻿using SerieList.Application.AppModels.Product;
using AutoMapper;
using SerieList.Presentation.Models.Post;
using SerieList.Application.CommonAppModels;
using SerieList.Extras.Util;

namespace SerieList.Presentation.Extensions
{
    internal static class ProductExtension
    {
        public static ProductAppModel MapperToAppModel(this ProductPostModel obj)
        {
            return Mapper.Map<ProductAppModel>(obj);
        }

        public static ProductCategoryAppModel MapperToAppModel(this ProductCategoryPostModel obj)
        {
            return Mapper.Map<ProductCategoryAppModel>(obj);
        }

        public static PagingResultSearchModel<ProductCategoryAppModel> MapperToView(this PagingResultAppModel<ProductCategoryAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<ProductCategoryAppModel>>(obj);
        }
    }
}