using SerieList.Application.AppModels.User;
using System;
using System.Collections.Generic;

namespace SerieList.Application.AppModels.Product
{
    public class ProductAppModel
    {
        public int IdProduct { get; set; }
        public int IdProductStatus { get; set; }
        public int IdProductType { get; set; }
        public int IdVisibility { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public ProductInfoAppModel ProductInfo { get; set; }
        public ProductStatusAppModel ProductStatus { get; set; }
        public ProductTypeAppModel ProductType { get; set; }
        public VisibilityAppModel Visibility { get; set; }
        public UserSimplifiedAppModel User { get; set; }

        public IEnumerable<ProductProductCategoryAppModel> Categories { get; set; }
    }
}
