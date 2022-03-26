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
