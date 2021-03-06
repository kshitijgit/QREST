﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QRESTEntities : DbContext
    {
        public QRESTEntities()
            : base("name=QRESTEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_QREST_APP_SETTINGS> T_QREST_APP_SETTINGS { get; set; }
        public virtual DbSet<T_QREST_APP_SETTINGS_CUSTOM> T_QREST_APP_SETTINGS_CUSTOM { get; set; }
        public virtual DbSet<T_QREST_APP_TASKS> T_QREST_APP_TASKS { get; set; }
        public virtual DbSet<T_QREST_EMAIL_TEMPLATE> T_QREST_EMAIL_TEMPLATE { get; set; }
        public virtual DbSet<T_QREST_HELP_DOCS> T_QREST_HELP_DOCS { get; set; }
        public virtual DbSet<T_QREST_ORG_EMAIL_RULE> T_QREST_ORG_EMAIL_RULE { get; set; }
        public virtual DbSet<T_QREST_ORG_USERS> T_QREST_ORG_USERS { get; set; }
        public virtual DbSet<T_QREST_ORGANIZATIONS> T_QREST_ORGANIZATIONS { get; set; }
        public virtual DbSet<T_QREST_QC_ASSESSMENT> T_QREST_QC_ASSESSMENT { get; set; }
        public virtual DbSet<T_QREST_REF_AQS_AGENCY> T_QREST_REF_AQS_AGENCY { get; set; }
        public virtual DbSet<T_QREST_REF_ASSESS_TYPE> T_QREST_REF_ASSESS_TYPE { get; set; }
        public virtual DbSet<T_QREST_REF_COUNTY> T_QREST_REF_COUNTY { get; set; }
        public virtual DbSet<T_QREST_REF_DURATION> T_QREST_REF_DURATION { get; set; }
        public virtual DbSet<T_QREST_REF_PAR_METHODS> T_QREST_REF_PAR_METHODS { get; set; }
        public virtual DbSet<T_QREST_REF_PARAMETERS> T_QREST_REF_PARAMETERS { get; set; }
        public virtual DbSet<T_QREST_REF_REGION> T_QREST_REF_REGION { get; set; }
        public virtual DbSet<T_QREST_REF_STATE> T_QREST_REF_STATE { get; set; }
        public virtual DbSet<T_QREST_REF_UNITS> T_QREST_REF_UNITS { get; set; }
        public virtual DbSet<T_QREST_ROLES> T_QREST_ROLES { get; set; }
        public virtual DbSet<T_QREST_SITE_POLL_CONFIG_DTL> T_QREST_SITE_POLL_CONFIG_DTL { get; set; }
        public virtual DbSet<T_QREST_SITES> T_QREST_SITES { get; set; }
        public virtual DbSet<T_QREST_SYS_LOG> T_QREST_SYS_LOG { get; set; }
        public virtual DbSet<T_QREST_SYS_LOG_ACTIVITY> T_QREST_SYS_LOG_ACTIVITY { get; set; }
        public virtual DbSet<T_QREST_SYS_LOG_EMAIL> T_QREST_SYS_LOG_EMAIL { get; set; }
        public virtual DbSet<T_QREST_USER_CLAIMS> T_QREST_USER_CLAIMS { get; set; }
        public virtual DbSet<T_QREST_USER_LOGINS> T_QREST_USER_LOGINS { get; set; }
        public virtual DbSet<T_QREST_USER_NOTIFICATION> T_QREST_USER_NOTIFICATION { get; set; }
        public virtual DbSet<T_QREST_USERS> T_QREST_USERS { get; set; }
        public virtual DbSet<T_QREST_MONITORS> T_QREST_MONITORS { get; set; }
        public virtual DbSet<T_QREST_REF_COLLECT_FREQ> T_QREST_REF_COLLECT_FREQ { get; set; }
        public virtual DbSet<T_QREST_REF_PAR_UNITS> T_QREST_REF_PAR_UNITS { get; set; }
        public virtual DbSet<T_QREST_DATA_FIVE_MIN> T_QREST_DATA_FIVE_MIN { get; set; }
        public virtual DbSet<T_QREST_REF_TIMEZONE> T_QREST_REF_TIMEZONE { get; set; }
        public virtual DbSet<T_QREST_DATA_HOURLY> T_QREST_DATA_HOURLY { get; set; }
        public virtual DbSet<T_QREST_REF_QUALIFIER> T_QREST_REF_QUALIFIER { get; set; }
        public virtual DbSet<T_QREST_REF_ACCESS_LEVEL> T_QREST_REF_ACCESS_LEVEL { get; set; }
        public virtual DbSet<T_QREST_REF_USER_STATUS> T_QREST_REF_USER_STATUS { get; set; }
        public virtual DbSet<T_QREST_SITE_POLL_CONFIG> T_QREST_SITE_POLL_CONFIG { get; set; }
        public virtual DbSet<T_QREST_SITE_NOTIFY> T_QREST_SITE_NOTIFY { get; set; }
        public virtual DbSet<T_QREST_ASSESS_DOCS> T_QREST_ASSESS_DOCS { get; set; }
        public virtual DbSet<MONITOR_SNAPSHOT> MONITOR_SNAPSHOT { get; set; }
        public virtual DbSet<T_QREST_AQS> T_QREST_AQS { get; set; }
        public virtual DbSet<T_QREST_DATA_IMPORTS> T_QREST_DATA_IMPORTS { get; set; }
    
        public virtual ObjectResult<SP_RPT_MONTHLY_Result> SP_RPT_MONTHLY(Nullable<System.Guid> monid, Nullable<int> mn, Nullable<int> yr, string timetype)
        {
            var monidParameter = monid.HasValue ?
                new ObjectParameter("monid", monid) :
                new ObjectParameter("monid", typeof(System.Guid));
    
            var mnParameter = mn.HasValue ?
                new ObjectParameter("mn", mn) :
                new ObjectParameter("mn", typeof(int));
    
            var yrParameter = yr.HasValue ?
                new ObjectParameter("yr", yr) :
                new ObjectParameter("yr", typeof(int));
    
            var timetypeParameter = timetype != null ?
                new ObjectParameter("timetype", timetype) :
                new ObjectParameter("timetype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_RPT_MONTHLY_Result>("SP_RPT_MONTHLY", monidParameter, mnParameter, yrParameter, timetypeParameter);
        }
    
        public virtual ObjectResult<SP_RPT_MONTHLY_SUMS_Result> SP_RPT_MONTHLY_SUMS(Nullable<System.Guid> monid, Nullable<int> mn, Nullable<int> yr, string timetype)
        {
            var monidParameter = monid.HasValue ?
                new ObjectParameter("monid", monid) :
                new ObjectParameter("monid", typeof(System.Guid));
    
            var mnParameter = mn.HasValue ?
                new ObjectParameter("mn", mn) :
                new ObjectParameter("mn", typeof(int));
    
            var yrParameter = yr.HasValue ?
                new ObjectParameter("yr", yr) :
                new ObjectParameter("yr", typeof(int));
    
            var timetypeParameter = timetype != null ?
                new ObjectParameter("timetype", timetype) :
                new ObjectParameter("timetype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_RPT_MONTHLY_SUMS_Result>("SP_RPT_MONTHLY_SUMS", monidParameter, mnParameter, yrParameter, timetypeParameter);
        }
    
        public virtual ObjectResult<SP_RPT_ANNUAL_Result> SP_RPT_ANNUAL(Nullable<System.Guid> monid, Nullable<int> yr, string timetype)
        {
            var monidParameter = monid.HasValue ?
                new ObjectParameter("monid", monid) :
                new ObjectParameter("monid", typeof(System.Guid));
    
            var yrParameter = yr.HasValue ?
                new ObjectParameter("yr", yr) :
                new ObjectParameter("yr", typeof(int));
    
            var timetypeParameter = timetype != null ?
                new ObjectParameter("timetype", timetype) :
                new ObjectParameter("timetype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_RPT_ANNUAL_Result>("SP_RPT_ANNUAL", monidParameter, yrParameter, timetypeParameter);
        }
    
        public virtual ObjectResult<SP_RPT_ANNUAL_SUMS_Result> SP_RPT_ANNUAL_SUMS(Nullable<System.Guid> monid, Nullable<int> yr, string timetype)
        {
            var monidParameter = monid.HasValue ?
                new ObjectParameter("monid", monid) :
                new ObjectParameter("monid", typeof(System.Guid));
    
            var yrParameter = yr.HasValue ?
                new ObjectParameter("yr", yr) :
                new ObjectParameter("yr", typeof(int));
    
            var timetypeParameter = timetype != null ?
                new ObjectParameter("timetype", timetype) :
                new ObjectParameter("timetype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_RPT_ANNUAL_SUMS_Result>("SP_RPT_ANNUAL_SUMS", monidParameter, yrParameter, timetypeParameter);
        }
    
        public virtual ObjectResult<SP_RPT_DAILY_Result> SP_RPT_DAILY(Nullable<System.Guid> siteid, Nullable<int> mn, Nullable<int> yr, Nullable<int> dy, string timetype)
        {
            var siteidParameter = siteid.HasValue ?
                new ObjectParameter("siteid", siteid) :
                new ObjectParameter("siteid", typeof(System.Guid));
    
            var mnParameter = mn.HasValue ?
                new ObjectParameter("mn", mn) :
                new ObjectParameter("mn", typeof(int));
    
            var yrParameter = yr.HasValue ?
                new ObjectParameter("yr", yr) :
                new ObjectParameter("yr", typeof(int));
    
            var dyParameter = dy.HasValue ?
                new ObjectParameter("dy", dy) :
                new ObjectParameter("dy", typeof(int));
    
            var timetypeParameter = timetype != null ?
                new ObjectParameter("timetype", timetype) :
                new ObjectParameter("timetype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_RPT_DAILY_Result>("SP_RPT_DAILY", siteidParameter, mnParameter, yrParameter, dyParameter, timetypeParameter);
        }
    
        public virtual int SP_VALIDATE_HOURLY()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_VALIDATE_HOURLY");
        }
    
        public virtual ObjectResult<SP_AQS_REVIEW_STATUS_Result> SP_AQS_REVIEW_STATUS(Nullable<System.Guid> siteid, Nullable<System.DateTime> adate)
        {
            var siteidParameter = siteid.HasValue ?
                new ObjectParameter("siteid", siteid) :
                new ObjectParameter("siteid", typeof(System.Guid));
    
            var adateParameter = adate.HasValue ?
                new ObjectParameter("adate", adate) :
                new ObjectParameter("adate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_AQS_REVIEW_STATUS_Result>("SP_AQS_REVIEW_STATUS", siteidParameter, adateParameter);
        }
    }
}
