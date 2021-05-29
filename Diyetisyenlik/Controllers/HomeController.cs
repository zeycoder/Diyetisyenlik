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
        DietEntities ym = new DietEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Diyet()
        {
            var diyetler = ym.Diet.ToList();

            return View(diyetler);
        }

        public ActionResult Hastalik()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}