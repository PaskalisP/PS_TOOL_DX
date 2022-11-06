CREATE TABLE [dbo].[Formblatt_BILANZ_TOTALS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Bilanzposition] [nvarchar](1000) NULL,
	[Bilanzposition_ID] [int] NULL,
	[BilanzpositionArt] [nvarchar](50) NULL,
	[AmountCurrentDate] [float] NULL,
	[AmountCurrentDate_UP] [float] NULL,
	[AmountLastYear] [float] NULL,
	[AmountLastYear_UP] [float] NULL,
	[AmountManualBooking] [float] NULL,
	[SQLcommandCurrentDate] [nvarchar](4000) NULL,
	[SQLcommandLastYear] [nvarchar](4000) NULL,
	[RiskDate] [datetime] NULL,
 CONSTRAINT [PK_Formblatt_BILANZ] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Formblatt_BILANZ_TOTALS] ADD  CONSTRAINT [DF_Formblatt_BILANZ_AmountCurrentDate]  DEFAULT (0) FOR [AmountCurrentDate]
GO

ALTER TABLE [dbo].[Formblatt_BILANZ_TOTALS] ADD  CONSTRAINT [DF_Formblatt_BILANZ_AmountCurrentDate_UP]  DEFAULT (0) FOR [AmountCurrentDate_UP]
GO

ALTER TABLE [dbo].[Formblatt_BILANZ_TOTALS] ADD  CONSTRAINT [DF_Formblatt_BILANZ_AmountLastYear]  DEFAULT (0) FOR [AmountLastYear]
GO

ALTER TABLE [dbo].[Formblatt_BILANZ_TOTALS] ADD  CONSTRAINT [DF_Formblatt_BILANZ_AmountLastYear_UP]  DEFAULT (0) FOR [AmountLastYear_UP]
GO

ALTER TABLE [dbo].[Formblatt_BILANZ_TOTALS] ADD  CONSTRAINT [DF_Formblatt_BILANZ_AmountManualBooking]  DEFAULT (0) FOR [AmountManualBooking]
GO


CREATE TABLE [dbo].[Formblatt_BILANZ_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GL_Item] [nvarchar](10) NULL,
	[ReleatedAccountNr] [nvarchar](50) NULL,
	[GL_Account_Nr] [nvarchar](50) NULL,
	[GL_Account_Name] [nvarchar](150) NULL,
	[Total_Balance] [float] NULL,
	[BSDate] [datetime] NULL,
	[RilibiCode] [nvarchar](50) NULL,
	[RilibiName] [nvarchar](1000) NULL,
	[IdFormblattBALANCE_TOTALS] [int] NULL,
 CONSTRAINT [PK_Formblatt_BILANZ_Details] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Formblatt_BILANZ_Details] ADD  CONSTRAINT [DF_Formblatt_BILANZ_Details_Total_Balance]  DEFAULT (0) FOR [Total_Balance]
GO

ALTER TABLE [dbo].[Formblatt_BILANZ_Details]  WITH NOCHECK ADD  CONSTRAINT [FK_Formblatt_BILANZ_Details_Formblatt_BILANZ_TOTALS] FOREIGN KEY([IdFormblattBALANCE_TOTALS])
REFERENCES [dbo].[Formblatt_BILANZ_TOTALS] ([ID])
GO

ALTER TABLE [dbo].[Formblatt_BILANZ_Details] NOCHECK CONSTRAINT [FK_Formblatt_BILANZ_Details_Formblatt_BILANZ_TOTALS]
GO