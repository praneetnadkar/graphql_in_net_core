using GraphQL.API.EF;
using System.Collections.Generic;

namespace GraphQL.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private List<Product> Products { get; set; }
    }
}