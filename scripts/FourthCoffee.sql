USE [master]
GO
/****** Object:  Database [FourthCoffee]    Script Date: 1/30/2019 1:56:05 AM ******/
CREATE DATABASE [FourthCoffee]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FourthCoffee', FILENAME = N'C:\20483-Programming-in-C-Sharp\Allfiles\Mod07\Democode\Databases\FourthCoffee.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FourthCoffee_log', FILENAME = N'C:\20483-Programming-in-C-Sharp\Allfiles\Mod07\Democode\Databases\FourthCoffee_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FourthCoffee] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FourthCoffee].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FourthCoffee] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FourthCoffee] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FourthCoffee] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FourthCoffee] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FourthCoffee] SET ARITHABORT OFF 
GO
ALTER DATABASE [FourthCoffee] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FourthCoffee] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FourthCoffee] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FourthCoffee] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FourthCoffee] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FourthCoffee] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FourthCoffee] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FourthCoffee] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FourthCoffee] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FourthCoffee] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FourthCoffee] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FourthCoffee] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FourthCoffee] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FourthCoffee] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FourthCoffee] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FourthCoffee] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FourthCoffee] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FourthCoffee] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FourthCoffee] SET  MULTI_USER 
GO
ALTER DATABASE [FourthCoffee] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FourthCoffee] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FourthCoffee] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FourthCoffee] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FourthCoffee] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FourthCoffee] SET QUERY_STORE = OFF
GO
USE [FourthCoffee]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [FourthCoffee]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 1/30/2019 1:56:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[BranchID] [int] NOT NULL,
	[BranchName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 1/30/2019 1:56:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[DateOfBirth] [date] NULL,
	[Branch] [int] NULL,
	[JobTitle] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobTitles]    Script Date: 1/30/2019 1:56:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobTitles](
	[JobTitleId] [int] NOT NULL,
	[Job] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[JobTitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Branches] ([BranchID], [BranchName]) VALUES (1, N'Head Office')
GO
INSERT [dbo].[Branches] ([BranchID], [BranchName]) VALUES (2, N'New York')
GO
INSERT [dbo].[Branches] ([BranchID], [BranchName]) VALUES (3, N'Washington DC')
GO
INSERT [dbo].[Branches] ([BranchID], [BranchName]) VALUES (4, N'Seattle')
GO
INSERT [dbo].[Branches] ([BranchID], [BranchName]) VALUES (5, N'San Francisco')
GO
INSERT [dbo].[Branches] ([BranchID], [BranchName]) VALUES (6, N'Los Angeles')
GO
INSERT [dbo].[Branches] ([BranchID], [BranchName]) VALUES (7, N'San Diego')
GO
INSERT [dbo].[Branches] ([BranchID], [BranchName]) VALUES (8, N'Boston')
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [DateOfBirth], [Branch], [JobTitle]) VALUES (1001, N'Terry', N'Adams', CAST(N'1970-11-21' AS Date), 2, 1)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [DateOfBirth], [Branch], [JobTitle]) VALUES (1002, N'Toni', N'Poe', CAST(N'1972-03-01' AS Date), 5, 2)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [DateOfBirth], [Branch], [JobTitle]) VALUES (1003, N'Charlie', N'Herb', CAST(N'1971-11-07' AS Date), 4, 3)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [DateOfBirth], [Branch], [JobTitle]) VALUES (1004, N'Diane', N'Prescott', CAST(N'1968-09-30' AS Date), 1, 3)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [DateOfBirth], [Branch], [JobTitle]) VALUES (1005, N'Glen', N'John', CAST(N'1967-10-04' AS Date), 3, 1)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [DateOfBirth], [Branch], [JobTitle]) VALUES (1006, N'Sean', N'Bentley', CAST(N'1967-08-27' AS Date), 2, 2)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [DateOfBirth], [Branch], [JobTitle]) VALUES (1007, N'Will', N'Kennedy', CAST(N'1969-01-11' AS Date), 4, 3)
GO
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [DateOfBirth], [Branch], [JobTitle]) VALUES (1008, N'Dennis', N'Saylor', CAST(N'1982-08-05' AS Date), 5, 1)
GO
INSERT [dbo].[JobTitles] ([JobTitleId], [Job]) VALUES (1, N'Branch Manager')
GO
INSERT [dbo].[JobTitles] ([JobTitleId], [Job]) VALUES (2, N'Barista')
GO
INSERT [dbo].[JobTitles] ([JobTitleId], [Job]) VALUES (3, N'Trainee Barista')
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Branches] FOREIGN KEY([Branch])
REFERENCES [dbo].[Branches] ([BranchID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Branches]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_JobTitles] FOREIGN KEY([JobTitle])
REFERENCES [dbo].[JobTitles] ([JobTitleId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_JobTitles]
GO
USE [master]
GO
ALTER DATABASE [FourthCoffee] SET  READ_WRITE 
GO
