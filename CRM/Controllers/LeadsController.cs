using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class LeadsController : Controller
    {
        // GET: Leads
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateLead()
        {
            return View();
        }
    }
}