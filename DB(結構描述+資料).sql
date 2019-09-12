USE [master]
GO
/****** Object:  Database [Business System]    Script Date: 2019/9/12 下午 06:15:45 ******/
CREATE DATABASE [Business System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Business System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Business System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Business System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Business System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Business System] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Business System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Business System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Business System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Business System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Business System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Business System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Business System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Business System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Business System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Business System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Business System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Business System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Business System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Business System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Business System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Business System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Business System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Business System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Business System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Business System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Business System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Business System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Business System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Business System] SET RECOVERY FULL 
GO
ALTER DATABASE [Business System] SET  MULTI_USER 
GO
ALTER DATABASE [Business System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Business System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Business System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Business System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Business System] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Business System', N'ON'
GO
ALTER DATABASE [Business System] SET QUERY_STORE = OFF
GO
USE [Business System]
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
USE [Business System]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account] [nvarchar](12) NOT NULL,
	[password] [nvarchar](12) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalChild]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalChild](
	[ApprovalStageID] [int] NULL,
	[ApprovalID] [int] NULL,
	[ApprovalStatusID] [int] NOT NULL,
	[ApproveDate] [datetime] NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApprovalChild] PRIMARY KEY CLUSTERED 
(
	[ApprovalStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalOrder]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalOrder](
	[ReportID] [nvarchar](50) NULL,
	[ApprovalCategoryID] [int] NULL,
	[ApprovalStageID] [int] NOT NULL,
	[ApprovalOrder] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApprovalOrder] PRIMARY KEY CLUSTERED 
