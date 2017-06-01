USE [task3]
GO

/****** Object:  Table [dbo].[semesters]    Script Date: 03/14/2017 23:14:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[semesters](
	[sem_id] [int] NOT NULL,
	[date_begin] [date] NOT NULL,
	[date_end] [date] NOT NULL,
 CONSTRAINT [PK_semesters] PRIMARY KEY CLUSTERED 
(
	[sem_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

