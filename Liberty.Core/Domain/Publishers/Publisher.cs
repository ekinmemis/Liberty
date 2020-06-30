using Liberty.Core.Domain.Books;
using System.Collections.Generic;

namespace Liberty.Core.Domain.Publishers
{
    public partial class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }

        private ICollection<Book> _books;
        public virtual ICollection<Book> Books
        {
            get => _books ?? (_books = new List<Book>());
            protected set => _books = value;
        }
    }
}