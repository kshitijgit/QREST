﻿/***************************************************************** */
/*************DROP EXISTING DATABASE (only use if refreshing DB*** */
/***************************************************************** */
/*
USE [QREST];
GO

drop table IF EXISTS [T_QREST_MONITORS];
drop table IF EXISTS [T_QREST_SITES];
drop table IF EXISTS [T_QREST_ORG_USERS];
drop table IF EXISTS [T_QREST_ORG_EMAIL_RULE];
drop table IF EXISTS [T_QREST_ORGANIZATIONS];
drop table IF EXISTS [T_QREST_REF_PAR_METHODS];
drop table IF EXISTS [T_QREST_REF_PARAMETERS];
drop table IF EXISTS [T_QREST_REF_UNITS];
drop table IF EXISTS [T_QREST_REF_COLLECT_FREQ];
drop table IF EXISTS [T_QREST_REF_DURATION];
drop table IF EXISTS [T_QREST_REF_REGION];
drop table IF EXISTS [T_QREST_REF_AQS_AGENCY];
drop table IF EXISTS [T_QREST_REF_STATE];
drop table IF EXISTS [T_QREST_EMAIL_TEMPLATE];
drop table IF EXISTS [T_QREST_APP_SETTINGS_CUSTOM];
drop table IF EXISTS [T_QREST_APP_SETTINGS];
drop table IF EXISTS [T_QREST_SYS_LOG_ACTIVITY];
drop table IF EXISTS [T_QREST_SYS_LOG_EMAIL];
drop table IF EXISTS [T_QREST_SYS_LOG];

drop table IF EXISTS [T_QREST_USER_CLAIMS];
drop table IF EXISTS [T_QREST_USER_LOGINS];
drop table IF EXISTS [T_QREST_USER_ROLES];
drop table IF EXISTS [T_QREST_USERS];
drop table IF EXISTS [T_QREST_ROLES];

*/

USE [QREST];
GO


/******************************************************************************************/
/*******************  IDENTITY TABLES ***********************************************/
/******************************************************************************************/

CREATE TABLE [dbo].[T_QREST_ROLES](
    [ROLE_IDX] [nvarchar](128) NOT NULL,
    [Name] [nvarchar](256) NOT NULL,
    [ROLE_DESC] [varchar](100),
CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([ROLE_IDX] ASC)
)


CREATE TABLE [dbo].[T_QREST_USERS](
    [USER_IDX] [nvarchar](128) NOT NULL,
    [Email] [nvarchar](256) NULL,
    [EmailConfirmed] [bit] NOT NULL,
    [PasswordHash] [nvarchar](max),
    [SecurityStamp] [nvarchar](max),
    [PhoneNumber] [nvarchar](max),
    [PhoneNumberConfirmed] [bit] NOT NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime],
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
    [FNAME] [varchar](40) NOT NULL,
    [LNAME] [varchar](40) NOT NULL,
    [TITLE] [varchar](50),
	[LAST_LOGIN_DT] datetime2(0),
	[CREATE_USER_IDX] [nvarchar](128) NULL,
	[CREATE_DT] [datetime2](0) NULL,
	[MODIFY_USER_IDX] [nvarchar](128) NULL,
	[MODIFY_DT] [datetime2](0) NULL,
CONSTRAINT [PK_T_QREST_USERS] PRIMARY KEY CLUSTERED ([USER_IDX] ASC)
)

