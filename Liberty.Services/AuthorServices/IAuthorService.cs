using Liberty.Core;
using Liberty.Core.Domain.Authors;

namespace Liberty.Services.AuthorServices
{
    public partial interface IAuthorService
    {
        IPagedList<Author> GetAllAuthors(string firstName = null,int pageIndex = 0, int pageSize = int.MaxValue);

        void DeleteAuthor(Author author);

        Author GetAuthorById(int authorId);

        void InsertAuthor(Author author);

        void UpdateAuthor(Author author);
    }
}
