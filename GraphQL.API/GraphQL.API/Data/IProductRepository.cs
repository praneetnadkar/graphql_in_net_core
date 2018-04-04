using GraphQL.API.EF;
using GraphQL.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.API.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();

        Task<List<Product>> GetProductsWithByCategoryIdAsync(int categoryId);

        Task<Product> GetProductAsync(int id);
    }
}