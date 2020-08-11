using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.VMmodel
{
    public class company_user_info
    {
        public int company_User_ID { get; set; }
        public string company_u_name { get; set; }
        public string company_u_domain { get; set; }
        public int company_owner { get; set; }
        public int Industry_id { get; set; }
        public int Type_of_comp_id { get; set; }
        public int User_id { get; set; }
        public decimal Annual_revenue { get; set; }
        public string  Description { get; set; }
        public string linkedin_page { get; set; }
        public int Company_id { get; set; }
        public string Create_date { get; set; }
       
        public string city { get; set; }
        public string state { get; set; }
        public string phone_number { get; set; }
        public string postal_code { get; set; }
        public string no_emp { get; set; }

        public string industry_name { get; set; }

        public string full_name { get; set; }

    }
}