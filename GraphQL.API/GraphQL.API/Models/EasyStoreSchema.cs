using GraphQL.Types;
using System;

namespace GraphQL.API.Models
{
    public class EasyStoreSchema : Schema
    {
        public EasyStoreSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (EasyStoreQuery)resolveType?.Invoke(typeof(EasyStoreQuery));
        }
    }
}