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
        DietEntities2 ym = new DietEntities2();
        public ActionResult Index()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Giris", "KayitGiris");
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
            return RedirectToAction("Diyet");
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
            return RedirectToAction("Hastalik");
        }
        public ActionResult Hasta() /* Hastalar Lislteleme Kodu  */
        {
            var hastalar = ym.Sick.ToList();
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

            List<SelectListItem> diyet = (from i in ym.Diet.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.DietName,
                                              Value = i.DietId.ToString()
                                          }).ToList();
            ViewBag.diyetler = diyet;
            return View();
        }

        [HttpPost]
        public ActionResult YeniHasta(Sick sick)
        {
            ym.Sick.Add(sick);
            ym.SaveChanges();
            return RedirectToAction("Hasta");
        }

        public ActionResult Cikis()
        {
            Session.Clear();
            return RedirectToAction("Giris", "KayitGiris");
        }

        public ActionResult Diyetisyen()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Giris", "KayitGiris");
            }
            var diyetisyenler = ym.User.ToList();
            return View(diyetisyenler);
        }

        [HttpGet]
        public ActionResult YeniDiyetisyen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDiyetisyen(User user)
        {
            ym.User.Add(user);
            ym.SaveChanges();
            return RedirectToAction("Diyetisyen");
        }
        public ActionResult DiyetSil(int id)
        {
            var sil = ym.Diet.Find(id);
            ym.Diet.Remove(sil);
            ym.SaveChanges();
            return RedirectToAction("Diyet", "Home");
        }
        public ActionResult DiyetisyenSil(int id)
        {
            var sil = ym.User.Find(id);
            ym.User.Remove(sil);
            ym.SaveChanges();
            return RedirectToAction("Diyetisyen", "Home");
        }
        public ActionResult HastalikSil(int id)
        {
            var sil = ym.Disease.Find(id);
            ym.Disease.Remove(sil);
            ym.SaveChanges();
            return RedirectToAction("Hastalik", "Home");
        }
        public ActionResult HastaSil(int id)
        {
            var sil = ym.Sick.Find(id);
            ym.Sick.Remove(sil);
            ym.SaveChanges();
            return RedirectToAction("Hasta", "Home");
        }


        public ActionResult DiyetGuncelle(int id)
        {
            var ktgr = ym.Diet.Find(id);
            return View("DiyetGuncelle", ktgr);
        }
        public ActionResult DiyetisyenGuncelle(int id)
        {
            var ktgr = ym.User.Find(id);
            return View("DiyetisyenGuncelle", ktgr);
        }
        public ActionResult HastaGuncelle(int id)
        {
            var ktgr = ym.Sick.Find(id);
            return View("HastaGuncelle", ktgr);
        }

        public ActionResult HastalikGuncelle(int id)
        {
            var ktgr = ym.Disease.Find(id);
            return View("HastalikGuncelle", ktgr);
        }
        public ActionResult dytGuncelle(Diet p1)
        {
            var dyt = ym.Diet.Find(p1.DietId);
            dyt.DietName = p1.DietName;
            dyt.DietMeal = p1.DietMeal;
            dyt.Day1 = p1.Day1;
            dyt.Day2 = p1.Day2;
            dyt.Day3 = p1.Day3;
            dyt.Day4 = p1.Day4;
            dyt.Day5 = p1.Day5;
            dyt.Day6 = p1.Day6;
            dyt.Sick = p1.Sick;
            ym.SaveChanges();
            return RedirectToAction("Diyet");
        }
        public ActionResult dytsynGuncelle(User u1)
        {
            var dytsyn = ym.User.Find(u1.UserId);
            dytsyn.FirstName = u1.FirstName;
            dytsyn.LastName = u1.LastName;
            dytsyn.password = u1.password;
            ym.SaveChanges();
            return RedirectToAction("Diyetisyen");
        }
        public ActionResult hstGuncelle(Sick s1)
        {
            var hst = ym.Sick.Find(s1.SickId);
            hst.FirstName = s1.FirstName;
            hst.LastName = s1.LastName;
            hst.Diet.DietName = s1.Diet.DietName;
            hst.Disease.DiseaseName = s1.Disease.DiseaseName;
            ym.SaveChanges();
            return RedirectToAction("Hasta");
        }
        public ActionResult hstlkGuncelle(Disease d1)
        {
            var hstlk = ym.Disease.Find(d1.DiseaseId);
            hstlk.DiseaseName = d1.DiseaseName;
            ym.SaveChanges();
            return RedirectToAction("Hastalik");

        }
    }
}