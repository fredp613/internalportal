USE [GCIMSTraining]
GO
/****** Object:  StoredProcedure [dbo].[web_sp_createProject]    Script Date: 5/8/2017 6:04:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[web_sp_createProject] 
	@GCIMSUserName varchar(200),
	@ClientID varchar(6),
	@Lang nvarchar(1),
	@FiscalYear nvarchar(9),
	@RequestedAmount Money, 
	@GCDocsNumber nvarchar(300),
	@CommitmentItemID nvarchar(100),
	@Title nvarchar(1000), 
	@Description nvarchar(4000), 
	@StartDate datetime,
	@EndDate datetime,	
	@ProjectID int OUTPUT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @ApplicationID int
	declare @ElectoralRidingID int
	declare @ClientPostalCode nvarchar(30)
	declare @GCIMSUserID int
	declare @BusinessLineID nvarchar(200)
	declare @SummaryCommitmentID nvarchar(100)
	declare @SubServiceLineID nvarchar(100)
	declare @ProductLineID nvarchar(100)
	declare @FundingMethodID nvarchar(100)
	declare @Now datetime
	SET @Now = GetDate()
	

	SET @FundingMethodID = (select FundingMethodID from luCommitmentItems where CommitmentItemID=@CommitmentItemID)

	SET @SummaryCommitmentID = (select SummaryCommitmentID from luCommitmentItems where CommitmentItemID=@CommitmentItemID)

	SET @SubServiceLineID = (select SubServiceLineID from luSummaryCommitments where SummaryCommitmentID = @SummaryCommitmentID)

	SET @ProductLineID = (select ProductLineID from luSubServiceLines where SubServiceLineID = @SubServiceLineID)	

	SET @BusinessLineID = (select businesslineid from luProductLines where ProductLineID = @ProductLineID)

	SET @ClientPostalCode = 'S7K3R6'
	SET @ElectoralRidingID = 547


	SET @ProjectID = 1
	SET @ApplicationID = 1
	SET @GCIMSUserID = 659
	select * from luActiveSummaryCommitments


	exec sp_GetNextProjectID @ProjectID output select @ProjectID

	exec sp_GetNextApplicationID @ApplicationID output select @ApplicationID

	print @ApplicationID
	exec sp_executesql N'INSERT INTO "GCIMSTraining".."tblProjects" ("ProjectID","ClientID","ProjectFiscalYearID","ProjectNumber","ProjectName","ProjectDescription","FundingTypeID","StartDate","EndDate","CreatedBy","CreatedDate","UpdatedBy","UpdatedDate","LogicalUpdatedBy","LogicalUpdatedDate","PostalCode","OriginalElectoralRidingID","ProjectDescriptionE","ProjectDescriptionLanguageID","ProjectTypeID") VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17,@P18,@P19,@P20)',N'@P1 int,@P2 varchar(6),@P3 varchar(8),@P4 int,@P5 varchar(255),@P6 text,@P7 varchar(1),@P8 datetime,@P9 datetime,@P10 varchar(30),@P11 datetime,@P12 varchar(30),@P13 datetime,@P14 varchar(30),@P15 datetime,@P16 varchar(6),@P17 int,@P18 text,@P19 varchar(1),@P20 int',@ProjectID,@ClientID,@FiscalYear,5,@Title,@Description,NULL,@Now,@Now,@GCIMSUserName,@Now,@GCIMSUserName,@Now,@GCIMSUserName,@Now,@ClientPostalCode,@ElectoralRidingID,@Description,@Lang,1

exec sp_executesql N'INSERT INTO "GCIMSTraining".."tblApplications" ("ApplicationID","ProjectID","ApplicationFiscalYearID","DepartmentID","BusinessLineID","ProductLineID","SubServiceLineID","SummaryCommitmentID","CommitmentItemID","RegionID","FundCentreID","ApplicationNumber","FundingMethodID","ApplicationStatusID","RecievedDate","RequestedAmount","CurrentOwnerID","OfficerOfRecordID","CreatedBy","CreatedDate","UpdatedBy","UpdatedDate","LogicalUpdatedBy","LogicalUpdatedDate","ProgramFileNumber","ProjectTypeID") VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17,@P18,@P19,@P20,@P21,@P22,@P23,@P24,@P25,@P26)',N'@P1 int,@P2 int,@P3 varchar(8),@P4 varchar(2),@P5 varchar(2),@P6 varchar(2),@P7 varchar(2),@P8 varchar(5),@P9 varchar(4),@P10 varchar(2),@P11 varchar(5),@P12 smallint,@P13 varchar(1),@P14 varchar(1),@P15 datetime,@P16 money,@P17 int,@P18 int,@P19 varchar(9),@P20 datetime,@P21 varchar(9),@P22 datetime,@P23 varchar(9),@P24 datetime,@P25 varchar(7),@P26 int',@ApplicationID,@ProjectID,@FiscalYear,'DJ',@BusinessLineID,@ProductLineID,@SubServiceLineID,@SummaryCommitmentID,@CommitmentItemID,'1','PrgmB',1,@FundingMethodID,'M',@Now,@RequestedAmount,@GCIMSUserID,@GCIMSUserID,@GCIMSUserName,@Now,@GCIMSUserName,@Now,@GCIMSUserName,@Now,@GCDocsNumber,1

declare @NewId uniqueidentifier
set @NewId = NEWID();

exec sp_executesql N'INSERT INTO "GCIMSTraining".."tblProjectDateRevisions" ("ProjectDateRevisionID","ProjectID","AmendmentID","StartDate","EndDate","ProjectFiscalYearID","Justification",
"Current","CreatedBy","CreatedDate","UpdatedBy","UpdatedDate") VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12)',N'@P1 uniqueidentifier,@P2 int,@P3 uniqueidentifier,@P4 datetime,@P5 datetime,@P6 varchar(8),@P7 text,@P8 bit,@P9 varchar(30),@P10 datetime,@P11 varchar(30),@P12 datetime',@NewId,@ProjectID,NULL,@StartDate,@EndDate,@FiscalYear,'',1,@GCIMSUserName,@Now,@GCIMSUserName,@Now


exec sp_InsertSystemEvent NULL,NULL,@ApplicationID,'Application Created / Demande créée','Application Created / Demande créée',@GCIMSUserName,0,1,23

exec up_CreateApplicationConfigurationSnapshot '873C8085-25AB-4012-9FFA-BE47A7C8A1DC',@FundingMethodID,1,@ApplicationID,@GCIMSUserName

exec up_LoadApplicationConfigurationTemplates @ProjectID

exec sp_CreateWorkflow @ApplicationID,@GCIMSUserName

exec sp_InsertUserApplication @ApplicationID,@GCIMSUserID

declare @p3 int
set @p3=17919
exec sp_CreateEligibilitySnapshot @ApplicationID,@GCIMSUserName,@p3 output
select @p3

exec sp_CreateRiskSnapshot @ApplicationID,@GCIMSUserName,1

exec sp_CreateRiskSnapshot @ApplicationID,@GCIMSUserName,2

declare @SpecificFieldTemplate uniqueidentifier


IF EXISTS(SELECT TOP 1 [SpecificFieldTemplateID]
  FROM [GCIMSTraining].[dbo].[tblProgramSpecificFieldTemplates]
  where CommitmentItemID = @CommitmentItemID and FiscalYearID = @FiscalYear)

	SET @SpecificFieldTemplate = (SELECT TOP 1 [SpecificFieldTemplateID]
	  FROM [GCIMSTraining].[dbo].[tblProgramSpecificFieldTemplates]
	  where CommitmentItemID = @CommitmentItemID and FiscalYearID = @FiscalYear) 

ELSE IF
 EXISTS(SELECT TOP 1 [SpecificFieldTemplateID]
  FROM [GCIMSTraining].[dbo].[tblProgramSpecificFieldTemplates]
  where SummaryCommitmentID = @SummaryCommitmentID and FiscalYearID = @FiscalYear) 

	SET @SpecificFieldTemplate = (SELECT TOP 1 [SpecificFieldTemplateID]
	  FROM [GCIMSTraining].[dbo].[tblProgramSpecificFieldTemplates]
	  where SummaryCommitmentID = @SummaryCommitmentID and FiscalYearID = @FiscalYear)

ELSE IF
 EXISTS(SELECT TOP 1 [SpecificFieldTemplateID]
  FROM [GCIMSTraining].[dbo].[tblProgramSpecificFieldTemplates]
  where SubServiceLineID = @SubServiceLineID and FiscalYearID = @FiscalYear) 

	SET @SpecificFieldTemplate = (SELECT TOP 1 [SpecificFieldTemplateID]
	  FROM [GCIMSTraining].[dbo].[tblProgramSpecificFieldTemplates]
	  where SubServiceLineID = @SubServiceLineID and FiscalYearID = @FiscalYear)

ELSE IF
 EXISTS(SELECT TOP 1 SpecificFieldTemplateID
  FROM [GCIMSTraining].[dbo].[tblProgramSpecificFieldTemplates]
  where ProductLineID = @ProductLineID and FiscalYearID = @FiscalYear) 

	SET @SpecificFieldTemplate = (SELECT TOP 1 SpecificFieldTemplateID
	  FROM [GCIMSTraining].[dbo].[tblProgramSpecificFieldTemplates]
	  where ProductLineID = @ProductLineID and FiscalYearID = @FiscalYear)

ELSE

	SET @SpecificFieldTemplate = (SELECT TOP 1 SpecificFieldTemplateID
		FROM [GCIMSTraining].[dbo].[tblProgramSpecificFieldTemplates]
		where BusinessLineID = @BusinessLineID and FiscalYearID = @FiscalYear)



exec up_GetNewApplicationSpecificFieldTemplateIDs @SpecificFieldTemplate,@ApplicationID

DECLARE	@OUT uniqueidentifier
exec web_up_CreateSpecificFieldSnapshot @SpecificFieldTemplate,@GCIMSUserName,NULL, @OUT OUTPUT

exec sp_executesql N'INSERT INTO "GCIMSTraining".."tblApplicationUserSpecificFieldTemplates" ("UserSpecificFieldTemplateID","ApplicationID","CreatedBy","CreatedDate","UpdatedBy","UpdatedDate") VALUES (@P1,@P2,@P3,@P4,@P5,@P6)',N'@P1 uniqueidentifier,@P2 int,@P3 varchar(9),@P4 datetime,@P5 varchar(9),@P6 datetime',@OUT,@ApplicationID,@GCIMSUserName,@Now,@GCIMSUserName,@Now 


SELECT @ProjectID


END
