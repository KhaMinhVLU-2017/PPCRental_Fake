using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo_PPCRental.Models;
using System.IO;

namespace demo_PPCRental.Controllers
{
    public class HomeController : Controller
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        public ActionResult Index()
        {
            List<PROPERTY> meo = new List<PROPERTY>();
            meo = db.PROPERTies.ToList();
            return View(meo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Search(string meo)
        {
            var hey = db.PROPERTies.ToList().Where(s => s.PropertyName.ToLower().Contains(meo) || s.Content.ToLower().Contains(meo)
                ||s.DISTRICT.DistrictName.ToLower().Contains(meo));
            return View(hey);
        }
        public ActionResult Detail(int? id)
        {
            if (id != null)
            {
                PROPERTY meo = new PROPERTY();
                meo = db.PROPERTies.Find(id);
                return View(meo);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var path = "";
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"||
                            Path.GetExtension(file.FileName).ToLower()==".png"||
                            Path.GetExtension(file.FileName).ToLower()==".gif"||
                            Path.GetExtension(file.FileName).ToLower()==".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Images/"), file.FileName);
                        file.SaveAs(path);
                     
                    }
                }
            }
            return View();
        }
    }
}