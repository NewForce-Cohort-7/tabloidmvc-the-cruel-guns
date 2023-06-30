USE [master]
IF db_id('TabloidMVC') IS NULl
  CREATE DATABASE [TabloidMVC]
GO
USE [TabloidMVC]
GO
DROP TABLE IF EXISTS [PostReaction];
DROP TABLE IF EXISTS [Reaction];
DROP TABLE IF EXISTS [PostTag];
DROP TABLE IF EXISTS [Tag];
DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [Post];
DROP TABLE IF EXISTS [Category];
DROP TABLE IF EXISTS [Subscription];
DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [UserType];
GO
CREATE TABLE [UserType] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(20) NOT NULL
)
CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,
  [DisplayName] nvarchar(50) NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [Email] nvarchar(555) NOT NULL,
  [CreateDateTime] datetime NOT NULL,
  [ImageLocation] nvarchar(255),
  [UserTypeId] integer NOT NULL,
  CONSTRAINT [FK_User_UserType] FOREIGN KEY ([UserTypeId]) REFERENCES [UserType] ([Id])
)
CREATE TABLE [Subscription] (
  [Id] integer PRIMARY KEY IDENTITY,
  [SubscriberUserProfileId] integer NOT NULL,
  [ProviderUserProfileId] integer NOT NULL,
  [BeginDateTime] datetime NOT NULL,
  [EndDateTime] datetime,
  CONSTRAINT [FK_Subscription_UserProfile_Subscriber] FOREIGN KEY ([SubscriberUserProfileId])
	REFERENCES [UserProfile] ([Id]),
  CONSTRAINT [FK_Subscription_UserProfile_Provider] FOREIGN KEY ([ProviderUserProfileId])
	REFERENCES [UserProfile] ([Id])
)
CREATE TABLE [Category] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(50) NOT NULL
)
CREATE TABLE [Post] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Title] nvarchar(255) NOT NULL,
  [Content] text NOT NULL,
  [ImageLocation] nvarchar(255),
  [CreateDateTime] datetime NOT NULL,
  [PublishDateTime] datetime,
  [IsApproved] bit NOT NULL,
  [CategoryId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,
  CONSTRAINT [FK_Post_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]),
  CONSTRAINT [FK_Post_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
)
CREATE TABLE [Comment] (
  [Id] integer PRIMARY KEY IDENTITY,
  [PostId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,
  [Subject] nvarchar(255) NOT NULL,
  [Content] text NOT NULL,
  [CreateDateTime] datetime NOT NULL,
  CONSTRAINT [FK_Comment_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
  CONSTRAINT [FK_Comment_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
)
CREATE TABLE [Tag] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(50) NOT NULL
)
CREATE TABLE [PostTag] (
  [id] integer PRIMARY KEY IDENTITY,
  [PostId] integer NOT NULL,
  [TagId] integer NOT NULL,
  CONSTRAINT [FK_PostTag_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
  CONSTRAINT [FK_PostTag_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tag] ([Id])
)
CREATE TABLE [Reaction] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(50) NOT NULL,
  [ImageLocation] nvarchar(255) NOT NULL
)
CREATE TABLE [PostReaction] (
  [Id] integer PRIMARY KEY IDENTITY,
  [PostId] integer NOT NULL,
  [ReactionId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,
  CONSTRAINT [FK_PostReaction_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
  CONSTRAINT [FK_PostReaction_Reaction] FOREIGN KEY ([ReactionId]) REFERENCES [Reaction] ([Id]),
  CONSTRAINT [FK_PostReaction_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
)
GO
1:42
USE [TabloidMVC]
GO
SET IDENTITY_INSERT [UserType] ON
INSERT INTO [UserType] ([ID], [Name]) VALUES (1, 'Admin'), (2, 'Author');
SET IDENTITY_INSERT [UserType] OFF
SET IDENTITY_INSERT [Category] ON
INSERT INTO [Category] ([Id], [Name])
VALUES (1, 'Technology'), (2, 'Close Magic'), (3, 'Politics'), (4, 'Science'), (5, 'Improv'),
	   (6, 'Cthulhu Sightings'), (7, 'History'), (8, 'Home and Garden'), (9, 'Entertainment'),
	   (10, 'Cooking'), (11, 'Music'), (12, 'Movies'), (13, 'Regrets');
SET IDENTITY_INSERT [Category] OFF
SET IDENTITY_INSERT [Tag] ON
INSERT INTO [Tag] ([Id], [Name])
VALUES (1, 'C#'), (2, 'JavaScript'), (3, 'Cyclopean Terrors'), (4, 'Family');
SET IDENTITY_INSERT [Tag] OFF
SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] (
	[Id], [FirstName], [LastName], [DisplayName], [Email], [CreateDateTime], [ImageLocation], [UserTypeId])
VALUES (1, 'Admina', 'Strator', 'admin', 'admin@example.com', SYSDATETIME(), NULL, 1);
SET IDENTITY_INSERT [UserProfile] OFF
SET IDENTITY_INSERT [Post] ON
INSERT INTO [Post] (
	[Id], [Title], [Content], [ImageLocation], [CreateDateTime], [PublishDateTime], [IsApproved], [CategoryId], [UserProfileId])
VALUES (
	1, 'C# is the Best Language',
'There are those' + char(10) + 'who do not believe' + char(10) + 'C# is the best.' + char(10) + 'They are wrong.',
    'https://gizmodiva.com/wp-content/uploads/2017/10/SCOTT-A-WOODWARD_1SW1943-1170x689.jpg',SYSDATETIME(), SYSDATETIME(), 1, 1, 1);
SET IDENTITY_INSERT [Post] OFF