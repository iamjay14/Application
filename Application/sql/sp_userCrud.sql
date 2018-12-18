create procedure sp_userCRUD
@Id int=null,
@Username nvarchar(100)=null,
@Password nvarchar(100)=null,
@Role nvarchar(20)=null,
@flag nvarchar(40)
As
begin
	if(@flag='Insert')
	begin
		if exists(select * from UserInfo where Username=@Username)
		begin
			select 101
		end
		else
		begin
			insert into UserInfo (Username,Password,Role) values (@Username,@Password,@Role)
		end
	end
	if(@flag='Update')
	begin
		if exists(select * from UserInfo where Username=@Username)
		begin
			select 101
		end
		else
		begin
			update UserInfo set Username=@Username,Password=@Password,Role=@Role where Id=@Id
		end
	end
	if(@flag='Delete')
	begin
		if exists(select * from UserInfo where Id=@Id)
		begin
			delete UserInfo where Id=@Id
		end
	end
	if(@flag='Gets')
	begin
		select * from UserInfo
	end
	if(@flag='Get')
	begin
		select * from UserInfo where Id=@Id
	end
	
end