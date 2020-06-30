using Liberty.Core;
using Liberty.Core.Domain.Authors;
using Liberty.Core.Domain.Books;
using Liberty.Core.Domain.Categories;
using Liberty.Core.Domain.Libraries;
using System.Collections.Generic;

namespace Liberty.Services.BookServices
{
    public partial interface IBookService
    {
        IPagedList<Book> GetAllBooks(string name = null, int pageIndex = 0, int pageSize = int.MaxValue);
        IList<Library> GetAllLibraries();
        IList<Author> GetAllAuthors();
        IList<Category> GetAllCategories();

        void DeleteBook(Book book);

        Book GetBookById(int bookId);

        void InsertBook(Book book);

        void UpdateBook(Book book);
    }
}
