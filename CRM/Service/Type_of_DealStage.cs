using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.Service
{
    public class Type_of_DealStage
    {
        CRMEntities db = new CRMEntities();

        public object Create(Type_of_Deal_Stage obj)
        {
            var check = db.Type_of_Deal_Stage.Where(x => x.Company_id == obj.Company_id && x.Deal_Stage_name == obj.Deal_Stage_name && x.User_id == obj.User_id).Count();
            if (check.ToString() == "0")
            {
                var Ins = db.Type_of_Deal_Stage.Add(obj);
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
                var lst = db.Type_of_Deal_Stage.Where(x => x.Company_id == comp_id).Select(x => new { x.Deal_Stage_Type_id, x.Deal_Stage_name, x.Company_id, x.User_Information.full_name, x.Create_date }).ToList();
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
                var GID = db.Type_of_Deal_Stage.Where(x => x.Deal_Stage_Type_id == id).Select(x => new { x.Deal_Stage_name, x.Deal_Stage_Type_id, x.Company_id, x.User_id }).SingleOrDefault();
                return GID;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Update(Type_of_Deal_Stage obj)
        {
            try
            {
                var check = db.Type_of_Deal_Stage.Where(x => x.Company_id == obj.Company_id && x.Deal_Stage_name == obj.Deal_Stage_name && x.User_id == obj.User_id).Count();
                if (check.ToString() == "0")
                {

                    var Up = db.Type_of_Deal_Stage.Where(x => x.Deal_Stage_Type_id == obj.Deal_Stage_Type_id).SingleOrDefault();
                    Up.Deal_Stage_name = obj.Deal_Stage_name;
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
                var del = db.Type_of_Deal_Stage.Where(x => x.Deal_Stage_Type_id == id).SingleOrDefault();
                db.Type_of_Deal_Stage.Remove(del);
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