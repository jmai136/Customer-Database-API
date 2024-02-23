USE [master]
GO
/****** Object:  Database [CustomerDatabase]    Script Date: 2/23/2024 10:29:53 AM ******/
CREATE DATABASE [CustomerDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CustomerDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CustomerDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CustomerDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CustomerDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomerDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomerDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CustomerDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CustomerDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CustomerDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CustomerDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [CustomerDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CustomerDatabase]
GO
/****** Object:  Schema [CustomerDatabase]    Script Date: 2/23/2024 10:29:53 AM ******/
CREATE SCHEMA [CustomerDatabase]
GO
/****** Object:  Table [CustomerDatabase].[Address]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[AddressLineOne] [nvarchar](100) NOT NULL,
	[AddressLineTwo] [nvarchar](100) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[AddressType] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[Call]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[Call](
	[CallID] [int] NOT NULL,
	[CallNotesID] [int] NULL,
	[CallDurationStartDateTime] [datetime2](7) NOT NULL,
	[CallDurationEndDateTime] [datetime2](7) NOT NULL,
	[CustomerID] [int] NULL,
	[CustomerSupportRepresentativeID] [int] NULL,
 CONSTRAINT [PK_Call] PRIMARY KEY CLUSTERED 
(
	[CallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[CallNotes]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[CallNotes](
	[CallNotesID] [int] IDENTITY(1,1) NOT NULL,
	[CallNotesDescription] [nvarchar](max) NULL,
	[IsResolved] [tinyint] NOT NULL,
	[CallReasonType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CallNotes] PRIMARY KEY CLUSTERED 
(
	[CallNotesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[Company]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[CompanyDescription] [nvarchar](max) NOT NULL,
	[CompanyIndustry] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[CompanyInfo]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[CompanyInfo](
	[CompanyInfoID] [int] NOT NULL,
	[CompanyID] [int] NULL,
	[AddressID] [int] NULL,
	[EmailID] [int] NULL,
	[PhoneNumberID] [int] NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[CompanyInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[Csr]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[Csr](
	[CustomerSupportRepresentativeID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_Csr] PRIMARY KEY CLUSTERED 
(
	[CustomerSupportRepresentativeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[Customer]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[Email]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[Email](
	[EmailID] [int] IDENTITY(1,1) NOT NULL,
	[EmailCharacters] [nvarchar](320) NOT NULL,
	[EmailAccountType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[EmailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[Person]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[PersonInfo]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[PersonInfo](
	[PersonInfoID] [int] NOT NULL,
	[PersonID] [int] NULL,
	[AddressID] [int] NULL,
	[PhoneNumberID] [int] NULL,
	[EmailID] [int] NULL,
 CONSTRAINT [PK_PersonInfo] PRIMARY KEY CLUSTERED 
(
	[PersonInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CustomerDatabase].[PhoneNumber]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomerDatabase].[PhoneNumber](
	[PhoneNumberID] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumberDigits] [nvarchar](11) NOT NULL,
	[PhoneNumberType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PhoneNumber] PRIMARY KEY CLUSTERED 
(
	[PhoneNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/23/2024 10:29:53 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/23/2024 10:29:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [CustomerDatabase].[Address] ON 

INSERT [CustomerDatabase].[Address] ([AddressID], [AddressLineOne], [AddressLineTwo], [City], [AddressType], [State]) VALUES (1, N'9929 Sulphur Springs Ave. Muskego', N'', N'Milwaukee', N'DOMICILE', N'WI')
INSERT [CustomerDatabase].[Address] ([AddressID], [AddressLineOne], [AddressLineTwo], [City], [AddressType], [State]) VALUES (2, N'17 Fairview Road Cheaspeake', N'', N'Toledo', N'BUSINESS', N'CA')
SET IDENTITY_INSERT [CustomerDatabase].[Address] OFF
GO
INSERT [CustomerDatabase].[Call] ([CallID], [CallNotesID], [CallDurationStartDateTime], [CallDurationEndDateTime], [CustomerID], [CustomerSupportRepresentativeID]) VALUES (1, 1, CAST(N'2020-12-05T17:25:09.0000000' AS DateTime2), CAST(N'2020-12-05T19:30:17.0000000' AS DateTime2), 1, 1)
GO
SET IDENTITY_INSERT [CustomerDatabase].[CallNotes] ON 

INSERT [CustomerDatabase].[CallNotes] ([CallNotesID], [CallNotesDescription], [IsResolved], [CallReasonType]) VALUES (1, N'', 1, N'BILLING_AND_PAYMENT')
SET IDENTITY_INSERT [CustomerDatabase].[CallNotes] OFF
GO
SET IDENTITY_INSERT [CustomerDatabase].[Company] ON 

INSERT [CustomerDatabase].[Company] ([CompanyID], [CompanyName], [CompanyDescription], [CompanyIndustry]) VALUES (1, N'The Shimada Clan', N'', N'HOSPITALITY')
SET IDENTITY_INSERT [CustomerDatabase].[Company] OFF
GO
INSERT [CustomerDatabase].[CompanyInfo] ([CompanyInfoID], [CompanyID], [AddressID], [EmailID], [PhoneNumberID]) VALUES (1, 1, 2, 2, 2)
GO
SET IDENTITY_INSERT [CustomerDatabase].[Csr] ON 

INSERT [CustomerDatabase].[Csr] ([CustomerSupportRepresentativeID], [PersonID], [CompanyID]) VALUES (1, 2, 1)
SET IDENTITY_INSERT [CustomerDatabase].[Csr] OFF
GO
SET IDENTITY_INSERT [CustomerDatabase].[Customer] ON 

INSERT [CustomerDatabase].[Customer] ([CustomerID], [PersonID]) VALUES (1, 1)
SET IDENTITY_INSERT [CustomerDatabase].[Customer] OFF
GO
SET IDENTITY_INSERT [CustomerDatabase].[Email] ON 

INSERT [CustomerDatabase].[Email] ([EmailID], [EmailCharacters], [EmailAccountType]) VALUES (1, N'shimadabro@gmail.com', N'HOME')
INSERT [CustomerDatabase].[Email] ([EmailID], [EmailCharacters], [EmailAccountType]) VALUES (2, N'shimadaclan@gmail.com', N'HOME')
SET IDENTITY_INSERT [CustomerDatabase].[Email] OFF
GO
SET IDENTITY_INSERT [CustomerDatabase].[Person] ON 

INSERT [CustomerDatabase].[Person] ([PersonID], [FirstName], [MiddleName], [LastName], [BirthDate]) VALUES (1, N'Genji', NULL, N'Shimada', CAST(N'1997-10-25' AS Date))
INSERT [CustomerDatabase].[Person] ([PersonID], [FirstName], [MiddleName], [LastName], [BirthDate]) VALUES (2, N'Hanzo', NULL, N'Shimada', CAST(N'1990-03-14' AS Date))
SET IDENTITY_INSERT [CustomerDatabase].[Person] OFF
GO
INSERT [CustomerDatabase].[PersonInfo] ([PersonInfoID], [PersonID], [AddressID], [PhoneNumberID], [EmailID]) VALUES (1, 1, 1, 1, 1)
INSERT [CustomerDatabase].[PersonInfo] ([PersonInfoID], [PersonID], [AddressID], [PhoneNumberID], [EmailID]) VALUES (2, 2, 1, 1, 1)
GO
SET IDENTITY_INSERT [CustomerDatabase].[PhoneNumber] ON 

INSERT [CustomerDatabase].[PhoneNumber] ([PhoneNumberID], [PhoneNumberDigits], [PhoneNumberType]) VALUES (1, N'1925064920', N'WORK')
INSERT [CustomerDatabase].[PhoneNumber] ([PhoneNumberID], [PhoneNumberDigits], [PhoneNumberType]) VALUES (2, N'7392018402', N'WORK')
SET IDENTITY_INSERT [CustomerDatabase].[PhoneNumber] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240222235843_InitialCreate', N'8.0.2')
GO
/****** Object:  Index [IX_Call_CallNotesID]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_Call_CallNotesID] ON [CustomerDatabase].[Call]
(
	[CallNotesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Call_CustomerSupportRepresentativeID]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_Call_CustomerSupportRepresentativeID] ON [CustomerDatabase].[Call]
(
	[CustomerSupportRepresentativeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CompanyInfo_CompanyID]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_CompanyInfo_CompanyID] ON [CustomerDatabase].[CompanyInfo]
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Csr_CompanyID]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_Csr_CompanyID] ON [CustomerDatabase].[Csr]
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Csr_PersonID]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_Csr_PersonID] ON [CustomerDatabase].[Csr]
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customer_PersonID]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_Customer_PersonID] ON [CustomerDatabase].[Customer]
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonInfo_PersonID]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_PersonInfo_PersonID] ON [CustomerDatabase].[PersonInfo]
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2/23/2024 10:29:54 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [CustomerDatabase].[Call]  WITH CHECK ADD  CONSTRAINT [FK_Call_CallNotes_CallNotesID] FOREIGN KEY([CallNotesID])
REFERENCES [CustomerDatabase].[CallNotes] ([CallNotesID])
GO
ALTER TABLE [CustomerDatabase].[Call] CHECK CONSTRAINT [FK_Call_CallNotes_CallNotesID]
GO
ALTER TABLE [CustomerDatabase].[Call]  WITH CHECK ADD  CONSTRAINT [FK_Call_Csr_CustomerSupportRepresentativeID] FOREIGN KEY([CustomerSupportRepresentativeID])
REFERENCES [CustomerDatabase].[Csr] ([CustomerSupportRepresentativeID])
GO
ALTER TABLE [CustomerDatabase].[Call] CHECK CONSTRAINT [FK_Call_Csr_CustomerSupportRepresentativeID]
GO
ALTER TABLE [CustomerDatabase].[Call]  WITH CHECK ADD  CONSTRAINT [FK_Call_Customer_CallID] FOREIGN KEY([CallID])
REFERENCES [CustomerDatabase].[Customer] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [CustomerDatabase].[Call] CHECK CONSTRAINT [FK_Call_Customer_CallID]
GO
ALTER TABLE [CustomerDatabase].[CompanyInfo]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInfo_Address_CompanyInfoID] FOREIGN KEY([CompanyInfoID])
REFERENCES [CustomerDatabase].[Address] ([AddressID])
ON DELETE CASCADE
GO
ALTER TABLE [CustomerDatabase].[CompanyInfo] CHECK CONSTRAINT [FK_CompanyInfo_Address_CompanyInfoID]
GO
ALTER TABLE [CustomerDatabase].[CompanyInfo]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInfo_Company_CompanyID] FOREIGN KEY([CompanyID])
REFERENCES [CustomerDatabase].[Company] ([CompanyID])
GO
ALTER TABLE [CustomerDatabase].[CompanyInfo] CHECK CONSTRAINT [FK_CompanyInfo_Company_CompanyID]
GO
ALTER TABLE [CustomerDatabase].[CompanyInfo]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInfo_Email_CompanyInfoID] FOREIGN KEY([CompanyInfoID])
REFERENCES [CustomerDatabase].[Email] ([EmailID])
ON DELETE CASCADE
GO
ALTER TABLE [CustomerDatabase].[CompanyInfo] CHECK CONSTRAINT [FK_CompanyInfo_Email_CompanyInfoID]
GO
ALTER TABLE [CustomerDatabase].[CompanyInfo]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInfo_PhoneNumber_CompanyInfoID] FOREIGN KEY([CompanyInfoID])
REFERENCES [CustomerDatabase].[PhoneNumber] ([PhoneNumberID])
ON DELETE CASCADE
GO
ALTER TABLE [CustomerDatabase].[CompanyInfo] CHECK CONSTRAINT [FK_CompanyInfo_PhoneNumber_CompanyInfoID]
GO
ALTER TABLE [CustomerDatabase].[Csr]  WITH CHECK ADD  CONSTRAINT [FK_Csr_Company_CompanyID] FOREIGN KEY([CompanyID])
REFERENCES [CustomerDatabase].[Company] ([CompanyID])
GO
ALTER TABLE [CustomerDatabase].[Csr] CHECK CONSTRAINT [FK_Csr_Company_CompanyID]
GO
ALTER TABLE [CustomerDatabase].[Csr]  WITH CHECK ADD  CONSTRAINT [FK_Csr_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [CustomerDatabase].[Person] ([PersonID])
GO
ALTER TABLE [CustomerDatabase].[Csr] CHECK CONSTRAINT [FK_Csr_Person_PersonID]
GO
ALTER TABLE [CustomerDatabase].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [CustomerDatabase].[Person] ([PersonID])
ON DELETE CASCADE
GO
ALTER TABLE [CustomerDatabase].[Customer] CHECK CONSTRAINT [FK_Customer_Person_PersonID]
GO
ALTER TABLE [CustomerDatabase].[PersonInfo]  WITH CHECK ADD  CONSTRAINT [FK_PersonInfo_Address_PersonInfoID] FOREIGN KEY([PersonInfoID])
REFERENCES [CustomerDatabase].[Address] ([AddressID])
ON DELETE CASCADE
GO
ALTER TABLE [CustomerDatabase].[PersonInfo] CHECK CONSTRAINT [FK_PersonInfo_Address_PersonInfoID]
GO
ALTER TABLE [CustomerDatabase].[PersonInfo]  WITH CHECK ADD  CONSTRAINT [FK_PersonInfo_Email_PersonInfoID] FOREIGN KEY([PersonInfoID])
REFERENCES [CustomerDatabase].[Email] ([EmailID])
ON DELETE CASCADE
GO
ALTER TABLE [CustomerDatabase].[PersonInfo] CHECK CONSTRAINT [FK_PersonInfo_Email_PersonInfoID]
GO
ALTER TABLE [CustomerDatabase].[PersonInfo]  WITH CHECK ADD  CONSTRAINT [FK_PersonInfo_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [CustomerDatabase].[Person] ([PersonID])
GO
ALTER TABLE [CustomerDatabase].[PersonInfo] CHECK CONSTRAINT [FK_PersonInfo_Person_PersonID]
GO
ALTER TABLE [CustomerDatabase].[PersonInfo]  WITH CHECK ADD  CONSTRAINT [FK_PersonInfo_PhoneNumber_PersonInfoID] FOREIGN KEY([PersonInfoID])
REFERENCES [CustomerDatabase].[PhoneNumber] ([PhoneNumberID])
ON DELETE CASCADE
GO
ALTER TABLE [CustomerDatabase].[PersonInfo] CHECK CONSTRAINT [FK_PersonInfo_PhoneNumber_PersonInfoID]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [CustomerDatabase] SET  READ_WRITE 
GO
