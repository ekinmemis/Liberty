using Liberty.Core.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Users
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable(nameof(Role));
        }
    }
}
