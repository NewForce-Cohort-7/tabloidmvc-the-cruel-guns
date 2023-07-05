using TabloidMVC.Models;
using TabloidMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TabloidMVC.Controllers
{
public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        // ASP.NET will give us an instance of our Category Repository. This is called "Dependency Injection"
        public CategoryController(
            ICategoryRepository categoryRepository)
            {
                _categoryRepo = categoryRepository;
            }

        // GET: CategoryController
        public ActionResult Index()
        {
            List<Category> categories = _categoryRepo.GetAllCategories();
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                _categoryRepo.AddCategory(category);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(category);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = _categoryRepo.GetCategoryById(id);

            return View(category);
        }

        // POST: Categorys/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                _categoryRepo.DeleteCategory(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(category);
            }
        }
    }
}
