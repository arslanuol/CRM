using CRM.Models;
using CRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class CreateTypeofLeadSourceController : Controller
    {
        // GET: CreateTypeofLeadSource
        TypesofLeadSource Service = new TypesofLeadSource();
        public ActionResult Create()
        {
            if (Session["Company_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Athentication", "Login");
            }
        }

        [HttpPost]
        public ActionResult Create(Type_of_LeadSource obj)
        {
            var Ins = Service.Create(obj);
            return Json(Ins,JsonRequestBehavior.AllowGet);
        }

    }
}