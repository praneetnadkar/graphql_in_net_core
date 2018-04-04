using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API
{
    public class GraphQlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IBookRepository _bookRepository;

        public GraphQlMiddleware(RequestDelegate next, IBookRepository bookRepository)
        {
            _next = next;
            _bookRepository = bookRepository;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var sent = false;
            if (httpContext.Request.Path.StartsWithSegments("/graph"))
            {
                using (var sr = new StreamReader(httpContext.Request.Body))
                {
                    var query = await sr.ReadToEndAsync();
                    if (!String.IsNullOrWhiteSpace(query))
                    {
                        var schema = new Schema { Query = new BooksQuery(_bookRepository) };                       
                        var graphqlRequest = JsonConvert.DeserializeObject<GraphQLRequest>(query);
                       
                        var result = await new DocumentExecuter()
                            .ExecuteAsync(options =>
                            {
                                options.Schema = schema;
                                options.Query = query;
                            }).ConfigureAwait(false);

                        //return await new DocumentExecuter().ExecuteAsync(schema, null, graphqlRequest.Query, graphqlRequest.OperationName, _inputs).ConfigureAwait(true);

                        CheckForErrors(result);

                        await WriteResult(httpContext, result);

                        sent = true;
                    }
                }
            }
            if (!sent)
            {
                await _next(httpContext);
            }
        }

        private async Task WriteResult(HttpContext httpContext, ExecutionResult result)
        {
            var json = new DocumentWriter(indent: true).Write(result);

            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }

        private void CheckForErrors(ExecutionResult result)
        {
            if (result.Errors?.Count > 0)
            {
                var errors = new List<Exception>();
                foreach (var error in result.Errors)
                {
                    var ex = new Exception(error.Message);
                    if (error.InnerException != null)
                    {
                        ex = new Exception(error.Message, error.InnerException);
                    }
                    errors.Add(ex);
                }
                throw new AggregateException(errors);
            }
        }
    }


public static class GraphQlMiddlewareExtensions
    {
        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GraphQlMiddleware>();
        }
    }

    internal sealed class GraphQLRequest
    {
        public string OperationName { get; set; }

        public string Query { get; set; }

        public Dictionary<string, string> Variables { get; set; }
    }
}
