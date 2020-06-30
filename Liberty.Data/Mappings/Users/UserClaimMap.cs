using Liberty.Core.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Users
{
    public class UserClaimMap : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimMap()
        {
            this.ToTable(nameof(UserClaim));
        }
    }
}
