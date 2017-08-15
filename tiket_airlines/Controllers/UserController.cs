using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiket_airlines.Models;
using tiket_airlines.Security;

namespace tiket_airlines.Controllers
{
    [AuthorizationFilterUser]
    public class UserController : Controller
    {
        tiket_airlinesEntitiesMVC db = new tiket_airlinesEntitiesMVC();

        // GET: User
        public ActionResult dashboard()
        {
            return View();
        }

        public ActionResult data_pembeli()
        {

            Gabungan gabungan = new Gabungan();
            int idUser = (int)Session["id"];
            //Gabungan. student = db.Students.Find(id);
            gabungan.tblPembeli = db.pembeli.Find(idUser);
            gabungan.tblDetailTiket = db.detil_pesan_tiket.Find(idUser);

            return View(gabungan);
        }

        [HttpPost]
        public ActionResult data_pembeli(int id, Gabungan gabungan)
        {

            var user = db.pembeli.FirstOrDefault(u => u.id_pembeli == id);
            user.nm_pembeli = gabungan.tblPembeli.nm_pembeli;
            user.email_pembeli = gabungan.tblPembeli.email_pembeli;
            user.hp_pembeli = gabungan.tblPembeli.hp_pembeli;
            db.SaveChanges();

            return RedirectToAction("data_pembeli", "User");
        }


        public ActionResult ketentuan()
        {
            return View();
        }


        public ActionResult validasi_tiket()
        {


            Gabungan gabungan = new Gabungan();
            int idUser = (int)Session["id"];
            //Gabungan. student = db.Students.Find(id);
            gabungan.tblPembeli = db.pembeli.Find(idUser);
            gabungan.tblDetailTiket = db.detil_pesan_tiket.Find(idUser);
            gabungan.tblValidasi = db.pembeli_validasi.Find(idUser);

            return View(gabungan);

        }

        [HttpPost]
        public ActionResult validasi_tiket(int id, Gabungan gabungan)
        {


            var userValidasi = db.pembeli_validasi.FirstOrDefault(u => u.id_pembeli == id);
            userValidasi.pilihan_bank = gabungan.tblDetailTiket.pilihan_bank;
            userValidasi.uang_transfer_validasi = gabungan.tblDetailTiket.harga_tiket;
            db.SaveChanges();

            return RedirectToAction("validasi_tiket", "User");

        }

    }
}