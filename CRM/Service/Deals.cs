using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;
using CRM.VMmodel;

namespace CRM.Service
{
    public class Deals
    {
        CRMEntities db = new CRMEntities();



        public object Get_pipeline(object id)
        {
            try
            {
                var comp_id = int.Parse(id.ToString());
                var Get_pipline = db.Type_of_Deals_Pipelines.Where(x => x.Company_id == comp_id).Select(x => new { x.Deals_Pipelines_id, x.Deals_piplines_name }).ToList();
                return Get_pipline;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Get_dealType(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var Get_dealtype = db.Type_of_deal.Where(x => x.company_id == com_id).Select(x => new { x.deal_type_id, x.deal_type_name }).ToList();
                return Get_dealtype;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Get_Contact_Owner(object id)
        {
            var com_id = int.Parse(id.ToString());
            var Owner = db.User_Information.Where(x => x.company_id == com_id).Select(x => new { x.User_id, x.full_name }).ToList();
            return Owner;
        }


        public object Get_dealstage(object id)
        {
            var com_id = int.Parse(id.ToString());
            var deal_stage = db.Type_of_Deal_Stage.Where(x => x.Company_id == com_id).Select(x => new { x.Deal_Stage_Type_id, x.Deal_Stage_name }).ToList();
            return deal_stage;
        }

        public object Add(DealsVm Vm)
        {
            var check = db.Deal_information.Where(x => x.company_id == Vm.company_id && x.deal_name == Vm.deal_name).Count();
            if(check.ToString()=="0")
            {
                db.Deal_information.Add(new Deal_information{ 
                    company_id=Vm.company_id,
                    deal_name=Vm.deal_name,
                    deal_owner_id=Vm.User_id,
                    deal_type_id=Vm.deal_type_id,
                    amont=Vm.amont,
                    closing_date=Vm.closing_date,
                    deal_pipeline_id=Vm.Deals_Pipelines_id,
                    User_id=Vm.User_id,
                    Create_date=Vm.Create_date,
                    type_of_dealstage=Vm.Deal_Stage_Type_id,
                });
                db.SaveChanges();
                return "Success";
            }
            else
            {
                return "Already";
            }
        }


        public object Get_Detail(object id)
        {
            try
            {
                var comp_id = int.Parse(id.ToString());
                var rec = from info in db.Deal_information
                          join d_type in db.Type_of_deal on info.deal_type_id equals d_type.deal_type_id
                          join d_stage in db.Type_of_Deal_Stage on info.type_of_dealstage equals d_stage.Deal_Stage_Type_id
                          join d_pipe in db.Type_of_Deals_Pipelines on info.deal_pipeline_id equals d_pipe.Deals_Pipelines_id
                          join Comp_owner in db.User_Information on info.User_id equals Comp_owner.User_id
                          where info.company_id == comp_id
                          select new DealsVm
                          {
                              deal_information_id = info.deal_information_id,
                              User_id = Comp_owner.User_id,
                              full_name= Comp_owner.full_name,
                              deal_type_name=d_type.deal_type_name,
                              deal_name=info.deal_name,
                              
                              closing_date= info.closing_date,
                              Deals_piplines_name=d_pipe.Deals_piplines_name,
                              Create_date=info.Create_date,
                              Deal_Stage_name=d_stage.Deal_Stage_name,


                          };
                return (rec.ToList());
            }
            catch(Exception ex)
            {
                return ex;
            }

        }
    }
}