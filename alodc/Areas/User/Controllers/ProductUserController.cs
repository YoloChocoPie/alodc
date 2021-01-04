using alodc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace alodc.Areas.User.Controllers
{
    public class ProductUserController : Controller
    {
        // GET: User/ProductUser
        
        QUANLYCANTEENEntities model = new QUANLYCANTEENEntities();
        // GET: Admin/ProductAdmin
        public ActionResult Index()
        {
            var food = model.FOODs.OrderByDescending(x => x.ID).ToList();
            return View(food);
        }

        public ActionResult Index2()

        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                var food = model.FOODs.OrderByDescending(x => x.ID).ToList();
                return View(food);

              

            }


        }


        //GET: Register

        // DƯỚI ĐÂY LÀ CODE ĐĂNG KÍ TUY NHIÊN ĐÃ LÀM ĐƯỢC THÌ MÌNH ĐỂ DỰ PHÒNG BIẾT ĐÂU SẼ LẤY, VCL NHỨC ĐẦU VÃI - LTC

        /*    public ActionResult Register()
            {
                return View();
            }

            //POST: Register
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Register(CUSTOMER cus)
            {
                if (ModelState.IsValid)
                {
                    var check = model.CUSTOMERs.FirstOrDefault(s => s.EMAIL == cus.EMAIL);
                    if (check == null)
                    {
                        cus.PASSWORD = GetMD5(cus.PASSWORD);
                        model.Configuration.ValidateOnSaveEnabled = false;
                        model.CUSTOMERs.Add(cus);
                        model.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "Email already exists";
                        return View();
                    }


                }
                return View();


            }*/







        // Ở TRÊN LẦ ĐĂNG NHẬP, THÌ ĐĂNG NHẬP CHỈ CẦN EMAIL VÀ PASS THÔI, RIGHT?

 /*       public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {

                var f_password = GetMD5(password);
                var data = model.CUSTOMERs.Where(s => s.EMAIL.Equals(email) && s.PASSWORD.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FULL_NAME;
                    Session["Email"] = data.FirstOrDefault().EMAIL;
                    Session["idUser"] = data.FirstOrDefault().ID;
                    return RedirectToAction("Index2");
                }
                else
                {
                    ViewBag.error = "Login failed"; 
                    return RedirectToAction("Login");
                }
            }
            return View();
        }*/


        // DƯỚI NÀY LÀ ĐĂNG KÍ

        public ActionResult CreateUserAccount()
        {
            ViewBag.faculity_id = model.FACULTies.OrderByDescending(x => x.ID).ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserAccount([Bind(Include = "EMAIL,PASSWORD,FULL_NAME,PHONE_NUMBER,STATUS,CUSTOMER_TYPE,FACULTY_ID")]
                        CUSTOMER cus)
        {
            if (ModelState.IsValid)
            {
                var cus1 = new CUSTOMER();
                cus1.EMAIL = cus.EMAIL;
                cus1.PASSWORD = cus.PASSWORD;
                cus1.FULL_NAME = cus.FULL_NAME;
                cus1.PHONE_NUMBER = cus.PHONE_NUMBER;
                cus1.STATUS = cus.STATUS;
                cus1.CUSTOMER_TYPE = cus.CUSTOMER_TYPE;
                cus1.FACULTY_ID = cus.FACULTY_ID;


                model.CUSTOMERs.Add(cus1);
                model.SaveChanges();

                Session["Success"] = true;
                return RedirectToAction("Index2");
            }
            return View();
        }


        // DƯỚI NÀY LÀ ĐĂNG XUẤT NHÁ

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
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
                food1.IMAGE_URL = food.IMAGE_URL;
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
            if (food == null)
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


        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
