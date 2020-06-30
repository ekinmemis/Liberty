using Liberty.Framework.DataTables;

namespace Liberty.Web.Models.BookModels
{
    public class BookListModel : DataSourceRequest
    {
        public string SearchName { get; set; }
    }
}