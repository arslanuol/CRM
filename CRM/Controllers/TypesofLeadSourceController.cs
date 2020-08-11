using CRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class TypesofLeadSourceController : Controller
    {
        LoadTypeofleadsource Service = new LoadTypeofleadsource();
        // GET: TypesofLeadSource
        public ActionResult Create()
        {
             
                
                return View();
            
        }

       
        [HttpGet]
        public ActionResult GetDetaill()
        {
            var comp_id = Session["Company_id"];
            var lst = Service.GetDetail(comp_id);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }


    }
}