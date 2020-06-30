using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Liberty.Core.Domain.Users
{
    public class Role : IdentityRole<int, UserRole>
    {
        public override ICollection<UserRole> Users => base.Users;
    }
}
