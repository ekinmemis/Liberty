namespace Liberty.Framework.DataTables
{
    public class DataSourceRequest
    {
        public string Draw { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public DataSourceRequest()
        {
            this.PageIndex = 1;
            this.PageSize = 10;
        }
    }
}
