using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentity.Models.Identity
{
    public class User : IdentityUser<int>
    {
        //public virtual ICollection<UserToken> UserTokens { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        //public virtual ICollection<UserLogin> Logins { get; set; }

        //public virtual ICollection<UserClaim> Claims { get; set; }
    }
}
