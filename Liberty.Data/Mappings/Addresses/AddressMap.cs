using Liberty.Core.Domain.Addresses;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Addresses
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.ToTable(nameof(Address));
        }
    }
}
