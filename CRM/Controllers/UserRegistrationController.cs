using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateUsers()
        {
            return View();
        }
    }
}