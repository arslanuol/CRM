using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class TypeofCampaignStatusController : Controller
    {
        // GET: TypeofCampaignStatus
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateCampaignStatus()
        {
            return View();
        }
    }
}