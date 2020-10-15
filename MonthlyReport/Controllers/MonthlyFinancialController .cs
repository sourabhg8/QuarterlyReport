using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Models;
using MonthlyReport.Data;

namespace MonthlyReport.Controllers
{
    public class MonthlyFinancialController : Controller
    {
        // GET: Financial
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {

                    try
                    {
                        FinancialDataMonthly fd = new FinancialDataMonthly();
                        Financial financial = fd.GetFinancialData();
                        return View(financial);
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
        public ActionResult FinancialEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "2")
                {
                    try
                    {
                        FinancialDataMonthly fd = new FinancialDataMonthly();
                        Financial financial = fd.GetFinancialData();
                        return View(financial);
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
        public ActionResult FinancialEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    Financial financial = new Financial();
                    financial.importantUpdate = form["importantUpdate"];
                    financial.masterPlanUpdate = form["masterPlanUpdate"];
                    List<Revenue> revenues = new List<Revenue>();
                    for (int i = 1; i <= 11; i++)
                    {
                        Revenue obj = new Revenue();
                        obj.act = form["act" + i.ToString()];
                        obj.bud = form["bud" + i.ToString()];
                        obj.var = form["var" + i.ToString()];
                        obj.actfor = form["actfor" + i.ToString()];
                        obj.budfor = form["budfor" + i.ToString()];
                        obj.varfor = form["varfor" + i.ToString()];
                        obj.comment = form["comment" + i.ToString()];
                        obj.action = form["action" + i.ToString()];
                        revenues.Add(obj);
                    }
                    financial.revenues = revenues;
                    FinancialDataMonthly fd = new FinancialDataMonthly();
                    fd.updateFinancialData(financial);
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
            FinancialDataMonthly fd = new FinancialDataMonthly();
            Financial financial = fd.GetFinancialData();
            return new PageOrientations().RenderRazorViewToString(this, "Print", financial);

        }
    }
}