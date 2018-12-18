create table UserInfo
(
Id int primary key identity,
Username nvarchar(100) unique,
Password nvarchar(100),
Role nvarchar(20)
);

create table Tag
(
Id int primary key,
Name nvarchar(100) unique,
CreatedDate date,
CreatedBy int,
foreign key (CreatedBy) references UserInfo(Id)
);

create table Job
(
Id int primary key identity,
Title nvarchar(500),
Description nvarchar(max),
TagId int,
CreatedDate date,
CreatedBy int,
foreign key (CreatedBy) references UserInfo(Id),
foreign key (TagId) references Tag(Id)
);

create table News
(
Id int primary key identity,
Title nvarchar(500),
Description nvarchar(max),
TagId int,
CreatedDate date,
CreatedBy int,
foreign key (CreatedBy) references UserInfo(Id),
foreign key (TagId) references Tag(Id)
);