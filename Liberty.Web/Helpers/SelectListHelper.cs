using Liberty.Services.AddressServices;
using Liberty.Services.PublisherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Liberty.Web.Helpers
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> GetPublisherList(IPublisherService publisherService)
        {
            if (publisherService == null)
                throw new ArgumentNullException("publisherService");


            var publishers = publisherService.GetAllPublishers();
            publishers.Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            });

            var result = new List<SelectListItem>();

            foreach (var item in publishers)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            return result;
        }

        public static List<SelectListItem> GetAddressList(IAddressService addressService)
        {
            if (addressService == null)
                throw new ArgumentNullException("addressService");

            var addresses = addressService.GetAllAddress();
            addresses.Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            });

            var result = new List<SelectListItem>();

            foreach (var item in addresses)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            return result;
        }
    }
}