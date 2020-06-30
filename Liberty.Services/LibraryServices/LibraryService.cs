using Liberty.Core;
using Liberty.Core.Domain.Libraries;
using Liberty.Data.Infrastructure;
using Liberty.Data.Repository;
using System;
using System.Linq;

namespace Liberty.Services.LibraryServices
{
    public class LibraryService : ILibraryService
    {
        private readonly IRepository<Library> _libraryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatabaseFactory _databaseFactory;

        public LibraryService()
        {
            this._databaseFactory = new DatabaseFactory();
            this._unitOfWork = new UnitOfWork(_databaseFactory);
            this._libraryRepository = new Repository<Library>();
        }

        public virtual IPagedList<Library> GetAllLibraries(string name = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _libraryRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            query = query.OrderBy(o => o.Id);

            var librarys = new PagedList<Library>(query, pageIndex, pageSize);

            return librarys;
        }

        public virtual void DeleteLibrary(Library library)
        {
            if (library == null)
                throw new ArgumentNullException("library");

            _libraryRepository.Delete(library);
        }

        public virtual Library GetLibraryById(int libraryId)
        {
            if (libraryId == 0)
                return null;

            return _libraryRepository.GetById(libraryId);
        }

        public virtual void InsertLibrary(Library library)
        {
            if (library == null)
                throw new ArgumentNullException("library");

            _libraryRepository.Insert(library);
        }

        public virtual void UpdateLibrary(Library library)
        {
            if (library == null)
                throw new ArgumentNullException("library");

            _libraryRepository.Update(library);
        }

        public virtual void SaveLibrary()
        {
            _unitOfWork.Save();
        }
    }
}
