using Liberty.Web.Models.CategoryModels;
using Liberty.Core.Domain.Categories;
using Liberty.Services.CategoryServices;
using System.Web.Mvc;

namespace Liberty.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController()
        {
            this._categoryService = new CategoryService();
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new CategoryListModel());
        }

        [HttpPost]
        public ActionResult CategoryList(CategoryListModel model)
        {
            var categorys = _categoryService.GetAllCategorys(model.SearchName, model.PageIndex, model.PageSize);
            return Json(new { draw = model.Draw, recordsFiltered = 0, recordsTotal = categorys.TotalCount, data = categorys });
        }

        public ActionResult Create()
        {
            var model = new CategoryModel();
            PrepareCategoryModel(model, null);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Id = model.Id,
                    Name = model.Name,
                };

                _categoryService.InsertCategory(category);
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            var model = new CategoryModel();
            PrepareCategoryModel(model, category);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
            var category = _categoryService.GetCategoryById(model.Id);

            if (ModelState.IsValid)
            {
                category.Name = model.Name;

                _categoryService.UpdateCategory(category);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            _categoryService.DeleteCategory(category);
            return Json("Ok");
        }

        [NonAction]
        protected void PrepareCategoryModel(CategoryModel model, Category category)
        {
            if (category != null)
            {
                model.Id = category.Id;
                model.Name = category.Name;
            }
        }
    }
}