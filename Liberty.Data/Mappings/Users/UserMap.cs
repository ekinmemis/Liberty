using Liberty.Core.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Users
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable(nameof(User));
        }
    }
}
