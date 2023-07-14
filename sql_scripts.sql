USE [master]
GO
/****** Object:  Database [PhoneDictionary]    Script Date: 10.07.2023 19:16:30 ******/
CREATE DATABASE [PhoneDictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhoneDictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PhoneDictionary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PhoneDictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PhoneDictionary_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PhoneDictionary] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhoneDictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhoneDictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhoneDictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhoneDictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhoneDictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhoneDictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhoneDictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhoneDictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhoneDictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhoneDictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhoneDictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhoneDictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhoneDictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhoneDictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhoneDictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhoneDictionary] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PhoneDictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhoneDictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhoneDictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhoneDictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhoneDictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhoneDictionary] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PhoneDictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhoneDictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [PhoneDictionary] SET  MULTI_USER 
GO
ALTER DATABASE [PhoneDictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhoneDictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhoneDictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhoneDictionary] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PhoneDictionary] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PhoneDictionary] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PhoneDictionary', N'ON'
GO
ALTER DATABASE [PhoneDictionary] SET QUERY_STORE = ON
GO
ALTER DATABASE [PhoneDictionary] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PhoneDictionary]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10.07.2023 19:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 10.07.2023 19:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InfoType] [int] NOT NULL,
	[Content] [nvarchar](100) NOT NULL,
	[PersonUUID] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 10.07.2023 19:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[UUID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[CompanyName] [nvarchar](500) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[UUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230709144348_InitialCreate', N'7.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230709144805_ColumnLenghtChange', N'7.0.8')
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 
GO
INSERT [dbo].[Contacts] ([Id], [InfoType], [Content], [PersonUUID], [CreatedDate], [UpdatedDate], [IsActive]) VALUES (1002, 1, N'05325320000', 1002, CAST(N'2023-07-10T17:47:51.2824751' AS DateTime2), NULL, 1)
GO
INSERT [dbo].[Contacts] ([Id], [InfoType], [Content], [PersonUUID], [CreatedDate], [UpdatedDate], [IsActive]) VALUES (1003, 3, N'ADANA', 1002, CAST(N'2023-07-10T17:49:19.1429797' AS DateTime2), NULL, 1)
GO
INSERT [dbo].[Contacts] ([Id], [InfoType], [Content], [PersonUUID], [CreatedDate], [UpdatedDate], [IsActive]) VALUES (1004, 1, N'5347009911', 1003, CAST(N'2023-07-10T17:50:07.8956123' AS DateTime2), NULL, 1)
GO
INSERT [dbo].[Contacts] ([Id], [InfoType], [Content], [PersonUUID], [CreatedDate], [UpdatedDate], [IsActive]) VALUES (1005, 3, N'BURSA', 1003, CAST(N'2023-07-10T17:50:16.2331623' AS DateTime2), NULL, 1)
GO
INSERT [dbo].[Contacts] ([Id], [InfoType], [Content], [PersonUUID], [CreatedDate], [UpdatedDate], [IsActive]) VALUES (1006, 3, N'BURSA', 1004, CAST(N'2023-07-10T17:50:44.9295040' AS DateTime2), NULL, 1)
GO
INSERT [dbo].[Contacts] ([Id], [InfoType], [Content], [PersonUUID], [CreatedDate], [UpdatedDate], [IsActive]) VALUES (1008, 1, N'532', 1004, CAST(N'2023-07-10T19:07:41.7693214' AS DateTime2), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 
GO
INSERT [dbo].[Person] ([UUID], [Name], [Surname], [CompanyName], [CreatedDate], [UpdatedDate], [IsActive]) VALUES (1002, N'İBRAHİM', N'ŞİMŞEK', N'ŞİMŞEK AŞ', CAST(N'2023-07-10T17:27:50.5182570' AS DateTime2), NULL, 1)
GO
INSERT [dbo].[Person] ([UUID], [Name], [Surname], [CompanyName], [CreatedDate], [UpdatedDate], [IsActive]) VALUES (1003, N'İlyas', N'Aruca', N'ARC', CAST(N'2023-07-10T17:49:35.1062040' AS DateTime2), NULL, 1)
GO
INSERT [dbo].[Person] ([UUID], [Name], [Surname], [CompanyName], [CreatedDate], [UpdatedDate], [IsActive]) VALUES (1004, N'BURAK', N'ÖNAL', N'ONAL AŞ', CAST(N'2023-07-10T17:50:33.8044432' AS DateTime2), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
/****** Object:  Index [IX_Contacts_PersonUUID]    Script Date: 10.07.2023 19:16:31 ******/
CREATE NONCLUSTERED INDEX [IX_Contacts_PersonUUID] ON [dbo].[Contacts]
(
	[PersonUUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_Person_PersonUUID] FOREIGN KEY([PersonUUID])
REFERENCES [dbo].[Person] ([UUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_Person_PersonUUID]
GO
USE [master]
GO
ALTER DATABASE [PhoneDictionary] SET  READ_WRITE 
GO
