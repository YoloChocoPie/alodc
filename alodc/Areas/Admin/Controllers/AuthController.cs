﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alodc.Models;


namespace alodc.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
       
        
        QUANLYCANTEENEntities model = new QUANLYCANTEENEntities();
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
            var user = model.ACCOUNTs.FirstOrDefault(u => u.EMAIL.Equals(email));
            if (user != null)
            {
                if (user.PASSWORD.Equals(password))
                {
                    Session["user-fullname"] = user.FULL_NAME;
                    Session["user-id"] = user.ID;
                    Session["user-role"] = user.ROLE;
                    return RedirectToAction("Index", "CategoriesAdmin");

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