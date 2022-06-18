using QuickKartMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickKartMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(QuickKartMVC.Models.User userModel)
        {
            using (QuickKartDBEntities db = new QuickKartDBEntities())
            {
                var userDetails = db.Users.Where(x => x.EmailId == userModel.EmailId && x.UserPassword == userModel.UserPassword).FirstOrDefault();
                if(userDetails == null)
                {
                    return RedirectToAction("Index", "ReLogin");
                }
                else
                {
                    Session["userId"] = userDetails.RoleId;
                    return RedirectToAction("Index", "User");
                }
            }
        }
    }
}