using CRM.Models;
using CRM.Service;
using CRM.VMmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class ContactController : Controller
    {
        Contact_Users Service = new Contact_Users();
        Deals D_Service = new Deals();
        Companies_Info C_Service = new Companies_Info();
        Tickets T_Service = new Tickets();
        CRMEntities db = new CRMEntities();
        // GET: Contact

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
        public ActionResult Create(ContactVM obj)
        {
            var ins = Service.Insert_data(obj);
            return Json(ins, JsonRequestBehavior.AllowGet);
        }


        [HandleError]
        [HttpGet]
        public ActionResult Get_LifeCycle()
        {
            var comp_id = Session["Company_id"];
            var GD = Service.GetLifeCycleStage(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Get_LeadStatus()
        {
            var Comp_id = Session["Company_id"];
            var Lead_Status = Service.Get_Lead_Status(Comp_id);
            return Json(Lead_Status, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult Get_ContactOwner()
        {
            var Comp_id = Session["Company_id"];
            var Con_Owner = Service.Get_Contact_Owner(Comp_id);
            return Json(Con_Owner, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDetail()
        {
            var Comp_id = Session["Company_id"];
            var Con_Owner = Service.GetList(Comp_id);
            return Json(Con_Owner, JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// Deals
        /// </summary>
        /// <returns></returns>

        public ActionResult Get_Contact_Information()
        {
            if (Session["Company_id"] != null)
            {
                return View();
                //return View();
            }
            else
            {
                return RedirectToAction("Athentication", "Login");
            }
        }


        [HttpGet]
        public ActionResult GetByID(int id)
        {
            var lst = db.Contact_User.Where(x => x.Contact_id == id).Select(x => new { x.email, x.full_names, x.last_name, x.User_Information.full_name, x.phone_Number, x.Contact_id, x.Job_Title, x.Lead_Status1.Lead_Status_name, x.Types_of_Life_Cycle.life_cycle_name, x.Company_id, x.User_Information.User_id, x.Create_date }).SingleOrDefault();
            Session["full_names"] = lst.full_names;
            Session["last_name"] = lst.last_name;
            Session["email"] = lst.email;
            Session["full_name"] = lst.full_name;
            Session["phone_Number"] = lst.phone_Number;
            Session["Contact_id"] = lst.Contact_id;
            Session["Job_Title"] = lst.Job_Title;
            Session["Lead_Status_name"] = lst.Lead_Status_name;
            Session["life_cycle_name"] = lst.life_cycle_name;
            return View("Get_Contact_Information");

        }

        [HttpGet]
        public ActionResult Get_Pipeline()
        {
            var comp_id = Session["Company_id"];
            var GD = D_Service.Get_pipeline(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Get_dealType()
        {
            var comp_id = Session["Company_id"];
            var G_type = D_Service.Get_dealType(comp_id);
            return Json(G_type, JsonRequestBehavior.AllowGet);
        }




        [HttpGet]
        public ActionResult Get_dealstage()
        {
            var comp_id = Session["Company_id"];
            var GDS = D_Service.Get_dealstage(comp_id);
            return Json(GDS, JsonRequestBehavior.AllowGet);
        }





       

        [HttpGet]
        public ActionResult GetDealName()
        {
            var comp_id = Session["Company_id"];
            var Deal_name = Service.GetDealName(comp_id);
            return Json(Deal_name, JsonRequestBehavior.AllowGet);
        }


        [HandleError]
        [HttpGet]
        public ActionResult GetDealowner()
        {

            var comp_id = Session["Company_id"];
            var owner = Service.Get_Deal_owner(comp_id);
            return Json(owner, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DealCreate(DealsVm Vm)
        {
            var ins = D_Service.Add(Vm);
            return Json(ins, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// End Deals
        /// </summary>
        /// <returns></returns>


        

        ///Companies Information
        [HttpGet]
        public ActionResult Get_indutry()
        {
            var comp_id = Session["Company_id"];
            var GD = C_Service.Get_Industry(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Get_Type()
        {
            var comp_id = Session["Company_id"];
            var G_type = C_Service.Get_Type(comp_id);
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
        public ActionResult CreateCompany(company_user_info CIN, company_user_contact com_c, company_user_no_emp emp_no)
        {
            var Ins = C_Service.Add_comapny(CIN, com_c, emp_no);
            return Json(Ins, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetCompanyName()
        {
            var comp_id = Session["Company_id"];
            var GCN = C_Service.GetCompanyName(comp_id);
            return Json(GCN, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// End Companies
        /// </summary>
        /// <returns></returns>


        ///Start Tickets
        [HttpGet]
        public ActionResult Get_ticketpipeline()
        {
            var comp_id = Session["Company_id"];
            var GD = T_Service.Get_ticketspipline(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }


        [HandleError]
        [HttpGet]
        public ActionResult Get_tickesource()
        {
            var comp_id = Session["Company_id"];
            var GD = T_Service.Get_ticketsource(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Get_ticketstatus()
        {
            var comp_id = Session["Company_id"];
            var GD = T_Service.Get_ticketstatus(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }

        [HandleError]
        [HttpGet]
        public ActionResult Get_priority()
        {
            var comp_id = Session["Company_id"];
            var GD = T_Service.Get_priority(comp_id);
            return Json(GD, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Get_Ticketsowner()
        {
            var comp_id = Session["Company_id"];
            var GC = C_Service.Get_Contact_Owner(comp_id);
            return Json(GC, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult CreateTickets(TicketsVm vm)
        {
            var ins = T_Service.AddTickets(vm);
            return Json(ins,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Get_Tickets()
        {

        }

        /// <summary>
        /// End Tikcets
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateContact()
        {
            return View();
        }
    }
}