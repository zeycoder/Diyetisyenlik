using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diyetisyenlik.Models.Entity;

namespace Diyetisyenlik.Controllers
{
    public class KayitGirisController : Controller
    {
        // GET: KayitGiris
        DietEntities ym = new DietEntities();
        public ActionResult Index()
        {
            //if (Session["KullaniciId"] == null)
            //{
            //    return RedirectToAction("Giris", "GirisKayit");
            //}
            //int Id = Convert.ToInt32(Session["KullaniciId"]);
            return View();
        }
        public ActionResult KayitEkle()
        {
            ViewBag.Message = "KAYIT EKLE SAYFAMIZ";
            return View();
        }
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(User u)
        {
         
            var kullanici = ym.User.FirstOrDefault(x => x.IdentityNumber == u.IdentityNumber && x.password == u.password);
            if (kullanici != null)
            {

                //Session["KullaniciId"] = kullanici.UserId;
                //Session["Unvan"] = kullanici.authority;
                return RedirectToAction("Diyet", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}