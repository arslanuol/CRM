using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.VMmodel
{
    public class TicketsVm
    {
        public int Ticket_id { get; set; }
        public string Ticket_name { get; set; }
        public int Ticket_status_id { get; set; }
        public string Ticket_status_name { get; set; }
        public int Ticket_Source_id { get; set; }
        public string Ticket_source_name { get; set; }
        public int User_id { get; set; }
        public string full_name { get; set; }
        public int priority_type_id { get; set; }
        public string priority_name { get; set; }
        public int Ticket_pipeline_id { get; set; }
        public string tickets_pipeline_name { get; set; }
        public string Created_date { get; set; }
        public int Created_by { get; set; }
        public string Date_of_creation { get; set; }
        public int Company_id { get; set; }
        public string Description { get; set; }
    }
}