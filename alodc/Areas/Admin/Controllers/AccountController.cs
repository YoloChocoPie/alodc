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
    public class AccountController : Controller
    {
        AD1TEAM1 model = new AD1TEAM1();
        // GET: Admin/Account
        public ActionResult Index()
        {
            var account = model.ACCOUNTs.OrderByDescending(x => x.ID).ToList();
         
            return View(account);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ACCOUNT c)
        {
            if (ModelState.IsValid)
            {
                var account = new ACCOUNT();
                account.EMAIL = c.EMAIL;
                account.PASSWORD = c.PASSWORD;
                account.FULL_NAME = c.FULL_NAME;
                account.STATUS = c.STATUS;
                account.ROLE = c.ROLE;
    
                model.ACCOUNTs.Add(account);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var account = model.ACCOUNTs.FirstOrDefault(x => x.ID == id);
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ACCOUNT c)
        {
            if (ModelState.IsValid)
            {
                var account = model.ACCOUNTs.FirstOrDefault(x => x.ID == id);
                account.EMAIL = c.EMAIL;
                account.PASSWORD = c.PASSWORD;
                account.FULL_NAME = c.FULL_NAME;
                account.STATUS = c.STATUS;
                account.ROLE = c.ROLE;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var account = model.ACCOUNTs.FirstOrDefault(x => x.ID == id);
            return View(account);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var account = model.ACCOUNTs.FirstOrDefault(x => x.ID == id);
            model.ACCOUNTs.Remove(account);
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