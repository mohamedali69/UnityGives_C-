CREATE TABLE [dbo].[users] (
	[Id] INT IDENTITY (100000, 1) NOT NULL,
	[email] NVARCHAR (50) NOT NULL,
	[password] NVARCHAR (50) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Event] (
	[Event_Id] INT IDENTITY (100000, 1) NOT NULL,
	[Event_Name] NVARCHAR (50) NOT NULL,
	[Event_Type] NVARCHAR (50) NOT NULL,
	[Event_Description] NVARCHAR (50) NOT NULL,
	PRIMARY KEY CLUSTERED ([Event_Id] ASC)
);
CREATE TABLE [dbo].[Donor] (
	[Donor_Id] INT IDENTITY (100000, 1) NOT NULL,
	[Donor_Name] NVARCHAR (50) NOT NULL,
	[Donor_PhoneNumber] NVARCHAR (50) NOT NULL,
	[Donor_Email] NVARCHAR (50) NOT NULL,
	PRIMARY KEY CLUSTERED ([Donor_Id] ASC)
);