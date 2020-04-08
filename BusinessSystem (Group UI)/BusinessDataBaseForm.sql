USE [BusinessDataBase]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivitiesChild]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivitiesMain]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Approval]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalProcedure]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalStatus]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BulletinBoard]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[C__MigrationHistory]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentChild]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentContent]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentMain]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentOption]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentQuestion]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentReply]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyVehicle]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyVehicleHistory]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeApprovalTemp]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventCalendar]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[File]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveHistory]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveHistoryApprovalTemp]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeetingRoom]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeetingRoomHistory]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Office]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipient]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reply]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportCategory]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportTimeSystem]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequisitionMain]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RewardandPunishment]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScoresLab]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suggestion]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuggestionHistory]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurveyMain]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagram]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'arina', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'arther', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'baldbrother', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'evette', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'jennifer', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'jenny', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'jocelyn', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'johnwick', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'kai', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'maeshin', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'marylin', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'memewang', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'mengmeng', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'NA', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'reeves', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'reshin', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'reshinfang', 0xEC278A38901287B2771A13739520384D43E4B078F78AFFE702DEF108774CCE24)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'rorychang', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'wengweng', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'wuwulin', NULL)
INSERT [dbo].[Account] ([account1], [password]) VALUES (N'youngshang', NULL)
INSERT [dbo].[Approval] ([OrderID], [ApprovalProcedureID], [FirstSignerID], [FirstSignerName], [FirstSignStatus], [FirstSignDate], [SecondSignerID], [SecondSignerName], [SecondSignStatus], [SecondSignDate], [ThirdSignerID], [ThirdSignerName], [ThirdSignStatus], [ThirdSignDate], [FourthSignerID], [FourthSignerName], [FourthSignStatus], [ForthSignDate]) VALUES (65, 5, 1010, N'杜美心', N'已審核', CAST(N'2019-12-25T10:01:32.353' AS DateTime), 1008, N'黃阿聖', N'已審核', CAST(N'2019-12-25T10:01:42.800' AS DateTime), NULL, N'-----', N'免審核', NULL, 1013, N'林美宋', N'已審核', CAST(N'2019-12-25T10:02:28.820' AS DateTime))
INSERT [dbo].[Approval] ([OrderID], [ApprovalProcedureID], [FirstSignerID], [FirstSignerName], [FirstSignStatus], [FirstSignDate], [SecondSignerID], [SecondSignerName], [SecondSignStatus], [SecondSignDate], [ThirdSignerID], [ThirdSignerName], [ThirdSignStatus], [ThirdSignDate], [FourthSignerID], [FourthSignerName], [FourthSignStatus], [ForthSignDate]) VALUES (66, 6, 1010, N'杜美心', N'已審核', CAST(N'2019-12-25T10:01:34.257' AS DateTime), 1008, N'黃阿聖', N'已審核', CAST(N'2019-12-25T10:01:44.447' AS DateTime), 1004, N'吳瑋瑋', N'駁回簽核', CAST(N'2019-12-25T10:02:15.760' AS DateTime), 1013, N'林美宋', N'未審核', NULL)
INSERT [dbo].[ApprovalProcedure] ([ApprovalProcedureID], [PositionID], [ApprovalReportName], [ApprovalSupervisor], [ApprovalDirector], [ApprovalGenalManager], [ApprovalFinancialDirector]) VALUES (1, 4, N'組員請假(<3天)', 1, 0, 0, 0)
INSERT [dbo].[ApprovalProcedure] ([ApprovalProcedureID], [PositionID], [ApprovalReportName], [ApprovalSupervisor], [ApprovalDirector], [ApprovalGenalManager], [ApprovalFinancialDirector]) VALUES (2, 4, N'組員請假(>3天)', 1, 1, 0, 0)
INSERT [dbo].[ApprovalProcedure] ([ApprovalProcedureID], [PositionID], [ApprovalReportName], [ApprovalSupervisor], [ApprovalDirector], [ApprovalGenalManager], [ApprovalFinancialDirector]) VALUES (3, 3, N'組長請假', 0, 1, 0, 0)
INSERT [dbo].[ApprovalProcedure] ([ApprovalProcedureID], [PositionID], [ApprovalReportName], [ApprovalSupervisor], [ApprovalDirector], [ApprovalGenalManager], [ApprovalFinancialDirector]) VALUES (4, 2, N'部長請假', 0, 0, 1, 0)
INSERT [dbo].[ApprovalProcedure] ([ApprovalProcedureID], [PositionID], [ApprovalReportName], [ApprovalSupervisor], [ApprovalDirector], [ApprovalGenalManager], [ApprovalFinancialDirector]) VALUES (5, 4, N'組員請購(<10000元)', 1, 1, 0, 1)
INSERT [dbo].[ApprovalProcedure] ([ApprovalProcedureID], [PositionID], [ApprovalReportName], [ApprovalSupervisor], [ApprovalDirector], [ApprovalGenalManager], [ApprovalFinancialDirector]) VALUES (6, 4, N'組員請購(>10000元)', 1, 1, 1, 1)
INSERT [dbo].[ApprovalProcedure] ([ApprovalProcedureID], [PositionID], [ApprovalReportName], [ApprovalSupervisor], [ApprovalDirector], [ApprovalGenalManager], [ApprovalFinancialDirector]) VALUES (7, 4, N'組員出差', 1, 0, 0, 0)
INSERT [dbo].[ApprovalProcedure] ([ApprovalProcedureID], [PositionID], [ApprovalReportName], [ApprovalSupervisor], [ApprovalDirector], [ApprovalGenalManager], [ApprovalFinancialDirector]) VALUES (8, 3, N'組長出差', 0, 1, 0, 0)
INSERT [dbo].[ApprovalProcedure] ([ApprovalProcedureID], [PositionID], [ApprovalReportName], [ApprovalSupervisor], [ApprovalDirector], [ApprovalGenalManager], [ApprovalFinancialDirector]) VALUES (9, 2, N'部長出差', 0, 0, 1, 0)
INSERT [dbo].[ApprovalStatus] ([ApprovalStatusID], [StatusName]) VALUES (1, N'審核駁回')
INSERT [dbo].[ApprovalStatus] ([ApprovalStatusID], [StatusName]) VALUES (2, N'審核中')
INSERT [dbo].[ApprovalStatus] ([ApprovalStatusID], [StatusName]) VALUES (3, N'審核完成')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0', N'GeneralManager')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'HRGroup')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'AdministrativeDepartment')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'DepartmentLeader')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4', N'GroupLeader')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5', N'Employee')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6', N'HRLeaders')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7', N'GALeaders')
SET IDENTITY_INSERT [dbo].[AspNetUserRoles] ON 

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'de961d70-7d4c-4d32-a93e-d59a9fb7e110', N'0', 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'b54db844-9708-4a8b-9cce-307a3d84c8cc', N'3', 2)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'b54db844-9708-4a8b-9cce-307a3d84c8cc', N'6', 3)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'b54db844-9708-4a8b-9cce-307a3d84c8cc', N'1', 4)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'ef5d54e9-500b-4031-b981-8bf8b2a6adf9', N'6', 5)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'ef5d54e9-500b-4031-b981-8bf8b2a6adf9', N'4', 6)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'ef5d54e9-500b-4031-b981-8bf8b2a6adf9', N'1', 7)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'45fc832c-ad3f-4fbf-9e13-54ee0c2e5a54', N'1', 8)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'da0b19d1-6a51-4718-bf0e-b71eaf6ae2db', N'4', 9)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'da0b19d1-6a51-4718-bf0e-b71eaf6ae2db', N'7', 10)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'b54db844-9708-4a8b-9cce-307a3d84c8cc', N'7', 11)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'a6f94714-df77-4003-b111-7253c6e60fc4', N'4', 12)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'b30540fd-d485-4754-a32f-1ec788fdfe38', N'3', 14)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'458f281a-36a6-470f-a67c-9b3c4fd06b2d', N'3', 15)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'd6c2af84-d2dc-4063-90a7-a6d07806e2cc', N'3', 16)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'e507b102-07f5-4e7b-8701-ca87b710227e', N'3', 17)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'b54db844-9708-4a8b-9cce-307a3d84c8cc', N'2', 22)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'ef5d54e9-500b-4031-b981-8bf8b2a6adf9', N'2', 23)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'45fc832c-ad3f-4fbf-9e13-54ee0c2e5a54', N'2', 24)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [id]) VALUES (N'da0b19d1-6a51-4718-bf0e-b71eaf6ae2db', N'2', 25)
SET IDENTITY_INSERT [dbo].[AspNetUserRoles] OFF
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'03547c64-3ef9-458f-a89a-3e3eac97da0a', N'baldbrother@msit.com', 0, N'AORPW8NGzACisERHQo/wkEuhlrXlV26k93sdJKDtih76EiFxl07y1CiXrgnJs5QV2Q==', N'0bf76566-ff2d-413b-94e5-8a655d13e067', NULL, 0, 0, NULL, 1, 0, N'baldbrother')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'255ab494-22c9-4eba-a62b-829f4f831bba', N'memewang@msit.com', 0, N'AOIJSefBVSZD2n1BUG5+iCpjfoM7aI5KfqfXFCeGn0CPGBakxCV8AxRX5VqK7KZjcw==', N'93ea6424-b179-4929-9209-a82261693eea', NULL, 0, 0, NULL, 1, 0, N'memewang')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'458f281a-36a6-470f-a67c-9b3c4fd06b2d', N'rorychang@msit.com', 0, N'AF016Vmvt0OvcEvESdtXPkYTaewnrXw4cXUOhLHQDhhsTIyeiGDpxGVZTByd4VWFuw==', N'b1c9a545-5cf9-4e91-892d-6e03254619fa', NULL, 0, 0, NULL, 1, 0, N'rorychang')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'45fc832c-ad3f-4fbf-9e13-54ee0c2e5a54', N'reshin@msit.com', 0, N'AGtWG4CJH3ioIhPy+8IGFsHqEDe2PbhsCuZWHRpa2JWNtBb0Em7cpIxn57UCz6Y1BQ==', N'02c4a6c2-0c0b-4d7b-9e91-e93fc994c9c5', NULL, 0, 0, NULL, 1, 0, N'reshin')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4ecf4b05-7d1a-4ed9-8b52-581e59d1deb8', N'mingwang@msit.com', 0, N'AFMs7w1egc/88jZZkboqwJCEXsVx4BiP3IqDa7wqJZMxHL7WLG7fLN/jj36A0H4ySA==', N'526aed5b-22f6-4330-ab42-19b8033febf5', NULL, 0, 0, NULL, 1, 0, N'mingwang')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'55f90091-5cfc-483b-b07d-94ae73ccbdb2', N'jenny@msit.com', 0, N'ADZOAXJ0YOCtI5g6UAdE89QsD585jnRgLUWDVKBADgBeJgkhT3IPMnLuGuyPiIsmuA==', N'cd539b58-4d19-4257-8751-2e564abd5175', NULL, 0, 0, NULL, 1, 0, N'jenny')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6874e37b-be93-459b-8745-f5f78d5edac1', N'shianko@msit.com', 0, N'AII/LwoPgjeju8d2li7GboeR/2WktQ4+Ssjcw7juAFk67vi7eTd4/dYq5QH1Mim8dQ==', N'9a2c8852-ee25-4ba3-9fa0-3dc5d889a541', NULL, 0, 0, NULL, 1, 0, N'shianko')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7deec67a-b004-4b29-a879-60474bb8714e', N'chinesetsai@msit.com', 0, N'AFQXCffo0kRW0/0bnG1WEs17WWrkCmdxluavuy30oalwSRv8lVZmT7o2yJZqjTQAsQ==', N'36a9fc1a-572c-4b1a-9766-905be45c2b53', NULL, 0, 0, NULL, 1, 0, N'chinesetsai')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'95570a63-5de9-4b1e-b62e-0e4a9b2fb1d0', N'reeves@msit.com', 0, N'AJxmCdTiuYQNZIfozpB5LhPUim/+a7YFogB0rg8Kg671gIA46Q3NTAeAANLQpP78dA==', N'fc35925e-e4f4-439d-81c4-c2d72a6c926d', NULL, 0, 0, NULL, 1, 0, N'reeves')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a6f94714-df77-4003-b111-7253c6e60fc4', N'arther@msit.com', 0, N'ABY0A0xGAzGltXMbudbsHke/C4CdElSNB6xIe8YA6suI8NwH+J7XpocUHzyTmt8GrQ==', N'7d670dcf-33a3-4e9f-b318-d3d5e40402bd', NULL, 0, 0, NULL, 1, 0, N'arther')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b30540fd-d485-4754-a32f-1ec788fdfe38', N'kai@msit.com', 0, N'AIRPeFJwGk4w++p7vLLaKUbYyCodgrXiVnqQIAISh+kSz9HVJ3ovF6cn1iqjPzVjvw==', N'19448a0b-7f3e-4e94-a24a-0c47993b82d8', NULL, 0, 0, NULL, 1, 0, N'kai')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b54db844-9708-4a8b-9cce-307a3d84c8cc', N'youngshang@msit.com', 0, N'APR8sz91dXEPwXoFXq/cwudmiAfU6F+UIPLq7mv/ABXZzKD0Ia7/eKHkmlpznCNZ/Q==', N'ad1a0392-db32-4f2f-8bab-97ccb20ed3b1', NULL, 0, 0, NULL, 1, 0, N'youngshang')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b7e293d7-30cc-490d-83a8-6ee4b2bc4c8e', N'johnwick@msit.com', 0, N'AKDd4BxtRV5nCD8xwCnKAKLXBCZMTBOAsz/kgzenBqJM2phBiqKHf4GGIVnPbX4l0A==', N'2518c09f-1717-4161-ba5f-1a7cc5676e20', NULL, 0, 0, NULL, 1, 0, N'johnwick')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c051c8e7-f19e-4d20-8545-9aa6ec22eea0', N'wengweng@msit.com', 0, N'AC1XxiujoK22Nk/wOIBu0DvTKN+QJQ0PiAnQzxOkdUesFjryNxHEcldCBiefQzxDEA==', N'f12ebd9f-650c-41d6-8b55-6ecb446019c7', NULL, 0, 0, NULL, 1, 0, N'wengweng')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c9952e96-0ea6-46fc-8910-85984087b483', N'arina@msit.com', 0, N'AF8hiPaNEuL8dhok6lseSILcVeP/pbr1k4dltB8iFrVn7RuZn1vqcJGemzFYt/QuEA==', N'9f6b1729-7eeb-45c6-ac51-425191aff9a9', NULL, 0, 0, NULL, 1, 0, N'arina')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd6c2af84-d2dc-4063-90a7-a6d07806e2cc', N'jocelyn@msit.com', 0, N'AOLzwY45Z59iyW1/ajLdWcURF/Iz036heT6BL1+sVEb25ZWhy1PtQVnWa2Qsfaueiw==', N'6c62c654-53c1-4a30-bc08-426a6e30649e', NULL, 0, 0, NULL, 1, 0, N'jocelyn')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'da0b19d1-6a51-4718-bf0e-b71eaf6ae2db', N'marylin@msit.com', 0, N'ALWRN4MghnMQMEaazIojZKQUN6LRlV6WHGcSFTPIsZsAWHeNnG+3GVhcUnEu0r+Y7Q==', N'ca25dce0-bd84-49a1-9f95-2074b8fe3cf2', NULL, 0, 0, NULL, 1, 0, N'marylin')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de961d70-7d4c-4d32-a93e-d59a9fb7e110', N'jennifer@msit.com', 0, N'AIn0mWCufawE42b/wply1cD9HyF60AIYa+HkOFTPLoV7JuvN8KKOFu2lTIPRb5/89g==', N'29a3a579-07d9-4e04-b645-4dd59fbe01ea', NULL, 0, 0, NULL, 1, 0, N'jennifer')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e05ef820-3ba3-4ad8-bb13-1bd5f5583aad', N'wuwulin@msit.com', 0, N'AIP8L7Vj3SuoQZ+HZw9cYI1owh6pRfPBrhp6CIwVpYZq8m7jmiOysTxacQcxWtrsZg==', N'cdffa78d-5141-4edf-94a0-0b0a8a5d5c3f', NULL, 0, 0, NULL, 1, 0, N'wuwulin')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e507b102-07f5-4e7b-8701-ca87b710227e', N'evette@msit.com', 0, N'AFDyXBXBo/nhdSVR5cyJkAudqyqXVkv+Vp6mmFvDpQOUjXvxsHkQeVsVkqvbvUSciA==', N'18e57066-e7c8-4841-a29f-178016bd7ccc', NULL, 0, 0, NULL, 1, 0, N'evette')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e662f523-4776-40e8-ab65-86333e125051', N'mengmeng@msit.com', 0, N'ADg7fdejzHwBGZT0JOdlbR+nQV5RuiTmGbR+EgGy5BuffrXRA4ITgBapS48VOTxiLg==', N'951e3ad9-d8d3-47e5-a16e-ce5905187d56', NULL, 0, 0, NULL, 1, 0, N'mengmeng')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ef5d54e9-500b-4031-b981-8bf8b2a6adf9', N'maeshin@msit.com', 0, N'AGPNeHq6KmoNOi8k5m7dQxhufbOovsjHmtcqir+VLY8mN9i2eT6TobhtjtAyXt41Ww==', N'61c4c9b7-10e3-46d5-b654-a69c3b66a03d', NULL, 0, 0, NULL, 1, 0, N'maeshin')
SET IDENTITY_INSERT [dbo].[BulletinBoard] ON 

INSERT [dbo].[BulletinBoard] ([Num], [EmployeeID], [DepartmentID], [GroupID], [Content], [PostTime]) VALUES (1, 1011, 3, 2, N'各處室同仁，請保持環境整潔，勿將垃圾置於桌上。', CAST(N'2019-12-12T13:28:27.373' AS DateTime))
INSERT [dbo].[BulletinBoard] ([Num], [EmployeeID], [DepartmentID], [GroupID], [Content], [PostTime]) VALUES (7, 1026, 3, 2, N'大家好，我是張萌萌~~~~', CAST(N'2019-12-17T09:51:48.000' AS DateTime))
INSERT [dbo].[BulletinBoard] ([Num], [EmployeeID], [DepartmentID], [GroupID], [Content], [PostTime]) VALUES (14, 1019, 6, 7, N'公告：新系統已上線！', CAST(N'2019-12-20T13:55:34.597' AS DateTime))
INSERT [dbo].[BulletinBoard] ([Num], [EmployeeID], [DepartmentID], [GroupID], [Content], [PostTime]) VALUES (16, 1027, 2, 4, N'通知：參加本月客訴會議的同仁請準時與會。', CAST(N'2019-12-20T15:49:22.327' AS DateTime))
INSERT [dbo].[BulletinBoard] ([Num], [EmployeeID], [DepartmentID], [GroupID], [Content], [PostTime]) VALUES (17, 1028, 3, 1, N'公告：年關將近，尚未完成資產盤點的單位請儘速完成。', CAST(N'2019-12-21T15:20:38.567' AS DateTime))
INSERT [dbo].[BulletinBoard] ([Num], [EmployeeID], [DepartmentID], [GroupID], [Content], [PostTime]) VALUES (18, 1029, 3, 2, N'公告：1/10為本公司休假日，請知悉。', CAST(N'2019-12-22T13:49:22.000' AS DateTime))
INSERT [dbo].[BulletinBoard] ([Num], [EmployeeID], [DepartmentID], [GroupID], [Content], [PostTime]) VALUES (21, 1032, 3, 2, N'Hi 我是李維~~~', CAST(N'2019-12-25T09:45:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[BulletinBoard] OFF
SET IDENTITY_INSERT [dbo].[CommentChild] ON 

INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 339, 1008, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 340, 1008, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 341, 1008, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 342, 1008, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 343, 1010, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 344, 1010, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 345, 1010, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 346, 1010, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 347, 1011, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 348, 1011, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 349, 1011, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 350, 1011, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 351, 1013, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 352, 1013, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 353, 1013, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 354, 1013, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 355, 1023, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 356, 1023, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 357, 1023, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 358, 1023, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 359, 1024, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 360, 1024, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 361, 1024, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 362, 1024, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 363, 1025, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 364, 1025, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 365, 1025, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 366, 1025, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 367, 1026, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 368, 1026, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 369, 1026, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 370, 1026, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 371, 1028, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 372, 1028, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 373, 1028, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 374, 1028, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 375, 1029, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 376, 1029, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 377, 1029, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 378, 1029, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 379, 1030, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 380, 1030, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 381, 1030, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 382, 1030, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 383, 1031, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 384, 1031, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 385, 1031, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 386, 1031, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 387, 1032, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 388, 1032, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 389, 1032, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 390, 1032, 82)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 391, 1019, 79)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 392, 1019, 80)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 393, 1019, 81)
INSERT [dbo].[CommentChild] ([CommentMainID], [ChildNum], [EmployeeID], [CommentQuestionID]) VALUES (39, 394, 1019, 82)
SET IDENTITY_INSERT [dbo].[CommentChild] OFF
SET IDENTITY_INSERT [dbo].[CommentContent] ON 

INSERT [dbo].[CommentContent] ([CommentContentID], [CommentContent1], [CommentOptionID]) VALUES (101, N'部門運動會', 1)
INSERT [dbo].[CommentContent] ([CommentContentID], [CommentContent1], [CommentOptionID]) VALUES (102, N'聖誕節活動', 1)
INSERT [dbo].[CommentContent] ([CommentContentID], [CommentContent1], [CommentOptionID]) VALUES (201, N'尾牙', 2)
INSERT [dbo].[CommentContent] ([CommentContentID], [CommentContent1], [CommentOptionID]) VALUES (202, N'春酒', 2)
INSERT [dbo].[CommentContent] ([CommentContentID], [CommentContent1], [CommentOptionID]) VALUES (301, N'廁所環境', 3)
SET IDENTITY_INSERT [dbo].[CommentContent] OFF
SET IDENTITY_INSERT [dbo].[CommentMain] ON 

INSERT [dbo].[CommentMain] ([CommentMainID], [CommentName], [EmployeeID], [SendTime], [CommentContentID], [ActivityMainID]) VALUES (39, N'2019 聖誕節活動', 1010, CAST(N'2019-12-25T09:47:39.587' AS DateTime), 102, NULL)
SET IDENTITY_INSERT [dbo].[CommentMain] OFF
SET IDENTITY_INSERT [dbo].[CommentOption] ON 

INSERT [dbo].[CommentOption] ([CommentOptionID], [CommentOption1]) VALUES (1, N'節慶活動')
INSERT [dbo].[CommentOption] ([CommentOptionID], [CommentOption1]) VALUES (2, N'聚餐')
INSERT [dbo].[CommentOption] ([CommentOptionID], [CommentOption1]) VALUES (3, N'環境')
INSERT [dbo].[CommentOption] ([CommentOptionID], [CommentOption1]) VALUES (15, N'停車場')
SET IDENTITY_INSERT [dbo].[CommentOption] OFF
SET IDENTITY_INSERT [dbo].[CommentQuestion] ON 

INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (101, 1, N'對活動流程的滿意度')
INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (101, 2, N'對活動場地的滿意度')
INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (101, 3, N'對活動日期選擇的滿意度')
INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (101, 4, N'對活動餐點的滿意度')
INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (101, 5, N'對活動整體滿意度')
INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (101, 63, N'對活動主持人的滿意度')
INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (102, 79, N'對交換金額的滿意度')
INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (102, 80, N'對活動場地的滿意度')
INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (102, 81, N'對活動主持人的滿意度')
INSERT [dbo].[CommentQuestion] ([CommentContentID], [CommentQuestionID], [Question]) VALUES (102, 82, N'對活動整體的滿意度')
SET IDENTITY_INSERT [dbo].[CommentQuestion] OFF
SET IDENTITY_INSERT [dbo].[CommentReply] ON 

