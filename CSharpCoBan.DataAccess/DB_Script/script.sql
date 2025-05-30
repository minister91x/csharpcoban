USE [BE_092024]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/7/2025 9:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](250) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/7/2025 9:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] NULL,
	[ProductName] [nvarchar](50) NULL,
	[CategoryID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/7/2025 9:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] NULL,
	[UserName] [nvarchar](250) NULL,
	[PassWord] [nvarchar](250) NULL,
	[IsAdmin] [int] NULL,
	[TokenExprired] [datetime] NULL,
	[RefeshToken] [nvarchar](250) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (1, N'Đồ gia dụng')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (2, N'Nội Thất')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (3, N'Đồ điện')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (4, N'Đồ test')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryID]) VALUES (1, N'Laptop Dell', 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryID]) VALUES (2, N'Iphone 17 ProMax', 2)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryID]) VALUES (3, N'Test', 10)
GO
INSERT [dbo].[User] ([UserID], [UserName], [PassWord], [IsAdmin], [TokenExprired], [RefeshToken]) VALUES (1, N'admin', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 1, CAST(N'2025-01-25T20:45:47.910' AS DateTime), N'H/S9LnhdG2XdZszuiWcGoFgQxsDxmgnJ2VxOVvEroDKL9qSMYQQjcgUzu+oBgpz75XBg71FtZRmSqcNanru9Cg==')
GO
/****** Object:  StoredProcedure [dbo].[SP_Product_GetAll]    Script Date: 2/7/2025 9:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Product_GetAll]
 @ProductID INT
  as
  BEGIN
  SELECT p.ProductId, p.ProductName, c.[CategoryID], c.[CategoryName] 
  FROM [dbo].[Product] p
  inner join [dbo].[Category] c on p.[CategoryID]=c.[CategoryID]
  WHERE p.ProductId = @ProductID
  ORDER BY ProductId DESC
  END
GO
/****** Object:  StoredProcedure [dbo].[SP_Product_GetList]    Script Date: 2/7/2025 9:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Product_GetList]
@ProductName NVARCHAR(50)
AS
BEGIN
SELECT * FROM [dbo].[Product]
WHERE (ISNULL(@ProductName,'')='' OR [ProductName] LIKE '%'+@ProductName+'%')
END
GO
