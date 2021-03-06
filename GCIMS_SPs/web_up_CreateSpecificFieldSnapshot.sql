USE [GCIMSTraining]
GO
/****** Object:  StoredProcedure [dbo].[web_up_CreateSpecificFieldSnapshot]    Script Date: 5/9/2017 4:35:36 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



ALTER PROCEDURE [dbo].[web_up_CreateSpecificFieldSnapshot]
(
	@SpecificFieldTemplateIDs	VARCHAR(8000)
	,@UserName			VARCHAR(30)
	,@Date				DateTime	= NULL
	,@Out				uniqueidentifier OUTPUT
)
AS

SET NOCOUNT ON

declare @CreatedTmpTable	as bit		-- Flag: Did we created the SpecificField Template array table

	-- If the Date was not supplied set it
	if @Date is null
		set @Date = GetDate()

	--Check to see if TEMP table created
	set @CreatedTmpTable = 0
	if OBJECT_ID('tempdb..#tmpUniqueIdentifiers') is NULL Begin
		CREATE TABLE #tmpUniqueIdentifiers (
			UniqueID	UNIQUEIDENTIFIER	PRIMARY KEY
			,NewUniqueID 	UNIQUEIDENTIFIER
		)
		Set @CreatedTmpTable = 1
	End

	--Split the array of IDs into a table
	execute up_SplitUniqueIdentifiers @SpecificFieldTemplateIDs
	
	--Create User Template snapshot
	insert into tblUserSpecificFieldTemplates
	(
		UserSpecificFieldTemplateID
		,SpecificFieldTemplateID
		,Active
		,CreatedBy
		,CreatedDate
		,UpdatedBy
		,UpdatedDate
	)
	select	tmpTemplates.NewUniqueID			--UserSpecificFieldTemplateID
		,Templates.SpecificFieldTemplateID		--SpecificFieldTemplateID
		,1						--Active: True
		,@UserName					--CreatedBy
		,@Date						--CreatedDate
		,@UserName					--UpdatedBy
		,@Date						--UpdatedDate
	from	tblSpecificFieldTemplates as Templates
		inner join #tmpUniqueIdentifiers as tmpTemplates on
			tmpTemplates.UniqueID = Templates.SpecificFieldTemplateID
	
	--Create User Data snapshot (for Row 1)
	insert into tblUserSpecificFieldData
	(
		UserSpecificFieldDataID
		,UserSpecificFieldTemplateID
		,SpecificFieldID
		,RowID
		,StringValue
		,MoneyValue
		,NumberValue
		,DateValue
		,TextValue
		,LookupValue
		,IsVisible
		,IsLocked
		,CreatedBy
		,CreatedDate
		,UpdatedBy
		,UpdatedDate
	)
	select	NEWID()					--UserSpecificFieldDataID
		,UserTemplates.UserSpecificFieldTemplateID	--UserSpecificFieldTemplateID
		,Fields.SpecificFieldID
		,1						--RowID (all user data starts at Row 1)
		,NULL						--StringValue
		,NULL						--MoneyValue
		,NULL						--NumberValue
		,NULL						--DateValue
		,NULL						--TextValue
		,NULL						--LookupValue
		,1						--IsVisible: True (all data starts as visible until other indicated by rules)
		,0						--IsLocked
		,@UserName					--CreatedBy
		,@Date						--CreatedDate
		,@UserName					--UpdatedBy
		,@Date						--UpdatedDate
	from	tblSpecificFields as Fields
		inner join tblUserSpecificFieldTemplates as UserTemplates on
			UserTemplates.SpecificFieldTemplateID = Fields.SpecificFieldTemplateID
--			and UserTemplates.CreatedDate = @Date
--			and UserTemplates.CreatedBy = @UserName
		inner join #tmpUniqueIdentifiers as tmpTemplates on
			tmpTemplates.NewUniqueID = UserTemplates.UserSpecificFieldTemplateID

	-- Update field data type: Table (set total number of rows = 0)
	-- Update field data type: #/$Column: (set running totals for fields that are columns in a table = 0)
	update	tblUserSpecificFieldData
	set	NumberValue = case FieldMasters.FieldTypeID
					when	11	then 	0		--11: Number
					when	14	then	0		--14: Table
					else			NULL
				end
		,MoneyValue = 	case FieldMasters.FieldTypeID
					when	8	then 	0		--8: Currency
					else			NULL
				end
	from	tblUserSpecificFieldData
		inner join tblSpecificFields as Fields on
			Fields.SpecificFieldID = tblUserSpecificFieldData.SpecificFieldID
		inner join tblSpecificFieldMasters as FieldMasters on
			FieldMasters.SpecificFieldMasterID = Fields.SpecificFieldMasterID
		inner join tblUserSpecificFieldTemplates as UserTemplates on
			UserTemplates.SpecificFieldTemplateID = Fields.SpecificFieldTemplateID
			and UserTemplates.UserSpecificFieldTemplateID = tblUserSpecificFieldData.UserSpecificFieldTemplateID
--			and UserTemplates.CreatedDate = @Date
--			and UserTemplates.CreatedBy = @UserName
		inner join #tmpUniqueIdentifiers as tmpTemplates on
			tmpTemplates.NewUniqueID = UserTemplates.UserSpecificFieldTemplateID
	where	FieldMasters.FieldTypeID = 14		--Table
		or (Fields.IsRunningTotal = 1		--True (must be a field in a table)
		  and FieldMasters.FieldTypeID in (11, 8))	--11: Number, 8: Currency

	--Apply Defaults from Row 1
	update	tblUserSpecificFieldData
	set	StringValue = Defaults.StringValue
		,MoneyValue = Defaults.MoneyValue
		,NumberValue = Defaults.NumberValue
		,DateValue = Defaults.DateValue
		,TextValue = Defaults.TextValue
		,LookupValue = Defaults.LookupValue
	from	tblUserSpecificFieldData
		inner join tblSpecificFieldDefaults as Defaults on
			Defaults.SpecificFieldID = tblUserSpecificFieldData.SpecificFieldID
		inner join tblUserSpecificFieldTemplates as UserTemplates on
			UserTemplates.UserSpecificFieldTemplateID = tblUserSpecificFieldData.UserSpecificFieldTemplateID
			and UserTemplates.UserSpecificFieldTemplateID = tblUserSpecificFieldData.UserSpecificFieldTemplateID
--			and UserTemplates.CreatedDate = @Date
--			and UserTemplates.CreatedBy = @UserName
		inner join #tmpUniqueIdentifiers as tmpTemplates on
			tmpTemplates.NewUniqueID = UserTemplates.UserSpecificFieldTemplateID
	where	Defaults.RowID = 1

	--Apply Remaining Defaults (all values > Row 1)
	insert into tblUserSpecificFieldData
	(
		UserSpecificFieldDataID
		,UserSpecificFieldTemplateID
		,SpecificFieldID
		,RowID
		,StringValue
		,MoneyValue
		,NumberValue
		,DateValue
		,TextValue
		,LookupValue
		,IsVisible
		,IsLocked
		,CreatedBy
		,CreatedDate
		,UpdatedBy
		,UpdatedDate
	)
	select	NEWID()					--UserSpecificFieldDataID
		,UserData.UserSpecificFieldTemplateID		--UserSpecificFieldTemplateID
		,UserData.SpecificFieldID
		,Defaults.RowID
		,Defaults.StringValue
		,Defaults.MoneyValue
		,Defaults.NumberValue
		,Defaults.DateValue
		,Defaults.TextValue
		,Defaults.LookupValue
		,1						--IsVisible: True (all data starts as visible until other indicated by rules)
		,CASE
			WHEN Defaults.StringValue IS NOT NULL	THEN 1
			WHEN Defaults.MoneyValue IS NOT NULL	THEN 1
			WHEN Defaults.NumberValue IS NOT NULL	THEN 1
			WHEN Defaults.DateValue IS NOT NULL		THEN 1
			WHEN Defaults.TextValue IS NOT NULL		THEN 1
			WHEN Defaults.LookupValue IS NOT NULL	THEN 1	
									ELSE 0
		END						--IsLocked (If there is a Non-Null default in a Table (ie RowID > 1) then the Field should be locked
		,@UserName					--CreatedBy
		,@Date						--CreatedDate
		,@UserName					--UpdatedBy
		,@Date						--UpdatedDate
	from	tblUserSpecificFieldData as UserData
		inner join tblSpecificFieldDefaults as Defaults on
			Defaults.SpecificFieldID = UserData.SpecificFieldID
		inner join tblUserSpecificFieldTemplates as UserTemplates on
			UserTemplates.UserSpecificFieldTemplateID = UserData.UserSpecificFieldTemplateID
--			and UserTemplates.CreatedDate = @Date
--			and UserTemplates.CreatedBy = @UserName
		inner join #tmpUniqueIdentifiers as tmpTemplates on
			tmpTemplates.NewUniqueID = UserTemplates.UserSpecificFieldTemplateID
	where	Defaults.RowID > 1

	--Create User Template Section
	insert into tblUserSpecificFieldTemplateSections
	(
		UserSpecificFieldTemplateSectionID
		,UserSpecificFieldTemplateID
		,SpecificFieldTemplateSectionID
		,SpecificFieldStatusTypeID
		,CreatedBy
		,CreatedDate
		,UpdatedBy
		,UpdatedDate
	)
	select	NEWID()					--UserSpecificFieldTemplateSectionID
		,UserTemplates.UserSpecificFieldTemplateID
		,TemplateSections.SpecificFieldTemplateSectionID
		,2						--SpecificFieldStatusTypeID NotComplete
		,@UserName					--CreatedBy
		,@Date						--CreatedDate
		,@UserName					--UpdatedBy
		,@Date						--UpdatedDate
		
	from	tblUserSpecificFieldTemplates as UserTemplates
		inner join tblSpecificFieldTemplateSections as TemplateSections on
			TemplateSections.SpecificFieldTemplateID = UserTemplates.SpecificFieldTemplateID
		inner join #tmpUniqueIdentifiers as tmpTemplates on
			tmpTemplates.NewUniqueID = UserTemplates.UserSpecificFieldTemplateID
--			and UserTemplates.CreatedDate = @Date
--			and UserTemplates.CreatedBy = @UserName

	--Create User Page Section 
	insert into tblUserSpecificFieldPageSections 
	(
		UserSpecificFieldPageSectionID
		,UserSpecificFieldTemplateSectionID
		,SpecificFieldPageSectionID
		,SpecificFieldStatusTypeID
		,CreatedBy
		,CreatedDate
		,UpdatedBy
		,UpdatedDate
	)
	select 	NEWID()					--UserSpecificFieldPageSectionID
		,UserTemplateSections.UserSpecificFieldTemplateSectionID
		,PageSections.SpecificFieldPageSectionID
		,2						--SpecificFieldStatusTypeID NotComplete
		,@UserName					--CreatedBy
		,@Date						--CreatedDate
		,@UserName					--UpdatedBy
		,@Date						--UpdatedDate

	from	tblSpecificFieldPageSections as PageSections
		inner join tblSpecificFieldTemplateSections as TemplateSections on
			TemplateSections.SpecificFieldTemplateSectionID = PageSections.SpecificFieldTemplateSectionID
		inner join tblUserSpecificFieldTemplateSections as UserTemplateSections on
			TemplateSections.SpecificFieldTemplateSectionID = UserTemplateSections.SpecificFieldTemplateSectionID
		inner join tblUserSpecificFieldTemplates as UserTemplates on
			UserTemplates.UserSpecificFieldTemplateID = UserTemplateSections.UserSpecificFieldTemplateID
		inner join #tmpUniqueIdentifiers as tmpTemplates on
			tmpTemplates.NewUniqueID = UserTemplates.UserSpecificFieldTemplateID
--			and UserTemplates.CreatedDate = @Date
--			and UserTemplates.CreatedBy = @UserName
		

	--Return the SpecificFieldTemplateIDs with the corresponding UserSpecificFieldTemplateIDs

	select	tmpTemplates.UniqueID as SpecificFieldTemplateID
		,UserTemplates.UserSpecificFieldTemplateID
	from	tblUserSpecificFieldTemplates as UserTemplates
		inner join #tmpUniqueIdentifiers as tmpTemplates on
			tmpTemplates.NewUniqueID = UserTemplates.UserSpecificFieldTemplateID

--	where	UserTemplates.CreatedDate = @Date
--		and UserTemplates.CreatedBy = @UserName
	
	select @Out = (select	UserTemplates.UserSpecificFieldTemplateID
	from	tblUserSpecificFieldTemplates as UserTemplates
		inner join #tmpUniqueIdentifiers as tmpTemplates on
			tmpTemplates.NewUniqueID = UserTemplates.UserSpecificFieldTemplateID)
	
	--Cleanup
	IF @CreatedTmpTable = 1
		DROP TABLE #tmpUniqueIdentifiers
	

SET NOCOUNT OFF
RETURN 