using CRM.Models;
using CRM.VMmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace CRM.Service
{
    public class Contact_Users
    {
        CRMEntities db = new CRMEntities();
        public object GetLifeCycleStage(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var Life_Cycle = db.Types_of_Life_Cycle.Where(x => x.Company_id == com_id).Select(x => new { x.life_cycle_id, x.life_cycle_name }).ToList();
                return Life_Cycle;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public object Get_Contact_Owner(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var Owner = db.User_Information.Where(x => x.company_id == com_id).Select(x => new { x.User_id, x.full_name }).ToList();
                return Owner;
            }
            catch(Exception ex)
            {
                return ex;
            }
          
        }

        public object Get_Lead_Status(object id)
        {
            try
            {
                var Comp_id = int.Parse(id.ToString());
                var Lead_Status = db.Lead_Status.Where(x => x.Company_id == Comp_id).Select(x => new { x.Lead_status_id, x.Lead_Status_name }).ToList();
                return Lead_Status;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public object Insert_data(ContactVM obj)
        {
            var check = db.Contact_User.Where(x => x.Company_id == obj.Company_id && x.email == obj.Email).Count();
            {
                if(check.ToString()=="0")
                {
                    db.Contact_User.Add(new Contact_User
                    {
                        email = obj.Email.ToString(),
                        full_names=obj.full_names.ToString(),
                        last_name=obj.last_name.ToString(),
                        Contact_owner=obj.contact_owner,
                        Job_Title=obj.job_title.ToString(),
                        phone_Number=obj.phone_number.ToString(),
                        LifeCycle_Stage=obj.LifeCycle_Stage,
                        Lead_Status=obj.lead_status,
                        Company_id=obj.Company_id,
                        Create_date=obj.Create_date,
                        Created_by=obj.Created_by,


                        

                    });
                    db.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Already";
                }


            }



        }

        public object GetList(object id)
        {
            try
            {
                var comp_id = int.Parse(id.ToString());
                var lst = db.Contact_User.Where(x => x.Company_id == comp_id).Select(x => new {x.Contact_id, x.email, x.full_names,x.last_name,x.User_Information.full_name,x.phone_Number,x.Job_Title,x.Lead_Status1.Lead_Status_name,x.Types_of_Life_Cycle.life_cycle_name,x.Company_id,x.User_Information.User_id,x.Create_date}).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object GetByID(int id)
        {
            try
            {
                var lst = db.Contact_User.Where(x => x.Contact_id == id).Select(x => new { x.email, x.full_names, x.last_name, x.User_Information.full_name, x.phone_Number, x.Contact_id, x.Job_Title, x.Lead_Status1.Lead_Status_name, x.Types_of_Life_Cycle.life_cycle_name, x.Company_id, x.User_Information.User_id, x.Create_date }).SingleOrDefault();
                return lst;
            }
            catch(Exception ex)
            {
                return ex;
            }
        }

        public object GetDealName(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var deal_name = db.Deal_information.Where(x => x.company_id == com_id).Select(x => new { x.deal_information_id, x.deal_name }).ToList();
                return deal_name;
            }
            catch(Exception ex)
            {
                return ex;
            }
        }
        public object Get_tickets(object id)
        {
            var comp_id = int.Parse(id.ToString());
            var GT = db.Tickets.Where(x => x.Company_id == comp_id).Select(x => new { x.Ticket_id, x.Ticket_name }).ToList();
            return GT;
        }

        public object Get_Deal_owner(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var owner = db.User_Information.Where(x => x.company_id == com_id).Select(x => new { x.User_id, x.full_name }).ToList();
                return owner;
            }
            catch(Exception ex)
            {
                return ex;
            }
        }
    }
}