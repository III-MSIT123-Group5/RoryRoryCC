using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIPBussinessSystem_MVC.Controllers
{
    public class LoginAccountController : Controller
    {
        // GET: LoginAccount
        // GET: Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}