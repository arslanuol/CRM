using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.VMmodel
{
    public class ContactVM
    {
        public int id { get; set; }
        public string full_names { get; set; }
        public string last_name { get; set; }
        public int contact_owner { get; set; }
        public string job_title { get; set; }
        public string phone_number { get; set; }
        public int LifeCycle_Stage { get; set; }
        public int lead_status { get; set; }
        public int Company_id { get; set; }
        public string Date_time { get; set; }
        public string Email { get; set; }
        public string Create_date { get; set; }
        public int Created_by { get; set; }
    }
}