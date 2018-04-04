using GraphQL.API.Data;
using GraphQL.API.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.Mutations
{

    /// <example>
    /// This is an example JSON request for a mutation
    /// {
    ///   "query": "mutation ($human:HumanInput!){ createHuman(human: $human) { id name } }",
    ///   "variables": {
    ///     "human": {
    ///       "name": "Boba Fett"
    ///     }
    ///   }
    /// }
    /// </example>
    public class CategoryMutation : ObjectGraphType<object>
    {
        public CategoryMutation(CategoryRepository data)
        {
            Name = "Mutation";

            Field<CategoryType>(
                "createCategory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CategoryType>> { Name = "category" }
                ),
                resolve: context =>
                {
                    var human = context.GetArgument<Category>("category");
                    return data.AddHuman(human);
                });
        }
    }
}