using Liberty.Core;
using Liberty.Core.Domain.Borroweds;

namespace Liberty.Services.BorrowedServices
{
    public partial interface IBorrowedService
    {
        IPagedList<Borrowed> GetAllBorroweds(int userId = 0, int pageIndex = 0, int pageSize = int.MaxValue);

        void DeleteBorrowed(Borrowed author);

        Borrowed GetBorrowedById(int authorId);

        void InsertBorrowed(Borrowed author);

        void UpdateBorrowed(Borrowed author);
    }
}
