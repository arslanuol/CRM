using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;
namespace CRM.Service
{
    public class Types_of_ticketstatus
    {
        CRMEntities db = new CRMEntities();

        public object Create(Types_of_ticketsStatus obj)
        {
            var check = db.Types_of_ticketsStatus.Where(x => x.Company_id == obj.Company_id && x.Ticket_status_name == obj.Ticket_status_name && x.User_id == obj.User_id).Count();
            if (check.ToString() == "0")
            {
                var Ins = db.Types_of_ticketsStatus.Add(obj);
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
                var lst = db.Types_of_ticketsStatus.Where(x => x.Company_id == comp_id).Select(x => new { x.Ticket_status_id, x.Ticket_status_name, x.Company_id, x.User_Information.full_name, x.Create_date }).ToList();
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
                var GID = db.Types_of_ticketsStatus.Where(x => x.Ticket_status_id == id).Select(x => new { x.Ticket_status_name, x.Ticket_status_id, x.Company_id, x.User_id }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Update(Types_of_ticketsStatus obj)
        {
            try
            {
                var check = db.Types_of_ticketsStatus.Where(x => x.Company_id == obj.Company_id && x.Ticket_status_name == obj.Ticket_status_name && x.User_id == obj.User_id).Count();
                if (check.ToString() == "0")
                {

                    var Up = db.Types_of_ticketsStatus.Where(x => x.Ticket_status_id == obj.Ticket_status_id).SingleOrDefault();
                    Up.Ticket_status_name = obj.Ticket_status_name;
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
                var del = db.Types_of_ticketsStatus.Where(x => x.Ticket_status_id == id).SingleOrDefault();
                db.Types_of_ticketsStatus.Remove(del);
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