using CRM.Service;
using CRM.VMmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class CompaniesController : Controller
    {

        Companies_Info Service = new Companies_Info();
        // GET: Companies
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
        public ActionResult Get_indutry()
        {
            var comp_id = Session["Company_id"];
            var GD = Service.Get_Industry(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Get_Type()
        {
            var comp_id = Session["Company_id"];
            var G_type = Service.Get_Type(comp_id);
            return Json(G_type, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Get_Contact_owner()
        {
            var comp_id = Session["Company_id"];
            var GD = Service.Get_Contact_Owner(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(company_user_info CIN , company_user_contact com_c, company_user_no_emp emp_no)
        {
            var Ins = Service.Add_comapny(CIN,com_c,emp_no);
            return Json(Ins, JsonRequestBehavior.AllowGet);
            //if (Ins == "Success")
            //{
            //    ViewBag.mseg = Ins;
            //}
            //else if (Ins == "Already")
            //{
            //    ViewBag.mseg = Ins;
            //}
            //return View();
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