USE [task3]
GO

/****** Object:  Table [dbo].[modules]    Script Date: 03/14/2017 23:14:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[modules](
	[mod_id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[org_id] [int] NOT NULL,
	[sem_id] [int] NOT NULL,
 CONSTRAINT [PK_modules] PRIMARY KEY CLUSTERED 
(
	[mod_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[modules]  WITH CHECK ADD FOREIGN KEY([org_id])
REFERENCES [dbo].[organizations] ([org_id])
GO

ALTER TABLE [dbo].[modules]  WITH CHECK ADD FOREIGN KEY([sem_id])
REFERENCES [dbo].[semesters] ([sem_id])
GO

