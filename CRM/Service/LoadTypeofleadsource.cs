using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Service
{
    public class LoadTypeofleadsource
    {

        CRMEntities db = new CRMEntities();
        public object GetDetail(object id)
        {
            try
            {
                var comp_id = int.Parse(id.ToString());
                var lst = db.Type_of_LeadSource.Where(x => x.company_id == comp_id).Select(x => new { x.leadsource_id, x.leadsource_name, x.company_id }).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}