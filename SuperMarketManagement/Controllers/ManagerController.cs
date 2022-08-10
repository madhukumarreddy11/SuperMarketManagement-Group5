using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Product()
        {
            using (UserContext db = new UserContext())
            {
                TempData["Product"] = db.Products.ToList();
            }
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product pt)
        {
            if (!ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    db.Products.Add(pt);
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["AddMsg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["AddMsg"] = "0";
                    }
                }
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Product? ss = new Product();
            using (UserContext db = new UserContext())
            {
                ss = db.Products.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            using (UserContext db = new UserContext())
            {
                var Result = db.Products.Find(p.Id);
                Result.ProductName = p.ProductName;
                Result.ProductCategory = p.ProductCategory;
                Result.Quantity = p.Quantity;
                Result.Price = p.Price;
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["EditMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["EditMsg"] = "0";
                }

            }
            return RedirectToAction("Product", "Manager");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product ss = new Product();
            using (UserContext db = new UserContext())
            {
                ss = db.Products.Where(x => x.Id == id).FirstOrDefault();
                db.Products.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Product", "Manager");
        }
       
    }
}
    

