using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API
{
    public class BooksQuery : ObjectGraphType
    {
        public BooksQuery(IBookRepository bookRepository)
        {
            Field<BookType>("book",
                            arguments: new QueryArguments(
                              new QueryArgument<StringGraphType>() { Name = "isbn" }),
                              resolve: context =>
                              {
                                  var id = context.GetArgument<string>("isbn");
                                  return bookRepository.BookByIsbn(id);
                              });

            Field<ListGraphType<BookType>>("books",
                                           resolve: context =>
                                           {
                                               return bookRepository.AllBooks();
                                           });
        }
    }
}
