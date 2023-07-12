using CreateOne.Data;
using CreateOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreateOne.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AplicationDbContext _db;
        public CategoryController(AplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategegoryList = _db.Categorys.ToList();
            return View(objCategegoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("name", "Name and display order can't exactly match"); 
            }
            
            if(ModelState.IsValid)
            {
                _db.Categorys.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }

            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categorys.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categorys.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edit Successfully";
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categorys.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category? obj = _db.Categorys.Find(id);
            if (obj == null) { return NotFound(); }
            _db.Categorys.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}
