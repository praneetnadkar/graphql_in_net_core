using System;
using System.Collections.Generic;

namespace GraphQL.API.EF
{
    public partial class Claims
    {
        public int Id { get; set; }
        public int? UserSubjectId { get; set; }
        public string RepoType { get; set; }
        public string Url { get; set; }
    }
}
