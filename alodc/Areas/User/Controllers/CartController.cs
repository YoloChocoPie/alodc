using System;
using System.Collections;
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
        private List<ORDER_DETAIL> Cart = null;

        private void GetCartController()
        {
           
            if (Session["Cart"] != null)
                Cart = Session["Cart"] as List<ORDER_DETAIL>;
            else
            {
                Cart = new List<ORDER_DETAIL>();
                Session["Cart"] = Cart; 
            }
        }

        // GET: User/Cart
        public ActionResult Index()
        {
            GetCartController();
            var hashtable = new Hashtable();
            foreach (var order in Cart)
            {
                if (hashtable[order.FOOD.ID]!= null)
                {

                    (hashtable[order.FOOD.ID] as ORDER_DETAIL).QUANTITY += order.QUANTITY;
                }
                else hashtable[order.FOOD.ID] = order;
            }
            Cart.Clear();
            foreach (ORDER_DETAIL order in hashtable.Values)
                Cart.Add(order);
            return View(Cart);
        }

        // GET: User/Cart/Details/5
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

        // GET: User/Cart/Create
        [HttpPost]
        public ActionResult Create(int foodId, int quantity)
        {
            GetCartController();
            
            var food = db.FOODs.Find(foodId);
            Cart.Add(new ORDER_DETAIL
            {
                FOOD = food,
                QUANTITY = quantity
               
            });
                


            return RedirectToAction("Index");
        }

        

        // GET: User/Cart/Edit/5
        public ActionResult Edit(int? id)
        {
            GetCartController();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER_DETAIL oRDER_DETAIL = db.ORDER_DETAIL.Find(id);
            if (oRDER_DETAIL == null)
            {
                return HttpNotFound();
            }
            ViewBag.FOOD_ID = new SelectList(db.FOODs, "ID", "FOOD_CODE", oRDER_DETAIL.FOOD_ID);
            ViewBag.ORDER_ID = new SelectList(db.ORDERs, "ID", "ORDER_CODE", oRDER_DETAIL.ORDER_ID);
            return View(oRDER_DETAIL);
        }

        

        // GET: User/Cart/Delete/5
        public ActionResult Delete(int? id)
        {
            GetCartController();
            var st = Cart.Find(s => s.FOOD_ID == id);
            Cart.Remove(st);
           
            Session["Cart"] = Cart;
            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            GetCartController();
            Cart.Clear();
            Session["Cart"] = Cart;
            return RedirectToAction("Index");
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
