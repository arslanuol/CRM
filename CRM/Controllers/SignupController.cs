using CRM.Models;
using CRM.Service;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class SignupController : Controller
    {
        Company_Create Service = new Company_Create();
        // GET: Signup
        [HttpGet]
        public ActionResult Register()
        {
            //var list = new SelectList(VMmodel.Country.CountryList(), "key", "value");
            //var sortlist = list.OrderBy(p => p.Text).ToList();
            //ViewBag.Countries = sortlist;
            //ViewBag.msg = "";
            return View();
        }

        [HttpPost]
        public ActionResult Register(Company_Information res, User_Information U_Info, HttpPostedFileBase img, Num_of_Emp_of_Comp No_Emp)
        {
            var msg = Service.Comp_create(res,U_Info, img,No_Emp);
            if (msg == "Success")
            {
                ViewBag.mseg = msg;
                return RedirectToAction("Athentication","Login");

            }
            else 
            {
                ViewBag.mseg = msg;
                return View();
            }
             
            
        }



        [HttpPost]
        public ActionResult uservalid(string usr)
        {
            var rec = Service.uservalid(usr);
            return Json(rec, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCountry()
        {
            var lst = Service.Get_Country();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}