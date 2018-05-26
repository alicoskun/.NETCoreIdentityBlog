using System.Collections.Generic;

namespace CoreIdentity.Models
{
    public class Blog : BaseEntity
    {
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}
