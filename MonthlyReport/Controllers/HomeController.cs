using System;
using System.Web.Mvc;
using MonthlyReport.Models;
using MonthlyReport.Data;
using System.Collections.Generic;
using System.Web.Routing;
using System.Web;
using System.IO;
using System.Linq;

namespace MonthlyReport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    
                    HomeData hd = new HomeData();
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
                    HomeData hd = new HomeData();
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
                    HomeData hd = new HomeData();
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

        public T RunControllerAsCurrentUser<T>(T controller,  string ControllerName) where T : ControllerBase
        {
            RouteData route = new RouteData();
            route.Values.Add("action", "Print");
            route.Values.Add("controller", ControllerName);
            var newContext = new ControllerContext(new HttpContextWrapper(System.Web.HttpContext.Current), route ?? new RouteData(), controller);
            controller.ControllerContext = newContext;
            return controller;
        }

        public ActionResult ArchiveReport()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    string HtmlContent = string.Empty;
                    HtmlContent = HtmlContent + Print();

                    var financialController = RunControllerAsCurrentUser(new FinancialController(), "Financial");
                    HtmlContent = HtmlContent + financialController.Print();

                    var accountsController = RunControllerAsCurrentUser(new AccountsController(), "Accounts");
                    HtmlContent = HtmlContent + accountsController.Print();

                    var someController = RunControllerAsCurrentUser(new LegalController(), "Legal");
                    HtmlContent = HtmlContent + someController.Print();

                    var salesController = RunControllerAsCurrentUser(new SalesController(), "Sales");
                    HtmlContent = HtmlContent + salesController.Print();

                    var customerController = RunControllerAsCurrentUser(new CustomerServiceController(), "CustomerService");
                    HtmlContent = HtmlContent + customerController.Print();

                    var marketingController = RunControllerAsCurrentUser(new MarketingController(), "Marketing");
                    HtmlContent = HtmlContent + marketingController.Print();

                    var operationController = RunControllerAsCurrentUser(new OperationsController(), "Operations");
                    HtmlContent = HtmlContent + operationController.Print();

                    var leasingController = RunControllerAsCurrentUser(new LeasingController(), "Leasing");
                    HtmlContent = HtmlContent + leasingController.Print();
                    var specController = RunControllerAsCurrentUser(new SpecialtyLeasingController(), "SpecialtyLeasing");
                    HtmlContent = HtmlContent + specController.Print();

                    var financialLoanController = RunControllerAsCurrentUser(new FinancialLoanController(), "FinancialLoan");
                    HtmlContent = HtmlContent + financialLoanController.Print();

                    new PageOrientations().ManipulatePdf(HtmlContent, Server.MapPath("~/"));
                    var result = TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now.ToUniversalTime(),
                                    TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
                    string fileName = "Quaterly Report " + result.ToString("yyyy-dd-MM-HH-mm-ss") + ".pdf";
                    System.IO.File.Copy(Server.MapPath("~/Pdf/Test.pdf"), Server.MapPath("~/Archive/Quaterly/" + fileName));

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


        public ActionResult DownloadPdf()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "6")
                {
                    try
                    {
                        string HtmlContent = string.Empty;
                        HtmlContent = HtmlContent + Print();

                        var financialController = RunControllerAsCurrentUser(new FinancialController(), "Financial");
                        HtmlContent = HtmlContent + financialController.Print();

                        var accountsController = RunControllerAsCurrentUser(new AccountsController(), "Accounts");
                        HtmlContent = HtmlContent + accountsController.Print();

                        var someController = RunControllerAsCurrentUser(new LegalController(), "Legal");
                        HtmlContent = HtmlContent + someController.Print();

                        var salesController = RunControllerAsCurrentUser(new SalesController(), "Sales");
                        HtmlContent = HtmlContent + salesController.Print();

                        var customerController = RunControllerAsCurrentUser(new CustomerServiceController(), "CustomerService");
                        HtmlContent = HtmlContent + customerController.Print();

                        var marketingController = RunControllerAsCurrentUser(new MarketingController(), "Marketing");
                        HtmlContent = HtmlContent + marketingController.Print();

                        var operationController = RunControllerAsCurrentUser(new OperationsController(), "Operations");
                        HtmlContent = HtmlContent + operationController.Print();

                        var leasingController = RunControllerAsCurrentUser(new LeasingController(), "Leasing");
                        HtmlContent = HtmlContent + leasingController.Print();
                        var specController = RunControllerAsCurrentUser(new SpecialtyLeasingController(), "SpecialtyLeasing");
                        HtmlContent = HtmlContent + specController.Print();

                        var financialLoanController = RunControllerAsCurrentUser(new FinancialLoanController(), "FinancialLoan");
                        HtmlContent = HtmlContent + financialLoanController.Print();

                        new PageOrientations().ManipulatePdf(HtmlContent, Server.MapPath("~/"));
                        return File(Server.MapPath("~/Pdf/Test.pdf"), "application/pdf", "Quaterly Management Report.pdf");
                    }
                    catch (Exception ex)
                    {
                        return View("Error", ex);
                    }
                }
                else
                {
                    return View("Accessdenied");
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
            HomeData hd = new HomeData();
            Home home = hd.GetHomeData();
            string s = new PageOrientations().RenderRazorViewToString(this, "Print", home);
            return s;
          
        }


        public ActionResult Archives()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                    List<FileInfo> lst = new List<FileInfo>();
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Archive/Quaterly"));
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
        public ActionResult DownloadArchive(string fileName)
        {
            return File(Server.MapPath("~/Archive/Quaterly/" + fileName), "application/pdf", "Quaterly Management Report Archive.pdf");
        }

        public ActionResult DeleteArchive(string fileName)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    FileInfo fi = new FileInfo(Server.MapPath("~/Archive/Quaterly/" + fileName));
                    fi.Delete();
                    return RedirectToAction("Archives");
                }
                catch(Exception ex)
                {
                    return View("Error", ex);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}