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
    
    public partial class Types_of_ticketsStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Types_of_ticketsStatus()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int Ticket_status_id { get; set; }
        public string Ticket_status_name { get; set; }
        public Nullable<int> Company_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public string Create_date { get; set; }
    
        public virtual Company_Information Company_Information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual User_Information User_Information { get; set; }
    }
}