using Liberty.Core;
using Liberty.Core.Domain.Authors;
using Liberty.Data.Infrastructure;
using Liberty.Data.Repository;
using System;
using System.Linq;

namespace Liberty.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatabaseFactory  _databaseFactory;

        public AuthorService()
        {
            this._databaseFactory = new DatabaseFactory();
            this._authorRepository = new Repository<Author>();
            this._unitOfWork = new UnitOfWork(_databaseFactory);
        }

        public virtual IPagedList<Author> GetAllAuthors(string firstName = null ,int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _authorRepository.Table;

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(a => a.Firstname.Contains(firstName));

            query = query.OrderBy(o => o.Id);

            var authors = new PagedList<Author>(query, pageIndex, pageSize);
            return authors;
        }

        public virtual void DeleteAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException("author");

            _authorRepository.Delete(author);

        }

        public virtual Author GetAuthorById(int authorId)
        {
            if (authorId == 0)
                return null;

            return _authorRepository.GetById(authorId);
        }

        public virtual void InsertAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException("author");

            _authorRepository.Insert(author);

        }

        public virtual void UpdateAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException("author");

            _authorRepository.Update(author);
        }

        public virtual void SaveAuthor()
        {
            _unitOfWork.Save();
        }
    }
}