(
	[ApprovalStageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalStatus]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalStatus](
	[ReportID] [nvarchar](50) NULL,
	[ApprovalStatusID] [int] NULL,
	[ApprovalStatus] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovantStatus]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovantStatus](
	[ApprovantStatusID] [int] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bulletin board]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bulletin board](
	[Num] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[DepartmentID] [int] NULL,
	[GroupID] [int] NULL,
	[Content] [nvarchar](50) NULL,
	[PostTime] [datetime] NULL,
 CONSTRAINT [PK_Bulletin board] PRIMARY KEY CLUSTERED 
(
	[Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Business Trip]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Business Trip](
	[employeeID] [int] NULL,
	[start_date_time] [datetime] NULL,
	[end_date_time] [datetime] NULL,
	[adress] [nchar](10) NULL,
	[description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company vehicle]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company vehicle](
	[license number] [nchar](10) NOT NULL,
	[brand] [nchar](10) NULL,
	[serial] [nchar](10) NULL,
	[max passenger] [nchar](10) NULL,
	[officeID] [int] NULL,
 CONSTRAINT [PK_Company vehicle] PRIMARY KEY CLUSTERED 
(
	[license number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company vehicle history]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company vehicle history](
	[license number] [nchar](10) NULL,
	[start_date_time] [datetime] NULL,
	[end_date_time] [datetime] NULL,
	[employeeID] [int] NULL,
	[purpose] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[departmentID] [int] NOT NULL,
	[name] [nvarchar](30) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[departmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employeeID] [int] IDENTITY(1001,1) NOT NULL,
	[employee_name] [nvarchar](50) NULL,
	[gender] [nvarchar](10) NULL,
	[birth] [date] NULL,
	[hire_date] [datetime] NULL,
	[account] [nvarchar](12) NULL,
	[officeID] [int] NULL,
	[departmentID] [int] NULL,
	[positionID] [int] NULL,
	[managerID] [int] NULL,
	[employed] [bit] NULL,
	[groupID] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[File]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[File](
	[FileID] [bigint] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
	[FileSize] [nvarchar](50) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[UploadDate] [datetime] NOT NULL,
	[Data] [varbinary](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupID] [int] NOT NULL,
	[GroupName] [nvarchar](50) NULL,
	[DepartmentID] [int] NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[leaveID] [nchar](10) NOT NULL,
	[leave_name] [nchar](20) NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[leaveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveHistory]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveHistory](
	[employeeID] [int] NULL,
	[leaveID] [nchar](10) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting room]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting room](
	[meetingID] [nchar](10) NOT NULL,
	[officeID] [int] NULL,
	[max member] [int] NULL,
 CONSTRAINT [PK_Meeting room] PRIMARY KEY CLUSTERED 
(
	[meetingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting room history]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting room history](
	[meetingID] [nchar](10) NULL,
	[start_date_time] [datetime] NULL,
	[end_date_time] [datetime] NOT NULL,
	[employeeID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [bigint] IDENTITY(1,1) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[MailingDate] [datetime] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Office]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Office](
	[officeID] [int] NOT NULL,
	[office_name] [nvarchar](20) NULL,
	[office_address] [nvarchar](60) NULL,
 CONSTRAINT [PK_Office] PRIMARY KEY CLUSTERED 
(
	[officeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[positionID] [int] NOT NULL,
	[position] [nchar](30) NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[positionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchasing Order]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchasing Order](
	[employeeID] [int] NULL,
	[items] [nchar](10) NULL,
	[quantity] [int] NULL,
	[unit price] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipient]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipient](
	[MessageID] [bigint] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Recipient] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportCategory]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportCategory](
	[ReportCategoryID] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NULL,
 CONSTRAINT [PK_ReportCategory] PRIMARY KEY CLUSTERED 
(
	[ReportCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportMain]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportMain](
	[ReportID] [nvarchar](50) NOT NULL,
	[ReportCategoryID] [nvarchar](50) NULL,
	[ApplicantID] [int] NULL,
	[ApplyDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
 CONSTRAINT [PK_ReportMain] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportTimeSystem]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportTimeSystem](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[employeeID] [int] NOT NULL,
	[ApplyDateTime] [datetime] NOT NULL,
	[EventHours] [float] NOT NULL,
	[EventID] [int] NOT NULL,
	[Note] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequisitionChild]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequisitionChild](
	[RequisitionID] [int] NULL,
	[ProductName] [nvarchar](50) NULL,
	[UnitPrice] [money] NULL,
	[Quantity] [decimal](18, 0) NULL,
	[Discount] [decimal](18, 0) NULL,
	[Note] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequisitionMain]    Script Date: 2019/9/12 下午 06:15:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequisitionMain](
	[ReportID] [nvarchar](50) NULL,
	[RequisitionID] [int] NOT NULL,
	[TotalPrice] [money] NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_RequisitionMain] PRIMARY KEY CLUSTERED 
(
	[RequisitionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RewardandPunishment]    Script Date: 2019/9/12 下午 06:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RewardandPunishment](
	[Reward/PunishmentID] [nchar](10) NOT NULL,
	[Reward/PunishmentName] [nchar](10) NULL,
 CONSTRAINT [PK_RewardandPunishment] PRIMARY KEY CLUSTERED 
(
	[Reward/PunishmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RewardandPunishmentHistory]    Script Date: 2019/9/12 下午 06:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RewardandPunishmentHistory](
	[employeeID] [int] NULL,
	[Date] [datetime] NULL,
	[Reward/Punishment] [nchar](10) NULL,
	[managerID] [nchar](10) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suggestion]    Script Date: 2019/9/12 下午 06:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suggestion](
	[suggestionID] [nchar](10) NOT NULL,
	[suggestion] [nchar](30) NULL,
 CONSTRAINT [PK_Suggestion] PRIMARY KEY CLUSTERED 
(
	[suggestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suggestion history]    Script Date: 2019/9/12 下午 06:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suggestion history](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[employeeID] [int] NULL,
	[departmentID] [int] NULL,
	[suggestionID] [nchar](10) NULL,
	[content] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurveyChild]    Script Date: 2019/9/12 下午 06:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyChild](
	[SurveyID] [int] NULL,
	[Survey] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurveyMain]    Script Date: 2019/9/12 下午 06:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyMain](
	[SurveyID] [int] NULL,
	[QuestionID] [bigint] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkingHours]    Script Date: 2019/9/12 下午 06:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingHours](
	[employeeID] [int] NULL,
	[clock_in_time] [datetime] NULL,
	[clock_out_time] [datetime] NULL,
	[leaveID] [nchar](10) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApprovalChild]  WITH CHECK ADD  CONSTRAINT [FK_ApprovalChild_ApprovalOrder] FOREIGN KEY([ApprovalStageID])
