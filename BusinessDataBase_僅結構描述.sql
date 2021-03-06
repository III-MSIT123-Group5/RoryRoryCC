/****** Object:  Database [BusinessDataBase]    Script Date: 2020/1/9 上午 09:11:10 ******/
CREATE DATABASE [BusinessDataBase]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [BusinessDataBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BusinessDataBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BusinessDataBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BusinessDataBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BusinessDataBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [BusinessDataBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BusinessDataBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BusinessDataBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BusinessDataBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BusinessDataBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BusinessDataBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BusinessDataBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BusinessDataBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BusinessDataBase] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [BusinessDataBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BusinessDataBase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BusinessDataBase] SET  MULTI_USER 
GO
ALTER DATABASE [BusinessDataBase] SET ENCRYPTION ON
GO
ALTER DATABASE [BusinessDataBase] SET QUERY_STORE = ON
GO
ALTER DATABASE [BusinessDataBase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account1] [nvarchar](12) NOT NULL,
	[password] [varbinary](32) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[account1] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivitiesChild]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivitiesChild](
	[ActivityChildID] [int] NOT NULL,
	[ActicityMainID] [int] NULL,
	[EmployeeID] [int] NULL,
	[JoinOrNot] [nchar](10) NULL,
 CONSTRAINT [PK_ActivitiesChilds] PRIMARY KEY CLUSTERED 
(
	[ActivityChildID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivitiesMain]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivitiesMain](
	[ActivityMainID] [int] NOT NULL,
	[ActivityName] [nvarchar](50) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_ActivitiesMains] PRIMARY KEY CLUSTERED 
(
	[ActivityMainID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Approval]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Approval](
	[OrderID] [int] NOT NULL,
	[ApprovalProcedureID] [int] NULL,
	[FirstSignerID] [int] NULL,
	[FirstSignerName] [nvarchar](10) NULL,
	[FirstSignStatus] [nvarchar](10) NULL,
	[FirstSignDate] [datetime] NULL,
	[SecondSignerID] [int] NULL,
	[SecondSignerName] [nvarchar](10) NULL,
	[SecondSignStatus] [nvarchar](10) NULL,
	[SecondSignDate] [datetime] NULL,
	[ThirdSignerID] [int] NULL,
	[ThirdSignerName] [nvarchar](10) NULL,
	[ThirdSignStatus] [nvarchar](10) NULL,
	[ThirdSignDate] [datetime] NULL,
	[FourthSignerID] [int] NULL,
	[FourthSignerName] [nvarchar](10) NULL,
	[FourthSignStatus] [nvarchar](10) NULL,
	[ForthSignDate] [datetime] NULL,
 CONSTRAINT [PK_Approvals] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalProcedure]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalProcedure](
	[ApprovalProcedureID] [int] NOT NULL,
	[PositionID] [int] NULL,
	[ApprovalReportName] [nvarchar](50) NULL,
	[ApprovalSupervisor] [bit] NULL,
	[ApprovalDirector] [bit] NULL,
	[ApprovalGenalManager] [bit] NULL,
	[ApprovalFinancialDirector] [bit] NULL,
 CONSTRAINT [PK_ApprovalProcedures] PRIMARY KEY CLUSTERED 
(
	[ApprovalProcedureID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalStatus]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalStatus](
	[ApprovalStatusID] [int] NOT NULL,
	[StatusName] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_ApprovalStatus] PRIMARY KEY CLUSTERED 
(
	[ApprovalStatusID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BulletinBoard]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BulletinBoard](
	[Num] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[DepartmentID] [int] NULL,
	[GroupID] [int] NULL,
	[Content] [nvarchar](50) NULL,
	[PostTime] [datetime] NULL,
 CONSTRAINT [PK_BulletinBoards] PRIMARY KEY CLUSTERED 
(
	[Num] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[C__MigrationHistory]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_C__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentChild]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentChild](
	[CommentMainID] [int] NULL,
	[ChildNum] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[CommentQuestionID] [int] NULL,
 CONSTRAINT [PK_CommentChilds] PRIMARY KEY CLUSTERED 
(
	[ChildNum] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentContent]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentContent](
	[CommentContentID] [int] IDENTITY(400,1) NOT NULL,
	[CommentContent1] [nvarchar](50) NULL,
	[CommentOptionID] [int] NULL,
 CONSTRAINT [PK_CommentContents] PRIMARY KEY CLUSTERED 
(
	[CommentContentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentMain]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentMain](
	[CommentMainID] [int] IDENTITY(1,1) NOT NULL,
	[CommentName] [nvarchar](50) NULL,
	[EmployeeID] [int] NULL,
	[SendTime] [datetime] NULL,
	[CommentContentID] [int] NULL,
	[ActivityMainID] [int] NULL,
 CONSTRAINT [PK_CommentMains] PRIMARY KEY CLUSTERED 
(
	[CommentMainID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentOption]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentOption](
	[CommentOptionID] [int] IDENTITY(10,1) NOT NULL,
	[CommentOption1] [nvarchar](50) NULL,
 CONSTRAINT [PK_CommentOptions] PRIMARY KEY CLUSTERED 
(
	[CommentOptionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentQuestion]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentQuestion](
	[CommentContentID] [int] NULL,
	[CommentQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](50) NULL,
 CONSTRAINT [PK_CommentQuestions] PRIMARY KEY CLUSTERED 
(
	[CommentQuestionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentReply]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentReply](
	[ReplyNum] [int] IDENTITY(1,1) NOT NULL,
	[ChildNum] [int] NULL,
	[Rate] [int] NULL,
	[ReplyTime] [datetime] NULL,
	[CommentMainID] [int] NULL,
 CONSTRAINT [PK_CommentReply] PRIMARY KEY CLUSTERED 
(
	[ReplyNum] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyVehicle]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyVehicle](
	[LicenseNumber] [nvarchar](50) NOT NULL,
	[VehicleYear] [int] NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[brand] [nvarchar](max) NOT NULL,
	[serial] [nvarchar](max) NOT NULL,
	[MaxPassenger] [nvarchar](max) NOT NULL,
	[officeID] [int] NOT NULL,
	[VehiclePhoto] [varbinary](max) NULL,
	[VehiclePhoto2] [nvarchar](max) NULL,
 CONSTRAINT [PK_CompanyVehicles] PRIMARY KEY CLUSTERED 
(
	[LicenseNumber] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyVehicleHistory]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyVehicleHistory](
	[VehicleHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[LicenseNumber] [nvarchar](50) NOT NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[employeeID] [int] NULL,
	[purpose] [nvarchar](max) NULL,
 CONSTRAINT [PK_CompanyVehicleHistories] PRIMARY KEY CLUSTERED 
(
	[VehicleHistoryID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[departmentID] [int] NOT NULL,
	[name] [nvarchar](30) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[departmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[Birth] [datetime] NOT NULL,
	[HireDate] [datetime] NOT NULL,
	[Account] [nvarchar](12) NOT NULL,
	[OfficeID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[PositionID] [int] NOT NULL,
	[ManagerID] [int] NOT NULL,
	[Employed] [bit] NOT NULL,
	[GroupID] [int] NOT NULL,
	[Photo] [nvarchar](max) NULL,
	[SpecialLeaveHours] [int] NOT NULL,
	[PersonalLeaveHours] [int] NOT NULL,
	[SickLeaveHours] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[employeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeApprovalTemp]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeApprovalTemp](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[Birth] [datetime] NOT NULL,
	[HireDate] [datetime] NOT NULL,
	[Account] [nvarchar](12) NOT NULL,
	[OfficeID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[PositionID] [int] NOT NULL,
	[ManagerID] [int] NOT NULL,
	[Employed] [bit] NOT NULL,
	[GroupID] [int] NOT NULL,
	[Photo] [nvarchar](max) NOT NULL,
	[CreateOrUpdate] [nvarchar](10) NOT NULL,
	[Editor] [int] NOT NULL,
	[EditorTime] [datetime] NOT NULL,
	[GroupLeaderID] [int] NULL,
	[GroupLeaderSignTime] [datetime] NULL,
	[DepartmentLeaderID] [int] NULL,
	[DepartmentLeaderSignTime] [datetime] NULL,
	[SignState] [bit] NOT NULL,
	[Rejection] [bit] NOT NULL,
	[StatusDescript] [nvarchar](12) NULL,
 CONSTRAINT [PK_EmployeeApprovalTemps] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](15) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventCalendar]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventCalendar](
	[CalendarID] [int] IDENTITY(1,1) NOT NULL,
	[employeeID] [int] NOT NULL,
	[Subject] [nvarchar](15) NOT NULL,
	[DepartmentID] [int] NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Location] [nvarchar](20) NULL,
	[Description] [nvarchar](50) NULL,
	[IsImportant] [bit] NOT NULL,
	[ThemeColor] [nvarchar](15) NULL,
 CONSTRAINT [PK_EventCalendars] PRIMARY KEY CLUSTERED 
(
	[CalendarID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[File]    Script Date: 2020/1/9 上午 09:11:10 ******/
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
	[Data] [nvarchar](max) NOT NULL,
	[Extension] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupID] [int] NOT NULL,
	[GroupName] [nvarchar](50) NULL,
	[DepartmentID] [int] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[leaveID] [int] NOT NULL,
	[leave_name] [nvarchar](10) NULL,
 CONSTRAINT [PK_Leaves] PRIMARY KEY CLUSTERED 
(
	[leaveID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveHistory]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[employeeID] [int] NOT NULL,
	[leaveID] [int] NOT NULL,
	[ReleaseTime] [datetime] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Appendix] [nvarchar](max) NULL,
	[LeaveHours] [int] NULL,
 CONSTRAINT [PK_LeaveHistories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveHistoryApprovalTemp]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveHistoryApprovalTemp](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[employeeID] [int] NOT NULL,
	[leaveID] [int] NOT NULL,
	[ReleaseTime] [datetime] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Appendix] [nvarchar](max) NULL,
	[LeaveHours] [int] NULL,
	[GroupLeader] [int] NULL,
	[GroupLeaderSignTime] [datetime] NULL,
	[DepartmentLeader] [int] NULL,
	[DepartmentLeaderSignTime] [datetime] NULL,
	[GeneralManager] [int] NULL,
	[GeneralManagerSignTime] [datetime] NULL,
	[Status] [nvarchar](16) NULL,
	[SignState] [bit] NOT NULL,
	[Reject] [bit] NOT NULL,
 CONSTRAINT [PK_LeaveHistoryApprovalTemps] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeetingRoom]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingRoom](
	[meetingID] [nvarchar](50) NOT NULL,
	[meetingName] [nvarchar](50) NOT NULL,
	[officeID] [int] NULL,
	[max_member] [int] NULL,
	[RoomAddress] [nvarchar](50) NULL,
 CONSTRAINT [PK_MeetingRooms] PRIMARY KEY CLUSTERED 
(
	[meetingID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeetingRoomHistory]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingRoomHistory](
	[MeetingRoomID] [int] IDENTITY(1,1) NOT NULL,
	[meetingID] [nvarchar](50) NULL,
	[start_date_time] [datetime] NULL,
	[end_date_time] [datetime] NOT NULL,
	[employeeID] [int] NULL,
 CONSTRAINT [PK_MeetingRoomHistories] PRIMARY KEY CLUSTERED 
(
	[MeetingRoomID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 2020/1/9 上午 09:11:10 ******/
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
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Office]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Office](
	[officeID] [int] NOT NULL,
	[office_name] [nvarchar](20) NULL,
	[office_address] [nvarchar](60) NULL,
 CONSTRAINT [PK_Offices] PRIMARY KEY CLUSTERED 
(
	[officeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[Note] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice]  AS ([Unitprice]*[Quantity]),
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[positionID] [int] NOT NULL,
	[position] [nvarchar](15) NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[positionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipient]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipient](
	[MessageID] [bigint] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[RecipientID] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Recipients] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC,
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reply]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reply](
	[ReplyID] [int] NOT NULL,
	[CommentTypeID] [int] NULL,
	[ReplyContent] [nvarchar](50) NULL,
	[EmployeeID] [int] NULL,
	[ReplyTime] [datetime] NULL,
 CONSTRAINT [PK_Replies] PRIMARY KEY CLUSTERED 
(
	[ReplyID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportCategory]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportCategory](
	[ReportID] [int] NOT NULL,
	[ReportName] [nvarchar](10) NULL,
 CONSTRAINT [PK_ReportCategories] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportTimeSystem]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportTimeSystem](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[ReportName] [nvarchar](10) NOT NULL,
	[employeeID] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[EventHours] [float] NOT NULL,
	[EventID] [int] NOT NULL,
	[Note] [nvarchar](50) NULL,
	[ApplyDateTime] [datetime] NOT NULL,
	[Discontinue] [bit] NULL,
 CONSTRAINT [PK_ReportTimeSystems] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequisitionMain]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequisitionMain](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NULL,
	[EmployeeID] [int] NULL,
	[RequisitionDate] [datetime] NULL,
	[Price] [money] NULL,
	[ApprovalStatusID] [int] NULL,
	[ApprovaStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_RequisitionMains] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RewardandPunishment]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RewardandPunishment](
	[Reward_PunishmentID] [nchar](10) NOT NULL,
	[Reward_PunishmentName] [nchar](10) NULL,
 CONSTRAINT [PK_RewardandPunishments] PRIMARY KEY CLUSTERED 
(
	[Reward_PunishmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScoresLab]    Script Date: 2020/1/9 上午 09:11:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScoresLab](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[class] [nvarchar](6) NULL,
	[subject] [nvarchar](6) NULL,
	[score] [int] NULL,
 CONSTRAINT [PK_ScoresLab] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suggestion]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suggestion](
	[suggestionID] [nchar](10) NOT NULL,
	[suggestion1] [nchar](30) NULL,
 CONSTRAINT [PK_Suggestions] PRIMARY KEY CLUSTERED 
(
	[suggestionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuggestionHistory]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuggestionHistory](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[employeeID] [int] NULL,
	[departmentID] [int] NULL,
	[suggestionID] [nchar](10) NULL,
	[content] [nvarchar](100) NULL,
 CONSTRAINT [PK_SuggestionHistories] PRIMARY KEY CLUSTERED 
(
	[num] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurveyMain]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyMain](
	[SurveyID] [int] NULL,
	[QuestionID] [bigint] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](50) NULL,
 CONSTRAINT [PK_SurveyMains] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagram]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagram](
	[name] [nvarchar](128) NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
 CONSTRAINT [PK_sysdiagrams] PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ActivitiesChild_ActivitiesMain]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActivitiesChild_ActivitiesMain] ON [dbo].[ActivitiesChild]
(
	[ActicityMainID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ActivitiesChild_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActivitiesChild_Employee] ON [dbo].[ActivitiesChild]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ActivitiesMain_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActivitiesMain_Employee] ON [dbo].[ActivitiesMain]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Approval_ApprovalProcedure]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Approval_ApprovalProcedure] ON [dbo].[Approval]
(
	[ApprovalProcedureID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Bulletin_board_Department]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Bulletin_board_Department] ON [dbo].[BulletinBoard]
(
	[DepartmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Bulletin_board_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Bulletin_board_Employee] ON [dbo].[BulletinBoard]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Bulletin_board_Group]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Bulletin_board_Group] ON [dbo].[BulletinBoard]
(
	[GroupID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_BulletinBoard_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_BulletinBoard_Employee] ON [dbo].[BulletinBoard]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CommentChild_CommentMain1]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CommentChild_CommentMain1] ON [dbo].[CommentChild]
