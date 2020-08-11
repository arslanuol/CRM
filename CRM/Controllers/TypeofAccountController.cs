using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class TypeofAccountController : Controller
    {
        // GET: TypeofAccount
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateTypeofAccount()
        {
            return View();
        }
    }
}