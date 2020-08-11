using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class TypeofRatingController : Controller
    {
        // GET: TypeofRating
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateTypeofRating()
        {
            return View();
        }
    }
}