//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QRESTModel.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_QREST_DATA_IMPORTS
    {
        public System.Guid IMPORT_IDX { get; set; }
        public string ORG_ID { get; set; }
        public System.Guid SITE_IDX { get; set; }
        public string COMMENT { get; set; }
        public string SUBMISSION_STATUS { get; set; }
        public string IMPORT_USERIDX { get; set; }
        public Nullable<System.DateTime> IMPORT_DT { get; set; }
    
        public virtual T_QREST_ORGANIZATIONS T_QREST_ORGANIZATIONS { get; set; }
        public virtual T_QREST_SITES T_QREST_SITES { get; set; }
    }
}
