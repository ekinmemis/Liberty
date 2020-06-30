using Microsoft.AspNet.Identity.EntityFramework;

namespace Liberty.Core.Domain.Users
{
    public class UserRole : IdentityUserRole<int>
    {
        public override int RoleId { get => base.RoleId; set => base.RoleId = value; }
        public override int UserId { get => base.UserId; set => base.UserId = value; }
    }
}
