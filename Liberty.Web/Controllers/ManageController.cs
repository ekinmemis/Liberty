using Liberty.Web.Models.ManageViewModels;
using Liberty.Core.Domain.Users;
using Liberty.Services.UserServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Liberty.Web.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationUserService _userService;
        public ApplicationUserService UserService
        {
            get => _userService ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserService>();
            private set => _userService = value;
        }

        public ManageController()
        {
        }

        public ManageController(ApplicationUserService userService)
        {
            UserService = userService;
        }

        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two factor provider has been set."
                : message == ManageMessageId.Error ? "An error has oLibertyurred."
                : message == ManageMessageId.AddPhoneSuccess ? "The phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var userId = User.Identity.GetUserId<int>();

            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserService.GetPhoneNumberAsync(userId),
                TwoFactor = await UserService.GetTwoFactorEnabledAsync(userId),
                Logins = await UserService.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId.ToString())
            };

            return View(model);
        }

        public ActionResult RemoveLogin()
        {
            var linkedAccounts = UserService.GetLogins(User.Identity.GetUserId<int>());

            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return View(linkedAccounts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var userId = User.Identity.GetUserId<int>();
            var result = await UserService.RemoveLoginAsync(userId, new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserService.FindByIdAsync(userId);
                if (user != null)
                    await SignInAsync(user, isPersistent: false);

                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
                message = ManageMessageId.Error;

            return RedirectToAction("ManageLogins", new { Message = message });
        }

        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Generate the token and send it
            var code = await UserService.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId<int>(), model.Number);

            if (UserService.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };

                await UserService.SmsService.SendAsync(message);
            }

            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RememberBrowser()
        {
            var rememberBrowserIdentity = AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(User.Identity.GetUserId().ToString());

            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, rememberBrowserIdentity);

            return RedirectToAction("Index", "Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetBrowser()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            return RedirectToAction("Index", "Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTFA()
        {
            var userId = User.Identity.GetUserId<int>();

            await UserService.SetTwoFactorEnabledAsync(userId, true);

            var user = await UserService.FindByIdAsync(userId);

            if (user != null)
                await SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", "Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTFA()
        {
            var userId = User.Identity.GetUserId<int>();

            await UserService.SetTwoFactorEnabledAsync(userId, false);

            var user = await UserService.FindByIdAsync(userId);

            if (user != null)
                await SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", "Manage");
        }

        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            // This code allows you exercise the flow without actually sending codes
            // For production use please register a SMS provider in IdentityConfig and generate a code here.
            var code = await UserService.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId<int>(), phoneNumber);
            ViewBag.Status = "For DEMO purposes only, the current code is " + code;
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = User.Identity.GetUserId<int>();
            var result = await UserService.ChangePhoneNumberAsync(userId, model.PhoneNumber, model.Code);

            if (result.Succeeded)
            {
                var user = await UserService.FindByIdAsync(userId);
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Failed to verify phone");
            return View(model);
        }

        public async Task<ActionResult> RemovePhoneNumber()
        {
            var userId = User.Identity.GetUserId<int>();
            var result = await UserService.SetPhoneNumberAsync(userId, null);

            if (!result.Succeeded)
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });

            var user = await UserService.FindByIdAsync(userId);

            if (user != null)
                await SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = User.Identity.GetUserId<int>();
            var result = await UserService.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                var user = await UserService.FindByIdAsync(userId);

                if (user != null)
                    await SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }

            AddErrors(result);
            return View(model);
        }

        public ActionResult SetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId<int>();
                var result = await UserService.AddPasswordAsync(userId, model.NewPassword);

                if (result.Succeeded)
                {
                    var user = await UserService.FindByIdAsync(userId);

                    if (user != null)
                        await SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has oLibertyurred."
                : "";
            var userId = User.Identity.GetUserId<int>();
            var user = await UserService.FindByIdAsync(userId);
            if (user == null)
                return View("Error");

            var userLogins = await UserService.GetLoginsAsync(userId);
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();

            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;

            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId().ToString());
        }

        public async Task<ActionResult> LinkLoginCallback()
        {
            var userId = User.Identity.GetUserId<int>();
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, userId.ToString());

            if (loginInfo == null)
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });

            var result = await UserService.AddLoginAsync(userId, loginInfo.Login);

            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get => HttpContext.GetOwinContext().Authentication;

        }

        private async Task SignInAsync(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserService));
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error);
        }

        private bool HasPassword()
        {
            var user = UserService.FindById(User.Identity.GetUserId<int>());

            if (user != null)
                return user.PasswordHash != null;

            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserService.FindById(User.Identity.GetUserId<int>());

            if (user != null)
                return user.PhoneNumber != null;

            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
    }
}