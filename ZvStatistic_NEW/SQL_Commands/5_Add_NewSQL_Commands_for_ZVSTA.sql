SET IDENTITY_INSERT [dbo].[SQL_PARAMETER_DETAILS_SECOND] ON
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18171, N'Delete all Data for the current Reporting Scheme and Period', NULL, NULL, NULL, 1, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM ZVSTAT_Reporting where ReportingPeriod=@REPORTING_PERIOD and ZVSTA_Schema=@ZVSTA_Schema
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18172, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 2, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18173, N'Create Temporary Table:#Temp_ZVSTA_FormNr to load all FormNr for the declared Schema', NULL, NULL, NULL, 3, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTA_FormNr
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18174, N'Create Temporary Table:#Temp_ZVSTA_ID_Position to load the ID Positions for the declared Schema ', NULL, NULL, NULL, 4, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTA_ID_Position
(ID int IDENTITY(1,1) NOT NULL,
ID_ORIG int NULL,
[LfdNr] [float] NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18175, N'Create Temporary Table:#Temp_ZVSTA_Position to load each Position for the declared Schema  based on the ID_ORIG from Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 5, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTA_Position
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18176, N'Create Temp Table:#Temp_ZVSTAT_Report - will include all relevant Positions based on the declared Schema', NULL, NULL, NULL, 6, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTAT_Report
([ID] [int] IDENTITY(1,1) NOT NULL,
[ZVSTA_Schema] [nvarchar](50) NULL,
ReportingPeriod nvarchar(50) NULL,
[LfdNr] [float] NULL,
[FormNr] [nvarchar](10) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[LandCode_Description] [nvarchar](255) NULL,
[SubdivisionOfCountryCode] [nvarchar](50) NULL,
[SubdivisionOfCountryName] [nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) NULL,
[PayCardSystem_Description] [nvarchar](255) default (''N''),
[Anzahl] [nvarchar](1) NULL,
[Wert] [nvarchar](1) NULL,
[SumPosition] [nvarchar](1) NULL,
[PositionSQLcommand] [nvarchar](max) NULL,
[PositionInfo] [nvarchar](max) NULL)

', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18177, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr basded on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 7, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--Insert in the Table:#Temp_ZVSTA_FormNr
--the FormNr basded on the declared Schema
INSERT INTO #Temp_ZVSTA_FormNr
(FormNr,ZVSTA_Schema,ReportingPeriod)
Select FormNr,@ZVSTA_Schema,@REPORTING_PERIOD
FROM [ZVSTAT_Parameters_from2014]
where ZVSTA_Schema=@ZVSTA_Schema
GROUP BY FormNr
order by FormNr asc

--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_FormNr
DECLARE @MIN_ID_Table_ZVSTA_FormNr int=1
DECLARE @MAX_ID_Table_ZVSTA_FormNr int=(Select MAX(ID) from #Temp_ZVSTA_FormNr)
WHILE @MIN_ID_Table_ZVSTA_FormNr<=@MAX_ID_Table_ZVSTA_FormNr
--Insert all Positions from current FormNr in Table:#Temp_ZVSTA_ID_Position
BEGIN
INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=(Select FormNr from #Temp_ZVSTA_FormNr where ID=@MIN_ID_Table_ZVSTA_FormNr)
and ZVSTA_Schema=@ZVSTA_Schema
and [PositionStatus] in (''Y'')
order by LfdNr asc

--Get next @MIN_ID_Table_ZVSTA_FormNr and start INSERT the next Position
SET @MIN_ID_Table_ZVSTA_FormNr=@MIN_ID_Table_ZVSTA_FormNr+1

END
	
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18178, N'Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 8, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

	BEGIN
		--JEDES_LAND_SEPARAT and MCC_CODES
		IF @LandCode in (''JEDES_LAND'') and @PayCardSystem in (''MCC_CODES'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
				
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A, ZVSTAT_Pay_Cards_Parameters B
				where A.ZVSTA_Relevant in (''Y'')  and A.[VALID]in (''Y'') and  B.[ZVSTA_Parameter_General] in (''MCC_CODES'') and b.Status in (''Y'')
			END
		--JEDES_LAND_SEPARAT and NO PayCardSystems
		IF @LandCode in (''JEDES_LAND'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,[COUNTRY CODE],@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
				from Countries
				where ZVSTA_Relevant in (''Y'')  and [VALID] in (''Y'')
			END
		--NO COUNTRIES and NO MCC_CODES
		IF @LandCode in (''W0'') and @PayCardSystem in (''MCC_CODES'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
				from ZVSTAT_Pay_Cards_Parameters B
				where  B.[ZVSTA_Parameter_General] in (''MCC_CODES'') and b.Status in (''Y'')
			END
		--NO COUNTRIES and NO PayCardSystems
		IF @LandCode in (''W0'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo  
			END


	END

--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END

', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18179, N'Update LfdNr, Land code description and PayCard System description in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 9, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--Update LfdNr
UPDATE #Temp_ZVSTAT_Report SET LfdNr=ID

--Update LandCode_Description
UPDATE A SET A.LandCode_Description=Case when A.LandCode in (''W0'') then ''Inländisch und grenzüberschreitent kombiniert (Total)''
										 else (Select B.[COUNTRY NAME] from Countries B where B.[COUNTRY CODE]=A.LandCode)  end 
from #Temp_ZVSTAT_Report A 

--Update PayCardSystem_Description
UPDATE A SET A.PayCardSystem_Description=B.ParameterValue2 
from #Temp_ZVSTAT_Report A INNER JOIN ZVSTAT_Pay_Cards_Parameters B on A.PayCardSystem=B.ParameterValue1
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18180, N'Update Subdivision CountryCodes in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 10, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE A SET A.SubdivisionOfCountryCode=B.SubdivisionOfCountryCode,A.SubdivisionOfCountryName=B.SubdivisionOfCountryName 
from #Temp_ZVSTAT_Report A INNER JOIN Countries B on A.LandCode=B.[COUNTRY CODE]
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18181, N'Insert all generated positions from Temp table:#Temp_ZVSTA_Report  to Live Table:ZVSTA_Reporting', NULL, NULL, NULL, 11, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--Insert Data to Live Table
INSERT INTO [dbo].[ZVSTAT_Reporting]
           ([ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand]
	    ,PositionInfo)
SELECT [ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand] 
	    ,PositionInfo
from #Temp_ZVSTAT_Report
		   order by LfdNr asc
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18182, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 12, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report
', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18183, N'Replace Parameters with Live Table Values', NULL, NULL, NULL, 13, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ID>'',CONVERT(nvarchar(255),ID))
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL

UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Schema>'',@ZVSTA_Schema)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_SchemaPeriod>'',
CASE WHEN RIGHT(@ZVSTA_Schema,1)=''H'' then ''HALFYEARLY'' 
when RIGHT(@ZVSTA_Schema,1)=''Q'' then ''QUARTERLY'' else ''YEARLY'' end )
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_ReportingPeriod>'',@REPORTING_PERIOD)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<SumPosition>'',SumPosition)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<CountPosition>'',Anzahl)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ValuePosition>'',Wert)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<PaymentFlow>'',Landkontext)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Position>'',PositionNr)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_CountryCode>'',LandCode)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_PaymentCardSystem>'',PayCardSystem)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL




