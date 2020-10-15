using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Data;
using MonthlyReport.Models;
using System.IO;

namespace MonthlyReport.Controllers
{
    public class MarketingController : Controller
    {
        // GET: Marketing
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads/First"));
                        foreach (FileInfo fi in di.GetFiles())
                        {
                            ViewBag.extension1 = fi.Extension;

                        }
                        if (di.GetFiles().Count() == 0)
                        {
                            ViewBag.extension1 = "none";
                        }
                        DirectoryInfo di2 = new DirectoryInfo(Server.MapPath("~/Uploads/Second"));
                        foreach (FileInfo fi in di2.GetFiles())
                        {
                            ViewBag.extension2 = fi.Extension;

                        }
                        if (di2.GetFiles().Count() == 0)
                        {
                            ViewBag.extension2 = "none";
                        }
                    DirectoryInfo di3 = new DirectoryInfo(Server.MapPath("~/Uploads/Third"));
                    foreach (FileInfo fi in di3.GetFiles())
                    {
                        ViewBag.extension3 = fi.Extension;

                    }
                    if (di3.GetFiles().Count() == 0)
                    {
                        ViewBag.extension3 = "none";
                    }
                    DirectoryInfo di4 = new DirectoryInfo(Server.MapPath("~/Uploads/Fourth"));
                    foreach (FileInfo fi in di4.GetFiles())
                    {
                        ViewBag.extension4 = fi.Extension;

                    }
                    if (di4.GetFiles().Count() == 0)
                    {
                        ViewBag.extension4 = "none";
                    }
                    MarketingData md = new MarketingData();
                    List<Marketing> lst = md.GetMarketingData();
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
        public ActionResult MarketingEdit(bool? firstUploaded = false, bool ? secondUploaded = false) 
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "5")
                {
                    try
                    {
                        MarketingData md = new MarketingData();
                        List<Marketing> lst = md.GetMarketingData();
                        bool a = firstUploaded == true ? true : false;
                        bool b = secondUploaded == true ? true : false;
                       
                        if (a)
                        {
                            ViewBag.message1 = "File Uploaded Successfully";
                        }
                        if (b)
                        {
                            ViewBag.message2 = "File Uploaded Successfully";
                        }

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

        [HttpGet]
        public ActionResult MarketingEditSecond( bool? thirdUploaded = false, bool? fourthUploaded = false)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                if (Session["roleid"].ToString() == "1" || Session["roleid"].ToString() == "5")
                {
                    try
                    {
                        MarketingData md = new MarketingData();
                        List<Marketing> lst = md.GetMarketingData();
                        bool c = thirdUploaded == true ? true : false;
                        bool d = fourthUploaded == true ? true : false;
                        if (c)
                        {
                            ViewBag.message3 = "File Uploaded Successfully";
                        }
                        if (d)
                        {
                            ViewBag.message4 = "File Uploaded Successfully";
                        }
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
        public ActionResult MarketingEdit(FormCollection form)
        {
            try
            {
                MarketingData md = new MarketingData();
                List<Marketing> lstexisting = md.GetMarketingData();
                List<Marketing> lst = new List<Marketing>();
                
                Marketing obj = new Marketing();
                obj.Type = form["Type1"];
                obj.TypeValue = form["TypeValue1"];
                obj.Kpi1 = form["Kpi11"];
                obj.Kpi2 = form["kpi12"];
                obj.Kpi3 = form["Kpi13"];
                obj.Result1 = form["Result11"];
                obj.Result2 = form["Result12"];
                obj.Result3 = form["Result13"];
                lst.Add(obj);
                Marketing obj1 = new Marketing();
                obj1.Type = form["Type2"];
                obj1.TypeValue = form["TypeValue2"];
                obj1.Kpi1 = form["Kpi21"];
                obj1.Kpi2 = form["kpi22"];
                obj1.Kpi3 = form["Kpi23"];
                obj1.Result1 = form["Result21"];
                obj1.Result2 = form["Result22"];
                obj1.Result3 = form["Result23"];
                lst.Add(obj1);
                lst.Add(lstexisting[2]);
                lst.Add(lstexisting[3]);


                md.UpdateMarketingData(lst);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpPost]
        public ActionResult MarketingEditSecond(FormCollection form)
        {
            try
            {
                MarketingData md = new MarketingData();
                List<Marketing> lstexisting = md.GetMarketingData();
                List<Marketing> lst = new List<Marketing>();
                lst.Add(lstexisting[0]);
                lst.Add(lstexisting[1]);
                Marketing obj = new Marketing();
                obj.Type = form["Type3"];
                obj.TypeValue = form["TypeValue3"];
                obj.Kpi1 = form["Kpi31"];
                obj.Kpi2 = form["kpi32"];
                obj.Kpi3 = form["Kpi33"];
                obj.Result1 = form["Result31"];
                obj.Result2 = form["Result32"];
                obj.Result3 = form["Result33"];
                lst.Add(obj);
                Marketing obj1 = new Marketing();
                obj1.Type = form["Type4"];
                obj1.TypeValue = form["TypeValue4"];
                obj1.Kpi1 = form["Kpi41"];
                obj1.Kpi2 = form["kpi42"];
                obj1.Kpi3 = form["Kpi43"];
                obj1.Result1 = form["Result41"];
                obj1.Result2 = form["Result42"];
                obj1.Result3 = form["Result43"];
                lst.Add(obj1);               
                md.UpdateMarketingData(lst);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }


        [HttpPost]
        public ActionResult ImageEditFirst(HttpPostedFileBase file1)
        {
            try
            {

                if (file1 != null)
                {
                    if (file1.ContentLength == 0)
                    {
                        return RedirectToAction("MarketingEdit");
                    }
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads/First"));
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        fi.Delete();
                    }
                    string extension = Path.GetExtension(file1.FileName);
                    string _fileName = "NewFile" + extension;
                    string path = Path.Combine(Server.MapPath("~/Uploads/First"), _fileName);
                    file1.SaveAs(path);
                    return RedirectToAction("MarketingEdit", new { firstUploaded = true });
                }
                else
                {
                    return RedirectToAction("MarketingEdit");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        [HttpPost]
        public ActionResult ImageEditSecond(HttpPostedFileBase file2)
        {
            try
            {
                if (file2 != null)
                {
                    if (file2.ContentLength == 0)
                    {
                        return RedirectToAction("MarketingEdit");
                    }
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads/Second"));
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        fi.Delete();
                    }
                    string extension = Path.GetExtension(file2.FileName);
                    string _fileName = "NewFile" + extension;
                    string path = Path.Combine(Server.MapPath("~/Uploads/Second"), _fileName);
                    file2.SaveAs(path);
                    return RedirectToAction("MarketingEdit", new { secondUploaded = true });
                }
                else
                {
                    return RedirectToAction("MarketingEdit");

                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpPost]
        public ActionResult ImageEditThird(HttpPostedFileBase file3)
        {
            try
            {
                if (file3 != null)
                {
                    if (file3.ContentLength == 0)
                    {
                        return RedirectToAction("MarketingEditSecond");
                    }
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads/Third"));
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        fi.Delete();
                    }
                    string extension = Path.GetExtension(file3.FileName);
                    string _fileName = "NewFile" + extension;
                    string path = Path.Combine(Server.MapPath("~/Uploads/Third"), _fileName);
                    file3.SaveAs(path);
                    return RedirectToAction("MarketingEditSecond", new { thirdUploaded = true });
                }
                else
                {
                    return RedirectToAction("MarketingEditSecond");

                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }


        [HttpPost]
        public ActionResult ImageEditFourth(HttpPostedFileBase file4)
        {
            try
            {
                if (file4 != null)
                {
                    if (file4.ContentLength == 0)
                    {
                        return RedirectToAction("MarketingEditSecond");
                    }
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads/Fourth"));
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        fi.Delete();
                    }
                    string extension = Path.GetExtension(file4.FileName);
                    string _fileName = "NewFile" + extension;
                    string path = Path.Combine(Server.MapPath("~/Uploads/Fourth"), _fileName);
                    file4.SaveAs(path);
                    return RedirectToAction("MarketingEditSecond", new { fourthUploaded = true });
                }
                else
                {
                    return RedirectToAction("MarketingEditSecond");

                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpGet]
        public bool DeleteImages( )
        {
            bool value = false;
            try
            {
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads/First"));
                foreach (FileInfo fi in di.GetFiles())
                {
                    fi.Delete();
                }
                DirectoryInfo di2 = new DirectoryInfo(Server.MapPath("~/Uploads/Second"));
                foreach (FileInfo fi in di2.GetFiles())
                {
                    fi.Delete();              
                }
                value = true;
                return (value);
            }
            catch(Exception ex)
            {
                value = false;
                return (value);
            }

        }


        [HttpGet]
        public bool DeleteImages2()
        {
            bool value = false;
            try
            {
                DirectoryInfo di3 = new DirectoryInfo(Server.MapPath("~/Uploads/Third"));
                foreach (FileInfo fi in di3.GetFiles())
                {
                    fi.Delete();
                }
                DirectoryInfo di4 = new DirectoryInfo(Server.MapPath("~/Uploads/Fourth"));
                foreach (FileInfo fi in di4.GetFiles())
                {
                    fi.Delete();
                }
                value = true;
                return (value);
            }
            catch (Exception ex)
            {
                value = false;
                return (value);
            }

        }

        [NonAction]
        public string Print()
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads/First"));
            foreach (FileInfo fi in di.GetFiles())
            {
                ViewBag.extension1 = fi.Extension;

            }
            if (di.GetFiles().Count() == 0)
            {
                ViewBag.extension1 = "none";
            }
            DirectoryInfo di2 = new DirectoryInfo(Server.MapPath("~/Uploads/Second"));
            foreach (FileInfo fi in di2.GetFiles())
            {
                ViewBag.extension2 = fi.Extension;

            }
            if (di2.GetFiles().Count() == 0)
            {
                ViewBag.extension2 = "none";
            }
            DirectoryInfo di3 = new DirectoryInfo(Server.MapPath("~/Uploads/Third"));
            foreach (FileInfo fi in di3.GetFiles())
            {
                ViewBag.extension3 = fi.Extension;

            }
            if (di3.GetFiles().Count() == 0)
            {
                ViewBag.extension3 = "none";
            }
            DirectoryInfo di4 = new DirectoryInfo(Server.MapPath("~/Uploads/Fourth"));
            foreach (FileInfo fi in di4.GetFiles())
            {
                ViewBag.extension4 = fi.Extension;

            }
            if (di4.GetFiles().Count() == 0)
            {
                ViewBag.extension4 = "none";
            }
            MarketingData md = new MarketingData();
            List<Marketing> lst = md.GetMarketingData();
            string s = new PageOrientations().RenderRazorViewToString(this, "Print", lst);
            return s;
        }
    }
}