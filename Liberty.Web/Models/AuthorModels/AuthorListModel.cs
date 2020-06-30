using Liberty.Framework.DataTables;

namespace Liberty.Web.Models.AuthorModels
{
    public class AuthorListModel : DataSourceRequest
    {
        public string SearchFirstname { get; set; }
    }
}