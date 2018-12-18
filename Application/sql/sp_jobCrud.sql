create procedure sp_jobCRUD
@Id int=null,
@Title nvarchar(500)=null,
@Description nvarchar(max)=null,
@TagId int=null,
@CreatedDate date=null,
@CreatedBy int=null,
@ApplyStartDate date=null,
@ApplyEndDate date=null,
@Fees decimal(7,2)=null,
@ExamDate date=null,
@flag nvarchar(40)
As
begin
	if(@flag='Insert')
	begin
		if exists(select * from Job where Title=@Title and ExamDate=@ExamDate)
		begin
			select 101
		end
		else
		begin
			insert into Job
			(
			Title,
			Description,
			TagId,
			CreatedDate,
			CreatedBy,
			ApplyStartDate,
			ApplyEndDate,
			Fees,
			ExamDate
			)
			values
			(
			@Title,
			@Description,
			@TagId,
			@CreatedDate,
			@CreatedBy,
			@ApplyStartDate,
			@ApplyEndDate,
			@Fees,
			@ExamDate
			)
		end
	end
	if(@flag='Update')
	begin
		if exists(select * from Job where Title=@Title and ExamDate=@ExamDate)
		begin
			select 101
		end
		else
		begin
			update Job
			set 
			Title=@Title,
			Description=@Description,
			TagId=@TagId,
			CreatedDate=@CreatedDate,
			CreatedBy=@CreatedBy,
			ApplyStartDate=@ApplyStartDate,
			ApplyEndDate=@ApplyEndDate,
			Fees=@Fees,
			ExamDate=@ExamDate
			
		end
	end
	if(@flag='Delete')
	begin
		if exists(select * from Job where Id=@Id)
		begin
			delete Job where Id=@Id
		end
	end
	if(@flag='Gets')
	begin
		select * from Job
	end
	if(@flag='Get')
	begin
		select * from Job where Id=@Id
	end
	
end