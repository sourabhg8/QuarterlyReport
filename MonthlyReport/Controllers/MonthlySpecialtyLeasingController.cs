using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Models;
using MonthlyReport.Data;

namespace MonthlyReport.Controllers
{
    public class MonthlySpecialtyLeasingController : Controller
    {
        // GET: SpecialtyLeasing
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                    try
                    {
                        SpecialityLeasingDataMonthly sld = new SpecialityLeasingDataMonthly();
                        SpecialityLeasingModel specialityLeasingModel = sld.GetSpecialityLeasingData();
                        return View(specialityLeasingModel);
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
        public ActionResult SpecialityEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "8")
                {
                    try
                    {
                        SpecialityLeasingDataMonthly sld = new SpecialityLeasingDataMonthly();
                        SpecialityLeasingModel specialityLeasingModel = sld.GetSpecialityLeasingData();
                        return View(specialityLeasingModel);
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
        public ActionResult SpecialityEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    SpecialityLeasingModel specialityLeasingModel = new SpecialityLeasingModel();
                    List<SpecialityLeasing> lstleasing = new List<SpecialityLeasing>();
                    List<SpecialProject> lstprojects = new List<SpecialProject>();
                    for (int i = 1; i <= 6; i++)
                    {
                        SpecialityLeasing obj = new SpecialityLeasing();
                        obj.Tenant = form["Tenant" + i];
                        obj.Sector = form["Sector" + i];
                        obj.UnitNo = form["UnitNo" + i];
                        obj.Gla = form["Gla" + i];
                        obj.Term = form["Term" + i];
                        obj.GrossRentBudget = form["GrossRentBudget" + i];
                        obj.GrossRentActual = form["GrossRentActual" + i];
                        obj.SalesPercentage = form["SalesPercentage" + i];
                        obj.Comments = form["comment" + i];
                        lstleasing.Add(obj);
                    }
                    for (int i = 1; i <= 4; i++)
                    {
                        SpecialProject obj = new SpecialProject();
                        obj.Title = form["Title" + i];
                        obj.Content = form["Content" + i];
                        lstprojects.Add(obj);
                    }
                    specialityLeasingModel.specialityLeasings = lstleasing;
                    specialityLeasingModel.specialProjects = lstprojects;
                    SpecialityLeasingDataMonthly sdl = new SpecialityLeasingDataMonthly();
                    sdl.UpdateSpeciality(specialityLeasingModel);
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
            SpecialityLeasingDataMonthly sld = new SpecialityLeasingDataMonthly();
            SpecialityLeasingModel specialityLeasingModel = sld.GetSpecialityLeasingData();
            return new PageOrientations().RenderRazorViewToString(this, "Print", specialityLeasingModel);

        }
    }
}