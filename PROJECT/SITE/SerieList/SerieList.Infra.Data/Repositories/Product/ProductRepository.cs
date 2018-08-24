using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Repositories.Product;
using System.Data.Entity;
using System.Linq;

namespace SerieList.Infra.Data.Repositories.Product
{
    public partial class ProductRepository : RepositoryBase<ProductModel>, IProductRepository
    {
        public void Add(ProductModel obj)
        {
            _context.Product.Add(obj);
            _context.ProductProductCategory.AddRange(obj.Categories);
            _context.SaveChanges();
        }

        public void Update(ProductModel obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj.ProductInfo).State = EntityState.Modified;
            ManageCategories(obj);
            _context.SaveChanges();
        }

        private void ManageCategories(ProductModel obj)
        {
            DeleteAllCategories(obj);
            AddOrUpdateCategories(obj);
        }

        private void AddOrUpdateCategories(ProductModel obj)
        {
            foreach (var item in obj.Categories)
            {
                var categoryAny = _context.ProductProductCategory.Any(e => e.IdCategory == item.IdCategory && e.IdProduct == obj.IdProduct);
                if (categoryAny)
                    _context.Entry(item).State = EntityState.Modified;
                else
                    _context.ProductProductCategory.Add(item);
            }
        }

        private void DeleteAllCategories(ProductModel obj)
        {
            var categoryIdList = obj.Categories.Select(e => e.IdCategory).ToList();
            var categories = _context.ProductProductCategory.Where(
                e => e.IdProduct == obj.IdProduct &&
                !categoryIdList.Contains(e.IdCategory));
            _context.ProductProductCategory.RemoveRange(categories);
        }
    }
}
