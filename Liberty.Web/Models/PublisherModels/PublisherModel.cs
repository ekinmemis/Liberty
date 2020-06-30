using System.Collections.Generic;
using System.Web.Mvc;

namespace Liberty.Web.Models.PublisherModels
{
    public class PublisherModel
    {
        public PublisherModel()
        {
            this.AvailableAddress = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public IList<SelectListItem> AvailableAddress { get; set; }
    }
}