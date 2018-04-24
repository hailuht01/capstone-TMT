USE [citytour]
GO
ALTER TABLE [dbo].[Itinerary_Landmark] DROP CONSTRAINT [FK_Itenerary_Landmark_Landmark]
GO
ALTER TABLE [dbo].[Itinerary_Landmark] DROP CONSTRAINT [FK_Itenerary_Landmark_Itenerary]
GO
ALTER TABLE [dbo].[Itinerary] DROP CONSTRAINT [FK_Itenerary_Users]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_isAdmin]
GO
ALTER TABLE [dbo].[Itinerary] DROP CONSTRAINT [DF_Itenerary_Title]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/24/2018 1:04:53 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Landmark]    Script Date: 4/24/2018 1:04:53 PM ******/
DROP TABLE [dbo].[Landmark]
GO
/****** Object:  Table [dbo].[Itinerary_Landmark]    Script Date: 4/24/2018 1:04:53 PM ******/
DROP TABLE [dbo].[Itinerary_Landmark]
GO
/****** Object:  Table [dbo].[Itinerary]    Script Date: 4/24/2018 1:04:53 PM ******/
DROP TABLE [dbo].[Itinerary]
GO
USE [master]
GO
/****** Object:  Database [citytour]    Script Date: 4/24/2018 1:04:53 PM ******/
DROP DATABASE [citytour]
GO
/****** Object:  Database [citytour]    Script Date: 4/24/2018 1:04:53 PM ******/
CREATE DATABASE [citytour]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'citytour', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\citytour.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'citytour_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\citytour_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [citytour] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [citytour].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [citytour] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [citytour] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [citytour] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [citytour] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [citytour] SET ARITHABORT OFF 
GO
ALTER DATABASE [citytour] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [citytour] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [citytour] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [citytour] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [citytour] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [citytour] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [citytour] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [citytour] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [citytour] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [citytour] SET  DISABLE_BROKER 
GO
ALTER DATABASE [citytour] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [citytour] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [citytour] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [citytour] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [citytour] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [citytour] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [citytour] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [citytour] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [citytour] SET  MULTI_USER 
GO
ALTER DATABASE [citytour] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [citytour] SET DB_CHAINING OFF 
GO
ALTER DATABASE [citytour] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [citytour] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [citytour] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [citytour] SET QUERY_STORE = OFF
GO
USE [citytour]
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
USE [citytour]
GO
/****** Object:  Table [dbo].[Itinerary]    Script Date: 4/24/2018 1:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itinerary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[User_Email] [varchar](50) NOT NULL,
	[Rating] [int] NOT NULL,
	[CreationDate] [date] NOT NULL,
	[DepartureDate] [date] NULL,
 CONSTRAINT [PK_Itenerary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Itinerary_Landmark]    Script Date: 4/24/2018 1:04:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itinerary_Landmark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Itinerary_Id] [int] NOT NULL,
	[Landmark_Id] [int] NOT NULL,
	[DurationInMin] [int] NOT NULL,
 CONSTRAINT [PK_Itenerary_Landmark] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Landmark]    Script Date: 4/24/2018 1:04:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Landmark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[address] [varchar](100) NOT NULL,
	[PicName] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Landmark] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/24/2018 1:04:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Email] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[isAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Users] ([Email], [Username], [FirstName], [LastName], [Password], [isAdmin]) VALUES (N'admin@citytour.com', N'Admin', N'Admin', N'Jones', N'Password', 1)
GO
INSERT [dbo].[Users] ([Email], [Username], [FirstName], [LastName], [Password], [isAdmin]) VALUES (N'user@citytour.com', N'User', N'User', N'User', N'Password', 0)
GO
ALTER TABLE [dbo].[Itinerary] ADD  CONSTRAINT [DF_Itenerary_Title]  DEFAULT ('Untitled') FOR [Title]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_isAdmin]  DEFAULT ((0)) FOR [isAdmin]
GO
ALTER TABLE [dbo].[Itinerary]  WITH CHECK ADD  CONSTRAINT [FK_Itenerary_Users] FOREIGN KEY([User_Email])
REFERENCES [dbo].[Users] ([Email])
GO
ALTER TABLE [dbo].[Itinerary] CHECK CONSTRAINT [FK_Itenerary_Users]
GO
ALTER TABLE [dbo].[Itinerary_Landmark]  WITH CHECK ADD  CONSTRAINT [FK_Itenerary_Landmark_Itenerary] FOREIGN KEY([Itinerary_Id])
REFERENCES [dbo].[Itinerary] ([Id])
GO
ALTER TABLE [dbo].[Itinerary_Landmark] CHECK CONSTRAINT [FK_Itenerary_Landmark_Itenerary]
GO
ALTER TABLE [dbo].[Itinerary_Landmark]  WITH CHECK ADD  CONSTRAINT [FK_Itenerary_Landmark_Landmark] FOREIGN KEY([Landmark_Id])
REFERENCES [dbo].[Landmark] ([Id])
GO
ALTER TABLE [dbo].[Itinerary_Landmark] CHECK CONSTRAINT [FK_Itenerary_Landmark_Landmark]
GO
USE [master]
GO
ALTER DATABASE [citytour] SET  READ_WRITE 
GO
