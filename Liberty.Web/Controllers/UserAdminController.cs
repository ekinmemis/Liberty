using Liberty.Web.Models.AccountViewModels;
using Liberty.Web.Models.AdminViewModels;
using Liberty.Core.Domain.Users;
using Liberty.Services.UserServices;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Liberty.Web.Controllers
{
    [Authorize()]
    public class UsersAdminController : Controller
    {
        private ApplicationUserService _userService;
        public ApplicationUserService UserService
        {
            get => _userService ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserService>();
            private set => _userService = value;
        }

        private ApplicationRoleService _roleService;
        public ApplicationRoleService RoleService
        {
            get => _roleService ?? HttpContext.GetOwinContext().Get<ApplicationRoleService>();
            private set => _roleService = value;
        }

        public UsersAdminController()
        {
        }
        public UsersAdminController(ApplicationUserService userService, ApplicationRoleService roleService)
        {
            UserService = userService;
            RoleService = roleService;
        }

        public async Task<ActionResult> Index()
        {
            return View(await UserService.Users.ToListAsync());
        }

        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = await UserService.FindByIdAsync(id);

            ViewBag.RoleNames = await UserService.GetRolesAsync(user.Id);

            return View(user);
        }

        public async Task<ActionResult> Create()
        {
            //Get the list of Roles
            ViewBag.RoleId = new SelectList(await RoleService.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = userViewModel.Email, Email = userViewModel.Email };
                var adminresult = await UserService.CreateAsync(user, userViewModel.Password);

                //Add User to the selected Roles 
                if (adminresult.Succeeded)
                    if (selectedRoles != null)
                    {
                        var result = await UserService.AddToRolesAsync(user.Id, selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            ViewBag.RoleId = new SelectList(await RoleService.Roles.ToListAsync(), "Name", "Name");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", adminresult.Errors.First());
                        ViewBag.RoleId = new SelectList(RoleService.Roles, "Name", "Name");
                        return View();
                    }

                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(RoleService.Roles, "Name", "Name");
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = await UserService.FindByIdAsync(id);

            if (user == null)
                return HttpNotFound();

            var userRoles = await UserService.GetRolesAsync(user.Id);

            return View(new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                RolesList = RoleService.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Email,Id")] EditUserViewModel editUser, params string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await UserService.FindByIdAsync(editUser.Id);

                if (user == null)
                    return HttpNotFound();

                user.UserName = editUser.Email;
                user.Email = editUser.Email;

                var userRoles = await UserService.GetRolesAsync(user.Id);

                selectedRole = selectedRole ?? new string[] { };

                var result = await UserService.AddToRolesAsync(user.Id, selectedRole.Except(userRoles).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }

                result = await UserService.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRole).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = await UserService.FindByIdAsync(id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var user = await UserService.FindByIdAsync(id);

                if (user == null)
                    return HttpNotFound();

                var result = await UserService.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
