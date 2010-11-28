USE [master]
GO
/****** Object:  Database [PNR]    Script Date: 11/28/2010 15:47:26 ******/
CREATE DATABASE [PNR] ON  PRIMARY 
( NAME = N'PNR', FILENAME = N'D:\PNR.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PNR_log', FILENAME = N'D:\PNR_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PNR] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PNR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PNR] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [PNR] SET ANSI_NULLS OFF
GO
ALTER DATABASE [PNR] SET ANSI_PADDING OFF
GO
ALTER DATABASE [PNR] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [PNR] SET ARITHABORT OFF
GO
ALTER DATABASE [PNR] SET AUTO_CLOSE ON
GO
ALTER DATABASE [PNR] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [PNR] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [PNR] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [PNR] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [PNR] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [PNR] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [PNR] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [PNR] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [PNR] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [PNR] SET  DISABLE_BROKER
GO
ALTER DATABASE [PNR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [PNR] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [PNR] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [PNR] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [PNR] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [PNR] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [PNR] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [PNR] SET  READ_WRITE
GO
ALTER DATABASE [PNR] SET RECOVERY SIMPLE
GO
ALTER DATABASE [PNR] SET  MULTI_USER
GO
ALTER DATABASE [PNR] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [PNR] SET DB_CHAINING OFF
GO
USE [PNR]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 11/28/2010 15:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Login] ([Username], [Password]) VALUES (N'admin', N'admin')
INSERT [dbo].[Login] ([Username], [Password]) VALUES (N'dongnt', N'dongnt')
INSERT [dbo].[Login] ([Username], [Password]) VALUES (N'ngocqt', N'ngocqt')
INSERT [dbo].[Login] ([Username], [Password]) VALUES (N'trinhdtn', N'trinhdtn')
INSERT [dbo].[Login] ([Username], [Password]) VALUES (N'truonghx', N'truonghx')
/****** Object:  Table [dbo].[TicketType]    Script Date: 11/28/2010 15:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketType](
	[IDTicket] [int] NOT NULL,
	[TicketType] [nvarchar](50) NULL,
 CONSTRAINT [PK_TicketType] PRIMARY KEY CLUSTERED 
(
	[IDTicket] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TicketType] ([IDTicket], [TicketType]) VALUES (0, N'Regular Ticket')
INSERT [dbo].[TicketType] ([IDTicket], [TicketType]) VALUES (1, N'Monthly Ticket')
/****** Object:  Table [dbo].[V_detail]    Script Date: 11/28/2010 15:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[V_detail](
	[V_Ticket] [char](10) NOT NULL,
	[V_No] [nvarchar](20) NOT NULL,
	[In_Time] [datetime] NOT NULL,
	[Out_Time] [datetime] NOT NULL,
	[V_Image] [image] NULL,
	[Ticket_Type] [int] NULL,
	[Username] [nvarchar](50) NULL,
 CONSTRAINT [PK_V_Information] PRIMARY KEY CLUSTERED 
(
	[V_Ticket] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[V_detail] ([V_Ticket], [V_No], [In_Time], [Out_Time], [V_Image], [Ticket_Type], [Username]) VALUES (N'0001      ', N'30K9-2233', CAST(0x00009E3C00D94130 AS DateTime), CAST(0x00009E3C0128A180 AS DateTime), NULL, 1, N'trinhdtn')
INSERT [dbo].[V_detail] ([V_Ticket], [V_No], [In_Time], [Out_Time], [V_Image], [Ticket_Type], [Username]) VALUES (N'0002      ', N'30K9-0909', CAST(0x00009E3C00A7D0F0 AS DateTime), CAST(0x00009E3C011826C0 AS DateTime), NULL, 1, N'trinhdtn')
INSERT [dbo].[V_detail] ([V_Ticket], [V_No], [In_Time], [Out_Time], [V_Image], [Ticket_Type], [Username]) VALUES (N'0003      ', N'30H1- 1282', CAST(0x00009E3C01499700 AS DateTime), CAST(0x00009E3D012B1A50 AS DateTime), NULL, 0, N'ngocqt')
INSERT [dbo].[V_detail] ([V_Ticket], [V_No], [In_Time], [Out_Time], [V_Image], [Ticket_Type], [Username]) VALUES (N'0004      ', N'29Y7-5060', CAST(0x00009E3E0151D460 AS DateTime), CAST(0x00009E3E016D91F0 AS DateTime), NULL, 0, N'ngocqt')
INSERT [dbo].[V_detail] ([V_Ticket], [V_No], [In_Time], [Out_Time], [V_Image], [Ticket_Type], [Username]) VALUES (N'0005      ', N'29Y9-2121', CAST(0x00009E3E0149DD50 AS DateTime), CAST(0x00009E3E017D8010 AS DateTime), NULL, 1, N'truonghx')
/****** Object:  Table [dbo].[Staff]    Script Date: 11/28/2010 15:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[Full_Name] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Role] [int] NULL,
	[Sex] [char](10) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [char](10) NULL,
	[Birthday] [date] NULL,
	[Email] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Staff] ([Full_Name], [Username], [Role], [Sex], [Address], [Phone], [Birthday], [Email]) VALUES (N'Nguyen Thanh Dong', N'dongnt', NULL, N'Male      ', N'140 Le Van Hien', N'934723272 ', CAST(0x5B950A00 AS Date), N'Dongnt146@gmail.com')
INSERT [dbo].[Staff] ([Full_Name], [Username], [Role], [Sex], [Address], [Phone], [Birthday], [Email]) VALUES (N'Ho Xuan Truong', N'truonghx', NULL, N'Male      ', N'18, Hoang Hoa Tham', N'912424244 ', CAST(0x5F0B0B00 AS Date), N'truonghx@gmail.com')
INSERT [dbo].[Staff] ([Full_Name], [Username], [Role], [Sex], [Address], [Phone], [Birthday], [Email]) VALUES (N'Quan Thi Ngoc', N'ngocqt', NULL, N'Female    ', N'19, My Dinh, Ha Noi', N'1696934254', CAST(0xB5110B00 AS Date), N'ngocqt@gmail.com')
INSERT [dbo].[Staff] ([Full_Name], [Username], [Role], [Sex], [Address], [Phone], [Birthday], [Email]) VALUES (N'Doan Thi Nu Trinh', N'trinhdtn', NULL, N'Female    ', NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[Mothly_Ticket]    Script Date: 11/28/2010 15:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mothly_Ticket](
	[IDCard] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[V_No1] [nvarchar](20) NULL,
	[V_No2] [nvarchar](20) NULL,
	[Start_Date] [datetime] NULL,
	[Expire_Date] [datetime] NULL,
	[Picture] [image] NULL,
	[UserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mothly_Ticket] PRIMARY KEY CLUSTERED 
(
	[IDCard] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Mothly_Ticket] ON
INSERT [dbo].[Mothly_Ticket] ([IDCard], [CustomerName], [Address], [V_No1], [V_No2], [Start_Date], [Expire_Date], [Picture], [UserName]) VALUES (1, N'Ho Xuan Truong', N'Hoang Hoa THam', N'43H1-0956', N'43H2-0987', CAST(0x00009DA000000000 AS DateTime), CAST(0x00009DBE00000000 AS DateTime), NULL, N'dongnt')
INSERT [dbo].[Mothly_Ticket] ([IDCard], [CustomerName], [Address], [V_No1], [V_No2], [Start_Date], [Expire_Date], [Picture], [UserName]) VALUES (2, N'Doan Thi Nu Trinh', N'Nguyen Dang Ninh', N'29H3-0987', N'29S1-0587', CAST(0x00009D9D00000000 AS DateTime), CAST(0x00009DBB00000000 AS DateTime), NULL, N'dongnt')
INSERT [dbo].[Mothly_Ticket] ([IDCard], [CustomerName], [Address], [V_No1], [V_No2], [Start_Date], [Expire_Date], [Picture], [UserName]) VALUES (3, N'Nguyen Thanh Dong', N'Nguyen Khanh Toan, Ha Noi', N'30K9-0785', N'30K9-0785', CAST(0x00009DE400000000 AS DateTime), CAST(0x00009E0200000000 AS DateTime), NULL, NULL)
INSERT [dbo].[Mothly_Ticket] ([IDCard], [CustomerName], [Address], [V_No1], [V_No2], [Start_Date], [Expire_Date], [Picture], [UserName]) VALUES (4, N'Quan Thi Ngoc', N'My Dinh, Ha Noi', N'30Y9-2987', N'30K1-2878', CAST(0x00009E2100000000 AS DateTime), CAST(0x00009E3F00000000 AS DateTime), NULL, NULL)
INSERT [dbo].[Mothly_Ticket] ([IDCard], [CustomerName], [Address], [V_No1], [V_No2], [Start_Date], [Expire_Date], [Picture], [UserName]) VALUES (5, N'Doan Thu Thuy', N'34, Le Trong Tan, Ha Noi', N'30H4- 6268', N'30H1-3121', CAST(0x00009E2100000000 AS DateTime), CAST(0x00009E3F00000000 AS DateTime), NULL, NULL)
INSERT [dbo].[Mothly_Ticket] ([IDCard], [CustomerName], [Address], [V_No1], [V_No2], [Start_Date], [Expire_Date], [Picture], [UserName]) VALUES (6, N'Quan Ngoc Hoa', N' Van Dinh, Ha Noi', N'29Z9-2313', N'30H4-0909', CAST(0x00009E2100000000 AS DateTime), CAST(0x00009E3F00000000 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Mothly_Ticket] OFF
/****** Object:  Table [dbo].[Finance]    Script Date: 11/28/2010 15:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Finance](
	[BillNo] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
	[Revenue] [float] NULL,
	[V_Total] [int] NULL,
 CONSTRAINT [PK_finance] PRIMARY KEY CLUSTERED 
(
	[BillNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_V_detail_TicketType]    Script Date: 11/28/2010 15:47:29 ******/
ALTER TABLE [dbo].[V_detail]  WITH CHECK ADD  CONSTRAINT [FK_V_detail_TicketType] FOREIGN KEY([Ticket_Type])
REFERENCES [dbo].[TicketType] ([IDTicket])
GO
ALTER TABLE [dbo].[V_detail] CHECK CONSTRAINT [FK_V_detail_TicketType]
GO
/****** Object:  ForeignKey [FK_V_Information_Login]    Script Date: 11/28/2010 15:47:29 ******/
ALTER TABLE [dbo].[V_detail]  WITH CHECK ADD  CONSTRAINT [FK_V_Information_Login] FOREIGN KEY([Username])
REFERENCES [dbo].[Login] ([Username])
GO
ALTER TABLE [dbo].[V_detail] CHECK CONSTRAINT [FK_V_Information_Login]
GO
/****** Object:  ForeignKey [FK_Staff_Login]    Script Date: 11/28/2010 15:47:29 ******/
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Login] FOREIGN KEY([Username])
REFERENCES [dbo].[Login] ([Username])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Login]
GO
/****** Object:  ForeignKey [FK_Mothly_Ticket_Login]    Script Date: 11/28/2010 15:47:29 ******/
ALTER TABLE [dbo].[Mothly_Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Mothly_Ticket_Login] FOREIGN KEY([UserName])
REFERENCES [dbo].[Login] ([Username])
GO
ALTER TABLE [dbo].[Mothly_Ticket] CHECK CONSTRAINT [FK_Mothly_Ticket_Login]
GO
/****** Object:  ForeignKey [FK_finance_Login]    Script Date: 11/28/2010 15:47:29 ******/
ALTER TABLE [dbo].[Finance]  WITH CHECK ADD  CONSTRAINT [FK_finance_Login] FOREIGN KEY([Username])
REFERENCES [dbo].[Login] ([Username])
GO
ALTER TABLE [dbo].[Finance] CHECK CONSTRAINT [FK_finance_Login]
GO
