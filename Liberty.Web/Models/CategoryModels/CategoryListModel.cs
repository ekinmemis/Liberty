using Liberty.Framework.DataTables;

namespace Liberty.Web.Models.CategoryModels
{
    public class CategoryListModel : DataSourceRequest
    {
        public string SearchName { get; set; }
    }
}