INSERT [dbo].[CommentReply] ([ReplyNum], [ChildNum], [Rate], [ReplyTime], [CommentMainID]) VALUES (136, 351, 4, CAST(N'2019-12-25T09:48:28.483' AS DateTime), 39)
INSERT [dbo].[CommentReply] ([ReplyNum], [ChildNum], [Rate], [ReplyTime], [CommentMainID]) VALUES (137, 352, 3, CAST(N'2019-12-25T09:48:28.570' AS DateTime), 39)
INSERT [dbo].[CommentReply] ([ReplyNum], [ChildNum], [Rate], [ReplyTime], [CommentMainID]) VALUES (138, 353, 2, CAST(N'2019-12-25T09:48:28.650' AS DateTime), 39)
INSERT [dbo].[CommentReply] ([ReplyNum], [ChildNum], [Rate], [ReplyTime], [CommentMainID]) VALUES (139, 354, 4, CAST(N'2019-12-25T09:48:28.730' AS DateTime), 39)
INSERT [dbo].[CommentReply] ([ReplyNum], [ChildNum], [Rate], [ReplyTime], [CommentMainID]) VALUES (140, 339, 1, CAST(N'2019-12-25T09:48:59.517' AS DateTime), 39)
INSERT [dbo].[CommentReply] ([ReplyNum], [ChildNum], [Rate], [ReplyTime], [CommentMainID]) VALUES (141, 340, 3, CAST(N'2019-12-25T09:48:59.603' AS DateTime), 39)
INSERT [dbo].[CommentReply] ([ReplyNum], [ChildNum], [Rate], [ReplyTime], [CommentMainID]) VALUES (142, 341, 2, CAST(N'2019-12-25T09:48:59.683' AS DateTime), 39)
INSERT [dbo].[CommentReply] ([ReplyNum], [ChildNum], [Rate], [ReplyTime], [CommentMainID]) VALUES (143, 342, 1, CAST(N'2019-12-25T09:48:59.763' AS DateTime), 39)
SET IDENTITY_INSERT [dbo].[CommentReply] OFF
INSERT [dbo].[CompanyVehicle] ([LicenseNumber], [VehicleYear], [PurchaseDate], [brand], [serial], [MaxPassenger], [officeID], [VehiclePhoto], [VehiclePhoto2]) VALUES (N'AUL-2222', 2019, CAST(N'2019-12-21T00:00:00.000' AS DateTime), N'TOYOTA', N'ALTIS', N'5', 1, NULL, N'1_saAN3k28za07Vzw0kJO_EQ.jpeg')
INSERT [dbo].[CompanyVehicle] ([LicenseNumber], [VehicleYear], [PurchaseDate], [brand], [serial], [MaxPassenger], [officeID], [VehiclePhoto], [VehiclePhoto2]) VALUES (N'BVF-8899', 2019, CAST(N'2019-12-25T00:00:00.000' AS DateTime), N'HONDA', N'CRV', N'5', 1, NULL, N'2019-Honda-CR-V-Vi-white-front.jpg')
INSERT [dbo].[CompanyVehicle] ([LicenseNumber], [VehicleYear], [PurchaseDate], [brand], [serial], [MaxPassenger], [officeID], [VehiclePhoto], [VehiclePhoto2]) VALUES (N'CUL-3333', 2019, CAST(N'2019-12-12T00:00:00.000' AS DateTime), N'FORD', N'MONDEO-WAGON', N'5', 1, NULL, N'photo.jpg')
INSERT [dbo].[CompanyVehicle] ([LicenseNumber], [VehicleYear], [PurchaseDate], [brand], [serial], [MaxPassenger], [officeID], [VehiclePhoto], [VehiclePhoto2]) VALUES (N'DUI-4444', 2019, CAST(N'2019-12-17T00:00:00.000' AS DateTime), N'BMW', N'X6', N'5', 2, NULL, N'exterieur-design-slide-2.jpg')
INSERT [dbo].[CompanyVehicle] ([LicenseNumber], [VehicleYear], [PurchaseDate], [brand], [serial], [MaxPassenger], [officeID], [VehiclePhoto], [VehiclePhoto2]) VALUES (N'GUI-5555', 2019, CAST(N'2019-12-19T00:00:00.000' AS DateTime), N'AUDI', N'A5', N'5', 2, NULL, N'下載.jpg')
SET IDENTITY_INSERT [dbo].[CompanyVehicleHistory] ON 

