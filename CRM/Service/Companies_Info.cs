using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using CRM.Models;
using CRM.VMmodel;

namespace CRM.Service
{
    public class Companies_Info
    {
        CRMEntities db = new CRMEntities();

        

        public object Get_Industry(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var GI = db.Type_of_Industry.Where(x => x.company_id == com_id).Select(x => new { x.industry_id, x.industry_name }).ToList();
                return GI;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Get_Type(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var T_Comp = db.Type_of_companies.Where(x => x.Company_id == com_id).Select(x => new { x.Type_of_comp_id, x.type_name }).ToList();
                return T_Comp;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Get_Contact_Owner(object id)
        {
            var com_id = int.Parse(id.ToString());
            var Owner = db.User_Information.Where(x => x.company_id == com_id).Select(x => new { x.User_id, x.full_name }).ToList();
            return Owner;
        }



        public object Add_comapny(company_user_info CIN, company_user_contact Comp_C, company_user_no_emp emp_no)
        {
            try
            {
                var check = db.Campany_User_Info.Where(x => x.Company_id == CIN.Company_id && x.company_u_name == CIN.company_u_name && x.company_User_ID == CIN.company_User_ID).Count();
                if (check.ToString() == "0")
                {
                    db.Campany_User_Info.Add(new Campany_User_Info
                    {
                        company_u_name = CIN.company_u_name,
                        company_u_domain = CIN.company_u_domain,
                        company_owner = CIN.company_owner,
                        Industry_id = CIN.Industry_id,
                        Type_of_comp_id = CIN.Type_of_comp_id,
                        User_id = CIN.User_id,
                        Annual_revenue = CIN.Annual_revenue,
                        Description = CIN.Description,
                        linkedin_page = CIN.linkedin_page,
                        Company_id = CIN.Company_id,
                        Create_date = CIN.Create_date,
                    });
                    db.SaveChanges();
                    var Comp_id = db.Campany_User_Info.Max(x => x.company_User_ID);
                    db.Company_contact_info.Add(new Company_contact_info
                    {
                        company_User_ID = Comp_id,
                        city = Comp_C.city,
                        state = Comp_C.state,
                        phone_number = Comp_C.phone_number,
                        postal_code = Comp_C.postal_code,
                        Company_id = Comp_C.Company_id,
                    });
                    db.SaveChanges();
                    db.Company_u_no_emp.Add(new Company_u_no_emp
                    {
                        company_User_ID = Comp_id,
                        no_emp = emp_no.no_emp,
                        Company_id = emp_no.Company_id,
                    });
                    db.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Already";
                }
            }
            catch(Exception ex)
            {
                return ex;
            }
           
           
        }


        public object Get_Detail(object id)
        {
            try
            {
                
                var comp_id = int.Parse(id.ToString());
                var rec = from info in db.Campany_User_Info
                          join Conc_info in db.Company_contact_info on info.company_User_ID equals Conc_info.company_User_ID
                          join No_emp in db.Company_u_no_emp on info.company_User_ID equals No_emp.company_User_ID
                          join INd in db.Type_of_Industry on info.Industry_id equals INd.industry_id
                          join type_Comp in db.Type_of_companies on info.Type_of_comp_id equals type_Comp.Type_of_comp_id
                          join Comp_owner in db.User_Information on info.User_id equals Comp_owner.User_id
                          where info.Company_id == comp_id
                          select new company_user_info { company_u_domain = info.company_u_domain, company_u_name = info.company_u_name, city=Conc_info.city,state=Conc_info.state,phone_number=Conc_info.phone_number,postal_code=Conc_info.postal_code,no_emp= No_emp .no_emp, Industry_id= INd.industry_id,industry_name=INd.industry_name,Create_date=info.Create_date,full_name=Comp_owner.full_name};
                          
                         //var lst = db.Campany_User_Info.Where(x => x.Company_id == comp_id).Select(x => new { x.company_User_ID, x.company_u_domain, x.company_u_name,x.Type_of_companies.type_name,x.Type_of_Industry.industry_name,x.User_id,x.Annual_revenue,x.Description,x.linkedin_page,x.Create_date,x.User_Information.full_name,x.Company_id}).ToList();
                         //var lsts = db.Company_contact_info.Where(x => x.Company_id == comp_id).Select(x => new { x.city }).ToList(); 

                         return (rec.ToList());
            }
            catch (Exception ex)
            {
                return ex;
            }
        }



        public object GetCompanyName(object id)
        {
            var com_id = int.Parse(id.ToString());
            var Get_Comp_name = db.Campany_User_Info.Where(x => x.Company_id == com_id).Select(x=>new {x.company_User_ID,x.company_u_name,x.company_u_domain}).ToList();
            return Get_Comp_name;
        }
    }
}