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
    
    public partial class T_QREST_SITES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_QREST_SITES()
        {
            this.T_QREST_MONITORS = new HashSet<T_QREST_MONITORS>();
        }
    
        public System.Guid SITE_IDX { get; set; }
        public string ORG_ID { get; set; }
        public string SITE_ID { get; set; }
        public string SITE_NAME { get; set; }
        public string AQS_SITE_ID { get; set; }
        public string STATE_CD { get; set; }
        public string COUNTY_CD { get; set; }
        public Nullable<decimal> LATITUDE { get; set; }
        public Nullable<decimal> LONGITUDE { get; set; }
        public string ELEVATION { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string ZIP_CODE { get; set; }
        public Nullable<System.DateTime> START_DT { get; set; }
        public Nullable<System.DateTime> END_DT { get; set; }
        public Nullable<bool> TELEMETRY_ONLINE_IND { get; set; }
        public string TELEMETRY_SOURCE { get; set; }
        public Nullable<int> TELEMETRY_PORT { get; set; }
        public string TELEMETRY_USERNAME { get; set; }
        public string TELEMETRY_PASSWORD { get; set; }
        public Nullable<bool> AIRNOW_IND { get; set; }
        public string SITE_COMMENTS { get; set; }
        public string CREATE_USER_IDX { get; set; }
        public Nullable<System.DateTime> CREATE_DT { get; set; }
        public string MODIFY_USER_IDX { get; set; }
        public Nullable<System.DateTime> MODIFY_DT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_QREST_MONITORS> T_QREST_MONITORS { get; set; }
        public virtual T_QREST_ORGANIZATIONS T_QREST_ORGANIZATIONS { get; set; }
        public virtual T_QREST_REF_COUNTY T_QREST_REF_COUNTY { get; set; }
    }
}
