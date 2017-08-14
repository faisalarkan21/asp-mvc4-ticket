using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tiket_airlines.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult dashboard()
        {
            return View();
        }

        public ActionResult data_pembeli()
        {
            return View();
        }


        public ActionResult ketentuan()
        {
            return View();
        }


        public ActionResult validasi_tiket()
        {
            return View();
        }
    }
}