using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Register()
        {
            using (UserContext db = new UserContext())
            {
                TempData["Register"] = db.UserMasters.ToList();
            }
            return View();
        }
        public IActionResult AddRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRegister([Bind] UserMaster userMaster)
        {

            if (!ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    db.UserMasters.Add(userMaster);
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
        

    }
}
