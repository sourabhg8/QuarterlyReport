using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MonthlyReport.Data;
using MonthlyReport.Models;
using iText.Html2pdf;
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

namespace MonthlyReport.Controllers
{
    public class AccountsController : Controller
    {
  

        // GET: Accounts
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {

                    try
                    {
                        AccountsData ad = new AccountsData();
                        List<Accounts> accounts = ad.GetAccountsData();
                        return View(accounts);
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
        public ActionResult AccountsEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "3")
                {
                    try
                    {
                        AccountsData ad = new AccountsData();
                        List<Accounts> accounts = ad.GetAccountsData();
                        return View(accounts);
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
        public ActionResult AccountsEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<Accounts> accounts = new List<Accounts>();
                    for (int i = 1; i <= 12; i++)
                    {
                        Accounts account = new Accounts();
                        if (i <= 10)
                        {
                            account.Tenant = form["tenant" + i];
                        }
                        else
                        {
                            account.Tenant = "test";
                        }
                        account.BalanceOverdue = form["BalanceOverDue" + i];
                        account.NetBalance = form["netBalance" + i];
                        account.Provision = form["provision" + i];
                        account.ReceivableBalance = form["ReceivableBalance" + i];
                        account.ThirtyDays = form["thirtydays" + i];
                        account.SixtyDays = form["sixtydays" + i];
                        account.NintyDays = form["nintydays" + i];
                        account.NintyPlusDays = form["nintyplusdays" + i];
                        account.Comment = form["comment" + i];
                        account.Action = form["action" + i];
                        accounts.Add(account);
                    }
                    AccountsData ad = new AccountsData();
                    ad.UpdateAccounts(accounts);
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
            AccountsData ad = new AccountsData();
            List<Accounts> accounts = ad.GetAccountsData();
            return new PageOrientations().RenderRazorViewToString(this, "Print", accounts);
            
        }
    }
   
    }
