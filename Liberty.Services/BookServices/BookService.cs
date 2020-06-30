using Liberty.Core;
using Liberty.Core.Domain.Authors;
using Liberty.Core.Domain.Books;
using Liberty.Core.Domain.Categories;
using Liberty.Core.Domain.Libraries;
using Liberty.Data.Infrastructure;
using Liberty.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Liberty.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Library> _libraryRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatabaseFactory _databaseFactory;
       
        public BookService()
        {
            this._bookRepository = new Repository<Book>();
            this._authorRepository = new Repository<Author>();
            this._categoryRepository = new Repository<Category>();
            this._libraryRepository = new Repository<Library>();
            this._unitOfWork = new UnitOfWork(_databaseFactory);
            this._databaseFactory = new DatabaseFactory();
        }

        public virtual IPagedList<Book> GetAllBooks(string name = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _bookRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            query = query.OrderBy(o => o.Id);

            var books = new PagedList<Book>(query, pageIndex, pageSize);

            return books;
        }

        public IList<Library> GetAllLibraries()
        {
            var query = from q in _libraryRepository.Table
                        orderby q.Name
                        select q;

            var libraries = query.ToList();
            return libraries;
        }

        public IList<Author> GetAllAuthors()
        {
            var query = from q in _authorRepository.Table
                        orderby q.Firstname
                        select q;

            var authors = query.ToList();
            return authors;
        }

        public IList<Category> GetAllCategories()
        {
            var query = from q in _categoryRepository.Table
                        orderby q.Name
                        select q;

            var categories = query.ToList();
            return categories;
        }

        public virtual void DeleteBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException("book");

            _bookRepository.Delete(book);
        }

        public virtual Book GetBookById(int bookId)
        {
            if (bookId == 0)
                return null;

            return _bookRepository.GetById(bookId);
        }

        public virtual void InsertBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException("book");

            _bookRepository.Insert(book);
        }

        public virtual void UpdateBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException("book");

            _bookRepository.Update(book);
        }

        public virtual void SaveBook()
        {
            _unitOfWork.Save();
        }

    }
}
