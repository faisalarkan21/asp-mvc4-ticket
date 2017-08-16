using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiket_airlines.Security;

namespace tiket_airlines.Controllers
{

    [AuthorizationFilterAdmin]
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult dashboard_admin()
        {
            return View();
        }

        public ActionResult kotak_validasi()
        {
            return View();
        }

        public ActionResult semua_pembeli()
        {
            return View();
        }
        public ActionResult pembeli_lunas()
        {
            return View();
        }

        public ActionResult pembeli_belum_lunas()
        {
            return View();
        }
        public ActionResult user_detail()
        {
            return View();
        }

        public ActionResult log_out()
        {
            Session.Remove("admin");
            Session.Remove("email");           
            return RedirectToAction("index", "Home");
        }




    }
}