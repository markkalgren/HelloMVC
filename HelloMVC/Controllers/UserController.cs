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
        public void Delete(int ID)
        {

        }
	}
}