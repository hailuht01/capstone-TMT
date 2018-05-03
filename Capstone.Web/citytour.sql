USE [citytour]
GO
ALTER TABLE [Itinerary_Landmark] DROP CONSTRAINT [FK_Itinerary_Landmark_Landmark]
GO
ALTER TABLE [Itinerary_Landmark] DROP CONSTRAINT [FK_Itinerary_Landmark_Itinerary]
GO
ALTER TABLE [Itinerary] DROP CONSTRAINT [FK_Itinerary_Users]
GO
ALTER TABLE [Users] DROP CONSTRAINT [DF_Users_isAdmin]
GO
ALTER TABLE [Landmark] DROP CONSTRAINT [DF_Landmark_ThumbsUp]
GO
ALTER TABLE [Itinerary] DROP CONSTRAINT [DF_Itenerary_Title]
GO
/****** Object:  Index [IX_Username]    Script Date: 5/3/2018 1:18:12 PM ******/
DROP INDEX [IX_Username] ON [Users]
GO
/****** Object:  Index [CH_Landmark_PlaceID]    Script Date: 5/3/2018 1:18:12 PM ******/
ALTER TABLE [Landmark] DROP CONSTRAINT [CH_Landmark_PlaceID]
GO
/****** Object:  Table [Users]    Script Date: 5/3/2018 1:18:12 PM ******/
DROP TABLE [Users]
GO
/****** Object:  Table [Landmark]    Script Date: 5/3/2018 1:18:12 PM ******/
DROP TABLE [Landmark]
GO
/****** Object:  Table [Itinerary_Landmark]    Script Date: 5/3/2018 1:18:12 PM ******/
DROP TABLE [Itinerary_Landmark]
GO
/****** Object:  Table [Itinerary]    Script Date: 5/3/2018 1:18:12 PM ******/
DROP TABLE [Itinerary]
GO
USE [master]
GO
/****** Object:  Database [citytour]    Script Date: 5/3/2018 1:18:12 PM ******/
DROP DATABASE [citytour]
GO
/****** Object:  Database [citytour]    Script Date: 5/3/2018 1:18:12 PM ******/
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
/****** Object:  Table [Itinerary]    Script Date: 5/3/2018 1:18:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Itinerary](
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
/****** Object:  Table [Itinerary_Landmark]    Script Date: 5/3/2018 1:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Itinerary_Landmark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Itinerary_Id] [int] NOT NULL,
	[Landmark_Id] [int] NOT NULL,
 CONSTRAINT [PK_Itenerary_Landmark] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Landmark]    Script Date: 5/3/2018 1:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Landmark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
	[PicName] [varchar](50) NULL,
	[ThumbsUp] [int] NULL,
	[Type] [varchar](200) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[PlaceId] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Landmark] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Users]    Script Date: 5/3/2018 1:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users](
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
SET IDENTITY_INSERT [Itinerary] ON 
GO
INSERT [Itinerary] ([Id], [Title], [CreationDate], [DepartureDate], [description], [User_Email]) VALUES (9, N'Mock Itinerary', CAST(N'2018-05-02' AS Date), CAST(N'2018-05-05' AS Date), N'This is a mock (admin) Itinerary!', N'Admin@citytour.com')
GO
INSERT [Itinerary] ([Id], [Title], [CreationDate], [DepartureDate], [description], [User_Email]) VALUES (10, N'Mock Itinerary', CAST(N'2018-05-02' AS Date), CAST(N'2018-05-05' AS Date), N'This is a mock (admin) Itinerary!', N'Admin@citytour.com')
GO
SET IDENTITY_INSERT [Itinerary] OFF
GO
SET IDENTITY_INSERT [Landmark] ON 
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (1, 39.097624, -84.511238999999989, N'National Underground Railroad Freedom Center', N'The National Underground Railroad Freedom Center is a museum in downtown Cincinnati, Ohio based on the history of the Underground Railroad', NULL, 1, N'museum', N'50 E Freedom Way, Cincinnati, OH 45202, USA', N'ChIJQ9spXUWxQYgRj1GVFSPPYME')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (3, 39.1028135, -84.512008900000012, N'Contemporary Arts Center', N'The Contemporary Arts Center is a contemporary art museum in Cincinnati, Ohio and one of the first contemporary art institutions in the United States. ', NULL, 1, N'museum', N'44 E 6th St, Cincinnati, OH 45202, USA', N'ChIJb4LYpVCxQYgRO54lkCeetLY')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (4, 39.1021235, -84.502636600000017, N'Taft Museum of Art', N'The Taft Museum of Art is a historic house museum holding a fine art collection in Cincinnati. It is on the National Register of Historic Places listings in downtown Cincinnati, Ohio and is a contributing property to the Lytle Park Historic District.[2]', NULL, 1, N'museum', N'4214, 316 Pike St, Cincinnati, OH 45202, USA', N'ChIJdyJfwl2xQYgRf7V1A3VCBFU')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (5, 39.1138109, -84.49719060000001, N'Cincinnati Art Museum', N'Located in scenic Eden Park, the Cincinnati Art Museum features a diverse, encyclopedic art collection of more than 67000 works spanning 6000 years. In addition to displaying its own broad collection, the museum also hosts several national and international traveling exhibitions each year.', NULL, 1, N'museum', N'953 Eden Park Dr, Cincinnati, OH 45202, USA', N'ChIJV0h_FdyzQYgR2CacE0p1ai8')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (6, 39.0949305, -84.511492200000021, N'Smale Riverfront Park', N'Scenic riverside venue with fountains, gardens, walkways, playgrounds, event lawns & restaurants.', NULL, 1, N'park', N'100 Ted Berry Way, Cincinnati, OH 45202, USA', N'ChIJLV6xrkWxQYgRDDJyOKNicwM')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (7, 39.101749300000009, -84.498661099999993, N'Sawyer Point Park', N'Cincinnati''s Central Riverfront is an outstanding riverfront facility. Located along the shore of the Ohio River just south of downtown Cincinnati, this mile-long linear park features many different spaces serving all segments of the region''s population', NULL, 1, N'park', N'705 E Pete Rose Way, Cincinnati, OH 45202, USA', N'ChIJkV51b2exQYgRLmkA6uJ5Hpo')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (8, 39.1163363, -84.496168799999964, N'Eden Park', N'Eden Park is an urban park located in the Walnut Hills and Mt. Adams neighborhoods of Cincinnati, Ohio. The hilltop park occupies 186 acres, and offers numerous overlooks of the Ohio River valley', NULL, 1, N'park', N'950 Eden Park Dr, Cincinnati, OH 45202, USA', N'ChIJ1S65e9qzQYgRMGR4AQFZg9s')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (9, 39.1039895, -84.494550199999992, N'Montgomery Inn Boathouse', N'The Montgomery Inn Boathouse has an energy all its own. Maybe it''s the striking view of the Ohio River. Maybe it''s the upstairs sports lounge. Maybe it''s the amazing food and incomparable service. Whatever it is, there''s definitely a vibe and it''s contagious (in a good way, of course).', NULL, 1, N'restaurant', N'925 Riverside Dr, Cincinnati, OH 45202, USA', N'ChIJ1YpO6mOxQYgRavAlyMV6XLo')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (10, 39.0969133, -84.5104814, N'Yard House', N'At Yard House enjoy more than 100 taps of the best American craft and import beers, plus a menu with more than 100 dishes made from scratch in our kitchen.', NULL, 1, N'restaurant', N'95 E Freedom Way, Cincinnati, OH 45202, USA', N'ChIJfWU7P0WxQYgR0Z7qRaNJrUI')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (11, 39.102908, -84.511471000000029, N'Nada', N'Trendy Mexican cantina with outdoor seating, festive cocktails & upscale fare in a chic setting.', NULL, 1, N'restaurant', N'600 Walnut St, Cincinnati, OH 45202, USA', N'ChIJ9UWCBlqxQYgRoH9ooQSY_jI')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (12, 39.1155538, -84.518907099999979, N'Pho Lang Thang', N'Upbeat Vietnamese joint inside Findlay Market for bowls of pho & banh mi sandwiches.', NULL, 1, N'restaurant', N'114 W Elder St, Cincinnati, OH 45202, USA', N'ChIJvYfkF_mzQYgRHq5iE8daVjE')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (13, 39.1092418, -84.517291199999988, N'Washington Park', N'The newly renovated and expanded Washington Park is an important civic space in the heart of Cincinnati that has evolved over the last 150 years to accommodate the needs and aspirations of the community.', NULL, 1, N'park', N'1230 Elm St, Cincinnati, OH 45202, USA', N'ChIJD1M8-VWxQYgRS8uaCQAi7uo')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (14, 39.0959805, -84.5114178, N'Anderson Pavilion', N'Anderson Pavilion offers spectacular views, contemporary elegance decor & ambiance, state-of-the art technology and an award-winning in-house culinary group.', NULL, 1, N'venue', N'8 E Mehring Way, Cincinnati, OH 45202, USA', N'ChIJLTILfkWxQYgRzEVMtCPCzzI')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (15, 39.095595, -84.523510999999985, N'Longworth Hall Event Center', N'Longworth Hall is a beautiful adaptation of a quarter mile long warehouse that was built in 1904 on land owned by Nicolas Longworth. * On the National Register of Historic Places.', NULL, 1, N'venue', N'700 W Pete Rose Way #137, Cincinnati, OH 45203, USA', N'ChIJ2c6oIrO2QYgR7gomoDgseow')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (16, 39.1079693, -84.5182115, N'The Transept', N'Funky''s Catering is proud to introduce Cincinnati''s premier event space, nestled in the southwest corner of Washington Park, The Transept transforms the historic German gothic church into a world-class venue for weddings, meetings, receptions and social gatherings', NULL, 1, N'venue', N'1205 Elm St, Cincinnati, OH 45202, USA', N'ChIJqfHgllWxQYgRmsT8hvq4C28')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (17, 39.1299821, -84.5100266, N'Bogart''s', N'Bogart''s is a venue for local, national, and international live music. Bogart''s has been recognized on the international stage for bringing the newest and best music and events to the public and continues the tradition of quality live entertainment that has been its forté since the building was built.', NULL, 1, N'venue', N'2621 Vine St, Cincinnati, OH 45219, USA', N'ChIJg6GhiFuxQYgRUjOYufKfBLY')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (18, 39.100793, -84.513230000000021, N'I Love Cincinnati Shop', N'I Love Cincinnati Shoppe offers everything you need to represent the Cincy-style with a large selection gifts and souvenirs.', NULL, 1, N'store', N'441 Vine St, Cincinnati, OH 45202, USA', N'ChIJJaWu8tTRcEARPNYJ3thmkMU')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (19, 39.1098918, -84.51000479999999, N'The Snatch Shop', N'Count on us for your fashion accessories/ unisex wears/ beauty products.', NULL, 1, N'store', N'1212 Sycamore St, Cincinnati, OH 45202, USA', N'ChIJo9jH7OKzQYgRwve1y-nDu_0')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (20, 39.1052203, -84.51328890000002, N'Library Friends'' Shop', N'At The Friends of the Public Library you can find a multitude of unique, comfortably priced gifts for all ages and tastes.', NULL, 1, N'store', N'800 Vine St, Cincinnati, OH 45202, USA', N'ChIJe3UJDFexQYgR3ZQGE4s4XM0')
GO
INSERT [Landmark] ([Id], [Latitude], [Longitude], [Name], [Description], [PicName], [ThumbsUp], [Type], [Address], [PlaceId]) VALUES (21, 39.1101215, -84.512103200000013, N'Libby Shop', N'When you shop at LIBBY Boutique, you''ll find contemporary women''s clothing and accessories', NULL, 1, N'store', N'1307 Main St, Cincinnati, OH 45202, USA', N'ChIJTdf90PyzQYgRx8cFDIt6N7A')
GO
SET IDENTITY_INSERT [Landmark] OFF
GO
INSERT [Users] ([Email], [Username], [FirstName], [LastName], [Password], [isAdmin]) VALUES (N'admin@citytour.com', N'Admin', N'Admin', N'Jones', N'Password', 1)
GO
INSERT [Users] ([Email], [Username], [FirstName], [LastName], [Password], [isAdmin]) VALUES (N'djpowerhouse513@gmail.com', N'Powerhouse', N'Byron', N'THOMPSON', N'BigSPlash513!', 0)
GO
INSERT [Users] ([Email], [Username], [FirstName], [LastName], [Password], [isAdmin]) VALUES (N'ruptastic@gmail.com', N'chris', N'Chris', N'Rupp', N'Password123!', 0)
GO
INSERT [Users] ([Email], [Username], [FirstName], [LastName], [Password], [isAdmin]) VALUES (N'user@citytour.com', N'User', N'User', N'User', N'Password', 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CH_Landmark_PlaceID]    Script Date: 5/3/2018 1:18:13 PM ******/
ALTER TABLE [Landmark] ADD  CONSTRAINT [CH_Landmark_PlaceID] UNIQUE NONCLUSTERED 
(
	[PlaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Username]    Script Date: 5/3/2018 1:18:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Username] ON [Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Itinerary] ADD  CONSTRAINT [DF_Itenerary_Title]  DEFAULT ('Untitled') FOR [Title]
