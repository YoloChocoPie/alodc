using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alodc.Models;

namespace alodc.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        QUANLYCANTEENEntities model = new QUANLYCANTEENEntities();
        // GET: Admin/ProductAdmin
        public ActionResult Index()
        {
            var food = model.FOODs.OrderByDescending(x => x.ID).ToList();
            return View(food);
        }
    }
}