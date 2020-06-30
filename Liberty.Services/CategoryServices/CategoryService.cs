using Liberty.Core;
using Liberty.Core.Domain.Categories;
using Liberty.Data.Infrastructure;
using Liberty.Data.Repository;
using System;
using System.Linq;

namespace Liberty.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatabaseFactory _databaseFactory;

        public CategoryService()
        {
            this._databaseFactory = new DatabaseFactory();
            this._categoryRepository = new Repository<Category>();
            this._unitOfWork = new UnitOfWork(_databaseFactory);
        }

        public virtual IPagedList<Category> GetAllCategorys(string name = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _categoryRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            query = query.OrderBy(o => o.Id);

            var categorys = new PagedList<Category>(query, pageIndex, pageSize);

            return categorys;
        }

        public virtual void DeleteCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Delete(category);
        }

        public virtual Category GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            return _categoryRepository.GetById(categoryId);
        }

        public virtual void InsertCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Insert(category);
        }

        public virtual void UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Update(category);
        }

        public virtual void SaveCategory()
        {
            _unitOfWork.Save();
        }
    }
}
