create procedure sp_newsCRUD
@Id int=null,
@Title nvarchar(500)=null,
@Description nvarchar(max)=null,
@TagId int=null,
@CreatedDate date=null,
@CreatedBy int=null,
@flag nvarchar(40)
As
begin
	if(@flag='Insert')
	begin
		if exists(select * from News where Title=@Title)
		begin
			select 101
		end
		else
		begin
			insert into News
			(
			Title,
			Description,
			TagId,
			CreatedDate,
			CreatedBy
			)
			values
			(
			@Title,
			@Description,
			@TagId,
			@CreatedDate,
			@CreatedBy
			)
		end
	end
	if(@flag='Update')
	begin
		if exists(select * from News where Title=@Title)
		begin
			select 101
		end
		else
		begin
			update News
			set 
			Title=@Title,
			Description=@Description,
			TagId=@TagId,
			CreatedDate=@CreatedDate,
			CreatedBy=@CreatedBy
			
		end
	end
	if(@flag='Delete')
	begin
		if exists(select * from News where Id=@Id)
		begin
			delete News where Id=@Id
		end
	end
	if(@flag='Gets')
	begin
		select * from News
	end
	if(@flag='Get')
	begin
		select * from News where Id=@Id
	end
	
end