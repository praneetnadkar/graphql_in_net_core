using System;
using System.Collections.Generic;

namespace GraphQL.API.EF
{
    public partial class Users
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
