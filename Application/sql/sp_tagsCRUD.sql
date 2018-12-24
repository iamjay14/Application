CREATE Procedure Sp_tagsCRUD
	 @Id int = null,
	 @TypeId int=null,
	 @Type nvarchar(200)=null,
	 @TagId int=null,
	 @flag varchar(40)
As
Begin
	set NOCOUNT ON;

	if(@flag='Insert')
	begin
		if exists (select * from Tags where TypeId=@TypeId and Type=@Type and TagId=@TagId)
		begin
			select 104
		end
		else
		begin
			declare @errorstr varchar(max)
			set @errorstr=''
			insert into Tags(  
			TypeId,  
			Type,
			TagId
			) values (  
			@TypeId,  
			@Type,
			@TagId
			)
			
		end
	end
	if(@flag='Update')
	begin
		declare @errorstr_up varchar(max)
		set @errorstr_up=''
		update Tags set TypeId=@TypeId,Type=@Type,TagId=@TagId where Id=@Id
		select 102,@errorstr_up
	end
	if(@flag='Delete')
	begin 
		delete from Tags where Id=@Id
		select 103
	end
	if(@flag='Select')
	begin
		Select * from Tags
	end
	if(@flag='Selectid')
	begin
		select * from Tags where Id=@Id
	end
End