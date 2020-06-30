using Liberty.Web.Models.AddressModels;
using Liberty.Core.Domain.Addresses;
using Liberty.Services.AddressServices;
using System.Web.Mvc;

namespace Liberty.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController()
        {
            this._addressService = new AddressService();
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new AddressListModel());
        }

        [HttpPost]
        public ActionResult AddressList(AddressListModel model)
        {
            var addresss = _addressService.GetAllAddress(model.SearchName, model.PageIndex, model.PageSize);
            return Json(new { draw = model.Draw, recordsFiltered = 0, recordsTotal = addresss.TotalCount, data = addresss });
        }

        public ActionResult Create()
        {
            var model = new AddressModel();
            PrepareAddressModel(model, null);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddressModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new Address()
                {
                    Id = model.Id,
                    Name = model.Name,
                    BuildingNumber = model.BuildingNumber,
                    District = model.District,
                    FloorNumber = model.FloorNumber,
                    Neighborhood = model.Neighborhood,
                    PostCode = model.PostCode,
                    Province = model.Province,
                    Street = model.Street,
                };

                _addressService.InsertAddress(address);
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var address = _addressService.GetAddressById(id);
            var model = new AddressModel();
            PrepareAddressModel(model, address);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddressModel model)
        {
            var address = _addressService.GetAddressById(model.Id);

            if (ModelState.IsValid)
            {
                address.Name = model.Name;
                address.Neighborhood = model.Neighborhood;
                address.PostCode = model.PostCode;
                address.Province = model.Province;
                address.Street = model.Street;
                address.BuildingNumber = model.BuildingNumber;
                address.District = model.District;

                _addressService.UpdateAddress(address);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var address = _addressService.GetAddressById(id);
            _addressService.DeleteAddress(address);
            return Json("Ok");
        }

        [NonAction]
        protected void PrepareAddressModel(AddressModel model, Address address)
        {
            if (address != null)
            {
                model.Id = address.Id;
                model.Name = address.Name;
                model.BuildingNumber = address.BuildingNumber;
                model.District = address.District;
                model.FloorNumber = address.FloorNumber;
                model.Neighborhood = address.Neighborhood;
                model.PostCode = address.PostCode;
                model.Province = address.Province;
                model.Street = address.Street;
            }
        }
    }
}