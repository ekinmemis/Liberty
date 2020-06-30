using Liberty.Core.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Users
{
    public class UserLoginMap : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginMap()
        {
            this.ToTable(nameof(UserLogin));

            this.HasKey(f => new { f.LoginProvider, f.ProviderKey, f.UserId });
        }
    }
}
