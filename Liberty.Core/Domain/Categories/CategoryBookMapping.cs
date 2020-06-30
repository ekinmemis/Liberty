using Liberty.Core.Domain.Books;

namespace Liberty.Core.Domain.Categories
{
    public partial class CategoryBookMapping : BaseEntity
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
