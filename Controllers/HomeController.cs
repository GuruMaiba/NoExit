using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoExit.Models;

namespace NoExit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var a = new DataEntity();
            a.Dispose();
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult AboutApocalypse()
        {


            return View();
        }
        public ActionResult AboutShiza()
        {


            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }

        public ActionResult GiftCards()
        {


            return View();
        }
    }
}