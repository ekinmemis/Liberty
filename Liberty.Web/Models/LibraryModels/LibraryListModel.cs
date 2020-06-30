using Liberty.Framework.DataTables;

namespace Liberty.Web.Models.LibraryModels
{
    public class LibraryListModel : DataSourceRequest
    {
        public string SearchName { get; set; }
    }
}