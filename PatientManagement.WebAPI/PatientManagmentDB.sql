USE [master]
GO
/****** Object:  Database [PatientManagement]    Script Date: 2/21/2025 10:33:07 PM ******/
CREATE DATABASE [PatientManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PatientManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PatientManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PatientManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PatientManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PatientManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PatientManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PatientManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PatientManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PatientManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PatientManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PatientManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [PatientManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PatientManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PatientManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PatientManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PatientManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PatientManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PatientManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PatientManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PatientManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PatientManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PatientManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PatientManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PatientManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PatientManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PatientManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PatientManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PatientManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PatientManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PatientManagement] SET  MULTI_USER 
GO
ALTER DATABASE [PatientManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PatientManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PatientManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PatientManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PatientManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PatientManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PatientManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [PatientManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PatientManagement]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 2/21/2025 10:33:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[AppointmentDate] [datetime] NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 2/21/2025 10:33:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Street] [nvarchar](200) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[State] [nvarchar](100) NOT NULL,
	[ZipCode] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__Patients__3214EC07AB34B69D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 
GO
INSERT [dbo].[Appointments] ([Id], [PatientId], [AppointmentDate], [Description]) VALUES (1, 1, CAST(N'2025-03-01T10:00:00.000' AS DateTime), N'Routine checkup')
GO
INSERT [dbo].[Appointments] ([Id], [PatientId], [AppointmentDate], [Description]) VALUES (2, 1, CAST(N'2025-04-15T14:30:00.000' AS DateTime), N'Follow-up consultation')
GO
INSERT [dbo].[Appointments] ([Id], [PatientId], [AppointmentDate], [Description]) VALUES (3, 2, CAST(N'2025-03-05T09:00:00.000' AS DateTime), N'Dental cleaning')
GO
INSERT [dbo].[Appointments] ([Id], [PatientId], [AppointmentDate], [Description]) VALUES (4, 2, CAST(N'2025-04-20T11:15:00.000' AS DateTime), N'Orthodontic checkup')
GO
INSERT [dbo].[Appointments] ([Id], [PatientId], [AppointmentDate], [Description]) VALUES (5, 3, CAST(N'2025-03-10T08:45:00.000' AS DateTime), N'Annual physical exam')
GO
INSERT [dbo].[Appointments] ([Id], [PatientId], [AppointmentDate], [Description]) VALUES (6, 3, CAST(N'2025-05-01T16:00:00.000' AS DateTime), N'Blood test review')
GO
INSERT [dbo].[Appointments] ([Id], [PatientId], [AppointmentDate], [Description]) VALUES (7, 1, CAST(N'2025-02-22T19:27:30.077' AS DateTime), N'Annual physical exam')
GO
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 
GO
INSERT [dbo].[Patients] ([Id], [Email], [FullName], [DateOfBirth], [Street], [City], [State], [ZipCode]) VALUES (1, N'0rcsWZ5fGsKdmb3cBqEK2JxLiWt/AxaBFECX70koe+k=', N'John Doe', CAST(N'2025-02-21T18:53:31.640' AS DateTime), N'123 Main St', N'Los Angeles', N'CA', N'90001')
GO
INSERT [dbo].[Patients] ([Id], [Email], [FullName], [DateOfBirth], [Street], [City], [State], [ZipCode]) VALUES (2, N'ACvB8UXcvFz7rrMWcFen9VucagvMoq61GHtYESPOyP8=', N'Jane Smith', CAST(N'2025-02-21T18:53:31.640' AS DateTime), N'456 Oak St', N'New York', N'NY', N'10001')
GO
INSERT [dbo].[Patients] ([Id], [Email], [FullName], [DateOfBirth], [Street], [City], [State], [ZipCode]) VALUES (3, N'YWKxyLn1cp6J6O0Hehkxltrct2mJQWfhm+zrRelMedQ=', N'Michael Johnson', CAST(N'2025-02-21T18:53:31.640' AS DateTime), N'789 Pine St', N'Chicago', N'IL', N'60601')
GO
INSERT [dbo].[Patients] ([Id], [Email], [FullName], [DateOfBirth], [Street], [City], [State], [ZipCode]) VALUES (5, N'5is57+eSh1xd22T7BRg19udwOWKmhSDMvHs8Eyvsfxg=', N'Hossam Yassin', CAST(N'2025-02-21T19:15:15.240' AS DateTime), N'227 ALFath', N'Alex', N'Alex', N'2222')
GO
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Patients]
GO
USE [master]
GO
ALTER DATABASE [PatientManagement] SET  READ_WRITE 
GO
