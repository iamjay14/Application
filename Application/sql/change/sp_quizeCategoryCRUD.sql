Create Procedure sp_quizeCategoryCRUD
@Id int=null,
@Name nvarchar(500)=null,
@flag nvarchar(40)
As
begin
	if(@flag='Insert')
	begin
		if exists(select * from QuizeCategory where Name=@Name)
		begin
			select 101
		end
		else
		begin
			insert into QuizeCategory (Name) values (@Name)
		end
	end
	if(@flag='Update')
	begin
		if exists(select * from QuizeCategory where Name=@Name)
		begin
			select 101
		end
		else
		begin
			update QuizeCategory set Name=@Name where Id=@Id
		end
	end
	if(@flag='Get')
	begin
		select * from QuizeCategory where Id=@Id
	end
	if(@flag='Gets')
	begin
		select * from QuizeCategory
	end
end