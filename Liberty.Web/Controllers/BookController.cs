using Liberty.Web.Helpers;
using Liberty.Web.Models.BookModels;
using Liberty.Core.Domain.Books;
using Liberty.Services.PublisherServices;
using Liberty.Services.BookServices;
using System.Web.Mvc;
using System.Linq;
using Liberty.Core.Domain.Authors;
using System.Collections.Generic;
using Liberty.Core.Domain.Libraries;
using Liberty.Core.Domain.Categories;

namespace Liberty.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;

        public BookController()
        {
            this._bookService = new BookService();
            this._publisherService = new PublisherService();
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new BookListModel());
        }

        [HttpPost]
        public ActionResult BookList(BookListModel model)
        {
            var books = _bookService.GetAllBooks(model.SearchName, model.PageIndex, model.PageSize);
            return Json(new { draw = model.Draw, recordsFiltered = 0, recordsTotal = books.TotalCount, data = books });
        }

        public ActionResult Create()
        {
            var model = new BookModel();
            PrepareBookModel(model, null);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookModel model)
        {
            var allAuthors = _bookService.GetAllAuthors();
            var newAuthors = new List<Author>();
            foreach (var author in allAuthors)
                if (model.SelectedAuthorBookIds.Contains(author.Id))
                    newAuthors.Add(author);

            var allLibraries = _bookService.GetAllLibraries();
            var newLibraries = new List<Library>();
            foreach (var library in allLibraries)
                if (model.SelectedLibraryBookIds.Contains(library.Id))
                    newLibraries.Add(library);

            var allCategories = _bookService.GetAllCategories();
            var newCategories = new List<Category>();
            foreach (var item in allCategories)
                if (model.SelectedCategoryBookIds.Contains(item.Id))
                    newCategories.Add(item);

            if (ModelState.IsValid)
            {
                var book = new Book()
                {
                    Id = model.Id,
                    Name = model.Name,
                    PublisherId = model.PublisherId,
                    PageCount = model.PageCount,
                    PublishedDate = model.PublishedDate,
                    InternationalStandardBookNumber = model.InternationalStandardBookNumber,
                };

                _bookService.InsertBook(book);

                foreach (var author in newAuthors)
                    book.AuthorBookMappings.Add(new AuthorBookMapping() { AuthorId = author.Id, BookId = book.Id });

                foreach (var library in newLibraries)
                    book.LibraryBookMappings.Add(new LibraryBookMapping() { LibraryId = library.Id, BookId = book.Id });

                foreach (var category in newCategories)
                    book.CategoryBookMappings.Add(new CategoryBookMapping() { CategoryId = category.Id, BookId = book.Id });

                _bookService.UpdateBook(book);
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var book = _bookService.GetBookById(id);
            var model = new BookModel();
            PrepareBookModel(model, book);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookModel model)
        {
            var allAuthors = _bookService.GetAllAuthors();
            var newAuthors = new List<Author>();
            foreach (var author in allAuthors)
                if (model.SelectedAuthorBookIds.Contains(author.Id))
                    newAuthors.Add(author);

            var allLibraries = _bookService.GetAllLibraries();
            var newLibraries = new List<Library>();
            foreach (var library in allLibraries)
                if (model.SelectedLibraryBookIds.Contains(library.Id))
                    newLibraries.Add(library);

            var allCategories = _bookService.GetAllCategories();
            var newCategories = new List<Category>();
            foreach (var item in allCategories)
                if (model.SelectedCategoryBookIds.Contains(item.Id))
                    newCategories.Add(item);

            var book = _bookService.GetBookById(model.Id);

            PrepareBookModel(model, book);

            if (ModelState.IsValid)
            {
                book.Name = model.Name;
                book.Id = model.Id;
                book.Name = model.Name;
                book.PublisherId = model.PublisherId;
                book.PageCount = model.PageCount;
                book.PublishedDate = model.PublishedDate;
                book.InternationalStandardBookNumber = model.InternationalStandardBookNumber;

                _bookService.UpdateBook(book);

                foreach (var author in newAuthors)
                    book.AuthorBookMappings.Add(new AuthorBookMapping() { AuthorId = author.Id, BookId = book.Id });

                foreach (var library in newLibraries)
                    book.LibraryBookMappings.Add(new LibraryBookMapping() { LibraryId = library.Id, BookId = book.Id });

                foreach (var category in newCategories)
                    book.CategoryBookMappings.Add(new CategoryBookMapping() { CategoryId = category.Id, BookId = book.Id });
            }


            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var book = _bookService.GetBookById(id);
            _bookService.DeleteBook(book);
            return Json("Ok");
        }

        [NonAction]
        protected void PrepareBookModel(BookModel model, Book book)
        {

            if (book != null)
            {
                model.SelectedAuthorBookIds = book.AuthorBookMappings.Select(ab => ab.Id).ToList();

                model.Id = book.Id;
                model.Name = book.Name;
                model.Name = book.Name;
                model.Id = book.Id;
                model.Name = book.Name;
                model.PublisherId = book.PublisherId;
                model.PageCount = book.PageCount;
                model.PublishedDate = book.PublishedDate;
                model.InternationalStandardBookNumber = book.InternationalStandardBookNumber;
                model.SelectedAuthorBookIds = book.AuthorBookMappings.Select(e => e.AuthorId).ToList();
                model.SelectedCategoryBookIds = book.CategoryBookMappings.Select(e => e.CategoryId).ToList();
                model.SelectedLibraryBookIds = book.LibraryBookMappings.Select(e => e.LibraryId).ToList();
            }

            //Publishers
            PreparePublishersForModel(model);

            var allAuthors = _bookService.GetAllAuthors();
            foreach (var author in allAuthors)
            {
                model.AvailableAuthorBooks.Add(new SelectListItem
                {
                    Text = author.Firstname,
                    Value = author.Id.ToString(),
                    Selected = model.SelectedAuthorBookIds.Contains(author.Id)
                });
            }

            var allLibraries = _bookService.GetAllLibraries();
            foreach (var library in allLibraries)
            {
                model.AvailableLibraryBooks.Add(new SelectListItem
                {
                    Text = library.Name,
                    Value = library.Id.ToString(),
                    Selected = model.SelectedAuthorBookIds.Contains(library.Id)
                });
            }

            var allCategories = _bookService.GetAllCategories();
            foreach (var category in allCategories)
            {
                model.AvailableCategoryBooks.Add(new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString(),
                    Selected = model.SelectedAuthorBookIds.Contains(category.Id)
                });
            }
        }

        [NonAction]
        protected virtual void PreparePublishersForModel(BookModel model)
        {
            model.AvailablePublishers.Add(new SelectListItem { Text = "None", Value = "0" });
            var publisheres = SelectListHelper.GetPublisherList(_publisherService);
            foreach (var publisher in publisheres)
                model.AvailablePublishers.Add(publisher);
        }
    }
}