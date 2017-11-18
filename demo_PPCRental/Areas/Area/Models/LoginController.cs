using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo_PPCRental.Models;

namespace demo_PPCRental.Areas.Area.Models
{
    public class LoginController : Controller
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        // GET: Area/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txt_user,string txt_pass)
        {
            USER meo = db.USERs.FirstOrDefault(s => s.Email == txt_user && s.Password == txt_pass);
            if (meo==null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
          
        }
    }
}