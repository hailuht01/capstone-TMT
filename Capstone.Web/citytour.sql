USE [citytour]
GO
ALTER TABLE [dbo].[Itinerary_Landmark] DROP CONSTRAINT [FK_Itinerary_Landmark_Landmark]
GO
ALTER TABLE [dbo].[Itinerary_Landmark] DROP CONSTRAINT [FK_Itinerary_Landmark_Itinerary]
GO
ALTER TABLE [dbo].[Itinerary] DROP CONSTRAINT [FK_Itinerary_Users]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_isAdmin]
GO
ALTER TABLE [dbo].[Landmark] DROP CONSTRAINT [DF_Landmark_ThumbsUp]
GO
ALTER TABLE [dbo].[Itinerary] DROP CONSTRAINT [DF_Itenerary_Title]
GO
/****** Object:  Index [IX_Username]    Script Date: 5/3/2018 11:59:44 AM ******/
DROP INDEX [IX_Username] ON [dbo].[Users]
GO
/****** Object:  Index [CH_Landmark_PlaceID]    Script Date: 5/3/2018 11:59:44 AM ******/
ALTER TABLE [dbo].[Landmark] DROP CONSTRAINT [CH_Landmark_PlaceID]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/3/2018 11:59:44 AM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Landmark]    Script Date: 5/3/2018 11:59:44 AM ******/
DROP TABLE [dbo].[Landmark]
GO
/****** Object:  Table [dbo].[Itinerary_Landmark]    Script Date: 5/3/2018 11:59:44 AM ******/
DROP TABLE [dbo].[Itinerary_Landmark]
GO
/****** Object:  Table [dbo].[Itinerary]    Script Date: 5/3/2018 11:59:44 AM ******/
DROP TABLE [dbo].[Itinerary]
GO
USE [master]
GO
/****** Object:  Database [citytour]    Script Date: 5/3/2018 11:59:44 AM ******/
DROP DATABASE [citytour]
GO
/****** Object:  Database [citytour]    Script Date: 5/3/2018 11:59:44 AM ******/
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
/****** Object:  Table [dbo].[Itinerary]    Script Date: 5/3/2018 11:59:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itinerary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[CreationDate] [date] NOT NULL,
	[DepartureDate] [date] NULL,
	[description] [varchar](250) NULL,
	[User_Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Itenerary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Itinerary_Landmark]    Script Date: 5/3/2018 11:59:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itinerary_Landmark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Itinerary_Id] [int] NOT NULL,
	[Landmark_Id] [int] NOT NULL,
 CONSTRAINT [PK_Itenerary_Landmark] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Landmark]    Script Date: 5/3/2018 11:59:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Landmark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
	[PicName] [varchar](50) NULL,
	[ThumbsUp] [int] NULL,
	[Type] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[PlaceId] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Landmark] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/3/2018 11:59:45 AM ******/
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
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Itinerary] ON 
GO
INSERT [dbo].[Itinerary] ([Id], [Title], [CreationDate], [DepartureDate], [description], [User_Email]) VALUES (9, N'Mock Itinerary', CAST(N'2018-05-02' AS Date), CAST(N'2018-05-05' AS Date), N'This is a mock (admin) Itinerary!', N'Admin@citytour.com')
GO
INSERT [dbo].[Itinerary] ([Id], [Title], [CreationDate], [DepartureDate], [description], [User_Email]) VALUES (10, N'Mock Itinerary', CAST(N'2018-05-02' AS Date), CAST(N'2018-05-05' AS Date), N'This is a mock (admin) Itinerary!', N'Admin@citytour.com')
GO
SET IDENTITY_INSERT [dbo].[Itinerary] OFF
GO
SET IDENTITY_INSERT [dbo].[Landmark] ON 
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (30, 39.0973675, 0, N'Cincinnati Reds Hall of Fame & Museum', N'The Cincinnati Reds Hall of Fame and Museum is an entity established by Major League Baseball''s Cincinnati Reds franchise that pays homage to the team''s past through displays, photographs and multimedia', NULL, 1, N'museum', N'100 Joe Nuxhall Way, Cincinnati, OH 45202, USA', N'ChIJkykqw0SxQYgRavSt4Z7nS7I')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (31, 39.1021235, 0, N'Taft Museum of Art', N'The Taft Museum of Art is a historic house museum holding a fine art collection in Cincinnati. It is on the National Register of Historic Places listings in downtown Cincinnati, Ohio and is a contributing property to the Lytle Park Historic District.[2]', NULL, 1, N'museum', N'4214, 316 Pike St, Cincinnati, OH 45202, USA', N'ChIJdyJfwl2xQYgRf7V1A3VCBFU')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (32, 39.1028135, 0, N'Contemporary Arts Center', N'The Contemporary Arts Center impacts regional and global communities by providing changing arts experiences that challenge, entertain and educate.', NULL, 1, N'museum', N'44 E 6th St, Cincinnati, OH 45202, USA', N'ChIJb4LYpVCxQYgRO54lkCeetLY')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (33, 39.097624, 0, N'National Underground Railroad Freedom Center', N'The National Underground Railroad Freedom Center is a museum in downtown Cincinnati, Ohio based on the history of the Underground Railroad.', NULL, 1, N'museum', N'50 E Freedom Way, Cincinnati, OH 45202, USA', N'ChIJQ9spXUWxQYgRj1GVFSPPYME')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (34, 39.1138109, 0, N'Cincinnati Art Museum', N'The Cincinnati Art Museum is one of the oldest art museums in the United States. Founded in 1881, it was the first purpose-built art museum west of the Alleghenies. Its collection of over 67,000 works spanning 6,000 years of human history make it one of the most comprehensive collections in the Midwest.', NULL, 1, N'museum', N'953 Eden Park Dr, Cincinnati, OH 45202, USA', N'ChIJV0h_FdyzQYgR2CacE0p1ai8')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (35, 39.101749300000009, 0, N'Sawyer Point Park', N'1

It was the mighty Ohio River that brought early settlers to the fertile valley that gave birth to Cincinnati. It was also the river that influenced the direction the young city would grow — as a busy riverboat port, as the terminus of the famed Miami-Erie Canal, as a major industrial and commercial center, and, today, as America’s most beautiful inland river city. Therefore, it seems appropriate to honor the Ohio River with this spectacular environmental sculpture by Andrew Leicester which serves as a dramatic gateway to Bicentennial Commons and to the city’s history as it tells the story of our ties to one of the nation’s great waterways.', NULL, 1, N'park', N'705 E Pete Rose Way, Cincinnati, OH 45202, USA', N'ChIJkV51b2exQYgRLmkA6uJ5Hpo')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (36, 39.1063319, 0, N'Friendship Park', N'The Theodore M. Berry International Friendship Park, completed in 2003 along the Ohio River just east of downtown, is a sumptuous and award-winning display of sculpture and flora representing five continents and also featuring a riverside bike trail and walking paths', NULL, 1, N'park', N'1135 Riverside Dr, Cincinnati, OH 45202, USA', N'ChIJ3QEaHNizQYgR6lDvvgX5BW0')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (37, 39.0949305, 0, N'Smale Riverfront Park', N'Located on 45-acres along Cincinnati''s downtown riverfront, park features include splash grounds and water play areas, playground, picnic area, Carol Ann''s Carousel, Moerlein Lager House and more. See this map for all the features', NULL, 1, N'park', N'100 Ted Berry Way, Cincinnati, OH 45202, USA', N'ChIJLV6xrkWxQYgRDDJyOKNicwM')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (38, 39.1043493, 0, N'Piatt Park', N'This two-block long shady park has fountains, plenty of seating for downtown picnics, and Wi-Fi access. It''s got the only equestrian statue in the city (that of North Bend, Ohio settler and 9th U.S. President William Henry Harrison). Nearly 200 years old now, Piatt Park is a treasured oasis in downtown Cincinnati', NULL, 1, N'park', N'30 Garfield Pl, Cincinnati, OH 45202, USA', N'ChIJd5vM2laxQYgRVrHMfERQ1IA')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (39, 39.1039895, 0, N'Montgomery Inn Boathouse', N'The Montgomery Inn Boathouse has an energy all its own. Maybe it''s the striking view of the Ohio River. Maybe it''s the upstairs sports lounge. Maybe it''s the amazing food and incomparable service. Whatever it is, there''s definitely a vibe and it''s contagious (in a good way, of course)', NULL, 1, N'restaurant', N'925 Riverside Dr, Cincinnati, OH 45202, USA', N'ChIJ1YpO6mOxQYgRavAlyMV6XLo')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (40, 39.101325, 0, N'Palomino - Cincinnati', N'A vibrant "Urban Italian" restaurant, bar and rotisserie famous for its style, hardwood fired Mediterranean cooking and versatile, imaginative menu', NULL, 1, N'restaurant', N'Fountain Place, 505 Vine St, Cincinnati, OH 45202, USA', N'ChIJIa5H81CxQYgRKP1f0J-vJhI')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (41, 39.1155538, 0, N'Pho Lang Thang', N'Upbeat Vietnamese joint inside Findlay Market for bowls of pho & banh mi sandwiches.', NULL, 1, N'restaurant', N'114 W Elder St, Cincinnati, OH 45202, USA', N'ChIJvYfkF_mzQYgRHq5iE8daVjE')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (42, 39.100793, 0, N'I Love Cincinnati Shop', N'If you are downtown for the parade and/or Opening Day, stop in and see us. We have Reds jackets, tees, ponchos, small purses, hats, blankets, black/red tights and more. Go Reds!', NULL, 1, N'store', N'441 Vine St, Cincinnati, OH 45202, USA', N'ChIJJaWu8tTRcEARPNYJ3thmkMU')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (43, 39.1023291, 0, N'Batsakes Hat Shop', N'Long-standing shop offering an assortment of handcrafted hats in an old-school atmosphere.', NULL, 1, N'store', N'1 W 6th St, Cincinnati, OH 45202, USA', N'ChIJndhJwlCxQYgRLnt_YZqOWDw')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (45, 39.0959805, 0, N'Anderson Pavilion', N'Anderson Pavilion offers spectacular views, contemporary elegance decor & ambiance, state-of-the art technology and an award-winning in-house culinary group. The Pavilion will offer a 350+ seat conference facility, ideal for hosting a wide variety of events.', NULL, 1, N'venue', N'8 E Mehring Way, Cincinnati, OH 45202, USA', N'ChIJLTILfkWxQYgRzEVMtCPCzzI')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (46, 39.143864, 0, N'Live at the Ludlow Garage', N'The Ludlow Garage began life as an automobile shop and later became a music venue located in the Clifton neighborhood of Cincinnati, Ohio.', NULL, 1, N'venue', N'342 Ludlow Ave, Cincinnati, OH 45220, USA', N'ChIJ1xTCa4ezQYgR2HxQejIcIcc')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (47, 39.1299821, 0, N'Bogart''s', N'Bogart''s is a venue for local, national, and international live music. Bogart''s has been recognized on the international stage for bringing the newest and best music and events to the public and continues the tradition of quality live entertainment that has been its forté since the building was built.', NULL, 1, N'venue', N'2621 Vine St, Cincinnati, OH 45219, USA', N'ChIJg6GhiFuxQYgRUjOYufKfBLY')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (48, 39.113055500000009, 0, N'Elsinore Arch', N'Elsinore Arch is a registered historic structure in Cincinnati, Ohio, listed in the National Register on March 3, 1980. The building, at Gilbert Avenue and Elsinore Place, was constructed in 1883 for the Cincinnati Water Works', NULL, 1, N'landmark', N'1292-1298 Elsinore Ave, Cincinnati, OH 45202, USA', N'ChIJF2IodN6zQYgRasZSqn9M_gs')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (50, 39.1052773, 0, N'Cincinnati Fire Museum', N'Cincinnati Fire Museum. The Cincinnati Fire Museum highlights the significant contributions that Cincinnati has made to the firefighting profession. Cincinnati is the birthplace of professional firefighting and we are proud to display its history', NULL, 1, N'museum', N'315 W Court St #1, Cincinnati, OH 45202, USA', N'ChIJmTZMX1SxQYgR2wuqNwACn_o')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (51, 39.1020517, 0, N'Rock Bottom Restaurant & Brewery', N'Brewpub chain serving house beers & upscale pub food & American fare in lively environs', NULL, 1, N'restaurant', N'10 Fountain Square Plaza, Cincinnati, OH 45202, USA', N'ChIJTV91kXJXQIgR-Yriq1FpdxU')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (52, 39.0969133, 0, N'Yard House', N'At Yard House enjoy more than 100 taps of the best American craft and import beers, plus a menu with more than 100 dishes made from scratch in our kitchen.', NULL, 1, N'restaurant', N'95 E Freedom Way, Cincinnati, OH 45202, USA', N'ChIJfWU7P0WxQYgR0Z7qRaNJrUI')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (53, 39.1056316, 0, N'Cincinnati Times-Star Building', N'Cincinnati Times-Star Building at 800 Broadway Street in Cincinnati, Ohio 45202, is a registered historic building. It was listed in the National Register on November 25, 1983. It was built in 1933 and was designed by the firm of Samuel Hannaford & Sons in the Art Deco Style.', NULL, 1, N'landmark', N'Reedy St, Cincinnati, OH 45202, USA', N'ChIJnTv6KFmxQYgRmbd2Gwwx0Dg')
GO
INSERT [dbo].[Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (54, 39.1000838, 0, N'Ingalls Building', N'The Ingalls Building, built in 1903 in Cincinnati, Ohio, is the world''s first reinforced concrete skyscraper. The 16-story building was designed by the Cincinnati architectural firm Elzner & Anderson and was named for its primary financial investor, Melville E. Ingalls', NULL, 1, N'landmark', N'6 E 4th St, Cincinnati, OH 45202, USA', N'ChIJB0oBcFCxQYgRWNRuanmaxj4')
GO
SET IDENTITY_INSERT [dbo].[Landmark] OFF
GO
INSERT [dbo].[Users] ([Email], [Username], [FirstName], [LastName], [Password], [isAdmin]) VALUES (N'admin@citytour.com', N'Admin', N'Admin', N'Jones', N'Password', 1)
GO
INSERT [dbo].[Users] ([Email], [Username], [FirstName], [LastName], [Password], [isAdmin]) VALUES (N'djpowerhouse513@gmail.com', N'Powerhouse', N'Byron', N'THOMPSON', N'BigSPlash513!', 0)
GO
INSERT [dbo].[Users] ([Email], [Username], [FirstName], [LastName], [Password], [isAdmin]) VALUES (N'user@citytour.com', N'User', N'User', N'User', N'Password', 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CH_Landmark_PlaceID]    Script Date: 5/3/2018 11:59:45 AM ******/
ALTER TABLE [dbo].[Landmark] ADD  CONSTRAINT [CH_Landmark_PlaceID] UNIQUE NONCLUSTERED 
(
	[PlaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Username]    Script Date: 5/3/2018 11:59:45 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Itinerary] ADD  CONSTRAINT [DF_Itenerary_Title]  DEFAULT ('Untitled') FOR [Title]
GO
ALTER TABLE [dbo].[Landmark] ADD  CONSTRAINT [DF_Landmark_ThumbsUp]  DEFAULT ((1)) FOR [ThumbsUp]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_isAdmin]  DEFAULT ((0)) FOR [isAdmin]
GO
ALTER TABLE [dbo].[Itinerary]  WITH CHECK ADD  CONSTRAINT [FK_Itinerary_Users] FOREIGN KEY([User_Email])
REFERENCES [dbo].[Users] ([Email])
GO
ALTER TABLE [dbo].[Itinerary] CHECK CONSTRAINT [FK_Itinerary_Users]
GO
ALTER TABLE [dbo].[Itinerary_Landmark]  WITH CHECK ADD  CONSTRAINT [FK_Itinerary_Landmark_Itinerary] FOREIGN KEY([Itinerary_Id])
REFERENCES [dbo].[Itinerary] ([Id])
GO
ALTER TABLE [dbo].[Itinerary_Landmark] CHECK CONSTRAINT [FK_Itinerary_Landmark_Itinerary]
GO
ALTER TABLE [dbo].[Itinerary_Landmark]  WITH CHECK ADD  CONSTRAINT [FK_Itinerary_Landmark_Landmark] FOREIGN KEY([Landmark_Id])
REFERENCES [dbo].[Landmark] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Itinerary_Landmark] CHECK CONSTRAINT [FK_Itinerary_Landmark_Landmark]
GO
USE [master]
GO
ALTER DATABASE [citytour] SET  READ_WRITE 
GO
