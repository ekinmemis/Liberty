using Liberty.Web.Models.AuthorModels;
using Liberty.Core.Domain.Authors;
using Liberty.Services.AuthorServices;
using System.Web.Mvc;

namespace Liberty.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController()
        {
            this._authorService = new AuthorService();
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new AuthorListModel());
        }

        [HttpPost]
        public ActionResult AuthorList(AuthorListModel model)
        {
            var authors = _authorService.GetAllAuthors(model.SearchFirstname, model.PageIndex, model.PageSize);
            return Json(new { draw = model.Draw, recordsFiltered = 0, recordsTotal = authors.TotalCount, data = authors });
        }

        public ActionResult Create()
        {
            var model = new AuthorModel();
            PrepareAuthorModel(model, null);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                var author = new Author()
                {
                    Id = model.Id,
                    Firstname = model.Firstname,
                    Middlename = model.Middlename,
                    Lastname = model.Lastname,
                };

                _authorService.InsertAuthor(author);
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var author = _authorService.GetAuthorById(id);
            var model = new AuthorModel();
            PrepareAuthorModel(model, author);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AuthorModel model)
        {
            var author = _authorService.GetAuthorById(model.Id);

            if (ModelState.IsValid)
            {
                author.Firstname = model.Firstname;
                author.Middlename = model.Middlename;
                author.Lastname = model.Lastname;

                _authorService.UpdateAuthor(author);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var author = _authorService.GetAuthorById(id);
            _authorService.DeleteAuthor(author);
            return Json("Ok");
        }

        [NonAction]
        protected void PrepareAuthorModel(AuthorModel model, Author author)
        {
            if (author != null)
            {
                model.Id = author.Id;
                model.Firstname = author.Firstname;
                model.Middlename = author.Middlename;
                model.Lastname = author.Lastname;
            }
        }
    }
}