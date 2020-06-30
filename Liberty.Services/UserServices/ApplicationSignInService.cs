using Liberty.Core.Domain.Users;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Liberty.Services.UserServices
{
    public class ApplicationSignInService : SignInManager<User, int>
    {
        public ApplicationSignInService(ApplicationUserService userService, IAuthenticationManager authenticationManager) :
            base(userService, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserService)UserManager);
        }

        public static ApplicationSignInService Create(IdentityFactoryOptions<ApplicationSignInService> options, IOwinContext context)
        {
            return new ApplicationSignInService(context.GetUserManager<ApplicationUserService>(), context.Authentication);
        }

        public override string ConvertIdToString(int id)
        {
            return base.ConvertIdToString(id);
        }

        public override Task<bool> SendTwoFactorCodeAsync(string provider)
        {
            return base.SendTwoFactorCodeAsync(provider);
        }

        public override Task SignInAsync(User user, bool isPersistent, bool rememberBrowser)
        {
            return base.SignInAsync(user, isPersistent, rememberBrowser);
        }

        public override Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser)
        {
            return base.TwoFactorSignInAsync(provider, code, isPersistent, rememberBrowser);
        }

        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }

        public override int ConvertIdFromString(string id)
        {
            return base.ConvertIdFromString(id);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
