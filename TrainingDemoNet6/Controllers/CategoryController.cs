using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TrainingDemoNet6.Data;
using TrainingDemoNet6.Models;

namespace TrainingDemoNet6.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel model)
        {
            if (model.Name == model.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Category Name cannot be the same as Display Order!");
                TempData["error"] = $"Whoops!";
            }
            if (!ModelState.IsValid)
            {
                TempData["error"] = $"Could not create category - please check the form!";
                return View();
            }
            _context.Categories.Add(model);
            _context.SaveChanges();
            TempData["success"] = $"Successfully created new category: {model.Name}!";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = _context.Categories.FirstOrDefault(c => c.Id == id);
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = $"Could not update category - please check the form!";
                return View(model);
            }

            _context.Categories.Update(model);
            _context.SaveChanges();
            TempData["success"] = $"Successfully updated category with new name: {model.Name}!";
            return RedirectToAction("Index");
        }

        
    }
}
