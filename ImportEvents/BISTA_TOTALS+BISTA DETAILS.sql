CREATE TABLE [dbo].[BISTA_TOTALS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BistaPositionNr] [nvarchar](50) NULL,
	[BistaPositionName] [nvarchar](1000) NULL,
	[BistaPosition_ID] [float] NULL,
	[BistaPositionArt] [nvarchar](50) NULL,
	[BistaAmountPosition_HP] [float] NULL,
	[BistaAmountPosition_UP] [float] NULL,
	[AmountLastYear] [float] NULL,
	[AmountLastYear_UP] [float] NULL,
	[AmountManualBooking] [float] NULL,
	[SQLcommandCurrentDate] [nvarchar](4000) NULL,
	[SQLcommandLastYear] [nvarchar](4000) NULL,
	[RiskDate] [datetime] NULL,
 CONSTRAINT [PK_BISTA_TOTALS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BISTA_TOTALS] ADD  CONSTRAINT [DF_BISTA_TOTALS_BistaAmountPositionHaupt]  DEFAULT ((0)) FOR [BistaAmountPosition_HP]
GO

ALTER TABLE [dbo].[BISTA_TOTALS] ADD  CONSTRAINT [DF_BISTA_TOTALS_BistaAmountPosition_UP]  DEFAULT ((0)) FOR [BistaAmountPosition_UP]
GO

ALTER TABLE [dbo].[BISTA_TOTALS] ADD  CONSTRAINT [DF_BISTA_TOTALS_AmountLastYear]  DEFAULT ((0)) FOR [AmountLastYear]
GO

ALTER TABLE [dbo].[BISTA_TOTALS] ADD  CONSTRAINT [DF_BISTA_TOTALS_AmountLastYear_UP]  DEFAULT ((0)) FOR [AmountLastYear_UP]
GO

ALTER TABLE [dbo].[BISTA_TOTALS] ADD  CONSTRAINT [DF_BISTA_TOTALS_AmountManualBooking]  DEFAULT ((0)) FOR [AmountManualBooking]
GO

CREATE TABLE [dbo].[BISTA_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GL_Item] [nvarchar](10) NULL,
	[ReleatedAccountNr] [nvarchar](50) NULL,
	[GL_Account_Nr] [nvarchar](50) NULL,
	[GL_Account_Name] [nvarchar](150) NULL,
	[ClientType] [nvarchar](50) NULL,
	[ClientName] [nvarchar](200) NULL,
	[BusinessType] [nvarchar](200) NULL,
	[Total_Balance] [float] NULL,
	[BistaCode] [nvarchar](50) NULL,
	[BistaPositionNr] [nvarchar](50) NULL,
	[BSDate] [datetime] NULL,
	[IdBISTA_TOTALS] [int] NULL,
 CONSTRAINT [PK_BISTA_Details] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BISTA_Details] ADD  CONSTRAINT [DF_BISTA_Details_Total_Balance]  DEFAULT ((0)) FOR [Total_Balance]
GO

ALTER TABLE [dbo].[BISTA_Details]  WITH NOCHECK ADD  CONSTRAINT [FK_BISTA_Details_BISTA_TOTALS] FOREIGN KEY([IdBISTA_TOTALS])
REFERENCES [dbo].[BISTA_TOTALS] ([ID])
GO

ALTER TABLE [dbo].[BISTA_Details] NOCHECK CONSTRAINT [FK_BISTA_Details_BISTA_TOTALS]
GO