GO
ALTER TABLE [Landmark] ADD  CONSTRAINT [DF_Landmark_ThumbsUp]  DEFAULT ((1)) FOR [ThumbsUp]
GO
ALTER TABLE [Users] ADD  CONSTRAINT [DF_Users_isAdmin]  DEFAULT ((0)) FOR [isAdmin]
GO
ALTER TABLE [Itinerary]  WITH CHECK ADD  CONSTRAINT [FK_Itinerary_Users] FOREIGN KEY([User_Email])
REFERENCES [Users] ([Email])
GO
ALTER TABLE [Itinerary] CHECK CONSTRAINT [FK_Itinerary_Users]
GO
ALTER TABLE [Itinerary_Landmark]  WITH CHECK ADD  CONSTRAINT [FK_Itinerary_Landmark_Itinerary] FOREIGN KEY([Itinerary_Id])
REFERENCES [Itinerary] ([Id])
GO
ALTER TABLE [Itinerary_Landmark] CHECK CONSTRAINT [FK_Itinerary_Landmark_Itinerary]
GO
ALTER TABLE [Itinerary_Landmark]  WITH CHECK ADD  CONSTRAINT [FK_Itinerary_Landmark_Landmark] FOREIGN KEY([Landmark_Id])
REFERENCES [Landmark] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Itinerary_Landmark] CHECK CONSTRAINT [FK_Itinerary_Landmark_Landmark]
GO
USE [master]
GO
ALTER DATABASE [citytour] SET  READ_WRITE 
GO
