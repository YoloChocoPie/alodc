using alodc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCanteen.Areas.User.Middleware;

namespace alodc.Areas.User.Controllers
{
    [LoginVerification]
    public class BillController : Controller
    {
        // GET: User/Bill
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

        public ActionResult Index()
        {
            var model = db.ORDERs.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Create()    
        {
            GetCartController();
            ViewBag.Cart = Cart;
            ViewBag.account_id = db.ACCOUNTs.OrderByDescending(x => x.ID).ToList();
            ViewBag.customer_id = db.CUSTOMERs.OrderByDescending(x => x.ID).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ORDER model)
        {
            ValidateDonDatHang(model);
            if (ModelState.IsValid)
            {
                db.ORDERs.Add(model);
                db.SaveChanges();
                foreach (var item in Cart)
                {
                    db.ORDER_DETAIL.Add(new ORDER_DETAIL
                    {
                        ORDER_ID = model.ID,
                            FOOD_ID = item.FOOD.ID,
                            PRICE = item.FOOD.PRICE,
                            QUANTITY = item.QUANTITY,
                            
                    }) ;
                }
                db.SaveChanges();
                Session["Cart"] = null;
                return RedirectToAction("Index", "ProductUser");
            }
            GetCartController();
            ViewBag.Cart = Cart;
            return View(model);
        }

        private void ValidateDonDatHang(ORDER model)
        {
            GetCartController();
            if (Cart.Count == 0)
            {
                ModelState.AddModelError("", "");
            }
        }
    }
}