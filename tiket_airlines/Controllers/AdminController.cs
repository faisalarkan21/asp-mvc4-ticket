using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiket_airlines.Helper;
using tiket_airlines.Models;
using tiket_airlines.Security;

namespace tiket_airlines.Controllers
{



    [AuthorizationFilterAdmin]
    public class AdminController : Controller
    {

        tiket_airlinesEntitiesMVC db = new tiket_airlinesEntitiesMVC();
        // GET: Admin

        public ActionResult dashboard_admin()
        {

            Statistik statistik = new Statistik();

            statistik.total_user = db.detil_pesan_tiket.Count();
            statistik.user_lunas = db.detil_pesan_tiket.Where(u => u.total_transfer != 0).Count();
            statistik.user_belum_lunas = db.detil_pesan_tiket.Where(u => u.total_transfer == 0).Count();
            statistik.uang_estimasi = ConvertCurrency.ToRupiah(db.detil_pesan_tiket.Select(u => u.harga_tiket).Sum());
            statistik.uang_diterima = ConvertCurrency.ToRupiah(db.detil_pesan_tiket.Select(u => u.total_transfer).Sum());
            
            decimal estimasi = db.detil_pesan_tiket.Select(u => u.harga_tiket).Sum();
            decimal uangDiterima = db.detil_pesan_tiket.Select(u => u.total_transfer).Sum();

            statistik.selisiPendapatan = ConvertCurrency.ToRupiah(estimasi - uangDiterima);
            statistik.user_validasi = db.pembeli_validasi.Where(u => u.uang_transfer_validasi != null).Count();
            
            return View(statistik);
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