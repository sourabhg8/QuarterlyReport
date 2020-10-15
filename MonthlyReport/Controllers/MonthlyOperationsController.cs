using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Models;
using MonthlyReport.Data;

namespace MonthlyReport.Controllers
{
    public class MonthlyOperationsController : Controller
    {
        // GET: Operations
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                    try
                    {
                        OperationsDataMonthly od = new OperationsDataMonthly();
                        List<Operations> operations = od.GetOperations();
                        return View(operations);
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
        public ActionResult OperationsEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "6")
                {
                    try
                    {
                        OperationsDataMonthly od = new OperationsDataMonthly();
                        List<Operations> operations = od.GetOperations();
                        return View(operations);
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
        public ActionResult OperationsEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<Operations> operations = new List<Operations>();
                    for (int i = 1; i <= 7; i++)
                    {
                        Operations operation = new Operations();
                        operation.Project = form["project" + i.ToString()];
                        operation.CompletionDate = form["Completion" + i.ToString()];
                        operation.ForecastCompletionDate = form["ForCompletion" + i.ToString()];
                        operation.Budget = form["Budget" + i.ToString()];
                        operation.CommitToDate = form["commit" + i.ToString()];
                        operation.ApprovedAmount = form["approved" + i.ToString()];
                        operation.Comments = form["Comments" + i.ToString()];
                        operation.IsRecoverable = (form["hide" + i.ToString()]) == "False" ? false : true;
                        operations.Add(operation);
                    }
                    OperationsDataMonthly od = new OperationsDataMonthly();
                    od.UpdateOperations(operations);
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
            OperationsDataMonthly od = new OperationsDataMonthly();
            List<Operations> operations = od.GetOperations();
            return new PageOrientations().RenderRazorViewToString(this, "Print", operations);
        }
    }
}