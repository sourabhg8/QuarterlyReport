using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyReport.Controllers
{
    public class LandingController : Controller
    {
        // GET: Landing
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}