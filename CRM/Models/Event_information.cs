//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event_information
    {
        public int event_info_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public string event_name { get; set; }
        public string location { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public string host_name { get; set; }
        public string participant_ { get; set; }
        public Nullable<int> related_to_id { get; set; }
        public string user_name { get; set; }
        public string Description { get; set; }
    
        public virtual Company_Information Company_Information { get; set; }
        public virtual Related_to_event Related_to_event { get; set; }
    }
}