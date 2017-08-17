using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tiket_airlines.Controllers
{
    public class HomeController : Controller
    {
        tiket_airlinesEntitiesMVC db = new tiket_airlinesEntitiesMVC();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login_user()
        {            
            if (Session["user"] != null)
            {
                return RedirectToAction("dashboard", "User");
            }

            return View();
        }

        public ActionResult Login_admin()
        {
            if (Session["admin"] != null)
            {
                return RedirectToAction("dashboard_admin", "Admin");
            }

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult daftar()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Login_user(pembeli postPembeli)
        {
            
            pembeli pb = db.pembeli.SingleOrDefault(u => u.email_pembeli == postPembeli.email_pembeli);

            if (pb == null)
            {
                ViewBag.htmlError = "has-error";
                ViewBag.errorMessage = "Username atau password anda salah.";
                return View();
            }

            if (postPembeli.email_pembeli == pb.email_pembeli && postPembeli.password == pb.password)
            {
                Session["user"] = pb.nm_pembeli;
                Session["email"] = pb.email_pembeli;
                Session["id"] = pb.id_pembeli;
                return RedirectToAction("dashboard", "User");
            }
            else
            {
                ViewBag.htmlError = "has-error";
                ViewBag.errorMessage = "Username atau password anda salah";
            }
            return View();
        }


        [HttpPost]
        public ActionResult Login_admin(admin postAdmin)
        {

            admin ad = db.admin.SingleOrDefault(u => u.email_admin == postAdmin.email_admin);

            if (ad == null)
            {
                ViewBag.htmlError = "has-error";
                ViewBag.errorMessage = "Username atau password anda salah.";
                return View();
            }

            if (postAdmin.email_admin == ad.email_admin && postAdmin.pass_admin == ad.pass_admin)
            {
                Session["admin"] = ad.nm_admin;
                Session["email"] = ad.email_admin;                           
                return RedirectToAction("dashboard_admin", "Admin");
            }
            else
            {
                ViewBag.htmlError = "has-error";
                ViewBag.errorMessage = "Username atau password anda salah";
            }
            return View();
        }

    }
}