REFERENCES [dbo].[ApprovalOrder] ([ApprovalStageID])
GO
ALTER TABLE [dbo].[ApprovalChild] CHECK CONSTRAINT [FK_ApprovalChild_ApprovalOrder]
GO
ALTER TABLE [dbo].[ApprovalOrder]  WITH CHECK ADD  CONSTRAINT [FK_ApprovalOrder_ReportMain] FOREIGN KEY([ReportID])
REFERENCES [dbo].[ReportMain] ([ReportID])
GO
ALTER TABLE [dbo].[ApprovalOrder] CHECK CONSTRAINT [FK_ApprovalOrder_ReportMain]
GO
ALTER TABLE [dbo].[ApprovalStatus]  WITH CHECK ADD  CONSTRAINT [FK_ApprovalStatus_ReportMain] FOREIGN KEY([ReportID])
REFERENCES [dbo].[ReportMain] ([ReportID])
GO
ALTER TABLE [dbo].[ApprovalStatus] CHECK CONSTRAINT [FK_ApprovalStatus_ReportMain]
GO
ALTER TABLE [dbo].[ApprovantStatus]  WITH CHECK ADD  CONSTRAINT [FK_ApprovantStatus_ApprovalChild] FOREIGN KEY([ApprovantStatusID])
REFERENCES [dbo].[ApprovalChild] ([ApprovalStatusID])
GO
ALTER TABLE [dbo].[ApprovantStatus] CHECK CONSTRAINT [FK_ApprovantStatus_ApprovalChild]
GO
ALTER TABLE [dbo].[Bulletin board]  WITH CHECK ADD  CONSTRAINT [FK_Bulletin board_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[Bulletin board] CHECK CONSTRAINT [FK_Bulletin board_Department]
GO
ALTER TABLE [dbo].[Bulletin board]  WITH CHECK ADD  CONSTRAINT [FK_Bulletin board_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Bulletin board] CHECK CONSTRAINT [FK_Bulletin board_Employee]
GO
ALTER TABLE [dbo].[Bulletin board]  WITH CHECK ADD  CONSTRAINT [FK_Bulletin board_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[Bulletin board] CHECK CONSTRAINT [FK_Bulletin board_Group]
GO
ALTER TABLE [dbo].[Business Trip]  WITH CHECK ADD  CONSTRAINT [FK_Business Trip_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Business Trip] CHECK CONSTRAINT [FK_Business Trip_Employee]
GO
ALTER TABLE [dbo].[Company vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Company vehicle_Office] FOREIGN KEY([officeID])
REFERENCES [dbo].[Office] ([officeID])
GO
ALTER TABLE [dbo].[Company vehicle] CHECK CONSTRAINT [FK_Company vehicle_Office]
GO
ALTER TABLE [dbo].[Company vehicle history]  WITH CHECK ADD  CONSTRAINT [FK_Company vehicle history_Company vehicle] FOREIGN KEY([license number])
REFERENCES [dbo].[Company vehicle] ([license number])
GO
ALTER TABLE [dbo].[Company vehicle history] CHECK CONSTRAINT [FK_Company vehicle history_Company vehicle]
GO
ALTER TABLE [dbo].[Company vehicle history]  WITH CHECK ADD  CONSTRAINT [FK_Company vehicle history_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Company vehicle history] CHECK CONSTRAINT [FK_Company vehicle history_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Account] FOREIGN KEY([account])
REFERENCES [dbo].[Account] ([account])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Account]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([departmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([managerID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Group] FOREIGN KEY([groupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Group]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Office] FOREIGN KEY([officeID])
REFERENCES [dbo].[Office] ([officeID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Office]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Position] FOREIGN KEY([positionID])
REFERENCES [dbo].[Position] ([positionID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Position]
GO
ALTER TABLE [dbo].[File]  WITH CHECK ADD  CONSTRAINT [FK_File_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[File] CHECK CONSTRAINT [FK_File_Employee]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Department]
GO
ALTER TABLE [dbo].[LeaveHistory]  WITH CHECK ADD  CONSTRAINT [FK_LeaveHistory_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[LeaveHistory] CHECK CONSTRAINT [FK_LeaveHistory_Employee]
GO
ALTER TABLE [dbo].[LeaveHistory]  WITH CHECK ADD  CONSTRAINT [FK_LeaveHistory_Leave] FOREIGN KEY([leaveID])
REFERENCES [dbo].[Leave] ([leaveID])
GO
ALTER TABLE [dbo].[LeaveHistory] CHECK CONSTRAINT [FK_LeaveHistory_Leave]
GO
ALTER TABLE [dbo].[Meeting room]  WITH CHECK ADD  CONSTRAINT [FK_Meeting room_Office] FOREIGN KEY([officeID])
REFERENCES [dbo].[Office] ([officeID])
GO
ALTER TABLE [dbo].[Meeting room] CHECK CONSTRAINT [FK_Meeting room_Office]
GO
ALTER TABLE [dbo].[Meeting room history]  WITH CHECK ADD  CONSTRAINT [FK_Meeting room history_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Meeting room history] CHECK CONSTRAINT [FK_Meeting room history_Employee]
GO
ALTER TABLE [dbo].[Meeting room history]  WITH CHECK ADD  CONSTRAINT [FK_Meeting room history_Meeting room] FOREIGN KEY([meetingID])
REFERENCES [dbo].[Meeting room] ([meetingID])
GO
ALTER TABLE [dbo].[Meeting room history] CHECK CONSTRAINT [FK_Meeting room history_Meeting room]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Employee]
GO
ALTER TABLE [dbo].[Purchasing Order]  WITH CHECK ADD  CONSTRAINT [FK_Purchasing Order_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Purchasing Order] CHECK CONSTRAINT [FK_Purchasing Order_Employee]
GO
ALTER TABLE [dbo].[Recipient]  WITH CHECK ADD  CONSTRAINT [FK_Recipient_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Recipient] CHECK CONSTRAINT [FK_Recipient_Employee]
GO
ALTER TABLE [dbo].[Recipient]  WITH CHECK ADD  CONSTRAINT [FK_Recipient_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
GO
ALTER TABLE [dbo].[Recipient] CHECK CONSTRAINT [FK_Recipient_Message]
GO
ALTER TABLE [dbo].[ReportMain]  WITH CHECK ADD  CONSTRAINT [FK_ReportMain_Employee] FOREIGN KEY([ApplicantID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[ReportMain] CHECK CONSTRAINT [FK_ReportMain_Employee]
GO
ALTER TABLE [dbo].[ReportMain]  WITH CHECK ADD  CONSTRAINT [FK_ReportMain_ReportCategory] FOREIGN KEY([ReportCategoryID])
REFERENCES [dbo].[ReportCategory] ([ReportCategoryID])
GO
ALTER TABLE [dbo].[ReportMain] CHECK CONSTRAINT [FK_ReportMain_ReportCategory]
GO
ALTER TABLE [dbo].[ReportTimeSystem]  WITH CHECK ADD  CONSTRAINT [FK_ReportTimeSystem_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[ReportTimeSystem] CHECK CONSTRAINT [FK_ReportTimeSystem_Employee]
GO
ALTER TABLE [dbo].[RequisitionChild]  WITH CHECK ADD  CONSTRAINT [FK_RequisitionChild_RequisitionMain] FOREIGN KEY([RequisitionID])
REFERENCES [dbo].[RequisitionMain] ([RequisitionID])
GO
ALTER TABLE [dbo].[RequisitionChild] CHECK CONSTRAINT [FK_RequisitionChild_RequisitionMain]
GO
ALTER TABLE [dbo].[RequisitionMain]  WITH CHECK ADD  CONSTRAINT [FK_RequisitionMain_ReportMain] FOREIGN KEY([ReportID])
REFERENCES [dbo].[ReportMain] ([ReportID])
GO
ALTER TABLE [dbo].[RequisitionMain] CHECK CONSTRAINT [FK_RequisitionMain_ReportMain]
GO
ALTER TABLE [dbo].[RewardandPunishmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_RewardandPunishmentHistory_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[RewardandPunishmentHistory] CHECK CONSTRAINT [FK_RewardandPunishmentHistory_Employee]
GO
ALTER TABLE [dbo].[RewardandPunishmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_RewardandPunishmentHistory_RewardandPunishment] FOREIGN KEY([Reward/Punishment])
REFERENCES [dbo].[RewardandPunishment] ([Reward/PunishmentID])
GO
ALTER TABLE [dbo].[RewardandPunishmentHistory] CHECK CONSTRAINT [FK_RewardandPunishmentHistory_RewardandPunishment]
GO
ALTER TABLE [dbo].[Suggestion history]  WITH CHECK ADD  CONSTRAINT [FK_Suggestion history_Department] FOREIGN KEY([departmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[Suggestion history] CHECK CONSTRAINT [FK_Suggestion history_Department]
GO
ALTER TABLE [dbo].[Suggestion history]  WITH CHECK ADD  CONSTRAINT [FK_Suggestion history_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Suggestion history] CHECK CONSTRAINT [FK_Suggestion history_Employee]
GO
ALTER TABLE [dbo].[Suggestion history]  WITH CHECK ADD  CONSTRAINT [FK_Suggestion history_Suggestion] FOREIGN KEY([suggestionID])
REFERENCES [dbo].[Suggestion] ([suggestionID])
GO
ALTER TABLE [dbo].[Suggestion history] CHECK CONSTRAINT [FK_Suggestion history_Suggestion]
GO
ALTER TABLE [dbo].[WorkingHours]  WITH CHECK ADD  CONSTRAINT [FK_Working hours_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[WorkingHours] CHECK CONSTRAINT [FK_Working hours_Employee]
GO
ALTER TABLE [dbo].[WorkingHours]  WITH CHECK ADD  CONSTRAINT [FK_Working hours_Leave] FOREIGN KEY([leaveID])
REFERENCES [dbo].[Leave] ([leaveID])
GO
ALTER TABLE [dbo].[WorkingHours] CHECK CONSTRAINT [FK_Working hours_Leave]
GO
/****** Object:  StoredProcedure [dbo].[AddReport]    Script Date: 2019/9/12 下午 06:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AddReport]
	@ReportID bigint Output,
	@employeeID int,
	@ApplyDateTime datetime,
	@EventHours float,
	@EventID int,
	@Note nvarchar(100)
AS
	Insert Into ReportTimeSystem(ReportID,employeeID,ApplyDateTime,EventHours,EventID,Note) 
	Values(@ReportID,@employeeID,@ApplyDateTime,@EventHours,@EventID,@Note)
	select @ReportID= SCOPE_IDENTITY()

RETURN 0
GO
USE [master]
GO
ALTER DATABASE [Business System] SET  READ_WRITE 
GO