(
	[CommentMainID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CommentChild_CommentQuestion]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CommentChild_CommentQuestion] ON [dbo].[CommentChild]
(
	[CommentQuestionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CommentChild_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CommentChild_Employee] ON [dbo].[CommentChild]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CommentContent_CommentOption]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CommentContent_CommentOption] ON [dbo].[CommentContent]
(
	[CommentOptionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CommentMain_ActivitiesMain]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CommentMain_ActivitiesMain] ON [dbo].[CommentMain]
(
	[ActivityMainID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CommentMain_CommentContent1]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CommentMain_CommentContent1] ON [dbo].[CommentMain]
(
	[CommentContentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CommentMain_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CommentMain_Employee] ON [dbo].[CommentMain]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CommentQuestion_CommentContent]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CommentQuestion_CommentContent] ON [dbo].[CommentQuestion]
(
	[CommentContentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Company_vehicle_Office]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Company_vehicle_Office] ON [dbo].[CompanyVehicle]
(
	[officeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_Company_vehicle_history_Company_vehicle]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Company_vehicle_history_Company_vehicle] ON [dbo].[CompanyVehicleHistory]
(
	[LicenseNumber] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Company_vehicle_history_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Company_vehicle_history_Employee] ON [dbo].[CompanyVehicleHistory]
