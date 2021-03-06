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
    
    public partial class call_information
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public call_information()
        {
            this.call_duration = new HashSet<call_duration>();
        }
    
        public int call_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> contact_name_id { get; set; }
        public string subject { get; set; }
        public Nullable<int> related_to_id { get; set; }
        public Nullable<int> call_type_id { get; set; }
        public Nullable<int> owner_id { get; set; }
        public string description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<call_duration> call_duration { get; set; }
        public virtual Company_Information Company_Information { get; set; }
        public virtual Related_to_call Related_to_call { get; set; }
        public virtual type_of_call type_of_call { get; set; }
    }
}
