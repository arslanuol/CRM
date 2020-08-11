using CRM.Service;
using CRM.VMmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class DealsController : Controller
    {
        Deals Service = new Deals();
        // GET: Deals
        [HttpGet]
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


        [HttpGet]
        public ActionResult Get_Pipeline()
        {
            var comp_id = Session["Company_id"];
            var GD = Service.Get_pipeline(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Get_dealType()
        {
            var comp_id = Session["Company_id"];
            var G_type = Service.Get_dealType(comp_id);
            return Json(G_type, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Get_Contact_owner()
        {
            var comp_id = Session["Company_id"];
            var GCO = Service.Get_Contact_Owner(comp_id);
            return Json(GCO, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Get_dealstage()
        {
            var comp_id = Session["Company_id"];
            var GDS = Service.Get_dealstage(comp_id);
            return Json(GDS, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(DealsVm Vm)
        {
            var Ins = Service.Add(Vm);
            return Json(Ins, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDetail()
        {
            var comp_id = Session["Company_id"];
            var lst = Service.Get_Detail(comp_id);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateDeal()
        {
            return View();
        }
    }
}