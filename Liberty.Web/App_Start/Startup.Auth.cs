using Liberty.Core.Domain.Users;
using Liberty.Data;
using Liberty.Services.UserServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace Liberty.Admin
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserService>(ApplicationUserService.Create);
            app.CreatePerOwinContext<ApplicationRoleService>(ApplicationRoleService.Create);
            app.CreatePerOwinContext<ApplicationSignInService>(ApplicationSignInService.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserService, User, int>(
                    validateInterval: TimeSpan.FromMinutes(30),
                     regenerateIdentityCallback: (manager, user) =>
                    user.GenerateUserIdentityAsync(manager), getUserIdCallback: (id) => (int.Parse(id.GetUserId())))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}