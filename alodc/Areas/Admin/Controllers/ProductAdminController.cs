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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FOOD_CODE,FOOD_NAME,CATEGORY_ID,DESCRIPTION,PRICE,IMAGE_URL,STATUS")]
                        FOOD food)
        {
            if (ModelState.IsValid)
            {
                var food1 = new FOOD();
                food1.FOOD_CODE = food.FOOD_CODE;
                food1.FOOD_NAME = food.FOOD_NAME;
                food1.CATEGORY_ID = food.CATEGORY_ID;
                food1.DESCRIPTION = food.DESCRIPTION;
                food1.PRICE = food.PRICE;
                food1.IMAGE_URL =  food.IMAGE_URL;
                food1.STATUS = food.STATUS;


                model.FOODs.Add(food1);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();



        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            /*var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            ViewBag.food_category = model.CATEGORies.OrderByDescending(x => x.ID).ToList();
            return View(food);*/

            FOOD food = model.FOODs.Find(id);
            if(food == null)
            {
                return HttpNotFound();
            }
            ViewBag.food_category = model.CATEGORies.OrderByDescending(x => x.ID).ToList();
            return View(food);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FOOD_CODE,FOOD_NAME,CATEGORY_ID,DESCRIPTION,PRICE,IMAGE_URL,STATUS")]
                        FOOD food, int id)
        {
            if (ModelState.IsValid)
            {

                var c = model.FOODs.FirstOrDefault(x => x.ID == id);
                c.FOOD_CODE = food.FOOD_CODE;
                c.FOOD_NAME = food.FOOD_NAME;
                c.CATEGORY_ID = food.CATEGORY_ID;
                c.DESCRIPTION = food.DESCRIPTION;
                c.PRICE = food.PRICE;
                c.IMAGE_URL = food.IMAGE_URL;
                c.STATUS = food.STATUS;

                
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index");
            }
            return View();



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
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            model.FOODs.Remove(food);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
        /* [AllowAnonymous]
         public ActionResult Details(int id)
         {

             var food = model.FOODs.FirstOrDefault(x => x.ID == id);
             if (model == null)
             {
                 return HttpNotFound();
             }
             return View(food);
         }*/


    }
}
    
