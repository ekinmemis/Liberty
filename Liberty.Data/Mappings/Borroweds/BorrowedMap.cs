using Liberty.Core.Domain.Borroweds;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Borroweds
{
    public class BorrowedMap : EntityTypeConfiguration<Borrowed>
    {
        public BorrowedMap()
        {
            this.ToTable(nameof(Borrowed));
        }
    }
}
