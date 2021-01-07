using alodc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCanteen.Areas.Admin.Middleware;

namespace alodc.Areas.Admin.Controllers
{
    [LoginVerification]
    public class CategoriesAdminController : Controller
    {
        // GET: Admin/CategoriesAdmin
        AD1TEAM1 model = new AD1TEAM1();
        // GET: Admin/CategoriesAdmin
        public ActionResult Index()
        {
            var categorye = model.CATEGORies.OrderByDescending(x => x.ID).ToList();
            return View(categorye);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CATEGORY c)
        {
            if (ModelState.IsValid) 
            {
                var category = new CATEGORY();
                category.CATEGORY_CODE = c.CATEGORY_CODE;
                category.CATEGORY_NAME = c.CATEGORY_NAME;
                category.IMAGE_URL = c.IMAGE_URL;
                category.STATUS = c.STATUS;

                model.CATEGORies.Add(category);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();
                
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CATEGORY c)
        {
            if (ModelState.IsValid) 
            {
                var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
                category.CATEGORY_CODE = c.CATEGORY_CODE;
                category.CATEGORY_NAME = c.CATEGORY_NAME;
                category.IMAGE_URL = c.IMAGE_URL;
                category.STATUS = c.STATUS;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
                
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
            model.CATEGORies.Remove(category);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {

            var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(category);

        }
    }
}