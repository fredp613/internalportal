SET NOCOUNT ON

DECLARE @tableNames table (idx integer primary Key not null, tblName nvarchar(200));
Insert @tableNames(idx,tblName) values 
(1,'luApplicationStatuses'),
(2,'luApprovalTypes'),
(3,'luBusinessLines'),
(4,'luCommitmentItems'),
(5,'luDepartments'),
(6,'luFiscalYears'),
(7,'luFundCentres'),
(8,'luFundingAttributes'),
(9,'luFundingMethods'),
(10,'luProductLines'),
(11,'luProjectTypes'),
(12,'luProvinces'),
(13,'luRegions'),
(14,'luSubServiceLines'),
(15,'luSummaryCommitments'),
(16,'tblAddresses'),
(17,'tblAmendments'),
(18,'tblContacts'),
(19,'tblEligibilityDataHeader'),
(20,'tblProjects'),
(21,'tblUsers'),
(22,'tblApplications')
Declare @Id Integer

while exists (Select tblName from @tableNames)

Begin

select @Id = Min(idx) from @tableNames

declare @TableName sysname = (select tblName from @tableNames where idx = @Id)

declare @Result varchar(max) = 'public class ' + @TableName + ': Controller {' +CHAR(13)+CHAR(13)+  
		'	private readonly GCIMSContext _context;' +CHAR(13)+CHAR(13)+
		'	public '+@TableName+'Controller(GCIMSContext context) {'+CHAR(13)+
		'		_context = context;' +CHAR(13)+
		'	}'+CHAR(13)+

		'	// GET: api/luCommitmentItems'+CHAR(13)+
        '	[HttpGet]'+CHAR(13)+
        '	public IEnumerable<luCommitmentItems> GetluCommitmentItems()'+CHAR(13)+
        '	{'+CHAR(13)+
            '	return _context.luCommitmentItems;'+CHAR(13)+
        '	}'+CHAR(13)+

        '	// GET: api/luCommitmentItems/5'+CHAR(13)+
        '	[HttpGet("{id}")]'+CHAR(13)+
        '	public async Task<IActionResult> GetluCommitmentItems([FromRoute] string id)'+CHAR(13)+
        '	{'+CHAR(13)+
            '	if (!ModelState.IsValid)'+CHAR(13)+
            '	{'+CHAR(13)+
            '		return BadRequest(ModelState);'+CHAR(13)+
            '	}'+CHAR(13)+

           '	var luCommitmentItems = await _context.luCommitmentItems.SingleOrDefaultAsync(m => m.CommitmentItemID == id);'+CHAR(13)+
		   +CHAR(13)+
            '	if (luCommitmentItems == null)'+CHAR(13)+
            '	{'+CHAR(13)+
            '		return NotFound();'+CHAR(13)+
            '	}'+CHAR(13)+
			+CHAR(13)+
            '	return Ok(luCommitmentItems);'+CHAR(13)+
        '	}'+CHAR(13)++CHAR(13)+
		'}'

print @Result

Delete from @tableNames Where idx = @Id

end

SET NOCOUNT OFF