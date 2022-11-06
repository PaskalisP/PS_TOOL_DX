USE [PS TOOL DX Live]
GO
/****** Object:  Table [dbo].[Events_Journal]    Script Date: 21.04.2022 23:42:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events_Journal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProcDate] [datetime] NULL,
	[Event] [nvarchar](max) NULL,
	[ProcName] [nvarchar](255) NULL,
	[SystemName] [nchar](255) NULL,
	[SystemUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_EVENTS_JOURNAL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
