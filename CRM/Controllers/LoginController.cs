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
    public class LoginController : Controller
    {
        Users_Login Service = new Users_Login();
        //CRMEntities db = new CRMEntities();
        // GET: Login
        public ActionResult Athentication()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Athentication(User_Information objUser)
        {
            //Company_Information rec=new Company_Information();
            if (ModelState.IsValid)
            {
                using (CRMEntities db = new CRMEntities())
                {
                    var obj = db.User_Information.Where(a => a.email.Equals(objUser.email) && a.password.Equals(objUser.password)).Select(a=>new { a.User_type.user_type_name, a.User_id,a.email,a.full_name}).FirstOrDefault();
                   
                    if (obj != null)
                    {

                        var comp_rec = from info in db.Company_Information
                                       join U_info in db.User_Information on info.Company_id equals U_info.company_id
                                       where U_info.email == obj.email
                                       select new CompanyVM { Company_id = info.Company_id, Company_Name= info.company_name, logo=info.Logo };


                        //var comp_rec = db.Company_Information.Where(x => x.User_id == obj.User_id).Select(x => new { x.Company_id, x.company_name, x.imagee, x.full_name}).SingleOrDefault();
                        Session["email"] = obj.email.ToString();
                        Session["full_name"] = obj.full_name.ToString();
                        Session["User_id"] = obj.User_id.ToString();
                        Session["Company_id"] = comp_rec.Select(x => x.Company_id).SingleOrDefault();
                        Session["company_name"] = comp_rec.Select(x => x.Company_Name).SingleOrDefault();


                        var img = comp_rec.Select(x=>x.logo).SingleOrDefault();
                        var base64 = Convert.ToBase64String(img);
                        var imgSrc = String.Format("data:image/gif;base64,{0}", base64);

                        Session["Logo"] = imgSrc;

                        return View("Dashboard");
                    }
                    else
                    {
                        ViewBag.Message = "User Name or Password Is Incorrect";
                        return View("Athentication");
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult Dashboard()
        {
            if (Session["Company_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Athentication");
            }
        }
    }
}