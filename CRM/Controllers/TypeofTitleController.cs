using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class TypeofTitleController : Controller
    {
        // GET: TypeofTitle
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateTitle()
        {
            return View();
        }
    }
}