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
        DietEntities1 d = new DietEntities1();
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
            var kullanici2 = d.User.FirstOrDefault(x => x.IdentityNumber == u.IdentityNumber && x.password == u.password);
            
            if (kullanici2 != null)
            {

                Session["KullaniciId"] = kullanici2.UserId;
                Session["Unvan"] = kullanici2.authority;
                return RedirectToAction("Diyet", "Home");
            }
            else
            {
                return View();
            }
        }
        
    }
}