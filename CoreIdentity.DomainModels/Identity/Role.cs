using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CoreIdentity.DomainModels.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role() : base()
        {

        }
        public Role(string roleName) : this()
        {
            Name = roleName;
        }

        public virtual ICollection<UserRole> Users { get; set; }
    }
}
