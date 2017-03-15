USE [task3]
GO

/****** Object:  Table [dbo].[choice]    Script Date: 03/14/2017 23:15:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[choice](
	[stud_id] [int] NOT NULL,
	[mod_id] [int] NOT NULL,
	[sem_id] [int] NOT NULL,
	[priority_num] [int] NOT NULL,
 CONSTRAINT [Stud_plan_PK] PRIMARY KEY CLUSTERED 
(
	[stud_id] ASC,
	[mod_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [One_sem_UK] UNIQUE NONCLUSTERED 
(
	[stud_id] ASC,
	[sem_id] ASC,
	[priority_num] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_plan] UNIQUE NONCLUSTERED 
(
	[stud_id] ASC,
	[mod_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[choice]  WITH CHECK ADD FOREIGN KEY([mod_id])
REFERENCES [dbo].[modules] ([mod_id])
GO

ALTER TABLE [dbo].[choice]  WITH CHECK ADD FOREIGN KEY([sem_id])
REFERENCES [dbo].[semesters] ([sem_id])
GO

ALTER TABLE [dbo].[choice]  WITH CHECK ADD FOREIGN KEY([sem_id])
REFERENCES [dbo].[semesters] ([sem_id])
GO

ALTER TABLE [dbo].[choice]  WITH CHECK ADD FOREIGN KEY([sem_id])
REFERENCES [dbo].[semesters] ([sem_id])
GO

ALTER TABLE [dbo].[choice]  WITH CHECK ADD FOREIGN KEY([stud_id])
REFERENCES [dbo].[students] ([stud_id])
GO

