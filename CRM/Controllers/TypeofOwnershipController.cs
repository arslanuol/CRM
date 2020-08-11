using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class TypeofOwnershipController : Controller
    {
        // GET: TypeofOwnership
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateTypeofOwnership()
        {
            return View();
        }
    }
}