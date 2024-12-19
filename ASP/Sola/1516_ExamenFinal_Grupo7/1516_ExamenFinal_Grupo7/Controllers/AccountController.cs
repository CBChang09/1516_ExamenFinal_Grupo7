using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1516_ExamenFinal_Grupo7.Controllers
    {
        public class AccountController : Controller
        {
            // GET: Account/Login
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login(string username, string password)
            {

                return RedirectToAction("Index", "Home");
            }
        }
    }

