using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Service
{
    public class TypeofIndustry
    {

        CRMEntities db = new CRMEntities();

        public object Create(Type_of_Industry obj)
        {
            var check = db.Type_of_Industry.Where(x => x.company_id == obj.company_id && x.industry_name == obj.industry_name && x.User_id==obj.User_id).Count();
            if (check.ToString() == "0")
            {
                var Ins = db.Type_of_Industry.Add(obj);
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
                var lst = db.Type_of_Industry.Where(x => x.company_id == comp_id).Select(x => new { x.industry_id, x.industry_name, x.company_id,x.User_Information.full_name,x.Create_Date}).ToList();
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
                var GID = db.Type_of_Industry.Where(x => x.industry_id == id).Select(x => new { x.industry_name, x.industry_id, x.company_id,x.User_id }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Update(Type_of_Industry obj)
        {
            try
            {
                var check = db.Type_of_Industry.Where(x => x.company_id == obj.company_id && x.industry_name == obj.industry_name && x.User_id==obj.User_id).Count();
                if (check.ToString() == "0")
                {
                    var Up = db.Type_of_Industry.Where(x => x.industry_id == obj.industry_id).SingleOrDefault();
                    Up.industry_name = obj.industry_name;
                    Up.company_id = obj.company_id;
                    Up.User_id = obj.User_id;
                    Up.Create_Date = obj.Create_Date;
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
                var del = db.Type_of_Industry.Where(x => x.industry_id == id).SingleOrDefault();
                db.Type_of_Industry.Remove(del);
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