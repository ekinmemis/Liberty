using Liberty.Web.Helpers;
using Liberty.Web.Models.LibraryModels;
using Liberty.Core.Domain.Libraries;
using Liberty.Services.AddressServices;
using Liberty.Services.LibraryServices;
using System.Web.Mvc;

namespace Liberty.Web.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;
        private readonly IAddressService _addressService;

        public LibraryController()
        {
            this._libraryService = new LibraryService();
            this._addressService = new AddressService();
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new LibraryListModel());
        }

        [HttpPost]
        public ActionResult LibraryList(LibraryListModel model)
        {
            var librarys = _libraryService.GetAllLibraries(model.SearchName, model.PageIndex, model.PageSize);
            return Json(new { draw = model.Draw, recordsFiltered = 0, recordsTotal = librarys.TotalCount, data = librarys });
        }

        public ActionResult Create()
        {
            var model = new LibraryModel();
            PrepareLibraryModel(model, null);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(LibraryModel model)
        {
            if (ModelState.IsValid)
            {
                var library = new Library()
                {
                    Id = model.Id,
                    Name = model.Name,
                    AddressId = model.AddressId
                };

                _libraryService.InsertLibrary(library);
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var library = _libraryService.GetLibraryById(id);
            var model = new LibraryModel();
            PrepareLibraryModel(model, library);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(LibraryModel model)
        {
            var library = _libraryService.GetLibraryById(model.Id);

            if (ModelState.IsValid)
            {
                library.Name = model.Name;

                _libraryService.UpdateLibrary(library);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var library = _libraryService.GetLibraryById(id);
            _libraryService.DeleteLibrary(library);
            return Json("Ok");
        }

        [NonAction]
        protected void PrepareLibraryModel(LibraryModel model, Library library)
        {
            if (library != null)
            {
                model.Id = library.Id;
                model.Name = library.Name;
                model.AddressId = library.AddressId;
            }
            //Addresses
            PrepareAddresssModel(model);
        }

        [NonAction]
        protected virtual void PrepareAddresssModel(LibraryModel model)
        {
            model.AvailableAddress.Add(new SelectListItem { Text = "None", Value = "0" });
            var addresses = SelectListHelper.GetAddressList(_addressService);
            foreach (var address in addresses)
                model.AvailableAddress.Add(address);
        }
    }
}