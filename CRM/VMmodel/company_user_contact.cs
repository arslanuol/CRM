using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.VMmodel
{
    public class company_user_contact
    {
        public int company_User_ID { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string phone_number { get; set; }
        public string postal_code { get; set; }
        public int Company_id { get; set; }
    }
}