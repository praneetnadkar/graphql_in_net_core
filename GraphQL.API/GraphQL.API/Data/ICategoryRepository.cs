using GraphQL.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.API.Data
{
    public interface ICategoryRepository
    {
        Task<List<Category>> CategoriesAsync();

        Task<Category> GetCategoryAsync(int id);
    }
}