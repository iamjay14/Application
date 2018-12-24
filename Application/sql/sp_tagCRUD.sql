CREATE Procedure Sp_tagCRUD
	 @Id int = null,
	 @Name nvarchar(200)=null,
	 @CreateDate date=null,
	 @CreateBy int=null,
	 @flag varchar(40),
	 @searchtext varchar(50),
	 @scope int OUTPUT 
As
Begin
	set NOCOUNT ON;

	if(@flag='Insert')
	begin
		if exists (select * from Tag where Name=LTRIM(RTRIM(@Name)))
		begin
			select 104
		end
		else
		begin
			declare @errorstr varchar(max)
			set @errorstr=''
			insert into Tag(  
			Name,  
			CreatedDate,
CreatedBy
			) values (  
			@Name,  
			@CreateDate,
			@CreateBy
			)
			set @scope=SCOPE_IDENTITY();
		end
	end
	if(@flag='Update')
	begin
		declare @errorstr_up varchar(max)
		set @errorstr_up=''
		update Tag set Name=@Name where Id=@Id
		select 102,@errorstr_up
	end
	if(@flag='Delete')
	begin 
		delete from Tag where Id=@Id
		select 103
	end
	if(@flag='Select')
	begin
		Select * from Tag
	end
	if(@flag='Selectid')
	begin
		select * from Tag where Id=@Id
	end
	return @scope
End