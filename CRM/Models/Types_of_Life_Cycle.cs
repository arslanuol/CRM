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
    
    public partial class Types_of_Life_Cycle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Types_of_Life_Cycle()
        {
            this.Contact_User = new HashSet<Contact_User>();
        }
    
        public int life_cycle_id { get; set; }
        public string life_cycle_name { get; set; }
        public Nullable<int> Company_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public string Create_date { get; set; }
    
        public virtual Company_Information Company_Information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact_User> Contact_User { get; set; }
        public virtual User_Information User_Information { get; set; }
    }
}
