using SerieList.Domain.Entitites.Product;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Product
{
    public class ProductStatusSeed
    {
        public static ProductStatusModel InProgress { get { return new ProductStatusModel() { IdProductStatus = 1, Description = "Em andamento", Excluded = false }; } }
        public static ProductStatusModel Canceled { get { return new ProductStatusModel() { IdProductStatus = 2, Description = "Cancelado", Excluded = false }; } }
        public static ProductStatusModel Completed { get { return new ProductStatusModel() { IdProductStatus = 3, Description = "Concluído", Excluded = false }; } }
        public static ProductStatusModel Waiting { get { return new ProductStatusModel() { IdProductStatus = 4, Description = "Aguardando lançamento", Excluded = false }; } }

        public static List<ProductStatusModel> Seeds
        {
            get
            {
                return new List<ProductStatusModel>()
                {
                    InProgress,
                    Canceled,
                    Completed,
                    Waiting
                };
            }
        }
    }
}
