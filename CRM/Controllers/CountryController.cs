using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Create()
        {
            return View();
        }
    }
}