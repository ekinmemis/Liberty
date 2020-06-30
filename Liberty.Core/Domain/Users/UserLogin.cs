using Microsoft.AspNet.Identity.EntityFramework;

namespace Liberty.Core.Domain.Users
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public override string LoginProvider { get => base.LoginProvider; set => base.LoginProvider = value; }
        public override string ProviderKey { get => base.ProviderKey; set => base.ProviderKey = value; }
        public override int UserId { get => base.UserId; set => base.UserId = value; }
    }
}
