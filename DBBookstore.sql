create database BookStore

create Table UserRegister(
UserId int primary key identity(1,1),
FullName varchar(10),
EmailId varchar(25),
PhNo varchar(20),
Password varchar(20))

select * from UserRegister

select * from Book
select * from Cart

create Table Book
(
BookId int primary key identity(1,1),
BookName varchar(50),
AuthorName varchar(50),
DiscountPrice money,
OriginalPrice money,
BookDescription varchar(50),
Image varchar(50),
Rating float ,
Reviewer int,
BookCount int
)

create table Cart(
CartId int primary key identity(1,1),
Quantity int,
userId int Foreign Key References UserRegister(UserId),
BookId int Foreign Key References Book(BookId))

create table WishList
(
	WishlistId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL
	FOREIGN KEY (UserId) REFERENCES UserRegister(UserId),
	BookId INT NOT NULL
	FOREIGN KEY (BookId) REFERENCES Book(BookId)	
);

select * from WishList


create table AddressType
(
	TypeId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Type varchar(20)
);
INSERT INTO AddressType (Type) VALUES ('Home')
INSERT INTO AddressType (Type) VALUES ('Work')
INSERT INTO AddressType (Type) VALUES ('Other')


select * from AddressType
select * from Address


create table Address
(
    AddressId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL
	FOREIGN KEY (UserId) REFERENCES UserRegister(UserId),
	Address varchar(max) not null,
	City varchar(100),
	State varchar(100),
	TypeId int
	FOREIGN KEY (TypeId) REFERENCES AddressType(TypeId)
);

create table BooksOrder(
OrderId int primary key identity(1,1),
TotalPrice Money,
BookQuantity int,
OrderDate Date,
userId int Foreign Key References UserRegister(userId),
BookId int Foreign Key References Book(BookId),
AddressId int Foreign Key References Address(AddressId)
)

create table BooksOrder(
OrderId int primary key identity(1,1),
TotalPrice Money,
BookQuantity int,
OrderDate Date,
UserId int Foreign Key References UserRegister(UserId),
BookId int Foreign Key References Book(BookId),
AddressId int Foreign Key References Address(AddressId)
)

select * from BooksOrder

create Table FeedBackBook(
FeedbackId int not null identity (1,1) primary key,
FeedBackFromUserName varchar(15),
Comments varchar(50),
Ratings int,
UserId int Foreign Key References UserRegister(UserId),
BookId int Foreign Key References Book(BookId))

drop table FeedBackBook

select * from FeedBackBook