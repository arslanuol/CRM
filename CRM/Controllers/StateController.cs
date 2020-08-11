using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace CRM.Controllers
{
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult CreateState()
        {
            var list = new SelectList(VMmodel.Country.CountryList(), "key", "value");
            var sortlist = list.OrderBy(p => p.Text).ToList();
            ViewBag.Countries = sortlist;
            return View();
        }
    }
}