', NULL, NULL, NULL, NULL, NULL, N'Y', 3854)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18184, N'Delete all Data for the current Reporting Scheme and Period', NULL, NULL, NULL, 1, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM ZVSTAT_Reporting where ReportingPeriod=@REPORTING_PERIOD and ZVSTA_Schema=@ZVSTA_Schema', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18185, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 2, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18186, N'Create Temporary Table:#Temp_ZVSTA_FormNr to load all FormNr for the declared Schema', NULL, NULL, NULL, 3, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTA_FormNr
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18187, N'Create Temporary Table:#Temp_ZVSTA_ID_Position to load the ID Positions for the declared Schema ', NULL, NULL, NULL, 4, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTA_ID_Position
(ID int IDENTITY(1,1) NOT NULL,
ID_ORIG int NULL,
[LfdNr] [float] NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18188, N'Create Temporary Table:#Temp_ZVSTA_Position to load each Position for the declared Schema  based on the ID_ORIG from Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 5, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTA_Position
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18189, N'Create Temp Table:#Temp_ZVSTAT_Report - will include all relevant Positions based on the declared Schema', NULL, NULL, NULL, 6, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTAT_Report
([ID] [int] IDENTITY(1,1) NOT NULL,
[ZVSTA_Schema] [nvarchar](50) NULL,
ReportingPeriod nvarchar(50) NULL,
[LfdNr] [float] NULL,
[FormNr] [nvarchar](10) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[LandCode_Description] [nvarchar](255) NULL,
[SubdivisionOfCountryCode] [nvarchar](50) NULL,
[SubdivisionOfCountryName] [nvarchar](255) NULL,
[LandCode_T] [nvarchar](255) NULL,
[LandCode_T_Description] [nvarchar](255) NULL,
[SubdivisionOfCountryCode_T] [nvarchar](50) NULL,
[SubdivisionOfCountryName_T][nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) NULL,
[PayCardSystem_Description] [nvarchar](255) default (''N''),
[Anzahl] [nvarchar](1) NULL,
[Wert] [nvarchar](1) NULL,
[SumPosition] [nvarchar](1) NULL,
[PositionSQLcommand] [nvarchar](max) NULL,
[PositionInfo] [nvarchar](max) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18190, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS1 based on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 7, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''


INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS1''and ZVSTA_Schema=@ZVSTA_Schema
and [PositionStatus] in (''Y'')
order by LfdNr asc
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18191, N'FormNr:ZVS1-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 8, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN
--No EU_EEA_SEPARAT and No PayCardSystems
IF @LandCode in (''W0'',''DE'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
    INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
    Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

--EU_EEA_SEPARAT(...) and NO PayCardSystem
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
    INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
    Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,[COUNTRY CODE],@PayCardSystem,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo 
    from Countries A
    where A.[EU EEA] in (''EU'',''EEA'') and A.[COUNTRY CODE] not in (''DE'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'')
END

--World Rest and No PayCardSystems
IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
    INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
    Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

END

--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END

', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18192, N'FormNr:ZVS1 - RESET Temporary Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 9, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM #Temp_ZVSTA_ID_Position
TRUNCATE TABLE #Temp_ZVSTA_ID_Position
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18193, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS2 based on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 10, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''


INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS2''and ZVSTA_Schema=@ZVSTA_Schema
and [PositionStatus] in (''Y'')
order by LfdNr asc
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18194, N'FormNr:ZVS2-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 11, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position 
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN
IF @LandCode in (''W0'',''DE'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

--No EU_EEA_SEPARAT and CARDS
IF @LandCode in (''W0'',''DE'',''G1'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
Select 
@ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
from ZVSTAT_Pay_Cards_Parameters B
where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END

--World Rest and No PayCardSystems
IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

END

--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END


', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18195, N'FormNr:ZVS2 - RESET Temporary Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 12, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM #Temp_ZVSTA_ID_Position
TRUNCATE TABLE #Temp_ZVSTA_ID_Position
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18196, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS3 based on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 13, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''


INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS3''and ZVSTA_Schema=@ZVSTA_Schema
and [PositionStatus] in (''Y'')
order by LfdNr asc
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18197, N'FormNr:ZVS3-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 14, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN
--World total and DE and No PayCardSystems
IF @LandCode in (''W0'',''DE'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

--EU_EEA_SEPARAT(...) and NO PayCardSystem
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,[COUNTRY CODE],@PayCardSystem,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo 
from Countries A
where A.[EU EEA] in (''EU'',''EEA'') and A.[COUNTRY CODE] not in (''DE'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'')
END

--World Rest and No PayCardSystems
IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

END

--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END



', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18198, N'FormNr:ZVS3 - RESET Temporary Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 15, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM #Temp_ZVSTA_ID_Position
TRUNCATE TABLE #Temp_ZVSTA_ID_Position
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18199, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS4.1 based on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 16, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''


INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS4.1''and ZVSTA_Schema=@ZVSTA_Schema
and [PositionStatus] in (''Y'')
order by LfdNr asc

', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18200, N'FormNr:ZVS4.1-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 17, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN		
--World total and DE and No PayCardSystems
IF @LandCode in (''W0'',''DE'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END
--EU_EEA_SEPARAT(...) and NO PayCardSystem
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,[COUNTRY CODE],@PayCardSystem,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo 
	from Countries A
	where A.[EU EEA] in (''EU'',''EEA'')  and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'')
END
--World Rest and No PayCardSystems
IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

--PAYMENTS
--No EU_EEA_SEPARAT and PAYMENTS
IF @LandCode in (''W0'') and @PayCardSystem in (''PAY_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''PAYMENTS'',''UNKNOWN'') and b.Status in (''Y'')
END
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''PAY_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],B.ParameterValue1,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo
	from Countries A, ZVSTAT_Pay_Cards_Parameters B
	where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'')  and A.Valid in (''Y'') and B.[ZVSTA_Parameter_General] in (''PAYMENTS'',''UNKNOWN'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''PAY_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''PAYMENTS'',''UNKNOWN'') and b.Status in (''Y'')
END

--DIRECT DEBITS
--No EU_EEA_SEPARAT and PAYMENTS
IF @LandCode in (''W0'') and @PayCardSystem in (''DD_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''DIRECT_DEBITS'',''UNKNOWN'') and b.Status in (''Y'')
END
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''DD_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],B.ParameterValue1,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo
	from Countries A, ZVSTAT_Pay_Cards_Parameters B
	where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'')  and A.Valid in (''Y'') and B.[ZVSTA_Parameter_General] in (''DIRECT_DEBITS'',''UNKNOWN'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''DD_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''DIRECT_DEBITS'',''UNKNOWN'') and b.Status in (''Y'')
END

--CARDS
--No EU_EEA_SEPARAT and PAYMENTS
IF @LandCode in (''W0'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],B.ParameterValue1,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo
	from Countries A, ZVSTAT_Pay_Cards_Parameters B
	where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'')  and A.Valid in (''Y'') and B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END

END
--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18201, N'FormNr:ZVS4.1 - RESET Temporary Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 18, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM #Temp_ZVSTA_ID_Position
TRUNCATE TABLE #Temp_ZVSTA_ID_Position
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18202, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS4.2 based on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 19, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''


INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS4.2''and ZVSTA_Schema=@ZVSTA_Schema
and [PositionStatus] in (''Y'')
order by LfdNr asc
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18203, N'FormNr:ZVS4.2-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 20, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN

	--Only Specific Country Codes for each EU-Country and CARDS
	IF @LandCode in (''W0'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
		BEGIN
			INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.[COUNTRY CODE] ,''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A
			where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'')
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''W0'',''W0'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo             
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''W0'',''G1'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	END
		--Only Specific Country Codes for each EU-Country and CARDS
	IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
		BEGIN
			INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.[COUNTRY CODE] ,''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A
			where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'')
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''G1'',''G1'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
                              
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''G1'',''W0'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	END

	IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
		BEGIN
			INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],C.[COUNTRY CODE],''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A, Countries C
			where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'') 
			and C.[EU EEA] in (''EU'',''EEA'') and C.ZVSTA_Relevant in (''Y'') and C.Valid in (''Y'')
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],''W0'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A
			where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'') 
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],''G1'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A
			where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'') 
		END


		--WITH CARDS
		IF @LandCode in (''W0'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.[COUNTRY CODE] ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A,ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
				and A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'')
			UNION ALL
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''W0'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			UNION ALL
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''G1'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			END

		IF @LandCode in (''G1'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.[COUNTRY CODE] ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A,ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
				and A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'')
			UNION ALL
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''G1'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			UNION ALL
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''W0'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			END

		IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],C.[COUNTRY CODE],B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A, ZVSTAT_Pay_Cards_Parameters B,Countries C
				where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'') and B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
				and C.[EU EEA] in (''EU'',''EEA'') and C.ZVSTA_Relevant in (''Y'') and C.Valid in (''Y'')
			UNION ALL
			    Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],''W0'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A, ZVSTAT_Pay_Cards_Parameters B
				where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'') and B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			UNION ALL
			    Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],''G1'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A, ZVSTAT_Pay_Cards_Parameters B
				where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'') and B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')

			END
		

END



--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END

--DELETE DUPLICATES based on Landkontext+PositionNr+LandCode+LandCode_T+PayCardSystem
DELETE from #Temp_ZVSTAT_Report where ID not in (Select MIN(ID) from #Temp_ZVSTAT_Report where  FormNr in (''ZVS4.2'')  group by Landkontext+PositionNr+LandCode+LandCode_T+PayCardSystem)
and FormNr in (''ZVS4.2'') ', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18204, N'FormNr:ZVS4.2 - RESET Temporary Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 21, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM #Temp_ZVSTA_ID_Position
TRUNCATE TABLE #Temp_ZVSTA_ID_Position
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18205, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS5.1 based on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 22, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''


INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS5.1''and ZVSTA_Schema=@ZVSTA_Schema
and [PositionStatus] in (''Y'')
order by LfdNr asc
', NULL, NULL, NULL, NULL, NULL, N'N', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18206, N'FormNr:ZVS5.1-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 23, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN
		
--World total and DE and No PayCardSystems
IF @LandCode in (''W0'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END
--EU_EEA_SEPARAT(...) and NO PayCardSystem
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,CountryCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo 
	from Countries A
	where A.EU_EEA in (''EU'',''EEA'')  and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'')
END
--World Rest and No PayCardSystems
IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

