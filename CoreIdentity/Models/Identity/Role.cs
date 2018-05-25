using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentity.Models.Identity
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
        //public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}
