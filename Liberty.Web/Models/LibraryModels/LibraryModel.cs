using System.Collections.Generic;
using System.Web.Mvc;

namespace Liberty.Web.Models.LibraryModels
{
    public class LibraryModel
    {
        public LibraryModel()
        {
            this.AvailableAddress = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public IList<SelectListItem> AvailableAddress { get; set; }
    }
}