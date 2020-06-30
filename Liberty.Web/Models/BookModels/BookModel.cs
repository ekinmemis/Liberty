using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Liberty.Web.Models.BookModels
{
    public class BookModel
    {
        public BookModel()
        {
            this.AvailablePublishers = new List<SelectListItem>();
            this.AvailableLibraryBooks = new List<SelectListItem>();
            this.AvailableAuthorBooks = new List<SelectListItem>();
            this.AvailableCategoryBooks = new List<SelectListItem>();

            this.SelectedAuthorBookIds = new List<int>();
            this.SelectedCategoryBookIds = new List<int>();
            this.SelectedLibraryBookIds = new List<int>();
        }

        public int Id { get; set; }
        public int InternationalStandardBookNumber { get; set; }
        public string Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public int PageCount { get; set; }

        public int PublisherId { get; set; }
        public IList<SelectListItem> AvailablePublishers { get; set; }

        public string LibraryBooksName { get; set; }
        public List<SelectListItem> AvailableLibraryBooks { get; set; }
        public IList<int> SelectedLibraryBookIds { get; set; }

        public string AuthorBooksName { get; set; }
        public List<SelectListItem> AvailableAuthorBooks { get; set; }
        public IList<int> SelectedAuthorBookIds { get; set; }

        public string CategoryBooksName { get; set; }
        public List<SelectListItem> AvailableCategoryBooks { get; set; }
        public IList<int> SelectedCategoryBookIds { get; set; }
    }
}