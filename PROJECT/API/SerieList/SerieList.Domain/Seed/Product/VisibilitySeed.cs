using SerieList.Domain.Entitites.Product;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Product
{
    public class VisibilitySeed
    {
        public static VisibilityModel Individual { get { return new VisibilityModel() { IdVisibility = 1, Description = "Individual", Excluded = false }; } }
        public static VisibilityModel All { get { return new VisibilityModel() { IdVisibility = 2, Description = "Todos", Excluded = false }; } }

        public static List<VisibilityModel> Seeds
        {
            get
            {
                return new List<VisibilityModel>()
                {
                    Individual,
                    All
                };
            }
        }
    }
}
