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
    
    public partial class task_information
    {
        public int task_info_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public string subject { get; set; }
        public string due_date { get; set; }
        public Nullable<int> priority_id { get; set; }
        public Nullable<int> contact_type_id { get; set; }
        public Nullable<int> related_type_id { get; set; }
        public Nullable<int> status_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> task_owner_id { get; set; }
    
        public virtual Company_Information Company_Information { get; set; }
        public virtual contact_type_for_task contact_type_for_task { get; set; }
        public virtual Related_to_Task Related_to_Task { get; set; }
        public virtual status_type_for_task status_type_for_task { get; set; }
    }
}
