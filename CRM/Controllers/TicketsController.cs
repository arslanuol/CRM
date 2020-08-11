using CRM.Service;
using CRM.VMmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class TicketsController : Controller
    {
        Tickets Service = new Tickets();
        // GET: Tickets
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
        [HandleError]
        [HttpGet]
        public ActionResult Get_ticketpipeline()
        {
            var comp_id = Session["Company_id"];
            var GD = Service.Get_ticketspipline(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }

        [HandleError]
        [HttpGet]
        public ActionResult Get_tickesource()
        {
            var comp_id = Session["Company_id"];
            var GD = Service.Get_ticketsource(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }


        [HandleError]
        [HttpGet]
        public ActionResult Get_ticketstatus()
        {
            var comp_id = Session["Company_id"];
            var GD = Service.Get_ticketstatus(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }
        [HandleError]
        [HttpGet]
        public ActionResult Get_priority()
        {
            var comp_id = Session["Company_id"];
            var GD = Service.Get_priority(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }


        [HandleError]
        [HttpGet]
        public ActionResult Get_contactowner()
        {
            var comp_id = Session["Company_id"];
            var GD = Service.Get_Getcontactowner(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(TicketsVm Vm)
        {
            var ins = Service.AddTickets(Vm);
            return Json(ins, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDetail()
        {
            var comp_id = Session["Company_id"];
            var lst = Service.Get_Detail(comp_id);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}