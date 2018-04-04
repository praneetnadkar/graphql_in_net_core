using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API
{
    public class PublisherType : ObjectGraphType<Publisher>
    {
        public PublisherType()
        {
            Field(x => x.Id).Description("The id of the publisher.");
            Field(x => x.Name).Description("The name of the publisher.");
            Field<ListGraphType<BookType>>("books",
                resolve: context => new Book[] { });
            Field<ListGraphType<AuthorType>>("authors",
                resolve: context => new Author[] { });
        }
    }
}
