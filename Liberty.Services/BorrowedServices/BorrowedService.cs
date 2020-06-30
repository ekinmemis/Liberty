using Liberty.Core;
using Liberty.Core.Domain.Borroweds;
using Liberty.Data.Infrastructure;
using Liberty.Data.Repository;
using System;
using System.Linq;

namespace Liberty.Services.BorrowedServices
{
    public class BorrowedService : IBorrowedService
    {
        private readonly IRepository<Borrowed> _borrowedRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatabaseFactory _databaseFactory;

        public BorrowedService()
        {
            this._databaseFactory = new DatabaseFactory();
            this._borrowedRepository = new Repository<Borrowed>();
            this._unitOfWork = new UnitOfWork(_databaseFactory);
        }

        public virtual IPagedList<Borrowed> GetAllBorroweds(int userId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _borrowedRepository.Table;

            query = query.OrderBy(o => o.Id);

            var borroweds = new PagedList<Borrowed>(query, pageIndex, pageSize);

            return borroweds;
        }

        public virtual void DeleteBorrowed(Borrowed borrowed)
        {
            if (borrowed == null)
                throw new ArgumentNullException("borrowed");

            _borrowedRepository.Delete(borrowed);
        }

        public virtual Borrowed GetBorrowedById(int borrowedId)
        {
            if (borrowedId == 0)
                return null;

            return _borrowedRepository.GetById(borrowedId);
        }

        public virtual void InsertBorrowed(Borrowed borrowed)
        {
            if (borrowed == null)
                throw new ArgumentNullException("borrowed");

            _borrowedRepository.Insert(borrowed);
        }

        public virtual void UpdateBorrowed(Borrowed borrowed)
        {
            if (borrowed == null)
                throw new ArgumentNullException("borrowed");

            _borrowedRepository.Update(borrowed);
        }

        public virtual void SaveBorrowed()
        {
            _unitOfWork.Save();
        }
    }
}
