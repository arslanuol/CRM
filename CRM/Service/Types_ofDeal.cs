using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.Service
{
    public class Types_ofDeal
    {
        CRMEntities db = new CRMEntities();

        public object Create(Type_of_deal obj)
        {
            var check = db.Type_of_deal.Where(x => x.company_id == obj.company_id && x.deal_type_name == obj.deal_type_name && x.User_id == obj.User_id).Count();
            if (check.ToString() == "0")
            {
                var Ins = db.Type_of_deal.Add(obj);
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
                var lst = db.Type_of_deal.Where(x => x.company_id == comp_id).Select(x => new { x.deal_type_id, x.deal_type_name, x.company_id, x.User_Information.full_name, x.Create_date }).ToList();
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
                var GID = db.Type_of_deal.Where(x => x.deal_type_id == id).Select(x => new { x.deal_type_name, x.deal_type_id, x.company_id, x.User_id }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Update(Type_of_deal obj)
        {
            try
            {
                var check = db.Type_of_deal.Where(x => x.company_id == obj.company_id && x.deal_type_name == obj.deal_type_name && x.User_id == obj.User_id).Count();
                if (check.ToString() == "0")
                {
                   
                    var Up = db.Type_of_deal.Where(x => x.deal_type_id == obj.deal_type_id).SingleOrDefault();
                    Up.deal_type_name = obj.deal_type_name;
                    Up.company_id = obj.company_id;
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
                var del = db.Type_of_deal.Where(x => x.deal_type_id == id).SingleOrDefault();
                db.Type_of_deal.Remove(del);
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