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
    public class FaculityController : Controller
    {
        // GET: Admin/Faculity
        AD1TEAM1 model = new AD1TEAM1();
        // GET: Admin/CategoriesAdmin
        public ActionResult Index()
        {
            var fac = model.FACULTies.OrderByDescending(x => x.ID).ToList();
            return View(fac);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FACULTY c)
        {
            if (ModelState.IsValid)
            {
                var fac = new FACULTY();
                fac.FACULTY_CODE = c.FACULTY_CODE;
                fac.FACULTY_NAME = c.FACULTY_NAME;
             
                fac.STATUS = c.STATUS;

                model.FACULTies.Add(fac);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var fac = model.FACULTies.FirstOrDefault(x => x.ID == id);
            return View(fac);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FACULTY c)
        {
            if (ModelState.IsValid)
            {
                var fac = model.FACULTies.FirstOrDefault(x => x.ID == id);
                fac.FACULTY_CODE = c.FACULTY_CODE;
                fac.FACULTY_NAME = c.FACULTY_NAME;

                fac.STATUS = c.STATUS;
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var fac = model.FACULTies.FirstOrDefault(x => x.ID == id);
            return View(fac);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var fac = model.FACULTies.FirstOrDefault(x => x.ID == id);
            model.FACULTies.Remove(fac);
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