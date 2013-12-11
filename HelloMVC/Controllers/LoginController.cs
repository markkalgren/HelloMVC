using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace HelloMVC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login(LoginFM credentials)
        {
            LoginVM user = new LoginService().Login(credentials);
            if (user != null)
            {
                Session["UserID"] = user.ID;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "That was wrong, idiot. Try again or go away.";
                return View("Index");
            }
        }
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}