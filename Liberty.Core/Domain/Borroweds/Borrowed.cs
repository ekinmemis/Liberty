using System;

namespace Liberty.Core.Domain.Borroweds
{
    public partial class Borrowed : BaseEntity
    {
        public DateTime BorrowedDate { get; set; }
        public bool IsRecieved { get; set; }
        public DateTime? RecievedDate { get; set; }

        public int UserId { get; set; }
        public int LibraryId { get; set; }
        public int BookId { get; set; }
    }
}
