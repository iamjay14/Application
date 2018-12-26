Create Procedure sp_quizeTypeCRUD
@Id int=null,
@Name nvarchar(500)=null,
@CategoryId int=null,
@flag nvarchar(40)
As
begin
	if(@flag='Insert')
	begin
		if exists(select * from QuizeType where Name=@Name)
		begin
			select 101
		end
		else
		begin
			insert into QuizeType (Name,CategoryId) values (@Name,@CategoryId)
		end
	end
	if(@flag='Update')
	begin
		if exists(select * from QuizeType where Name=@Name)
		begin
			select 101
		end
		else
		begin
			update QuizeType set Name=@Name,CategoryId=@CategoryId where Id=@Id
		end
	end
	if(@flag='Get')
	begin
		select * from QuizeType where Id=@Id
	end
	if(@flag='Gets')
	begin
		select * from QuizeType
	end
end