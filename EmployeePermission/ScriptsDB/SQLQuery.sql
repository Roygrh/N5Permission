CREATE TABLE [dbo].[Employee](
	[ID] [numeric](11, 0) primary key IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL);

CREATE TABLE [dbo].[PermissionType](
	[ID] [numeric](11, 0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL);

CREATE TABLE [dbo].[Permission](
	[ID] [numeric](11, 0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[IDEmployee] [numeric](11, 0) NULL,
	[IDType] [numeric](11, 0) NULL,
	foreign key (IDEmployee) references Employee(ID),
	FOREIGN KEY (IDType) REFERENCES PermissionType(ID));