using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Service
{
    public class Company_Create
    {
        CRMEntities db = new CRMEntities();
        
        public object Comp_create(Company_Information res, User_Information U_Info, HttpPostedFileBase img, Num_of_Emp_of_Comp No_emp)
        {
            try
            {
                var role = db.User_type.Where(x => x.user_type_name == "CEO").Select(x => x.User_type_id).SingleOrDefault();
                if (role == 0)
                {
                    db.User_type.Add(new User_type
                    {
                        user_type_name = "CEO"
                    });
                    db.SaveChanges();
                }

               
                res.Logo = new byte[img.ContentLength];
                img.InputStream.Read(res.Logo, 0, img.ContentLength);
                db.Company_Information.Add(res);
                db.SaveChanges();


                var valid = valdation(U_Info);
                if (valid != null)
                {
                    var roles = db.User_type.Where(x => x.user_type_name == "CEO").Select(x => x.User_type_id).SingleOrDefault();
                    var comp_id = db.Company_Information.Max(x => x.Company_id);
                    db.Num_of_Emp_of_Comp.Add(new Num_of_Emp_of_Comp
                    {
                       Company_id=comp_id,
                        Num_of_Emp=No_emp.Num_of_Emp
                    });
                   // 
                    db.User_Information.Add(new User_Information
                    {
                        user_type_id = roles,
                        company_id=comp_id,                       
                        email = U_Info.email,
                        password = U_Info.password,
                        confirm_password= U_Info.confirm_password,
                        full_name = U_Info.full_name,
                        last_name=U_Info.last_name

                    });

                    db.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Already";
                }
            }
            catch (Exception ex)
            {

                return ex;
            }
        }




        public object valdation(User_Information obj)
        {
            try
            {
                var res = db.User_Information.Where(x => x.email == obj.email).Count();
                return res;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }




        public object uservalid(string usr)
        {
            try
            {
                var valid = db.User_Information.Where(x => x.email == usr).Count();
                if (valid == 0)
                {
                    return "OK";
                }
                else
                {
                    return "Already";
                }
            }
            catch (Exception ex)
            {

                return ex;
            }
        }


        public object Get_Country()
        {
            var list = db.Country_name.Select(x => new { x.Country_id,x.country_name1 }).ToList();
            return list;
        }

    }
}