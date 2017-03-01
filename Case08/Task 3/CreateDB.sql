CREATE DATABASE DB_CALENDAR
GO

USE DB_CALENDAR
GO

PRINT (N'создать таблицу tExceptionDay')
GO
CREATE TABLE dbo.tExceptionDay(
	idExcDay INT NOT NULL,
	startDate DATETIME NOT NULL,
	endDate DATETIME,
	iterationTipe INT NOT NULL,
	inc INT NOT NULL,
	iterationCount INT,
	descDay NVARCHAR(300),
	PRIMARY KEY CLUSTERED (idExcDay)
)
GO

PRINT (N'Создать индекс [int_1] для объекта типа таблица [dbo].[tExceptionDay]')
GO
CREATE INDEX ind_1
	ON dbo.tExceptionDay (idExcDay)
	ON [PRIMARY]
GO

PRINT (N'Создать таблицу [dbo].[tWorkTimeSpans]')
GO
CREATE TABLE dbo.tWorkTimeSpans (
	idWTS INT NOT NULL,
	upTime TIME(0) NOT NULL,
	endTime TIME(0) NOT NULL,
	idExcDay INT NOT NULL,
	PRIMARY KEY CLUSTERED (idWTS)
)
GO

PRINT (N'Создать индекс [ind_2] для объекта типа таблица [dbo].[tWorkTimeSpans]')
GO
CREATE INDEX ind_2
	ON dbo.tWorkTimeSpans (idWTS)
	ON [PRIMARY]
GO

PRINT (N'Создать внешний ключ для объекта типа таблица [dbo].[tWorkTimeSpans]')
GO
ALTER TABLE dbo.tWorkTimeSpans 
	ADD FOREIGN KEY (idExcDay) REFERENCES dbo.tExceptionDay (idExcDay)
GO

--
-- Ввод данных для таблицы tExceptionDay
--

INSERT INTO tExceptionDay VALUES (1,'2017-01-01',null,4,1,10,'Новый год')
INSERT INTO tExceptionDay VALUES (2,'2017-07-01',null,4,1,10,'Рождество Христово')
INSERT INTO tExceptionDay VALUES (3,'2017-13-01',null,1,7,10,'сокращенный рабочий день')
INSERT INTO tExceptionDay VALUES (4,'2017-11-01',null,2,1,10,'удлинённый рабочий день')
INSERT INTO tExceptionDay VALUES (5,'2017-07-02','2017-28-02',2,1,null,'очень сокращенный день')
INSERT INTO tExceptionDay VALUES (6,'2017-23-02',null,4,1,10,'День защитника Отечества')
INSERT INTO tExceptionDay VALUES (7,'2017-08-03',null,4,1,10,'Международный женский день')
INSERT INTO tExceptionDay VALUES (8,'2017-01-05',null,4,1,10,'Праздник весны и труда')
INSERT INTO tExceptionDay VALUES (9,'2017-09-05',null,4,1,10,'День победы')
INSERT INTO tExceptionDay VALUES (10,'2017-12-06',null,1,1,10,'День России')
GO

INSERT INTO tWorkTimeSpans VALUES (1,'09:00:00','12:00:00',3)
INSERT INTO tWorkTimeSpans VALUES (2,'13:00:00','17:00:00',3)
INSERT INTO tWorkTimeSpans VALUES (3,'08:00:00','12:00:00',4)
INSERT INTO tWorkTimeSpans VALUES (4,'13:00:00','16:00:00',4)
INSERT INTO tWorkTimeSpans VALUES (5,'17:00:00','20:00:00',4)
INSERT INTO tWorkTimeSpans VALUES (6,'09:00:00','12:00:00',5)
GO