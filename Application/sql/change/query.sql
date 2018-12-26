create table QuizeCategory
(
Id int primary key identity,
Name nvarchar(500) ,
);

create table QuizeType
(
Id int primary key identity,
Name nvarchar(1000),
CategoryId int,
foreign key (CategoryId) references QuizeCategory(Id)
);

create table Question
(
Id int primary key identity,
Name nvarchar(max),
IsActive tinyint default 1,
QuizeTypeId int,
foreign key (QuizeTypeId) references QuizeType(Id)
);

Create Table QuestionChoices
(
Id int primary key identity,
QuestionId int,
Choice nvarchar(500),
IsRight tinyint default 0,
foreign key (QuestionId) references Question(Id)
);