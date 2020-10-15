using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Data;
using MonthlyReport.Models;

namespace MonthlyReport.Controllers
{
    public class CustomerServiceController : Controller
    {
       
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {

                    try
                    {
                        CustomerServiceData csd = new CustomerServiceData();
                        CustomerService customerService = csd.GetCustomerServiceData();
                        return View(customerService);
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
        public ActionResult InteractiveEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "5")
                {
                    try
                    {
                        CustomerServiceData csd = new CustomerServiceData();
                        List<Interactive> interactives = csd.GetInteractiveData();
                        Header header = csd.GetHeaderData()[0];
                        ViewBag.Header = header;
                        return View(interactives);
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
        public ActionResult SocialMediaEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "5")
                {
                    try
                    {
                        CustomerServiceData csd = new CustomerServiceData();
                        List<SocialMedia> socialMedias = csd.GetSocialMediaData();
                        Header header = csd.GetHeaderData()[1];
                        ViewBag.Header = header;
                        return View(socialMedias);
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
        public ActionResult GiftCardEdit()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "5")
                {
                    try
                    {
                        CustomerServiceData csd = new CustomerServiceData();
                        List<GiftCard> giftCards = csd.GetGiftCardData();
                        Header header = csd.GetHeaderData()[2];
                        ViewBag.Header = header;
                        return View(giftCards);
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
        public ActionResult InteractiveEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<Interactive> lst = new List<Interactive>();
                    for (int i = 1; i <= 2; i++)
                    {
                        Interactive obj = new Interactive();
                        obj.Month1 =  !string.IsNullOrEmpty( form["Month1" + i]) ? form["Month1" + i] : string.Empty;
                        obj.Month2 = !string.IsNullOrEmpty(form["Month2" + i]) ? form["Month2" + i] : string.Empty;
                        obj.Year1 = !string.IsNullOrEmpty(form["Year1" + i]) ? form["Year1" + i] : string.Empty;
                        obj.Year2 = !string.IsNullOrEmpty(form["Year2" + i]) ? form["Year2" + i] : string.Empty;
                        obj.Change1 = !string.IsNullOrEmpty(form["Change1" + i]) ? form["Change1" + i] : string.Empty;
                        obj.Change2 = !string.IsNullOrEmpty(form["Change2" + i]) ? form["Change2" + i] : string.Empty;
                        lst.Add(obj);
                    }
                    Header header = new Header();
                    header.Month1 = !string.IsNullOrEmpty(form["Month1" ]) ? form["Month1"] : string.Empty; ;
                    header.Month2 = !string.IsNullOrEmpty(form["Month2"]) ? form["Month2" ] : string.Empty; ;
                    header.Year1 = !string.IsNullOrEmpty(form["Year1" ]) ? form["Year1" ] : string.Empty;
                    header.Year2 = !string.IsNullOrEmpty(form["Year2" ]) ? form["Year2" ] : string.Empty;
                    header.Year3 = !string.IsNullOrEmpty(form["Year3" ]) ? form["Year3"] : string.Empty;
                    header.Year4 = !string.IsNullOrEmpty(form["Year4" ]) ? form["Year4"] : string.Empty;
                    CustomerServiceData csd = new CustomerServiceData();
                    csd.UpdateInteractiveData(lst, header);
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
        public ActionResult GiftCardEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<GiftCard> lst = new List<GiftCard>();
                    for (int i = 1; i <= 2; i++)
                    {
                        GiftCard obj = new GiftCard();
                        obj.Month1 = form["Month1" + i];
                        obj.Month2 = form["Month2" + i];
                        obj.Year1 = form["Year1" + i];
                        obj.Year2 = form["Year2" + i];
                        obj.Change1 = form["Change1" + i];
                        obj.Change2 = form["Change2" + i];
                        lst.Add(obj);
                    }
                    Header header = new Header();
                    header.Month1 = !string.IsNullOrEmpty(form["Month1"]) ? form["Month1"] : string.Empty; ;
                    header.Month2 = !string.IsNullOrEmpty(form["Month2"]) ? form["Month2"] : string.Empty; ;
                    header.Year1 = !string.IsNullOrEmpty(form["Year1"]) ? form["Year1"] : string.Empty;
                    header.Year2 = !string.IsNullOrEmpty(form["Year2"]) ? form["Year2"] : string.Empty;
                    header.Year3 = !string.IsNullOrEmpty(form["Year3"]) ? form["Year3"] : string.Empty;
                    header.Year4 = !string.IsNullOrEmpty(form["Year4"]) ? form["Year4"] : string.Empty;
                    CustomerServiceData csd = new CustomerServiceData();
                    csd.UpdateGiftCardData(lst, header);
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
        public ActionResult SocialMediaEdit(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    List<SocialMedia> lst = new List<SocialMedia>();
                    for (int i = 1; i <= 2; i++)
                    {
                        SocialMedia obj = new SocialMedia();
                        obj.Month1 = form["Month1" + i];
                        obj.Month2 = form["Month2" + i];
                       
                        obj.Year2 = form["Year2" + i];
                        obj.Change1 = form["Change1" + i];
                        obj.Change2 = form["Change2" + i];
                        lst.Add(obj);
                    }
                    Header header = new Header();
                    header.Month1 = !string.IsNullOrEmpty(form["Month1"]) ? form["Month1"] : string.Empty; ;
                    header.Month2 = !string.IsNullOrEmpty(form["Month2"]) ? form["Month2"] : string.Empty; ;
                    header.Year1 = !string.IsNullOrEmpty(form["Year1"]) ? form["Year1"] : string.Empty;
                    header.Year2 = !string.IsNullOrEmpty(form["Year2"]) ? form["Year2"] : string.Empty;
                    header.Year3 = !string.IsNullOrEmpty(form["Year3"]) ? form["Year3"] : string.Empty;
                    header.Year4 = "2019";
                    CustomerServiceData csd = new CustomerServiceData();
                    csd.UpdateSocialMediaData(lst, header);
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
            CustomerServiceData csd = new CustomerServiceData();
            CustomerService customerService = csd.GetCustomerServiceData();
            string s =  new PageOrientations().RenderRazorViewToString(this, "Print", customerService);
            
            return s;

                       
        }

    }
}