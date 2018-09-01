﻿using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Product
{
    public partial class ProductModel
    {
        public int IdProduct { get; set; }
        public int IdProductStatus { get; set; }
        public int IdProductType { get; set; }
        public int IdVisibility { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual ProductInfoModel ProductInfo { get; set; }
        public virtual ProductStatusModel ProductStatus { get; set; }
        public virtual ProductTypeModel ProductType { get; set; }
        public virtual VisibilityModel Visibility { get; set; }
        public virtual UserModel User { get; set; }

        public virtual ICollection<ProductProductCategoryModel> Categories { get; set; }
        public virtual ICollection<SeasonModel> Seasons { get; set; }
        public virtual ICollection<EpisodeModel> Episodes { get; set; }

    }
}
