using Microsoft.AspNet.Identity.EntityFramework;

namespace Liberty.Core.Domain.Users
{
    public class UserClaim : IdentityUserClaim<int>
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string ClaimType { get => base.ClaimType; set => base.ClaimType = value; }
        public override string ClaimValue { get => base.ClaimValue; set => base.ClaimValue = value; }
        public override int UserId { get => base.UserId; set => base.UserId = value; }
    }
}