CREATE TABLE [dbo].[T_QREST_USER_CLAIMS](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
    [ClaimType] [nvarchar](max) NULL,
    [ClaimValue] [nvarchar](max) NULL,
CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
CONSTRAINT [FK_AspNetUserClaims_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [T_QREST_USERS] ([USER_IDX]) ON DELETE CASCADE
)


CREATE TABLE [dbo].[T_QREST_USER_LOGINS](
    [LoginProvider] [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](128) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
CONSTRAINT [FK_AspNetUserLogins_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [T_QREST_USERS] ([USER_IDX]) ON DELETE CASCADE
)

CREATE TABLE [dbo].[T_QREST_USER_ROLES](
    [USER_IDX] [nvarchar](128) NOT NULL,
    [ROLE_IDX] [nvarchar](128) NOT NULL,
CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([USER_IDX] ASC, [ROLE_IDX] ASC),
CONSTRAINT [FK_AspNetUserRoles_Roles_RoleId] FOREIGN KEY ([ROLE_IDX]) REFERENCES [T_QREST_ROLES] ([ROLE_IDX]) ON DELETE CASCADE,
CONSTRAINT [FK_AspNetUserRoles_Users_UserId] FOREIGN KEY ([USER_IDX]) REFERENCES [T_QREST_USERS] ([USER_IDX]) ON DELETE CASCADE
)



GO



/******************************************************************************************/
/*******************  REF DATA TABLES ***********************************************/
/******************************************************************************************/


CREATE TABLE [dbo].[T_QREST_SYS_LOG](
	[LOG_ID] [int] NOT NULL IDENTITY(1,1),
	[LOG_DT] [datetime2](0) NULL,
	[LOG_TYP] [varchar](15) NULL,
	[LOG_USERID] [varchar](128) NULL,
	[LOG_MSG] [varchar](2000) NULL,
 CONSTRAINT [PK_T_QREST_SYS_LOG] PRIMARY KEY CLUSTERED  ([LOG_ID] ASC)
) ON [PRIMARY]


GO


CREATE TABLE [dbo].[T_QREST_SYS_LOG_EMAIL](
	[LOG_EMAIL_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMAIL_DT] [datetime2](0) NULL,
	[EMAIL_FROM] [varchar](200) NULL,
	[EMAIL_TO] [varchar](200) NULL,
	[EMAIL_CC] [varchar](200) NULL,
	[EMAIL_SUBJ] [varchar](200) NULL,
	[EMAIL_MSG] [varchar](2000) NULL,
	[EMAIL_TYPE] [varchar](15) NULL,
 CONSTRAINT [PK_T_QREST_SYS_LOG_EMAIL] PRIMARY KEY CLUSTERED  ([LOG_EMAIL_ID] ASC)
) ON [PRIMARY]


GO


CREATE TABLE [dbo].[T_QREST_SYS_LOG_ACTIVITY](
	[LOG_ACTIVITY_IDX] [int] IDENTITY(1,1) NOT NULL,
	[ACTIVITY_DT] [datetime2](0) NULL,
	[ACTIVITY_TYPE] [varchar](25) NOT NULL,
	[ACTIVITY_USER] [varchar](256) NULL,
	[ACTIVITY_DESC] [varchar](125) NULL,
	[IP_ADDRESS] [varchar](100) NULL,
 CONSTRAINT [PK_T_QREST_SYS_LOG_ACTIVITY] PRIMARY KEY CLUSTERED  ([LOG_ACTIVITY_IDX] ASC)
) ON [PRIMARY]


GO


CREATE TABLE [dbo].[T_QREST_APP_SETTINGS](
	[SETTING_IDX] [int] IDENTITY(1,1) NOT NULL,
	[SETTING_NAME] [varchar](100) NOT NULL,
	[SETTING_DESC] [varchar](500) NULL,
	[SETTING_VALUE] [varchar](200) NULL,
	[SETTING_CAT] [varchar](20) NULL,
	[MODIFY_USER_IDX] [varchar](128) NULL,
	[MODIFY_DT] [datetime2](0) NULL,
 CONSTRAINT [PK_T_QREST_APP_SETTINGS] PRIMARY KEY CLUSTERED  ([SETTING_IDX] ASC)
) ON [PRIMARY]


GO


CREATE TABLE [dbo].[T_QREST_APP_SETTINGS_CUSTOM](
	[SETTING_CUSTOM_IDX] [int] IDENTITY(1,1) NOT NULL,
	[TERMS_AND_CONDITIONS] [varchar](max) NULL,
	[ANNOUNCEMENTS] [varchar](max) NULL,
 CONSTRAINT [PK_T_QREST_APP_SETTINGS_CUSTOM] PRIMARY KEY CLUSTERED ([SETTING_CUSTOM_IDX] ASC)
) ON [PRIMARY]


GO



CREATE TABLE [dbo].[T_QREST_EMAIL_TEMPLATE](
	[EMAIL_TEMPLATE_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMAIL_TEMPLATE_NAME] [varchar](60) NOT NULL,
	[EMAIL_TEMPLATE_DESC] [varchar](1000) NOT NULL,
	[SUBJ] [varchar](200) NULL,
	[MSG] [varchar](max) NULL,
	[MODIFY_USER_IDX] [varchar](128) NULL,
	[MODIFY_DT] [datetime2](0) NULL,
 CONSTRAINT [PK_T_QREST_EMAIL_TEMPLATE] PRIMARY KEY CLUSTERED  ([EMAIL_TEMPLATE_ID] ASC)
) ON [PRIMARY]

GO



CREATE TABLE [T_QREST_REF_STATE](
	[STATE_CD] [varchar](5) NOT NULL,
	[STATE_NAME] [varchar](100) NOT NULL,
 CONSTRAINT [PK_T_QREST_REF_STATE] PRIMARY KEY CLUSTERED  ([STATE_CD] ASC)
);

GO

CREATE TABLE [T_QREST_REF_AQS_AGENCY](
	[AQS_AGENCY_CODE] [varchar](4) NOT NULL,
	[AQS_AGENCY_NAME] [varchar](100) NOT NULL,
	[AQS_AGENCY_TYPE] [varchar](1) NOT NULL,
 CONSTRAINT [PK_T_QREST_REF_AQS_AGENCY] PRIMARY KEY CLUSTERED  (AQS_AGENCY_CODE ASC)
);



CREATE TABLE [T_QREST_REF_REGION](
	[EPA_REGION] [int] NOT NULL,
	[EPA_REGION_NAME] [varchar](100) NOT NULL,
 CONSTRAINT [PK_T_QREST_REF_REGION] PRIMARY KEY CLUSTERED  ([EPA_REGION] ASC)
);

GO

CREATE TABLE [T_QREST_REF_DURATION] (
	[DURATION_CODE] varchar(1) NOT NULL,
	[DURATION_DESC] varchar(50) NOT NULL,
	[ACT_IND] [bit] NOT NULL DEFAULT 1,
	[CREATE_USER_IDX] nvarchar(128),
	[CREATE_DT] datetime2(0),
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
    CONSTRAINT [PK_T_QREST_REF_DURATION] PRIMARY KEY ([DURATION_CODE])
);

GO


CREATE TABLE [T_QREST_REF_COLLECT_FREQ] (
	[COLLECT_FREQ_CODE] varchar(2) NOT NULL,
	[COLLECT_FEQ_DESC] varchar(50) NOT NULL,
	[ACT_IND] [bit] NOT NULL DEFAULT 1,
	[CREATE_USER_IDX] nvarchar(128),
	[CREATE_DT] datetime2(0),
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
    CONSTRAINT [PK_T_QREST_REF_COLLECT_FREQ] PRIMARY KEY ([COLLECT_FREQ_CODE])
);

GO


CREATE TABLE [T_QREST_REF_UNITS] (
	[UNIT_CODE] varchar(3) NOT NULL,
	[UNIT_DESC] varchar(50) NOT NULL,
	[ACT_IND] [bit] NOT NULL DEFAULT 1,
	[CREATE_USER_IDX] nvarchar(128),
	[CREATE_DT] datetime2(0),
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
    CONSTRAINT [PK_T_QREST_REF_UNITS] PRIMARY KEY ([UNIT_CODE])
);

GO


CREATE TABLE [T_QREST_REF_PARAMETERS] (
	[PAR_CODE] varchar(6) NOT NULL,
	[PAR_NAME] varchar(100) NOT NULL,
	[PAR_NAME_ALT] varchar(100) NOT NULL,
	[CAS_NUM] varchar(100),
	[STD_UNIT_CODE] varchar(3),
	[SHORTLIST_IND] [bit] NOT NULL DEFAULT 0,
	[ACT_IND] [bit] NOT NULL DEFAULT 1,
	[CREATE_USER_IDX] nvarchar(128),
	[CREATE_DT] datetime2(0),
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
    CONSTRAINT [PK_T_QREST_REF_PARAMETERS] PRIMARY KEY ([PAR_CODE]),
    CONSTRAINT [FK_T_QREST_REF_PARAMETERS_U] FOREIGN KEY ([STD_UNIT_CODE]) REFERENCES [T_QREST_REF_UNITS] ([UNIT_CODE])
);

GO


CREATE TABLE [T_QREST_REF_PAR_METHODS] (
	[PAR_METHOD_IDX] UNIQUEIDENTIFIER NOT NULL,
	[PAR_CODE] varchar(6) NOT NULL,
	[METHOD_CODE] varchar(4) NOT NULL,
	[RECORDING_MODE] varchar(20),
	[COLLECTION_DESC] varchar(200),
	[ANALYSIS_DESC] varchar(200),
	[REFERENCE_METHOD_ID] varchar(200),
	[EQUIVALENT_METHOD] varchar(200),
	[STD_UNIT_CODE] varchar(3),
	[FED_MDL] float,
	[MIN_VALUE] float,
	[MAX_VALUE] float,
	[ACT_IND] [bit] NOT NULL DEFAULT 1,
	[CREATE_USER_IDX] nvarchar(128),
	[CREATE_DT] datetime2(0),
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
    CONSTRAINT [PK_T_QREST_REF_PAR_METHODS] PRIMARY KEY ([PAR_METHOD_IDX]),
	CONSTRAINT [FK_T_QREST_REF_PAR_METHODS_P] FOREIGN KEY ([PAR_CODE]) REFERENCES [T_QREST_REF_PARAMETERS] ([PAR_CODE]),
	CONSTRAINT [FK_T_QREST_REF_PAR_METHODS_U] FOREIGN KEY ([STD_UNIT_CODE]) REFERENCES [T_QREST_REF_UNITS] ([UNIT_CODE])
);

GO


/******************************************************************************************/
/*******************    ORGANIZATION TABLES ***********************************************/
/******************************************************************************************/
CREATE TABLE [T_QREST_ORGANIZATIONS] (
	[ORG_ID] varchar(30) NOT NULL,
	[ORG_NAME] varchar(100) NOT NULL,
	[AQS_AGENCY_CODE] varchar(4),
	[STATE_CD] varchar(5),
	[EPA_REGION] [int],
	[AQS_NAAS_UID] varchar(100),
	[AQS_NAAS_PWD] varchar(250),
	[ACT_IND] [bit] NOT NULL DEFAULT 1,
	[CREATE_USER_IDX] nvarchar(128),
	[CREATE_DT] datetime2(0),
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
    CONSTRAINT [PK_T_QREST_ORGANIZATIONS] PRIMARY KEY ([ORG_ID]),
 FOREIGN KEY ([STATE_CD]) references T_QREST_REF_STATE ([STATE_CD]),
 FOREIGN KEY ([EPA_REGION]) references T_QREST_REF_REGION ([EPA_REGION]),
 FOREIGN KEY ([AQS_AGENCY_CODE]) references T_QREST_REF_AQS_AGENCY ([AQS_AGENCY_CODE])
);
GO


CREATE TABLE [dbo].[T_QREST_ORG_EMAIL_RULE](
	[ORG_ID] varchar(30) NOT NULL,
	[EMAIL_STRING] varchar(100) NOT NULL,
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
 CONSTRAINT [PK_T_QREST_ORG_EMAIL_RULE] PRIMARY KEY CLUSTERED  ([ORG_ID] ASC, [EMAIL_STRING] ASC),
 FOREIGN KEY ([ORG_ID]) references T_QREST_ORGANIZATIONS ([ORG_ID]) ON UPDATE CASCADE 	ON DELETE CASCADE
) ON [PRIMARY]

GO	


CREATE TABLE [T_QREST_ORG_USERS] (
	[ORG_USER_IDX] UNIQUEIDENTIFIER NOT NULL,
	[ORG_ID] varchar(30) NOT NULL,
	[USER_IDX] nvarchar(128) NOT NULL,
	[ACCESS_LEVEL] varchar(1) NOT NULL,
	[STATUS_IND] varchar(1) NOT NULL,
	[CREATE_USER_IDX] nvarchar(128),
	[CREATE_DT] datetime2(0),
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
    CONSTRAINT [PK_T_QREST_ORG_USERS] PRIMARY KEY ([ORG_USER_IDX]),
    CONSTRAINT [FK_T_QREST_ORG_USERS_T] FOREIGN KEY ([ORG_ID]) REFERENCES [T_QREST_ORGANIZATIONS] ([ORG_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_T_QREST_ORG_USERS_U] FOREIGN KEY ([USER_IDX]) REFERENCES [T_QREST_USERS] ([USER_IDX]) ON DELETE CASCADE
);
GO



/******************************************************************************************/
/*******************  SITE/MONITOR TABLES ***********************************************/
/******************************************************************************************/
CREATE TABLE [T_QREST_SITES] (
	[SITE_IDX] UNIQUEIDENTIFIER NOT NULL,
	[ORG_ID] varchar(30) NOT NULL,
	[SITE_ID] varchar(50) NOT NULL,
	[SITE_NAME] varchar(100) NOT NULL,
	[AQS_SITE_ID] varchar(4),
	[LATITUDE] decimal(18,5),
	[LONGITUDE] decimal(18,5),
	[ADDRESS] varchar(100),
	[CITY] varchar(50),
	[STATE] varchar(2),
	[ZIP_CODE] varchar(10),
	[START_DT] datetime2(0),
	[END_DT] datetime2(0),
	[TELEMETRY_ONLINE_IND] bit,
	[SITE_COMMENTS] varchar(max),
	[CREATE_USER_IDX] nvarchar(128),
	[CREATE_DT] datetime2(0),
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
    CONSTRAINT [PK_T_QREST_SITES] PRIMARY KEY ([SITE_IDX]),
    CONSTRAINT [FK_T_QREST_SITES_O] FOREIGN KEY ([ORG_ID]) REFERENCES [T_QREST_ORGANIZATIONS] ([ORG_ID])
);
GO


CREATE TABLE [T_QREST_MONITORS] (
	[MONITOR_IDX] UNIQUEIDENTIFIER NOT NULL,
	[SITE_IDX] UNIQUEIDENTIFIER NOT NULL,
	[PAR_METHOD_IDX] UNIQUEIDENTIFIER NOT NULL,
	[POC] int NOT NULL,
	[DURATION_CODE] varchar(1) NULL,
	[COLLECT_FREQ_CODE] varchar(2) NOT NULL,
	[COLLECT_UNIT_CODE] varchar(3),
	[ALERT_MIN_VALUE] float,
	[ALERT_MAX_VALUE] float,
	[ALERT_PCT_CHANGE] int,
	[ALERT_STUCK_REC_COUNT] int,
	[CREATE_USER_IDX] nvarchar(128),
	[CREATE_DT] datetime2(0),
	[MODIFY_USER_IDX] nvarchar(128),
	[MODIFY_DT] datetime2(0),
    CONSTRAINT [PK_T_QREST_MONITORS] PRIMARY KEY ([MONITOR_IDX]),
    CONSTRAINT [FK_T_QREST_MONITORS_S] FOREIGN KEY ([SITE_IDX]) REFERENCES [T_QREST_SITES] ([SITE_IDX]),
    CONSTRAINT [FK_T_QREST_MONITORS_P] FOREIGN KEY ([PAR_METHOD_IDX]) REFERENCES [T_QREST_REF_PAR_METHODS] ([PAR_METHOD_IDX]),
    CONSTRAINT [FK_T_QREST_MONITORS_D] FOREIGN KEY ([DURATION_CODE]) REFERENCES [T_QREST_REF_DURATION] ([DURATION_CODE]),
    CONSTRAINT [FK_T_QREST_MONITORS_C] FOREIGN KEY ([COLLECT_FREQ_CODE]) REFERENCES [T_QREST_REF_COLLECT_FREQ] ([COLLECT_FREQ_CODE])
);
GO





