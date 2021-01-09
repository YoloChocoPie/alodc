using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alodc.Models;
using WebCanteen.Areas.Admin.Middleware;

namespace alodc.Areas.Admin.Controllers
{
    [LoginVerification]
    public class UserController : Controller
    {
        // GET: Admin/User
        AD1TEAM1 model = new AD1TEAM1();
        // GET: Admin/Account
        public ActionResult Index()
        {
            var cus = model.CUSTOMERs.OrderByDescending(x => x.ID).ToList();

            return View(cus);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.cus_faculity = model.FACULTies.OrderByDescending(x => x.ID).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CUSTOMER c)
        {
            if (ModelState.IsValid)
            {
                var cus = new CUSTOMER();
                cus.EMAIL = c.EMAIL;
                cus.PASSWORD = c.PASSWORD;
                cus.FULL_NAME = c.FULL_NAME;
                cus.PHONE_NUMBER = c.PHONE_NUMBER;
                cus.STATUS = c.STATUS;
                cus.CUSTOMER_TYPE = c.CUSTOMER_TYPE;
                cus.FACULTY_ID = c.FACULTY_ID;

                model.CUSTOMERs.Add(cus);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CUSTOMER cus = model.CUSTOMERs.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }
            ViewBag.cus_faculity = model.FACULTies.OrderByDescending(x => x.ID).ToList();
            return View(cus);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CUSTOMER c)
        {
            if (ModelState.IsValid)
            {
                var cus = model.CUSTOMERs.FirstOrDefault(x => x.ID == id);
                cus.EMAIL = c.EMAIL;
                cus.PASSWORD = c.PASSWORD;
                cus.FULL_NAME = c.FULL_NAME;
                cus.PHONE_NUMBER = c.PHONE_NUMBER;
                cus.STATUS = c.STATUS;
                cus.CUSTOMER_TYPE = c.CUSTOMER_TYPE;
                cus.FACULTY_ID = c.FACULTY_ID;
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cus = model.CUSTOMERs.FirstOrDefault(x => x.ID == id);
            return View(cus);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var cus= model.CUSTOMERs.FirstOrDefault(x => x.ID == id);
            model.CUSTOMERs.Remove(cus);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {

            var account = model.ACCOUNTs.FirstOrDefault(x => x.ID == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(account);

        }
    }
}