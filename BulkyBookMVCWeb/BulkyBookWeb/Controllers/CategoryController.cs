using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _categoryService.GetCategory();
            return View(objCategoryList);
        }

        // GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _categoryService.CreateCategory(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        // GET 
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            // ToDo: move to the service
            var categoryFormDb = _categoryService.FindCategory(id);

            if(categoryFormDb == null)
            {
                return NotFound();
            }
            return View(categoryFormDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        // GET 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFormDb = _categoryService.FindCategory(id);

            if (categoryFormDb == null)
            {
                return NotFound();
            }
            return View(categoryFormDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _categoryService.FindCategory(id);
            if (obj == null)
            {
                return NotFound();
            }
               _categoryService.RemoveCategory(obj);
               return RedirectToAction("Index");
           return View(obj); 
        }
    }
}