--PAYMENTS
--No EU_EEA_SEPARAT and PAYMENTS
IF @LandCode in (''W0'') and @PayCardSystem in (''PAY_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''PAYMENTS'',''UNKNOWN'') and b.Status in (''Y'')
END
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''PAY_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,B.ParameterValue1,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo
	from Countries A, ZVSTAT_Pay_Cards_Parameters B
	where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'')  and A.Status in (''Y'') and B.[ZVSTA_Parameter_General] in (''PAYMENTS'',''UNKNOWN'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''PAY_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''PAYMENTS'',''UNKNOWN'') and b.Status in (''Y'')
END

--DIRECT DEBITS
--No EU_EEA_SEPARAT and PAYMENTS
IF @LandCode in (''W0'') and @PayCardSystem in (''DD_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''DIRECT_DEBITS'',''UNKNOWN'') and b.Status in (''Y'')
END
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''DD_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,B.ParameterValue1,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo
	from Countries A, ZVSTAT_Pay_Cards_Parameters B
	where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'')  and A.Status in (''Y'') and B.[ZVSTA_Parameter_General] in (''DIRECT_DEBITS'',''UNKNOWN'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''DD_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''DIRECT_DEBITS'',''UNKNOWN'') and b.Status in (''Y'')
END

--CARDS
--No EU_EEA_SEPARAT and PAYMENTS
IF @LandCode in (''W0'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,B.ParameterValue1,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo
	from Countries A, ZVSTAT_Pay_Cards_Parameters B
	where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'')  and A.Status in (''Y'') and B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END


END

--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END
', NULL, NULL, NULL, NULL, NULL, N'N', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18207, N'FormNr:ZVS5.1 - RESET Temporary Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 24, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM #Temp_ZVSTA_ID_Position
TRUNCATE TABLE #Temp_ZVSTA_ID_Position
', NULL, NULL, NULL, NULL, NULL, N'N', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18208, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS5.2 based on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 25, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''


INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS5.2''and ZVSTA_Schema=@ZVSTA_Schema
and [PositionStatus] in (''Y'')
order by LfdNr asc
', NULL, NULL, NULL, NULL, NULL, N'N', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18209, N'FormNr:ZVS5.2-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_', NULL, NULL, NULL, 26, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN

	--Only Specific Country Codes for each EU-Country and CARDS
	IF @LandCode in (''W0'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
		BEGIN
			INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.CountryCode ,''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A
			where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'')
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''W0'',''W0'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo             
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''W0'',''G1'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	END
		--Only Specific Country Codes for each EU-Country and CARDS
	IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
		BEGIN
			INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.CountryCode ,''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A
			where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'')
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''G1'',''G1'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
                              
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''G1'',''W0'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	END

	IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
		BEGIN
			INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,C.CountryCode,''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A, Countries C
			where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'') 
			and C.EU_EEA in (''EU'',''EEA'') and C.ZVSTA_Relevant in (''Y'') and C.Status in (''Y'')
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,''W0'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A
			where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'') 
		UNION ALL
			Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,''G1'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
			from Countries A
			where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'') 
		END


		--WITH CARDS
		IF @LandCode in (''W0'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.CountryCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A,ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
				and A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'')
			UNION ALL
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''W0'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			UNION ALL
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''G1'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			END

		IF @LandCode in (''G1'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.CountryCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A,ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
				and A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'')
			UNION ALL
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''G1'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			UNION ALL
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''W0'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from ZVSTAT_Pay_Cards_Parameters B
				where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			END

		IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
			BEGIN
				INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
				Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,C.CountryCode,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A, ZVSTAT_Pay_Cards_Parameters B,Countries C
				where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'') and B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
				and C.EU_EEA in (''EU'',''EEA'') and C.ZVSTA_Relevant in (''Y'') and C.Status in (''Y'')
			UNION ALL
			    Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,''W0'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A, ZVSTAT_Pay_Cards_Parameters B
				where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'') and B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
			UNION ALL
			    Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,''G1'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
				from Countries A, ZVSTAT_Pay_Cards_Parameters B
				where A.EU_EEA in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'') and B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')

			END
		

END



--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END

--DELETE DUPLICATES based on Landkontext+PositionNr+LandCode+LandCode_T+PayCardSystem
DELETE from #Temp_ZVSTAT_Report where ID not in (Select MIN(ID) from #Temp_ZVSTAT_Report where FormNr in (''ZVS5.2'') group by Landkontext+PositionNr+LandCode+LandCode_T+PayCardSystem)
and FormNr in (''ZVS5.2'')

', NULL, NULL, NULL, NULL, NULL, N'N', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18210, N'FormNr:ZVS5.2 - RESET Temporary Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 27, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM #Temp_ZVSTA_ID_Position
TRUNCATE TABLE #Temp_ZVSTA_ID_Position
', NULL, NULL, NULL, NULL, NULL, N'N', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18211, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS6 based on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 28, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''


INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS6''and ZVSTA_Schema=@ZVSTA_Schema
and [PositionStatus] in (''Y'')
order by LfdNr asc
', NULL, NULL, NULL, NULL, NULL, N'N', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18212, N'FormNr:ZVS6-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 29, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN
		
--World total and DE and No PayCardSystems
IF @LandCode in (''W0'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END
--EU_EEA_SEPARAT(...) and NO PayCardSystem
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,CountryCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo 
	from Countries A
	where A.EU_EEA in (''EU'',''EEA'')  and A.ZVSTA_Relevant in (''Y'') and A.Status in (''Y'')
END
--World Rest and No PayCardSystems
IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

			
END

--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END', NULL, NULL, NULL, NULL, NULL, N'N', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18213, N'FormNr:ZVS6 - RESET Temporary Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 30, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM #Temp_ZVSTA_ID_Position
TRUNCATE TABLE #Temp_ZVSTA_ID_Position
', NULL, NULL, NULL, NULL, NULL, N'N', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18214, N'Update Temp Table:#Temp_ZVSTA_Report - Form2 - Column:PayCardSystem=PCS_ALL if PayCardSystem=N', NULL, NULL, NULL, 31, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''PCS_ALL'' 
where FormNr in (''ZVS2'') and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18215, N'Update Temp Table:#Temp_ZVSTA_Report - Form4.1 - Column:PayCardSystem=CTS_ALL if PayCardSystem=N and PositionNr like PCT', NULL, NULL, NULL, 32, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''CTS_ALL'' 
where FormNr in (''ZVS4.1'') and [PositionNr] like ''PCT%'' and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18216, N'Update Temp Table:#Temp_ZVSTA_Report - Form4.1 - Column:PayCardSystem=DDS_ALL if PayCardSystem=N and PositionNr like PDD', NULL, NULL, NULL, 33, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''DDS_ALL'' 
where FormNr in (''ZVS4.1'') and [PositionNr] like ''PDD%'' and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18217, N'Update Temp Table:#Temp_ZVSTA_Report - Form4.1 - Column:PayCardSystem=PCS_ALL if PayCardSystem=N and PositionNr=PCW', NULL, NULL, NULL, 34, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''PCS_ALL'' 
where FormNr in (''ZVS4.1'') and [PositionNr] in (''PCW'') and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18218, N'Update Temp Table:#Temp_ZVSTA_Report - Form4.2 - Column:PayCardSystem=PCS_ALL if PayCardSystem=N', NULL, NULL, NULL, 35, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''PCS_ALL'' 
where FormNr in (''ZVS4.2'') and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18219, N'Update Temp Table:#Temp_ZVSTA_Report - Form5.1 - Column:PayCardSystem=CTS_ALL if PayCardSystem=N and PositionNr like FCT', NULL, NULL, NULL, 36, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''CTS_ALL'' 
where FormNr in (''ZVS5.1'') and [PositionNr] like ''FCT%'' and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18220, N'Update Temp Table:#Temp_ZVSTA_Report - Form5.1 - Column:PayCardSystem=DDS_ALL if PayCardSystem=N and PositionNr like FDD', NULL, NULL, NULL, 37, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''DDS_ALL'' 
where FormNr in (''ZVS5.1'') and [PositionNr] like ''FDD%'' and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18221, N'Update Temp Table:#Temp_ZVSTA_Report - Form5.1 - Column:PayCardSystem=PCS_ALL if PayCardSystem=N and PositionNr=FCW', NULL, NULL, NULL, 38, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''PCS_ALL'' 
where FormNr in (''ZVS5.1'') and [PositionNr] in (''FCW'') and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18222, N'Update Temp Table:#Temp_ZVSTA_Report - Form5.2 - Column:PayCardSystem=PCS_ALL if PayCardSystem=N', NULL, NULL, NULL, 39, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''PCS_ALL'' 
where FormNr in (''ZVS5.2'') and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18223, N'Update LfdNr, Land code description and PayCard System description in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 40, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
--Update LfdNr
UPDATE #Temp_ZVSTAT_Report SET LfdNr=ID

--Update LandCode_Description
UPDATE A SET A.LandCode_Description=
Case when A.LandCode in (''DE'') then ''Inländisch''
     when A.LandCode in (''W0'') then ''Inländisch und grenzüberschreitent kombiniert (Total)''
     when A.LandCode in (''G1'') then ''Rest der Welt (außerhalb des EWR)''
     when A.LandCode in (''G3'') then ''Grenzüberschreitend innerhalb des EWR''
else (Select B.[COUNTRY NAME] from Countries B where B.[COUNTRY CODE]=A.LandCode)  end 
from #Temp_ZVSTAT_Report  A 

--Update LandCode_Description
UPDATE A SET A.LandCode_T_Description=
Case when A.LandCode_T in (''DE'') then ''Inländisch''
     when A.LandCode_T in (''W0'') then ''Inländisch und grenzüberschreitent kombiniert (Total)''
     when A.LandCode_T in (''G1'') then ''Rest der Welt (außerhalb des EWR)''
     when A.LandCode_T in (''G3'') then ''Grenzüberschreitend innerhalb des EWR''
else (Select B.[COUNTRY NAME] from Countries B where B.[COUNTRY CODE]=A.LandCode_T)  end 
from #Temp_ZVSTAT_Report  A 


--Update PayCardSystem_Description
UPDATE A SET A.PayCardSystem_Description=B.ParameterValue2 
from #Temp_ZVSTAT_Report A INNER JOIN ZVSTAT_Pay_Cards_Parameters B on A.PayCardSystem=B.ParameterValue1', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18224, N'Update Subdivision CountryCodes in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 41, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE A SET 
A.SubdivisionOfCountryCode=B.SubdivisionOfCountryCode
,A.SubdivisionOfCountryName=B.SubdivisionOfCountryName 
from #Temp_ZVSTAT_Report A INNER JOIN Countries B on A.LandCode=B.[COUNTRY CODE]

UPDATE A SET 
A.SubdivisionOfCountryCode_T=B.SubdivisionOfCountryCode
,A.SubdivisionOfCountryName_T=B.SubdivisionOfCountryName 
from #Temp_ZVSTAT_Report A INNER JOIN Countries B on A.LandCode_T=B.[COUNTRY CODE]
', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18225, N'Insert all generated positions from Temp table:#Temp_ZVSTA_Report  to Live Table:ZVSTA_Reporting', NULL, NULL, NULL, 42, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--Insert Data to Live Table
INSERT INTO [dbo].[ZVSTAT_Reporting]
           ([ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[LandCode_T]
           ,[LandCode_T_Description]
           ,[SubdivisionOfCountryCode_T]
           ,[SubdivisionOfCountryName_T]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand]
	    ,PositionInfo)
SELECT [ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[LandCode_T]
           ,[LandCode_T_Description]
           ,[SubdivisionOfCountryCode_T]
           ,[SubdivisionOfCountryName_T]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand] 
	    ,PositionInfo
from #Temp_ZVSTAT_Report
		   order by LfdNr asc', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18226, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 43, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18227, N'Replace Parameters with Live Table Values', NULL, NULL, NULL, 44, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ID>'',CONVERT(nvarchar(255),ID))
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL

UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Schema>'',@ZVSTA_Schema)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_SchemaPeriod>'',
CASE WHEN RIGHT(@ZVSTA_Schema,1)=''H'' then ''HALFYEARLY'' 
when RIGHT(@ZVSTA_Schema,1)=''Q'' then ''QUARTERLY'' else ''YEARLY'' end )
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_ReportingPeriod>'',@REPORTING_PERIOD)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<SumPosition>'',SumPosition)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<CountPosition>'',Anzahl)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ValuePosition>'',Wert)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<PaymentFlow>'',Landkontext)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Position>'',PositionNr)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_CountryCode>'',LandCode)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_PaymentCardSystem>'',PayCardSystem)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL




