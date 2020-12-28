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
    public class BillController : Controller
    {
        // GET: Admin/Bill
        QUANLYCANTEENEntities model = new QUANLYCANTEENEntities();
        public ActionResult Index()
        {
            var bill = model.ORDERs.OrderByDescending(x => x.ID).ToList();
            return View(bill);
        }

        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.account_id = model.ACCOUNTs.OrderByDescending(x => x.ID).ToList();
            ViewBag.customer_id = model.CUSTOMERs.OrderByDescending(x => x.ID).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ORDER_CODE,DATE,ACCOUNT_ID,CUSTOMER_ID,STATUS,FEEDBACK")]
                        ORDER order)
        {
            if (ModelState.IsValid)
            {
                var order1 = new ORDER();
                order1.ORDER_CODE = order.ORDER_CODE;
                order1.DATE = order.DATE;
                order1.ACCOUNT_ID = order.ACCOUNT_ID;
                order1.CUSTOMER_ID = order.CUSTOMER_ID;
                order1.STATUS = order.STATUS;
                order1.FEEDBACK = order.FEEDBACK;


                model.ORDERs.Add(order1);
                model.SaveChanges();

                Session["Success"] = true;
               
                return RedirectToAction("Index");
            }
            ViewBag.account_id = model.ACCOUNTs.OrderByDescending(x => x.ID).ToList();
            ViewBag.customer_id = model.CUSTOMERs.OrderByDescending(x => x.ID).ToList();
            return View();



        }
        /*var order1 = new ORDER();
               order1.ORDER_CODE = order.ORDER_CODE;
               order1.DATE = order.DATE;
               order1.ACCOUNT_ID = order.ACCOUNT_ID;
               order1.CUSTOMER_ID = order.CUSTOMER_ID;
               order1.STATUS = order.STATUS;
               order1.FEEDBACK = order.FEEDBACK;*/

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var food = model.ORDERs.FirstOrDefault(x => x.ID == id);
            return View(food);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(int id)
        {
            var food = model.ORDERs.FirstOrDefault(x => x.ID == id);
            model.ORDERs.Remove(food);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            /*var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            ViewBag.food_category = model.CATEGORies.OrderByDescending(x => x.ID).ToList();
            return View(food);*/

            ORDER food = model.ORDERs.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.account_id = model.ACCOUNTs.OrderByDescending(x => x.ID).ToList();
            ViewBag.customer_id = model.CUSTOMERs.OrderByDescending(x => x.ID).ToList();
            return View(food);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ORDER order)
        {
            if (ModelState.IsValid)
            {
                var order1 = model.ORDERs.FirstOrDefault(x => x.ID == id);
                order1.ORDER_CODE = order.ORDER_CODE;
                order1.DATE = order.DATE;
                order1.ACCOUNT_ID = order.ACCOUNT_ID;
                order1.CUSTOMER_ID = order.CUSTOMER_ID;
                order1.STATUS = order.STATUS;
                order1.FEEDBACK = order.FEEDBACK;

                model.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.account_id = model.ACCOUNTs.OrderByDescending(x => x.ID).ToList();
            ViewBag.customer_id = model.CUSTOMERs.OrderByDescending(x => x.ID).ToList();
            return View();

        }
        public ActionResult Print(int id)
        {
            var printData = model.ORDERs.FirstOrDefault(x => x.ID == id);
            return View(printData);
        }
    }
}