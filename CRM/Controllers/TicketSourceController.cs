using CRM.Models;
using CRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class TicketSourceController : Controller
    {
        Types_of_TicketSource Service = new Types_of_TicketSource();

        // GET: TicketSource
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

        [HttpPost]
        public ActionResult Create(tbl_Type_TicketSource obj)
        {
            var ins = Service.Create(obj);
            return Json(ins, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetDetail()
        {
            var comp_id = Session["Company_id"];
            var lst = Service.GetDetail(comp_id);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }



        [HandleError]
        [HttpGet]
        public ActionResult GetByID(int id)
        {
            var GID = Service.GetByID(id);
            return Json(GID, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult Update(tbl_Type_TicketSource obj)
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