', NULL, NULL, NULL, NULL, NULL, N'Y', 3855)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18228, N'Delete all Data for the current Reporting Scheme and Period', NULL, NULL, NULL, 1, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DELETE FROM ZVSTAT_Reporting where ReportingPeriod=@REPORTING_PERIOD and ZVSTA_Schema=@ZVSTA_Schema', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18229, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 2, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18230, N'Create Temporary Table:#Temp_ZVSTA_FormNr to load all FormNr for the declared Schema', NULL, NULL, NULL, 3, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTA_FormNr
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18231, N'Create Temporary Table:#Temp_ZVSTA_ID_Position to load the ID Positions for the declared Schema ', NULL, NULL, NULL, 4, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTA_ID_Position
(ID int IDENTITY(1,1) NOT NULL,
ID_ORIG int NULL,
[LfdNr] [float] NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18232, N'Create Temporary Table:#Temp_ZVSTA_Position to load each Position for the declared Schema  based on the ID_ORIG from Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 5, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTA_Position
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) Default(''N''),
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18233, N'Create Temp Table:#Temp_ZVSTAT_Report - will include all relevant Positions based on the declared Schema', NULL, NULL, NULL, 6, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

CREATE TABLE #Temp_ZVSTAT_Report
([ID] [int] IDENTITY(1,1) NOT NULL,
[ZVSTA_Schema] [nvarchar](50) NULL,
ReportingPeriod nvarchar(50) NULL,
[LfdNr] [float] NULL,
[FormNr] [nvarchar](10) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[LandCode_Description] [nvarchar](255) NULL,
[SubdivisionOfCountryCode] [nvarchar](50) NULL,
[SubdivisionOfCountryName] [nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) default (''N''),
[PayCardSystem_Description] [nvarchar](255) default (''N''),
[Anzahl] [nvarchar](1) NULL,
[Wert] [nvarchar](1) NULL,
[SumPosition] [nvarchar](1) NULL,
[PositionSQLcommand] [nvarchar](max) NULL,
[PositionInfo] [nvarchar](max) NULL)
', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18234, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr basded on the declared Schema and declare Minimum ansd Maximum ID', NULL, NULL, NULL, 7, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--Insert in the Table:#Temp_ZVSTA_FormNr
--the FormNr basded on the declared Schema
INSERT INTO #Temp_ZVSTA_FormNr
(FormNr,ZVSTA_Schema,ReportingPeriod)
Select FormNr,@ZVSTA_Schema,@REPORTING_PERIOD
FROM [ZVSTAT_Parameters_from2014]
where ZVSTA_Schema=@ZVSTA_Schema
and FormNr in (''ZVS1'',''ZVS2'',''ZVS4'',''ZVS5'',''ZVS8'')
and [PositionStatus] in (''Y'')
GROUP BY FormNr
order by FormNr asc

--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_FormNr
DECLARE @MIN_ID_Table_ZVSTA_FormNr int=1
DECLARE @MAX_ID_Table_ZVSTA_FormNr int=(Select MAX(ID) from #Temp_ZVSTA_FormNr)
WHILE @MIN_ID_Table_ZVSTA_FormNr<=@MAX_ID_Table_ZVSTA_FormNr
--Insert all Positions from current FormNr in Table:#Temp_ZVSTA_ID_Position
BEGIN
INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=(Select FormNr from #Temp_ZVSTA_FormNr where ID=@MIN_ID_Table_ZVSTA_FormNr)
and ZVSTA_Schema=@ZVSTA_Schema and FormNr in (''ZVS1'',''ZVS2'',''ZVS4'',''ZVS5'',''ZVS8'')
and [PositionStatus] in (''Y'')
order by LfdNr asc

--Get next @MIN_ID_Table_ZVSTA_FormNr and start INSERT the next Position
SET @MIN_ID_Table_ZVSTA_FormNr=@MIN_ID_Table_ZVSTA_FormNr+1

END
	', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18235, N'Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 8, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN
		
--JEDES EU_LAND_SEPARAT and NO PayCardSystems
IF @LandCode in (''EU'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,[COUNTRY CODE],@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
from Countries
where [EU EEA] in (''EU'',''EEA'') and [COUNTRY CODE] not in (''DE'') and ZVSTA_Relevant in (''Y'')  and Valid in (''Y'')
END
		
--NO COUNTRIES and NO PayCardSystems
IF @LandCode not in (''EU'',''EEA'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo  
END


END

--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END
', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18236, N'Update LfdNr, Land code description and PayCard System description in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 9, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
--Update LfdNr
UPDATE #Temp_ZVSTAT_Report SET LfdNr=ID

--Update LandCode_Description
UPDATE A SET A.LandCode_Description=
Case when A.LandCode in (''DE'') then ''Inländisch''
     when A.LandCode in (''A1'') then ''Gesendet GESAMT''
     when A.LandCode in (''U9'') then ''Rest der Welt (außerhalb des EWR)''
     when A.LandCode in (''Z9'') then ''Ausland''
else (Select B.[COUNTRY NAME] from Countries B where B.[COUNTRY CODE]=A.LandCode)  end 
from #Temp_ZVSTAT_Report A 

--Update PayCardSystem_Description
UPDATE A SET A.PayCardSystem_Description=B.ParameterValue2 
from #Temp_ZVSTAT_Report A INNER JOIN ZVSTAT_Pay_Cards_Parameters B on A.PayCardSystem=B.ParameterValue1', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18237, N'Update Subdivision CountryCodes in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 10, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE A SET A.SubdivisionOfCountryCode=B.SubdivisionOfCountryCode,A.SubdivisionOfCountryName=B.SubdivisionOfCountryName 
from #Temp_ZVSTAT_Report A INNER JOIN Countries B on A.LandCode=B.[COUNTRY CODE]', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18238, N'Insert all generated positions from Temp table:#Temp_ZVSTA_Report  to Live Table:ZVSTA_Reporting', NULL, NULL, NULL, 11, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

--Insert Data to Live Table
INSERT INTO [dbo].[ZVSTAT_Reporting]
           ([ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand]
	    ,PositionInfo)
SELECT [ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand] 
	    ,PositionInfo
from #Temp_ZVSTAT_Report
		   order by LfdNr asc', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18239, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 12, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18240, N'Replace Parameters with Live Table Values', NULL, NULL, NULL, 13, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ID>'',CONVERT(nvarchar(255),ID))
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL

UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Schema>'',@ZVSTA_Schema)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_SchemaPeriod>'',
CASE WHEN RIGHT(@ZVSTA_Schema,1)=''H'' then ''HALFYEARLY'' 
when RIGHT(@ZVSTA_Schema,1)=''Q'' then ''QUARTERLY'' else ''YEARLY'' end )
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_ReportingPeriod>'',@REPORTING_PERIOD)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<SumPosition>'',SumPosition)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<CountPosition>'',Anzahl)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ValuePosition>'',Wert)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<PaymentFlow>'',Landkontext)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Position>'',PositionNr)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_CountryCode>'',LandCode)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_PaymentCardSystem>'',PayCardSystem)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL




