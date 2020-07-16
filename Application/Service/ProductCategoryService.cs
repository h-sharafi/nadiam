using Domain;
using Persistence;

namespace Application.Service
{
    public interface IProductCategoryService : IGenericRepository<ProductCategory>
    {

    }
    public class ProductCategoryService : GenericRepository<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(DataContext context) : base(context)
        {
        }
    }
}