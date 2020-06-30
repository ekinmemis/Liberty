using Liberty.Core.Domain.Authors;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Authors
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            this.ToTable(nameof(Author));
        }
    }
}
