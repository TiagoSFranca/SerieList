using SerieList.Domain.Entitites.Product;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Product
{
    public class ProductTypeSeed
    {
        public static ProductTypeModel Serie { get { return new ProductTypeModel() { IdProductType = 1, Description = "Série", Excluded = false }; } }
        public static ProductTypeModel Movie { get { return new ProductTypeModel() { IdProductType = 2, Description = "Filme", Excluded = false }; } }
        public static ProductTypeModel Anime { get { return new ProductTypeModel() { IdProductType = 3, Description = "Anime", Excluded = false }; } }

        public static List<ProductTypeModel> Seeds
        {
            get
            {
                return new List<ProductTypeModel>()
                {
                    Serie,
                    Movie,
                    Anime
                };
            }
        }
    }
}
