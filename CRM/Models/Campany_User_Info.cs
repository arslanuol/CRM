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
    
    public partial class Campany_User_Info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campany_User_Info()
        {
            this.Company_contact_info = new HashSet<Company_contact_info>();
            this.Company_u_no_emp = new HashSet<Company_u_no_emp>();
        }
    
        public int company_User_ID { get; set; }
        public string company_u_name { get; set; }
        public string company_u_domain { get; set; }
        public Nullable<int> company_owner { get; set; }
        public Nullable<int> Industry_id { get; set; }
        public Nullable<int> Type_of_comp_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<decimal> Annual_revenue { get; set; }
        public string Description { get; set; }
        public string linkedin_page { get; set; }
        public Nullable<int> Company_id { get; set; }
        public string Create_date { get; set; }
    
        public virtual Company_Information Company_Information { get; set; }
        public virtual Type_of_companies Type_of_companies { get; set; }
        public virtual Type_of_Industry Type_of_Industry { get; set; }
        public virtual User_Information User_Information { get; set; }
        public virtual User_Information User_Information1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company_contact_info> Company_contact_info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company_u_no_emp> Company_u_no_emp { get; set; }
    }
}