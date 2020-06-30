using Liberty.Core.Domain.Publishers;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Publishers
{
    public class PublisherMap : EntityTypeConfiguration<Publisher>
    {
        public PublisherMap()
        {
            this.ToTable(nameof(Publisher));
        }
    }
}
