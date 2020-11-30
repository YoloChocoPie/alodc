using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alodc.Models;
using WebCanteen.Areas.Admin.Middleware;

namespace alodc.Areas.Admin.Controllers
{
    [LoginVerification]
    public class ProductAdminController : Controller

    {
        QUANLYCANTEENEntities model = new QUANLYCANTEENEntities();
        // GET: Admin/ProductAdmin
        public ActionResult Index()
        {
            var food = model.FOODs.OrderByDescending(x => x.ID).ToList();
            return View(food);
        }

        public ActionResult Create()
        {
           ViewBag.food_category = model.CATEGORies.OrderByDescending(x => x.ID).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(FOOD c)
        {
            var food = new FOOD();
            food.FOOD_CODE = c.FOOD_CODE;
            food.FOOD_NAME = c.FOOD_NAME;
            food.CATEGORY_ID = c.CATEGORY_ID;
            food.DESCRIPTION = c.DESCRIPTION;
            food.PRICE = c.PRICE;
            food.IMAGE_URL = c.IMAGE_URL;
            food.STATUS = c.STATUS;
            
            model.FOODs.Add(food);
            model.SaveChanges();
            Session["Success"] = true;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            ViewBag.food_category = model.CATEGORies.OrderByDescending(x => x.ID).ToList();
            return View(food);
        }
        [HttpPost]

        public ActionResult Edit(int id,FOOD c)
        {
            // Get the original record to edit from the database.
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            food.FOOD_CODE = c.FOOD_CODE;
            food.FOOD_NAME = c.FOOD_NAME;
            food.CATEGORY_ID = c.CATEGORY_ID;
            food.DESCRIPTION = c.DESCRIPTION;
            food.PRICE = c.PRICE;
            food.IMAGE_URL = c.IMAGE_URL;
            food.STATUS = c.STATUS;



            
            model.SaveChanges();
            return RedirectToAction("Index");

            // This will attempt to do the model binding and map all the submitted 
            // properties to the attached entity.
     
        }
/*        public ActionResult Edit( FOOD c)
        {
            
        }*/
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            return View(food);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            model.FOODs.Remove(food);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {

            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }
    }
}
    
