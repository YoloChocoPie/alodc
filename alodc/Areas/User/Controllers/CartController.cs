/*using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using alodc.Models;

namespace alodc.Areas.User.Controllers
{
    public class CartController : Controller
    {
        private AD1TEAM1 db = new AD1TEAM1();
        private List<MENU> Cart = null;

        public CartController()
        {
            var Session = System.Web.HttpContext.Current.Session;
            if (Session["Cart"] != null)
                Cart = Session["Cart"] as List<MENU>;
            else
            {
                Cart = new List<MENU>();
                Session["Cart"] = Cart;
            }
        }

        // GET: User/Cart
        public ActionResult Index()
        {
            return View(Cart);
        }

        *//* // GET: User/Cart/Details/5
         public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             ORDER_DETAIL oRDER_DETAIL = db.ORDER_DETAIL.Find(id);
             if (oRDER_DETAIL == null)
             {
                 return HttpNotFound();
             }
             return View(oRDER_DETAIL);
         }
 *//*
        // GET: User/Cart/Create
        [HttpPost]
        public ActionResult Create(int foodId, int quantity)
        {
            var product = db.FOODs.Find(foodId);
            Cart.Add(new MENU
            {
                FOOD = product,
                QUANTITY = quantity
            });
            return RedirectToAction("Index");

        }



        // GET: User/Cart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU oRDER_DETAIL = db.MENUs.Find(id);
            if (oRDER_DETAIL == null)
            {
                return HttpNotFound();
            }
            ViewBag.MENU_ID = new SelectList(db.MENUs, "ID", "ID", oRDER_DETAIL.FOOD.MENUs);
            ViewBag.ORDER_ID = new SelectList(db.ORDERs, "ID", "ORDER_CODE", oRDER_DETAIL.ORDER_DETAIL);
            return View(oRDER_DETAIL);
        }



        // GET: User/Cart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER_DETAIL oRDER_DETAIL = db.ORDER_DETAIL.Find(id);
            if (oRDER_DETAIL == null)
            {
                return HttpNotFound();
            }
            return View(oRDER_DETAIL);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
*/