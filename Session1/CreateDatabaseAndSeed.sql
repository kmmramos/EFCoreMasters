USE [master]
GO

IF DB_ID('EFCoreMastersDB.Session01') IS NOT NULL
   RETURN

-- Create Database
CREATE DATABASE [EFCoreMastersDB.Session01]
GO

USE [EFCoreMastersDB.Session01]
GO
GO

/****** Object:  Table [dbo].[Products]    Script Date: 11/9/2022 2:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ShopId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Reviews]    Script Date: 11/9/2022 1:58:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ReviewerName] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[NumberOfStars] [tinyint] NOT NULL,
	CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Shops]    Script Date: 11/9/2022 2:09:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Tags]    Script Date: 11/9/2022 2:12:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Insert Scripts ******/

SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Name], [ShopId]) VALUES (1, N'Dell Laptop', 1)
GO
INSERT [dbo].[Products] ([Id], [Name], [ShopId]) VALUES (2, N'Apple Mouse', 1)
GO
INSERT [dbo].[Products] ([Id], [Name], [ShopId]) VALUES (3, N'IPhone 13', 2)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO

SET IDENTITY_INSERT [dbo].[Reviews] ON 
GO
INSERT [dbo].[Reviews] ([Id], [ProductId], [ReviewerName], [Comment], [NumberOfStars]) 
	VALUES (1, 1, N'Reviewer One', 'Laptop easily heats up pretty quickly', 3)
GO
INSERT [dbo].[Reviews] ([Id], [ProductId], [ReviewerName], [Comment], [NumberOfStars]) 
	VALUES (2, 2, N'Reviewer Two', 'Mouse is too heavy!', 1)
GO
INSERT [dbo].[Reviews] ([Id], [ProductId], [ReviewerName], [Comment], [NumberOfStars]) 
	VALUES (3, 3, N'Reviewer Three', 'Phone has high quality images.', 4)
GO
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO

SET IDENTITY_INSERT [dbo].[Shops] ON 
GO
INSERT [dbo].[Shops] ([Id], [Name]) 
	VALUES (1, N'Technology Hub Store')
GO
INSERT [dbo].[Shops] ([Id], [Name]) 
	VALUES (2, N'Sales Tech')
GO
SET IDENTITY_INSERT [dbo].[Shops] OFF
GO

SET IDENTITY_INSERT [dbo].[Tags] ON 
GO
INSERT [dbo].[Tags] ([Id], [Name]) 
	VALUES (1, N'Tag 1')
GO
INSERT [dbo].[Tags] ([Id], [Name]) 
	VALUES (2, N'Tag 2')
GO
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO

/*** Foreign Keys ***/
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Shops_ShopId] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shops] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Shops_ShopId]
GO

GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Products_ProductId]
GO