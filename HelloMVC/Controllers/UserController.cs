using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloMVC.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("../Login/Index");
            }
            UserService users = new UserService();
            UsersVM user = users.GetUsers();
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserFM user)
        {
            //if the user is valid, create user
            UserService users = new UserService();
            users.CreateUser(user);
            return RedirectToAction("Index");
            //else return to create with errors
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            UserService users = new UserService();
            UserFM user = users.GetUserFM(ID);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UserFM userFM)
        {
            UserService users = new UserService();
            users.UpdateUser(userFM);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            UserService users = new UserService();
            users.DeleteUser(ID);
            return RedirectToAction("Index");
        }
        public ActionResult ResetPassword(int ID)
        {
            UserService users = new UserService();
            users.ResetPassword(ID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditPassword(int ID)
        {
            UserService users = new UserService();
            return View(users.GetEditPassFM(ID));
        }
        [HttpPost]
        public ActionResult EditPassword(EditPassFM pass)
        {
            UserService users = new UserService();
            if (users.VerifyPass(pass) && pass.NewPass == pass.ConfirmPass && pass.NewPass.Length > 7)
            {
                users.EditPassword(pass);
            }
            //users.EditPassword(pass);
            return RedirectToAction("Index");
        }
	}
}