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
    
    public partial class Type_of_companies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type_of_companies()
        {
            this.Campany_User_Info = new HashSet<Campany_User_Info>();
        }
    
        public int Type_of_comp_id { get; set; }
        public string type_name { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<int> Company_id { get; set; }
        public string Create_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Campany_User_Info> Campany_User_Info { get; set; }
        public virtual Company_Information Company_Information { get; set; }
        public virtual User_Information User_Information { get; set; }
    }
}
