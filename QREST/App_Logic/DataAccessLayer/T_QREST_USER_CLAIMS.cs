//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QREST.App_Logic.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_QREST_USER_CLAIMS
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    
        public virtual T_QREST_USERS T_QREST_USERS { get; set; }
    }
}
