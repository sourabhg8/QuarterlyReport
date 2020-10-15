using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Models;
using MonthlyReport.Data;

namespace MonthlyReport.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                        Salesdata sd = new Salesdata();
                        Sales sales = new Sales();
                        sales.SquareSales = sd.GetSquareSalesdata();
                        sales.LifeStyles = sd.GetLifeStyledata();
                        sales.Comments = sd.GetSalesComments();
                        return View(sales);
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
        [HttpGet]
        public ActionResult SquareEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "4")
                {
                    try
                    {
                        Salesdata sd = new Salesdata();
                        List<SquareSales> squareSales = sd.GetSquareSalesdata();
                        ViewBag.comment = sd.GetSalesComments()[0].comment;
                        return View(squareSales);
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

        [HttpGet]
        public ActionResult LifeStyleEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "4")
                {
                    try
                    {
                        Salesdata sd = new Salesdata();
                        List<SquareSales> squareSales = sd.GetLifeStyledata();
                        ViewBag.comment = sd.GetSalesComments()[1].comment;
                        return View(squareSales);
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

        [HttpGet]
        public ActionResult CommentsEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "4")
                {
                    try
                    {
                        Salesdata sd = new Salesdata();
                        List<SalesComments> squareSales = sd.GetSalesComments();
                        return View(squareSales);
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

        [HttpPost] 
        public ActionResult SquareEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<SquareSales> lst = new List<SquareSales>();
                    for (int i = 1; i <= 3; i++)
                    {
                        SquareSales obj = new SquareSales();
                        obj.Tenant = form["Tenant" + i];
                        obj.Gla = form["Gla" +i];
                        obj.sales1 = form["sales1" + i];
                        obj.Sales2 = form["Sales2" + i];
                        obj.Sales3 = form["Sales3" + i];
                        obj.Psf1 = form["Psf1" + i];
                        obj.PSF2 = form["PSF2" + i];
                        obj.PSF3 = form["PSF3" + i];
                        obj.LY1 = form["LY1" + i];
                        obj.LY2 = form["LY2" + i];
                        obj.LY3 = form["LY3" + i];
                        obj.GrossRent = form["GrossRent" + i];
                        obj.PctRent = form["PctRent" + i];
                        obj.Groc = form["Groc" + i];
                        lst.Add(obj);
                    }
                    Salesdata sd = new Salesdata();
                    sd.UpdateSquareSales(lst, form["comment"]);
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

        [HttpPost] 
        public ActionResult LifeStyleEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<SquareSales> lst = new List<SquareSales>();
                    for (int i = 1; i <= 3; i++)
                    {
                        SquareSales obj = new SquareSales();
                        obj.Tenant = form["Tenant" + i];
                        obj.Gla = form["Gla" + i];
                        obj.sales1 = form["sales1" + i];
                        obj.Sales2 = form["Sales2" + i];
                        obj.Sales3 = form["Sales3" + i];
                        obj.Psf1 = form["Psf1" + i];
                        obj.PSF2 = form["PSF2" + i];
                        obj.PSF3 = form["PSF3" + i];
                        obj.LY1 = form["LY1" + i];
                        obj.LY2 = form["LY2" + i];
                        obj.LY3 = form["LY3" + i];
                        obj.GrossRent = form["GrossRent" + i];
                        obj.PctRent = form["PctRent" + i];
                        obj.Groc = form["Groc" + i];
                        lst.Add(obj);
                    }
                    Salesdata sd = new Salesdata();
                    sd.UpdateLifeStyleSales(lst, form["comment"]);
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
        [HttpPost]
        public ActionResult CommentsEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<SalesComments> lst = new List<SalesComments>();
                    for (int i = 1; i <= 2; i++)
                    {
                        SalesComments obj = new SalesComments();
                        obj.comment = form["comment" + i];
                        obj.sector = form["sector" + i];
                        obj.commentid = i + 2;
                        lst.Add(obj);
                    }
                    Salesdata sd = new Salesdata();
                    foreach(SalesComments obj in lst)
                    {
                        sd.UpdateCommentSales(obj);
                    }
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

        [NonAction]
        public string Print()
        {
            Salesdata sd = new Salesdata();
            Sales sales = new Sales();
            sales.SquareSales = sd.GetSquareSalesdata();
            sales.LifeStyles = sd.GetLifeStyledata();
            sales.Comments = sd.GetSalesComments();
            return new PageOrientations().RenderRazorViewToString(this, "Print", sales);
           
        }
    }
}