using CRM.Models;
using CRM.VMmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Service
{
    public class Users_Login
    {
        CRMEntities db = new CRMEntities();

        public CompanyVM Login(string UserName, string Passwod)
        {
            CompanyVM compVM = new CompanyVM();
            try
            {
                var rec = db.User_Information.Where(x => x.email == UserName && x.password == Passwod).Select(x => new { x.User_type.user_type_name, x.User_id }).SingleOrDefault();
                if (rec != null)
                {
                    
                    
                        //var comp_rec = db.Company_Information.Where(x => x.User_id == rec.User_id).Select(x => new { x.Company_id, x.company_name, x.imagee,}).SingleOrDefault();
                        //compVM.role = rec.user_type_name;
                        //compVM.Company_id = comp_rec.Company_id;
                        //compVM.Company_Name = comp_rec.company_name;
                        ////compVM.UserName = UserName;
                        //compVM.logo = comp_rec.imagee;

                    
                }
                return compVM;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}