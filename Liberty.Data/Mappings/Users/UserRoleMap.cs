using Liberty.Core.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Users
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable(nameof(UserRole));

            this.HasKey(f => new { f.UserId, f.RoleId });
        }
    }
}
