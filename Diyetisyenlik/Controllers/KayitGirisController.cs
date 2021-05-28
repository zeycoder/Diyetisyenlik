using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diyetisyenlik.Controllers
{
    public class KayitGirisController : Controller
    {
        // GET: KayitGiris
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KayitEkle()
        {
            ViewBag.Message = "KAYIT EKLE SAYFAMIZ";
            return View();
        }
        public ActionResult Giris()
        {
            ViewBag.Message = "GİRİS YAP SAYFAMIZ";
            return View();
        }
    }
}