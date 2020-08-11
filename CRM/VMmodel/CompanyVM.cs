using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.VMmodel
{
    public class CompanyVM
    {
        public int Company_id { get; set; }
        public string Company_Name { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] logo { get; set; }
        public string role { get; set; }
       
    }
    public class recordlist
    {
        public IList<CompanyVM> records { get; set; }
    }
}