using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class CampaignController : Controller
    {
        // GET: Campaign
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateCampaign()
        {
            return View();
        }
    }
}