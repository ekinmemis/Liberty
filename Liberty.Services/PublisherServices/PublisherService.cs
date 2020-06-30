using Liberty.Core;
using Liberty.Core.Domain.Publishers;
using Liberty.Data.Infrastructure;
using Liberty.Data.Repository;
using System;
using System.Linq;

namespace Liberty.Services.PublisherServices
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatabaseFactory  _databaseFactory;
        public PublisherService()
        {
            this._databaseFactory = new DatabaseFactory();
            this._unitOfWork = new UnitOfWork(_databaseFactory);
            this._publisherRepository = new Repository<Publisher>();
        }

        public virtual IPagedList<Publisher> GetAllPublishers(string name = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _publisherRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            query = query.OrderBy(o => o.Id);

            var publishers = new PagedList<Publisher>(query, pageIndex, pageSize);

            return publishers;
        }

        public virtual void DeletePublisher(Publisher publisher)
        {
            if (publisher == null)
                throw new ArgumentNullException("publisher");

            _publisherRepository.Delete(publisher);

            SavePublisher();
        }

        public virtual Publisher GetPublisherById(int publisherId)
        {
            if (publisherId == 0)
                return null;

            return _publisherRepository.GetById(publisherId);
        }

        public virtual void InsertPublisher(Publisher publisher)
        {
            if (publisher == null)
                throw new ArgumentNullException("publisher");

            _publisherRepository.Insert(publisher);

            SavePublisher();
        }

        public virtual void UpdatePublisher(Publisher publisher)
        {
            if (publisher == null)
                throw new ArgumentNullException("publisher");

            _publisherRepository.Update(publisher);
        }

        public virtual void SavePublisher()
        {
            _unitOfWork.Save();
        }
    }
}
