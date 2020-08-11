using CRM.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Service
{
    public class LeadsStatus
    {
        CRMEntities db = new CRMEntities();
        public object Create(Lead_Status obj)
        {
            var check = db.Lead_Status.Where(x => x.Company_id == obj.Company_id && x.Lead_Status_name == obj.Lead_Status_name).Count();
            if(check.ToString()=="0")
            {
                var Ins = db.Lead_Status.Add(obj);
                db.SaveChanges();
                return "Success";
            }
            else
            {
                return "Already";
            }
        }


        public object GetList(object id)
        {
            try
            {
                var comp_id = int.Parse(id.ToString());
                var lst = db.Lead_Status.Where(x => x.Company_id == comp_id).Select(x => new { x.Lead_status_id, x.Lead_Status_name, x.Company_id,x.User_id,x.User_Information.full_name,x.Create_date}).ToList();
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
                var GID = db.Lead_Status.Where(x => x.Lead_status_id == id).Select(x => new { x.Lead_Status_name, x.Lead_status_id, x.Company_id,x.User_id,x.Create_date }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }



        public object Update(Lead_Status obj)
        {
            try
            {
                var check = db.Lead_Status.Where(x => x.Company_id == obj.Company_id && x.Lead_Status_name == obj.Lead_Status_name).Count();
                if (check.ToString() == "0")
                {
                    var Up = db.Lead_Status.Where(x => x.Lead_status_id == obj.Lead_status_id).SingleOrDefault();
                    Up.Lead_Status_name = obj.Lead_Status_name;
                    Up.Company_id = obj.Company_id;
                    Up.Create_date = obj.Create_date;
                    Up.User_id = obj.User_id;
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
                var del = db.Lead_Status.Where(x => x.Lead_status_id == id).SingleOrDefault();
                db.Lead_Status.Remove(del);
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