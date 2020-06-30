using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System;
using Liberty.Services.UserServices;
using Liberty.Core.Domain.Users;
using Liberty.Web.Models.AdminViewModels;

namespace Liberty.Web.Controllers
{
    [Authorize]
    public class RolesAdminController : Controller
    {
        private ApplicationUserService _userService;
        public ApplicationUserService UserService
        {
            get => _userService ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserService>();
            set => _userService = value;
        }

        private ApplicationRoleService _roleService;
        public ApplicationRoleService RoleService
        {
            get => _roleService ?? HttpContext.GetOwinContext().Get<ApplicationRoleService>();
            private set => _roleService = value;
        }

        public RolesAdminController()
        {
        }

        public RolesAdminController(ApplicationUserService userService, ApplicationRoleService roleService)
        {
            UserService = userService;
            RoleService = roleService;
        }
    
        public ActionResult Index()
        {
            return View(RoleService.Roles);
        }

        //public async Task<ActionResult> Details(int id)
        //{
        //    if (id == 0)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var role = await RoleService.FindByIdAsync(id);
        //    // Get the list of Users in this Role
        //    var users = new List<User>();

        //    // Get the list of Users in this Role
        //    foreach (var user in UserService.Users.ToList())
        //        if (await UserService.IsInRoleAsync(user.Id, role.Name))
        //            users.Add(user);

        //    ViewBag.Users = users;
        //    ViewBag.UserCount = users.Count();
        //    return View(role);
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new Role();
                role.Name = roleViewModel.Name;
                var roleresult = await RoleService.CreateAsync(role);

                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }

                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var role = await RoleService.FindByIdAsync(id);

            if (role == null)
                return HttpNotFound();

            RoleViewModel roleModel = new RoleViewModel { Id = Convert.ToInt32(role.Id), Name = role.Name };

            return View(roleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = await RoleService.FindByIdAsync(roleModel.Id);
                role.Name = roleModel.Name;
                await RoleService.UpdateAsync(role);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var role = await RoleService.FindByIdAsync(id);

            if (role == null)
                return HttpNotFound();

            return View(role);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, string deleteUser)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var role = await RoleService.FindByIdAsync(id);

                if (role == null)
                    return HttpNotFound();

                IdentityResult result;

                if (deleteUser != null)
                    result = await RoleService.DeleteAsync(role);
                else
                    result = await RoleService.DeleteAsync(role);

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
