# Using GraphQL in .Net Core
Using graphQL for the API and create schemas and types to get the data.

# What is GraphQL ?

GraphQL is a data query language developed internally by Facebook in 2012 before being publicly released in 2015. It provides an alternative to REST and ad-hoc webservice architectures. It allows clients to define the structure of the data required, and exactly the same structure of the data is returned from the server. It is a strongly typed runtime which allows clients to dictate what data is needed. This avoids both the problems of over-fetching as well as under-fetching of data.

GraphQL is a query language for APIs and a runtime for fulfilling those queries with your existing data. GraphQL provides a complete and understandable description of the data in your API, gives clients the power to ask for exactly what they need and nothing more, makes it easier to evolve APIs over time, and enables powerful developer tools.

GraphQL queries always return predictable results. Apps using GraphQL are fast and stable because they control the data they get, not the server.

# Parallelism with REST
The core idea of REST is the resource. Each resource is identified by a URL, and you retrieve that resource by sending a GET request to that URL. You will likely get a JSON response, since that’s what most APIs are using these days. 

In REST the type, or shape, of the resource and the way you fetch that resource are coupled. GraphQL is quite different in this respect, because in GraphQL these two concepts are completely separate

# In a Nutshell
Create queries adn types with one post method for the API.

This is how the API in .net looks like:
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query };

            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

Thats it ! The rest of the things will come under the Types, Schema and Queries.

Refer to the code base on how to create types, schema and queries in .net using GraphQL
