using Domain;
using Persistence;

namespace Application.Service
{
    public interface IProductService : IGenericRepository<Product>
    {

    }
    public class ProductService : GenericRepository<Product>, IProductService
    {
        public ProductService(DataContext context) : base(context)
        {
        }
    }
}