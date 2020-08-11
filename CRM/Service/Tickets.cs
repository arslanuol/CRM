using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;
using CRM.VMmodel;

namespace CRM.Service
{
    public class Tickets
    {
        CRMEntities db = new CRMEntities();
        public object Get_ticketspipline(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var TP = db.Typesoftickets_pipeline.Where(x => x.Company_id == com_id).Select(x => new { x.tickets_pipeline_id, x.tickets_pipeline_name }).ToList();
                return TP;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Get_ticketstatus(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var TS = db.Types_of_ticketsStatus.Where(x => x.Company_id == com_id).Select(x => new { x.Ticket_status_id, x.Ticket_status_name }).ToList();
                return TS;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public object Get_ticketsource(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var TSR = db.tbl_Type_TicketSource.Where(x => x.Company_id == com_id).Select(x => new { x.Ticket_Source_id, x.Ticket_source_name }).ToList();
                return TSR;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object Get_priority(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var GP = db.Type_of_priority.Where(x => x.Company_id == com_id).Select(x => new { x.priority_type_id, x.priority_name }).ToList();
                return GP;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public object Get_Getcontactowner(object id)
        {
            try
            {
                var com_id = int.Parse(id.ToString());
                var get_owner = db.User_Information.Where(x => x.company_id == com_id).Select(x => new { x.User_id, x.full_name }).ToList();
                return get_owner;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }


        public object AddTickets(TicketsVm vm)
        {
            try
            {
                var check = db.Tickets.Where(x => x.Company_id == vm.Company_id && x.Ticket_name == vm.Ticket_name).Count();
                if (check.ToString() == "0")
                {
                    db.Tickets.Add(new Ticket
                    {
                        Ticket_name = vm.Ticket_name,
                        Ticket_status_id = vm.Ticket_status_id,
                        Ticket_Source_id = vm.Ticket_Source_id,
                        User_id = vm.User_id,
                        priority_type_id = vm.priority_type_id,
                        Created_date = vm.Created_date,
                        Ticket_pipeline_id = vm.Ticket_pipeline_id,
                        Description = vm.Description,
                        Created_by = vm.Created_by,
                        Date_of_creation = vm.Date_of_creation,
                        Company_id = vm.Company_id

                    });
                    db.SaveChanges();
                    return "Success";

                }
                else
                {
                    return "Already";
                }
            }
            catch(Exception ex)
            {
                return ex;
            }
            
        }


        public object Get_Detail(object id)
        {
            try
            {
                var comp_id = int.Parse(id.ToString());
                var rec = from info in db.Tickets
                          join TS in db.Types_of_ticketsStatus on info.Ticket_status_id equals TS.Ticket_status_id
                          join TSR in db.tbl_Type_TicketSource on info.Ticket_Source_id equals TSR.Ticket_Source_id
                          join owner_name in db.User_Information on info.User_id equals owner_name.User_id
                          join PT in db.Type_of_priority on info.priority_type_id equals PT.priority_type_id
                          join TP in db.Typesoftickets_pipeline on info.Ticket_pipeline_id equals TP.tickets_pipeline_id
                          join Crby in db.User_Information on info.User_id equals Crby.User_id
                          join comp in db.Company_Information on info.Company_id equals comp.Company_id
                          where info.Company_id == comp_id
                          select new TicketsVm
                          {
                              Ticket_id = info.Ticket_id,
                              Ticket_name=info.Ticket_name,
                              Ticket_status_name = TS.Ticket_status_name,
                              Ticket_status_id= TS.Ticket_status_id,
                              Ticket_Source_id=TSR.Ticket_Source_id,
                              Ticket_source_name=TSR.Ticket_source_name,
                              User_id = owner_name.User_id,
                              full_name=owner_name.full_name,
                              priority_type_id=PT.priority_type_id,
                              priority_name= PT.priority_name,
                              Created_date=info.Created_date,
                              Ticket_pipeline_id=TP.tickets_pipeline_id,
                              tickets_pipeline_name=TP.tickets_pipeline_name,
                              Description=info.Description,
                              Created_by=Crby.User_id,
                              Date_of_creation=info.Date_of_creation,
                              Company_id = comp.Company_id
                          };
                return (rec.ToList());
            }
            catch (Exception ex)
            {
                return ex;
            }

        }
    }
}