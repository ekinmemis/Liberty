using Liberty.Core.Domain.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Liberty.Data
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            db = new ApplicationDbContext();

            var userStore = new UserStore<User, Role, int, UserLogin, UserRole, UserClaim>(db);
            var userManager = new UserManager<User, int>(userStore);
            var roleStore = new RoleStore<Role, int, UserRole>(db);
            var roleManager = new RoleManager<Role, int>(roleStore);

            const string name = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName1 = "Administrator";
            const string roleName2 = "Manager";
            const string roleName3 = "User";
            const string roleName4 = "Guest";


            //Create Role Administrator if it does not exist
            var administrator = roleManager.FindByName(roleName1);
            if (administrator == null)
            {
                administrator = new Role() { Id = 1, Name = roleName1 };
                roleManager.Create(administrator);
            }

            //Create Role Manager if it does not exist
            var manager = roleManager.FindByName(roleName2);
            if (manager == null)
            {
                manager = new Role() { Id = 2, Name = roleName2 };
                roleManager.Create(manager);
            }

            //Create Role User if it does not exist
            var theUserRole = roleManager.FindByName(roleName3);
            if (theUserRole == null)
            {
                theUserRole = new Role() { Id = 3, Name = roleName3 };
                roleManager.Create(theUserRole);
            }

            //Create Role Guest if it does not exist
            var guest = roleManager.FindByName(roleName4);
            if (guest == null)
            {
                guest = new Role() { Id = 4, Name = roleName4 };
                roleManager.Create(guest);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new User { Id = 1, UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(administrator.Name))
            {
                var result = userManager.AddToRole(user.Id, administrator.Name);
            }
        }
    }
}
