using System;

namespace SerieList.Domain.Entitites.Product
{
    public partial class ProductInfoModel
    {
        public int IdProduct { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BeginAt { get; set; }
        public DateTime? EndAt { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}
