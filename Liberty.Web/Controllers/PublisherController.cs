using Liberty.Web.Helpers;
using Liberty.Web.Models.PublisherModels;
using Liberty.Core.Domain.Publishers;
using Liberty.Services.AddressServices;
using Liberty.Services.PublisherServices;
using System.Web.Mvc;

namespace Liberty.Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        private readonly IAddressService _addressService;

        public PublisherController()
        {
            this._publisherService = new PublisherService();
            this._addressService = new AddressService();
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new PublisherListModel());
        }

        [HttpPost]
        public ActionResult PublisherList(PublisherListModel model)
        {
            var publishers = _publisherService.GetAllPublishers(model.SearchName, model.PageIndex, model.PageSize);
            return Json(new { draw = model.Draw, recordsFiltered = 0, recordsTotal = publishers.TotalCount, data = publishers });
        }

        public ActionResult Create()
        {
            var model = new PublisherModel();
            PreparePublisherModel(model, null);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PublisherModel model)
        {
            if (ModelState.IsValid)
            {
                var publisher = new Publisher()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    AddressId = model.AddressId
                };

                _publisherService.InsertPublisher(publisher);
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            var model = new PublisherModel();
            PreparePublisherModel(model, publisher);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PublisherModel model)
        {
            var publisher = _publisherService.GetPublisherById(model.Id);

            if (ModelState.IsValid)
            {
                publisher.Name = model.Name;

                _publisherService.UpdatePublisher(publisher);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            _publisherService.DeletePublisher(publisher);
            return Json("Ok");
        }

        [NonAction]
        protected void PreparePublisherModel(PublisherModel model, Publisher publisher)
        {
            if (publisher != null)
            {
                model.Id = publisher.Id;
                model.Name = publisher.Name;
                model.AddressId = publisher.AddressId;
                model.Email = publisher.Email;
                model.Phone = publisher.Phone;

            }
            //Addresses
            PrepareAddresssModel(model);
        }

        [NonAction]
        protected virtual void PrepareAddresssModel(PublisherModel model)
        {
            model.AvailableAddress.Add(new SelectListItem { Text = "None", Value = "0" });
            var addresses = SelectListHelper.GetAddressList(_addressService);
            foreach (var address in addresses)
                model.AvailableAddress.Add(address);
        }
    }
}