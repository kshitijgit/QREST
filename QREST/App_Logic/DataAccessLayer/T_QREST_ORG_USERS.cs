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
    
    public partial class T_QREST_ORG_USERS
    {
        public System.Guid ORG_USER_IDX { get; set; }
        public string ORG_ID { get; set; }
        public string USER_IDX { get; set; }
        public string ACCESS_LEVEL { get; set; }
        public string STATUS_IND { get; set; }
        public string CREATE_USER_IDX { get; set; }
        public Nullable<System.DateTime> CREATE_DT { get; set; }
        public string MODIFY_USER_IDX { get; set; }
        public Nullable<System.DateTime> MODIFY_DT { get; set; }
    
        public virtual T_QREST_ORGANIZATIONS T_QREST_ORGANIZATIONS { get; set; }
        public virtual T_QREST_USERS T_QREST_USERS { get; set; }
    }
}
