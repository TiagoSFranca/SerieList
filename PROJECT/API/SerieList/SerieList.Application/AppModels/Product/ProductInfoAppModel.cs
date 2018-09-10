using System;

namespace SerieList.Application.AppModels.Product
{
    public class ProductInfoAppModel
    {
        public int IdProduct { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BeginAt { get; set; }
        public DateTime? EndAt { get; set; }
    }
}
