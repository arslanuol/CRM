using CRM.Models;
using CRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class TypesofLeadStatusController : Controller
    {
        LeadsStatus Service = new LeadsStatus();
        CRMEntities db = new CRMEntities();
        // GET: TypesofLeadStatus

       
         [HttpGet]
        public ActionResult Create()
        {
            //return View();
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
        public ActionResult GetDetail()
        {
            var comp_id = Session["Company_id"];
            var lst = Service.GetList(comp_id);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateTypeofLeadStatus()
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
        public ActionResult CreateTypeofLeadStatus(Lead_Status obj)
        {
            var ins = Service.Create(obj);
            return Json(ins,JsonRequestBehavior.AllowGet);
        }

        [HandleError]
        [HttpGet]
        public ActionResult GetByID(int id)
        {
            var GID = Service.GetByID(id);
            return Json(GID, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Update(Lead_Status obj)
        {
            var Up = Service.Update(obj);
            return Json(Up, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Del = Service.Delete(id);
            return Json(Del, JsonRequestBehavior.AllowGet);
        }


    }
}