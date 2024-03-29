USE [Obmennik]
GO
/****** Object:  Table [dbo].[Buy]    Script Date: 02.02.2019 20:01:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buy](
	[IdCourse] [int] IDENTITY(1,1) NOT NULL,
	[EUR] [decimal](10, 2) NOT NULL,
	[USD] [decimal](10, 2) NOT NULL,
	[GBP] [decimal](10, 2) NOT NULL,
	[UAH] [decimal](10, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Buy] PRIMARY KEY CLUSTERED 
(
	[IdCourse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 02.02.2019 20:01:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[SurName] [nvarchar](max) NOT NULL,
	[Passport] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History]    Script Date: 02.02.2019 20:01:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[IdOperation] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[Operation] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[BuyRate] [decimal](10, 2) NOT NULL,
	[SellRate] [decimal](10, 2) NOT NULL,
	[Value2] [nvarchar](max) NOT NULL,
	[CountMoney] [decimal](10, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Obmen] PRIMARY KEY CLUSTERED 
(
	[IdOperation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sell]    Script Date: 02.02.2019 20:01:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sell](
	[IdCourse] [int] IDENTITY(1,1) NOT NULL,
	[EUR] [decimal](10, 2) NOT NULL,
	[USD] [decimal](10, 2) NOT NULL,
	[GBP] [decimal](10, 2) NOT NULL,
	[UAH] [decimal](10, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sell] PRIMARY KEY CLUSTERED 
(
	[IdCourse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Buy] ON 

INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (0, CAST(70.00 AS Decimal(10, 2)), CAST(60.00 AS Decimal(10, 2)), CAST(55.00 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)), CAST(N'2019-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (1, CAST(123.00 AS Decimal(10, 2)), CAST(123.00 AS Decimal(10, 2)), CAST(123.00 AS Decimal(10, 2)), CAST(123.00 AS Decimal(10, 2)), CAST(N'2019-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (2, CAST(7.00 AS Decimal(10, 2)), CAST(7.00 AS Decimal(10, 2)), CAST(7.00 AS Decimal(10, 2)), CAST(7.00 AS Decimal(10, 2)), CAST(N'2019-02-01T13:50:14.913' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (3, CAST(9.00 AS Decimal(10, 2)), CAST(7.00 AS Decimal(10, 2)), CAST(13.00 AS Decimal(10, 2)), CAST(11.00 AS Decimal(10, 2)), CAST(N'2019-02-01T13:55:11.453' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (4, CAST(15.00 AS Decimal(10, 2)), CAST(15.00 AS Decimal(10, 2)), CAST(16.00 AS Decimal(10, 2)), CAST(16.00 AS Decimal(10, 2)), CAST(N'2019-02-01T13:57:29.463' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (5, CAST(70.21 AS Decimal(10, 2)), CAST(60.21 AS Decimal(10, 2)), CAST(80.21 AS Decimal(10, 2)), CAST(50.21 AS Decimal(10, 2)), CAST(N'2019-02-01T13:59:27.470' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (6, CAST(71.21 AS Decimal(10, 2)), CAST(61.21 AS Decimal(10, 2)), CAST(81.21 AS Decimal(10, 2)), CAST(51.21 AS Decimal(10, 2)), CAST(N'2019-02-02T15:46:20.210' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (7, CAST(71.21 AS Decimal(10, 2)), CAST(61.21 AS Decimal(10, 2)), CAST(81.21 AS Decimal(10, 2)), CAST(51.21 AS Decimal(10, 2)), CAST(N'2019-02-02T15:51:40.467' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (8, CAST(71.21 AS Decimal(10, 2)), CAST(61.21 AS Decimal(10, 2)), CAST(81.21 AS Decimal(10, 2)), CAST(51.21 AS Decimal(10, 2)), CAST(N'2019-02-02T16:38:07.597' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (9, CAST(110.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), CAST(130.00 AS Decimal(10, 2)), CAST(120.00 AS Decimal(10, 2)), CAST(N'2019-02-02T16:38:50.107' AS DateTime))
INSERT [dbo].[Buy] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (10, CAST(200.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), CAST(250.00 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)), CAST(N'2019-02-02T17:42:23.510' AS DateTime))
SET IDENTITY_INSERT [dbo].[Buy] OFF
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [FirstName], [SurName], [Passport]) VALUES (11, N'Dmitriy', N'Shitov', N'4561897141')
INSERT [dbo].[Client] ([Id], [FirstName], [SurName], [Passport]) VALUES (12, N'Dmitriy', N'Shitov', N'4561897141')
INSERT [dbo].[Client] ([Id], [FirstName], [SurName], [Passport]) VALUES (13, N'Dmitriy', N'Shitov', N'4561897141')
INSERT [dbo].[Client] ([Id], [FirstName], [SurName], [Passport]) VALUES (14, N'Dmitriy', N'Shitov', N'4561897141')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[History] ON 

INSERT [dbo].[History] ([IdOperation], [IdClient], [Operation], [Value], [BuyRate], [SellRate], [Value2], [CountMoney], [Date]) VALUES (4, 11, N'Продажа', N'USD', CAST(150.00 AS Decimal(10, 2)), CAST(160.00 AS Decimal(10, 2)), N'RUB', CAST(15000.00 AS Decimal(10, 2)), CAST(N'2019-02-02T19:36:46.317' AS DateTime))
INSERT [dbo].[History] ([IdOperation], [IdClient], [Operation], [Value], [BuyRate], [SellRate], [Value2], [CountMoney], [Date]) VALUES (5, 12, N'Покупка', N'USD', CAST(150.00 AS Decimal(10, 2)), CAST(160.00 AS Decimal(10, 2)), N'RUB', CAST(2100.00 AS Decimal(10, 2)), CAST(N'2019-02-02T19:37:49.503' AS DateTime))
INSERT [dbo].[History] ([IdOperation], [IdClient], [Operation], [Value], [BuyRate], [SellRate], [Value2], [CountMoney], [Date]) VALUES (6, 13, N'Продажа', N'USD', CAST(150.00 AS Decimal(10, 2)), CAST(160.00 AS Decimal(10, 2)), N'RUB', CAST(5000.00 AS Decimal(10, 2)), CAST(N'2019-02-02T19:39:33.543' AS DateTime))
INSERT [dbo].[History] ([IdOperation], [IdClient], [Operation], [Value], [BuyRate], [SellRate], [Value2], [CountMoney], [Date]) VALUES (7, 14, N'Покупка', N'USD', CAST(150.00 AS Decimal(10, 2)), CAST(160.00 AS Decimal(10, 2)), N'RUB', CAST(4687.50 AS Decimal(10, 2)), CAST(N'2019-02-02T19:39:46.877' AS DateTime))
SET IDENTITY_INSERT [dbo].[History] OFF
SET IDENTITY_INSERT [dbo].[Sell] ON 

INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (0, CAST(75.00 AS Decimal(10, 2)), CAST(80.00 AS Decimal(10, 2)), CAST(90.00 AS Decimal(10, 2)), CAST(85.00 AS Decimal(10, 2)), CAST(N'2019-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (1, CAST(123.00 AS Decimal(10, 2)), CAST(123.00 AS Decimal(10, 2)), CAST(123.00 AS Decimal(10, 2)), CAST(123.00 AS Decimal(10, 2)), CAST(N'2019-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (2, CAST(7.00 AS Decimal(10, 2)), CAST(7.00 AS Decimal(10, 2)), CAST(7.00 AS Decimal(10, 2)), CAST(7.00 AS Decimal(10, 2)), CAST(N'2019-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (3, CAST(16.00 AS Decimal(10, 2)), CAST(14.00 AS Decimal(10, 2)), CAST(20.00 AS Decimal(10, 2)), CAST(18.00 AS Decimal(10, 2)), CAST(N'2019-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (4, CAST(17.00 AS Decimal(10, 2)), CAST(18.00 AS Decimal(10, 2)), CAST(12.00 AS Decimal(10, 2)), CAST(16.00 AS Decimal(10, 2)), CAST(N'2019-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (5, CAST(75.00 AS Decimal(10, 2)), CAST(65.00 AS Decimal(10, 2)), CAST(80.21 AS Decimal(10, 2)), CAST(55.21 AS Decimal(10, 2)), CAST(N'2019-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (6, CAST(76.00 AS Decimal(10, 2)), CAST(66.00 AS Decimal(10, 2)), CAST(81.21 AS Decimal(10, 2)), CAST(56.21 AS Decimal(10, 2)), CAST(N'2019-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (7, CAST(76.21 AS Decimal(10, 2)), CAST(66.21 AS Decimal(10, 2)), CAST(81.21 AS Decimal(10, 2)), CAST(56.21 AS Decimal(10, 2)), CAST(N'2019-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (8, CAST(76.21 AS Decimal(10, 2)), CAST(66.21 AS Decimal(10, 2)), CAST(81.21 AS Decimal(10, 2)), CAST(56.21 AS Decimal(10, 2)), CAST(N'2019-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (9, CAST(150.00 AS Decimal(10, 2)), CAST(140.00 AS Decimal(10, 2)), CAST(170.00 AS Decimal(10, 2)), CAST(160.00 AS Decimal(10, 2)), CAST(N'2019-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Sell] ([IdCourse], [EUR], [USD], [GBP], [UAH], [Date]) VALUES (10, CAST(210.00 AS Decimal(10, 2)), CAST(160.00 AS Decimal(10, 2)), CAST(260.00 AS Decimal(10, 2)), CAST(60.00 AS Decimal(10, 2)), CAST(N'2019-02-02T17:42:23.510' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sell] OFF
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Client1] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Client1]
GO
