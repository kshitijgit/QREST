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
    
    public partial class T_QREST_DATA_FIVE_MIN
    {
        public System.Guid DATA_FIVE_IDX { get; set; }
        public System.Guid MONITOR_IDX { get; set; }
        public Nullable<System.DateTime> DATA_DTTM { get; set; }
        public string DATA_VALUE { get; set; }
        public string UNIT_CODE { get; set; }
        public Nullable<bool> VAL_IND { get; set; }
        public string VAL_CD { get; set; }
        public Nullable<System.DateTime> MODIFY_DT { get; set; }
    }
}