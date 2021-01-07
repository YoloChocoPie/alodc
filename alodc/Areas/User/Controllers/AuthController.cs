using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alodc.Models;


namespace alodc.Areas.User.Controllers
{
    public class AuthController : Controller
    {
       
        
        AD1TEAM1 model = new AD1TEAM1();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            Session["password-incorret"] = false;
            Session["user-not-found"] = false;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = model.CUSTOMERs.FirstOrDefault(u => u.EMAIL.Equals(email));
            if (user != null)
            {
                if (user.PASSWORD.Equals(password))
                {
                    Session["user-fullname"] = user.FULL_NAME;
                    Session["user-id"] = user.ID;
                    Session["user-role"] = user.CUSTOMER_TYPE;
                    return RedirectToAction("Index2", "ProductUser");

                }
                else
                {
                    Session["password-incorrect"] = true;
                    return View();
                }
            }
            Session["user-not-found"] = true;
            return View();
        }
        public ActionResult Logout()
        {
            Session["user-fullname"] = null;
            Session["user-id"] = null;
            return RedirectToAction("Login");
        }
    }
}