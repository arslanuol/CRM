using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Service
{
    public class Life_Cycle_Stage
    {
        CRMEntities db = new CRMEntities();

        public object Create(Types_of_Life_Cycle obj)
        {
            var check = db.Types_of_Life_Cycle.Where(x => x.Company_id == obj.Company_id && x.life_cycle_name == obj.life_cycle_name).Count();
            if (check.ToString() == "0")
            {
                var Ins = db.Types_of_Life_Cycle.Add(obj);
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
                var lst = db.Types_of_Life_Cycle.Where(x => x.Company_id == comp_id).Select(x => new { x.life_cycle_id, x.life_cycle_name, x.Company_id,x.User_Information.full_name,x.User_id,x.Create_date}).ToList();
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
                var GID = db.Types_of_Life_Cycle.Where(x => x.life_cycle_id == id).Select(x => new { x.life_cycle_name, x.life_cycle_id, x.Company_id,x.User_id,x.Create_date }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Update(Types_of_Life_Cycle obj)
        {
            try
            {
                var check = db.Types_of_Life_Cycle.Where(x => x.Company_id == obj.Company_id && x.life_cycle_name == obj.life_cycle_name).Count();
                if (check.ToString() == "0")
                {
                    var Up = db.Types_of_Life_Cycle.Where(x=>x.life_cycle_id==obj.life_cycle_id).SingleOrDefault();
                    Up.life_cycle_name = obj.life_cycle_name;
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
                var del = db.Types_of_Life_Cycle.Where(x => x.life_cycle_id == id).SingleOrDefault();
                db.Types_of_Life_Cycle.Remove(del);
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