using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonthlyReport.Models;
using MonthlyReport.Data;

namespace MonthlyReport.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(bool? valid = true)
        {
            if(valid == false)
            {
                ViewBag.Message = "Invalid credentials, Please try again";
            }
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword(Login login)
        {
            if(login.redirectToLogin == false)
            {
                ViewBag.Message = login.validationMessage;
                return View();
            }
            else
            {
                ViewBag.Message = login.validationMessage;
                return View("Index");
            }
            
        }

        [HttpPost]
        public ActionResult ChangePassword(FormCollection form)
        {
            if (!string.IsNullOrEmpty(Session["username"] as string))
            {
                try
                {
                    Login login = new Login();
                    login.username = Session["username"] as string;
                    login.password = form["password"];
                    login.newPassword = form["newpassword"];
                    login.confirmPassword = form["confirmpassword"];

                    LoginTable lt = new LoginTable();
                    Login response = lt.GetValidation(login);                   
                    if (response.Isvalid)
                    {
                        Session["username"] = login.username.ToString();
                        if (login.newPassword != login.confirmPassword)
                        {
                            login.validationMessage = "New Password and Confirm Password didnt matched";
                            login.Isvalid = false;
                            login.redirectToLogin = false;
                            return RedirectToAction("ChangePassword", login);
                        }
                        else
                        {
                            lt.ChangePassword(login);
                            login.validationMessage = "Password Changed successfully, Kindly login to your account again";
                            login.Isvalid = true;
                            login.redirectToLogin = true;
                            return RedirectToAction("ChangePassword", login);
                        }
                    }
                    else
                    {
                        login.validationMessage = "Old Password is not Valid";
                        login.Isvalid = false;
                        login.redirectToLogin = false;
                        return RedirectToAction("ChangePassword", login);
                    }
                }
                catch(Exception ex)
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
        public ActionResult Authenticate(FormCollection form)
        {
            Login login = new Login();
            login.username = form["username"];
            login.password = form["password"];
            LoginTable lt = new LoginTable();
            Login response = lt.GetValidation(login);
            if (response.Isvalid)
            {
                Session["username"] = login.username.ToString();
                Session["roleid"] = response.roleid;
                return RedirectToAction("Index", "Landing");
            }
            else
            {
                return RedirectToAction("Index",new { valid = false});

            }
        }
        [HttpGet]

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}