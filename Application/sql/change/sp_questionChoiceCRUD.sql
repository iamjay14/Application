Create Procedure sp_questionChoiceCRUD
@Id int=null,
@QuestionId int=null,
@Choice nvarchar(500)=null,
@IsRight tinyint=null,
@flag nvarchar(40)
As
begin
	if(@flag='Insert')
	begin
		if exists(select * from QuestionChoice where QuestionId=@QuestionId and Choice=@Choice)
		begin
			select 101
		end
		else
		begin
			insert into QuestionChoice (QuestionId,Choice,IsRight) values (@QuestionId,@Choice,@IsRight)
		end
	end
	if(@flag='Update')
	begin
		if exists(select * from QuestionChoice where QuestionId=@QuestionId and Choice=@Choice)
		begin
			select 101
		end
		else
		begin
			update QuestionChoice set QuestionId=@QuestionId,Choice=@Choice,IsRight=@IsRight where Id=@Id
		end
	end
	if(@flag='Get')
	begin
		select * from QuestionChoice where Id=@Id
	end
	if(@flag='Gets')
	begin
		select * from QuestionChoice
	end
end