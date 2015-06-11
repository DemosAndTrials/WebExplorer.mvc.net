using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExplorer.Models;

namespace WebExplorer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ExplorerViewModel model = new ExplorerViewModel();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}