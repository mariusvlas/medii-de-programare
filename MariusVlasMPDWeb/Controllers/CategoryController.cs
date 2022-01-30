using MariusVlasMPDWeb.Data;
using MariusVlasMPDWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MariusVlasMPDWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category value)
        {

            if(ModelState.IsValid)
            {
                _db.Categories.Add(value);
                _db.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return View(value);
            }
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            var foundCategory = _db.Categories.Find(id);

            if (foundCategory == null)
            {
                return NotFound();
            }

            return View(foundCategory);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category value)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(value);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(value);
            }
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var foundCategory = _db.Categories.Find(id);

            if (foundCategory == null)
            {
                return NotFound();
            }

            return View(foundCategory);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
