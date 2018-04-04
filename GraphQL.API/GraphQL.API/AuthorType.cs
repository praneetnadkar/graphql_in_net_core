﻿using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(x => x.Id).Description("The Id of the person.");
            Field(x => x.Name).Description("The name of the person.");
            Field(x => x.Birthdate).Description("The birthdate of the person.");
            Field<ListGraphType<BookType>>("books",
                resolve: context => new Book[] { });
            Field<ListGraphType<PublisherType>>("publishers",
                resolve: context => new Publisher[] { });

        }
    }
}
