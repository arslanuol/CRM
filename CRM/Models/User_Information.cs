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
    
    public partial class User_Information
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_Information()
        {
            this.Account_information = new HashSet<Account_information>();
            this.campaign_information = new HashSet<campaign_information>();
            this.Campany_User_Info = new HashSet<Campany_User_Info>();
            this.Campany_User_Info1 = new HashSet<Campany_User_Info>();
            this.Contact_information = new HashSet<Contact_information>();
            this.Contact_User = new HashSet<Contact_User>();
            this.Contact_User1 = new HashSet<Contact_User>();
            this.Deal_information = new HashSet<Deal_information>();
            this.Deal_information1 = new HashSet<Deal_information>();
            this.lead_information = new HashSet<lead_information>();
            this.Lead_Status = new HashSet<Lead_Status>();
            this.tbl_Type_TicketSource = new HashSet<tbl_Type_TicketSource>();
            this.Tickets = new HashSet<Ticket>();
            this.Tickets1 = new HashSet<Ticket>();
            this.Type_of_companies = new HashSet<Type_of_companies>();
            this.Type_of_deal = new HashSet<Type_of_deal>();
            this.Type_of_Deal_Stage = new HashSet<Type_of_Deal_Stage>();
            this.Type_of_Deals_Pipelines = new HashSet<Type_of_Deals_Pipelines>();
            this.Type_of_Industry = new HashSet<Type_of_Industry>();
            this.Type_of_LeadStatus = new HashSet<Type_of_LeadStatus>();
            this.Type_of_priority = new HashSet<Type_of_priority>();
            this.Types_of_Life_Cycle = new HashSet<Types_of_Life_Cycle>();
            this.Types_of_ticketsStatus = new HashSet<Types_of_ticketsStatus>();
            this.Typesoftickets_pipeline = new HashSet<Typesoftickets_pipeline>();
            this.User_Contact_Information = new HashSet<User_Contact_Information>();
        }
    
        public int User_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> user_type_id { get; set; }
        public string full_name { get; set; }
        public string last_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account_information> Account_information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<campaign_information> campaign_information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Campany_User_Info> Campany_User_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Campany_User_Info> Campany_User_Info1 { get; set; }
        public virtual Company_Information Company_Information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact_information> Contact_information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact_User> Contact_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact_User> Contact_User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal_information> Deal_information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal_information> Deal_information1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lead_information> lead_information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lead_Status> Lead_Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Type_TicketSource> tbl_Type_TicketSource { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type_of_companies> Type_of_companies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type_of_deal> Type_of_deal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type_of_Deal_Stage> Type_of_Deal_Stage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type_of_Deals_Pipelines> Type_of_Deals_Pipelines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type_of_Industry> Type_of_Industry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type_of_LeadStatus> Type_of_LeadStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type_of_priority> Type_of_priority { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Types_of_Life_Cycle> Types_of_Life_Cycle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Types_of_ticketsStatus> Types_of_ticketsStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Typesoftickets_pipeline> Typesoftickets_pipeline { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Contact_Information> User_Contact_Information { get; set; }
        public virtual User_type User_type { get; set; }
    }
}
