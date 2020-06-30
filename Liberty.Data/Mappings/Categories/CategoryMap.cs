using Liberty.Core.Domain.Categories;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Categories
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable(nameof(Category));
        }
    }
}
