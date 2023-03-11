using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NoExit.Areas.Admin.Controllers
{
    public class MyString
    {
        public string val { get; set; }
    }
    public class HomeController : Controller
    {

        
        [HttpGet]
        public ActionResult Index()
        {
            
            return View(new MyString() { val="" });
        }
        [HttpPost]
        public ActionResult Index(MyString pass)
        {
            if (pass.val== "Noexit675503")
                FormsAuthentication.SetAuthCookie("YA", true);
            return RedirectToAction("Index","QuestRequests");
        }
        

    }
}