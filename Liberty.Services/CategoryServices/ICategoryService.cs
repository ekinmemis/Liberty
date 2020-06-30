using Liberty.Core;
using Liberty.Core.Domain.Categories;

namespace Liberty.Services.CategoryServices
{
    public partial interface ICategoryService
    {
        IPagedList<Category> GetAllCategorys(string name = null, int pageIndex = 0, int pageSize = int.MaxValue);

        void DeleteCategory(Category category);

        Category GetCategoryById(int categoryId);

        void InsertCategory(Category category);

        void UpdateCategory(Category category);
    }
}
