//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkingSystem_Application.Web.API.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Register
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string EPassword { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<bool> IsVerified { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}