using GraphQL.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            //_categories = GenFu.GenFu.ListOf<Category>();
            _categories = new List<Category>{
                new Category
                {
                    Id = 1,
                    Name = "Computers"
                },
                new Category
                {
                    Id = 2,
                    Name = "Mobile Phones"
                }
            };
        }

        public Task<List<Category>> CategoriesAsync()
        {
            return Task.FromResult(_categories);
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return Task.FromResult(_categories.FirstOrDefault(x => x.Id == id));
        }

        public Category AddHuman(Category category)
        {
            category.Id = 1234;
            _categories.Add(category);
            return category;
        }
    }
}