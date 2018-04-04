using GraphQL.API.Data;
using GraphQL.Types;
using System.Linq;

namespace GraphQL.API.Models
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(x => x.Id).Description("Category id.");
            Field(x => x.Name, true).Description("Category name.");

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetProductsWithByCategoryIdAsync(context.Source.Id).Result.ToList()
            );
        }
    }
}