using Liberty.Core.Domain.Books;

namespace Liberty.Core.Domain.Authors
{
    public partial class AuthorBookMapping : BaseEntity
    {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
