using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Service
{
    public class TypesofLeadSource
    {
        CRMEntities db = new CRMEntities();
        public object Create(Type_of_LeadSource obj)
        {
            try
            {
                var check = db.Type_of_LeadSource.Where(x => x.leadsource_name == obj.leadsource_name && x.company_id == obj.company_id).Count();
               
                if (check.ToString()=="0")
                {
                    db.Type_of_LeadSource.Add(obj);
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


        

    }
}