using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Data;
using MonthlyReport.Models;

namespace MonthlyReport.Controllers
{
    public class FinancialLoanController : Controller
    {
        // GET: FinancialLoan
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
               
                    try
                    {
                        FinanacialLoanData fld = new FinanacialLoanData();
                        List<FinancialLoan> lst = fld.GetFinancialLoanData();
                        return View(lst);
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
        public ActionResult FinancialLoanEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "9")
                {
                    try
                    {
                        FinanacialLoanData fld = new FinanacialLoanData();
                        List<FinancialLoan> lst = fld.GetFinancialLoanData();
                        return View(lst);
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
        public ActionResult FinancialLoanEdit(FormCollection form)
        {
             
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<FinancialLoan> lst = new List<FinancialLoan>();
                    for (int i = 1; i <= 10; i++)
                    {
                        FinancialLoan obj = new FinancialLoan();
                        obj.date = form["date"];
                        obj.Lender = form["Lender" + i];
                        obj.Loanbalance = form["Loanbalance" + i];
                        obj.Rate = form["Rate" + i];
                        obj.Term = form["Term" + i];
                        obj.Expiryterm = form["Expiryterm" + i];
                        obj.Phase = string.Empty;
                        lst.Add(obj);
                    }
                    FinanacialLoanData ld = new FinanacialLoanData();
                    ld.UpdateFinancialLoan(lst);
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
            FinanacialLoanData fld = new FinanacialLoanData();
            List<FinancialLoan> lst = fld.GetFinancialLoanData();
            return new PageOrientations().RenderRazorViewToString(this, "Print", lst);
            
        }
    }
}