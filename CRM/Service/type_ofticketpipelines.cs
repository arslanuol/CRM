using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Service
{
    public class type_ofticketpipelines
    {
        CRMEntities db = new CRMEntities();

        public object Create(Typesoftickets_pipeline obj)
        {
            var check = db.Typesoftickets_pipeline.Where(x => x.Company_id == obj.Company_id && x.tickets_pipeline_name == obj.tickets_pipeline_name && x.User_id == obj.User_id).Count();
            if (check.ToString() == "0")
            {
                var Ins = db.Typesoftickets_pipeline.Add(obj);
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
                var lst = db.Typesoftickets_pipeline.Where(x => x.Company_id == comp_id).Select(x => new { x.tickets_pipeline_id, x.tickets_pipeline_name, x.Company_id, x.User_Information.full_name, x.Create_date }).ToList();
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
                var GID = db.Typesoftickets_pipeline.Where(x => x.tickets_pipeline_id == id).Select(x => new { x.tickets_pipeline_name, x.tickets_pipeline_id, x.Company_id, x.User_id }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Update(Typesoftickets_pipeline obj)
        {
            try
            {
                var check = db.Typesoftickets_pipeline.Where(x => x.Company_id == obj.Company_id && x.tickets_pipeline_name == obj.tickets_pipeline_name && x.User_id == obj.User_id).Count();
                if (check.ToString() == "0")
                {

                    var Up = db.Typesoftickets_pipeline.Where(x => x.tickets_pipeline_id == obj.tickets_pipeline_id).SingleOrDefault();
                    Up.tickets_pipeline_name = obj.tickets_pipeline_name;
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
                var del = db.Typesoftickets_pipeline.Where(x => x.tickets_pipeline_id == id).SingleOrDefault();
                db.Typesoftickets_pipeline.Remove(del);
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