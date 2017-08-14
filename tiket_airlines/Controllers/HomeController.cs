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
            return View();
        }

        public ActionResult Login_admin()
        {
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

            }

            if (postPembeli.email_pembeli == pb.email_pembeli && postPembeli.password == pb.password)
            {

                return RedirectToAction("dashboard", "User");


            }
            else
            {

                ViewBag.htmlError = "has-error";
                ViewBag.errorMessage = "Username atau password anda salah.";


            }



            return View();
        }

    }
}