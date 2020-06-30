using Liberty.Core;
using Liberty.Core.Domain.Publishers;

namespace Liberty.Services.PublisherServices
{
    public partial interface IPublisherService
    {
        IPagedList<Publisher> GetAllPublishers(string name = null, int pageIndex = 0, int pageSize = int.MaxValue);

        void DeletePublisher(Publisher publisher);

        Publisher GetPublisherById(int publisherId);

        void InsertPublisher(Publisher publisher);

        void UpdatePublisher(Publisher publisher);
    }
}
