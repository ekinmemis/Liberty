using Liberty.Core.Domain.Libraries;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Libraries
{
    public class LibraryMap : EntityTypeConfiguration<Library>
    {
        public LibraryMap()
        {
            this.ToTable(nameof(Library));
        }
    }
}