(
	[employeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Employee_Department]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Employee_Department] ON [dbo].[Employee]
(
	[DepartmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Employee_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Employee_Employee] ON [dbo].[Employee]
(
	[ManagerID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Employee_Group]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Employee_Group] ON [dbo].[Employee]
(
	[GroupID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Employee_Office]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Employee_Office] ON [dbo].[Employee]
(
	[OfficeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Employee_Position]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Employee_Position] ON [dbo].[Employee]
(
	[PositionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EmployeeApprovalTemp_Department]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeApprovalTemp_Department] ON [dbo].[EmployeeApprovalTemp]
(
	[DepartmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EmployeeApprovalTemp_DepartmentLeaderByEmployee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeApprovalTemp_DepartmentLeaderByEmployee] ON [dbo].[EmployeeApprovalTemp]
(
	[DepartmentLeaderID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EmployeeApprovalTemp_EditorByEmployee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeApprovalTemp_EditorByEmployee] ON [dbo].[EmployeeApprovalTemp]
(
	[Editor] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EmployeeApprovalTemp_Group]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeApprovalTemp_Group] ON [dbo].[EmployeeApprovalTemp]
(
	[GroupID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EmployeeApprovalTemp_GroupLeaderByEmployee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeApprovalTemp_GroupLeaderByEmployee] ON [dbo].[EmployeeApprovalTemp]
(
	[GroupLeaderID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EmployeeApprovalTemp_ManagerByEmployee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeApprovalTemp_ManagerByEmployee] ON [dbo].[EmployeeApprovalTemp]
(
	[ManagerID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EmployeeApprovalTemp_Office]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeApprovalTemp_Office] ON [dbo].[EmployeeApprovalTemp]
(
	[OfficeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EmployeeApprovalTemp_Position]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeApprovalTemp_Position] ON [dbo].[EmployeeApprovalTemp]
(
	[PositionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EventCalendar_Department]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EventCalendar_Department] ON [dbo].[EventCalendar]
(
	[DepartmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EventCalendar_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EventCalendar_Employee] ON [dbo].[EventCalendar]
(
	[employeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_File_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_File_Employee] ON [dbo].[File]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Group_Department]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Group_Department] ON [dbo].[Group]
(
	[DepartmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LeaveHistory_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LeaveHistory_Employee] ON [dbo].[LeaveHistory]
(
	[employeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LeaveHistory_Leave]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LeaveHistory_Leave] ON [dbo].[LeaveHistory]
(
	[leaveID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LeaveHistoryApprovalTemp_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LeaveHistoryApprovalTemp_Employee] ON [dbo].[LeaveHistoryApprovalTemp]
(
	[employeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LeaveHistoryApprovalTemp_EmployeeByDepartmentLeader]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LeaveHistoryApprovalTemp_EmployeeByDepartmentLeader] ON [dbo].[LeaveHistoryApprovalTemp]
(
	[DepartmentLeader] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LeaveHistoryApprovalTemp_EmployeeByGM]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LeaveHistoryApprovalTemp_EmployeeByGM] ON [dbo].[LeaveHistoryApprovalTemp]
(
	[GeneralManager] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LeaveHistoryApprovalTemp_EmployeeByGroupLeader]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LeaveHistoryApprovalTemp_EmployeeByGroupLeader] ON [dbo].[LeaveHistoryApprovalTemp]
(
	[GroupLeader] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LeaveHistoryApprovalTemp_Leave]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LeaveHistoryApprovalTemp_Leave] ON [dbo].[LeaveHistoryApprovalTemp]
(
	[leaveID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Meeting_room_Office]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Meeting_room_Office] ON [dbo].[MeetingRoom]
(
	[officeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Meeting_room_history_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Meeting_room_history_Employee] ON [dbo].[MeetingRoomHistory]
(
	[employeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_Meeting_room_history_Meeting_room]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Meeting_room_history_Meeting_room] ON [dbo].[MeetingRoomHistory]
(
	[meetingID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Message_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Message_Employee] ON [dbo].[Message]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_OrderDetail_RequisitionMain1]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_OrderDetail_RequisitionMain1] ON [dbo].[OrderDetail]
(
	[OrderID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Recipient_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Recipient_Employee] ON [dbo].[Recipient]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Reply_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Reply_Employee] ON [dbo].[Reply]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ReportTimeSystem_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ReportTimeSystem_Employee] ON [dbo].[ReportTimeSystem]
(
	[employeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ReportTimeSystem_Event]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ReportTimeSystem_Event] ON [dbo].[ReportTimeSystem]
(
	[EventID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_RequisitionMain_ApprovalStatus]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_RequisitionMain_ApprovalStatus] ON [dbo].[RequisitionMain]
(
	[ApprovalStatusID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_RequisitionMain_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_RequisitionMain_Employee] ON [dbo].[RequisitionMain]
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_RequisitionMain_ReportCategory]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_RequisitionMain_ReportCategory] ON [dbo].[RequisitionMain]
(
	[ReportID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Suggestion_history_Department]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Suggestion_history_Department] ON [dbo].[SuggestionHistory]
(
	[departmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Suggestion_history_Employee]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Suggestion_history_Employee] ON [dbo].[SuggestionHistory]
(
	[employeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_Suggestion_history_Suggestion]    Script Date: 2020/1/9 上午 09:11:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Suggestion_history_Suggestion] ON [dbo].[SuggestionHistory]
(
	[suggestionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActivitiesChild]  WITH CHECK ADD  CONSTRAINT [FK_ActivitiesChild_ActivitiesMain] FOREIGN KEY([ActicityMainID])
REFERENCES [dbo].[ActivitiesMain] ([ActivityMainID])
GO
ALTER TABLE [dbo].[ActivitiesChild] CHECK CONSTRAINT [FK_ActivitiesChild_ActivitiesMain]
GO
ALTER TABLE [dbo].[ActivitiesChild]  WITH CHECK ADD  CONSTRAINT [FK_ActivitiesChild_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[ActivitiesChild] CHECK CONSTRAINT [FK_ActivitiesChild_Employee]
GO
ALTER TABLE [dbo].[ActivitiesMain]  WITH CHECK ADD  CONSTRAINT [FK_ActivitiesMain_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[ActivitiesMain] CHECK CONSTRAINT [FK_ActivitiesMain_Employee]
GO
ALTER TABLE [dbo].[Approval]  WITH CHECK ADD  CONSTRAINT [FK_Approval_ApprovalProcedure] FOREIGN KEY([ApprovalProcedureID])
REFERENCES [dbo].[ApprovalProcedure] ([ApprovalProcedureID])
GO
ALTER TABLE [dbo].[Approval] CHECK CONSTRAINT [FK_Approval_ApprovalProcedure]
GO
ALTER TABLE [dbo].[Approval]  WITH CHECK ADD  CONSTRAINT [FK_Approval_RequisitionMain] FOREIGN KEY([OrderID])
REFERENCES [dbo].[RequisitionMain] ([OrderID])
GO
ALTER TABLE [dbo].[Approval] CHECK CONSTRAINT [FK_Approval_RequisitionMain]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BulletinBoard]  WITH CHECK ADD  CONSTRAINT [FK_Bulletin_board_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[BulletinBoard] CHECK CONSTRAINT [FK_Bulletin_board_Department]
GO
ALTER TABLE [dbo].[BulletinBoard]  WITH CHECK ADD  CONSTRAINT [FK_Bulletin_board_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[BulletinBoard] CHECK CONSTRAINT [FK_Bulletin_board_Employee]
GO
ALTER TABLE [dbo].[BulletinBoard]  WITH CHECK ADD  CONSTRAINT [FK_Bulletin_board_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[BulletinBoard] CHECK CONSTRAINT [FK_Bulletin_board_Group]
GO
ALTER TABLE [dbo].[BulletinBoard]  WITH CHECK ADD  CONSTRAINT [FK_BulletinBoard_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[BulletinBoard] CHECK CONSTRAINT [FK_BulletinBoard_Employee]
GO
ALTER TABLE [dbo].[CommentChild]  WITH CHECK ADD  CONSTRAINT [FK_CommentChild_CommentMain1] FOREIGN KEY([CommentMainID])
REFERENCES [dbo].[CommentMain] ([CommentMainID])
GO
ALTER TABLE [dbo].[CommentChild] CHECK CONSTRAINT [FK_CommentChild_CommentMain1]
GO
ALTER TABLE [dbo].[CommentChild]  WITH CHECK ADD  CONSTRAINT [FK_CommentChild_CommentQuestion] FOREIGN KEY([CommentQuestionID])
REFERENCES [dbo].[CommentQuestion] ([CommentQuestionID])
GO
ALTER TABLE [dbo].[CommentChild] CHECK CONSTRAINT [FK_CommentChild_CommentQuestion]
GO
ALTER TABLE [dbo].[CommentChild]  WITH CHECK ADD  CONSTRAINT [FK_CommentChild_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[CommentChild] CHECK CONSTRAINT [FK_CommentChild_Employee]
GO
ALTER TABLE [dbo].[CommentContent]  WITH CHECK ADD  CONSTRAINT [FK_CommentContent_CommentOption] FOREIGN KEY([CommentOptionID])
REFERENCES [dbo].[CommentOption] ([CommentOptionID])
GO
ALTER TABLE [dbo].[CommentContent] CHECK CONSTRAINT [FK_CommentContent_CommentOption]
GO
ALTER TABLE [dbo].[CommentMain]  WITH CHECK ADD  CONSTRAINT [FK_CommentMain_ActivitiesMain] FOREIGN KEY([ActivityMainID])
REFERENCES [dbo].[ActivitiesMain] ([ActivityMainID])
GO
ALTER TABLE [dbo].[CommentMain] CHECK CONSTRAINT [FK_CommentMain_ActivitiesMain]
GO
ALTER TABLE [dbo].[CommentMain]  WITH CHECK ADD  CONSTRAINT [FK_CommentMain_CommentContent1] FOREIGN KEY([CommentContentID])
REFERENCES [dbo].[CommentContent] ([CommentContentID])
GO
ALTER TABLE [dbo].[CommentMain] CHECK CONSTRAINT [FK_CommentMain_CommentContent1]
GO
ALTER TABLE [dbo].[CommentMain]  WITH CHECK ADD  CONSTRAINT [FK_CommentMain_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[CommentMain] CHECK CONSTRAINT [FK_CommentMain_Employee]
GO
ALTER TABLE [dbo].[CommentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_CommentQuestion_CommentContent] FOREIGN KEY([CommentContentID])
REFERENCES [dbo].[CommentContent] ([CommentContentID])
GO
ALTER TABLE [dbo].[CommentQuestion] CHECK CONSTRAINT [FK_CommentQuestion_CommentContent]
GO
ALTER TABLE [dbo].[CommentReply]  WITH CHECK ADD  CONSTRAINT [FK_CommentReply_CommentChild] FOREIGN KEY([ChildNum])
REFERENCES [dbo].[CommentChild] ([ChildNum])
GO
ALTER TABLE [dbo].[CommentReply] CHECK CONSTRAINT [FK_CommentReply_CommentChild]
GO
ALTER TABLE [dbo].[CommentReply]  WITH CHECK ADD  CONSTRAINT [FK_CommentReply_CommentChild1] FOREIGN KEY([ChildNum])
REFERENCES [dbo].[CommentChild] ([ChildNum])
GO
ALTER TABLE [dbo].[CommentReply] CHECK CONSTRAINT [FK_CommentReply_CommentChild1]
GO
ALTER TABLE [dbo].[CommentReply]  WITH CHECK ADD  CONSTRAINT [FK_CommentReply_CommentMain] FOREIGN KEY([CommentMainID])
REFERENCES [dbo].[CommentMain] ([CommentMainID])
GO
ALTER TABLE [dbo].[CommentReply] CHECK CONSTRAINT [FK_CommentReply_CommentMain]
GO
ALTER TABLE [dbo].[CompanyVehicle]  WITH CHECK ADD  CONSTRAINT [FK_Company_vehicle_Office] FOREIGN KEY([officeID])
REFERENCES [dbo].[Office] ([officeID])
GO
ALTER TABLE [dbo].[CompanyVehicle] CHECK CONSTRAINT [FK_Company_vehicle_Office]
GO
ALTER TABLE [dbo].[CompanyVehicleHistory]  WITH CHECK ADD  CONSTRAINT [FK_Company_vehicle_history_Company_vehicle] FOREIGN KEY([LicenseNumber])
REFERENCES [dbo].[CompanyVehicle] ([LicenseNumber])
GO
ALTER TABLE [dbo].[CompanyVehicleHistory] CHECK CONSTRAINT [FK_Company_vehicle_history_Company_vehicle]
GO
ALTER TABLE [dbo].[CompanyVehicleHistory]  WITH CHECK ADD  CONSTRAINT [FK_Company_vehicle_history_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[CompanyVehicleHistory] CHECK CONSTRAINT [FK_Company_vehicle_history_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Group]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Office] FOREIGN KEY([OfficeID])
REFERENCES [dbo].[Office] ([officeID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Office]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Position] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Position] ([positionID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Position]
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeApprovalTemp_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp] CHECK CONSTRAINT [FK_EmployeeApprovalTemp_Department]
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeApprovalTemp_DepartmentLeaderByEmployee] FOREIGN KEY([DepartmentLeaderID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp] CHECK CONSTRAINT [FK_EmployeeApprovalTemp_DepartmentLeaderByEmployee]
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeApprovalTemp_EditorByEmployee] FOREIGN KEY([Editor])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp] CHECK CONSTRAINT [FK_EmployeeApprovalTemp_EditorByEmployee]
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeApprovalTemp_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp] CHECK CONSTRAINT [FK_EmployeeApprovalTemp_Group]
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeApprovalTemp_GroupLeaderByEmployee] FOREIGN KEY([GroupLeaderID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp] CHECK CONSTRAINT [FK_EmployeeApprovalTemp_GroupLeaderByEmployee]
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeApprovalTemp_ManagerByEmployee] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp] CHECK CONSTRAINT [FK_EmployeeApprovalTemp_ManagerByEmployee]
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeApprovalTemp_Office] FOREIGN KEY([OfficeID])
REFERENCES [dbo].[Office] ([officeID])
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp] CHECK CONSTRAINT [FK_EmployeeApprovalTemp_Office]
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeApprovalTemp_Position] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Position] ([positionID])
GO
ALTER TABLE [dbo].[EmployeeApprovalTemp] CHECK CONSTRAINT [FK_EmployeeApprovalTemp_Position]
GO
ALTER TABLE [dbo].[EventCalendar]  WITH CHECK ADD  CONSTRAINT [FK_EventCalendar_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[EventCalendar] CHECK CONSTRAINT [FK_EventCalendar_Department]
GO
ALTER TABLE [dbo].[EventCalendar]  WITH CHECK ADD  CONSTRAINT [FK_EventCalendar_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[EventCalendar] CHECK CONSTRAINT [FK_EventCalendar_Employee]
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
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_LeaveHistoryApprovalTemp_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp] CHECK CONSTRAINT [FK_LeaveHistoryApprovalTemp_Employee]
GO
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_LeaveHistoryApprovalTemp_EmployeeByDepartmentLeader] FOREIGN KEY([DepartmentLeader])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp] CHECK CONSTRAINT [FK_LeaveHistoryApprovalTemp_EmployeeByDepartmentLeader]
GO
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_LeaveHistoryApprovalTemp_EmployeeByGM] FOREIGN KEY([GeneralManager])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp] CHECK CONSTRAINT [FK_LeaveHistoryApprovalTemp_EmployeeByGM]
GO
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_LeaveHistoryApprovalTemp_EmployeeByGroupLeader] FOREIGN KEY([GroupLeader])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp] CHECK CONSTRAINT [FK_LeaveHistoryApprovalTemp_EmployeeByGroupLeader]
GO
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp]  WITH CHECK ADD  CONSTRAINT [FK_LeaveHistoryApprovalTemp_Leave] FOREIGN KEY([leaveID])
REFERENCES [dbo].[Leave] ([leaveID])
GO
ALTER TABLE [dbo].[LeaveHistoryApprovalTemp] CHECK CONSTRAINT [FK_LeaveHistoryApprovalTemp_Leave]
GO
ALTER TABLE [dbo].[MeetingRoom]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_room_Office] FOREIGN KEY([officeID])
REFERENCES [dbo].[Office] ([officeID])
GO
ALTER TABLE [dbo].[MeetingRoom] CHECK CONSTRAINT [FK_Meeting_room_Office]
GO
ALTER TABLE [dbo].[MeetingRoomHistory]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_room_history_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[MeetingRoomHistory] CHECK CONSTRAINT [FK_Meeting_room_history_Employee]
GO
ALTER TABLE [dbo].[MeetingRoomHistory]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_room_history_Meeting_room] FOREIGN KEY([meetingID])
REFERENCES [dbo].[MeetingRoom] ([meetingID])
GO
ALTER TABLE [dbo].[MeetingRoomHistory] CHECK CONSTRAINT [FK_Meeting_room_history_Meeting_room]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_Employee]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_RequisitionMain1] FOREIGN KEY([OrderID])
REFERENCES [dbo].[RequisitionMain] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_RequisitionMain1]
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
ALTER TABLE [dbo].[Reply]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Reply] CHECK CONSTRAINT [FK_Reply_Employee]
GO
ALTER TABLE [dbo].[ReportTimeSystem]  WITH CHECK ADD  CONSTRAINT [FK_ReportTimeSystem_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[ReportTimeSystem] CHECK CONSTRAINT [FK_ReportTimeSystem_Employee]
GO
ALTER TABLE [dbo].[ReportTimeSystem]  WITH CHECK ADD  CONSTRAINT [FK_ReportTimeSystem_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[ReportTimeSystem] CHECK CONSTRAINT [FK_ReportTimeSystem_Event]
GO
ALTER TABLE [dbo].[RequisitionMain]  WITH CHECK ADD  CONSTRAINT [FK_RequisitionMain_ApprovalStatus] FOREIGN KEY([ApprovalStatusID])
REFERENCES [dbo].[ApprovalStatus] ([ApprovalStatusID])
GO
ALTER TABLE [dbo].[RequisitionMain] CHECK CONSTRAINT [FK_RequisitionMain_ApprovalStatus]
GO
ALTER TABLE [dbo].[RequisitionMain]  WITH CHECK ADD  CONSTRAINT [FK_RequisitionMain_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[RequisitionMain] CHECK CONSTRAINT [FK_RequisitionMain_Employee]
GO
ALTER TABLE [dbo].[RequisitionMain]  WITH CHECK ADD  CONSTRAINT [FK_RequisitionMain_ReportCategory] FOREIGN KEY([ReportID])
REFERENCES [dbo].[ReportCategory] ([ReportID])
GO
ALTER TABLE [dbo].[RequisitionMain] CHECK CONSTRAINT [FK_RequisitionMain_ReportCategory]
GO
ALTER TABLE [dbo].[SuggestionHistory]  WITH CHECK ADD  CONSTRAINT [FK_Suggestion_history_Department] FOREIGN KEY([departmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[SuggestionHistory] CHECK CONSTRAINT [FK_Suggestion_history_Department]
GO
ALTER TABLE [dbo].[SuggestionHistory]  WITH CHECK ADD  CONSTRAINT [FK_Suggestion_history_Employee] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[SuggestionHistory] CHECK CONSTRAINT [FK_Suggestion_history_Employee]
GO
ALTER TABLE [dbo].[SuggestionHistory]  WITH CHECK ADD  CONSTRAINT [FK_Suggestion_history_Suggestion] FOREIGN KEY([suggestionID])
REFERENCES [dbo].[Suggestion] ([suggestionID])
GO
ALTER TABLE [dbo].[SuggestionHistory] CHECK CONSTRAINT [FK_Suggestion_history_Suggestion]
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 2020/1/9 上午 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
ALTER DATABASE [BusinessDataBase] SET  READ_WRITE 
GO
