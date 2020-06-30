using Liberty.Core.Domain.Users;
using Liberty.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Linq;
using System.Threading.Tasks;

namespace Liberty.Services.UserServices
{
    public class ApplicationRoleService : RoleManager<Role, int>
    {
        public override IQueryable<Role> Roles => base.Roles;

        public ApplicationRoleService(IRoleStore<Role, int> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleService Create(IdentityFactoryOptions<ApplicationRoleService> options, IOwinContext context)
        {
            return new ApplicationRoleService(new RoleStore<Role, int, UserRole>(context.Get<ApplicationDbContext>()));
        }

        public override Task<IdentityResult> CreateAsync(Role role)
        {
            return base.CreateAsync(role);
        }

        public override Task<IdentityResult> DeleteAsync(Role role)
        {
            return base.DeleteAsync(role);
        }

        public override Task<Role> FindByIdAsync(int roleId)
        {
            return base.FindByIdAsync(roleId);
        }

        public override Task<Role> FindByNameAsync(string roleName)
        {
            return base.FindByNameAsync(roleName);
        }

        public override Task<bool> RoleExistsAsync(string roleName)
        {
            return base.RoleExistsAsync(roleName);
        }

        public override Task<IdentityResult> UpdateAsync(Role role)
        {
            return base.UpdateAsync(role);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
