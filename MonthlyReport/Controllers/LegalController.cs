using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Data;
using MonthlyReport.Models;


namespace MonthlyReport.Controllers
{
    public class LegalController : Controller
    {
        // GET: Legal
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<Legal> legals = new List<Legal>();
                    LegalData ld = new LegalData();
                    legals = ld.GetLegalData();
                    return View(legals);
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
        public ActionResult LegalEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "3")
                {
                    try
                    {
                        List<Legal> legals = new List<Legal>();
                        LegalData ld = new LegalData();
                        legals = ld.GetLegalData();
                        return View(legals);
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
        public ActionResult LegalEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<Legal> legals = new List<Legal>();
                    for (int i = 1; i <= 8; i++)
                    {
                        Legal legal = new Legal();
                        legal.Tenant = form["Tenant" + i.ToString()];
                        legal.Ar = form["Ar" + i.ToString()];
                        legal.CollectionProb = form["CollectionProb" + i.ToString()];
                        legal.Comments = form["comment" + i.ToString()];
                        legals.Add(legal);
                    }

                    LegalData ld = new LegalData();
                    ld.UpdateLegalData(legals);
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
            LegalData ld = new LegalData();
            List<Legal> legals = ld.GetLegalData();
            return  new PageOrientations().RenderRazorViewToString(this, "Print", legals);
        }
    }
}