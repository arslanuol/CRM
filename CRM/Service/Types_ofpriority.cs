using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Service
{
    public class Types_ofpriority
    {
        CRMEntities db = new CRMEntities();
        public object Create(Type_of_priority obj)
        {
            var check = db.Type_of_priority.Where(x => x.Company_id == obj.Company_id && x.priority_name == obj.priority_name && x.User_id == obj.User_id).Count();
            if (check.ToString() == "0")
            {
                var Ins = db.Type_of_priority.Add(obj);
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
                var lst = db.Type_of_priority.Where(x => x.Company_id == comp_id).Select(x => new { x.priority_type_id, x.priority_name, x.Company_id, x.User_Information.full_name, x.Create_date }).ToList();
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
                var GID = db.Type_of_priority.Where(x => x.priority_type_id == id).Select(x => new { x.priority_name, x.priority_type_id, x.Company_id, x.User_id }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Update(Type_of_priority obj)
        {
            try
            {
                var check = db.Type_of_priority.Where(x => x.Company_id == obj.Company_id && x.priority_name == obj.priority_name && x.User_id == obj.User_id).Count();
                if (check.ToString() == "0")
                {

                    var Up = db.Type_of_priority.Where(x => x.priority_type_id == obj.priority_type_id).SingleOrDefault();
                    Up.priority_name = obj.priority_name;
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
                var del = db.Type_of_priority.Where(x => x.priority_type_id == id).SingleOrDefault();
                db.Type_of_priority.Remove(del);
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