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



    }
}