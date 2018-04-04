using System;
using System.Collections.Generic;

namespace GraphQL.API.EF
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
