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
    
    public partial class T_QREST_MONITORS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_QREST_MONITORS()
        {
            this.T_QREST_QC_ASSESSMENT = new HashSet<T_QREST_QC_ASSESSMENT>();
            this.T_QREST_SITE_POLL_CONFIG_DTL = new HashSet<T_QREST_SITE_POLL_CONFIG_DTL>();
            this.T_QREST_ASSESS_DOCS = new HashSet<T_QREST_ASSESS_DOCS>();
        }
    
        public System.Guid MONITOR_IDX { get; set; }
        public System.Guid SITE_IDX { get; set; }
        public System.Guid PAR_METHOD_IDX { get; set; }
        public int POC { get; set; }
        public string DURATION_CODE { get; set; }
        public string COLLECT_FREQ_CODE { get; set; }
        public string COLLECT_UNIT_CODE { get; set; }
        public Nullable<double> ALERT_MIN_VALUE { get; set; }
        public Nullable<double> ALERT_MAX_VALUE { get; set; }
        public Nullable<double> ALERT_AMT_CHANGE { get; set; }
        public Nullable<int> ALERT_STUCK_REC_COUNT { get; set; }
        public string CREATE_USER_IDX { get; set; }
        public Nullable<System.DateTime> CREATE_DT { get; set; }
        public string MODIFY_USER_IDX { get; set; }
        public Nullable<System.DateTime> MODIFY_DT { get; set; }
        public string ALERT_MIN_TYPE { get; set; }
        public string ALERT_MAX_TYPE { get; set; }
        public string ALERT_AMT_CHANGE_TYPE { get; set; }
        public string ALERT_STUCK_TYPE { get; set; }
    
        public virtual T_QREST_REF_COLLECT_FREQ T_QREST_REF_COLLECT_FREQ { get; set; }
        public virtual T_QREST_REF_DURATION T_QREST_REF_DURATION { get; set; }
        public virtual T_QREST_REF_PAR_METHODS T_QREST_REF_PAR_METHODS { get; set; }
        public virtual T_QREST_SITES T_QREST_SITES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_QREST_QC_ASSESSMENT> T_QREST_QC_ASSESSMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_QREST_SITE_POLL_CONFIG_DTL> T_QREST_SITE_POLL_CONFIG_DTL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_QREST_ASSESS_DOCS> T_QREST_ASSESS_DOCS { get; set; }
    }
}
