using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Models;
using MonthlyReport.Data;

namespace MonthlyReport.Controllers
{
    public class MonthlyLeasingController : Controller
    {
       
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {

                    try
                    {
                        Leasing leasing = new Leasing();
                        LeasingDataMonthly ld = new LeasingDataMonthly();
                        leasing.NewTenantOpenings = ld.GetNewTenantOpeningData();
                        leasing.DeliveredSpaces = ld.GetDelieverdSpaces();
                        leasing.keyDeals = ld.GetKeyDeals();
                        leasing.completedRenewals = ld.GetCompletedRenewals();
                        leasing.hotDeals = ld.GetHotDeals();
                        leasing.tenantsAtRisks = ld.GetTenantAtRisk();
                        leasing.tenantClosures = ld.GetTenantClosure();
                        return View(leasing);
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
        public ActionResult NewTenantOpeningEdit()
        {

            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "7")
                {
                    try
                    {
                        Leasing leasing = new Leasing();
                        LeasingDataMonthly ld = new LeasingDataMonthly();
                        leasing.NewTenantOpenings = ld.GetNewTenantOpeningData();
                        return View(leasing.NewTenantOpenings);
                    }
                    catch (Exception ex)
                    {
                        return View("Error", ex);
                    }

                }
                else
                {
                    return View("Accessdeneid");
                }
            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult NewTenantOpeningEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<NewTenantOpening> lst = new List<NewTenantOpening>();
                    for (int i = 1; i <= 5; i++)
                    {
                        NewTenantOpening obj = new NewTenantOpening();
                        obj.Tenant = form["Tenant" + i];
                        obj.Months = form["month"];
                        obj.Sector = form["Sector" + i];
                        obj.UnitNo = form["Tenant" + i];
                        obj.Gla = form["Gla" + i];
                        obj.NetRent = form["NetRent" + i];
                        obj.Ner = form["Ner" + i];
                        obj.Llw = form["Llw" + i];
                        obj.TA = form["TA" + i];
                        obj.Commision = form["Commision" + i];
                        lst.Add(obj);
                    }
                    LeasingDataMonthly ld = new LeasingDataMonthly();
                    ld.UpdateNewTenantOpening(lst);
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
        [HttpGet]
        public ActionResult DeliveredSpacesEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "7")
                {
                    try
                    {
                        Leasing leasing = new Leasing();
                        LeasingDataMonthly ld = new LeasingDataMonthly();
                        leasing.DeliveredSpaces = ld.GetDelieverdSpaces();
                        return View(leasing.DeliveredSpaces);
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
        public ActionResult DeliveredSpacesEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<DeliveredSpaces> lst = new List<DeliveredSpaces>();
                    for (int i = 1; i <= 5; i++)
                    {
                        DeliveredSpaces obj = new DeliveredSpaces();
                        obj.Tenant = form["Tenant" + i];
                        obj.Months = form["month"];
                        obj.Sector = form["Sector" + i];
                        obj.UnitNo = form["UnitNo" + i];
                        obj.Gla = form["Gla" + i];
                        obj.DeliveryDate = form["DeliveryDate" + i];
                        obj.FixturingPeriod = form["FixturingPeriod" + i];
                        obj.ExpectedOpening = form["ExpectedOpening" + i];
                        obj.Ner = form["Ner" + i];
                        obj.Llw = form["Llw" + i];
                        obj.TA = form["TA" + i];
                        obj.Commision = form["Commision" + i];
                        lst.Add(obj);
                    }
                    LeasingDataMonthly ld = new LeasingDataMonthly();
                    ld.UpdateDeliveredSpaces(lst);
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
        [HttpGet]
        public ActionResult KeyDealsEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "7")
                {
                    try
                    {
                        Leasing leasing = new Leasing();
                        LeasingDataMonthly ld = new LeasingDataMonthly();
                        leasing.keyDeals = ld.GetKeyDeals();
                        return View(leasing.keyDeals);
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
        public ActionResult KeyDealsEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<KeyDeals> lst = new List<KeyDeals>();
                    for (int i = 1; i <= 5; i++)
                    {
                        KeyDeals obj = new KeyDeals();
                        obj.Tenant = form["Tenant" + i];
                        obj.Sector = form["Sector" + i];
                        obj.UnitNo = form["UnitNo" + i];
                        obj.Gla = form["Gla" + i];
                        obj.Term = form["Term" + i];
                        obj.NetBudget = form["NetBudget" + i];
                        obj.NetRentActual = form["NetRentActual" + i];
                        obj.Ner = form["Ner" + i];
                        obj.Llw = form["Llw" + i];
                        obj.TA = form["TA" + i];
                        obj.Commision = form["Commision" + i];
                        lst.Add(obj);
                    }
                    LeasingDataMonthly ld = new LeasingDataMonthly();
                    ld.UpdateKeyDeals(lst);
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

        [HttpGet]
        public ActionResult CompletedRenewalsEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "7")
                {
                    try
                    {
                        Leasing leasing = new Leasing();
                        LeasingDataMonthly ld = new LeasingDataMonthly();
                        leasing.completedRenewals = ld.GetCompletedRenewals();
                        return View(leasing.completedRenewals);
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
        public ActionResult CompletedRenewalsEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                
                    try
                {
                    List<CompletedRenewals> lst = new List<CompletedRenewals>();
                    for (int i = 1; i <= 5; i++)
                    {
                        CompletedRenewals obj = new CompletedRenewals();
                        obj.Tenant = form["Tenant" + i];
                        obj.Sector = form["Sector" + i];
                        obj.UnitNo = form["UnitNo" + i];
                        obj.Gla = form["Gla" + i];
                        obj.Term = form["Term" + i];
                        obj.NetBudget = form["NetBudget" + i];
                        obj.NetRentActual = form["NetRentActual" + i];
                        obj.Ner = form["Ner" + i];
                        obj.Llw = form["Llw" + i];
                        obj.TA = form["TA" + i];
                        obj.Commision = form["Commision" + i];
                        lst.Add(obj);
                    }
                    LeasingDataMonthly ld = new LeasingDataMonthly();
                    ld.UpdateCompletedRenewals(lst);
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
        [HttpGet]
        public ActionResult HotDealsEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "7")
                {
                    try
                    {
                        Leasing leasing = new Leasing();
                        LeasingDataMonthly ld = new LeasingDataMonthly();
                        leasing.hotDeals = ld.GetHotDeals();
                        return View(leasing.hotDeals);
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
        public ActionResult HotDealsEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                    try
                    {
                        List<HotDeals> lst = new List<HotDeals>();
                        for (int i = 1; i <= 5; i++)
                        {
                            HotDeals obj = new HotDeals();
                            obj.Tenant = form["Tenant" + i];
                            obj.Sector = form["Sector" + i];
                            obj.UnitNo = form["UnitNo" + i];
                            obj.Gla = form["Gla" + i];
                            obj.Term = form["Term" + i];
                            obj.LoiSigned = form["LoiSigned" + i];
                            obj.BudgetRate = form["BudgetRate" + i];
                            obj.ProposedRate = form["ProposedRate" + i];
                            obj.Ner = form["Ner" + i];
                            obj.Llw = form["Llw" + i];
                            obj.TA = form["TA" + i];
                            obj.Commision = form["Commision" + i];
                            obj.Comments = form["comment" + i];
                            lst.Add(obj);
                        }
                        LeasingDataMonthly ld = new LeasingDataMonthly();
                        ld.UpdateHotDeals(lst);
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
        [HttpGet]
        public ActionResult TenantsAtRiskEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "7")
                {
                    Leasing leasing = new Leasing();
                    LeasingDataMonthly ld = new LeasingDataMonthly();
                    leasing.tenantsAtRisks = ld.GetTenantAtRisk();
                    return View(leasing.tenantsAtRisks);
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
        public ActionResult TenantsAtRiskEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<TenantsAtRisk> lst = new List<TenantsAtRisk>();
                    for (int i = 1; i <= 7; i++)
                    {
                        TenantsAtRisk obj = new TenantsAtRisk();
                        obj.Tenant = form["Tenant" + i];
                        obj.Sales = form["Sales" + i];
                        obj.UnitNo = form["UnitNo" + i];
                        obj.Gla = form["Gla" + i];
                        obj.Groc = form["Groc" + i];
                        obj.RollingSales = form["RollingSales" + i];
                        obj.ArYtd = form["ArYtd" + i];
                        obj.Comments = form["comment" + i];
                        lst.Add(obj);
                    }
                    LeasingDataMonthly ld = new LeasingDataMonthly();
                    ld.UpdateTenantsAtrisk(lst);
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

        [HttpGet]
        public ActionResult TenantsClosureEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "7")
                {
                    try
                    {
                        Leasing leasing = new Leasing();
                        LeasingDataMonthly ld = new LeasingDataMonthly();
                        leasing.tenantClosures = ld.GetTenantClosure();
                        return View(leasing.tenantClosures);
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
        public ActionResult TenantsClosureEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<TenantClosure> lst = new List<TenantClosure>();
                    for (int i = 1; i <= 5; i++)
                    {
                        TenantClosure obj = new TenantClosure();
                        obj.Tenant = form["Tenant" + i];
                        obj.Sector = form["Sector" + i];
                        obj.Gla = form["Gla" + i];
                        obj.DateOfClosure = form["DateOfClosure" + i];
                        obj.ReasonOfClosure = form["ReasonOfClosure" + i];
                        obj.Ar = form["Ar" + i];
                        obj.CoTenancyRisk = form["CoTenancyRisk" + i];
                        obj.LLW = form["LLW" + i];
                        obj.TI = form["TI" + i];
                        obj.Comments = form["comment" + i];
                        obj.Occupancy = form["Occupancy" + i];
                        lst.Add(obj);
                    }
                    LeasingDataMonthly ld = new LeasingDataMonthly();
                    ld.UpdateTenantClosure(lst);
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
            Leasing leasing = new Leasing();
            LeasingDataMonthly ld = new LeasingDataMonthly();
            leasing.NewTenantOpenings = ld.GetNewTenantOpeningData();
            leasing.DeliveredSpaces = ld.GetDelieverdSpaces();
            leasing.keyDeals = ld.GetKeyDeals();
            leasing.completedRenewals = ld.GetCompletedRenewals();
            leasing.hotDeals = ld.GetHotDeals();
            leasing.tenantsAtRisks = ld.GetTenantAtRisk();
            leasing.tenantClosures = ld.GetTenantClosure();
            return new PageOrientations().RenderRazorViewToString(this, "Print", leasing);

        }

    }
}