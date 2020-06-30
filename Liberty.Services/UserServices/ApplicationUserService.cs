using Liberty.Core.Domain.Users;
using Liberty.Data;
using Liberty.Services.MessageServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Liberty.Services.UserServices
{
    public class ApplicationUserService : UserManager<User, int>
    {
        public override IQueryable<User> Users => base.Users;
        public override bool SupportsQueryableUsers => base.SupportsQueryableUsers;
        public override bool SupportsUserClaim => base.SupportsUserClaim;
        public override bool SupportsUserEmail => base.SupportsUserEmail;
        public override bool SupportsUserLockout => base.SupportsUserLockout;
        public override bool SupportsUserLogin => base.SupportsUserLogin;
        public override bool SupportsUserPassword => base.SupportsUserPassword;
        public override bool SupportsUserPhoneNumber => base.SupportsUserPhoneNumber;
        public override bool SupportsUserRole => base.SupportsUserRole;
        public override bool SupportsUserSecurityStamp => base.SupportsUserSecurityStamp;
        public override bool SupportsUserTwoFactor => base.SupportsUserTwoFactor;

        public ApplicationUserService(IUserStore<User, int> store)
            : base(store)
        {
        }

        public static ApplicationUserService Create(IdentityFactoryOptions<ApplicationUserService> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserService(new UserStore<User, Role, int, UserLogin, UserRole, UserClaim>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<User, int>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<User, int>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public override Task<IdentityResult> UpdateAsync(User user)
        {
            return base.UpdateAsync(user);
        }

        public override Task<IdentityResult> AddLoginAsync(int userId, UserLoginInfo login)
        {
            return base.AddLoginAsync(userId, login);
        }

        public override Task<IdentityResult> AddPasswordAsync(int userId, string password)
        {
            return base.AddPasswordAsync(userId, password);
        }

        public override Task<IdentityResult> AddToRoleAsync(int userId, string role)
        {
            return base.AddToRoleAsync(userId, role);
        }

        public override Task<IdentityResult> AddToRolesAsync(int userId, params string[] roles)
        {
            return base.AddToRolesAsync(userId, roles);
        }

        public override Task<IdentityResult> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            return base.ChangePasswordAsync(userId, currentPassword, newPassword);
        }

        public override Task<IdentityResult> ChangePhoneNumberAsync(int userId, string phoneNumber, string token)
        {
            return base.ChangePhoneNumberAsync(userId, phoneNumber, token);
        }

        public override Task<bool> CheckPasswordAsync(User user, string password)
        {
            return base.CheckPasswordAsync(user, password);
        }

        public override Task<IdentityResult> ConfirmEmailAsync(int userId, string token)
        {
            return base.ConfirmEmailAsync(userId, token);
        }

        public override Task<IdentityResult> CreateAsync(User user)
        {
            return base.CreateAsync(user);
        }

        public override Task<IdentityResult> AddClaimAsync(int userId, Claim claim)
        {
            return base.AddClaimAsync(userId, claim);
        }

        public override Task<IdentityResult> CreateAsync(User user, string password)
        {
            return base.CreateAsync(user, password);
        }

        public override Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType)
        {
            return base.CreateIdentityAsync(user, authenticationType);
        }

        public override Task<IdentityResult> DeleteAsync(User user)
        {
            return base.DeleteAsync(user);
        }

        public override Task<User> FindAsync(string userName, string password)
        {
            return base.FindAsync(userName, password);
        }

        public override Task<User> FindAsync(UserLoginInfo login)
        {
            return base.FindAsync(login);
        }

        public override Task<User> FindByEmailAsync(string email)
        {
            return base.FindByEmailAsync(email);
        }

        public override Task<User> FindByIdAsync(int userId)
        {
            return base.FindByIdAsync(userId);
        }

        public override Task<User> FindByNameAsync(string userName)
        {
            return base.FindByNameAsync(userName);
        }

        public override Task<string> GenerateChangePhoneNumberTokenAsync(int userId, string phoneNumber)
        {
            return base.GenerateChangePhoneNumberTokenAsync(userId, phoneNumber);
        }

        public override Task<string> GenerateEmailConfirmationTokenAsync(int userId)
        {
            return base.GenerateEmailConfirmationTokenAsync(userId);
        }

        public override Task<string> GeneratePasswordResetTokenAsync(int userId)
        {
            return base.GeneratePasswordResetTokenAsync(userId);
        }

        public override Task<string> GenerateTwoFactorTokenAsync(int userId, string twoFactorProvider)
        {
            return base.GenerateTwoFactorTokenAsync(userId, twoFactorProvider);
        }

        public override Task<string> GenerateUserTokenAsync(string purpose, int userId)
        {
            return base.GenerateUserTokenAsync(purpose, userId);
        }

        public override Task<IdentityResult> AccessFailedAsync(int userId)
        {
            return base.AccessFailedAsync(userId);
        }

        public override Task<int> GetAccessFailedCountAsync(int userId)
        {
            return base.GetAccessFailedCountAsync(userId);
        }

        public override Task<IdentityResult> ResetAccessFailedCountAsync(int userId)
        {
            return base.ResetAccessFailedCountAsync(userId);
        }

        public override Task<IList<Claim>> GetClaimsAsync(int userId)
        {
            return base.GetClaimsAsync(userId);
        }

        public override Task<string> GetEmailAsync(int userId)
        {
            return base.GetEmailAsync(userId);
        }

        public override Task<bool> GetLockoutEnabledAsync(int userId)
        {
            return base.GetLockoutEnabledAsync(userId);
        }

        public override Task<DateTimeOffset> GetLockoutEndDateAsync(int userId)
        {
            return base.GetLockoutEndDateAsync(userId);
        }

        public override Task<IList<UserLoginInfo>> GetLoginsAsync(int userId)
        {
            return base.GetLoginsAsync(userId);
        }

        public override Task<string> GetPhoneNumberAsync(int userId)
        {
            return base.GetPhoneNumberAsync(userId);
        }

        public override Task<IList<string>> GetRolesAsync(int userId)
        {
            return base.GetRolesAsync(userId);
        }

        public override Task<string> GetSecurityStampAsync(int userId)
        {
            return base.GetSecurityStampAsync(userId);
        }

        public override Task<bool> GetTwoFactorEnabledAsync(int userId)
        {
            return base.GetTwoFactorEnabledAsync(userId);
        }

        public override Task<IList<string>> GetValidTwoFactorProvidersAsync(int userId)
        {
            return base.GetValidTwoFactorProvidersAsync(userId);
        }

        public override Task<bool> HasPasswordAsync(int userId)
        {
            return base.HasPasswordAsync(userId);
        }

        public override Task<bool> IsEmailConfirmedAsync(int userId)
        {
            return base.IsEmailConfirmedAsync(userId);
        }

        public override Task<bool> IsInRoleAsync(int userId, string role)
        {
            return base.IsInRoleAsync(userId, role);
        }

        public override Task<bool> IsLockedOutAsync(int userId)
        {
            return base.IsLockedOutAsync(userId);
        }

        public override Task<bool> IsPhoneNumberConfirmedAsync(int userId)
        {
            return base.IsPhoneNumberConfirmedAsync(userId);
        }

        public override Task<IdentityResult> NotifyTwoFactorTokenAsync(int userId, string twoFactorProvider, string token)
        {
            return base.NotifyTwoFactorTokenAsync(userId, twoFactorProvider, token);
        }

        public override void RegisterTwoFactorProvider(string twoFactorProvider, IUserTokenProvider<User, int> provider)
        {
            base.RegisterTwoFactorProvider(twoFactorProvider, provider);
        }

        public override Task<IdentityResult> RemoveClaimAsync(int userId, Claim claim)
        {
            return base.RemoveClaimAsync(userId, claim);
        }

        public override Task<IdentityResult> RemoveFromRoleAsync(int userId, string role)
        {
            return base.RemoveFromRoleAsync(userId, role);
        }

        public override Task<IdentityResult> RemoveFromRolesAsync(int userId, params string[] roles)
        {
            return base.RemoveFromRolesAsync(userId, roles);
        }

        public override Task<IdentityResult> RemoveLoginAsync(int userId, UserLoginInfo login)
        {
            return base.RemoveLoginAsync(userId, login);
        }

        public override Task<IdentityResult> RemovePasswordAsync(int userId)
        {
            return base.RemovePasswordAsync(userId);
        }

        public override Task<IdentityResult> ResetPasswordAsync(int userId, string token, string newPassword)
        {
            return base.ResetPasswordAsync(userId, token, newPassword);
        }

        public override Task SendEmailAsync(int userId, string subject, string body)
        {
            return base.SendEmailAsync(userId, subject, body);
        }

        public override Task SendSmsAsync(int userId, string message)
        {
            return base.SendSmsAsync(userId, message);
        }

        public override Task<IdentityResult> SetEmailAsync(int userId, string email)
        {
            return base.SetEmailAsync(userId, email);
        }

        public override Task<IdentityResult> SetLockoutEnabledAsync(int userId, bool enabled)
        {
            return base.SetLockoutEnabledAsync(userId, enabled);
        }

        public override Task<IdentityResult> SetLockoutEndDateAsync(int userId, DateTimeOffset lockoutEnd)
        {
            return base.SetLockoutEndDateAsync(userId, lockoutEnd);
        }

        public override Task<IdentityResult> SetPhoneNumberAsync(int userId, string phoneNumber)
        {
            return base.SetPhoneNumberAsync(userId, phoneNumber);
        }

        public override Task<IdentityResult> SetTwoFactorEnabledAsync(int userId, bool enabled)
        {
            return base.SetTwoFactorEnabledAsync(userId, enabled);
        }

        protected override Task<IdentityResult> UpdatePassword(IUserPasswordStore<User, int> passwordStore, User user, string newPassword)
        {
            return base.UpdatePassword(passwordStore, user, newPassword);
        }

        public override Task<IdentityResult> UpdateSecurityStampAsync(int userId)
        {
            return base.UpdateSecurityStampAsync(userId);
        }

        public override Task<bool> VerifyChangePhoneNumberTokenAsync(int userId, string token, string phoneNumber)
        {
            return base.VerifyChangePhoneNumberTokenAsync(userId, token, phoneNumber);
        }

        protected override Task<bool> VerifyPasswordAsync(IUserPasswordStore<User, int> store, User user, string password)
        {
            return base.VerifyPasswordAsync(store, user, password);
        }

        public override Task<bool> VerifyTwoFactorTokenAsync(int userId, string twoFactorProvider, string token)
        {
            return base.VerifyTwoFactorTokenAsync(userId, twoFactorProvider, token);
        }

        public override Task<bool> VerifyUserTokenAsync(int userId, string purpose, string token)
        {
            return base.VerifyUserTokenAsync(userId, purpose, token);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
