using Liberty.Core;
using Liberty.Core.Domain.Libraries;

namespace Liberty.Services.LibraryServices
{
    public partial interface ILibraryService
    {
        IPagedList<Library> GetAllLibraries(string name = null, int pageIndex = 0, int pageSize = int.MaxValue);

        void DeleteLibrary(Library library);

        Library GetLibraryById(int libraryId);

        void InsertLibrary(Library library);

        void UpdateLibrary(Library library);
    }
}
