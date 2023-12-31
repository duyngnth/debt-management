USE [master]
GO
/****** Object:  Database [DebtManagement]    Script Date: 03/11/2023 02:42:12 ******/
CREATE DATABASE [DebtManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DebtManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DebtManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DebtManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DebtManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DebtManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DebtManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DebtManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DebtManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DebtManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DebtManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DebtManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [DebtManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DebtManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DebtManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DebtManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DebtManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DebtManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DebtManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DebtManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DebtManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DebtManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DebtManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DebtManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DebtManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DebtManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DebtManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DebtManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DebtManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DebtManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [DebtManagement] SET  MULTI_USER 
GO
ALTER DATABASE [DebtManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DebtManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DebtManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DebtManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DebtManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DebtManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DebtManagement', N'ON'
GO
ALTER DATABASE [DebtManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [DebtManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DebtManagement]
GO
/****** Object:  Table [dbo].[Debit]    Script Date: 03/11/2023 02:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Debit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[creditorId] [int] NULL,
	[debtorName] [nvarchar](50) NOT NULL,
	[debtorPhone] [varchar](20) NULL,
	[description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DebitDetail]    Script Date: 03/11/2023 02:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DebitDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[debitId] [int] NULL,
	[amount] [money] NOT NULL,
	[isPaid] [bit] NOT NULL,
	[date] [datetime] NOT NULL,
	[deadline] [datetime] NULL,
	[description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/11/2023 02:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[displayName] [nvarchar](50) NOT NULL,
	[type] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Debit] ON 

INSERT [dbo].[Debit] ([id], [creditorId], [debtorName], [debtorPhone], [description]) VALUES (1, 1, N'Nguyễn Trung Vũ', N'0984373737', N'Uy tín')
INSERT [dbo].[Debit] ([id], [creditorId], [debtorName], [debtorPhone], [description]) VALUES (3, 1, N'Minh bé', N'0982888990', N'Chuyên trả chậm, kì kèo')
INSERT [dbo].[Debit] ([id], [creditorId], [debtorName], [debtorPhone], [description]) VALUES (6, 1, N'Huy Quân', N'0942469798', N'Có tiền sử nợ xấu')
SET IDENTITY_INSERT [dbo].[Debit] OFF
GO
SET IDENTITY_INSERT [dbo].[DebitDetail] ON 

INSERT [dbo].[DebitDetail] ([id], [debitId], [amount], [isPaid], [date], [deadline], [description]) VALUES (2, 1, 400000.0000, 0, CAST(N'2023-10-23T00:00:00.000' AS DateTime), CAST(N'2023-10-30T00:00:00.000' AS DateTime), N'Trả nhiều lần')
INSERT [dbo].[DebitDetail] ([id], [debitId], [amount], [isPaid], [date], [deadline], [description]) VALUES (3, 1, 200000.0000, 1, CAST(N'2023-10-26T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[DebitDetail] ([id], [debitId], [amount], [isPaid], [date], [deadline], [description]) VALUES (4, 1, 100000.0000, 1, CAST(N'2023-10-28T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[DebitDetail] ([id], [debitId], [amount], [isPaid], [date], [deadline], [description]) VALUES (6, 3, 2000000.0000, 0, CAST(N'2023-10-25T00:00:00.000' AS DateTime), CAST(N'2023-12-25T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[DebitDetail] ([id], [debitId], [amount], [isPaid], [date], [deadline], [description]) VALUES (12, 6, 50000.0000, 0, CAST(N'2023-10-31T02:13:00.000' AS DateTime), NULL, N'Tiền đổ xăng')
SET IDENTITY_INSERT [dbo].[DebitDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [email], [password], [displayName], [type]) VALUES (1, N'duynt@gmail.com', N'12345678', N'Nguyễn Thế Duy', 2)
INSERT [dbo].[User] ([id], [email], [password], [displayName], [type]) VALUES (2, N'vunt@gmail.com', N'12345678', N'Nguyễn Trung Vũ', 2)
INSERT [dbo].[User] ([id], [email], [password], [displayName], [type]) VALUES (3, N'admin@gmail.com', N'admin123', N'Admin', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((2)) FOR [type]
GO
ALTER TABLE [dbo].[Debit]  WITH CHECK ADD FOREIGN KEY([creditorId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[DebitDetail]  WITH CHECK ADD  CONSTRAINT [FK__DebitDeta__debit__3C69FB99] FOREIGN KEY([debitId])
REFERENCES [dbo].[Debit] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DebitDetail] CHECK CONSTRAINT [FK__DebitDeta__debit__3C69FB99]
GO
USE [master]
GO
ALTER DATABASE [DebtManagement] SET  READ_WRITE 
GO
