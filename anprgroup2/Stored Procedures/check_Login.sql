USE [PNR] 
GO
/****** Object:  StoredProcedure [dbo].[check_login]    Script Date: 11/29/2010 14:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[check_login]
@Username varchar(30),@Password varchar(30)
as 
select *
from Login
where Username=@Username and Password=@Password