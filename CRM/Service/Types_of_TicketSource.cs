using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.Service
{
    public class Types_of_TicketSource
    {
        CRMEntities db = new CRMEntities();

        public object Create(tbl_Type_TicketSource obj)
        {
            var check = db.tbl_Type_TicketSource.Where(x => x.Company_id == obj.Company_id && x.Ticket_source_name == obj.Ticket_source_name && x.User_id == obj.User_id).Count();
            if (check.ToString() == "0")
            {
                var Ins = db.tbl_Type_TicketSource.Add(obj);
                db.SaveChanges();
                return "Success";
            }
            else
            {
                return "Already";
            }
        }

        public object GetDetail(object id)
        {
            try
            {
                var comp_id = int.Parse(id.ToString());
                var lst = db.tbl_Type_TicketSource.Where(x => x.Company_id == comp_id).Select(x => new { x.Ticket_Source_id, x.Ticket_source_name, x.Company_id, x.User_Information.full_name, x.Create_date }).ToList();
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
                var GID = db.tbl_Type_TicketSource.Where(x => x.Ticket_Source_id == id).Select(x => new { x.Ticket_source_name, x.Ticket_Source_id, x.Company_id, x.User_id }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Update(tbl_Type_TicketSource obj)
        {
            try
            {
                var check = db.tbl_Type_TicketSource.Where(x => x.Company_id == obj.Company_id && x.Ticket_source_name == obj.Ticket_source_name && x.User_id == obj.User_id).Count();
                if (check.ToString() == "0")
                {

                    var Up = db.tbl_Type_TicketSource.Where(x => x.Ticket_Source_id == obj.Ticket_Source_id).SingleOrDefault();
                    Up.Ticket_source_name= obj.Ticket_source_name;
                    Up.Company_id = obj.Company_id;
                    Up.User_id = obj.User_id;
                    Up.Create_date = obj.Create_date;
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



        public object Delete(int id)
        {
            try
            {
                var del = db.tbl_Type_TicketSource.Where(x => x.Ticket_Source_id == id).SingleOrDefault();
                db.tbl_Type_TicketSource.Remove(del);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex;
            }


        }
    }
}