using Liberty.Framework.DataTables;

namespace Liberty.Web.Models.PublisherModels
{
    public class PublisherListModel : DataSourceRequest
    {
        public string SearchName { get; set; }
    }
}