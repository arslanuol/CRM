using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class UserTypeController : Controller
    {
        // GET: UserType
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateUserType()
        {
            return View();
        }
    }
}