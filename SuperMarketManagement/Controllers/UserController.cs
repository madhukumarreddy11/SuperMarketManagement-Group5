using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            using (UserContext db = new UserContext())
            {
                TempData["Register"] = db.UserMasters.ToList();
            }
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp([Bind] UserMaster userMaster)
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login lg)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users.Where(x => x.UserId == lg.UserId && x.Password == lg.Password);
                if (users.Count() > 0)
                {
                    var user = users.FirstOrDefault();

                    HttpContext.Session.SetInt32("role", user.RoleId);
                    HttpContext.Session.SetString("name", user.Name);
                    ModelState.Clear();

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["msg"] = "1";
                }
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult Cancel(int id)
        {
            UserMaster ss = new UserMaster();
            using (UserContext db = new UserContext())
            {
                ss = db.UserMasters.Where(x => x.Id == id).FirstOrDefault();
                db.UserMasters.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                //object TempData = null;
                TempData["CancelMsg"] = "1";
                 ModelState.Clear();
                }

            }
            return RedirectToAction("Register", "User");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }
    }
}
