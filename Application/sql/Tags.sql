Create Table Tags
(
Id int primary key identity,
TypeId int,
Type nvarchar(200),
TagId int,
foreign key (TagId) references Tag(Id)
)