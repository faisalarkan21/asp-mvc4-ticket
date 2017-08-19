using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiket_airlines.Helper;
using tiket_airlines.Models;

namespace tiket_airlines.Controllers
{
    public class HomeController : Controller
    {
        static tiket_airlinesEntitiesMVC db = new tiket_airlinesEntitiesMVC();

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

        [HttpGet]
        public JsonResult HargaBandara(int id)
        {

            var dataPajak = db.pajak_bandara.SingleOrDefault(u => u.id_bandara == id);
            string harga = ConvertCurrency.ToRupiah(dataPajak.pajak);


            return Json(new { harga = harga }, JsonRequestBehavior.AllowGet);
        }


        public static IEnumerable<SelectListItem> getBandara()
        {
            IEnumerable<SelectListItem> items = db.pajak_bandara.Select(c => new SelectListItem
            {
                Value = c.id_bandara.ToString(),
                Text = c.nm_bandara

            });

            return items;

        }


        public ActionResult daftar()
        {


            return View();
        }

        [HttpPost]
        public ActionResult daftar(Gabungan gabungan)
        {

            // table Pembeli
            var dbPembeli = new pembeli
            {
                nm_pembeli = gabungan.tblPembeli.nm_pembeli,
                email_pembeli = gabungan.tblPembeli.email_pembeli,
                password = gabungan.tblPembeli.password,
                hp_pembeli = gabungan.tblPembeli.hp_pembeli,
                gd_pembeli = gabungan.tblPembeli.gd_pembeli
            };

            db.pembeli.Add(dbPembeli);

            //table tgl Order
            tgl_pesan tgl_table = new tgl_pesan();
            tgl_table.tgl_order = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            var dbTglPesan = new tgl_pesan
            {
                tgl_order = tgl_table.tgl_order
            };

            db.tgl_pesan.Add(dbTglPesan);


          

            // table Detail Pembeli
            var dbPembeliDetail = new detil_pesan_tiket
            {
                harga_tiket = ConvertCurrency.ToAngka(gabungan.rp_harga_tiket),
                total_transfer = gabungan.tblDetailTiket.total_transfer,
                pilihan_bank = gabungan.tblDetailTiket.pilihan_bank,
                bandara_berangkat = gabungan.tblDetailTiket.bandara_berangkat,
                bandara_tujuan = gabungan.tblDetailTiket.bandara_tujuan,
                status = gabungan.tblDetailTiket.status
            };

            db.detil_pesan_tiket.Add(dbPembeliDetail);



            // table Validasi Pembeli
            var dbValidasi = new pembeli_validasi
            {
                nm_pembeli = gabungan.tblPembeli.nm_pembeli,
                email_pembeli = gabungan.tblPembeli.email_pembeli,
                hp_pembeli = gabungan.tblPembeli.hp_pembeli,
                uang_transfer_validasi = null,
                pilihan_bank = null


            };

            db.pembeli_validasi.Add(dbValidasi);

            db.SaveChanges();


            return RedirectToAction("login_user", "Home");

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