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
    public class CheckoutController : Controller
    {
        AD1TEAM1 model = new AD1TEAM1();
        // GET: User/Checkout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.account_id = model.ACCOUNTs.OrderByDescending(x => x.ID).ToList();
            ViewBag.customer_id = model.CUSTOMERs.OrderByDescending(x => x.ID).ToList();
            
            return View();
        }
    }
}