Create Procedure sp_questionCRUD
@Id int=null,
@Name nvarchar(500)=null,
@IsActive tinyint=null,
@QuizeTypeId int=null,
@flag nvarchar(40)
As
begin
	if(@flag='Insert')
	begin
		if exists(select * from Question where Name=@Name)
		begin
			select 101
		end
		else
		begin
			insert into Question (Name,IsActive,QuizeTypeId) values (@Name,@IsActive,@QuizeTypeId)
		end
	end
	if(@flag='Update')
	begin
		if exists(select * from Question where Name=@Name)
		begin
			select 101
		end
		else
		begin
			update Question set Name=@Name,IsActive=@IsActive,QuizeTypeId=@QuizeTypeId where Id=@Id
		end
	end
	if(@flag='Get')
	begin
		select * from Question where Id=@Id
	end
	if(@flag='Gets')
	begin
		select * from Question
	end
end