', NULL, NULL, NULL, NULL, NULL, N'Y', 3856)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18241, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 1, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18242, N'Create Temporary Table:#Temp_ZVSTA_FormNr to load all FormNr for the declared Schema', NULL, NULL, NULL, 2, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

CREATE TABLE #Temp_ZVSTA_FormNr
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18243, N'Create Temporary Table:#Temp_ZVSTA_ID_Position to load the ID Positions for the declared Schema ', NULL, NULL, NULL, 3, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

CREATE TABLE #Temp_ZVSTA_ID_Position
(ID int IDENTITY(1,1) NOT NULL,
ID_ORIG int NULL,
[LfdNr] [float] NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18244, N'Create Temporary Table:#Temp_ZVSTA_Position to load each Position for the declared Schema  based on the ID_ORIG from Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 4, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

CREATE TABLE #Temp_ZVSTA_Position
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18245, N'Create Temp Table:#Temp_ZVSTAT_Report - will include all relevant Positions based on the declared Schema', NULL, NULL, NULL, 5, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

CREATE TABLE #Temp_ZVSTAT_Report
([ID] [int] IDENTITY(1,1) NOT NULL,
[ZVSTA_Schema] [nvarchar](50) NULL,
ReportingPeriod nvarchar(50) NULL,
[LfdNr] [float] NULL,
[FormNr] [nvarchar](10) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[LandCode_Description] [nvarchar](255) NULL,
[SubdivisionOfCountryCode] [nvarchar](50) NULL,
[SubdivisionOfCountryName] [nvarchar](255) NULL,
[LandCode_T] [nvarchar](255) NULL,
[LandCode_T_Description] [nvarchar](255) NULL,
[SubdivisionOfCountryCode_T] [nvarchar](50) NULL,
[SubdivisionOfCountryName_T][nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) NULL,
[PayCardSystem_Description] [nvarchar](255) default (''N''),
[Anzahl] [nvarchar](1) NULL,
[Wert] [nvarchar](1) NULL,
[SumPosition] [nvarchar](1) NULL,
[PositionSQLcommand] [nvarchar](max) NULL,
[PositionInfo] [nvarchar](max) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18246, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS5.1 based on the declared Schema with declared Position (+ Position FTT)', NULL, NULL, NULL, 6, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS5.1'' and ZVSTA_Schema=@ZVSTA_Schema
and LEFT(PositionNr,3) in (@POSITION_NR,''FTT'')
--and [PositionStatus] in (''Y'')
order by LfdNr asc

', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18247, N'FormNr:ZVS5.1-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 7, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN
              
--World total and DE and No PayCardSystems
IF @LandCode in (''W0'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema 
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
       
END
--EU_EEA_SEPARAT(...) and NO PayCardSystem
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema 
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,[COUNTRY CODE],@PayCardSystem,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo 
       from Countries A
       where A.[EU EEA] in (''EU'',''EEA'') and [COUNTRY CODE] in (@COUNTRY_CODE) and A.ZVSTA_Relevant in (''Y'') and A.Valid in (''Y'')
END
----World Rest and No PayCardSystems
IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema and @COUNTRY_CODE=''G1''
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,@PayCardSystem,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

----PAYMENTS
----No EU_EEA_SEPARAT and PAYMENTS
IF @LandCode in (''W0'') and @PayCardSystem in (''PAY_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
       from ZVSTAT_Pay_Cards_Parameters B
       where B.[ZVSTA_Parameter_General] in (''PAYMENTS'',''UNKNOWN'') and b.Status in (''Y'')
END
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''PAY_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],B.ParameterValue1,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo
       from Countries A, ZVSTAT_Pay_Cards_Parameters B
       where A.[EU EEA] in (''EU'',''EEA'') and A.[COUNTRY CODE] in (@COUNTRY_CODE) and A.ZVSTA_Relevant in (''Y'')  and A.Valid in (''Y'') and B.[ZVSTA_Parameter_General] in (''PAYMENTS'',''UNKNOWN'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''PAY_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema and @COUNTRY_CODE=''G1''
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
       from ZVSTAT_Pay_Cards_Parameters B
       where B.[ZVSTA_Parameter_General] in (''PAYMENTS'',''UNKNOWN'') and b.Status in (''Y'')
END

----DIRECT DEBITS
----No EU_EEA_SEPARAT and PAYMENTS
IF @LandCode in (''W0'') and @PayCardSystem in (''DD_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
       from ZVSTAT_Pay_Cards_Parameters B
       where B.[ZVSTA_Parameter_General] in (''DIRECT_DEBITS'',''UNKNOWN'') and b.Status in (''Y'')
END
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''DD_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],B.ParameterValue1,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo
       from Countries A, ZVSTAT_Pay_Cards_Parameters B
       where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and [COUNTRY CODE] in (@COUNTRY_CODE)  and A.Valid in (''Y'') and B.[ZVSTA_Parameter_General] in (''DIRECT_DEBITS'',''UNKNOWN'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''DD_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema  and @COUNTRY_CODE=''G1''
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
       from ZVSTAT_Pay_Cards_Parameters B
       where B.[ZVSTA_Parameter_General] in (''DIRECT_DEBITS'',''UNKNOWN'') and b.Status in (''Y'')
END

----CARDS
----No EU_EEA_SEPARAT and PAYMENTS
IF @LandCode in (''W0'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
       from ZVSTAT_Pay_Cards_Parameters B
       where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END
IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.[COUNTRY CODE],B.ParameterValue1,@Anzahl,@Wert,@SumPosition ,@PositionSQLcommand,@PositionInfo
       from Countries A, ZVSTAT_Pay_Cards_Parameters B
       where A.[EU EEA] in (''EU'',''EEA'') and A.ZVSTA_Relevant in (''Y'') and [COUNTRY CODE] in (@COUNTRY_CODE)  and A.Valid in (''Y'') and B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema  and @COUNTRY_CODE=''G1''
BEGIN
       INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
       Select @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
       from ZVSTAT_Pay_Cards_Parameters B
       where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END


END

--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18248, N'FormNr:ZVS5.1 - Delete Duplicates in Temporary Table:#Temp_ZVSTA_Report based on PositionNr+Landkontext+LandCode+LandCode_T+PayCardSystem', NULL, NULL, NULL, 8, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

DELETE from #Temp_ZVSTAT_Report where ID not in (Select MIN(ID) from #Temp_ZVSTAT_Report group by PositionNr+Landkontext+LandCode+ISNULL(LandCode_T,'''')+ISNULL(PayCardSystem,''''))
', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18249, N'Update Temp Table:#Temp_ZVSTA_Report - Form5.1 - Column:PayCardSystem=CTS_ALL if PayCardSystem=N and PositionNr like FCT', NULL, NULL, NULL, 9, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''CTS_ALL'' 
where FormNr in (''ZVS5.1'') and [PositionNr] like ''FCT%'' and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18250, N'Update Temp Table:#Temp_ZVSTA_Report - Form5.1 - Column:PayCardSystem=DDS_ALL if PayCardSystem=N and PositionNr like FDD', NULL, NULL, NULL, 10, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''DDS_ALL'' 
where FormNr in (''ZVS5.1'') and [PositionNr] like ''FDD%'' and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18251, N'Update Temp Table:#Temp_ZVSTA_Report - Form5.1 - Column:PayCardSystem=PCS_ALL if PayCardSystem=N and PositionNr=FCW', NULL, NULL, NULL, 11, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''PCS_ALL'' 
where FormNr in (''ZVS5.1'') and [PositionNr] in (''FCW'') and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18252, N'Update Land code description and PayCard System description in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 12, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''


--Update LandCode_Description
UPDATE A SET A.LandCode_Description=
Case when A.LandCode in (''DE'') then ''Inländisch''
     when A.LandCode in (''W0'') then ''Inländisch und grenzüberschreitent kombiniert (Total)''
     when A.LandCode in (''G1'') then ''Rest der Welt (außerhalb des EWR)''
     when A.LandCode in (''G3'') then ''Grenzüberschreitend innerhalb des EWR''
else (Select B.[COUNTRY NAME] from Countries B where B.[COUNTRY CODE]=A.LandCode)  end 
from #Temp_ZVSTAT_Report  A 

--Update LandCode_Description
UPDATE A SET A.LandCode_T_Description=
Case when A.LandCode_T in (''DE'') then ''Inländisch''
     when A.LandCode_T in (''W0'') then ''Inländisch und grenzüberschreitent kombiniert (Total)''
     when A.LandCode_T in (''G1'') then ''Rest der Welt (außerhalb des EWR)''
     when A.LandCode_T in (''G3'') then ''Grenzüberschreitend innerhalb des EWR''
else (Select B.[COUNTRY NAME] from Countries B where B.[COUNTRY CODE]=A.LandCode_T)  end 
from #Temp_ZVSTAT_Report  A 


--Update PayCardSystem_Description
UPDATE A SET A.PayCardSystem_Description=B.ParameterValue2 
from #Temp_ZVSTAT_Report A INNER JOIN ZVSTAT_Pay_Cards_Parameters B on A.PayCardSystem=B.ParameterValue1
', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18253, N'Update Subdivision CountryCodes in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 13, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE A SET 
A.SubdivisionOfCountryCode=B.SubdivisionOfCountryCode
,A.SubdivisionOfCountryName=B.SubdivisionOfCountryName 
from #Temp_ZVSTAT_Report A INNER JOIN Countries B on A.LandCode=B.[COUNTRY CODE]

UPDATE A SET 
A.SubdivisionOfCountryCode_T=B.SubdivisionOfCountryCode
,A.SubdivisionOfCountryName_T=B.SubdivisionOfCountryName 
from #Temp_ZVSTAT_Report A INNER JOIN Countries B on A.LandCode_T=B.[COUNTRY CODE]
', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18254, N'Insert all generated positions from Temp table:#Temp_ZVSTA_Report  to Live Table:ZVSTA_Reporting', NULL, NULL, NULL, 14, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

--Insert Data to Live Table
INSERT INTO [dbo].[ZVSTAT_Reporting]
           ([ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[LandCode_T]
           ,[LandCode_T_Description]
           ,[SubdivisionOfCountryCode_T]
           ,[SubdivisionOfCountryName_T]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand]
     ,PositionInfo)
SELECT [ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[LandCode_T]
           ,[LandCode_T_Description]
           ,[SubdivisionOfCountryCode_T]
           ,[SubdivisionOfCountryName_T]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand] 
     ,PositionInfo
from #Temp_ZVSTAT_Report
where [ZVSTA_Schema]+[ReportingPeriod]+[FormNr]+[PositionNr]+[Landkontext]+[LandCode]+ISNULL([PayCardSystem],'''')
not in (Select [ZVSTA_Schema]+[ReportingPeriod]+[FormNr]+[PositionNr]+[Landkontext]+[LandCode]+ISNULL([PayCardSystem],'''')
from [ZVSTAT_Reporting] where [ZVSTA_Schema]=@ZVSTA_Schema and [ReportingPeriod]=@REPORTING_PERIOD and PositionName not in (''FEHLANZEIGE''))
', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18255, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 15, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18256, N'Recalculate LfdNr in Live Table:ZVSTA_Reporting', NULL, NULL, NULL, 16, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''


UPDATE A SET A.LfdNr=B.RowNumber 
from ZVSTAT_Reporting A INNER JOIN
(SELECT ROW_NUMBER() OVER(ORDER BY ID asc) AS RowNumber,  ID
from ZVSTAT_Reporting A 
where A.[ZVSTA_Schema]+A.[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD) B
on A.ID=B.ID
where A.[ZVSTA_Schema]+A.[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18257, N'Replace Parameters with Live Table Values', NULL, NULL, NULL, 17, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ID>'',CONVERT(nvarchar(255),ID))
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''

UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Schema>'',@ZVSTA_Schema)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_SchemaPeriod>'',
CASE WHEN RIGHT(@ZVSTA_Schema,1)=''H'' then ''HALFYEARLY'' 
when RIGHT(@ZVSTA_Schema,1)=''Q'' then ''QUARTERLY'' else ''YEARLY'' end )
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_ReportingPeriod>'',@REPORTING_PERIOD)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<SumPosition>'',SumPosition)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<CountPosition>'',Anzahl)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ValuePosition>'',Wert)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<PaymentFlow>'',Landkontext)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Position>'',PositionNr)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_CountryCode>'',LandCode)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''


UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_PaymentCardSystem>'',PayCardSystem)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.1''



', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18258, N'Set Status:A (NOT FINALIZED) in ZVSTA Report', NULL, NULL, NULL, 18, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE ZVSTAT_Reporting SET [ReportStatus]=''A''
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18259, N'Delete Row:FEHLANZEIGE if there are Data on the Report', NULL, NULL, NULL, 19, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DECLARE @SUM_COUNT int = 
(Select Sum(B.CountID) from
(Select Count(ID) as CountID from ZVSTAT_Reporting where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD  and PositionName in (''FEHLANZEIGE'') 
UNION ALL
Select Count(ID) as CountID from ZVSTAT_Reporting where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD  and PositionName not in (''FEHLANZEIGE''))B)

IF  @SUM_COUNT>1 
BEGIN
DELETE from ZVSTAT_Reporting where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD  
and PositionName in (''FEHLANZEIGE'') 
END', NULL, NULL, NULL, NULL, NULL, N'Y', 3857)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18260, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 1, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18261, N'Create Temporary Table:#Temp_ZVSTA_FormNr to load all FormNr for the declared Schema', NULL, NULL, NULL, 2, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

CREATE TABLE #Temp_ZVSTA_FormNr
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18262, N'Create Temporary Table:#Temp_ZVSTA_ID_Position to load the ID Positions for the declared Schema ', NULL, NULL, NULL, 3, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

