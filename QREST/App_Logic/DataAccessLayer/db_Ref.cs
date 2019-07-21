﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using QREST.App_Logic.BusinessLogicLayer;


namespace QREST.App_Logic.DataAccessLayer
{
    public class LogDisplayType
    {
        public int LOG_ID { get; set; }
        public DateTime? LOG_DT { get; set; }
        public string LOG_TYP { get; set; }
        public string LOG_USERID { get; set; }
        public string LOG_MSG { get; set; }
        public string LOG_USER_NAME { get; set; }
    }

    
    public class AgencyImportType
    {
        public T_QREST_REF_AQS_AGENCY T_QREST_REF_AQS_AGENCY { get; set; }
        public bool VALIDATE_CD { get; set; }
        public string VALIDATE_MSG { get; set; }

        //INITIALIZE
        public AgencyImportType()
        {
            T_QREST_REF_AQS_AGENCY = new T_QREST_REF_AQS_AGENCY();
            VALIDATE_CD = true;
        }
    }


    public class RefParMethodDisplay
    {
        public T_QREST_REF_PAR_METHODS T_QREST_REF_PAR_METHODS { get; set; }
        public string PAR_NAME { get; set; }
        public string UNIT_DESC { get; set; }
    }


    public class db_Ref
    {

        //*****************APP_SETTINGS**********************************
        public static string GetT_QREST_APP_SETTING(string settingName)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_APP_SETTINGS
                            where a.SETTING_NAME == settingName
                            select a).FirstOrDefault().SETTING_VALUE;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static List<T_QREST_APP_SETTINGS> GetT_QREST_APP_SETTING_list() {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_APP_SETTINGS
                            orderby a.SETTING_CAT
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static int InsertOrUpdateT_QREST_APP_SETTINGS(int sETTING_IDX, string sETTING_NAME, string sETTING_VALUE, bool? eNCRYPT_IND, string sETTING_VALUE_SALT, string cREATE_USER)
        {

            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    bool insInd = false;

                    T_QREST_APP_SETTINGS e = (from c in ctx.T_QREST_APP_SETTINGS
                                             where c.SETTING_IDX == sETTING_IDX
                                            select c).FirstOrDefault();

                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_APP_SETTINGS();
                    }

                    if (sETTING_NAME != null) e.SETTING_NAME = sETTING_NAME;
                    if (sETTING_VALUE != null) e.SETTING_VALUE = sETTING_VALUE;

                    e.MODIFY_DT = System.DateTime.Now;
                    e.MODIFY_USER_IDX = cREATE_USER;

                    if (insInd)
                        ctx.T_QREST_APP_SETTINGS.Add(e);

                    ctx.SaveChanges();
                    return e.SETTING_IDX;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return 0;
                }
            }
        }



        //*****************APP_SETTINGS_CUSTOM**********************************
        public static T_QREST_APP_SETTINGS_CUSTOM GetT_QREST_APP_SETTING_CUSTOM()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_APP_SETTINGS_CUSTOM
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static int InsertUpdateT_QREST_APP_SETTING_CUSTOM(string tERMS_AND_CONDITIONS, string aNNOUNCEMENTS)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    Boolean insInd = false;

                    T_QREST_APP_SETTINGS_CUSTOM e = (from c in ctx.T_QREST_APP_SETTINGS_CUSTOM
                                                     select c).FirstOrDefault();

                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_APP_SETTINGS_CUSTOM();
                    }

                    if (tERMS_AND_CONDITIONS != null) e.TERMS_AND_CONDITIONS = UtilsText.GetSafeHtml(tERMS_AND_CONDITIONS);
                    if (aNNOUNCEMENTS != null) e.ANNOUNCEMENTS = UtilsText.GetSafeHtml(aNNOUNCEMENTS);

                    if (insInd)
                        ctx.T_QREST_APP_SETTINGS_CUSTOM.Add(e);

                    ctx.SaveChanges();
                    return e.SETTING_CUSTOM_IDX;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return 0;
                }
            }
        }



        //*****************EMAIL_TEMPLATE **********************************
        public static List<T_QREST_EMAIL_TEMPLATE> GetT_QREST_EMAIL_TEMPLATE()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {

                try
                {
                    return (from a in ctx.T_QREST_EMAIL_TEMPLATE
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_EMAIL_TEMPLATE GetT_QREST_EMAIL_TEMPLATE_ByID(int id)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_EMAIL_TEMPLATE
                            where a.EMAIL_TEMPLATE_ID == id
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_EMAIL_TEMPLATE GetT_QREST_EMAIL_TEMPLATE_ByName(string name)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_EMAIL_TEMPLATE
                            where a.EMAIL_TEMPLATE_NAME == name
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static int InsertUpdateT_QREST_EMAIL_TEMPLATE(int? eMAIL_TEMPLATE_ID, string sUBJ, string mSG, string UserID)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    Boolean insInd = false;

                    T_QREST_EMAIL_TEMPLATE e = (from c in ctx.T_QREST_EMAIL_TEMPLATE
                                                where c.EMAIL_TEMPLATE_ID == eMAIL_TEMPLATE_ID
                                                select c).FirstOrDefault();

                    //insert case
                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_EMAIL_TEMPLATE();
                    }

                    e.MODIFY_DT = System.DateTime.UtcNow;
                    e.MODIFY_USER_IDX = UserID;

                    if (sUBJ != null) e.SUBJ = sUBJ;
                    if (mSG != null) e.MSG = mSG;

                    if (insInd)
                        ctx.T_QREST_EMAIL_TEMPLATE.Add(e);

                    ctx.SaveChanges();
                    return e.EMAIL_TEMPLATE_ID;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return 0;
                }
            }
        }



        //***************** ORGANZIATIONS ******************************
        public static List<T_QREST_ORGANIZATIONS> GetT_QREST_ORGANIZATIONS(bool actInd)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_ORGANIZATIONS
                            where (actInd == true ? a.ACT_IND == true : true)
                            orderby a.ORG_NAME
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_ORGANIZATIONS GetT_QREST_ORGANIZATION_ByID(string id)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_ORGANIZATIONS
                            where a.ORG_ID == id
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static List<T_QREST_ORGANIZATIONS> GetT_QREST_ORGANIZATION_ByEmail(string email)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    var domain = Regex.Match(email, "@(.*)").Groups[1].Value;

                    return (from a in ctx.T_QREST_ORGANIZATIONS
                            join b in ctx.T_QREST_ORG_EMAIL_RULE on a.ORG_ID equals b.ORG_ID
                            where b.EMAIL_STRING.ToUpper() == domain.ToUpper()
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    throw ex;
                }
            }
        }

        public static int InsertUpdatetT_QREST_ORGANIZATION(string oRG_ID, string oRG_NAME, string sTATE_CD, int? ePA_REGION, string aQS_NAAS_UID, string aQS_NAAS_PWD,
            string aQS_AGENCY_CODE, bool? aCT_IND, string cREATE_USER)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    Boolean insInd = false;

                    T_QREST_ORGANIZATIONS e = (from c in ctx.T_QREST_ORGANIZATIONS
                                               where c.ORG_ID == oRG_ID
                                               select c).FirstOrDefault();

                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_ORGANIZATIONS();
                        e.ORG_ID = oRG_ID;
                        e.CREATE_DT = System.DateTime.Now;
                        e.CREATE_USER_IDX = cREATE_USER;
                    }
                    else
                    {
                        e.MODIFY_DT = System.DateTime.Now;
                        e.MODIFY_USER_IDX = cREATE_USER;
                    }

                    if (oRG_NAME != null) e.ORG_NAME = oRG_NAME;
                    if (sTATE_CD != null) e.STATE_CD = sTATE_CD;
                    if (ePA_REGION != null) e.EPA_REGION = ePA_REGION;
                    if (aQS_AGENCY_CODE != null) e.AQS_AGENCY_CODE = aQS_AGENCY_CODE;
                    if (aQS_NAAS_UID != null) e.AQS_NAAS_UID = aQS_NAAS_UID;
                    if (aQS_NAAS_PWD != null) e.AQS_NAAS_PWD = aQS_NAAS_PWD;
                    if (aCT_IND != null) e.ACT_IND = aCT_IND ?? true;


                    if (insInd)
                        ctx.T_QREST_ORGANIZATIONS.Add(e);

                    ctx.SaveChanges();
                    return 1;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return 0;
                }
            }
        }

        public static int DeleteT_QREST_ORGANIZATIONS(string id)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    //don't delete if there are sites for the org
                    List<T_QREST_SITES> _sites = db_Air.GetT_QREST_SITES_ByOrgID(id);
                    if (_sites == null || _sites.Count==0)
                    {
                        T_QREST_ORGANIZATIONS rec = new T_QREST_ORGANIZATIONS { ORG_ID = id };
                        ctx.Entry(rec).State = System.Data.Entity.EntityState.Deleted;
                        ctx.SaveChanges();

                        return 1;
                    }
                    else
                        return -1;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return 0;
                }
            }
        }



        //***************** REF_AQS_AGENCY ******************************
        public static List<T_QREST_REF_AQS_AGENCY> GetT_QREST_REF_AQS_AGENCY()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_AQS_AGENCY
                            orderby a.AQS_AGENCY_NAME
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_REF_AQS_AGENCY GetT_QREST_REF_AQS_AGENCY_ByID(string id)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_AQS_AGENCY
                            where a.AQS_AGENCY_CODE == id
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static bool InsertUpdatetT_QREST_REF_AQS_AGENCY(string aQS_AGENCY_CODE, string aQS_AGENCY_NAME, string aQS_AGENCY_TYPE, bool? aCT_IND, string cREATE_USER)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    Boolean insInd = false;

                    T_QREST_REF_AQS_AGENCY e = (from c in ctx.T_QREST_REF_AQS_AGENCY
                                                where c.AQS_AGENCY_CODE == aQS_AGENCY_CODE
                                                 select c).FirstOrDefault();

                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_REF_AQS_AGENCY();
                        e.AQS_AGENCY_CODE = aQS_AGENCY_CODE;
                    }

                    if (aQS_AGENCY_NAME != null) e.AQS_AGENCY_NAME = aQS_AGENCY_NAME;
                    if (aQS_AGENCY_TYPE != null) e.AQS_AGENCY_TYPE = aQS_AGENCY_TYPE;

                    if (insInd)
                        ctx.T_QREST_REF_AQS_AGENCY.Add(e);

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return false;
                }
            }
        }



        //***************** REF_COLLECT_FREQ ******************************
        public static List<T_QREST_REF_COLLECT_FREQ> GetT_QREST_REF_COLLECT_FREQ()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_COLLECT_FREQ
                            orderby a.COLLECT_FREQ_CODE
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_REF_COLLECT_FREQ GetT_QREST_REF_COLLECT_FREQ_ByID(string id)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_COLLECT_FREQ
                            where a.COLLECT_FREQ_CODE == id
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static bool InsertUpdatetT_QREST_REF_COLLECT_FREQ(string cOLLECT_FREQ_CODE, string cOLLECT_FREQ_DESC, bool? aCT_IND, string cREATE_USER)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    Boolean insInd = false;

                    T_QREST_REF_COLLECT_FREQ e = (from c in ctx.T_QREST_REF_COLLECT_FREQ
                                                  where c.COLLECT_FREQ_CODE == cOLLECT_FREQ_CODE
                                              select c).FirstOrDefault();

                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_REF_COLLECT_FREQ();
                        e.COLLECT_FREQ_CODE = cOLLECT_FREQ_CODE;
                        e.CREATE_DT = System.DateTime.Now;
                        e.CREATE_USER_IDX = cREATE_USER;
                    }
                    else
                    {
                        e.MODIFY_DT = System.DateTime.Now;
                        e.MODIFY_USER_IDX = cREATE_USER;
                    }

                    if (cOLLECT_FREQ_DESC != null) e.COLLECT_FEQ_DESC = cOLLECT_FREQ_DESC;
                    if (aCT_IND != null) e.ACT_IND = aCT_IND ?? true;

                    if (insInd)
                        ctx.T_QREST_REF_COLLECT_FREQ.Add(e);

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return false;
                }
            }
        }



        //***************** REF_DURATION ******************************
        public static List<T_QREST_REF_DURATION> GetT_QREST_REF_DURATION()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_DURATION
                            orderby a.DURATION_CODE
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_REF_DURATION GetT_QREST_REF_DURATION_ByID(string id)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_DURATION
                            where a.DURATION_CODE == id
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static bool InsertUpdatetT_QREST_REF_DURATION(string dURATION_CODE, string dURATION_DESC, bool? aCT_IND, string cREATE_USER)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    Boolean insInd = false;

                    T_QREST_REF_DURATION e = (from c in ctx.T_QREST_REF_DURATION
                                                where c.DURATION_CODE == dURATION_CODE
                                                select c).FirstOrDefault();

                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_REF_DURATION();
                        e.DURATION_CODE = dURATION_CODE;
                        e.CREATE_DT = System.DateTime.Now;
                        e.CREATE_USER_IDX = cREATE_USER;
                    }
                    else
                    {
                        e.MODIFY_DT = System.DateTime.Now;
                        e.MODIFY_USER_IDX = cREATE_USER;
                    }

                    if (dURATION_DESC != null) e.DURATION_DESC = dURATION_DESC;
                    if (aCT_IND != null) e.ACT_IND = aCT_IND ?? true;

                    if (insInd)
                        ctx.T_QREST_REF_DURATION.Add(e);

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return false;
                }
            }
        }



        //***************** REF_PAR_METHODS ******************************
        public static List<T_QREST_REF_PAR_METHODS> GetT_QREST_REF_PAR_METHODS()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_PAR_METHODS
                            orderby a.PAR_CODE, a.METHOD_CODE
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_REF_PAR_METHODS GetT_QREST_REF_PAR_METHODS_ByParCdMethodCd(string parCD, string methodCD)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_PAR_METHODS
                            where a.PAR_CODE == parCD
                            && a.METHOD_CODE == methodCD
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static bool InsertUpdatetT_QREST_REF_PAR_METHODS(Guid? pAR_METHOD_IDX, string pAR_CODE, string mETHOD_CODE, string rECORDING_MODE, string cOLLECTION_DESC, string aNALYSIS_DESC,
            string rEFERENCE_METHOD_ID, string eQUIVALENT_METHOD, string sTD_UNIT_CODE, double? fED_MDL, double? mIN_VALUE, double? mAX_VALUE, bool? aCT_IND, string cREATE_USER)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    bool insInd = false;

                    T_QREST_REF_PAR_METHODS e = null;

                    //first try to get from IDX
                    if (pAR_METHOD_IDX != null)
                        e = (from c in ctx.T_QREST_REF_PAR_METHODS
                             where c.PAR_METHOD_IDX == pAR_METHOD_IDX
                             select c).FirstOrDefault();

                    //then get from par and method
                    if (e == null)
                        e = (from c in ctx.T_QREST_REF_PAR_METHODS
                             where c.PAR_CODE == pAR_CODE
                             && c.METHOD_CODE == mETHOD_CODE
                             select c).FirstOrDefault();

                    //then 
                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_REF_PAR_METHODS();
                        e.PAR_METHOD_IDX = Guid.NewGuid();
                        e.PAR_CODE = pAR_CODE;
                        e.METHOD_CODE = mETHOD_CODE;
                        e.CREATE_DT = System.DateTime.Now;
                        e.CREATE_USER_IDX = cREATE_USER;
                    }
                    else
                    {
                        e.MODIFY_DT = System.DateTime.Now;
                        e.MODIFY_USER_IDX = cREATE_USER;
                    }

                    if (rECORDING_MODE != null) e.RECORDING_MODE = rECORDING_MODE;
                    if (cOLLECTION_DESC != null) e.COLLECTION_DESC = cOLLECTION_DESC;
                    if (aNALYSIS_DESC != null) e.ANALYSIS_DESC = aNALYSIS_DESC;
                    if (rEFERENCE_METHOD_ID != null) e.REFERENCE_METHOD_ID = rEFERENCE_METHOD_ID;
                    if (eQUIVALENT_METHOD != null) e.EQUIVALENT_METHOD = eQUIVALENT_METHOD;
                    if (sTD_UNIT_CODE != null) e.STD_UNIT_CODE = sTD_UNIT_CODE;
                    if (fED_MDL != null) e.FED_MDL = fED_MDL;
                    if (mIN_VALUE != null) e.MIN_VALUE = mIN_VALUE;
                    if (mAX_VALUE != null) e.MAX_VALUE = mAX_VALUE;
                    if (aCT_IND != null) e.ACT_IND = aCT_IND ?? true;

                    if (insInd)
                        ctx.T_QREST_REF_PAR_METHODS.Add(e);

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return false;
                }
            }
        }

        public static List<RefParMethodDisplay> GetT_QREST_REF_PAR_METHODS_Search(string strPar, string strCollMethod, int pageSize, int? skip, int orderBy, string orderDir = "asc")
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    if (strPar == null) strPar = "";
                    if (strCollMethod == null) strCollMethod = "";
                    string orderCol = (orderBy == 3 ? "PAR_NAME" : "PAR_NAME");

                    return (from a in ctx.T_QREST_REF_PAR_METHODS
                            join p in ctx.T_QREST_REF_PARAMETERS on a.PAR_CODE equals p.PAR_CODE
                            join u in ctx.T_QREST_REF_UNITS on a.STD_UNIT_CODE equals u.UNIT_CODE
                            where (strPar.Length>0 ? (p.PAR_NAME.Contains(strPar) || p.PAR_CODE.Contains(strPar) || a.METHOD_CODE.Contains(strPar)) : true)
                            orderby a.PAR_CODE, a.METHOD_CODE
                            select new RefParMethodDisplay {
                                T_QREST_REF_PAR_METHODS = a,
                                PAR_NAME = p.PAR_NAME,
                                UNIT_DESC = u.UNIT_DESC
                            }).OrderBy(orderCol, orderDir).Skip(skip ?? 0).Take(pageSize).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static int GetT_QREST_REF_PAR_METHODS_Count(string strPar, string strCollMethod)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    if (strPar == null) strPar = "";
                    if (strCollMethod == null) strCollMethod = "";

                    return (from a in ctx.T_QREST_REF_PAR_METHODS
                            join p in ctx.T_QREST_REF_PARAMETERS on a.PAR_CODE equals p.PAR_CODE
                            where (strPar.Length > 0 ? (p.PAR_NAME.Contains(strPar) || p.PAR_CODE.Contains(strPar) || a.METHOD_CODE.Contains(strPar)) : true)
                            select a).Count();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return 0;
                }
            }
        }



        //***************** REF_PARAMETERS ******************************
        public static List<T_QREST_REF_PARAMETERS> GetT_QREST_REF_PARAMETERS()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_PARAMETERS
                            orderby a.PAR_CODE
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_REF_PARAMETERS GetT_QREST_REF_PARAMETERS_ByID(string id)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_PARAMETERS
                            where a.PAR_CODE == id
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static bool InsertUpdatetT_QREST_REF_PARAMETERS(string pAR_CODE, string pAR_NAME, string pAR_NAME_ALT, string cAS_NUM, string sTD_UNIT_CODE, bool? aCT_IND, string cREATE_USER)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    Boolean insInd = false;

                    T_QREST_REF_PARAMETERS e = (from c in ctx.T_QREST_REF_PARAMETERS
                                              where c.PAR_CODE == pAR_CODE
                                              select c).FirstOrDefault();

                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_REF_PARAMETERS();
                        e.PAR_CODE = pAR_CODE;
                        e.CREATE_DT = System.DateTime.Now;
                        e.CREATE_USER_IDX = cREATE_USER;
                    }
                    else
                    {
                        e.MODIFY_DT = System.DateTime.Now;
                        e.MODIFY_USER_IDX = cREATE_USER;
                    }

                    if (pAR_NAME != null) e.PAR_NAME = pAR_NAME;
                    if (pAR_NAME_ALT != null) e.PAR_NAME_ALT = pAR_NAME_ALT;
                    if (cAS_NUM != null) e.CAS_NUM = cAS_NUM;
                    if (sTD_UNIT_CODE != null) e.STD_UNIT_CODE = sTD_UNIT_CODE;

                    if (aCT_IND != null) e.ACT_IND = aCT_IND ?? true;

                    if (insInd)
                        ctx.T_QREST_REF_PARAMETERS.Add(e);

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return false;
                }
            }
        }



        //***************** REF_REGION ******************************
        public static List<T_QREST_REF_REGION> GetT_QREST_REF_REGION()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_REGION
                            orderby a.EPA_REGION
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }



        //***************** REF_STATE ******************************
        public static List<T_QREST_REF_STATE> GetT_QREST_REF_STATE()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_STATE
                            orderby a.STATE_NAME
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }



        //***************** REF_UNITS ******************************
        public static List<T_QREST_REF_UNITS> GetT_QREST_REF_UNITS()
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_UNITS
                            orderby a.UNIT_CODE
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_REF_UNITS GetT_QREST_REF_UNITS_ByID(string id)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_UNITS
                            where a.UNIT_CODE == id
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static T_QREST_REF_UNITS GetT_QREST_REF_UNITS_ByDesc(string desc)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    return (from a in ctx.T_QREST_REF_UNITS
                            where a.UNIT_DESC == desc
                            select a).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return null;
                }
            }
        }

        public static bool InsertUpdatetT_QREST_REF_UNITS(string uNIT_CODE, string uNIT_DESC, bool? aCT_IND, string cREATE_USER)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    Boolean insInd = false;

                    T_QREST_REF_UNITS e = (from c in ctx.T_QREST_REF_UNITS
                                           where c.UNIT_CODE == uNIT_CODE
                                              select c).FirstOrDefault();

                    if (e == null)
                    {
                        insInd = true;
                        e = new T_QREST_REF_UNITS();
                        e.UNIT_CODE = uNIT_CODE;
                        e.CREATE_DT = System.DateTime.Now;
                        e.CREATE_USER_IDX = cREATE_USER;
                    }
                    else
                    {
                        e.MODIFY_DT = System.DateTime.Now;
                        e.MODIFY_USER_IDX = cREATE_USER;
                    }

                    if (uNIT_DESC != null) e.UNIT_DESC = uNIT_DESC;
                    if (aCT_IND != null) e.ACT_IND = aCT_IND ?? true;

                    if (insInd)
                        ctx.T_QREST_REF_UNITS.Add(e);

                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return false;
                }
            }
        }
        


        //*****************SYS_LOG **********************************
        public static int CreateT_QREST_SYS_LOG(string lOG_USERID, string lOG_TYPE, string lOG_MSG)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    T_QREST_SYS_LOG a = new T_QREST_SYS_LOG
                    {
                        LOG_DT = System.DateTime.Now,
                        LOG_TYP = lOG_TYPE ?? "ERROR",
                        LOG_USERID = lOG_USERID,
                        LOG_MSG = lOG_MSG.SubStringPlus(0, 2000)
                    };

                    ctx.T_QREST_SYS_LOG.Add(a);
                    ctx.SaveChanges();
                    return a.LOG_ID;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static List<LogDisplayType> GetT_QREST_SYS_LOG(DateTime? DateFrom, DateTime? DateTo, int pageSize, int? skip, int orderBy, string orderDir = "asc")
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    DateTime DateFromDt = (DateFrom == null ? System.DateTime.Today.AddYears(-10) : new DateTime(DateFrom.ConvertOrDefault<DateTime>().Year, DateFrom.ConvertOrDefault<DateTime>().Month, DateFrom.ConvertOrDefault<DateTime>().Day, 0, 0, 0));
                    DateTime DateToDt = (DateTo == null ? System.DateTime.Today.AddYears(1) : new DateTime(DateTo.ConvertOrDefault<DateTime>().Year, DateTo.ConvertOrDefault<DateTime>().Month, DateTo.ConvertOrDefault<DateTime>().Day, 23, 59, 59));

                    string orderCol = (orderBy == 3 ? "LOG_MSG" : "LOG_ID");

                    return (from a in ctx.T_QREST_SYS_LOG
                            join d in ctx.T_QREST_USERS on a.LOG_USERID equals d.USER_IDX
                                into lj from d in lj.DefaultIfEmpty() //left join on duration
                            where a.LOG_DT >= DateFromDt
                            && a.LOG_DT <= DateToDt
                            select new LogDisplayType {
                                LOG_ID = a.LOG_ID,
                                LOG_DT = a.LOG_DT,
                                LOG_MSG = a.LOG_MSG,
                                LOG_TYP = a.LOG_TYP,
                                LOG_USERID = a.LOG_USERID,
                                LOG_USER_NAME = d.Email
                            }).OrderBy(orderCol, orderDir).Skip(skip??0).Take(pageSize).ToList();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
               
        public static int GetT_QREST_SYS_LOG_count(DateTime? DateFrom, DateTime? DateTo)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    DateTime DateFromDt = (DateFrom == null ? System.DateTime.Today.AddYears(-10) : new DateTime(DateFrom.ConvertOrDefault<DateTime>().Year, DateFrom.ConvertOrDefault<DateTime>().Month, DateFrom.ConvertOrDefault<DateTime>().Day, 0, 0, 0));
                    DateTime DateToDt = (DateTo == null ? System.DateTime.Today.AddYears(1) : new DateTime(DateTo.ConvertOrDefault<DateTime>().Year, DateTo.ConvertOrDefault<DateTime>().Month, DateTo.ConvertOrDefault<DateTime>().Day, 23, 59, 59));

                    var xxx = (from a in ctx.T_QREST_SYS_LOG
                               where a.LOG_DT >= DateFromDt
                               && a.LOG_DT <= DateToDt
                               select a).Count();

                    return xxx;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        //*****************SYS_LOG_ACTIVITY **********************************
        public static int CreateT_QREST_SYS_LOG_ACTIVITY(string aCTIVITY_TYPE, string aCTIVITY_USER, DateTime? lOG_DT, string aCTIVITY_DESC, string hostName)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    //first check if user has accessed claim today. If yes, then don't log
                    if (GetT_QREST_SYS_LOG_ACTIVITY_today(aCTIVITY_TYPE, aCTIVITY_USER, aCTIVITY_DESC) > 0)
                        return 0;

                    T_QREST_SYS_LOG_ACTIVITY a = new T_QREST_SYS_LOG_ACTIVITY
                    {
                        ACTIVITY_TYPE = aCTIVITY_TYPE,
                        ACTIVITY_USER = aCTIVITY_USER.ToUpper(),
                        ACTIVITY_DT = lOG_DT,
                        ACTIVITY_DESC = aCTIVITY_DESC,
                        IP_ADDRESS = GetIP.GetLocalIPAddress(System.Web.HttpContext.Current)
                    };

                    ctx.T_QREST_SYS_LOG_ACTIVITY.Add(a);
                    ctx.SaveChanges();
                    return a.LOG_ACTIVITY_IDX;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return 0;
                }
            }
        }

        public static int GetT_QREST_SYS_LOG_ACTIVITY_today(string actType, string user, string activity_desc)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    DateTime startDtTime = DateTime.Today;

                    return (from a in ctx.T_QREST_SYS_LOG_ACTIVITY
                            where a.ACTIVITY_TYPE == actType
                            && a.ACTIVITY_USER == user.ToUpper()
                            && (activity_desc != null ? a.ACTIVITY_DESC == activity_desc : true)
                            && a.ACTIVITY_DT >= startDtTime
                            select a).ToList().Count;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return 0;
                }
            }
        }



        //*****************SYS_LOG_EMAIL **********************************
        public static int CreateT_QREST_SYS_LOG_EMAIL(string eMAIL_FROM, string eMAIL_TO, string eMAIL_CC, string eMAIL_SUBJ, string eMAIL_MSG, string eMAIL_TYPE)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    T_QREST_SYS_LOG_EMAIL a = new T_QREST_SYS_LOG_EMAIL
                    {
                        EMAIL_DT = System.DateTime.Now,
                        EMAIL_FROM = eMAIL_FROM,
                        EMAIL_TO = eMAIL_TO,
                        EMAIL_CC = eMAIL_CC,
                        EMAIL_SUBJ = eMAIL_SUBJ,
                        EMAIL_MSG = eMAIL_MSG.SubStringPlus(0, 2000),
                        EMAIL_TYPE = eMAIL_TYPE
                    };
                    ctx.T_QREST_SYS_LOG_EMAIL.Add(a);
                    ctx.SaveChanges();
                    return a.LOG_EMAIL_ID;
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    return 0;
                }
            }
        }

        public static List<T_QREST_SYS_LOG_EMAIL> GetT_QREST_SYS_EMAIL_LOG(DateTime? DateFrom, DateTime? DateTo)
        {
            using (QRESTEntities ctx = new QRESTEntities())
            {
                try
                {
                    DateTime DateFromDt = (DateFrom == null ? System.DateTime.Today.AddYears(-10) : new DateTime(DateFrom.ConvertOrDefault<DateTime>().Year, DateFrom.ConvertOrDefault<DateTime>().Month, DateFrom.ConvertOrDefault<DateTime>().Day, 0, 0, 0));
                    DateTime DateToDt = (DateTo == null ? System.DateTime.Today.AddYears(1) : new DateTime(DateTo.ConvertOrDefault<DateTime>().Year, DateTo.ConvertOrDefault<DateTime>().Month, DateTo.ConvertOrDefault<DateTime>().Day, 23, 59, 59));

                    return (from a in ctx.T_QREST_SYS_LOG_EMAIL
                            where a.EMAIL_DT >= DateFromDt
                            && a.EMAIL_DT <= DateToDt
                            orderby a.LOG_EMAIL_ID descending
                            select a).ToList();
                }
                catch (Exception ex)
                {
                    logEF.LogEFException(ex);
                    throw ex;
                }
            }
        }

    }
}