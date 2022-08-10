using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.Controllers
{
    public class CashierController : Controller
    {
        public IActionResult Customer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Customer([Bind] Customer customer)
        {

            if (!ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    db.Customers.Add(customer);
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
        public IActionResult Bill()
        {
            using (UserContext db = new UserContext())
            {
                TempData["Bill"] = db.Bills.ToList();
            }
            return View();
        }
        public IActionResult AddBill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBill([Bind] Bill bill)
        {

            if (!ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    db.Bills.Add(bill);
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
        public IActionResult EditBill(int id)
        {
            Bill? ss = new Bill
                ();
            using (UserContext db = new UserContext())
            {
                ss = db.Bills.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult EditBill(Bill b)
        {
            using (UserContext db = new UserContext())
            {
                var Result = db.Bills.Find(b.Id);
                Result.ProductName = b.ProductName;
                Result.ProductCategory = b.ProductCategory;
                Result.Quantity = b.Quantity;
                Result.Price = b.Price;
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
            return RedirectToAction("Bill", "Cashier");
        }
    }
}
