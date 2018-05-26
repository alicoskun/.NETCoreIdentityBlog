using CoreIdentity.Models.Identity;
using System.Collections.Generic;

namespace CoreIdentity.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public virtual ICollection<UserPost> UserPosts { get; set; }
    }
}
