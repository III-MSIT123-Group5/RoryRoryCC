using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BussinessSystem_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        ////登入驗證
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        


    }
}