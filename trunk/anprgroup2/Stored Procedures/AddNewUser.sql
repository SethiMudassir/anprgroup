USE [PNR]
GO
/****** Object:  StoredProcedure [dbo].[ins_user]    Script Date: 12/01/2010 12:02:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[ins_user]
@FullName nvarchar(50),
@Username nvarchar(50),
@Role int,
@Sex nvarchar(10),
@Address nvarchar(50),
@Phone nvarchar(50),
@Birthday date,
@Email nvarchar(50),
@IDNumber nvarchar(50),
@Password nvarchar(50)
as
insert Login(Username,Password) values (@Username,@Password)
insert Staff(Full_Name,Username,Role,Sex,Address,Phone,Birthday,Email,IDNumber) values (@FullName,@Username,@Role,@Sex,@Address,@Phone,@Birthday,@Email,@IDNumber)
