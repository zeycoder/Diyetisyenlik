using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diyetisyenlik.Models.Entity;

namespace Diyetisyenlik.Controllers
{
    public class HomeController : Controller
    {
        DietEntities1 ym = new DietEntities1();
        public ActionResult Index()
        {
            if(Session["KullaniciId"] == null)
            {
                return RedirectToAction("Giris","KayitGiris");
            }
            return View();
        }

        public ActionResult Diyet()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Giris", "KayitGiris");
            }
            var diyetler = ym.Diet.ToList();
            return View(diyetler);
        }

        [HttpGet]
        public ActionResult YeniDiyet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDiyet(Diet diet)
        {
            ym.Diet.Add(diet);
            ym.SaveChanges();
            return View();
        }
        public ActionResult Hastalik()
        {
            var hastalik = ym.Disease.ToList();
            return View(hastalik);
        }
        
        [HttpGet]
        public ActionResult YeniHastalik()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniHastalik(Disease disease)
        {
            ym.Disease.Add(disease);
            ym.SaveChanges();
            return View();
        }
        public ActionResult Hasta() /* Hastalar Lislteleme Kodu  */
        {
            var hastalar= ym.User.ToList();
            return View(hastalar);
        }

        [HttpGet]
        public ActionResult YeniHasta()
        {
            List<SelectListItem> hasta = (from i in ym.Disease.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.DiseaseName,
                                              Value = i.DiseaseId.ToString()
                                          }).ToList();
            ViewBag.hastalar = hasta;
            return View();
        }

        [HttpPost]
        public ActionResult YeniHasta(User user)
        {
            ym.User.Add(user);
            ym.SaveChanges();
            return View();
        }

        public ActionResult Cikis()
        {
            Session.Clear();
            return RedirectToAction("Giris", "KayitGiris");
        }

        
    }
}