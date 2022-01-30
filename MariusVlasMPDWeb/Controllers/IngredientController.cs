using MariusVlasMPDWeb.Data;
using MariusVlasMPDWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MariusVlasMPDWeb.Controllers
{
    public class IngredientController : Controller
    {
        private readonly ApplicationDbContext _db;

        public IngredientController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Ingredient> objIngredientList = _db.Ingredients;
            return View(objIngredientList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingredient value)
        {

                _db.Ingredients.Add(value);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            var foundIngredient = _db.Ingredients.Find(id);

            if (foundIngredient == null)
            {
                return NotFound();
            }

            return View(foundIngredient);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ingredient value)
        {

//            if (ModelState.IsValid)
  //          {
                _db.Ingredients.Update(value);
                _db.SaveChanges();
                return RedirectToAction("Index");
    //        }
      //      else
        //    {
          //      return View(value);
        //    }
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var foundIngredient = _db.Ingredients.Find(id);

            if (foundIngredient == null)
            {
                return NotFound();
            }

            return View(foundIngredient);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Ingredients.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Ingredients.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
