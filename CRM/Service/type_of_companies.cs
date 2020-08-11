using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;
namespace CRM.Service
{
    public class type_of_companies
    {
        CRMEntities db = new CRMEntities();

        public object Create(Type_of_companies obj)
        {
            var check = db.Type_of_companies.Where(x => x.Company_id == obj.Company_id && x.type_name == obj.type_name && x.User_id == obj.User_id).Count();
            if (check.ToString() == "0")
            {
                var Ins = db.Type_of_companies.Add(obj);
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
                var lst = db.Type_of_companies.Where(x => x.Company_id == comp_id).Select(x => new { x.Type_of_comp_id, x.type_name, x.Company_id, x.User_Information.full_name, x.Create_date }).ToList();
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
                var GID = db.Type_of_companies.Where(x => x.Type_of_comp_id == id).Select(x => new { x.type_name, x.Type_of_comp_id, x.Company_id, x.User_id }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Update(Type_of_companies obj)
        {
            try
            {
                var check = db.Type_of_companies.Where(x => x.Company_id == obj.Company_id && x.type_name == obj.type_name && x.User_id == obj.User_id).Count();
                if (check.ToString() == "0")
                {
                    var Up = db.Type_of_companies.Where(x => x.Type_of_comp_id == obj.Type_of_comp_id).SingleOrDefault();
                    Up.type_name = obj.type_name;
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
                var del = db.Type_of_companies.Where(x => x.Type_of_comp_id == id).SingleOrDefault();
                db.Type_of_companies.Remove(del);
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