CREATE TABLE #Temp_ZVSTA_ID_Position
(ID int IDENTITY(1,1) NOT NULL,
ID_ORIG int NULL,
[LfdNr] [float] NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18263, N'Create Temporary Table:#Temp_ZVSTA_Position to load each Position for the declared Schema  based on the ID_ORIG from Table:#Temp_ZVSTA_ID_Position', NULL, NULL, NULL, 4, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

CREATE TABLE #Temp_ZVSTA_Position
(ID int IDENTITY(1,1) NOT NULL,
FormNr nvarchar(255) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) NULL,
ZVSTA_Schema nvarchar(255) NULL,
ReportingPeriod nvarchar(255) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18264, N'Create Temp Table:#Temp_ZVSTAT_Report - will include all relevant Positions based on the declared Schema', NULL, NULL, NULL, 5, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

CREATE TABLE #Temp_ZVSTAT_Report
([ID] [int] IDENTITY(1,1) NOT NULL,
[ZVSTA_Schema] [nvarchar](50) NULL,
ReportingPeriod nvarchar(50) NULL,
[LfdNr] [float] NULL,
[FormNr] [nvarchar](10) NULL,
[FormName] [nvarchar](max) NULL,
[PositionNr] [nvarchar](50) NULL,
[PositionName] [nvarchar](max) NULL,
[Landkontext] [nvarchar](10) NULL,
[LandCode] [nvarchar](255) NULL,
[LandCode_Description] [nvarchar](255) NULL,
[SubdivisionOfCountryCode] [nvarchar](50) NULL,
[SubdivisionOfCountryName] [nvarchar](255) NULL,
[LandCode_T] [nvarchar](255) NULL,
[LandCode_T_Description] [nvarchar](255) NULL,
[SubdivisionOfCountryCode_T] [nvarchar](50) NULL,
[SubdivisionOfCountryName_T][nvarchar](255) NULL,
[PayCardSystem] [nvarchar](255) NULL,
[PayCardSystem_Description] [nvarchar](255) default (''N''),
[Anzahl] [nvarchar](1) NULL,
[Wert] [nvarchar](1) NULL,
[SumPosition] [nvarchar](1) NULL,
[PositionSQLcommand] [nvarchar](max) NULL,
[PositionInfo] [nvarchar](max) NULL)', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18265, N'Insert in the Table:#Temp_ZVSTA_FormNr the FormNr:ZVS5.2 based on the declared Schema with declared Position', NULL, NULL, NULL, 6, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

INSERT INTO #Temp_ZVSTA_ID_Position
(ID_ORIG,LfdNr,ZVSTA_Schema,ReportingPeriod)
Select ID,LfdNr,@ZVSTA_Schema,@REPORTING_PERIOD 
from [ZVSTAT_Parameters_from2014]
where FormNr=''ZVS5.2'' and ZVSTA_Schema=@ZVSTA_Schema
and LEFT(PositionNr,3) in (@POSITION_NR)
--and [PositionStatus] in (''Y'')
order by LfdNr asc

', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18266, N'Insert from FormNr:ZVS5.1-Position FTT for W0 and each Country', NULL, NULL, NULL, 7, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

DECLARE @CHECK_RESULT_W0 int =(Select COUNT(ID) from ZVSTAT_Reporting where ZVSTA_Schema=@ZVSTA_Schema and ReportingPeriod=@REPORTING_PERIOD 
                                and PositionNr in (''FTT'') and LandCode in (''W0'') and Landkontext in (@LAND_KONTEXT) and FormNr in (''ZVS5.1''))
DECLARE @CHECK_RESULT_COUNTRY_A int =(Select COUNT(ID) from ZVSTAT_Reporting where ZVSTA_Schema=@ZVSTA_Schema and ReportingPeriod=@REPORTING_PERIOD 
                                and PositionNr in (''FTT'') and LandCode in (@COUNTRY_CODE_A) and Landkontext in (@LAND_KONTEXT) and FormNr in (''ZVS5.1''))
DECLARE @CHECK_RESULT_COUNTRY_B int =(Select COUNT(ID) from ZVSTAT_Reporting where ZVSTA_Schema=@ZVSTA_Schema and ReportingPeriod=@REPORTING_PERIOD 
                                and PositionNr in (''FTT'') and LandCode in (@COUNTRY_CODE_B) and Landkontext in (@LAND_KONTEXT) and FormNr in (''ZVS5.1''))

IF @CHECK_RESULT_W0=0
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,FormNr,FormName,PositionNr,PositionName,@LAND_KONTEXT,''W0'' ,''N'',Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo 
	from ZVSTAT_Parameters_from2014
	where ZVSTA_Schema=@ZVSTA_Schema and FormNr in (''ZVS5.1'') and PositionNr in (''FTT'')
END

IF @CHECK_RESULT_COUNTRY_A=0
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,FormNr,FormName,PositionNr,PositionName,@LAND_KONTEXT,@COUNTRY_CODE_A ,''N'',Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo 
	from ZVSTAT_Parameters_from2014
	where ZVSTA_Schema=@ZVSTA_Schema and FormNr in (''ZVS5.1'') and PositionNr in (''FTT'')
END

IF @CHECK_RESULT_COUNTRY_B=0
BEGIN
INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,FormNr,FormName,PositionNr,PositionName,@LAND_KONTEXT,@COUNTRY_CODE_B ,''N'',Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo 
	from ZVSTAT_Parameters_from2014
	where ZVSTA_Schema=@ZVSTA_Schema and FormNr in (''ZVS5.1'') and PositionNr in (''FTT'')
END', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18267, N'FormNr:ZVS5.2-Go to each ID in #Temp_ZVSTA_ID_Position and insert each Position in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 8, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

DECLARE @ZVSTAT_COUNTRIES as Table
([ID] [int] IDENTITY(1,1) NOT NULL,
[CountryCode] [nvarchar](50) NULL,
CountryName nvarchar(255) NULL)

INSERT INTO @ZVSTAT_COUNTRIES
(CountryCode,CountryName)
Select CountryCode,CountryName from Countries where Status in (''Y'') and EU_EEA in (''EU'',''EEA'') and ZVSTA_Relevant in (''Y'') and SubdivisionOfCountryCode is NULL
UNION ALL
Select ''G1'',''Rest der Welt''

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
--Declare Minimum ansd Maximum ID in the Table:#Temp_ZVSTA_ID_Position
-----------------------------------------------------------------------------
DECLARE @MIN_ID_Table_ZVSTA_ID_Position int=1
DECLARE @MAX_ID_Table_ZVSTA_ID_Position int=(Select MAX(ID) from #Temp_ZVSTA_ID_Position)
-------Go to each ID in #Temp_ZVSTA_ID_Position----------
WHILE @MIN_ID_Table_ZVSTA_ID_Position<=@MAX_ID_Table_ZVSTA_ID_Position
BEGIN
-------Get all data from each column for each ID in #Temp_ZVSTA_ID_Position----------
DECLARE @ZVSTA_Current_Schema nvarchar(255)=(Select ZVSTA_Schema from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormNr nvarchar(50)=(Select FormNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @FormName nvarchar(255)=(Select FormName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionNr nvarchar(50)=(Select PositionNr from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionName nvarchar(max)=(Select PositionName from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Landkontext nvarchar(10)=(Select Landkontext from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @LandCode nvarchar(50)=(Select LandCode from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PayCardSystem nvarchar(255)=(Select PayCardSystem from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Anzahl nvarchar(50)=(Select Anzahl from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @Wert nvarchar(50)=(Select Wert from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @SumPosition nvarchar(50)=(Select SumPosition from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionSQLcommand nvarchar(max)=(Select PositionSQLcommand from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))
DECLARE @PositionInfo nvarchar(max)=(Select PositionInfo from [ZVSTAT_Parameters_from2014] where ID=(Select ID_ORIG from #Temp_ZVSTA_ID_Position where ID=@MIN_ID_Table_ZVSTA_ID_Position))

BEGIN

--Only W0 for related countries
IF @LandCode in (''W0'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema and @Landkontext=@LAND_KONTEXT
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.CountryCode ,''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from @ZVSTAT_COUNTRIES A
	where A.CountryCode in (@COUNTRY_CODE_A) 
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''W0'',''W0'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo             
END

--Only Specific Country Codes for each EU-Country and CARDS
IF @LandCode in (''G1'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema and (@COUNTRY_CODE_A=''G1'' or @COUNTRY_CODE_B=''G1'') and @Landkontext=@LAND_KONTEXT
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.CountryCode ,''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from @ZVSTAT_COUNTRIES A
	where CountryCode in (@COUNTRY_CODE_A) 
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''G1'',''W0'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''W0'',''G1'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo
END

IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''N'') and @ZVSTA_Current_Schema=@ZVSTA_Schema and @Landkontext=@LAND_KONTEXT
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,C.CountryCode,''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from @ZVSTAT_COUNTRIES A, @ZVSTAT_COUNTRIES C
	where  A.CountryCode in (@COUNTRY_CODE_A) and C.CountryCode in (@COUNTRY_CODE_B)
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,''W0'',''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from Countries A
	where CountryCode in (@COUNTRY_CODE_A)
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''W0'',A.CountryCode,''PCS_ALL'',@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from Countries A
	where CountryCode in (@COUNTRY_CODE_A)
END


--	--WITH CARDS
IF @LandCode in (''W0'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema and @Landkontext=@LAND_KONTEXT
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.CountryCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from @ZVSTAT_COUNTRIES A,ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
	and CountryCode in (@COUNTRY_CODE_A)
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''W0'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END

IF @LandCode in (''G1'') and @PayCardSystem in (''CARDS_ALL'') and (@COUNTRY_CODE_A=''G1'' or @COUNTRY_CODE_B=''G1'') and @ZVSTA_Current_Schema=@ZVSTA_Schema and @Landkontext=@LAND_KONTEXT
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,A.CountryCode ,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from @ZVSTAT_COUNTRIES A,ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
	and CountryCode in (@COUNTRY_CODE_A)
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,@LandCode,''W0'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''W0'',@LandCode,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'')
END

IF @LandCode in (''EU_EEA_SEPARAT'') and @PayCardSystem in (''CARDS_ALL'') and @ZVSTA_Current_Schema=@ZVSTA_Schema and @Landkontext=@LAND_KONTEXT
BEGIN
	INSERT INTO #Temp_ZVSTAT_Report(ZVSTA_Schema,ReportingPeriod,FormNr,FormName,PositionNr,PositionName,Landkontext,LandCode,LandCode_T,PayCardSystem,Anzahl,Wert,SumPosition,PositionSQLcommand,PositionInfo)
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,C.CountryCode,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from @ZVSTAT_COUNTRIES A, ZVSTAT_Pay_Cards_Parameters B,Countries C
	where  A.CountryCode in (@COUNTRY_CODE_A) and C.CountryCode in (@COUNTRY_CODE_B) and B.[ZVSTA_Parameter_General] in (''CARDS'')
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,A.CountryCode,''W0'',B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from @ZVSTAT_COUNTRIES A, ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'') and A.CountryCode in (@COUNTRY_CODE_A) and B.[ZVSTA_Parameter_General] in (''CARDS'')
UNION ALL
	SELECT @ZVSTA_Schema,@REPORTING_PERIOD,@FormNr,@FormName,@PositionNr,@PositionName,@Landkontext,''W0'',A.CountryCode,B.ParameterValue1,@Anzahl,@Wert,@SumPosition,@PositionSQLcommand,@PositionInfo 
	from @ZVSTAT_COUNTRIES A, ZVSTAT_Pay_Cards_Parameters B
	where B.[ZVSTA_Parameter_General] in (''CARDS'') and b.Status in (''Y'') and A.CountryCode in (@COUNTRY_CODE_A) and B.[ZVSTA_Parameter_General] in (''CARDS'')

END
		

END


--Go to the next ID and start the a.m. command again
SET @MIN_ID_Table_ZVSTA_ID_Position=@MIN_ID_Table_ZVSTA_ID_Position+1

END', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18268, N'FormNr:ZVS5.2 - Delete Duplicates in Temporary Table:#Temp_ZVSTA_Report based on PositionNr+Landkontext+LandCode+LandCode_T+PayCardSystem', NULL, NULL, NULL, 9, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

DELETE from #Temp_ZVSTAT_Report where ID not in (Select MIN(ID) from #Temp_ZVSTAT_Report group by PositionNr+Landkontext+LandCode+ISNULL(LandCode_T,'''')+ISNULL(PayCardSystem,''''))
', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18269, N'Update Temp Table:#Temp_ZVSTA_Report - Form5.2 - Column:PayCardSystem=PCS_ALL if PayCardSystem=N', NULL, NULL, NULL, 10, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE #Temp_ZVSTAT_Report SET PayCardSystem=''PCS_ALL'' 
where FormNr in (''ZVS5.2'') and PayCardSystem in (''N'')
', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18270, N'Update Land code description and PayCard System description in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 11, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

--Update LandCode_Description
UPDATE A SET A.LandCode_Description=
Case when A.LandCode in (''DE'') then ''Inländisch''
     when A.LandCode in (''W0'') then ''Inländisch und grenzüberschreitent kombiniert (Total)''
     when A.LandCode in (''G1'') then ''Rest der Welt (außerhalb des EWR)''
     when A.LandCode in (''G3'') then ''Grenzüberschreitend innerhalb des EWR''
else (Select B.CountryName from Countries B where B.CountryCode=A.LandCode)  end 
from #Temp_ZVSTAT_Report  A 

--Update LandCode_Description
UPDATE A SET A.LandCode_T_Description=
Case when A.LandCode_T in (''DE'') then ''Inländisch''
     when A.LandCode_T in (''W0'') then ''Inländisch und grenzüberschreitent kombiniert (Total)''
     when A.LandCode_T in (''G1'') then ''Rest der Welt (außerhalb des EWR)''
     when A.LandCode_T in (''G3'') then ''Grenzüberschreitend innerhalb des EWR''
else (Select B.CountryName from Countries B where B.CountryCode=A.LandCode_T)  end 
from #Temp_ZVSTAT_Report  A 


--Update PayCardSystem_Description
UPDATE A SET A.PayCardSystem_Description=B.ParameterValue2 
from #Temp_ZVSTAT_Report A INNER JOIN ZVSTAT_Pay_Cards_Parameters B on A.PayCardSystem=B.ParameterValue1
', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18271, N'Update Subdivision CountryCodes in Temp Table:#Temp_ZVSTA_Report', NULL, NULL, NULL, 12, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE A SET 
A.SubdivisionOfCountryCode=B.SubdivisionOfCountryCode
,A.SubdivisionOfCountryName=B.SubdivisionOfCountryName 
from #Temp_ZVSTAT_Report A INNER JOIN Countries B on A.LandCode=B.CountryCode

UPDATE A SET 
A.SubdivisionOfCountryCode_T=B.SubdivisionOfCountryCode
,A.SubdivisionOfCountryName_T=B.SubdivisionOfCountryName 
from #Temp_ZVSTAT_Report A INNER JOIN Countries B on A.LandCode_T=B.CountryCode
', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18272, N'Replace Standard Parameters with ZV Statistic Parameters', NULL, NULL, NULL, 13, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE #Temp_ZVSTAT_Report 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Schema>'',@ZVSTA_Schema)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report  
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_SchemaPeriod>'',
CASE WHEN RIGHT(@ZVSTA_Schema,1)=''H'' then ''HALFYEARLY'' 
when RIGHT(@ZVSTA_Schema,1)=''Q'' then ''QUARTERLY'' else ''YEARLY'' end )
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report  
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_ReportingPeriod>'',@REPORTING_PERIOD)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<SumPosition>'',SumPosition)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<CountPosition>'',Anzahl)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report  
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ValuePosition>'',Wert)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report  
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<PaymentFlow>'',Landkontext)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report  
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_Position>'',PositionNr)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report  
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_COUNTRY_A>'',LandCode)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_COUNTRY_B>'',LandCode_T)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''


UPDATE #Temp_ZVSTAT_Report  
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ZVSTA_PaymentCardSystem>'',PayCardSystem)
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''
', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18273, N'Insert all generated positions from Temp table:#Temp_ZVSTA_Report  to Live Table:ZVSTA_Reporting', NULL, NULL, NULL, 14, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

--Insert Data to Live Table
INSERT INTO [dbo].[ZVSTAT_Reporting]
           ([ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[LandCode_T]
           ,[LandCode_T_Description]
           ,[SubdivisionOfCountryCode_T]
           ,[SubdivisionOfCountryName_T]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand]
     ,PositionInfo)
SELECT [ZVSTA_Schema]
           ,[ReportingPeriod]
           ,[LfdNr]
           ,[FormNr]
           ,[FormName]
           ,[PositionNr]
           ,[PositionName]
           ,[Landkontext]
           ,[LandCode]
           ,[LandCode_Description]
           ,[SubdivisionOfCountryCode]
           ,[SubdivisionOfCountryName]
           ,[LandCode_T]
           ,[LandCode_T_Description]
           ,[SubdivisionOfCountryCode_T]
           ,[SubdivisionOfCountryName_T]
           ,[PayCardSystem]
           ,[PayCardSystem_Description]
           ,[Anzahl]
           ,[Wert]
           ,[SumPosition]
           ,[PositionSQLcommand] 
     ,PositionInfo
from #Temp_ZVSTAT_Report
--where [ZVSTA_Schema]+[ReportingPeriod]+[FormNr]+[PositionNr]+[Landkontext]+[LandCode]+[LandCode_T]+ISNULL([PayCardSystem],'''')
--not in (Select [ZVSTA_Schema]+[ReportingPeriod]+[FormNr]+[PositionNr]+[Landkontext]+[LandCode]+[LandCode_T]+ISNULL([PayCardSystem],'''')
--from [ZVSTAT_Reporting] where [ZVSTA_Schema]=@ZVSTA_Schema and [ReportingPeriod]=@REPORTING_PERIOD and PositionName not in --(''FEHLANZEIGE''))
', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18274, N'Drop all Temporary Tables if existing', NULL, NULL, NULL, 15, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

IF OBJECT_ID(''tempdb..#Temp_ZVSTA_FormNr'') IS NOT NULL DROP TABLE #Temp_ZVSTA_FormNr
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_ID_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_ID_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTA_Position'') IS NOT NULL DROP TABLE #Temp_ZVSTA_Position
IF OBJECT_ID(''tempdb..#Temp_ZVSTAT_Report'') IS NOT NULL DROP TABLE #Temp_ZVSTAT_Report', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18275, N'Recalculate LfdNr in Live Table:ZVSTA_Reporting', NULL, NULL, NULL, 16, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE A SET A.LfdNr=B.RowNumber 
from ZVSTAT_Reporting A INNER JOIN
(SELECT ROW_NUMBER() OVER(ORDER BY ID asc) AS RowNumber,  ID
from ZVSTAT_Reporting A 
where A.[ZVSTA_Schema]+A.[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD) B
on A.ID=B.ID
where A.[ZVSTA_Schema]+A.[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18276, N'Replace Parameter ID with Live Table ID Value', NULL, NULL, NULL, 17, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE [ZVSTAT_Reporting] 
SET [PositionSQLcommand]=
REPLACE([PositionSQLcommand],''<ID>'',CONVERT(nvarchar(255),ID))
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
and [PositionSQLcommand] is not NULL
and FormNr=''ZVS5.2''




', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18277, N'Set Status:A (NOT FINALIZED) in ZVSTA Report', NULL, NULL, NULL, 18, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''
DECLARE @COUNTRY_CODE_A nvarchar(2)=''<ZV_COUNTRY_A>''
DECLARE @COUNTRY_CODE_B nvarchar(2)=''<ZV_COUNTRY_B>''
DECLARE @LAND_KONTEXT nvarchar(255)=''<ZV_LANDKONTEXT>''
DECLARE @COUNTRY_CODE nvarchar(2)=''<ZV_COUNTRY>''
DECLARE @POSITION_NR nvarchar(255)=''<ZV_MELDEPOSITION>''

UPDATE ZVSTAT_Reporting SET [ReportStatus]=''A''
where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD
', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
INSERT INTO [dbo].[SQL_PARAMETER_DETAILS_SECOND] ([ID], [SQL_Name_1], [SQL_Name_2], [SQL_Name_3], [SQL_Name_4], [SQL_Float_1], [SQL_Float_2], [SQL_Float_3], [SQL_Float_4], [SQL_Command_1], [SQL_Command_2], [SQL_Command_3], [SQL_Command_4], [SQL_Date1], [SQL_Date2], [Status], [Id_SQL_Parameters_Details]) VALUES (18278, N'Delete Row:FEHLANZEIGE if there are Data on the Report', NULL, NULL, NULL, 19, NULL, NULL, NULL, N'DECLARE @ZVSTA_Schema nvarchar(255)=''<ZV_MELDESCHEMA>''
DECLARE @REPORTING_PERIOD nvarchar(255)=''<ZV_MELDEPERIODE>''

DECLARE @SUM_COUNT int = 
(Select Sum(B.CountID) from
(Select Count(ID) as CountID from ZVSTAT_Reporting where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD  and PositionName in (''FEHLANZEIGE'') 
UNION ALL
Select Count(ID) as CountID from ZVSTAT_Reporting where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD  and PositionName not in (''FEHLANZEIGE''))B)

IF  @SUM_COUNT>1 
BEGIN
DELETE from ZVSTAT_Reporting where [ZVSTA_Schema]+[ReportingPeriod]=@ZVSTA_Schema+@REPORTING_PERIOD  
and PositionName in (''FEHLANZEIGE'') 
END', NULL, NULL, NULL, NULL, NULL, N'Y', 3858)
SET IDENTITY_INSERT [dbo].[SQL_PARAMETER_DETAILS_SECOND] OFF
