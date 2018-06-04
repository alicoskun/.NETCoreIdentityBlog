using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CoreIdentity.DomainModels.Identity
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<UserPost> UserPosts { get; set; }

        //public virtual ICollection<UserToken> UserTokens { get; set; }

        //public virtual ICollection<UserRole> Roles { get; set; }

        //public virtual ICollection<UserLogin> Logins { get; set; }

        //public virtual ICollection<UserClaim> Claims { get; set; }
    }
}
