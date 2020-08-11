using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace CRM.VMmodel
{
    public class DealsVm
    {
        public int deal_information_id { get; set; }
        public int company_id { get; set; }
        public int deal_owner_id { get; set; }
        public string full_name { get; set; }
        public string deal_name { get; set; }
        public int deal_type_id { get; set; }
        public string deal_type_name { get; set; }
        public decimal amont { get; set; }
        public string closing_date { get; set; }
        public int Deals_Pipelines_id { get; set; }
        public string Deals_piplines_name { get; set; }
        public int User_id { get; set; }
        public string Create_date { get; set; }
        public int Deal_Stage_Type_id { get; set; }
        public string Deal_Stage_name { get; set; }
    }
}