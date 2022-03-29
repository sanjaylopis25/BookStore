create procedure sp_UserRegister
@FullName varchar(10),
@EmailId varchar(25),
@PhNo varchar(20),
@Password varchar(20)
As
Begin
Insert into UserRegister (FullName,EmailId,PhNo,Password) values (@FullName,@EmailId,@PhNo,@Password)
End

create procedure sp_LoginUser
@EmailId varchar(25),
@Password varchar(20)
As
Begin
select EmailId,Password from UserRegister where EmailId=@EmailId AND Password=@Password
End

create procedure sp_UserLogin
@EmailId varchar(25),
@Password varchar(20)
As
Begin
Declare @Count int
select @Count = count (EmailId) from UserRegister where EmailId=@EmailId AND Password=@Password
if(@Count =1)
	Begin
		Select 1 as ReturnCode
	End
	Else
	Begin
		Select -1 as ReturnCode
	End
End



create procedure sp_ForgetPassword
@EmailId varchar(25)
As
Begin
select EmailId from UserRegister where EmailId=@EmailId 
End


alter procedure sp_ForgetPassword

(
@EmailId varchar(50)
)

as
begin try
     update UserRegister set Password=null where EmailId=@EmailId
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch

select * from UserRegister
select * from Book

create procedure sp_ResetPassword

@EmailId varchar(25),
@Password varchar(10)
As
Begin
update UserRegister set Password=@Password where EmailId=@EmailId
End

create procedure sp_AddingBooks
 @BookName varchar(50),
 @AuthorName varchar(50),
 @DiscountPrice money,
  @OriginalPrice money,
  @BookDescription varchar(50),
  @Rating float,
  @Image varchar(50),
  @Reviewer int,
  @BookCount int
  As 
  Begin
  Insert into Book (BookName,AuthorName,DiscountPrice,OriginalPrice,BookDescription,
  Rating,Image,Reviewer,BookCount) values (@BookName,@AuthorName,@DiscountPrice,@OriginalPrice,@BookDescription,
  @Rating,@Image,@Reviewer,@BookCount)
  End

  create procedure sp_UpdateBooks
 @BookId int,
 @BookName varchar(50),
 @AuthorName varchar(50),
 @DiscountPrice money,
  @OriginalPrice money,
  @BookDescription varchar(50),
  @Rating float,
   @Image varchar(50),
  @Reviewer int,
  @BookCount int
  As 
  Begin
  update Book set BookName=@BookName,AuthorName=@AuthorName,DiscountPrice=@DiscountPrice,
  OriginalPrice=@OriginalPrice,BookDescription=@BookDescription,Rating=@Rating,Reviewer=@Reviewer,
  BookCount=@BookCount,Image=@Image where BookId=@BookId
  End

  create procedure sp_DeleteBooks
  @BookId int
  As
  Begin
  delete Book where BookId=@BookId
  End

  create procedure sp_GetAllBooks
  As
  Begin
  select * from Book
  End

  create procedure sp_GetAllBookById
  @BookId int
  As
  Begin
  select * from Book where BookId=@BookId
  End



create procedure sp_AddBooktoCart
@Quantity int,
@userId int,
@BookId int
As
Begin
Insert into Cart (Quantity,userId,BookId) values (@Quantity,@userId,@BookId)
End


create procedure sp_DeleteCart
@CartId int
As
Begin 
Delete Cart where CartId=@CartId
End


create procedure sp_UpdateCart
@Quantity int,
@CartId int
As
Begin
update Cart set Quantity=@Quantity
where CartId=@CartId
End


create procedure sp_GetAllBooksinCart
@userId int
As
Begin
select Cart.CartId,Cart.userId,Cart.BookId,Cart.Quantity , Book.BookName,Book.AuthorName,
Book.BookDescription,Book.DiscountPrice,Book.OriginalPrice,Book.Rating,Book.Reviewer,
Book.Image,Book.BookCount from Cart inner join Book on Cart.BookId=Book.BookId
where Cart.userId=@userId
End

create PROCEDURE sp_CreateWishlist
	@UserId INT,
	@BookId INT
AS
BEGIN 
	IF EXISTS(SELECT * FROM WishList WHERE BookId = @BookId AND UserId = @UserId)
		SELECT 1;
	ELSE
	BEGIN
		IF EXISTS(SELECT * FROM Book WHERE BookId = @BookId)
		BEGIN
			INSERT INTO WishList(UserId,BookId)
			VALUES ( @UserId,@BookId)
		END
		ELSE
			SELECT 2;
	END
END


CREATE PROCEDURE sp_DeleteWishlist
	@WishlistId INT
AS
BEGIN
		DELETE FROM Wishlist WHERE WishlistId = @WishlistId
END

CREATE PROCEDURE sp_GetWishListbyUserId
  @UserId int
AS
BEGIN
	   select 
		Book.BookId,
		Book.BookName,
		Book.AuthorName,
		Book.DiscountPrice,
		Book.OriginalPrice,
		Book.BookDescription,
		Book.Image,
		Book.Rating,
		Book.Reviewer,
		Book.BookCount,
		WishList.WishlistId,
		WishList.UserId,
		WishList.BookId
		FROM Book
		inner join WishList
		on Wishlist.BookId=Book.BookId where WishList.UserId=@UserId
End


create procedure Sp_AddAddress(
		@UserId int,
        @Address varchar(600),
		@City varchar(50),
		@State varchar(50),
		@TypeId int	)		
As 
Begin
	IF (EXISTS(SELECT * FROM UserRegister WHERE @UserId = @UserId))
	Begin
	Insert into Address (UserId,Address,City,State,TypeId )
		values (@UserId,@Address,@City,@State,@TypeId);
	End
	Else
	Begin
		Select 1
	End
End

CREATE PROCEDURE sp_DeleteAddress
	@AddressId int
AS
BEGIN
		DELETE FROM Address WHERE AddressId=@AddressId
END

create PROCEDURE sp_UpdateAddress
(
@AddressId int,
@Address varchar(max),
@City varchar(100),
@State varchar(100),
@TypeId int	)

AS
BEGIN
       If (exists(Select * from Address where AddressId=@AddressId))
		begin
			UPDATE Address
			SET 
			Address= @Address, 
			City = @City,
			State=@State,
			TypeId=@TypeId 
				WHERE AddressId=@AddressID;
		 end
		 else
		 begin
		 select 1;
		 end
END 




create PROCEDURE sp_GetAllAddresses
AS
BEGIN
	 begin
	   SELECT * FROM Address ;
   	 end
End





create PROCEDURE sp_GetAddressbyUserid
  (
  @UserId int
  )
AS
BEGIN
	   SELECT * FROM Address WHERE UserId=@UserId;
END