INSERT [dbo].[CompanyVehicleHistory] ([VehicleHistoryID], [LicenseNumber], [StartDateTime], [EndDateTime], [employeeID], [purpose]) VALUES (86, N'AUL-2222', CAST(N'2019-12-26T10:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), 1011, N'外出訪客')
SET IDENTITY_INSERT [dbo].[CompanyVehicleHistory] OFF
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (0, N'無組別')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (1, N'總經理')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (2, N'業務部')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (3, N'行政部')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (4, N'產品部')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (5, N'財務部')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (6, N'資訊部')
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1004, N'吳瑋瑋', N'F', CAST(N'1995-02-09T00:00:00.000' AS DateTime), CAST(N'2019-08-28T00:00:00.000' AS DateTime), N'jennifer', 2, 1, 1, 1004, 1, 8, N'd00f0380a0f0f83bc2aa1097d196903c.jpg', 42, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1008, N'黃阿聖', N'M', CAST(N'1991-10-21T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'youngshang', 1, 3, 2, 1004, 1, 3, N'35344603_1841117929304974_7189688490869653504_n.jpg', 49, 97, 207)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1010, N'杜美心', N'F', CAST(N'1990-03-10T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'maeshin', 1, 3, 3, 1008, 1, 2, N'b3e24c71d62ffae6ca710138766b6caf.jpg', 27, 98, 203)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1011, N'方芮欣', N'F', CAST(N'1993-05-20T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'reshin', 1, 3, 4, 1010, 1, 2, N'ffff.png', 35, 87, 203)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1012, N'張小佑', N'M', CAST(N'1995-04-25T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'rorychang', 1, 2, 2, 1004, 1, 4, N'maleDefault.jpg', 49, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1013, N'林美宋', N'F', CAST(N'1990-12-04T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'marylin', 2, 3, 3, 1008, 1, 1, N'd3913796.jpg', 49, 98, 182)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1019, N'張喬喬', N'F', CAST(N'1995-01-06T00:00:00.000' AS DateTime), CAST(N'2019-12-01T00:00:00.000' AS DateTime), N'jocelyn', 2, 6, 2, 1004, 1, 7, N'64657288_2415626275191113_674949639505444864_n.jpg', 49, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1020, N'李小鎧', N'M', CAST(N'1993-03-21T00:00:00.000' AS DateTime), CAST(N'2019-12-02T00:00:00.000' AS DateTime), N'kai', 1, 4, 2, 1004, 1, 5, N'maleDefault.jpg', 49, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1021, N'馬詩詩', N'F', CAST(N'1995-08-08T00:00:00.000' AS DateTime), CAST(N'2019-11-30T00:00:00.000' AS DateTime), N'evette', 2, 5, 2, 1004, 1, 6, N'femaleDefault.png', 49, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1022, N'NA', N'M', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'NA', 1, 1, 4, 1004, 1, 8, N'maleDefault.jpg', 0, 0, 0)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1023, N'王亞瑟', N'M', CAST(N'1991-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-12T00:00:00.000' AS DateTime), N'arther', 1, 3, 3, 1008, 1, 3, N'maleDefault.jpg', 49, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1024, N'陳珍妮', N'F', CAST(N'1990-03-17T00:00:00.000' AS DateTime), CAST(N'2019-12-12T00:00:00.000' AS DateTime), N'jenny', 1, 3, 4, 1023, 1, 3, N'femaleDefault.png', 49, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1025, N'林五五', N'F', CAST(N'1985-03-18T00:00:00.000' AS DateTime), CAST(N'2019-12-16T00:00:00.000' AS DateTime), N'wuwulin', 1, 3, 4, 1010, 1, 2, N'femaleDefault.png', 49, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1026, N'張萌萌', N'F', CAST(N'1994-12-09T00:00:00.000' AS DateTime), CAST(N'2019-12-17T00:00:00.000' AS DateTime), N'mengmeng', 2, 3, 4, 1010, 1, 2, N'1209229387ffef16e5ed6f4b572c79da.jpg', 28, 91, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1027, N'橋本有菜', N'F', CAST(N'1994-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-17T00:00:00.000' AS DateTime), N'arina', 1, 2, 3, 1012, 1, 4, N'46232DABA417w600h411.jpeg', 49, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1028, N'張文文', N'M', CAST(N'1999-11-10T00:00:00.000' AS DateTime), CAST(N'2019-12-20T00:00:00.000' AS DateTime), N'wengweng', 2, 3, 4, 1013, 1, 1, N'maxresdefault.jpg', 49, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1029, N'陳俊傑', N'M', CAST(N'1991-12-10T00:00:00.000' AS DateTime), CAST(N'2019-12-22T00:00:00.000' AS DateTime), N'baldbrother', 2, 3, 4, 1010, 1, 2, N'下載 (2).jpg', 42, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1030, N'王迷因', N'F', CAST(N'1991-12-10T00:00:00.000' AS DateTime), CAST(N'2019-12-23T00:00:00.000' AS DateTime), N'memewang', 1, 3, 4, 1010, 1, 2, N'tumblr_622ae3f8dd5f88dd0a0cce5e36a20d2d_8114b6e4_500.jpg', 42, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1031, N'魏克強', N'F', CAST(N'1991-12-11T00:00:00.000' AS DateTime), CAST(N'2019-12-24T00:00:00.000' AS DateTime), N'johnwick', 2, 3, 4, 1010, 1, 2, N'maxresdefault.jpg', 42, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1032, N'李維', N'M', CAST(N'1994-12-21T00:00:00.000' AS DateTime), CAST(N'2019-12-25T00:00:00.000' AS DateTime), N'reeves', 1, 3, 4, 1010, 1, 2, N'5d66d21e6f24eb396b6c8192.jpg', 42, 98, 210)
INSERT [dbo].[Employee] ([employeeID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [SpecialLeaveHours], [PersonalLeaveHours], [SickLeaveHours]) VALUES (1033, N'方芮欣', N'F', CAST(N'2000-03-31T21:52:46.000' AS DateTime), CAST(N'2020-04-08T21:52:46.243' AS DateTime), N'reshinfang', 2, 3, 3, 1010, 1, 2, N'https://p2.bahamut.com.tw/B/2KU/34/ebed634608c1bec8e7f6c4b74210zw65.JPG?w=1000', 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EmployeeApprovalTemp] ON 

INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (3, N'黃阿聖', N'M', CAST(N'1991-10-21T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'youngshang', 1, 3, 2, 1004, 1, 3, N'maleDefault.jpg', N'Create', 1004, CAST(N'2019-12-11T17:45:34.020' AS DateTime), 1004, CAST(N'2019-12-11T17:45:34.020' AS DateTime), 1004, CAST(N'2019-12-11T17:45:34.020' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (4, N'杜美心', N'F', CAST(N'1990-03-10T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'maeshin', 1, 3, 3, 1008, 1, 2, N'femaleDefault.png', N'Create', 1004, CAST(N'2019-12-11T17:49:22.563' AS DateTime), 1004, CAST(N'2019-12-11T17:45:34.020' AS DateTime), 1004, CAST(N'2019-12-11T17:45:34.020' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (5, N'方芮欣', N'F', CAST(N'1993-05-20T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'reshin', 1, 3, 4, 1010, 1, 2, N'femaleDefault.png', N'Create', 1004, CAST(N'2019-12-11T17:53:05.363' AS DateTime), 1004, CAST(N'2019-12-11T17:45:34.020' AS DateTime), 1004, CAST(N'2019-12-11T17:45:34.020' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (6, N'張小佑', N'M', CAST(N'1995-04-25T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'rorychang', 1, 2, 2, 1004, 1, 4, N'maleDefault.jpg', N'Create', 1011, CAST(N'2019-12-11T18:05:22.523' AS DateTime), 1010, CAST(N'2019-12-11T18:05:45.453' AS DateTime), 1008, CAST(N'2019-12-11T18:06:05.123' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (7, N'林美宋', N'F', CAST(N'1990-12-04T00:00:00.000' AS DateTime), CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'marylin', 2, 3, 3, 1008, 1, 1, N'femaleDefault.png', N'Create', 1010, CAST(N'2019-12-11T18:10:13.053' AS DateTime), 1010, CAST(N'2019-12-11T18:10:25.160' AS DateTime), 1008, CAST(N'2019-12-11T18:13:06.980' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (8, N'李小鎧', N'M', CAST(N'1993-03-21T00:00:00.000' AS DateTime), CAST(N'2019-12-02T00:00:00.000' AS DateTime), N'kai', 1, 4, 2, 1004, 1, 5, N'maleDefault.jpg', N'Create', 1011, CAST(N'2019-12-12T10:39:32.340' AS DateTime), 1010, CAST(N'2019-12-12T10:43:49.660' AS DateTime), 1008, CAST(N'2019-12-12T10:44:04.883' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (9, N'馬詩詩', N'F', CAST(N'1995-08-08T00:00:00.000' AS DateTime), CAST(N'2019-11-30T00:00:00.000' AS DateTime), N'evette', 2, 5, 2, 1004, 1, 6, N'femaleDefault.png', N'Create', 1011, CAST(N'2019-12-12T10:41:36.057' AS DateTime), 1010, CAST(N'2019-12-12T10:43:51.797' AS DateTime), 1008, CAST(N'2019-12-12T10:44:08.147' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (10, N'張喬喬', N'F', CAST(N'1995-01-06T00:00:00.000' AS DateTime), CAST(N'2019-12-01T00:00:00.000' AS DateTime), N'jocelyn', 2, 6, 2, 1004, 1, 7, N'femaleDefault.png', N'Create', 1011, CAST(N'2019-12-12T10:42:44.847' AS DateTime), 1010, CAST(N'2019-12-12T10:43:47.377' AS DateTime), 1008, CAST(N'2019-12-12T10:44:02.473' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (11, N'王亞瑟', N'M', CAST(N'1991-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-12T00:00:00.000' AS DateTime), N'arther', 1, 3, 3, 1008, 1, 3, N'maleDefault.jpg', N'Create', 1010, CAST(N'2019-12-12T15:01:34.040' AS DateTime), 1010, CAST(N'2019-12-12T15:02:04.373' AS DateTime), 1008, CAST(N'2019-12-12T15:02:31.303' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (12, N'陳珍妮', N'F', CAST(N'1990-03-17T00:00:00.000' AS DateTime), CAST(N'2019-12-12T00:00:00.000' AS DateTime), N'jenny', 1, 3, 4, 1023, 1, 3, N'femaleDefault.png', N'Create', 1010, CAST(N'2019-12-12T15:04:01.537' AS DateTime), 1010, CAST(N'2019-12-12T15:04:12.610' AS DateTime), 1008, CAST(N'2019-12-12T15:04:21.203' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (13, N'蔡國文', N'F', CAST(N'1990-04-06T00:00:00.000' AS DateTime), CAST(N'2019-12-12T00:00:00.000' AS DateTime), N'chinesetsai', 1, 1, 2, 1004, 1, 8, N'femaleDefault.png', N'Create', 1010, CAST(N'2019-12-12T16:21:25.333' AS DateTime), 1010, CAST(N'2019-12-13T17:17:11.987' AS DateTime), 1008, CAST(N'2019-12-16T12:03:33.463' AS DateTime), 0, 1, N'已遭部長駁回')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (14, N'林五五', N'F', CAST(N'1985-03-18T00:00:00.000' AS DateTime), CAST(N'2019-12-16T00:00:00.000' AS DateTime), N'wuwulin', 1, 3, 4, 1010, 1, 2, N'femaleDefault.png', N'Create', 1011, CAST(N'2019-12-16T12:01:11.927' AS DateTime), 1010, CAST(N'2019-12-16T12:02:31.347' AS DateTime), 1008, CAST(N'2019-12-16T12:03:57.407' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (15, N'柯小賢', N'M', CAST(N'1998-04-06T00:00:00.000' AS DateTime), CAST(N'2019-12-17T00:00:00.000' AS DateTime), N'shianko', 1, 6, 3, 1019, 1, 7, N'maleDefault.jpg', N'Create', 1011, CAST(N'2019-12-17T09:18:52.057' AS DateTime), 1010, CAST(N'2019-12-17T09:46:51.577' AS DateTime), 1008, CAST(N'2019-12-17T09:47:29.563' AS DateTime), 0, 1, N'已遭部長駁回')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (16, N'張萌萌', N'F', CAST(N'1994-12-09T00:00:00.000' AS DateTime), CAST(N'2019-12-17T00:00:00.000' AS DateTime), N'mengmeng', 2, 3, 4, 1010, 1, 2, N'femaleDefault.png', N'Create', 1011, CAST(N'2019-12-17T09:45:55.810' AS DateTime), 1010, CAST(N'2019-12-17T09:46:48.167' AS DateTime), 1008, CAST(N'2019-12-17T09:47:41.210' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (17, N'橋本有菜', N'F', CAST(N'1994-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-17T00:00:00.000' AS DateTime), N'arina', 1, 2, 3, 1012, 1, 4, N'femaleDefault.png', N'Create', 1010, CAST(N'2019-12-17T13:32:14.987' AS DateTime), 1010, CAST(N'2019-12-17T13:40:35.060' AS DateTime), 1008, CAST(N'2019-12-17T13:41:08.987' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (18, N'張文文', N'M', CAST(N'1999-11-10T00:00:00.000' AS DateTime), CAST(N'2019-12-20T00:00:00.000' AS DateTime), N'wengweng', 2, 3, 4, 1013, 1, 1, N'maleDefault.jpg', N'Create', 1011, CAST(N'2019-12-20T14:34:33.247' AS DateTime), 1010, CAST(N'2019-12-20T14:36:22.297' AS DateTime), 1008, CAST(N'2019-12-20T14:36:56.480' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (19, N'王大明', N'M', CAST(N'1991-07-18T00:00:00.000' AS DateTime), CAST(N'2019-12-21T00:00:00.000' AS DateTime), N'mingwang', 1, 2, 4, 1027, 1, 4, N'maleDefault.jpg', N'Create', 1010, CAST(N'2019-12-20T17:51:58.033' AS DateTime), NULL, NULL, NULL, NULL, 0, 0, N'待組長簽核')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (20, N'陳俊傑', N'M', CAST(N'1991-12-10T00:00:00.000' AS DateTime), CAST(N'2019-12-22T00:00:00.000' AS DateTime), N'baldbrother', 2, 3, 4, 1010, 1, 2, N'maleDefault.jpg', N'Create', 1011, CAST(N'2019-12-22T13:42:01.353' AS DateTime), 1010, CAST(N'2019-12-22T13:42:37.677' AS DateTime), 1008, CAST(N'2019-12-22T13:42:57.743' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (21, N'王迷因', N'F', CAST(N'1991-12-10T00:00:00.000' AS DateTime), CAST(N'2019-12-23T00:00:00.000' AS DateTime), N'memewang', 1, 3, 4, 1010, 1, 2, N'femaleDefault.png', N'Create', 1011, CAST(N'2019-12-23T09:32:14.917' AS DateTime), 1010, CAST(N'2019-12-23T09:32:48.423' AS DateTime), 1008, CAST(N'2019-12-23T09:33:03.580' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (22, N'魏克強', N'F', CAST(N'1991-12-11T00:00:00.000' AS DateTime), CAST(N'2019-12-24T00:00:00.000' AS DateTime), N'johnwick', 2, 3, 4, 1010, 1, 2, N'femaleDefault.png', N'Create', 1011, CAST(N'2019-12-24T15:27:13.960' AS DateTime), 1010, CAST(N'2019-12-24T15:27:41.320' AS DateTime), 1008, CAST(N'2019-12-24T15:27:56.830' AS DateTime), 1, 0, N'簽核完成')
INSERT [dbo].[EmployeeApprovalTemp] ([ID], [EmployeeName], [Gender], [Birth], [HireDate], [Account], [OfficeID], [DepartmentID], [PositionID], [ManagerID], [Employed], [GroupID], [Photo], [CreateOrUpdate], [Editor], [EditorTime], [GroupLeaderID], [GroupLeaderSignTime], [DepartmentLeaderID], [DepartmentLeaderSignTime], [SignState], [Rejection], [StatusDescript]) VALUES (23, N'李維', N'M', CAST(N'1994-12-21T00:00:00.000' AS DateTime), CAST(N'2019-12-25T00:00:00.000' AS DateTime), N'reeves', 1, 3, 4, 1010, 1, 2, N'maleDefault.jpg', N'Create', 1011, CAST(N'2019-12-25T09:38:34.143' AS DateTime), 1010, CAST(N'2019-12-25T09:39:16.917' AS DateTime), 1008, CAST(N'2019-12-25T09:39:29.603' AS DateTime), 1, 0, N'簽核完成')
SET IDENTITY_INSERT [dbo].[EmployeeApprovalTemp] OFF
SET IDENTITY_INSERT [dbo].[Event] ON 

INSERT [dbo].[Event] ([EventID], [EventName]) VALUES (1, N'出差')
INSERT [dbo].[Event] ([EventID], [EventName]) VALUES (2, N'開會')
INSERT [dbo].[Event] ([EventID], [EventName]) VALUES (3, N'餐會')
INSERT [dbo].[Event] ([EventID], [EventName]) VALUES (4, N'工作')
SET IDENTITY_INSERT [dbo].[Event] OFF
SET IDENTITY_INSERT [dbo].[EventCalendar] ON 

INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (38, 1011, N'事假', 3, CAST(N'2019-12-03T09:00:00.000' AS DateTime), CAST(N'2019-12-03T17:00:00.000' AS DateTime), N'總公司', N'考駕照', 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (45, 1010, N'病假', 3, CAST(N'2019-11-15T09:00:00.000' AS DateTime), CAST(N'2019-11-15T17:00:00.000' AS DateTime), N'總公司', N'感冒', 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (46, 1010, N'特休', 3, CAST(N'2019-12-21T09:00:00.000' AS DateTime), CAST(N'2019-12-23T17:00:00.000' AS DateTime), N'總公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (47, 1010, N'會議室預約', 3, CAST(N'2019-12-20T08:00:00.000' AS DateTime), CAST(N'2019-12-20T10:00:00.000' AS DateTime), N'雲豹', N'B2', 0, N'#FFEE99')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (48, 1010, N'公務車預約', 3, CAST(N'2019-12-20T08:00:00.000' AS DateTime), CAST(N'2019-12-21T08:00:00.000' AS DateTime), N'BCD-5216', N'出差', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (49, 1011, N'事假', 3, CAST(N'2019-12-21T09:00:00.000' AS DateTime), CAST(N'2019-12-21T10:00:00.000' AS DateTime), N'總公司', N'家裡有事', 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (50, 1011, N'特休', 3, CAST(N'2019-12-26T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), N'總公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (51, 1026, N'特休', 3, CAST(N'2019-12-23T09:00:00.000' AS DateTime), CAST(N'2019-12-25T17:00:00.000' AS DateTime), N'大安分公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (52, 1008, N'事假', 3, CAST(N'2019-12-23T09:00:00.000' AS DateTime), CAST(N'2019-12-23T10:00:00.000' AS DateTime), N'總公司', N'私事待辦', 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (54, 1011, N'公務車預約', 3, CAST(N'2019-12-22T09:00:00.000' AS DateTime), CAST(N'2019-12-22T17:00:00.000' AS DateTime), N'BCD-5216', N'外出訪客戶', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (66, 1013, N'病假', 3, CAST(N'2019-12-10T09:00:00.000' AS DateTime), CAST(N'2019-12-13T17:00:00.000' AS DateTime), N'大安分公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (67, 1004, N'特休', 1, CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), N'大安分公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (79, 1029, N'特休', 3, CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), N'大安分公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (89, 1030, N'特休', 3, CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), N'總公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (102, 1013, N'查詢工作岡位', 3, CAST(N'2019-12-23T15:08:00.000' AS DateTime), CAST(N'2019-12-24T15:08:00.000' AS DateTime), N'辦公室', N'查找資料', 1, N'#0080c0')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (103, 1013, N'查詢工作岡位', 1, CAST(N'2019-12-23T15:09:00.000' AS DateTime), CAST(N'2019-12-24T15:09:00.000' AS DateTime), N'辦公室', N'找資料', 0, N'#000000')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (106, 1031, N'特休', 3, CAST(N'2020-01-16T09:00:00.000' AS DateTime), CAST(N'2020-01-16T17:00:00.000' AS DateTime), N'大安分公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (132, 1011, N'公務車預約', 3, CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-26T15:00:00.000' AS DateTime), N'AUL-2222', N'外出訪客', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (133, 1011, N'公務車預約', 3, CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-26T15:00:00.000' AS DateTime), N'CRV-1111', N'', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (134, 1011, N'公務車預約', 3, CAST(N'2019-12-25T10:00:00.000' AS DateTime), CAST(N'2019-12-26T16:00:00.000' AS DateTime), N'CUL-3333', N'', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (135, 1011, N'公務車預約', 3, CAST(N'2019-12-25T10:00:00.000' AS DateTime), CAST(N'2019-12-26T16:00:00.000' AS DateTime), N'CVD-2222', N'', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (136, 1011, N'會議室預約', 3, CAST(N'2019-12-24T09:00:00.000' AS DateTime), CAST(N'2019-12-24T10:00:00.000' AS DateTime), N'石虎', N'A1', 0, N'#FFEE99')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (137, 1011, N'公務車預約', 3, CAST(N'2020-12-25T10:00:00.000' AS DateTime), CAST(N'2019-12-26T13:00:00.000' AS DateTime), N'AUL-2222', N'fghdgfsdgfs', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (138, 1011, N'公務車預約', 3, CAST(N'2020-12-25T10:00:00.000' AS DateTime), CAST(N'2019-12-26T13:00:00.000' AS DateTime), N'CRV-1111', N'dfhsdfgsdfg', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (139, 1011, N'會議室預約', 3, CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-25T10:00:00.000' AS DateTime), N'石虎', N'A1', 0, N'#FFEE99')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (140, 1011, N'會議室預約', 3, CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-25T10:00:00.000' AS DateTime), N'雲豹', N'B2', 0, N'#FFEE99')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (141, 1011, N'會議室預約', 3, CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-25T10:00:00.000' AS DateTime), N'白海豚', N'C3', 0, N'#FFEE99')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (142, 1026, N'事假', 3, CAST(N'2019-12-30T09:00:00.000' AS DateTime), CAST(N'2019-12-30T17:00:00.000' AS DateTime), N'大安分公司', N'護照辦理', 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (143, 1011, N'病假', 3, CAST(N'2020-01-31T09:00:00.000' AS DateTime), CAST(N'2020-01-31T17:00:00.000' AS DateTime), N'總公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (144, 1011, N'公務車預約', 3, CAST(N'2019-12-25T10:00:00.000' AS DateTime), CAST(N'2019-12-26T16:00:00.000' AS DateTime), N'AUL-2222', N'', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (145, 1011, N'公務車預約', 3, CAST(N'2019-12-25T10:00:00.000' AS DateTime), CAST(N'2019-12-26T16:00:00.000' AS DateTime), N'CRV-1111', N'', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (146, 1011, N'會議室預約', 3, CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-25T11:00:00.000' AS DateTime), N'石虎', N'A1', 0, N'#FFEE99')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (147, 1011, N'會議室預約', 3, CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-25T11:00:00.000' AS DateTime), N'雲豹', N'B2', 0, N'#FFEE99')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (148, 1011, N'公務車預約', 3, CAST(N'2019-12-25T10:00:00.000' AS DateTime), CAST(N'2019-12-26T16:00:00.000' AS DateTime), N'AUL-2222', N'', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (149, 1011, N'公務車預約', 3, CAST(N'2019-12-25T10:00:00.000' AS DateTime), CAST(N'2019-12-26T16:00:00.000' AS DateTime), N'CRV-1111', N'', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (150, 1011, N'公務車預約', 3, CAST(N'2019-12-26T10:00:00.000' AS DateTime), CAST(N'2019-12-27T16:00:00.000' AS DateTime), N'asdfasdf', N'', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (151, 1032, N'特休', 3, CAST(N'2019-12-31T09:00:00.000' AS DateTime), CAST(N'2019-12-31T17:00:00.000' AS DateTime), N'總公司', NULL, 1, N'#DDDDDD')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (152, 1011, N'公務車預約', 3, CAST(N'2019-12-26T10:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), N'AUL-2222', N'外出訪客', 0, N'#BBFF66')
INSERT [dbo].[EventCalendar] ([CalendarID], [employeeID], [Subject], [DepartmentID], [StartTime], [EndTime], [Location], [Description], [IsImportant], [ThemeColor]) VALUES (153, 1011, N'會議室預約', 3, CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-25T10:00:00.000' AS DateTime), N'石虎', N'A1', 0, N'#FFEE99')
SET IDENTITY_INSERT [dbo].[EventCalendar] OFF
SET IDENTITY_INSERT [dbo].[File] ON 

INSERT [dbo].[File] ([FileID], [FileName], [FileSize], [EmployeeID], [UploadDate], [Data], [Extension]) VALUES (154, N'新進員工資料.xlsx', N'9946', 1010, CAST(N'2019-12-22T14:32:56.517' AS DateTime), N'C:\Users\User\Documents\GitHub\RoryRoryCC\BusinessSystemMVC(Admin page) 2019-11-29\BusinessSystemMVC(Admin page)\\Uploads\新進員工資料.xlsx', N'.xlsx')
INSERT [dbo].[File] ([FileID], [FileName], [FileSize], [EmployeeID], [UploadDate], [Data], [Extension]) VALUES (163, N'logo2.png', N'21542', 1011, CAST(N'2019-12-25T09:57:01.347' AS DateTime), N'C:\Users\User\Desktop\第一組\BusinessSystemMVC(Admin page) 2019-11-29\BusinessSystemMVC(Admin page)\\Uploads\logo2.png', N'.png')
INSERT [dbo].[File] ([FileID], [FileName], [FileSize], [EmployeeID], [UploadDate], [Data], [Extension]) VALUES (164, N'Upload.txt', N'2154', 1011, CAST(N'2019-12-25T09:57:01.350' AS DateTime), N'C:\Users\User\Desktop\第一組\BusinessSystemMVC(Admin page) 2019-11-29\BusinessSystemMVC(Admin page)\\Uploads\Upload.txt', N'.txt')
INSERT [dbo].[File] ([FileID], [FileName], [FileSize], [EmployeeID], [UploadDate], [Data], [Extension]) VALUES (165, N'展示資料.xlsx', N'11570', 1011, CAST(N'2019-12-25T09:57:01.353' AS DateTime), N'C:\Users\User\Desktop\第一組\BusinessSystemMVC(Admin page) 2019-11-29\BusinessSystemMVC(Admin page)\\Uploads\展示資料.xlsx', N'.xlsx')
SET IDENTITY_INSERT [dbo].[File] OFF
INSERT [dbo].[Group] ([GroupID], [GroupName], [DepartmentID]) VALUES (0, N'無組別', 0)
INSERT [dbo].[Group] ([GroupID], [GroupName], [DepartmentID]) VALUES (1, N'總務組', 3)
INSERT [dbo].[Group] ([GroupID], [GroupName], [DepartmentID]) VALUES (2, N'人資組', 3)
INSERT [dbo].[Group] ([GroupID], [GroupName], [DepartmentID]) VALUES (3, N'行政部室', 3)
INSERT [dbo].[Group] ([GroupID], [GroupName], [DepartmentID]) VALUES (4, N'業務部室', 2)
INSERT [dbo].[Group] ([GroupID], [GroupName], [DepartmentID]) VALUES (5, N'產品部室', 4)
INSERT [dbo].[Group] ([GroupID], [GroupName], [DepartmentID]) VALUES (6, N'財務部室', 5)
INSERT [dbo].[Group] ([GroupID], [GroupName], [DepartmentID]) VALUES (7, N'資訊部室', 6)
INSERT [dbo].[Group] ([GroupID], [GroupName], [DepartmentID]) VALUES (8, N'總經理室', 1)
INSERT [dbo].[Leave] ([leaveID], [leave_name]) VALUES (0, N'特休')
INSERT [dbo].[Leave] ([leaveID], [leave_name]) VALUES (1, N'事假')
INSERT [dbo].[Leave] ([leaveID], [leave_name]) VALUES (2, N'病假')
SET IDENTITY_INSERT [dbo].[LeaveHistory] ON 

INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (4, 1011, 1, CAST(N'2019-12-17T17:06:58.437' AS DateTime), CAST(N'2019-12-03T09:00:00.000' AS DateTime), CAST(N'2019-12-03T17:00:00.000' AS DateTime), N'考駕照', NULL, 7)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (5, 1010, 2, CAST(N'2019-12-18T19:02:32.580' AS DateTime), CAST(N'2019-11-15T09:00:00.000' AS DateTime), CAST(N'2019-11-15T17:00:00.000' AS DateTime), N'感冒', NULL, 7)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (6, 1010, 0, CAST(N'2019-12-18T19:00:18.240' AS DateTime), CAST(N'2019-12-21T09:00:00.000' AS DateTime), CAST(N'2019-12-23T17:00:00.000' AS DateTime), NULL, NULL, 21)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (7, 1011, 1, CAST(N'2019-12-18T14:24:00.580' AS DateTime), CAST(N'2019-12-21T09:00:00.000' AS DateTime), CAST(N'2019-12-21T10:00:00.000' AS DateTime), N'家裡有事', NULL, 1)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (8, 1011, 0, CAST(N'2019-12-19T14:20:08.773' AS DateTime), CAST(N'2019-12-26T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), NULL, NULL, 14)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (9, 1026, 0, CAST(N'2019-12-19T14:01:11.540' AS DateTime), CAST(N'2019-12-23T09:00:00.000' AS DateTime), CAST(N'2019-12-25T17:00:00.000' AS DateTime), NULL, NULL, 21)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (10, 1008, 1, CAST(N'2019-12-19T13:38:09.410' AS DateTime), CAST(N'2019-12-23T09:00:00.000' AS DateTime), CAST(N'2019-12-23T10:00:00.000' AS DateTime), N'私事待辦', NULL, 1)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (11, 1013, 2, CAST(N'2019-12-21T15:25:22.547' AS DateTime), CAST(N'2019-12-10T09:00:00.000' AS DateTime), CAST(N'2019-12-13T17:00:00.000' AS DateTime), NULL, NULL, 28)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (12, 1004, 0, CAST(N'2019-12-21T15:34:16.233' AS DateTime), CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), NULL, NULL, 7)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (13, 1029, 0, CAST(N'2019-12-22T13:45:45.157' AS DateTime), CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), NULL, NULL, 7)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (14, 1030, 0, CAST(N'2019-12-23T09:35:00.777' AS DateTime), CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), NULL, NULL, 7)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (15, 1031, 0, CAST(N'2019-12-24T15:30:00.187' AS DateTime), CAST(N'2020-01-16T09:00:00.000' AS DateTime), CAST(N'2020-01-16T17:00:00.000' AS DateTime), NULL, NULL, 7)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (16, 1026, 1, CAST(N'2019-12-20T15:44:52.610' AS DateTime), CAST(N'2019-12-30T09:00:00.000' AS DateTime), CAST(N'2019-12-30T17:00:00.000' AS DateTime), N'護照辦理', NULL, 7)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (17, 1011, 2, CAST(N'2019-12-25T08:31:31.800' AS DateTime), CAST(N'2020-01-31T09:00:00.000' AS DateTime), CAST(N'2020-01-31T17:00:00.000' AS DateTime), NULL, NULL, 7)
INSERT [dbo].[LeaveHistory] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours]) VALUES (18, 1032, 0, CAST(N'2019-12-25T09:41:38.417' AS DateTime), CAST(N'2019-12-31T09:00:00.000' AS DateTime), CAST(N'2019-12-31T17:00:00.000' AS DateTime), NULL, NULL, 7)
SET IDENTITY_INSERT [dbo].[LeaveHistory] OFF
SET IDENTITY_INSERT [dbo].[LeaveHistoryApprovalTemp] ON 

INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (14, 1011, 1, CAST(N'2019-12-17T17:06:58.437' AS DateTime), CAST(N'2019-12-03T09:00:00.000' AS DateTime), CAST(N'2019-12-03T17:00:00.000' AS DateTime), N'考駕照', NULL, 7, 1010, CAST(N'2019-12-17T17:18:03.347' AS DateTime), 1008, CAST(N'2019-12-17T17:31:09.443' AS DateTime), 1022, CAST(N'2019-12-17T17:06:58.437' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (15, 1011, 1, CAST(N'2019-12-18T14:24:00.580' AS DateTime), CAST(N'2019-12-21T09:00:00.000' AS DateTime), CAST(N'2019-12-21T10:00:00.000' AS DateTime), N'家裡有事', NULL, 1, 1010, CAST(N'2019-12-19T14:21:00.760' AS DateTime), 1008, CAST(N'2019-12-19T14:21:55.477' AS DateTime), 1022, CAST(N'2019-12-18T14:24:00.580' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (16, 1010, 0, CAST(N'2019-12-18T19:00:18.240' AS DateTime), CAST(N'2019-12-21T09:00:00.000' AS DateTime), CAST(N'2019-12-23T17:00:00.000' AS DateTime), NULL, NULL, 21, 1022, CAST(N'2019-12-18T19:00:18.240' AS DateTime), 1008, CAST(N'2019-12-18T19:03:18.083' AS DateTime), 1004, CAST(N'2019-12-18T19:03:54.960' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (17, 1010, 2, CAST(N'2019-12-18T19:02:32.580' AS DateTime), CAST(N'2019-11-15T09:00:00.000' AS DateTime), CAST(N'2019-11-15T17:00:00.000' AS DateTime), N'感冒', NULL, 7, 1022, CAST(N'2019-12-18T19:02:32.580' AS DateTime), 1008, CAST(N'2019-12-18T19:03:26.710' AS DateTime), 1022, CAST(N'2019-12-18T19:02:32.580' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (18, 1008, 1, CAST(N'2019-12-19T13:38:09.410' AS DateTime), CAST(N'2019-12-23T09:00:00.000' AS DateTime), CAST(N'2019-12-23T10:00:00.000' AS DateTime), N'私事待辦', NULL, 1, 1022, CAST(N'2019-12-19T13:38:09.410' AS DateTime), 1022, CAST(N'2019-12-19T13:38:09.410' AS DateTime), 1004, CAST(N'2019-12-19T14:31:07.213' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (19, 1026, 0, CAST(N'2019-12-19T14:01:11.540' AS DateTime), CAST(N'2019-12-23T09:00:00.000' AS DateTime), CAST(N'2019-12-25T17:00:00.000' AS DateTime), NULL, NULL, 21, 1010, CAST(N'2019-12-19T14:20:57.430' AS DateTime), 1008, CAST(N'2019-12-19T14:21:53.647' AS DateTime), 1004, CAST(N'2019-12-19T14:30:52.047' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (20, 1011, 0, CAST(N'2019-12-19T14:20:08.773' AS DateTime), CAST(N'2019-12-26T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), NULL, NULL, 14, 1010, CAST(N'2019-12-19T14:21:02.700' AS DateTime), 1008, CAST(N'2019-12-19T14:21:57.587' AS DateTime), 1022, CAST(N'2019-12-19T14:20:08.773' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (21, 1028, 0, CAST(N'2019-12-20T14:39:08.220' AS DateTime), CAST(N'2019-12-23T09:00:00.000' AS DateTime), CAST(N'2019-12-23T17:00:00.000' AS DateTime), N'想放拉', NULL, 7, 1013, CAST(N'2019-12-20T14:41:05.833' AS DateTime), NULL, NULL, 1022, CAST(N'2019-12-20T14:39:08.220' AS DateTime), N'已遭組長駁回', 0, 1)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (24, 1026, 1, CAST(N'2019-12-20T15:44:52.610' AS DateTime), CAST(N'2019-12-30T09:00:00.000' AS DateTime), CAST(N'2019-12-30T17:00:00.000' AS DateTime), N'護照辦理', NULL, 7, 1010, CAST(N'2019-12-20T15:45:18.857' AS DateTime), 1008, CAST(N'2019-12-25T08:32:07.033' AS DateTime), 1022, CAST(N'2019-12-20T15:44:52.610' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (26, 1027, 1, CAST(N'2019-12-21T14:58:05.363' AS DateTime), CAST(N'2019-12-24T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), NULL, NULL, 28, 1022, CAST(N'2019-12-21T14:58:05.363' AS DateTime), 1012, CAST(N'2019-12-21T14:58:45.813' AS DateTime), NULL, NULL, N'待總經理簽核', 0, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (27, 1028, 0, CAST(N'2019-12-21T15:04:58.267' AS DateTime), CAST(N'2019-12-31T09:00:00.000' AS DateTime), CAST(N'2019-12-31T17:00:00.000' AS DateTime), NULL, NULL, 7, NULL, NULL, NULL, NULL, 1022, CAST(N'2019-12-21T15:05:25.540' AS DateTime), N'待部長簽核', 0, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (28, 1013, 2, CAST(N'2019-12-21T15:25:22.547' AS DateTime), CAST(N'2019-12-10T09:00:00.000' AS DateTime), CAST(N'2019-12-13T17:00:00.000' AS DateTime), NULL, NULL, 28, 1022, CAST(N'2019-12-21T15:25:22.547' AS DateTime), 1008, CAST(N'2019-12-21T15:25:44.043' AS DateTime), 1004, CAST(N'2019-12-21T15:26:19.370' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (30, 1004, 0, CAST(N'2019-12-21T15:34:16.233' AS DateTime), CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), NULL, NULL, 7, 1022, CAST(N'2019-12-21T15:34:16.233' AS DateTime), 1022, CAST(N'2019-12-21T15:34:16.233' AS DateTime), 1004, CAST(N'2019-12-21T15:34:16.233' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (31, 1029, 1, CAST(N'2019-12-22T13:44:51.433' AS DateTime), CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-25T17:00:00.000' AS DateTime), N'想放假', NULL, 7, 1010, CAST(N'2019-12-22T13:46:16.333' AS DateTime), NULL, NULL, 1022, CAST(N'2019-12-22T13:44:51.433' AS DateTime), N'已遭組長駁回', 0, 1)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (32, 1029, 0, CAST(N'2019-12-22T13:45:32.520' AS DateTime), CAST(N'2020-01-06T09:00:00.000' AS DateTime), CAST(N'2020-01-09T17:00:00.000' AS DateTime), NULL, NULL, 28, 1010, CAST(N'2019-12-22T13:46:27.467' AS DateTime), 1008, CAST(N'2019-12-22T13:46:57.533' AS DateTime), NULL, NULL, N'待總經理簽核', 0, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (33, 1029, 0, CAST(N'2019-12-22T13:45:45.157' AS DateTime), CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), NULL, NULL, 7, 1010, CAST(N'2019-12-22T13:46:33.813' AS DateTime), 1008, CAST(N'2019-12-22T13:47:05.237' AS DateTime), 1022, CAST(N'2019-12-22T13:45:45.157' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (34, 1030, 1, CAST(N'2019-12-23T09:34:20.067' AS DateTime), CAST(N'2019-12-26T09:00:00.000' AS DateTime), CAST(N'2019-12-26T17:00:00.000' AS DateTime), N'想放啦', NULL, 7, 1010, CAST(N'2019-12-23T09:35:28.873' AS DateTime), NULL, NULL, 1022, CAST(N'2019-12-23T09:34:20.067' AS DateTime), N'已遭組長駁回', 0, 1)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (35, 1030, 0, CAST(N'2019-12-23T09:34:50.740' AS DateTime), CAST(N'2020-01-06T09:00:00.000' AS DateTime), CAST(N'2020-01-10T10:00:00.000' AS DateTime), NULL, NULL, 29, 1010, CAST(N'2019-12-23T09:35:35.560' AS DateTime), 1008, CAST(N'2019-12-23T09:35:58.400' AS DateTime), NULL, NULL, N'待總經理簽核', 0, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (36, 1030, 0, CAST(N'2019-12-23T09:35:00.777' AS DateTime), CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), NULL, NULL, 7, 1010, CAST(N'2019-12-23T09:35:36.937' AS DateTime), 1008, CAST(N'2019-12-23T09:36:00.250' AS DateTime), 1022, CAST(N'2019-12-23T09:35:00.777' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (37, 1031, 1, CAST(N'2019-12-24T15:29:27.140' AS DateTime), CAST(N'2019-12-27T09:00:00.000' AS DateTime), CAST(N'2019-12-27T17:00:00.000' AS DateTime), N'想放假', NULL, 7, 1010, CAST(N'2019-12-24T15:30:28.803' AS DateTime), NULL, NULL, 1022, CAST(N'2019-12-24T15:29:27.140' AS DateTime), N'已遭組長駁回', 0, 1)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (38, 1031, 0, CAST(N'2019-12-24T15:29:47.450' AS DateTime), CAST(N'2020-01-06T09:00:00.000' AS DateTime), CAST(N'2020-01-10T17:00:00.000' AS DateTime), NULL, NULL, 35, 1010, CAST(N'2019-12-24T15:30:33.867' AS DateTime), 1008, CAST(N'2019-12-24T15:30:55.667' AS DateTime), NULL, NULL, N'待總經理簽核', 0, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (39, 1031, 0, CAST(N'2019-12-24T15:30:00.187' AS DateTime), CAST(N'2020-01-16T09:00:00.000' AS DateTime), CAST(N'2020-01-16T17:00:00.000' AS DateTime), NULL, NULL, 7, 1010, CAST(N'2019-12-24T15:30:35.790' AS DateTime), 1008, CAST(N'2019-12-24T15:30:57.113' AS DateTime), 1022, CAST(N'2019-12-24T15:30:00.187' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (40, 1011, 2, CAST(N'2019-12-25T08:31:31.800' AS DateTime), CAST(N'2020-01-31T09:00:00.000' AS DateTime), CAST(N'2020-01-31T17:00:00.000' AS DateTime), NULL, NULL, 7, 1010, CAST(N'2019-12-25T08:31:51.180' AS DateTime), 1008, CAST(N'2019-12-25T08:32:12.193' AS DateTime), 1022, CAST(N'2019-12-25T08:31:31.800' AS DateTime), N'簽核完成', 1, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (41, 1032, 1, CAST(N'2019-12-25T09:40:44.873' AS DateTime), CAST(N'2019-12-30T09:00:00.000' AS DateTime), CAST(N'2019-12-30T17:00:00.000' AS DateTime), N'想放假', NULL, 7, 1010, CAST(N'2019-12-25T09:42:08.420' AS DateTime), NULL, NULL, 1022, CAST(N'2019-12-25T09:40:44.873' AS DateTime), N'已遭組長駁回', 0, 1)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (42, 1032, 0, CAST(N'2019-12-25T09:41:25.557' AS DateTime), CAST(N'2020-01-13T09:00:00.000' AS DateTime), CAST(N'2020-01-16T17:00:00.000' AS DateTime), NULL, NULL, 28, 1010, CAST(N'2019-12-25T09:42:12.360' AS DateTime), 1008, CAST(N'2019-12-25T09:42:34.947' AS DateTime), NULL, NULL, N'待總經理簽核', 0, 0)
INSERT [dbo].[LeaveHistoryApprovalTemp] ([ID], [employeeID], [leaveID], [ReleaseTime], [StartTime], [EndTime], [Description], [Appendix], [LeaveHours], [GroupLeader], [GroupLeaderSignTime], [DepartmentLeader], [DepartmentLeaderSignTime], [GeneralManager], [GeneralManagerSignTime], [Status], [SignState], [Reject]) VALUES (43, 1032, 0, CAST(N'2019-12-25T09:41:38.417' AS DateTime), CAST(N'2019-12-31T09:00:00.000' AS DateTime), CAST(N'2019-12-31T17:00:00.000' AS DateTime), NULL, NULL, 7, 1010, CAST(N'2019-12-25T09:42:13.943' AS DateTime), 1008, CAST(N'2019-12-25T09:42:36.740' AS DateTime), 1022, CAST(N'2019-12-25T09:41:38.417' AS DateTime), N'簽核完成', 1, 0)
SET IDENTITY_INSERT [dbo].[LeaveHistoryApprovalTemp] OFF
INSERT [dbo].[MeetingRoom] ([meetingID], [meetingName], [officeID], [max_member], [RoomAddress]) VALUES (N'A1', N'石虎', 1, 24, N'2樓201室')
INSERT [dbo].[MeetingRoom] ([meetingID], [meetingName], [officeID], [max_member], [RoomAddress]) VALUES (N'B2', N'雲豹', 1, 12, N'3樓302室')
INSERT [dbo].[MeetingRoom] ([meetingID], [meetingName], [officeID], [max_member], [RoomAddress]) VALUES (N'C3', N'白海豚', 1, 6, N'3樓305室')
INSERT [dbo].[MeetingRoom] ([meetingID], [meetingName], [officeID], [max_member], [RoomAddress]) VALUES (N'D2', N'秋海棠', 2, 12, N'9樓903室')
INSERT [dbo].[MeetingRoom] ([meetingID], [meetingName], [officeID], [max_member], [RoomAddress]) VALUES (N'E3', N'酢醬草', 2, 6, N'9樓908室')
INSERT [dbo].[MeetingRoom] ([meetingID], [meetingName], [officeID], [max_member], [RoomAddress]) VALUES (N'F3', N'虎斑貓', 2, 10, N'九樓904')
SET IDENTITY_INSERT [dbo].[MeetingRoomHistory] ON 

INSERT [dbo].[MeetingRoomHistory] ([MeetingRoomID], [meetingID], [start_date_time], [end_date_time], [employeeID]) VALUES (11, N'A1', CAST(N'2019-12-15T14:00:00.000' AS DateTime), CAST(N'2019-12-15T17:00:00.000' AS DateTime), 1008)
INSERT [dbo].[MeetingRoomHistory] ([MeetingRoomID], [meetingID], [start_date_time], [end_date_time], [employeeID]) VALUES (22, N'B2', CAST(N'2019-12-20T08:00:00.000' AS DateTime), CAST(N'2019-12-20T10:00:00.000' AS DateTime), 1010)
INSERT [dbo].[MeetingRoomHistory] ([MeetingRoomID], [meetingID], [start_date_time], [end_date_time], [employeeID]) VALUES (26, N'C3', CAST(N'2019-12-21T15:00:00.000' AS DateTime), CAST(N'2019-12-22T16:00:00.000' AS DateTime), 1027)
INSERT [dbo].[MeetingRoomHistory] ([MeetingRoomID], [meetingID], [start_date_time], [end_date_time], [employeeID]) VALUES (28, N'F3', CAST(N'2019-12-22T09:00:00.000' AS DateTime), CAST(N'2019-12-23T09:00:00.000' AS DateTime), 1008)
INSERT [dbo].[MeetingRoomHistory] ([MeetingRoomID], [meetingID], [start_date_time], [end_date_time], [employeeID]) VALUES (29, N'D2', CAST(N'2019-12-22T14:00:00.000' AS DateTime), CAST(N'2019-12-23T16:00:00.000' AS DateTime), 1008)
INSERT [dbo].[MeetingRoomHistory] ([MeetingRoomID], [meetingID], [start_date_time], [end_date_time], [employeeID]) VALUES (40, N'A1', CAST(N'2019-12-25T09:00:00.000' AS DateTime), CAST(N'2019-12-25T10:00:00.000' AS DateTime), 1011)
SET IDENTITY_INSERT [dbo].[MeetingRoomHistory] OFF
SET IDENTITY_INSERT [dbo].[Message] ON 

INSERT [dbo].[Message] ([MessageID], [Data], [EmployeeID], [Title], [MailingDate], [Status]) VALUES (43, N'文件已上傳至檔案管理中,請在12/25號下班前回信', 1010, N'員工資料確認', CAST(N'2019-12-22T14:30:18.820' AS DateTime), N'true')
INSERT [dbo].[Message] ([MessageID], [Data], [EmployeeID], [Title], [MailingDate], [Status]) VALUES (46, N'請確認', 1011, N'收到郵件', CAST(N'2019-12-25T09:58:41.633' AS DateTime), N'true')
SET IDENTITY_INSERT [dbo].[Message] OFF
INSERT [dbo].[Office] ([officeID], [office_name], [office_address]) VALUES (1, N'總公司', N'106 台北市大安區復興南路一段390號')
INSERT [dbo].[Office] ([officeID], [office_name], [office_address]) VALUES (2, N'大安分公司', N'106 台北市大安區和平東路二段106號11樓')
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([OrderDetailID], [OrderID], [Note], [ProductName], [UnitPrice], [Quantity]) VALUES (65, 65, N'新進員工，新購螢幕', N'螢幕', 2000.0000, 2)
INSERT [dbo].[OrderDetail] ([OrderDetailID], [OrderID], [Note], [ProductName], [UnitPrice], [Quantity]) VALUES (66, 66, N'新進員工，新購電腦', N'電腦', 15000.0000, 3)
INSERT [dbo].[OrderDetail] ([OrderDetailID], [OrderID], [Note], [ProductName], [UnitPrice], [Quantity]) VALUES (67, 67, N'寄信給顧客A', N'郵資', 15.0000, 10)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
INSERT [dbo].[Position] ([positionID], [position]) VALUES (1, N'總經理')
INSERT [dbo].[Position] ([positionID], [position]) VALUES (2, N'部長')
INSERT [dbo].[Position] ([positionID], [position]) VALUES (3, N'組長')
INSERT [dbo].[Position] ([positionID], [position]) VALUES (4, N'員工')
SET IDENTITY_INSERT [dbo].[Recipient] ON 

INSERT [dbo].[Recipient] ([MessageID], [EmployeeID], [Status], [RecipientID]) VALUES (43, 1011, N'false', 43)
INSERT [dbo].[Recipient] ([MessageID], [EmployeeID], [Status], [RecipientID]) VALUES (46, 1010, N'true', 46)
SET IDENTITY_INSERT [dbo].[Recipient] OFF
INSERT [dbo].[ReportCategory] ([ReportID], [ReportName]) VALUES (1, N'請假單')
INSERT [dbo].[ReportCategory] ([ReportID], [ReportName]) VALUES (2, N'請購單')
INSERT [dbo].[ReportCategory] ([ReportID], [ReportName]) VALUES (3, N'出差單')
INSERT [dbo].[ReportCategory] ([ReportID], [ReportName]) VALUES (4, N'獎懲單')
SET IDENTITY_INSERT [dbo].[ReportTimeSystem] ON 

INSERT [dbo].[ReportTimeSystem] ([ReportID], [ReportName], [employeeID], [StartTime], [EndTime], [EventHours], [EventID], [Note], [ApplyDateTime], [Discontinue]) VALUES (20, N'出差', 1010, CAST(N'2019-12-19T11:50:00.000' AS DateTime), CAST(N'2019-12-19T14:50:00.000' AS DateTime), 3, 1, N'去開會', CAST(N'2019-12-19T11:51:26.307' AS DateTime), 1)
INSERT [dbo].[ReportTimeSystem] ([ReportID], [ReportName], [employeeID], [StartTime], [EndTime], [EventHours], [EventID], [Note], [ApplyDateTime], [Discontinue]) VALUES (23, N'編輯UI', 1011, CAST(N'2019-12-15T14:00:00.000' AS DateTime), CAST(N'2019-12-21T14:00:00.000' AS DateTime), 144, 1, NULL, CAST(N'2019-12-21T13:30:53.000' AS DateTime), 1)
INSERT [dbo].[ReportTimeSystem] ([ReportID], [ReportName], [employeeID], [StartTime], [EndTime], [EventHours], [EventID], [Note], [ApplyDateTime], [Discontinue]) VALUES (29, N'修改ui', 1011, CAST(N'2019-12-25T09:52:00.000' AS DateTime), CAST(N'2019-12-25T17:52:00.000' AS DateTime), 8, 4, NULL, CAST(N'2019-12-25T09:53:13.753' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ReportTimeSystem] OFF
SET IDENTITY_INSERT [dbo].[RequisitionMain] ON 

INSERT [dbo].[RequisitionMain] ([OrderID], [ReportID], [EmployeeID], [RequisitionDate], [Price], [ApprovalStatusID], [ApprovaStatus]) VALUES (65, 2, 1011, CAST(N'2019-12-25T09:59:58.527' AS DateTime), 4000.0000, 3, N'審核完成')
INSERT [dbo].[RequisitionMain] ([OrderID], [ReportID], [EmployeeID], [RequisitionDate], [Price], [ApprovalStatusID], [ApprovaStatus]) VALUES (66, 2, 1011, CAST(N'2019-12-25T10:00:05.000' AS DateTime), 45000.0000, 1, N'新進員工只有2位')
INSERT [dbo].[RequisitionMain] ([OrderID], [ReportID], [EmployeeID], [RequisitionDate], [Price], [ApprovalStatusID], [ApprovaStatus]) VALUES (67, 2, 1033, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RequisitionMain] OFF
SET IDENTITY_INSERT [dbo].[ScoresLab] ON 

INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (1, N'A', N'國文', 87)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (2, N'B', N'英文', 89)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (3, N'C', N'數學', 50)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (4, N'D', N'國文', 45)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (5, N'A', N'英文', 64)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (6, N'B', N'數學', 43)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (7, N'C', N'國文', 78)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (8, N'D', N'英文', 32)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (9, N'A', N'數學', 32)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (10, N'B', N'國文', 78)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (11, N'C', N'英文', 50)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (12, N'D', N'數學', 68)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (13, N'A', N'國文', 12)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (14, N'B', N'英文', 9)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (15, N'C', N'數學', 98)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (16, N'D', N'國文', 63)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (17, N'A', N'英文', 98)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (18, N'B', N'數學', 88)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (19, N'C', N'國文', 25)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (20, N'D', N'英文', 67)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (21, N'A', N'數學', 87)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (22, N'B', N'國文', 58)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (23, N'C', N'英文', 47)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (24, N'D', N'數學', 1)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (25, N'A', N'國文', 98)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (26, N'B', N'英文', 58)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (27, N'C', N'數學', 14)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (28, N'D', N'國文', 88)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (29, N'A', N'英文', 36)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (30, N'B', N'數學', 99)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (31, N'C', N'國文', 78)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (32, N'D', N'英文', 55)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (33, N'A', N'數學', 25)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (34, N'B', N'國文', 12)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (35, N'C', N'英文', 78)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (36, N'D', N'數學', 100)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (37, N'A', N'國文', 12)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (38, N'B', N'英文', 41)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (39, N'C', N'數學', 45)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (40, N'D', N'國文', 98)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (41, N'A', N'英文', 63)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (42, N'B', N'數學', 78)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (43, N'C', N'國文', 55)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (44, N'D', N'英文', 12)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (45, N'A', N'數學', 35)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (46, N'B', N'國文', 2)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (47, N'D', N'英文', 88)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (48, N'C', N'數學', 98)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (49, N'A', N'國文', 65)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (50, N'B', N'英文', 32)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (51, N'C', N'數學', 78)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (52, N'D', N'國文', 11)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (53, N'A', N'數學', 60)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (54, N'A', N'數學', 77)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (55, N'A', N'數學', 65)
INSERT [dbo].[ScoresLab] ([id], [class], [subject], [score]) VALUES (56, N'A', N'數學', 70)
SET IDENTITY_INSERT [dbo].[ScoresLab] OFF
SET IDENTITY_INSERT [dbo].[sysdiagrams] ON 

INSERT [dbo].[sysdiagrams] ([name], [principal_id], [diagram_id], [version], [definition]) VALUES (N'Diagram_0', 1, 1, 1, 0xD0CF11E0A1B11AE1000000000000000000000000000000003E000300FEFF0900060000000000000000000000020000000100000000000000001000008300000001000000FEFFFFFF000000000000000027000000FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFDFFFFFF85000000030000000400000005000000060000000700000008000000090000000A0000000B0000000C0000000D0000000E0000000F000000100000001100000012000000130000001400000015000000160000001700000018000000190000001A0000001B0000001C0000001D0000001E0000001F00000020000000210000002200000023000000240000002500000026000000FEFFFFFFFDFFFFFF290000002A0000002B0000002C0000002D0000002E0000002F000000300000003100000032000000330000003400000035000000360000003700000038000000390000003A0000003B0000003C0000003D0000003E0000003F000000400000004100000042000000430000004400000045000000460000004700000048000000490000004A0000004B0000004C0000004D0000004E0000004F000000500000005100000052000000530000005400000055000000560000005700000058000000590000005A0000005B0000005C0000005D0000005E0000005F000000600000006100000062000000630000006400000065000000660000006700000068000000690000006A0000006B0000006C0000006D0000006E0000006F000000700000007100000072000000730000007400000075000000760000007700000078000000790000007A0000007B0000007C0000007D0000007E0000007F0000008000000052006F006F007400200045006E00740072007900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000016000500FFFFFFFFFFFFFFFF0200000000000000000000000000000000000000000000000000000000000000306B4EF0AE0DD60184000000800C0000000000006600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004000201FFFFFFFFFFFFFFFFFFFFFFFF000000000000000000000000000000000000000000000000000000000000000000000000020000005E480000000000006F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000040002010100000004000000FFFFFFFF000000000000000000000000000000000000000000000000000000000000000000000000280000007DB5000000000000010043006F006D0070004F0062006A0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000012000201FFFFFFFFFFFFFFFFFFFFFFFF000000000000000000000000000000000000000000000000000000000000000000000000000000005F00000000000000000434000A1E500C05000080BC0000000F00FFFF5A000000BC000000007D0000637800000A450000C46A0100CB78010097730000F28A0000DE805B10F195D011B0A000AA00BDCB5C00001800B300000006000080010000408822BC0253797374656DA13E030000003C006B0000000900000000000000D9E6B0E91C81D011AD5100A0C90F5739F43B7F847F61C74385352986E1D552F8A0327DB2D86295428D98273C25A2DA2D00002800430000000000000053444DD2011FD1118E63006097D2DF4834C9D2777977D811907000065B840D9C00002800430000000000000051444DD2011FD1118E63006097D2DF4834C9D2777977D811907000065B840D9CB60000005847000000FF0100B701012F00003000A50900000700008001000000A002000000800000070000805363684772696400868800007C9200004163636F756E740000003800A50900000700008002000000B0020000008000000F00008053636847726964007C920000FC020100416374697669746965734368696C640000003800A50900000700008003000000AE020000008000000E000080536368477269640044610000D0010100416374697669746965734D61696E64000000C800A5090000070000800400000052000000018000009E000000436F6E74726F6C00A07600006D080100270041006300740069007600690074006900650073004D00610069006E00270020008C542000270041006300740069007600690074006900650073004300680069006C006400270020004B4E93958476DC956F8027602000270046004B005F0041006300740069007600690074006900650073004300680069006C0064005F0041006300740069007600690074006900650073004D00610069006E002700B70600002800B50100000700008005000000310000007700000002800000436F6E74726F6C00EE7B0000B30A010000003000A50900000700008006000000A2020000008000000800008053636847726964009CF900004AC40000417070726F76616C00003C00A50900000700008007000000B40200000080000011000080536368477269646C5A1D0100E0C40000417070726F76616C50726F6365647572650000000000B800A5090000070000800800000052000000018000008E000000436F6E74726F6C6CF80E0100DFC30000270041007000700072006F00760061006C00500072006F00630065006400750072006500270020008C542000270041007000700072006F00760061006C00270020004B4E93958476DC956F8027602000270046004B005F0041007000700072006F00760061006C005F0041007000700072006F00760061006C00500072006F006300650064007500720065002700000000002800B50100000700008009000000310000006F00000002800000436F6E74726F6C6CAD0D010089C3000000003800A5090000070000800A000000AE020000008000000E000080536368477269646C36D800005AD20000417070726F76616C537461747573640000003400A5090000070000800B000000A8020000008000000B000080536368477269646CF20C0100580200004173704E6574526F6C65737400003800A5090000070000800C000000B20200000080000010000080536368477269646C2C2D0100903300004173704E657455736572436C61696D7300003800A5090000070000800D000000B20200000080000010000080536368477269646CF20C0100EE4D00004173704E6574557365724C6F67696E7300003800A5090000070000800E000000B0020000008000000F000080536368477269646CF20C0100181500004173704E657455736572526F6C6573730000D800A5090000070000800F0000005200000001800000B0000000436F6E74726F6C6C7D1601000909000027004100730070004E006500740052006F006C0065007300270020008C54200027004100730070004E0065007400550073006500720052006F006C0065007300270020004B4E93958476DC956F8027602000270046004B005F00640062006F005F004100730070004E0065007400550073006500720052006F006C00650073005F00640062006F005F004100730070004E006500740052006F006C00650073005F0052006F006C00650049006400270000002800B50100000700008010000000310000008F00000002800000436F6E74726F6C6CE5FA00006110000000003400A50900000700008011000000A8020000008000000B000080536368477269646CF20C0100302A00004173704E657455736572736F0000DC00A509000007000080120000005200000001800000B4000000436F6E74726F6C6C4E2201000139000027004100730070004E006500740055007300650072007300270020008C54200027004100730070004E0065007400550073006500720043006C00610069006D007300270020004B4E93958476DC956F8027602000270046004B005F00640062006F005F004100730070004E0065007400550073006500720043006C00610069006D0073005F00640062006F005F004100730070004E0065007400550073006500720073005F00550073006500720049006400270000002800B50100000700008013000000310000009100000002800000436F6E74726F6C6CEA170100473B00000000DC00A509000007000080140000005200000001800000B4000000436F6E74726F6C6C7D160100A648000027004100730070004E006500740055007300650072007300270020008C54200027004100730070004E006500740055007300650072004C006F00670069006E007300270020004B4E93958476DC956F8027602000270046004B005F00640062006F005F004100730070004E006500740055007300650072004C006F00670069006E0073005F00640062006F005F004100730070004E0065007400550073006500720073005F00550073006500720049006400270000002800B50100000700008015000000310000009100000002800000436F6E74726F6C6C71FA0000064C00000000D800A509000007000080160000005200000001800000B0000000436F6E74726F6C6C7D160100251E000027004100730070004E006500740055007300650072007300270020008C54200027004100730070004E0065007400550073006500720052006F006C0065007300270020004B4E93958476DC956F8027602000270046004B005F00640062006F005F004100730070004E0065007400550073006500720052006F006C00650073005F00640062006F005F004100730070004E0065007400550073006500720073005F00550073006500720049006400270000002800B50100000700008017000000310000008F00000002800000436F6E74726F6C6C1FFB00001325000000003800A50900000700008018000000AC020000008000000D000080536368477269646C4C680000D449000042756C6C6574696E426F61726465737300003C00A50900000700008019000000B80200000080000013000080536368477269646CA08C000000000000435F5F4D6967726174696F6E486973746F72790000003400A5090000070000801A000000AA020000008000000C000080536368477269646C5CC10000B40E0100436F6D6D656E744368696C6400003800A5090000070000801B000000AE020000008000000E000080536368477269646CA041000052160100436F6D6D656E74436F6E74656E74737300003400A5090000070000801C000000A8020000008000000B000080536368477269646C7E810000981B0100436F6D6D656E744D61696E650000B800A5090000070000801D00000062000000018000008E000000436F6E74726F6C6CA07600002F0A0100270041006300740069007600690074006900650073004D00610069006E00270020008C542000270043006F006D006D0065006E0074004D00610069006E00270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074004D00610069006E005F0041006300740069007600690074006900650073004D00610069006E002700000000002800B5010000070000801E000000310000006F00000002800000436F6E74726F6C6CDC6B0000791701000000B000A5090000070000801F000000620000000180000088000000436F6E74726F6C6CDA96000099160100270043006F006D006D0065006E0074004D00610069006E00270020008C542000270043006F006D006D0065006E0074004300680069006C006400270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074004300680069006C0064005F0043006F006D006D0065006E0074004D00610069006E003100270000002800B50100000700008020000000310000006D00000002800000436F6E74726F6C6C08A200000B2301000000B800A50900000700008021000000620000000180000090000000436F6E74726F6C6CFC5600006B190100270043006F006D006D0065006E00740043006F006E00740065006E007400270020008C542000270043006F006D006D0065006E0074004D00610069006E00270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074004D00610069006E005F0043006F006D006D0065006E00740043006F006E00740065006E0074003100270000002800B50100000700008022000000310000007100000002800000436F6E74726F6C6C175600003D26010000003800A50900000700008023000000AC020000008000000D000080536368477269646CA04100006A2B0100436F6D6D656E744F7074696F6E7473730000C000A50900000700008024000000520000000180000096000000436F6E74726F6C6C2B4B00005F1F0100270043006F006D006D0065006E0074004F007000740069006F006E00270020008C542000270043006F006D006D0065006E00740043006F006E00740065006E007400270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E00740043006F006E00740065006E0074005F0043006F006D006D0065006E0074004F007000740069006F006E002700000000002800B50100000700008025000000310000007300000002800000436F6E74726F6C6C714D00002326010000003800A50900000700008026000000B0020000008000000F000080536368477269646C5CC10000D42A0100436F6D6D656E745175657374696F6E730000C800A5090000070000802700000062000000018000009E000000436F6E74726F6C6CFC5600002D1B0100270043006F006D006D0065006E00740043006F006E00740065006E007400270020008C542000270043006F006D006D0065006E0074005100750065007300740069006F006E00270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074005100750065007300740069006F006E005F0043006F006D006D0065006E00740043006F006E00740065006E0074002700B70600002800B50100000700008028000000310000007700000002800000436F6E74726F6C6CD47600005F3101000000C000A50900000700008029000000520000000180000096000000436F6E74726F6C6CE7CA0000E31E0100270043006F006D006D0065006E0074005100750065007300740069006F006E00270020008C542000270043006F006D006D0065006E0074004300680069006C006400270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074004300680069006C0064005F0043006F006D006D0065006E0074005100750065007300740069006F006E002700000000002800B5010000070000802A000000310000007300000002800000436F6E74726F6C6C2DCD0000BE23010000003800A5090000070000802B000000AE020000008000000E000080536368477269646C46E60000387C0000436F6D70616E7956656869636C656E7300004000A5090000070000802C000000BC0200000080000015000080536368477269646CA2C60000387C0000436F6D70616E7956656869636C65486973746F72790800000000E400A5090000070000802D0000005200000001800000BC000000436F6E74726F6C6C13E000008F7D0000270043006F006D00700061006E007900560065006800690063006C006500270020008C542000270043006F006D00700061006E007900560065006800690063006C00650048006900730074006F0072007900270020004B4E93958476DC956F8027602000270046004B005F0043006F006D00700061006E0079005F00760065006800690063006C0065005F0068006900730074006F00720079005F0043006F006D00700061006E0079005F00760065006800690063006C006500270000002800B5010000070000802E000000310000008900000002800000436F6E74726F6C6C92D60000397D000000003400A5090000070000802F000000A6020000008000000A000080536368477269646CA41F0000624300004465706172746D656E7469630000B000A50900000700008030000000620000000180000088000000436F6E74726F6C6C003500007B46000027004400650070006100720074006D0065006E007400270020008C5420002700420075006C006C006500740069006E0042006F00610072006400270020004B4E93958476DC956F8027602000270046004B005F00420075006C006C006500740069006E005F0062006F006100720064005F004400650070006100720074006D0065006E007400270000002800B50100000700008031000000310000006D00000002800000436F6E74726F6C6C193F0000454C000000003000A50900000700008032000000A20200000080000008000080536368477269646C78B400007AA30000456D706C6F7965650000B000A50900000700008033000000620000000180000086000000436F6E74726F6C65239C000072CB0000270045006D0070006C006F00790065006500270020008C542000270041006300740069007600690074006900650073004300680069006C006400270020004B4E93958476DC956F8027602000270046004B005F0041006300740069007600690074006900650073004300680069006C0064005F0045006D0070006C006F007900650065002700270000002800B50100000700008034000000310000006B00000002800000436F6E74726F6C657AA800004DF600000000AC00A50900000700008035000000620000000180000082000000436F6E74726F6C65EB6A000072CB0000270045006D0070006C006F00790065006500270020008C542000270041006300740069007600690074006900650073004D00610069006E00270020004B4E93958476DC956F8027602000270046004B005F0041006300740069007600690074006900650073004D00610069006E005F0045006D0070006C006F007900650065002700650000002800B50100000700008036000000310000006900000002800000436F6E74726F6C65ED930000C7FB00000000A800A50900000700008037000000620000000180000080000000436F6E74726F6C6589720000035A0000270045006D0070006C006F00790065006500270020008C5420002700420075006C006C006500740069006E0042006F00610072006400270020004B4E93958476DC956F8027602000270046004B005F00420075006C006C006500740069006E005F0062006F006100720064005F0045006D0070006C006F00790065006500270000002800B50100000700008038000000310000006900000002800000436F6E74726F6C65879E0000B67200000000A800A5090000070000803900000062000000018000007E000000436F6E74726F6C651F730000035A0000270045006D0070006C006F00790065006500270020008C5420002700420075006C006C006500740069006E0042006F00610072006400270020004B4E93958476DC956F8027602000270046004B005F00420075006C006C006500740069006E0042006F006100720064005F0045006D0070006C006F007900650065002700270000002800B5010000070000803A000000310000006700000002800000436F6E74726F6C6513A000000F7200000000A400A5090000070000803B00000062000000018000007A000000436F6E74726F6C6553B9000072CB0000270045006D0070006C006F00790065006500270020008C542000270043006F006D006D0065006E0074004300680069006C006400270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074004300680069006C0064005F0045006D0070006C006F007900650065002700650000002800B5010000070000803C000000310000006500000002800000436F6E74726F6C65E6A90000CFFC00000000A000A5090000070000803D000000620000000180000076000000436F6E74726F6C65258B000072CB0000270045006D0070006C006F00790065006500270020008C542000270043006F006D006D0065006E0074004D00610069006E00270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074004D00610069006E005F0045006D0070006C006F007900650065002700000000002800B5010000070000803E000000310000006300000002800000436F6E74726F6C65698F00007BFC00000000CC00A5090000070000803F0000005200000001800000A2000000436F6E74726F6C65A1C50000F68B0000270045006D0070006C006F00790065006500270020008C542000270043006F006D00700061006E007900560065006800690063006C00650048006900730074006F0072007900270020004B4E93958476DC956F8027602000270046004B005F0043006F006D00700061006E0079005F00760065006800690063006C0065005F0068006900730074006F00720079005F0045006D0070006C006F007900650065002700A13E00002800B50100000700008040000000310000007B00000002800000436F6E74726F6C6575B000001399000000009C00A50900000700008041000000620000000180000072000000436F6E74726F6C652F290000134A000027004400650070006100720074006D0065006E007400270020008C542000270045006D0070006C006F00790065006500270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F007900650065005F004400650070006100720074006D0065006E0074002700650000002800B50100000700008042000000310000006100000002800000436F6E74726F6C6588660000BA76000000009400A509000007000080430000006A000000018000006A000000436F6E74726F6C6564AF0000669E0000270045006D0070006C006F00790065006500270020008C542000270045006D0070006C006F00790065006500270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F007900650065005F0045006D0070006C006F007900650065002700000000002800B50100000700008044000000310000005D00000002800000436F6E74726F6C6579AD000041A0000000003C00A50900000700008045000000BA020000008000001400008053636847726964659ABF00003A200000456D706C6F796565417070726F76616C54656D700000CC00A509000007000080460000006200000001800000A2000000436F6E74726F6C6500350000493A000027004400650070006100720074006D0065006E007400270020008C542000270045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004400650070006100720074006D0065006E0074002700A13E00002800B50100000700008047000000310000007900000002800000436F6E74726F6C65D76C0000733C00000000E800A509000007000080480000006200000001800000BE000000436F6E74726F6C652FBF0000D2580000270045006D0070006C006F00790065006500270020008C542000270045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004400650070006100720074006D0065006E0074004C00650061006400650072004200790045006D0070006C006F007900650065002700000000002800B50100000700008049000000310000009900000002800000436F6E74726F6C6575C100008B7900000000D400A5090000070000804A0000006200000001800000AA000000436F6E74726F6C6599BE0000D2580000270045006D0070006C006F00790065006500270020008C542000270045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F0045006400690074006F0072004200790045006D0070006C006F007900650065002700490000002800B5010000070000804B000000310000008500000002800000436F6E74726F6C65DFC00000157A00000000DC00A5090000070000804C0000006200000001800000B4000000436F6E74726F6C65C5BF0000D2580000270045006D0070006C006F00790065006500270020008C542000270045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F00470072006F00750070004C00650061006400650072004200790045006D0070006C006F00790065006500270000002800B5010000070000804D000000310000008F00000002800000436F6E74726F6C650BC20000027900000000D400A5090000070000804E0000006200000001800000AC000000436F6E74726F6C6503BE0000D2580000270045006D0070006C006F00790065006500270020008C542000270045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004D0061006E0061006700650072004200790045006D0070006C006F00790065006500270000002800B5010000070000804F000000310000008700000002800000436F6E74726F6C6549C000009F7A000000003000A509000007000080500000009C020000008000000500008053636847726964652CE200002C4C00004576656E7469646500003800A50900000700008051000000AC020000008000000D000080536368477269646536420000DC5000004576656E7443616C656E646172656E730000B000A509000007000080520000005A0000000180000086000000436F6E74726F6C6563310000134A000027004400650070006100720074006D0065006E007400270020008C54200027004500760065006E007400430061006C0065006E00640061007200270020004B4E93958476DC956F8027602000270046004B005F004500760065006E007400430061006C0065006E006400610072005F004400650070006100720074006D0065006E0074002700270000002800B50100000700008053000000310000006B00000002800000436F6E74726F6C657C2500009B5F00000000A800A5090000070000805400000062000000018000007E000000436F6E74726F6C65DD4B00008D6A0000270045006D0070006C006F00790065006500270020008C54200027004500760065006E007400430061006C0065006E00640061007200270020004B4E93958476DC956F8027602000270046004B005F004500760065006E007400430061006C0065006E006400610072005F0045006D0070006C006F007900650065002700270000002800B50100000700008055000000310000006700000002800000436F6E74726F6C65729900006A73000000002C00A509000007000080560000009A02000000800000040000805363684772696465CCD80000D4DF000046696C6500008400A5090000070000805700000062000000018000005A000000436F6E74726F6C65D4C9000049C30000270045006D0070006C006F00790065006500270020008C5420002700460069006C006500270020004B4E93958476DC956F8027602000270046004B005F00460069006C0065005F0045006D0070006C006F007900650065002700000000002800B50100000700008058000000310000005500000002800000436F6E74726F6C654AC7000006D8000000003000A509000007000080590000009C02000000800000050000805363684772696465488A0000CC42000047726F757069646500009C00A5090000070000805A000000520000000180000074000000436F6E74726F6C65A87D0000574C00002700470072006F0075007000270020008C5420002700420075006C006C006500740069006E0042006F00610072006400270020004B4E93958476DC956F8027602000270046004B005F00420075006C006C006500740069006E005F0062006F006100720064005F00470072006F0075007000270000002800B5010000070000805B000000310000006300000002800000436F6E74726F6C65837D00009D4E000000009000A5090000070000805C000000620000000180000066000000436F6E74726F6C6500350000B944000027004400650070006100720074006D0065006E007400270020008C5420002700470072006F0075007000270020004B4E93958476DC956F8027602000270046004B005F00470072006F00750070005F004400650070006100720074006D0065006E0074002700000000002800B5010000070000805D000000310000005B00000002800000436F6E74726F6C65B9570000FF46000000008800A5090000070000805E00000062000000018000005E000000436F6E74726F6C6519990000DD4B00002700470072006F0075007000270020008C542000270045006D0070006C006F00790065006500270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F007900650065005F00470072006F00750070002700000000002800B5010000070000805F000000310000005700000002800000436F6E74726F6C6512A60000EA7300000000B800A509000007000080600000005A000000018000008E000000436F6E74726F6C65D39300000B3C00002700470072006F0075007000270020008C542000270045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F00470072006F00750070002700270000002800B50100000700008061000000310000006F00000002800000436F6E74726F6C65AE9F0000353E000000003000A509000007000080620000009C0200000080000005000080536368477269646508E80000AE4101004C6561766569646500003400A50900000700008063000000AA020000008000000C0000805363684772696465AC070100103A01004C65617665486973746F72790000A400A5090000070000806400000062000000018000007A000000436F6E74726F6C65A1C5000072CB0000270045006D0070006C006F00790065006500270020008C54200027004C00650061007600650048006900730074006F0072007900270020004B4E93958476DC956F8027602000270046004B005F004C00650061007600650048006900730074006F00720079005F0045006D0070006C006F007900650065002700650000002800B50100000700008065000000310000006500000002800000436F6E74726F6C650BE70000DFFA000000009800A5090000070000806600000052000000018000006E000000436F6E74726F6C6564FD0000C744010027004C006500610076006500270020008C54200027004C00650061007600650048006900730074006F0072007900270020004B4E93958476DC956F8027602000270046004B005F004C00650061007600650048006900730074006F00720079005F004C0065006100760065002700000000002800B50100000700008067000000310000005F00000002800000436F6E74726F6C657DFD00000D47010000004000A50900000700008068000000C20200000080000018000080536368477269646500E10000D00101004C65617665486973746F7279417070726F76616C54656D700000D400A509000007000080690000006200000001800000AA000000436F6E74726F6C65DFC3000072CB0000270045006D0070006C006F00790065006500270020008C54200027004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F007900650065002700270000002800B5010000070000806A000000310000007D00000002800000436F6E74726F6C65D0B1000093FB00000000F800A5090000070000806B0000006200000001800000CE000000436F6E74726F6C651DC2000072CB0000270045006D0070006C006F00790065006500270020008C54200027004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F00790065006500420079004400650070006100720074006D0065006E0074004C00650061006400650072002700000000002800B5010000070000806C00000031000000A100000002800000436F6E74726F6C65ADF20000920001000000DC00A5090000070000806D0000006200000001800000B2000000436F6E74726F6C6599BE000072CB0000270045006D0070006C006F00790065006500270020008C54200027004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F007900650065004200790047004D002700270000002800B5010000070000806E000000310000008500000002800000436F6E74726F6C65D3A60000AFFD00000000EC00A5090000070000806F0000006200000001800000C4000000436F6E74726F6C65D7BC000072CB0000270045006D0070006C006F00790065006500270020008C54200027004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F0079006500650042007900470072006F00750070004C0065006100640065007200270000002800B50100000700008070000000310000009700000002800000436F6E74726F6C6553C4000063FE00000000C800A5090000070000807500000052000000018000009E000000436F6E74726F6C6593F10000A735010027004C006500610076006500270020008C54200027004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F004C0065006100760065002700B70600002800B50100000700008076000000310000007700000002800000436F6E74726F6C65D9F30000693C010000003400A50900000700008077000000A8020000008000000B0000805363684772696465DE200100CE7C00004D656574696E67526F6F6D7900003C00A50900000700008078000000B602000000800000120000805363684772696465861E0100C29700004D656574696E67526F6F6D486973746F7279616C0000C000A50900000700008079000000520000000180000096000000436F6E74726F6C65D4C900003BA40000270045006D0070006C006F00790065006500270020008C54200027004D0065006500740069006E00670052006F006F006D0048006900730074006F0072007900270020004B4E93958476DC956F8027602000270046004B005F004D0065006500740069006E0067005F0072006F006F006D005F0068006900730074006F00720079005F0045006D0070006C006F007900650065002700000000002800B5010000070000807A000000310000007500000002800000436F6E74726F6C659FEA000081A600000000CC00A5090000070000807B0000005200000001800000A4000000436F6E74726F6C6571310100A18A000027004D0065006500740069006E00670052006F006F006D00270020008C54200027004D0065006500740069006E00670052006F006F006D0048006900730074006F0072007900270020004B4E93958476DC956F8027602000270046004B005F004D0065006500740069006E0067005F0072006F006F006D005F0068006900730074006F00720079005F004D0065006500740069006E0067005F0072006F006F006D00270000002800B5010000070000807C000000310000007D00000002800000436F6E74726F6C65971B0100A392000000003000A5090000070000807D000000A002000000800000070000805363684772696465D494000080BB00004D6573736167656500009000A5090000070000807E000000620000000180000066000000436F6E74726F6C6530AA000027B80000270045006D0070006C006F00790065006500270020008C54200027004D00650073007300610067006500270020004B4E93958476DC956F8027602000270046004B005F004D006500730073006100670065005F0045006D0070006C006F007900650065002700000000002800B5010000070000807F000000310000005B00000002800000436F6E74726F6C6510A00000D4BA000000003000A509000007000080800000009E0200000080000006000080536368477269646566020100CE7C00004F666669636564650000A400A5090000070000808100000052000000018000007C000000436F6E74726F6C65A2FB00000184000027004F0066006600690063006500270020008C542000270043006F006D00700061006E007900560065006800690063006C006500270020004B4E93958476DC956F8027602000270046004B005F0043006F006D00700061006E0079005F00760065006800690063006C0065005F004F0066006600690063006500270000002800B50100000700008082000000310000006700000002800000436F6E74726F6C65B7F700004786000000008C00A509000007000080830000006A0000000180000062000000436F6E74726F6C65D4C90000DF85000027004F0066006600690063006500270020008C542000270045006D0070006C006F00790065006500270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F007900650065005F004F00660066006900630065002700650000002800B50100000700008084000000310000005900000002800000436F6E74726F6C6575F300004FA300000000BC00A509000007000080850000005A0000000180000092000000436F6E74726F6C654ED90000A13C000027004F0066006600690063006500270020008C542000270045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004F00660066006900630065002700650000002800B50100000700008086000000310000007100000002800000436F6E74726F6C652F0701009F45000000009800A50900000700008087000000520000000180000070000000436F6E74726F6C65C2170100A981000027004F0066006600690063006500270020008C54200027004D0065006500740069006E00670052006F006F006D00270020004B4E93958476DC956F8027602000270046004B005F004D0065006500740069006E0067005F0072006F006F006D005F004F0066006600690063006500270000002800B50100000700008088000000310000006100000002800000436F6E74726F6C6526150100EF83000000003400A50900000700008089000000A8020000008000000B00008053636847726964659CF9000082AA00004F7264657244657461696C7900003000A5090000070000808A000000A202000000800000080000805363684772696465609F0000C8640000506F736974696F6E00009400A5090000070000808B00000062000000018000006A000000436F6E74726F6C6EEBA80000796B0000270050006F0073006900740069006F006E00270020008C542000270045006D0070006C006F00790065006500270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F007900650065005F0050006F0073006900740069006F006E002700630000002800B5010000070000808C000000310000005D00000002800000436F6E74726F6C6EF2B10000C97E00000000C400A5090000070000808D00000062000000018000009A000000436F6E74726F6C6EBCB40000CD3D0000270050006F0073006900740069006F006E00270020008C542000270045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000270020004B4E93958476DC956F8027602000270046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F0050006F0073006900740069006F006E002700650000002800B5010000070000808E000000310000007500000002800000436F6E74726F6C6E67BE00000658000000003400A5090000070000808F000000A40200000080000009000080536368477269646ED49400007AA30000526563697069656E74696C7900009800A5090000070000809000000062000000018000006E000000436F6E74726F6C6E30AA000007A90000270045006D0070006C006F00790065006500270020008C542000270052006500630069007000690065006E007400270020004B4E93958476DC956F8027602000270046004B005F0052006500630069007000690065006E0074005F0045006D0070006C006F007900650065002700270000002800B50100000700008091000000310000005F00000002800000436F6E74726F6C6E7F9F00007CB4000000009400A5090000070000809200000052000000018000006A000000436F6E74726F6C6E5F9E0000E8AE000027004D00650073007300610067006500270020008C542000270052006500630069007000690065006E007400270020004B4E93958476DC956F8027602000270046004B005F0052006500630069007000690065006E0074005F004D006500730073006100670065002700650000002800B50100000700008093000000310000005D00000002800000436F6E74726F6C6EA5A00000B7B4000000003000A509000007000080940000009C0200000080000005000080536368477269646EE6270100D00101005265706C7969646E00008800A5090000070000809500000062000000018000005E000000436F6E74726F6C6E63C7000072CB0000270045006D0070006C006F00790065006500270020008C54200027005200650070006C007900270020004B4E93958476DC956F8027602000270046004B005F005200650070006C0079005F0045006D0070006C006F007900650065002700000000002800B50100000700008096000000310000005700000002800000436F6E74726F6C6E72E000002BFA000000003800A50900000700008097000000AE020000008000000E000080536368477269646E36D8000018AB00005265706F727443617465676F72796E7300003800A50900000700008098000000B20200000080000010000080536368477269646E2CE20000FE5B00005265706F727454696D6553797374656D0000B400A509000007000080990000005A000000018000008A000000436F6E74726F6C6E5BC000000D760000270045006D0070006C006F00790065006500270020008C54200027005200650070006F0072007400540069006D006500530079007300740065006D00270020004B4E93958476DC956F8027602000270046004B005F005200650070006F0072007400540069006D006500530079007300740065006D005F0045006D0070006C006F007900650065002700700000002800B5010000070000809A000000310000006D00000002800000436F6E74726F6C6EA1C20000D17D00000000A800A5090000070000809B00000052000000018000007E000000436F6E74726F6C6E2BE10000DD52000027004500760065006E007400270020008C54200027005200650070006F0072007400540069006D006500530079007300740065006D00270020004B4E93958476DC956F8027602000270046004B005F005200650070006F0072007400540069006D006500530079007300740065006D005F004500760065006E0074002700270000002800B5010000070000809C000000310000006700000002800000436F6E74726F6C6E14D200004758000000003800A5090000070000809D000000B0020000008000000F000080536368477269646E36D80000EABA00005265717569736974696F6E4D61696E6D0000C800A5090000070000809E00000052000000018000009E000000436F6E74726F6C6E35D7000019CB0000270041007000700072006F00760061006C00530074006100740075007300270020008C54200027005200650071007500690073006900740069006F006E004D00610069006E00270020004B4E93958476DC956F8027602000270046004B005F005200650071007500690073006900740069006F006E004D00610069006E005F0041007000700072006F00760061006C005300740061007400750073002700B70600002800B5010000070000809F000000310000007700000002800000436F6E74726F6C6E83C400006DCF00000000B000A509000007000080A0000000520000000180000086000000436F6E74726F6C6ED4C90000E9B90000270045006D0070006C006F00790065006500270020008C54200027005200650071007500690073006900740069006F006E004D00610069006E00270020004B4E93958476DC956F8027602000270046004B005F005200650071007500690073006900740069006F006E004D00610069006E005F0045006D0070006C006F007900650065002700270000002800B501000007000080A1000000310000006B00000002800000436F6E74726F6C6E28C9000093B900000000C800A509000007000080A200000052000000018000009E000000436F6E74726F6C6E35D70000C9B1000027005200650070006F0072007400430061007400650067006F0072007900270020008C54200027005200650071007500690073006900740069006F006E004D00610069006E00270020004B4E93958476DC956F8027602000270046004B005F005200650071007500690073006900740069006F006E004D00610069006E005F005200650070006F0072007400430061007400650067006F00720079002700B70600002800B501000007000080A3000000310000007700000002800000436F6E74726F6C6E10C4000016B700000000BC00A509000007000080A4000000520000000180000094000000436F6E74726F6C6E92ED0000E9B9000027005200650071007500690073006900740069006F006E004D00610069006E00270020008C54200027004F007200640065007200440065007400610069006C00270020004B4E93958476DC956F8027602000270046004B005F004F007200640065007200440065007400610069006C005F005200650071007500690073006900740069006F006E004D00610069006E003100270000002800B501000007000080A5000000310000007300000002800000436F6E74726F6C6E17EA00002FBC00000000B000A509000007000080A6000000520000000180000086000000436F6E74726F6C6E92ED0000CDC6000027005200650071007500690073006900740069006F006E004D00610069006E00270020008C542000270041007000700072006F00760061006C00270020004B4E93958476DC956F8027602000270046004B005F0041007000700072006F00760061006C005F005200650071007500690073006900740069006F006E004D00610069006E002700270000002800B501000007000080A7000000310000006B00000002800000436F6E74726F6C6EE5EB000013C9000000003C00A509000007000080A8000000B80200000080000013000080536368477269646E8A66000000000000526577617264616E6450756E6973686D656E746C00003400A509000007000080A9000000A6020000008000000A000080536368477269646E000000007E36000053756767657374696F6E6E4D00003C00A509000007000080AA000000B40200000080000011000080536368477269646E000000003E49000053756767657374696F6E486973746F72796E746C0000C000A509000007000080AB000000620000000180000098000000436F6E74726F6C6E5C1500007B46000027004400650070006100720074006D0065006E007400270020008C5420002700530075006700670065007300740069006F006E0048006900730074006F0072007900270020004B4E93958476DC956F8027602000270046004B005F00530075006700670065007300740069006F006E005F0068006900730074006F00720079005F004400650070006100720074006D0065006E007400270000002800B501000007000080AC000000310000007500000002800000436F6E74726F6C6E1C040000F04700000000B800A509000007000080AD000000620000000180000090000000436F6E74726F6C6EA70900000D570000270045006D0070006C006F00790065006500270020008C5420002700530075006700670065007300740069006F006E0048006900730074006F0072007900270020004B4E93958476DC956F8027602000270046004B005F00530075006700670065007300740069006F006E005F0068006900730074006F00720079005F0045006D0070006C006F00790065006500270000002800B501000007000080AE000000310000007100000002800000436F6E74726F6C6EE26B0000D27400000000C000A509000007000080AF000000520000000180000098000000436F6E74726F6C6E8B0900002F3D00002700530075006700670065007300740069006F006E00270020008C5420002700530075006700670065007300740069006F006E0048006900730074006F0072007900270020004B4E93958476DC956F8027602000270046004B005F00530075006700670065007300740069006F006E005F0068006900730074006F00720079005F00530075006700670065007300740069006F006E00270000002800B501000007000080B0000000310000007500000002800000436F6E74726F6C6EC0F7FFFFBE40000000003400A509000007000080B1000000A6020000008000000A000080536368477269646EFC210000000000005375727665794D61696E6E4D00003400A509000007000080B2000000A6020000008000000A000080536368477269646E8E440000000000007379736469616772616D6E4D00003400A509000007000080B3000000A8020000008000000B000080536368477269646E00000000000000007379736469616772616D734D00003400A509000007000080B4000000AA020000008000000C000080536368477269646E84990000E8160100436F6D6D656E745265706C790000B400A509000007000080B500000052000000018000008A000000436F6E74726F6C6ECDB50000E7150100270043006F006D006D0065006E0074004300680069006C006400270020008C542000270043006F006D006D0065006E0074005200650070006C007900270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074005200650070006C0079005F0043006F006D006D0065006E0074004300680069006C0064002700650000002800B501000007000080B6000000310000006D00000002800000436F6E74726F6C6EFCAD0000911501000000B400A509000007000080B700000052000000018000008C000000436F6E74726F6C6ECDB50000E7150100270043006F006D006D0065006E0074004300680069006C006400270020008C542000270043006F006D006D0065006E0074005200650070006C007900270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074005200650070006C0079005F0043006F006D006D0065006E0074004300680069006C0064003100270000002800B501000007000080B8000000310000006F00000002800000436F6E74726F6C6E4FAD0000911501000000B000A509000007000080B9000000520000000180000086000000436F6E74726F6C6EC996000035220100270043006F006D006D0065006E0074004D00610069006E00270020008C542000270043006F006D006D0065006E0074005200650070006C007900270020004B4E93958476DC956F8027602000270046004B005F0043006F006D006D0065006E0074005200650070006C0079005F0043006F006D006D0065006E0074004D00610069006E002700270000002800B501000007000080BA000000310000006B00000002800000436F6E74726F6C6E328F00007B240100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000008100000082000000FEFFFFFFFEFFFFFFCE000000FEFFFFFF8700000088000000890000008A0000008B0000008C0000008D0000008E0000008F000000900000009100000092000000930000009400000095000000960000009700000098000000990000009A0000009B0000009C0000009D0000009E0000009F000000A0000000A1000000A2000000A3000000A4000000A5000000A6000000A7000000A8000000A9000000AA000000AB000000AC000000AD000000AE000000AF000000B0000000B1000000B2000000B3000000B4000000B5000000B6000000B7000000B8000000B9000000BA000000BB000000BC000000BD000000BE000000BF000000C0000000C1000000C2000000C3000000C4000000C5000000C6000000C7000000C8000000C9000000CA000000CB000000CC000000CD000000FEFFFFFFCF000000D0000000D1000000D2000000D3000000FEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF214334120800000088160000680900007856341207000000140100004100630063006F0075006E00740000002800640062006F00290000009E9D1D3F0000803F0000003F0000803FF3F2723F9E9D1D3F0000803F0000803F0000803FF3F2723F9E9D1D3F0000803F0000000001000000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000F03F0000000000000000C4AB966C0000000000000000846C976C1C58976C5093C4265093C4260200000002000000000000000000000038ED390E000000000200000000000000000000000000000000806144008061C40000000000000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000F80A00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005800000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000080000004100630063006F0075006E0074000000214334120800000088160000290E000078563412070000001401000041006300740069007600690074006900650073004300680069006C00640000002800640062006F0029000000DCDB5B3FEAE9693F0000803F72006F0073006F00660074002000530051004C0020005300650072007600650072005C003100340030005C0054006F006F006C0073005C00420069006E006E005C004D0061006E006100670065006D0065006E007400530074007500640069006F005C004D00610073006800750070005C007A0068002D00540057005C004D006900630072006F0073006F00660074002E004E006500740045006E007400650072007000720069007300650053006500720076006500000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000290E000000000000040000000400000002000000020000001C01000080070000000000000100000039130000060A000000000000030000000300000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006800000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000001000000041006300740069007600690074006900650073004300680069006C00640000002143341208000000881600008A10000078563412070000001401000041006300740069007600690074006900650073004D00610069006E0000002800640062006F0029000000543E9392923ED5D4D43E0000803F0000803FA5A4243EE5E4643EABAAAA3E0000803F0000000001000000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000F03F0000000000000000C4AB966C0000000000000000846C976C1C58976CF8A3C426F8A3C42602000000020000000000000000000000A0F2520E00000000020000000000000000000040000000000000A841000098C10000004000000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600008A10000000000000050000000500000002000000020000001C01000080070000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006600000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000F00000041006300740069007600690074006900650073004D00610069006E00000002000B00CC770000040A01007C920000040A01000000000002000000F0F0F00000000000000000000000000000000000010000000500000000000000EE7B0000B30A01003F1200003E010000310000000100000200003F1200003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9210046004B005F0041006300740069007600690074006900650073004300680069006C0064005F0041006300740069007600690074006900650073004D00610069006E00214334120800000088160000712F000078563412070000001401000041007000700072006F00760061006C0000002800640062006F0029000000693F0000803F0000803FD7D6563FDCDB5B3FEAE9693F0000803FB8CDC909B8CDC909C4CDC909C4CDC909D0CDC909D0CDC909DCCDC909DCCDC909E8CDC909E8CDC909F4CDC909F4CDC90900CEC90900CEC9090CCEC9090CCEC90918CEC90918CEC90924CEC90924CEC90930CEC90930CEC9093CCEC9093CCEC90948CEC90948CEC90954CEC90954CEC90960CEC90960CEC9096CCEC9096CCEC90978CEC90978CEC90984CEC90984CEC90990CEC90990CEC9099CCEC9099CCEC909A8CEC909A8CEC909B4CEC909B4CEC909C0CEC909C0CE000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000009230000000000002D0100000D0000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000712F000000000000120000000C00000002000000020000001C01000000090000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005A00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000900000041007000700072006F00760061006C0000002143341208000000BD1600004B15000078563412070000001401000041007000700072006F00760061006C00500072006F0063006500640075007200650000002800640062006F002900000000406F400000000000003340000000000000F03F00000000000000000000000001000000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000F03F0000000000000000C4AB966C0000000000000000846C976C1C58976CE095C426E095C4260200000002000000000000000000000038C6390E00000000020000000000000000000040000000000000A841000098C10000004000000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000F1190000000000002D010000090000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000BD1600004B15000000000000070000000700000002000000020000001C010000800700000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006C00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000001200000041007000700072006F00760061006C00500072006F00630065006400750072006500000002000B005A1D010076C500002410010076C500000000000002000000F0F0F00000000000000000000000000000000000010000000900000000000000AD0D010089C30000231200003E01000032000000010000020000231200003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91D0046004B005F0041007000700072006F00760061006C005F0041007000700072006F00760061006C00500072006F006300650064007500720065002143341208000000881600006809000078563412070000001401000041007000700072006F00760061006C0053007400610074007500730000002800640062006F002900000061006C00750065002000460052004F004D0020007300790073002E0065007800740065006E006400650064005F00700072006F0070006500720074006900650073002000570048004500520045002000280063006C0061007300730020003D00200031002900200041004E004400200028006D0069006E006F0072005F006900640020003D00200030002900200041004E004400200028006D0061006A006F0072005F006900640020003D0020004F0042004A004500430054005F004900440028004E00000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000040B00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006600000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000F00000041007000700072006F00760061006C005300740061007400750073000000214334120800000088160000680900007856341207000000140100004100730070004E006500740052006F006C006500730000002800640062006F00290000000300000000000000200200000200000000000000000000000040D0D1B0FFD4010000000000000000B06BFD0D000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000030EFFB0D78DCFC0D50EFFB0D0000000000000000000000000000000000000000000000000000000000000000412A03A67B677A9A7549937EBE97C8A7CB17E431673EE209FE455793F30AFA1C1400000030F6FB0D1400000070F1FB0DD8B5FB368468620275D1000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000340800000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006000000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000C0000004100730070004E006500740052006F006C00650073000000214334120800000088160000290E00007856341207000000140100004100730070004E0065007400550073006500720043006C00610069006D00730000002800640062006F00290000000000F0FAFB0D00000000000000001000000004FBFB0D00000000000000001000000018FBFB0D0000000000000000100000002CFBFB0D00000000000000001000000040FBFB0D00000000000000001000000054FBFB0D00000000000000001000000068FBFB0D0000000000000000100000007CFBFB0D00000000000000001000000090FBFB0D000000000000000010000000A4FBFB0D000000000000000010000000B8FBFB0D000000000000000010000000CCFBFB0D00000000000000001000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000290E000000000000040000000400000002000000020000001C01000080070000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006A00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000110000004100730070004E0065007400550073006500720043006C00610069006D0073000000214334120800000088160000C80B00007856341207000000140100004100730070004E006500740055007300650072004C006F00670069006E00730000002800640062006F00290000000000000000000000000000000000000000000000000000000000000000005881060968B1FE0D000000000000000058D8FC0D00000000000000000000000000000000000000000000000038D7FC0D0000000000000000000000000000000050D7FC0D10F4FB0D0000000000000000000000000000000000000000000000000000000028B3FE0D00000000000000000000000000000000C1365E95A5A52AB7A3A7B05F257D87C214000000F070FF0D1400000010F5FB0DD1C653787ED09BA3DF9B000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000C80B000000000000030000000300000002000000020000001C01000034080000000000000100000039130000060A000000000000030000000300000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006A00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000110000004100730070004E006500740055007300650072004C006F00670069006E0073000000214334120800000088160000C80B00007856341207000000140100004100730070004E0065007400550073006500720052006F006C006500730000002800640062006F002900000090000000B7E2680EF9430D090200000058E3680E0E0100005FE3680E000000000000000000000000000000000000000000000000000000000B00000048663B0E84840400000042269163FBEB6854848404002D003C01000012041B0E00000000E401000089E4680E31440D09000000001A0000007CE6680E09E7230E0000000031000000A5E6680ED8440D090000000079000000E5E6680EEB9DB506000000001600000067E7680E939BB506000000000400000086E7680E1BDC0309000000003B00000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000C80B000000000000030000000300000002000000020000001C01000034080000000000000100000039130000060A000000000000030000000300000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006800000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000100000004100730070004E0065007400550073006500720052006F006C0065007300000002000B0014180100C00B000014180100181500000000000002000000F0F0F00000000000000000000000000000000000010000001000000000000000E5FA000061100000801C00003E01000039000000010000020000801C00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E92D0046004B005F00640062006F005F004100730070004E0065007400550073006500720052006F006C00650073005F00640062006F005F004100730070004E006500740052006F006C00650073005F0052006F006C006500490064002143341208000000881600002D2100007856341207000000140100004100730070004E00650074005500730065007200730000002800640062006F002900000080AEF89B56A3D7018A000000EF95680EF9430D09020000008A96680E0E0100009196680E000000000000000000000000000000000000000000000000000000000B000000F04D3B0E0B030B000000349240DF6C976DC20B030B002D6318E0546312041B0E00000000E4010000BB97680E31440D09000000001A000000AE99680E09E7230E0000000031000000D799680ED8440D090000000079000000179A680EEB9DB5060000000016000000999A680E939BB5060000000004000000B89A680E1BDC0309000000005200000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000009230000000000002D0100000D0000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600002D210000000000000C0000000C00000002000000020000001C010000340800000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006000000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000C0000004100730070004E006500740055007300650072007300000002000B007A230100983A00002C2D0100983A00000000000002000000F0F0F00000000000000000000000000000000000010000001300000000000000EA170100473B0000F41C00003E0100003C000000010000020000F41C00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E92E0046004B005F00640062006F005F004100730070004E0065007400550073006500720043006C00610069006D0073005F00640062006F005F004100730070004E0065007400550073006500720073005F0055007300650072004900640002000B00141801005D4B000014180100EE4D00000000000002000000F0F0F0000000000000000000000000000000000001000000150000000000000071FA0000064C0000F41C00003E01000032000000010000020000F41C00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E92E0046004B005F00640062006F005F004100730070004E006500740055007300650072004C006F00670069006E0073005F00640062006F005F004100730070004E0065007400550073006500720073005F0055007300650072004900640002000B0014180100302A000014180100E02000000000000002000000F0F0F000000000000000000000000000000000000100000017000000000000001FFB000013250000461C00003E01000030000000010000020000461C00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E92D0046004B005F00640062006F005F004100730070004E0065007400550073006500720052006F006C00650073005F00640062006F005F004100730070004E0065007400550073006500720073005F00550073006500720049006400214334120800000088160000EA120000785634120700000014010000420075006C006C006500740069006E0042006F0061007200640000002800640062006F00290000000000000020000000020000000000000000000000000000000000000000000000000000007032010E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000088CE040EE0BBFF0D0000000000000000000000000000000000000000000000000000000000000000000000005C84057213689D6E08BB96B622BDF5157F667A71D3EB6978209A51149D83DA2010000000B0BBFF0D140000006837050E181C2BE05851F96993E1000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000AB170000000000002D010000080000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000EA12000000000000060000000600000002000000020000001C010000480900000000000001000000391300004D0C000000000000040000000400000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006400000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000E000000420075006C006C006500740069006E0042006F006100720064000000214334120800000091170000290E000078563412070000001401000043005F005F004D006900670072006100740069006F006E0048006900730074006F007200790000002800640062006F0029000000460052004F004D0020007300790073002E0065007800740065006E006400650064005F00700072006F0070006500720074006900650073002000570048004500520045002000280063006C0061007300730020003D00200031002900200041004E004400200028006D0069006E006F0072005F006900640020003D00200030002900200041004E004400200028006D0061006A006F0072005F006900640020003D0020004F0042004A004500430054005F004900440028004E00000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000091170000290E000000000000040000000400000002000000020000001C010000880B0000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000007000000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000001400000043005F005F004D006900670072006100740069006F006E0048006900730074006F00720079000000214334120800000088160000EA12000078563412070000001401000043006F006D006D0065006E0074004300680069006C00640000002800640062006F00290000000000000000000020000000000000000000000000000000000000000000000000000000000000B880060900000000000000000000000000000000000000000000000000000000000000000000000000000000D86D0A0900000000000000000000000000000000F06D0A09F8BBFB0D000000000000000000000000000000000000000000000000000000007025010E000000000000000000000000000000000832B65CC3E3A49BC381BA95E1B587371400000098BBFB0D1400000098BDFB0D625EFD0E9B0A5790333D000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000AB170000000000002D010000080000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000EA12000000000000060000000600000002000000020000001C010000740A00000000000001000000391300004D0C000000000000040000000400000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006200000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000D00000043006F006D006D0065006E0074004300680069006C0064000000214334120800000088160000C80B000078563412070000001401000043006F006D006D0065006E00740043006F006E00740065006E00740000002800640062006F002900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000055005200FA57B60E490300800300360034002F000300360048005500590048005500030030004400510044004A004800500000008040000000410000A040000000410000804000008040000040400000E040000020410000C04000004040000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000C80B000000000000030000000300000002000000020000001C01000080070000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006600000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000F00000043006F006D006D0065006E00740043006F006E00740065006E0074000000214334120800000088160000EA12000078563412070000001401000043006F006D006D0065006E0074004D00610069006E0000002800640062006F00290000000000000000000000000018402800000018000000C70D0000180000001800000045000000C80D000000000000C90D00000000000010000000220000001E000000C70D00001000000007000000CA0D00002B0000001000000007000000CB0D000049000000380100007C000000CB0D000000000000000000002001000020010000020000000000000000000000000000000000000000000000000041400000000000003A400200000000000000000000000C00000001000000780000000000000000000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000AB170000000000002D010000080000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000EA12000000000000060000000600000002000000020000001C010000800700000000000001000000391300004D0C000000000000040000000400000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006000000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000C00000043006F006D006D0065006E0074004D00610069006E00000004000B00CC770000C60B0100E87E0000C60B0100E87E0000CC2301007E810000CC2301000000000002000000F0F0F00000000000000000000000000000000000010000001E00000000000000DC6B0000791701005D1200003E010000360000000100000200005D1200003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91D0046004B005F0043006F006D006D0065006E0074004D00610069006E005F0041006300740069007600690074006900650073004D00610069006E0004000B0006980000F82401008CB90000F82401008CB90000141801005CC10000141801000000000002000000F0F0F0000000000000000000000000000000000001000000200000000000000008A200000B2301009A1300003E0100002F0000000100000200009A1300003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91C0046004B005F0043006F006D006D0065006E0074004300680069006C0064005F0043006F006D006D0065006E0074004D00610069006E00310004000B0028580000021B0100445F0000021B0100445F00008E2501007E8100008E2501000000000002000000F0F0F00000000000000000000000000000000000010000002200000000000000175600003D260100D71400003E01000039000000010000020000D71400003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91E0046004B005F0043006F006D006D0065006E0074004D00610069006E005F0043006F006D006D0065006E00740043006F006E00740065006E00740031002143341208000000881600006809000078563412070000001401000043006F006D006D0065006E0074004F007000740069006F006E0000002800640062006F00290000005500000010000000080000005E0A00002B0000001000000008000000600A00002A0000001000000008000000610A00002A00000010000000080000005F0A00004B0000001000000008000000620A00002A00000010000000080000005D0A00002B0000001000000008000000590A00002B00000010000000080000005A0A00005500000010000000080000005B0A00004B00000010000000080000005C0A00004D00000010000000080000006E0B00002B0000001000000008000000770B0000550000001000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000800700000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006400000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000E00000043006F006D006D0065006E0074004F007000740069006F006E00000002000B00C24C00006A2B0100C24C00001A2201000000000002000000F0F0F00000000000000000000000000000000000010000002500000000000000714D000023260100111500003E01000032000000010000020000111500003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91F0046004B005F0043006F006D006D0065006E00740043006F006E00740065006E0074005F0043006F006D006D0065006E0074004F007000740069006F006E00214334120800000088160000C80B000078563412070000001401000043006F006D006D0065006E0074005100750065007300740069006F006E0000002800640062006F002900000000000000000000402800000018000000BE030000180000001800000045000000BF03000000000000C0030000000000001000000022000000BD030000BE0300000D535B0B260E0080BC030000BD030000000000001000000007000000C1030000270000001000000007000000C2030000270000001000000007000000C30300002B0000001000000007000000C40300004B000000340000007D000000C4030000000000000000F03F6884583D6884583D6884583D0000803F00000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000C80B000000000000030000000300000002000000020000001C0100002C070000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006800000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000001000000043006F006D006D0065006E0074005100750065007300740069006F006E00000004000B0028580000C41C0100905E0000C41C0100905E0000B03001005CC10000B03001000000000002000000F0F0F00000000000000000000000000000000000010000002800000000000000D47600005F310100141600003E0100003A000000010000020000141600003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9210046004B005F0043006F006D006D0065006E0074005100750065007300740069006F006E005F0043006F006D006D0065006E00740043006F006E00740065006E00740002000B007ECC0000D42A01007ECC00009E2101000000000002000000F0F0F00000000000000000000000000000000000010000002A000000000000002DCD0000BE230100D71400003E01000049000000010000020000D71400003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91F0046004B005F0043006F006D006D0065006E0074004300680069006C0064005F0043006F006D006D0065006E0074005100750065007300740069006F006E002143341208000000881600000C1A000078563412070000001401000043006F006D00700061006E007900560065006800690063006C00650000002800640062006F00290000000000E5040000A104000000000000000000000000803F0000000000000000010000000000803F0000803F0000803F000000003100000000000000980000009800000000000000000000000000000000000000000000000000000000000000010000000101000100000000000101000001000000490064000000006800000000000000000000000000000000000000280000000000000005000000000000000000000003000000000000000000F03F0000000000000000000000000000F03F000000000000000000000000000000000100000005000000540000002C0000002C0000002C000000340000000000000000000000222900007D1E0000000000002D0100000B0000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600000C1A000000000000090000000900000002000000020000001C010000F80A0000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006600000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000F00000043006F006D00700061006E007900560065006800690063006C006500000021433412080000009D1A00007912000078563412070000001401000043006F006D00700061006E007900560065006800690063006C00650048006900730074006F007200790000002800640062006F002900000028000000180000002C0C00001800000018000000450000002D0C0000000000002E0C00000000000010000000220000006A0E00002C0C00001000000007000000300C00002B0000001000000007000000310C0000550000003800000085000000310C0000000000000000F03F0000000000002440140000000000000000000000000000000100000000000000510000007000000018000000300C000060000000300000003F000000000000000000E03F000000000000000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000AB170000000000002D010000080000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C05000000000000010000009D1A00007912000000000000060000000600000002000000020000001C010000500D0000000000000100000039130000060A000000000000030000000300000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000007400000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000001600000043006F006D00700061006E007900560065006800690063006C00650048006900730074006F0072007900000002000B0046E60000267F00003FE10000267F00000000000002000000F0F0F00000000000000000000000000000000000010000002E0000000000000092D60000397D00005C1A00003E010000320000000100000200005C1A00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E92A0046004B005F0043006F006D00700061006E0079005F00760065006800690063006C0065005F0068006900730074006F00720079005F0043006F006D00700061006E0079005F00760065006800690063006C006500214334120800000088160000680900007856341207000000140100004400650070006100720074006D0065006E00740000002800640062006F0029000000000000000000000000000100000000000000510000001000000007000000250C00004B000000340000007D000000250C0000000000000000F03F0000803F0000803F0000803F00000000000000000000000000000000000000007000000018000000220C000060000000300000003D0000000000000000000000000000000000344000000000007C98400000000000003440230C000000000000300000003F00000000000000000000008357D10E0004008000000000007C98400000000000003340250C0000000000001000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000F80A00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005E00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000B0000004400650070006100720074006D0065006E007400000004000B002C36000012480000553E000012480000553E0000964B00004C680000964B00000000000002000000F0F0F00000000000000000000000000000000000010000003100000000000000193F0000454C0000E61000003E01000037000000010000020000E61000003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91C0046004B005F00420075006C006C006500740069006E005F0062006F006100720064005F004400650070006100720074006D0065006E007400214334120800000088160000AF2A000078563412070000001401000045006D0070006C006F0079006500650000002800640062006F002900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000F80000008352941C000900800000000038F0C52604022C0202000000DC03000000000000FC59000000000000B881010000000000B677B502000000000300000000000000000000007A0100000000000000000000000000000000000001000000E4D3601501000000E300000002000000885E030EE300000016030300DE01000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000009230000000000002D0100000D0000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000AF2A000000000000100000000C00000002000000020000001C010000040B0000000000000100000039130000D910000000000000060000000600000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005A00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000900000045006D0070006C006F00790065006500000004000B0028B9000029CE000028B900001CFF00009E9D00001CFF00009E9D0000FC0201000000000002000000F0F0F000000000000000000000000000000000000100000034000000000000007AA800004DF60000FF0F00003E01000034000000010000020000FF0F00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91B0046004B005F0041006300740069007600690074006900650073004300680069006C0064005F0045006D0070006C006F0079006500650004000B00A4B5000029CE0000A4B50000B4FD0000666C0000B4FD0000666C0000D00101000000000002000000F0F0F00000000000000000000000000000000000010000003600000000000000ED930000C7FB0000C50F00003E01000034000000010000020000C50F00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91A0046004B005F0041006300740069007600690074006900650073004D00610069006E005F0045006D0070006C006F0079006500650004000B0042BD00007AA3000042BD0000A374000004740000A374000004740000BE5C00000000000002000000F0F0F00000000000000000000000000000000000010000003800000000000000879E0000B67200001C1000003E010000360000000100000200001C1000003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91A0046004B005F00420075006C006C006500740069006E005F0062006F006100720064005F0045006D0070006C006F0079006500650004000B00D8BD00007AA30000D8BD0000FC7300009A740000FC7300009A740000BE5C00000000000002000000F0F0F00000000000000000000000000000000000010000003A0000000000000013A000000F720000A90F00003E01000036000000010000020000A90F00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9190046004B005F00420075006C006C006500740069006E0042006F006100720064005F0045006D0070006C006F0079006500650004000B00EABA000029CE0000EABA00001CFF00007ECC00001CFF00007ECC0000B40E01000000000002000000F0F0F00000000000000000000000000000000000010000003C00000000000000E6A90000CFFC0000551000003E01000038000000010000020000551000003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9180046004B005F0043006F006D006D0065006E0074004300680069006C0064005F0045006D0070006C006F0079006500650004000B0066B7000029CE000066B7000068FE0000A08C000068FE0000A08C0000981B01000000000002000000F0F0F00000000000000000000000000000000000010000003E00000000000000698F00007BFC00001C1000003E0100003B0000000100000200001C1000003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9170046004B005F0043006F006D006D0065006E0074004D00610069006E005F0045006D0070006C006F0079006500650002000B0038C700007AA3000038C70000B18E00000000000002000000F0F0F0000000000000000000000000000000000001000000400000000000000075B0000013990000141600003E0100002F000000010000020000141600003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9230046004B005F0043006F006D00700061006E0079005F00760065006800690063006C0065005F0068006900730074006F00720079005F0045006D0070006C006F0079006500650004000B00C62A0000CA4C0000C62A00000B76000016BC00000B76000016BC00007AA300000000000002000000F0F0F0000000000000000000000000000000000001000000420000000000000088660000BA7600004E0E00003E010000320000000100000200004E0E00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9160046004B005F0045006D0070006C006F007900650065005F004400650070006100720074006D0065006E00740005000B0078B40000A6A4000090B00000A6A4000090B00000929F0000A4B50000929F0000A4B500007AA300000000000002000000F0F0F0000000000000000000000000000000000001000000440000000000000079AD000041A00000840D00003E0100003D000000010000020000840D00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9140046004B005F0045006D0070006C006F007900650065005F0045006D0070006C006F007900650065002143341208000000E01A0000533B000078563412070000001401000045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D00700000002800640062006F00290000000000CC0D000000000000100000002200000023000000CA0D00001000000007000000CD0D00002B0000001000000007000000CE0D0000490000001000000007000000CF0D0000420000004000000076000000CF0D0000000000000000F03F00000000000000000000000000000000000000000000F03F0000000000000000000000000000000000000000180200007C000000CE0D0000CF0D0000010000000002000000020000020000000000000000000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000009230000000000002D0100000D0000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000E01A0000533B000000000000170000000C00000002000000020000001C010000C40B0000000000000100000039130000AB17000000000000090000000900000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000007200000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000001500000045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000000004000B002C36000024450000483D000024450000483D0000C43B00009ABF0000C43B00000000000002000000F0F0F00000000000000000000000000000000000010000004700000000000000D76C0000733C00004E1600003E010000320000000100000200004E1600003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9220046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004400650070006100720074006D0065006E00740004000B00C6C000007AA30000C6C00000EF730000AACD0000EF730000AACD00008D5B00000000000002000000F0F0F0000000000000000000000000000000000001000000490000000000000075C100008B790000C72000003E01000032000000010000020000C72000003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9320046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004400650070006100720074006D0065006E0074004C00650061006400650072004200790045006D0070006C006F0079006500650004000B0030C000007AA3000030C000003B730000E8CB00003B730000E8CB00008D5B00000000000002000000F0F0F00000000000000000000000000000000000010000004B00000000000000DFC00000157A00005C1A00003E010000320000000100000200005C1A00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9280046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F0045006400690074006F0072004200790045006D0070006C006F0079006500650004000B005CC100007AA300005CC10000A37400006CCF0000A37400006CCF00008D5B00000000000002000000F0F0F00000000000000000000000000000000000010000004D000000000000000BC2000002790000131E00003E01000032000000010000020000131E00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E92D0046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F00470072006F00750070004C00650061006400650072004200790045006D0070006C006F0079006500650004000B009ABF00007AA300009ABF00008772000026CA00008772000026CA00008D5B00000000000002000000F0F0F00000000000000000000000000000000000010000004F0000000000000049C000009F7A0000B61B00003E01000032000000010000020000B61B00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9290046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004D0061006E0061006700650072004200790045006D0070006C006F00790065006500214334120800000088160000680900007856341207000000140100004500760065006E00740000002800640062006F0029000000000000000000000000000000000000000000F03F0000000000000000000000000000000000000000400100007C0000002E0C00002F0C00000100000028010000280100000200000000000000000000000000000000000000000000000000244000000000000020400100000000000000000000000C00000001000000F80000000000000000000000000000000000000028000000000000000500000000000000000000000C00000000000000000000400000000000000000000000000000144000000000000008400000000000002040000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000E00A00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005400000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000060000004500760065006E00740000002143341208000000881600006C1C00007856341207000000140100004500760065006E007400430061006C0065006E0064006100720000002800640062006F0029000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000C3200000000000002D0100000C0000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006C1C0000000000000A0000000A00000002000000020000001C010000E00A0000000000000100000039130000060A000000000000030000000300000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006400000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000E0000004500760065006E007400430061006C0065006E00640061007200000003000B00FA320000CA4C0000FA320000EC5E000036420000EC5E00000000000002000000F0F0F000000000000000000000000000000000000100000053000000000000007C2500009B5F0000C81000003E01000042000000010000020000C81000003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91B0046004B005F004500760065006E007400430061006C0065006E006400610072005F004400650070006100720074006D0065006E00740004000B00ACBC00007AA30000ACBC000057750000584D000057750000584D0000486D00000000000002000000F0F0F00000000000000000000000000000000000010000005500000000000000729900006A730000FF0F00003E01000032000000010000020000FF0F00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9190046004B005F004500760065006E007400430061006C0065006E006400610072005F0045006D0070006C006F007900650065002143341208000000881600004B150000785634120700000014010000460069006C00650000002800640062006F0029000000CA06E80CFF0D880BFF0D0811FF0D60C6FB0D00C5FB0DA0C3FB0DB0C5FB0DF086C5261080C526C080C5267081C5263048B3266043B3268047B3269049B326E0D9F52630D9F52670D6F526A0D1F52610D5F52630CEF526D0E2F526B0DEF52660DFF526A0E7F52640E6F52690E5F526F0E6F52610EBF52608BDEC26D8CCEC2638CEEC26E8B8EC2618CAEC2698B9EC2668BEEC2678C0EC2648BAEC2618D5EC2628C1EC2698C4EC2678D6EC26D8D7EC2658D2EC26905C0827305B082720590827B0550827C04C0827B03F082770420827204E0827F05208274047000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000F1190000000000002D010000090000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600004B15000000000000070000000700000002000000020000001C010000E00A0000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005200000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F00000005000000460069006C006500000004000B0000CB0000E0C400001CD20000E0C400001CD2000060EA0000CCD8000060EA00000000000002000000F0F0F000000000000000000000000000000000000100000058000000000000004AC7000006D80000230A00003E01000032000000010000020000230A00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9100046004B005F00460069006C0065005F0045006D0070006C006F00790065006500214334120800000088160000C80B0000785634120700000014010000470072006F007500700000002800640062006F0029000000E80CFF0D880BFF0D0811FF0D60C6FB0D00C5FB0DA0C3FB0DB0C5FB0DF086C5261080C526C080C5267081C5263048B3266043B3268047B3269049B326E0D9F52630D9F52670D6F526A0D1F52610D5F52630CEF526D0E2F526B0DEF52660DFF526A0E7F52640E6F52690E5F526F0E6F52610EBF52608BDEC26D8CCEC2638CEEC26E8B8EC2618CAEC2698B9EC2668BEEC2678C0EC2648BAEC2618D5EC2628C1EC2698C4EC2678D6EC26D8D7EC2658D2EC26905C0827305B082720590827B0550827C04C0827B03F082770420827204E0827F05208274047000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000C80B000000000000030000000300000002000000020000001C010000E00A0000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005400000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F00000006000000470072006F0075007000000002000B00488A0000EE4D0000D47E0000EE4D00000000000002000000F0F0F00000000000000000000000000000000000010000005B00000000000000837D00009D4E0000320E00003E01000034000000010000020000320E00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9170046004B005F00420075006C006C006500740069006E005F0062006F006100720064005F00470072006F007500700004000B002C360000504600006C3F0000504600006C3F000050460000488A0000504600000000000002000000F0F0F00000000000000000000000000000000000010000005D00000000000000B9570000FF460000630C00003E01000037000000010000020000630C00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9130046004B005F00470072006F00750070005F004400650070006100720074006D0065006E00740004000B00B09A0000944E0000B09A00003B7300006EBE00003B7300006EBE00007AA300000000000002000000F0F0F00000000000000000000000000000000000010000005F0000000000000012A60000EA7300009A0B00003E010000320000000100000200009A0B00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9110046004B005F0045006D0070006C006F007900650065005F00470072006F007500700003000B006A950000CC4200006A950000863D00009ABF0000863D00000000000002000000F0F0F00000000000000000000000000000000000010000006100000000000000AE9F0000353E00009A1300003E010000320000000100000200009A1300003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91D0046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F00470072006F0075007000214334120800000088160000680900007856341207000000140100004C00650061007600650000002800640062006F002900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000340800000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005400000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000060000004C0065006100760065000000214334120800000088160000AB1700007856341207000000140100004C00650061007600650048006900730074006F007200790000002800640062006F00290000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000371C0000000000002D0100000A0000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000AB17000000000000080000000800000002000000020000001C01000034080000000000000100000039130000060A000000000000030000000300000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006200000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000D0000004C00650061007600650048006900730074006F0072007900000004000B0038C7000029CE000038C7000030FA0000CE12010030FA0000CE120100103A01000000000002000000F0F0F000000000000000000000000000000000000100000065000000000000000BE70000DFFA0000350F00003E01000032000000010000020000350F00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9180046004B005F004C00650061007600650048006900730074006F00720079005F0045006D0070006C006F0079006500650002000B0090FE00005E460100AC0701005E4601000000000002000000F0F0F000000000000000000000000000000000000100000067000000000000007DFD00000D470100110D00003E0100001B000000010000020000110D00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9150046004B005F004C00650061007600650048006900730074006F00720079005F004C0065006100760065002143341208000000751D0000923600007856341207000000140100004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D00700000002800640062006F002900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000803F00000000C0559C0C00090080000000001000000007000000C90D000049000000C00000007C000000C90D00000000000001000000A8000000A80000000200000000000000000000000000000000001840000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000009230000000000002D0100000D0000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000751D00009236000000000000150000000C00000002000000020000001C010000400B00000000000001000000391300006515000000000000080000000800000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000007A00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000190000004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D007000000004000B0076C5000029CE000076C50000E4FA0000C0F30000E4FA0000C0F30000D00101000000000002000000F0F0F00000000000000000000000000000000000010000006A00000000000000D0B1000093FB0000341700003E01000032000000010000020000341700003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9240046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F0079006500650004000B00B4C3000029CE0000B4C3000098FB0000FEF1000098FB0000FEF10000D00101000000000002000000F0F0F00000000000000000000000000000000000010000006C00000000000000ADF2000092000100782200003E01000064000000010000020000782200003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9360046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F00790065006500420079004400650070006100720074006D0065006E0074004C006500610064006500720004000B0030C0000029CE000030C0000000FD00007AEE000000FD00007AEE0000D00101000000000002000000F0F0F00000000000000000000000000000000000010000006E00000000000000D3A60000AFFD0000CF1A00003E01000032000000010000020000CF1A00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9280046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F007900650065004200790047004D0004000B006EBE000029CE00006EBE0000B4FD0000B8EC0000B4FD0000B8EC0000D00101000000000002000000F0F0F0000000000000000000000000000000000001000000700000000000000053C4000063FE0000C41F00003E01000058000000010000020000C41F00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9310046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F0079006500650042007900470072006F00750070004C006500610064006500720002000B002AF30000AE4101002AF30000623801000000000002000000F0F0F00000000000000000000000000000000000010000007600000000000000D9F30000693C0100111500003E01000032000000010000020000111500003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9210046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F004C0065006100760065002143341208000000881600008A1000007856341207000000140100004D0065006500740069006E00670052006F006F006D0000002800640062006F002900000078000000000000000000F03F00000000000000002800000000000000050000000000000000000000040000000000000000804040000000000000000000000000008040400000000000003940000000000000F03F0000000000003940000000000000F03F00000000000000001000000007000000D20D000049000000C00000007C000000D20D00000000000000000000A8000000A800000002000000000000000000F03F0000000000000000000000000080404000000000000039400100000000000000000000000C00000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600008A10000000000000050000000500000002000000020000001C01000034080000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006000000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000C0000004D0065006500740069006E00670052006F006F006D00000021433412080000009A1800008A1000007856341207000000140100004D0065006500740069006E00670052006F006F006D0048006900730074006F007200790000002800640062006F0029000000643BDF0F28409BC420B072680740CCCCCCCCCCCC2940C0CAA145B6F3084078E9263108AC2A403F355EBA490C0C4078E9263108AC2A40AAF1D24D62100F4078E9263108AC2A4062105839B44810409F1A2FDD24C6294062105839B448104095438B6CE7FB274062105839B4481040FED478E9263126407F6ABC7493180F40B29DEFA7C64B2540BE9F1A2FDD240C40B29DEFA7C64B2540F80000000E00000005000000E80100000000000000002E400000000000001440B80100000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C05000000000000010000009A1800008A10000000000000050000000500000002000000020000001C01000060090000000000000100000039130000060A000000000000030000000300000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006E00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000130000004D0065006500740069006E00670052006F006F006D0048006900730074006F0072007900000002000B0000CB0000D2A50000861E0100D2A500000000000002000000F0F0F00000000000000000000000000000000000010000007A000000000000009FEA000081A60000471400003E01000032000000010000020000471400003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9200046004B005F004D0065006500740069006E0067005F0072006F006F006D005F0068006900730074006F00720079005F0045006D0070006C006F0079006500650002000B0008330100588D000008330100C29700000000000002000000F0F0F00000000000000000000000000000000000010000007C00000000000000971B0100A3920000C21600003E0100003A000000010000020000C21600003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9240046004B005F004D0065006500740069006E0067005F0072006F006F006D005F0068006900730074006F00720079005F004D0065006500740069006E0067005F0072006F006F006D00214334120800000088160000EA1200007856341207000000140100004D0065007300730061006700650000002800640062006F00290000007E03000040000000180000007B03000030000000300000003F00000000000000000000000000000000000000000000000000304000000000000030407C0300000000000010000000220000007A0300007B0300001400000026000000790300007A030000000000008200000048030000000000000000F03F00000000000000000000000000000000000000000000F03F000000000000F03F00000000000000000000000000000000000000000000F03F000000000000F03F39B4C876BE9FE63F39B4C876BE9FF63F00000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000AB170000000000002D010000080000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000EA12000000000000060000000600000002000000020000001C010000F80A0000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005800000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000080000004D00650073007300610067006500000004000B0078B40000BEB900005CAD0000BEB900005CAD0000E0C400005CAB0000E0C400000000000002000000F0F0F00000000000000000000000000000000000010000007F0000000000000010A00000D4BA00009D0C00003E010000320000000100000200009D0C00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9130046004B005F004D006500730073006100670065005F0045006D0070006C006F00790065006500214334120800000088160000C80B00007856341207000000140100004F006600660069006300650000002800640062006F00290000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000D40000006451F71A000A0080989EF42618EAC5262000480002200000DC03000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000C80B000000000000030000000300000002000000020000001C010000F80A00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005600000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000070000004F0066006600690063006500000002000B006602010098850000CEFC0000988500000000000002000000F0F0F00000000000000000000000000000000000010000008200000000000000B7F7000047860000C50F00003E01000032000000010000020000C50F00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9190046004B005F0043006F006D00700061006E0079005F00760065006800690063006C0065005F004F006600660069006300650005000B007610010096880000761001006A930000731001006A930000731001003CA5000000CB00003CA500000000000002000000F0F0F0000000000000000000000000000000000001000000840000000000000075F300004FA300007D0B00003E010000320000000100000200007D0B00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9120046004B005F0045006D0070006C006F007900650065005F004F006600660069006300650003000B0080060100CE7C0000800601001C3E00007ADA00001C3E00000000000002000000F0F0F000000000000000000000000000000000000100000086000000000000002F0701009F4500007C1300003E010000320000000100000200007C1300003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E91E0046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004F006600660069006300650002000B00EE18010040830000DE200100408300000000000002000000F0F0F0000000000000000000000000000000000001000000880000000000000026150100EF830000F80D00003E0100003F000000010000020000F80D00003E0100000200000000000500008008000080010000001500018800009001905F010008B773B2D3A9FAC5E9160046004B005F004D0065006500740069006E0067005F0072006F006F006D005F004F00660066006900630065002143341208000000881600004B1500007856341207000000140100004F007200640065007200440065007400610069006C0000002800640062006F00290000000E00000005000000B80100000000000000001C400000000000002C40880100000000000005000000000000000000000002000000E9263108AC9C18400000000000002C40E9263108AC9C1840726891ED7CFF25400600000020000000300000000900000020B07268916D184014AE47E17A1426406891ED7C3F351840295C8FC2D653820AC00F0080B6F317407B14AE47E13A26401804560E2DB21740E7FBA9F1D24D264020B07268916D1740AC1C5A643B5F2640A4703D0AD7231740C876BE9F1A6F2640B0726891EDFC000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000F1190000000000002D010000090000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600004B15000000000000070000000700000002000000020000001C010000F80A0000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006000000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000C0000004F007200640065007200440065007400610069006C0000002143341208000000881600006809000078563412070000001401000050006F0073006900740069006F006E0000002800640062006F0029000000000000000000603C00000000000000000000000002004E005000040002004A51260900130080270000006D00730069007400310032003300670072006F00750070003500720065007400720079002E00640061007400610062006100730065002E00770069006E0064006F00770073002E006E0065007400000000000000090000000000000040E2D54FD2010000090000000000000050853850D20100003CC000001000000000000000000000000000000002000000080002000200000033000000020000000C000200000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000040B00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005A00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000900000050006F0073006900740069006F006E00000004000B0082AA0000306E000082AA00008772000004BF00008772000004BF00007AA300000000000002000000F0F0F00000000000000000000000000000000000010000008C00000000000000F2B10000C97E0000630C00003E01000032000000010000020000630C00003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9140046004B005F0045006D0070006C006F007900650065005F0050006F0073006900740069006F006E0004000B00E8B5000078690000B8BD000078690000B8BD0000483F00009ABF0000483F00000000000002000000F0F0F00000000000000000000000000000000000010000008E0000000000000067BE000006580000641400003E01000032000000010000020000641400003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9200046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F0050006F0073006900740069006F006E00214334120800000088160000290E000078563412070000001401000052006500630069007000690065006E00740000002800640062006F0029000000CC020000000000000000F03FD5C0693FD5C0693FD5C0693F0000803F000000000000000000000000000000001000000007000000CD02000049000000000100007C000000CD0200000000000001000000E8000000135141090214008000000000000000000000000000000000000000000000304000000000000030400100000000000000000000000C00000001000000B800000000000000000030400000000000002640280000000000000005000000000000000000000008000000000000000000224000000000000026400000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000290E000000000000040000000400000002000000020000001C010000F80A0000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005C00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000A00000052006500630069007000690065006E007400000004000B0078B40000FCB700005CAD0000FCB700005CAD000082AA00005CAB000082AA00000000000002000000F0F0F000000000000000000000000000000000000100000091000000000000007F9F00007CB400002E0D00003E010000320000000100000200002E0D00003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9150046004B005F0052006500630069007000690065006E0074005F0045006D0070006C006F0079006500650002000B00F69F000080BB0000F69F0000A3B100000000000002000000F0F0F00000000000000000000000000000000000010000009300000000000000A5A00000B7B40000470C00003E01000040000000010000020000470C00003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9140046004B005F0052006500630069007000690065006E0074005F004D006500730073006100670065002143341208000000881600008A1000007856341207000000140100005200650070006C00790000002800640062006F0029000000273108AC1C5A2440D122DBF97E6A08400000000000002440105839B4C8760C40000000000000244014AE47E17A14124000000000000024400000000000001440022B8716D94E25400000000000001440AE47E17A14EE2740000000000000144095438B6CE73B294060E5D022DB79134095438B6CE73B2A40EB51B81E856B1240AE47E17A14EE2A40580100000C0000000100000078000000000000000000F03F0000000000002240280000000000000005000000000000000000000004000000000000007F502D0A0010008000002E40000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600008A10000000000000050000000500000002000000020000001C0100002C070000000000000100000039130000C007000000000000020000000200000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005400000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000060000005200650070006C007900000004000B00FAC8000029CE0000FAC800007CF90000083301007CF9000008330100D00101000000000002000000F0F0F0000000000000000000000000000000000001000000960000000000000072E000002BFA0000600B00003E01000032000000010000020000600B00003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9110046004B005F005200650070006C0079005F0045006D0070006C006F00790065006500214334120800000088160000680900007856341207000000140100005200650070006F0072007400430061007400650067006F007200790000002800640062006F0029000000000000000000050000000000000000000000040000000000000000001C400000000000001C400000000000001C4000000000000020400000000000000040000000000000204000000000000000400000000000001C40780000000C0000000100000078000000000000000000004000000000000014402800000000000000050000000000000000000000040000000000000000001C4000000000000014400000000000001C40000000000000184000000000000000400000000000001840000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000040B00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006600000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000F0000005200650070006F0072007400430061007400650067006F007200790000002143341208000000881600006C1C00007856341207000000140100005200650070006F0072007400540069006D006500530079007300740065006D0000002800640062006F002900000000000000000000002E400000000000002440000000000000224000000000000024400000000000002240000000000000224000000000000024400000000000002240000000000000244000000000000008400000000000002640000000000000084000000000000026400000000000002240000000000000284000000000BC51E808001500800000284000000000000014400000000000002A4000000000000014400000000000002A4000000000000022400000000000002C40000000000000000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000C3200000000000002D0100000C0000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006C1C0000000000000A0000000A00000002000000020000001C010000E00A0000000000000100000039130000060A000000000000030000000300000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006A00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000110000005200650070006F0072007400540069006D006500530079007300740065006D00000003000B00F2C100007AA30000F2C10000887700002CE20000887700000000000002000000F0F0F00000000000000000000000000000000000010000009A00000000000000A1C20000D17D00003F1200003E010000320000000100000200003F1200003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E91C0046004B005F005200650070006F0072007400540069006D006500530079007300740065006D005F0045006D0070006C006F0079006500650002000B00C2E2000094550000C2E20000FE5B00000000000002000000F0F0F00000000000000000000000000000000000010000009C0000000000000014D2000047580000FF0F00003E01000034000000010000020000FF0F00003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9190046004B005F005200650070006F0072007400540069006D006500530079007300740065006D005F004500760065006E007400214334120800000088160000EA1200007856341207000000140100005200650071007500690073006900740069006F006E004D00610069006E0000002800640062006F0029000000CC02000000000000CD020000000000001000000022000000CA020000CB0200001400000026000000C9020000CA020000000000001400000026000000C3020000C9020000010000001000000007000000CE020000270000001000000007000000CF020000270000001000000007000000D00200002B0000001000000007000000D10200004B000000340000007D000000D1020000000000000000F03F6884583D6884583D6884583D0000803F00000000000000000000000000000000100000000700000000000000000000000100000005000000540000002C0000002C0000002C00000034000000000000000000000022290000AB170000000000002D010000080000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000EA12000000000000060000000600000002000000020000001C010000040B00000000000001000000391300004D0C000000000000040000000400000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006800000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F000000100000005200650071007500690073006900740069006F006E004D00610069006E00000002000B00CCD800005AD20000CCD80000D4CD00000000000002000000F0F0F00000000000000000000000000000000000010000009F0000000000000083C400006DCF00009A1300003E010000330000000100000200009A1300003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9210046004B005F005200650071007500690073006900740069006F006E004D00610069006E005F0041007000700072006F00760061006C0053007400610074007500730002000B0000CB000080BB000036D8000080BB00000000000002000000F0F0F0000000000000000000000000000000000001000000A10000000000000028C9000093B90000E61000003E01000032000000010000020000E61000003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E91B0046004B005F005200650071007500690073006900740069006F006E004D00610069006E005F0045006D0070006C006F0079006500650002000B00CCD8000080B40000CCD80000EABA00000000000002000000F0F0F0000000000000000000000000000000000001000000A30000000000000010C4000016B700000D1400003E010000320000000100000200000D1400003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9210046004B005F005200650071007500690073006900740069006F006E004D00610069006E005F005200650070006F0072007400430061007400650067006F007200790002000B00BEEE000080BB00009CF9000080BB00000000000002000000F0F0F0000000000000000000000000000000000001000000A50000000000000017EA00002FBC00005D1200003E0100003E0000000100000200005D1200003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E91F0046004B005F004F007200640065007200440065007400610069006C005F005200650071007500690073006900740069006F006E004D00610069006E00310002000B00BEEE000064C800009CF9000064C800000200000002000000F0F0F0000000000000000000000000000000000001000000A700000000000000E5EB000013C900008F1000003E010000320000000100000200008F1000003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E91B0046004B005F0041007000700072006F00760061006C005F005200650071007500690073006900740069006F006E004D00610069006E002143341208000000F21900006809000078563412070000001401000052006500770061007200640061006E006400500075006E006900730068006D0065006E00740000002800640062006F0029000000A59B1840EFA7C64B3789244037894160E55019401C5A643BDF4F24408B6CE7FBA9F1194052B81E85EB112440050000000000000070000000020000000000000000001C4052B81E85EB1124400000000000001C400000000000002C40B80100000E0000000100000058010000EB51B81E856B1240AE47E17A14EE2A40280000000000000006000000200000000000000012000000C64B378941601140C64B378941A02B4022DBF97E6ABC0F4045B6F3FDD4F82B4037894160E5D0000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000F21900006809000000000000020000000200000002000000020000001C010000D80C00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000007000000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000001400000052006500770061007200640061006E006400500075006E006900730068006D0065006E007400000021433412080000008816000068090000785634120700000014010000530075006700670065007300740069006F006E0000002800640062006F002900000000000300000010000000F0E61D0E0000000000000000030000000F0000000037C9060000000000000000030000001100000090E71D0E0000000000000000030000000F0000003037C90600000000000000000300000014000000F0E71D0E0000000000000000030000000F0000006037C9060000000000000000030000000F0000009037C9060000000000000000030000001F000000C848AF0200000000000000000300000023000000C8686A0E0000000000000000030000000F000000A837C90600000000000000000300000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600006809000000000000020000000200000002000000020000001C010000E00A00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005E00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000B000000530075006700670065007300740069006F006E0000002143341208000000881600008A100000785634120700000014010000530075006700670065007300740069006F006E0048006900730074006F007200790000002800640062006F002900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600008A10000000000000050000000500000002000000020000001C010000E00A00000000000001000000391300004D0C000000000000040000000400000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006C00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F00000012000000530075006700670065007300740069006F006E0048006900730074006F0072007900000004000B00A41F000012480000D417000012480000D41700007251000088160000725100000000000002000000F0F0F0000000000000000000000000000000000001000000AC000000000000001C040000F0470000091300003E01000034000000010000020000091300003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9200046004B005F00530075006700670065007300740069006F006E005F0068006900730074006F00720079005F004400650070006100720074006D0065006E00740004000B0080BB00007AA3000080BB0000BF760000220B0000BF760000220B0000C85900000000000002000000F0F0F0000000000000000000000000000000000001000000AE00000000000000E26B0000D27400003F1200003E010000320000000100000200003F1200003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E91E0046004B005F00530075006700670065007300740069006F006E005F0068006900730074006F00720079005F0045006D0070006C006F0079006500650002000B00220B0000E63F0000220B00003E4900000000000002000000F0F0F0000000000000000000000000000000000001000000B000000000000000C0F7FFFFBE400000B31200003E0100000A000000010000020000B31200003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E9200046004B005F00530075006700670065007300740069006F006E005F0068006900730074006F00720079005F00530075006700670065007300740069006F006E00214334120800000088160000C80B00007856341207000000140100005300750072007600650079004D00610069006E0000002800640062006F00290000005C03F4B4120E04545C0328B5120E0C5A5C035CB5120E545B5C0390B5120EA05B5C030C19000968EFA803F8B5120EF0605C032CB6120EAC615C0364B92D0EE44DD40394B6120E38685C03C8B6120EA86A5C037018000924E7A80308180009DCE5A803D417000908885F0398B7120E98A35C0330B92D0ED031D403FCB82D0E2C32D40334B8120E24A15C03C8B82D0EC031D40394B82D0EB8F2D30360B82D0EA8F2D30304B9120E0C805F0338B9120E58805F0318502C005032D707FC2100090432D7072CB82D0E88D6D30308BA000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C050000000000000100000088160000C80B000000000000030000000300000002000000020000001C010000E00A00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005E00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000B0000005300750072007600650079004D00610069006E0000002143341208000000881600008A1000007856341207000000140100007300790073006400690061006700720061006D0000002800640062006F0029000000FB036890420EE8F4F2039C90420E54F5F203D090420EF8F4F2031C27400EE40AFB033891420ED825F3036C91420E4426F303A091420EE825F303D491420EC8EDF3030892420EE8EDF3033C92420E08EEF303B426400E38E655034C26400E34C8FA03E425400ED4C7FA035063B726F4122F044093420E602AF4037493420EA82BF403A893420EF02CF403DC93420E3C2DF4031094420EB82DF4034494420EC82DF4037894420E802EF4037C25400E24C4FA033C8D400EB44CC8074825400E24C6F8031425400EE8BBF8037C95000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600008A10000000000000050000000500000002000000020000001C010000E00A00000000000001000000391300007A05000000000000010000000100000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000005E00000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000B0000007300790073006400690061006700720061006D0000002143341208000000881600008A1000007856341207000000140100007300790073006400690061006700720061006D00730000002800640062006F0029000000EC85400ECC93FB033048420E7006F2033008B72648CB4A299848420E9006F20334B7BC063C6DE7070049420EB006F203C46FAB268C9B55296849420ED006F203A892AB260C9B5529E889420EF006F2037C94AB2688496B08508A420E1007F2032059AC269C345629B88A420E3007F2031CB9AC26F8345629208B420E5007F203E4ECB72650FF5829888B420E7007F203E04CB82690525A29F08B420E280AF203248C420ED80DF203588C420EF00FF2038C8C420E0827F203C08C420E382BF203F48C420ED82EF203288D000000000000000000000100000005000000540000002C0000002C0000002C0000003400000000000000000000002229000065150000000000002D010000070000000C000000070000001C01000006090000620700006003000038040000F4020000EC04000054060000CC03000054060000040800007C0500000000000001000000881600008A10000000000000050000000500000002000000020000001C010000E00A0000000000000100000039130000060A000000000000030000000300000002000000020000001C010000060900000100000000000000391300003403000000000000000000000000000002000000020000001C010000060900000000000000000000D13100000923000000000000000000000D00000004000000040000001C01000006090000AA0A00009006000078563412040000006000000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000C0000007300790073006400690061006700720061006D00730000002143341208000000751D00002818000078563412070000001401000043006F006D006D0065006E0074005200650070006C00790000002800640062006F002900000020002000200020002000200020002000200020002000200020002000200020002000200020002000200041005300200062006900740029003D003000200061006E0064002000740062006C002E00740065006D0070006F00720061006C005F0074007900700065003D003000200061006E006400200043004100530054002800740062006C002E00690073005F006D0065006D006F00720079005F006F007000740069006D0069007A0065006400200041005300200062006900740029003D003100200061006E00000000000000000000000100000005000000540000002C0000002C0000002C000000340000000000000000000000B12100009A150000000000002D010000070000000C000000070000001C01000035070000EB0500006003000038040000F4020000ED03000054060000CC03000054060000040800007C0500000000000001000000751D00002818000000000000040000000400000002000000020000001C010000880E00000000000001000000201000003403000000000000000000000000000002000000020000001C010000350700000100000000000000201000003403000000000000000000000000000002000000020000001C010000350700000000000000000000B92800007323000000000000000000000D00000004000000040000001C010000350700008E0800004605000078563412040000006200000001000000010000000B000000000000000100000002000000030000000400000005000000060000000700000008000000090000000A00000004000000640062006F0000000D00000043006F006D006D0065006E0074005200650070006C007900000002000B005CC100007E170100F9B600007E1701000000000002000000F0F0F0000000000000000000000000000000000001000000B600000000000000FCAD000091150100601300003E01000000000000010000020000601300003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E91C0046004B005F0043006F006D006D0065006E0074005200650070006C0079005F0043006F006D006D0065006E0074004300680069006C00640002000B005CC100007E170100F9B600007E1701000000000002000000F0F0F0000000000000000000000000000000000001000000B8000000000000004FAD0000911501000D1400003E010000000000000100000200000D1400003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E91D0046004B005F0043006F006D006D0065006E0074005200650070006C0079005F0043006F006D006D0065006E0074004300680069006C006400310002000B0006980000CC23010084990000CC2301000000000002000000F0F0F0000000000000000000000000000000000001000000BA00000000000000328F00007B240100261300003E01000032000000010000020000261300003E010000020000000000FFFFFF0008000080010000001500018800009001905F010008B773B2D3A9FAC5E91B0046004B005F0043006F006D006D0065006E0074005200650070006C0079005F0043006F006D006D0065006E0074004D00610069006E00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000FEFFFFFFFEFFFFFF0400000005000000060000000700000008000000090000000A0000000B0000000C0000000D0000000E0000000F000000100000001100000012000000130000001400000015000000160000001700000018000000190000001A0000001B0000001C0000001D0000001E0000001F000000200000002100000022000000230000002400000025000000260000002700000028000000290000002A0000002B0000002C0000002D0000002E0000002F00000030000000FEFFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF0100FEFF030A0000FFFFFFFF00000000000000000000000000000000170000004D6963726F736F66742044445320466F726D20322E300010000000456D626564646564204F626A6563740000000000F439B271000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010003000000000000000C0000000B0000004E61BC00000000000000000000000000000000000000000000000000000000000000000000000000000000000000DBE6B0E91C81D011AD5100A0C90F573900000200606F4CF0AE0DD601020200001048450000000000000000000000000000000000EC0100004400610074006100200053006F0075007200630065003D0028006C006F00630061006C006400620029005C00500072006F006A0065006300740073005600310033003B0049006E0069007400690061006C00200043006100740061006C006F0067003D0042007500730069006E00650073007300440061007400610042006100730065003B0049006E00740065006700720061007400650064002000530065006300750072006900740079003D0054007200750065003B004D0075006C007400690070006C00650041006300740069007600650052006500730075006C00740053006500740073003D00460061006C00730065003B0043006F006E006E00650063007400200054000300440064007300530074007200650061006D000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000160002000300000006000000FFFFFFFF000000000000000000000000000000000000000000000000000000000000000000000000860000003D8F00000000000053006300680065006D00610020005500440056002000440065006600610075006C0074000000000000000000000000000000000000000000000000000000000026000200FFFFFFFFFFFFFFFFFFFFFFFF000000000000000000000000000000000000000000000000000000000000000000000000020000001600000000000000440053005200450046002D0053004300480045004D0041002D0043004F004E00540045004E0054005300000000000000000000000000000000000000000000002C0002010500000007000000FFFFFFFF00000000000000000000000000000000000000000000000000000000000000000000000003000000660B00000000000053006300680065006D00610020005500440056002000440065006600610075006C007400200050006F007300740020005600360000000000000000000000000036000200FFFFFFFFFFFFFFFFFFFFFFFF0000000000000000000000000000000000000000000000000000000000000000000000003100000012000000000000000C00000097730000F28A00000100260000007300630068005F006C006100620065006C0073005F00760069007300690062006C0065000000010000000B0000001E000000000000000000000000000000000000006400000000000000000000000000000000000000000000000000010000000100000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800300038000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000020000000200000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0031003900320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000030000000300000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0031003900320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000000400000004000000000000005400000001FF414001000000640062006F00000046004B005F0041006300740069007600690074006900650073004300680069006C0064005F0041006300740069007600690074006900650073004D00610069006E0000000000000000000000C4020000000005000000050000000400000008000000012A683EB02A683E0000000000000000AD070000000000060000000600000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300300034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000070000000700000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0031003900320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000000800000008000000000000004C0000000101000001000000640062006F00000046004B005F0041007000700072006F00760061006C005F0041007000700072006F00760061006C00500072006F0063006500640075007200650000000000000000000000C4020000000009000000090000000800000008000000012A683E702A683E0000000000000000AD0700000000000A0000000A00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000000B0000000B00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003100300030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000000C0000000C00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0031003900320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000000D0000000D00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003100300030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000000E0000000E00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003100300030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000000F0000000F000000000000006C00000001FF514001000000640062006F00000046004B005F00640062006F005F004100730070004E0065007400550073006500720052006F006C00650073005F00640062006F005F004100730070004E006500740052006F006C00650073005F0052006F006C0065004900640000000000000000000000C4020000000010000000100000000F00000008000000012A683E302A683E0000000000000000AD070000000000110000001100000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003100300030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000001200000012000000000000006E00000001FF514001000000640062006F00000046004B005F00640062006F005F004100730070004E0065007400550073006500720043006C00610069006D0073005F00640062006F005F004100730070004E0065007400550073006500720073005F0055007300650072004900640000000000000000000000C40200000000130000001300000012000000080000000129683EF029683E0000000000000000AD0700000000001400000014000000000000006E00000001FF514001000000640062006F00000046004B005F00640062006F005F004100730070004E006500740055007300650072004C006F00670069006E0073005F00640062006F005F004100730070004E0065007400550073006500720073005F0055007300650072004900640000000000000000000000C40200000000150000001500000014000000080000000129683EB029683E0000000000000000AD0700000000001600000016000000000000006C00000001FF514001000000640062006F00000046004B005F00640062006F005F004100730070004E0065007400550073006500720052006F006C00650073005F00640062006F005F004100730070004E0065007400550073006500720073005F0055007300650072004900640000000000000000000000C40200000000170000001700000016000000080000000129683E7029683E0000000000000000AD070000000000180000001800000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300370036000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000190000001900000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003900350032000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000001A0000001A00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003600370036000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000001B0000001B00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0031003900320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000001C0000001C00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0031003900320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000001D0000001D000000000000004C0000000101000001000000640062006F00000046004B005F0043006F006D006D0065006E0074004D00610069006E005F0041006300740069007600690074006900650073004D00610069006E0000000000000000000000C402000000001E0000001E0000001D000000080000000129683E3029683E0000000000000000AD0700000000001F0000001F000000000000004A0000000101000001000000640062006F00000046004B005F0043006F006D006D0065006E0074004300680069006C0064005F0043006F006D006D0065006E0074004D00610069006E00310000000000000000000000C4020000000020000000200000001F000000080000000128683EF028683E0000000000000000AD0700000000002100000021000000000000004E0000000101000001000000640062006F00000046004B005F0043006F006D006D0065006E0074004D00610069006E005F0043006F006D006D0065006E00740043006F006E00740065006E007400310000000000000000000000C40200000000220000002200000021000000080000000128683EB028683E0000000000000000AD070000000000230000002300000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0031003900320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000240000002400000000000000500000000101000001000000640062006F00000046004B005F0043006F006D006D0065006E00740043006F006E00740065006E0074005F0043006F006D006D0065006E0074004F007000740069006F006E0000000000000000000000C40200000000250000002500000024000000080000000128683E7028683E0000000000000000AD070000000000260000002600000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0031003800330036000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000002700000027000000000000005400000001FF414001000000640062006F00000046004B005F0043006F006D006D0065006E0074005100750065007300740069006F006E005F0043006F006D006D0065006E00740043006F006E00740065006E00740000000000000000000000C40200000000280000002800000027000000080000000128683E3028683E0000000000000000AD070000000000290000002900000000000000500000000101000001000000640062006F00000046004B005F0043006F006D006D0065006E0074004300680069006C0064005F0043006F006D006D0065006E0074005100750065007300740069006F006E0000000000000000000000C402000000002A0000002A00000029000000080000000127683EF027683E0000000000000000AD0700000000002B0000002B00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800300038000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000002C0000002C00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0033003400300038000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000002D0000002D000000000000006600000001FFD03E01000000640062006F00000046004B005F0043006F006D00700061006E0079005F00760065006800690063006C0065005F0068006900730074006F00720079005F0043006F006D00700061006E0079005F00760065006800690063006C00650000000000000000000000C402000000002E0000002E0000002D000000080000000127683EB027683E0000000000000000AD0700000000002F0000002F00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800300038000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000003000000030000000000000004A0000000101000001000000640062006F00000046004B005F00420075006C006C006500740069006E005F0062006F006100720064005F004400650070006100720074006D0065006E00740000000000000000000000C40200000000310000003100000030000000080000000127683E7027683E0000000000000000AD070000000000320000003200000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000003300000033000000000000004800000001FF507701000000640062006F00000046004B005F0041006300740069007600690074006900650073004300680069006C0064005F0045006D0070006C006F0079006500650000000000000000000000C40200000000340000003400000033000000080000000127683E3027683E0000000000000000AD0700000000003500000035000000000000004600000001FF507701000000640062006F00000046004B005F0041006300740069007600690074006900650073004D00610069006E005F0045006D0070006C006F0079006500650000000000000000000000C40200000000360000003600000035000000080000000126683EF026683E0000000000000000AD0700000000003700000037000000000000004600000001FF507701000000640062006F00000046004B005F00420075006C006C006500740069006E005F0062006F006100720064005F0045006D0070006C006F0079006500650000000000000000000000C40200000000380000003800000037000000080000000126683EB026683E0000000000000000AD0700000000003900000039000000000000004400000001FF507701000000640062006F00000046004B005F00420075006C006C006500740069006E0042006F006100720064005F0045006D0070006C006F0079006500650000000000000000000000C402000000003A0000003A00000039000000080000000126683E7026683E0000000000000000AD0700000000003B0000003B000000000000004200000001FF507701000000640062006F00000046004B005F0043006F006D006D0065006E0074004300680069006C0064005F0045006D0070006C006F0079006500650000000000000000000000C402000000003C0000003C0000003B000000080000000126683E3026683E0000000000000000AD0700000000003D0000003D000000000000004000000001FF514001000000640062006F00000046004B005F0043006F006D006D0065006E0074004D00610069006E005F0045006D0070006C006F0079006500650000000000000000000000C402000000003E0000003E0000003D000000080000000125683EF025683E0000000000000000AD0700000000003F0000003F000000000000005800000001FF414001000000640062006F00000046004B005F0043006F006D00700061006E0079005F00760065006800690063006C0065005F0068006900730074006F00720079005F0045006D0070006C006F0079006500650000000000000000000000C4020000000040000000400000003F000000080000000125683EB025683E0000000000000000AD0700000000004100000041000000000000003E00000001FF514001000000640062006F00000046004B005F0045006D0070006C006F007900650065005F004400650070006100720074006D0065006E00740000000000000000000000C40200000000420000004200000041000000080000000125683E7025683E0000000000000000AD0700000000004300000043000000000000003A00000001FF514001000000640062006F00000046004B005F0045006D0070006C006F007900650065005F0045006D0070006C006F0079006500650000000000000000000000C40200000000440000004400000043000000080000000125683E3025683E0000000000000000AD070000000000450000004500000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0033003000310032000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000004600000046000000000000005600000001FF414001000000640062006F00000046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004400650070006100720074006D0065006E00740000000000000000000000C40200000000470000004700000046000000080000000124683EF024683E0000000000000000AD070000000000480000004800000000000000760000000104000001000000640062006F00000046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004400650070006100720074006D0065006E0074004C00650061006400650072004200790045006D0070006C006F0079006500650000000000000000000000C40200000000490000004900000048000000080000000124683EB024683E0000000000000000AD0700000000004A0000004A000000000000006200000001FFD03E01000000640062006F00000046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F0045006400690074006F0072004200790045006D0070006C006F0079006500650000000000000000000000C402000000004B0000004B0000004A000000080000000124683E7024683E0000000000000000AD0700000000004C0000004C000000000000006C0000000100514001000000640062006F00000046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F00470072006F00750070004C00650061006400650072004200790045006D0070006C006F0079006500650000000000000000000000C402000000004D0000004D0000004C000000080000000124683E3024683E0000000000000000AD0700000000004E0000004E00000000000000640000000100D03E01000000640062006F00000046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004D0061006E0061006700650072004200790045006D0070006C006F0079006500650000000000000000000000C402000000004F0000004F0000004E000000080000000123683EF023683E0000000000000000AD070000000000500000005000000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000510000005100000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000005200000052000000000000004800000001FF507701000000640062006F00000046004B005F004500760065006E007400430061006C0065006E006400610072005F004400650070006100720074006D0065006E00740000000000000000000000C40200000000530000005300000052000000080000000123683EB023683E0000000000000000AD0700000000005400000054000000000000004400000001FF507701000000640062006F00000046004B005F004500760065006E007400430061006C0065006E006400610072005F0045006D0070006C006F0079006500650000000000000000000000C402000000005500000055000000540000000800000001129B3E90129B3E0000000000000000AD070000000000560000005600000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000005700000057000000000000003200000001FF414001000000640062006F00000046004B005F00460069006C0065005F0045006D0070006C006F0079006500650000000000000000000000C40200000000580000005800000057000000080000000123683E7023683E0000000000000000AD070000000000590000005900000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000005A0000005A000000000000004000000001FF514001000000640062006F00000046004B005F00420075006C006C006500740069006E005F0062006F006100720064005F00470072006F007500700000000000000000000000C402000000005B0000005B0000005A0000000800000001149B3E50149B3E0000000000000000AD0700000000005C0000005C000000000000003800000001FF414001000000640062006F00000046004B005F00470072006F00750070005F004400650070006100720074006D0065006E00740000000000000000000000C402000000005D0000005D0000005C0000000800000001149B3E90149B3E0000000000000000AD0700000000005E0000005E000000000000003400000001FF414001000000640062006F00000046004B005F0045006D0070006C006F007900650065005F00470072006F007500700000000000000000000000C402000000005F0000005F0000005E000000080000000123683E3023683E0000000000000000AD0700000000006000000060000000000000004C0000000101000001000000640062006F00000046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F00470072006F007500700000000000000000000000C40200000000610000006100000060000000080000000122683EF022683E0000000000000000AD070000000000620000006200000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003100300030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000630000006300000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003100300030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000006400000064000000000000004200000001FF507701000000640062006F00000046004B005F004C00650061007600650048006900730074006F00720079005F0045006D0070006C006F0079006500650000000000000000000000C40200000000650000006500000064000000080000000122683EB022683E0000000000000000AD0700000000006600000066000000000000003C0000000101514001000000640062006F00000046004B005F004C00650061007600650048006900730074006F00720079005F004C00650061007600650000000000000000000000C40200000000670000006700000066000000080000000122683E7022683E0000000000000000AD070000000000680000006800000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800380030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000006900000069000000000000005A0000000100514001000000640062006F00000046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F0079006500650000000000000000000000C402000000006A0000006A000000690000000800000001E29E3EF8E29E3E0000000000000000AD0700000000006B0000006B000000000000007E0000000103514001000000640062006F00000046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F00790065006500420079004400650070006100720074006D0065006E0074004C006500610064006500720000000000000000000000C402000000006C0000006C0000006B0000000800000001E29E3EB8E29E3E0000000000000000AD0700000000006D0000006D00000000000000620000000100D03E01000000640062006F00000046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F007900650065004200790047004D0000000000000000000000C402000000006E0000006E0000006D0000000800000001E29E3E78E29E3E0000000000000000AD0700000000006F0000006F00000000000000740000000104000001000000640062006F00000046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F0045006D0070006C006F0079006500650042007900470072006F00750070004C006500610064006500720000000000000000000000C4020000000070000000700000006F0000000800000001E29E3E38E29E3E0000000000000000AD0700000000007500000075000000000000005400000001FF414001000000640062006F00000046004B005F004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D0070005F004C00650061007600650000000000000000000000C402000000007600000076000000750000000800000001E19E3EF8E19E3E0000000000000000AD070000000000770000007700000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003100300030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000780000007800000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003400300030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000007900000079000000000000005200000001FF414001000000640062006F00000046004B005F004D0065006500740069006E0067005F0072006F006F006D005F0068006900730074006F00720079005F0045006D0070006C006F0079006500650000000000000000000000C402000000007A0000007A000000790000000800000001E19E3EB8E19E3E0000000000000000AD0700000000007B0000007B000000000000005A00000001FF514001000000640062006F00000046004B005F004D0065006500740069006E0067005F0072006F006F006D005F0068006900730074006F00720079005F004D0065006500740069006E0067005F0072006F006F006D0000000000000000000000C402000000007C0000007C0000007B000000080000000189993E7889993E0000000000000000AD0700000000007D0000007D00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800300038000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000007E0000007E000000000000003800000001FF414001000000640062006F00000046004B005F004D006500730073006100670065005F0045006D0070006C006F0079006500650000000000000000000000C402000000007F0000007F0000007E0000000800000001E19E3E78E19E3E0000000000000000AD070000000000800000008000000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800300038000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000008100000081000000000000004400000001FF507701000000640062006F00000046004B005F0043006F006D00700061006E0079005F00760065006800690063006C0065005F004F006600660069006300650000000000000000000000C4020000000082000000820000008100000008000000018B993E388B993E0000000000000000AD0700000000008300000083000000000000003600000001FF414001000000640062006F00000046004B005F0045006D0070006C006F007900650065005F004F006600660069006300650000000000000000000000C402000000008400000084000000830000000800000001E19E3E38E19E3E0000000000000000AD0700000000008500000085000000000000004E0000000102000001000000640062006F00000046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F004F006600660069006300650000000000000000000000C402000000008600000086000000850000000800000001E09E3EF8E09E3E0000000000000000AD0700000000008700000087000000000000003E0000000101514001000000640062006F00000046004B005F004D0065006500740069006E0067005F0072006F006F006D005F004F006600660069006300650000000000000000000000C402000000008800000088000000870000000800000001E09E3EB8E09E3E0000000000000000AD070000000000890000008900000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800300038000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000008A0000008A00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000008B0000008B000000000000003A0000000101514001000000640062006F00000046004B005F0045006D0070006C006F007900650065005F0050006F0073006900740069006F006E0000000000000000000000C402000000008C0000008C0000008B0000000800000001E09E3E78E09E3E0000000000000000AD0700000000008D0000008D000000000000005200000001FF414001000000640062006F00000046004B005F0045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D0070005F0050006F0073006900740069006F006E0000000000000000000000C402000000008E0000008E0000008D0000000800000001E09E3E38E09E3E0000000000000000AD0700000000008F0000008F00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800300038000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000009000000090000000000000003C0000000101514001000000640062006F00000046004B005F0052006500630069007000690065006E0074005F0045006D0070006C006F0079006500650000000000000000000000C402000000009100000091000000900000000800000001DF9E3EF8DF9E3E0000000000000000AD0700000000009200000092000000000000003A0000000101514001000000640062006F00000046004B005F0052006500630069007000690065006E0074005F004D0065007300730061006700650000000000000000000000C40200000000930000009300000092000000080000000191993E7891993E0000000000000000AD070000000000940000009400000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0031003800330036000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000009500000095000000000000003400000001FF414001000000640062006F00000046004B005F005200650070006C0079005F0045006D0070006C006F0079006500650000000000000000000000C402000000009600000096000000950000000800000001DF9E3EB8DF9E3E0000000000000000AD070000000000970000009700000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000980000009800000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000009900000099000000000000004A0000000102000001000000640062006F00000046004B005F005200650070006F0072007400540069006D006500530079007300740065006D005F0045006D0070006C006F0079006500650000000000000000000000C402000000009A0000009A000000990000000800000001DF9E3E78DF9E3E0000000000000000AD0700000000009B0000009B000000000000004400000001FF507701000000640062006F00000046004B005F005200650070006F0072007400540069006D006500530079007300740065006D005F004500760065006E00740000000000000000000000C402000000009C0000009C0000009B0000000800000001DF9E3E38DF9E3E0000000000000000AD0700000000009D0000009D00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003800320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C00310036003800300000009E0000009E000000000000005400000001FF414001000000640062006F00000046004B005F005200650071007500690073006900740069006F006E004D00610069006E005F0041007000700072006F00760061006C0053007400610074007500730000000000000000000000C402000000009F0000009F0000009E0000000800000001DE9E3EF8DE9E3E0000000000000000AD070000000000A0000000A0000000000000004800000001FF507701000000640062006F00000046004B005F005200650071007500690073006900740069006F006E004D00610069006E005F0045006D0070006C006F0079006500650000000000000000000000C40200000000A1000000A1000000A00000000800000001DE9E3EB8DE9E3E0000000000000000AD070000000000A2000000A2000000000000005400000001FF414001000000640062006F00000046004B005F005200650071007500690073006900740069006F006E004D00610069006E005F005200650070006F0072007400430061007400650067006F007200790000000000000000000000C40200000000A3000000A3000000A20000000800000001DE9E3E78DE9E3E0000000000000000AD070000000000A4000000A400000000000000500000000102000001000000640062006F00000046004B005F004F007200640065007200440065007400610069006C005F005200650071007500690073006900740069006F006E004D00610069006E00310000000000000000000000C40200000000A5000000A5000000A40000000800000001DE9E3E38DE9E3E0000000000000000AD070000000000A6000000A6000000000000004800000001FF507701000000640062006F00000046004B005F0041007000700072006F00760061006C005F005200650071007500690073006900740069006F006E004D00610069006E0000000000000000000000C40200000000A7000000A7000000A60000000800000001DD9E3EF8DD9E3E0000000000000000AD070000000000A8000000A800000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0033003200380038000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000A9000000A900000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000AA000000AA00000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000AB000000AB000000000000005200000001FF414001000000640062006F00000046004B005F00530075006700670065007300740069006F006E005F0068006900730074006F00720079005F004400650070006100720074006D0065006E00740000000000000000000000C40200000000AC000000AC000000AB0000000800000001DD9E3EB8DD9E3E0000000000000000AD070000000000AD000000AD000000000000004E0000000101000001000000640062006F00000046004B005F00530075006700670065007300740069006F006E005F0068006900730074006F00720079005F0045006D0070006C006F0079006500650000000000000000000000C40200000000AE000000AE000000AD0000000800000001DD9E3E78DD9E3E0000000000000000AD070000000000AF000000AF000000000000005200000001FF414001000000640062006F00000046004B005F00530075006700670065007300740069006F006E005F0068006900730074006F00720079005F00530075006700670065007300740069006F006E0000000000000000000000C40200000000B0000000B0000000AF0000000800000001DD9E3E38DD9E3E0000000000000000AD070000000000B1000000B100000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000B2000000B200000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000B3000000B300000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0032003300310030002C0031002C0031003800390030002C0035002C0031003200360030000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0032003700380034000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0032003300310030000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0032003300310030002C00310032002C0032003700330030002C00310031002C0031003600380030000000B4000000B400000000000000000000000000000000000000D00200000600280000004100630074006900760065005400610062006C00650056006900650077004D006F006400650000000100000008000400000031000000200000005400610062006C00650056006900650077004D006F00640065003A00300000000100000008003A00000034002C0030002C003200380034002C0030002C0031003800340035002C0031002C0031003500310035002C0035002C0031003000300035000000200000005400610062006C00650056006900650077004D006F00640065003A00310000000100000008001E00000032002C0030002C003200380034002C0030002C0033003700320030000000200000005400610062006C00650056006900650077004D006F00640065003A00320000000100000008001E00000032002C0030002C003200380034002C0030002C0031003800340035000000200000005400610062006C00650056006900650077004D006F00640065003A00330000000100000008001E00000032002C0030002C003200380034002C0030002C0031003800340035000000200000005400610062006C00650056006900650077004D006F00640065003A00340000000100000008003E00000034002C0030002C003200380034002C0030002C0031003800340035002C00310032002C0032003100390030002C00310031002C0031003300350030000000B5000000B5000000000000004A0000000101000001000000640062006F00000046004B005F0043006F006D006D0065006E0074005200650070006C0079005F0043006F006D006D0065006E0074004300680069006C00640000000000000000000000C40200000000B6000000B6000000B50000000800000001DC9E3EF8DC9E3E0000000000000000AD070000000000B7000000B7000000000000004C0000000101000001000000640062006F00000046004B005F0043006F006D006D0065006E0074005200650070006C0079005F0043006F006D006D0065006E0074004300680069006C006400310000000000000000000000C40200000000B8000000B8000000B70000000800000001DC9E3EB8DC9E3E0000000000000000AD070000000000B9000000B9000000000000004800000001FF507701000000640062006F00000046004B005F0043006F006D006D0065006E0074005200650070006C0079005F0043006F006D006D0065006E0074004D00610069006E0000000000000000000000C40200000000BA000000BA000000B90000000800000001DB9E3EB8DB9E3E0000000000000000AD0700000000004F0100001D000000030000001C0000006B0000006400000004000000030000000200000065000000600000000800000007000000060000004C0000004D0000009E0000000A0000009D00000000000000010000000F0000000B0000000E000000250000002400000016000000110000000E000000240000002500000014000000110000000D000000250000002400000012000000110000000C0000008100000060000000B50000001A000000B40000006600000063000000B70000001A000000B40000006600000063000000270000001B000000260000005F0000005C000000210000001B0000001C000000590000006A000000B90000001C000000B4000000650000008C0000001F0000001C0000001A000000690000006800000024000000230000001B000000240000002500000029000000260000001A00000024000000250000002D0000002B0000002C0000005200000061000000AB0000002F000000AA00000058000000650000005C0000002F000000590000005300000054000000520000002F000000510000004100000078000000460000002F000000450000004F000000B6000000410000002F000000320000002500000018000000300000002F00000018000000590000004E000000AD00000032000000AA0000001600000025000000A0000000320000009D0000009B0000004A0000009900000032000000980000002C000000A6000000950000003200000094000000450000002400000090000000320000008F0000008E000000610000007E000000320000007D000000940000006900000079000000320000007800000051000000800000006F000000320000006800000021000000260000006D0000003200000068000000270000002C0000006B00000032000000680000003300000038000000690000003200000068000000390000003E0000006400000032000000630000003F00000024000000570000003200000056000000BB0000006C0000005400000032000000510000001A000000250000004E000000320000004500000024000000230000004C00000032000000450000002A000000350000004A00000032000000450000002600000029000000480000003200000045000000280000002F0000004300000032000000320000004C000000020000003F000000320000002C0000003E000000010000003D000000320000001C00000009000000240000003B000000320000001A00000015000000240000003900000032000000180000001E000000290000003700000032000000180000001C0000002700000035000000320000000300000003000000240000003300000032000000020000000F000000240000009B0000005000000098000000010000000000000060000000590000004500000024000000BC0000005E000000590000003200000037000000200000005A00000059000000180000006E00000057000000750000006200000068000000240000003D00000066000000620000006300000059000000720000007B00000077000000780000003D00000044000000920000007D0000008F00000024000000250000008700000080000000770000005F0000005E0000008500000080000000450000000C000000BF0000008300000080000000320000002F0000004F00000081000000800000002B00000066000000690000008D0000008A0000004500000059000000C20000008B0000008A000000320000002500000022000000A2000000970000009D0000000100000000000000A60000009D000000060000007700000056000000A40000009D000000890000004B00000082000000AF000000A9000000AA000000250000002400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000069006D0065006F00750074003D00330030003B0054007200750073007400530065007200760065007200430065007200740069006600690063006100740065003D00460061006C00730065003B005000610063006B00650074002000530069007A0065003D0034003000390036003B004100700070006C00690063006100740069006F006E0020004E0061006D0065003D0022004D006900630072006F0073006F00660074002000530051004C00200053006500720076006500720020004D0061006E006100670065006D0065006E0074002000530074007500640069006F002200000000800500140000004400690061006700720061006D005F0030000000000226001A00000043006F006D006D0065006E0074005200650070006C007900000008000000640062006F00000000022600180000007300790073006400690061006700720061006D007300000008000000640062006F00000000022600160000007300790073006400690061006700720061006D00000008000000640062006F00000000022600160000005300750072007600650079004D00610069006E00000008000000640062006F0000000002260024000000530075006700670065007300740069006F006E0048006900730074006F0072007900000008000000640062006F0000000002260016000000530075006700670065007300740069006F006E00000008000000640062006F000000000226002800000052006500770061007200640061006E006400500075006E006900730068006D0065006E007400000008000000640062006F00000000022600200000005200650071007500690073006900740069006F006E004D00610069006E00000008000000640062006F00000000022600220000005200650070006F0072007400540069006D006500530079007300740065006D00000008000000640062006F000000000226001E0000005200650070006F0072007400430061007400650067006F0072007900000008000000640062006F000000000226000C0000005200650070006C007900000008000000640062006F000000000226001400000052006500630069007000690065006E007400000008000000640062006F000000000226001200000050006F0073006900740069006F006E00000008000000640062006F00000000022600180000004F007200640065007200440065007400610069006C00000008000000640062006F000000000226000E0000004F0066006600690063006500000008000000640062006F00000000022600100000004D00650073007300610067006500000008000000640062006F00000000022600260000004D0065006500740069006E00670052006F006F006D0048006900730074006F0072007900000008000000640062006F00000000022600180000004D0065006500740069006E00670052006F006F006D00000008000000640062006F00000000022600320000004C00650061007600650048006900730074006F007200790041007000700072006F00760061006C00540065006D007000000008000000640062006F000000000226001A0000004C00650061007600650048006900730074006F0072007900000008000000640062006F000000000226000C0000004C006500610076006500000008000000640062006F000000000226000C000000470072006F0075007000000008000000640062006F000000000226000A000000460069006C006500000008000000640062006F000000000226001C0000004500760065006E007400430061006C0065006E00640061007200000008000000640062006F000000000226000C0000004500760065006E007400000008000000640062006F000000000226002A00000045006D0070006C006F0079006500650041007000700072006F00760061006C00540065006D007000000008000000640062006F000000000226001200000045006D0070006C006F00790065006500000008000000640062006F00000000022600160000004400650070006100720074006D0065006E007400000008000000640062006F000000000226002C00000043006F006D00700061006E007900560065006800690063006C00650048006900730074006F0072007900000008000000640062006F000000000226001E00000043006F006D00700061006E007900560065006800690063006C006500000008000000640062006F000000000226002000000043006F006D006D0065006E0074005100750065007300740069006F006E00000008000000640062006F000000000226001C00000043006F006D006D0065006E0074004F007000740069006F006E00000008000000640062006F000000000226001800000043006F006D006D0065006E0074004D00610069006E00000008000000640062006F000000000226001E00000043006F006D006D0065006E00740043006F006E00740065006E007400000008000000640062006F000000000226001A00000043006F006D006D0065006E0074004300680069006C006400000008000000640062006F000000000226002800000043005F005F004D006900670072006100740069006F006E0048006900730074006F0072007900000008000000640062006F000000000226001C000000420075006C006C006500740069006E0042006F00610072006400000008000000640062006F00000000022600180000004100730070004E006500740055007300650072007300000008000000640062006F00000000022600200000004100730070004E0065007400550073006500720052006F006C0065007300000008000000640062006F00000000022600220000004100730070004E006500740055007300650072004C006F00670069006E007300000008000000640062006F00000000022600220000004100730070004E0065007400550073006500720043006C00610069006D007300000008000000640062006F00000000022600180000004100730070004E006500740052006F006C0065007300000008000000640062006F000000000226001E00000041007000700072006F00760061006C00530074006100740075007300000008000000640062006F000000000226002400000041007000700072006F00760061006C00500072006F00630065006400750072006500000008000000640062006F000000000226001200000041007000700072006F00760061006C00000008000000640062006F000000000226001E00000041006300740069007600690074006900650073004D00610069006E00000008000000640062006F000000000226002000000041006300740069007600690074006900650073004300680069006C006400000008000000640062006F00000000022400100000004100630063006F0075006E007400000008000000640062006F00000001000000D68509B3BB6BF2459AB8371664F0327008004E0000007B00310036003300340043004400440037002D0030003800380038002D0034003200450033002D0039004600410032002D004200360044003300320035003600330042003900310044007D0000000000000000000000000000000000000000000000000000000000010003000000000000000C0000000B0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000062885214)
SET IDENTITY_INSERT [dbo].[sysdiagrams] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_principal_name]    Script Date: 2020/4/8 下午 10:14:44 ******/
ALTER TABLE [dbo].[sysdiagrams] ADD  CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 2020/4/8 下午 10:14:44 ******/
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
