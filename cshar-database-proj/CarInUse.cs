//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cshar_database_proj
{
    using global::System;
    using global::System.Collections.Generic;
    
    public partial class CarInUse
    {
        public int HireID { get; set; }
        public int ClientID { get; set; }
        public int CarID { get; set; }
        public Nullable<global::System.DateTime> StartTime { get; set; }
        public global::System.DateTime StopTime { get; set; }
    
        public virtual Cars Cars { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
