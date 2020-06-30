using Liberty.Framework.DataTables;

namespace Liberty.Web.Models.AddressModels
{
    public class AddressListModel : DataSourceRequest
    {
        public string SearchName { get; set; }
    }
}