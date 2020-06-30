using Liberty.Core.Domain.Books;
namespace Liberty.Core.Domain.Libraries
{
    public partial class LibraryBookMapping : BaseEntity
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }
    }
}
