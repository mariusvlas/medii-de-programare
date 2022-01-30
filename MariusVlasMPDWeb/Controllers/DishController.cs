using MariusVlasMPDWeb.Data;
using MariusVlasMPDWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MariusVlasMPDWeb.Controllers
{
    public class DishController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DishController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Dish> objList = _db.Dishes;
            return View(objList);

        }

        // GET
        public IActionResult Create()
        {
            IEnumerable<Category> categories = _db.Categories;
            TempData["categories"] = categories;
            IEnumerable<Ingredient> ingredients = _db.Ingredients;
            TempData["ingredients"] = ingredients;
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dish value)
        {

            IEnumerable<Category> categories = _db.Categories;
            TempData["categories"] = categories;
            IEnumerable<Ingredient> ingredients = _db.Ingredients;
            TempData["ingredients"] = ingredients;

            if (ModelState.IsValid)
            {
                _db.Dishes.Add(value);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                _db.Dishes.Add(value);
                _db.SaveChanges();
                return View(value);
            }
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var foundDish = _db.Dishes.Find(id);

            List<string> list = new List<string>();
            IEnumerable<Category> categories = _db.Categories;
            TempData["categories"] = categories;
            IEnumerable<Ingredient> ingredients = _db.Ingredients;
            TempData["ingredients"] = ingredients;
            if (foundDish == null)
            {
                return NotFound();
            }

            return View(foundDish);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dish value)
        {

            IEnumerable<Category> categories = _db.Categories;
            TempData["categories"] = categories;
            IEnumerable<Ingredient> ingredients = _db.Ingredients;
            TempData["ingredients"] = ingredients;
            if (ModelState.IsValid)
            {
                _db.Dishes.Update(value);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                _db.Dishes.Update(value);
                _db.SaveChanges();
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
            var foundDish = _db.Dishes.Find(id);

            if (foundDish == null)
            {
                return NotFound();
            }

            return View(foundDish);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Dishes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Dishes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
