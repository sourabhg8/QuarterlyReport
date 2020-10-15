using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp;
using iTextSharp.text.pdf;
//using Aspose.Pdf;
//using Aspose.Pdf.Forms;
using iTextSharp.text;
using System.Text;
using MonthlyReport.Models;
using MonthlyReport.Data;
using System.Configuration;
using System.Web.Routing;

namespace MonthlyReport.Controllers
{
    public class MonthlyHomeController : Controller
    {
        public ActionResult Index()
        {

          
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    HomeDataMonthly hd = new HomeDataMonthly();
                    Home home = hd.GetHomeData();
                    return View(home);
                }
                catch(Exception ex)
                {
                    return View("Error");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult IndexEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    HomeDataMonthly hd = new HomeDataMonthly();
                    Home home = hd.GetHomeData();
                    return View("IndexEdit", home);
                }
                catch(Exception ex)
                {
                    return View("Error",ex);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult IndexEdit(Home home)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    home.quarter = string.IsNullOrEmpty(home.quarter) ? string.Empty : home.quarter;
                    HomeDataMonthly hd = new HomeDataMonthly();
                    hd.UpdateHomeData(home);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("Error", ex);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public T RunControllerAsCurrentUser<T>(T controller, string ControllerName) where T : ControllerBase
        {
            RouteData route = new RouteData();
            route.Values.Add("action", "Print");
            route.Values.Add("controller", ControllerName);
            var newContext = new ControllerContext(new HttpContextWrapper(System.Web.HttpContext.Current), route ?? new RouteData(), controller);
            controller.ControllerContext = newContext;
            return controller;
        }
        public ActionResult DownloadPdf()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    string HtmlContent = string.Empty;
                    HtmlContent = HtmlContent + Print();
                    var financialController = RunControllerAsCurrentUser(new MonthlyFinancialController(), "MonthlyFinancial");
                    HtmlContent = HtmlContent + financialController.Print();

                    var accountsController = RunControllerAsCurrentUser(new MonthlyAccountsController(), "MonthlyAccounts");
                    HtmlContent = HtmlContent + accountsController.Print();


                    var operationController = RunControllerAsCurrentUser(new MonthlyOperationsController(), "MonthlyOperations");
                    HtmlContent = HtmlContent + operationController.Print();

                    var leasingController = RunControllerAsCurrentUser(new MonthlyLeasingController(), "MonthlyLeasing");
                    HtmlContent = HtmlContent + leasingController.Print();
                    var specController = RunControllerAsCurrentUser(new MonthlySpecialtyLeasingController(), "MonthlySpecialtyLeasing");
                    HtmlContent = HtmlContent + specController.Print();

                    var financialLoanController = RunControllerAsCurrentUser(new MonthlyFinancialLoanController(), "MonthlyFinancialLoan");
                    HtmlContent = HtmlContent + financialLoanController.Print();
                    ;
                    new PageOrientations().ManipulatePdf(HtmlContent, Server.MapPath("~/"));
                    return File(Server.MapPath("~/Pdf/Test.pdf"), "application/pdf", "Monthly Management Report.pdf");
                }
                catch (Exception ex)
                {
                    return View("Error", ex);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Archives()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                List<FileInfo> lst = new List<FileInfo>();
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Archive/Monthly"));
                foreach (FileInfo fi in di.GetFiles())
                {
                    lst.Add(fi);
                }
                lst = lst.OrderByDescending(x => x.LastWriteTime).ToList();
                return View(lst);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult ArchiveReport()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    string HtmlContent = string.Empty;
                    HtmlContent = HtmlContent + Print();
                    var financialController = RunControllerAsCurrentUser(new MonthlyFinancialController(), "MonthlyFinancial");
                    HtmlContent = HtmlContent + financialController.Print();

                    var accountsController = RunControllerAsCurrentUser(new MonthlyAccountsController(), "MonthlyAccounts");
                    HtmlContent = HtmlContent + accountsController.Print();


                    var operationController = RunControllerAsCurrentUser(new MonthlyOperationsController(), "MonthlyOperations");
                    HtmlContent = HtmlContent + operationController.Print();

                    var leasingController = RunControllerAsCurrentUser(new MonthlyLeasingController(), "MonthlyLeasing");
                    HtmlContent = HtmlContent + leasingController.Print();
                    var specController = RunControllerAsCurrentUser(new MonthlySpecialtyLeasingController(), "MonthlySpecialtyLeasing");
                    HtmlContent = HtmlContent + specController.Print();

                    var financialLoanController = RunControllerAsCurrentUser(new MonthlyFinancialLoanController(), "MonthlyFinancialLoan");
                    HtmlContent = HtmlContent + financialLoanController.Print();


                    new PageOrientations().ManipulatePdf(HtmlContent, Server.MapPath("~/"));
                    var result = TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now.ToUniversalTime(),
                                    TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
                    string fileName = "Monthly Report " + result.ToString("yyyy-dd-MM-HH-mm-ss") + ".pdf";
                    System.IO.File.Copy(Server.MapPath("~/Pdf/Test.pdf"), Server.MapPath("~/Archive/Monthly/" + fileName));

                    return RedirectToAction("Archives");
                }
                catch (Exception ex)
                {
                    return View("Error", ex);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult DownloadArchive(string fileName)
        {
            return File(Server.MapPath("~/Archive/Monthly/" + fileName), "application/pdf", "Monthly Management Report Archive.pdf");
        }

        public ActionResult DeleteArchive(string fileName)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    FileInfo fi = new FileInfo(Server.MapPath("~/Archive/Monthly/" + fileName));
                    fi.Delete();
                    return RedirectToAction("Archives");
                }
                catch (Exception ex)
                {
                    return View("Error", ex);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [NonAction]
        public string Print()
        {
            HomeDataMonthly hd = new HomeDataMonthly();
            Home home = hd.GetHomeData();
            string s = new PageOrientations().RenderRazorViewToString(this, "Print", home);
            return s;

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