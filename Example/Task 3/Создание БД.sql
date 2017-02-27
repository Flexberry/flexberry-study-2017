--
-- Скрипт сгенерирован Devart dbForge Studio for SQL Server, Версия 5.4.215.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/sql/studio
-- Дата скрипта: 22.02.2017 16:49:05
-- Версия сервера: 12.00.2269
-- Версия клиента: 
--



USE books
GO

IF DB_NAME() <> N'books' SET NOEXEC ON
GO

--
-- Создать таблицу [dbo].[tSubject]
--
PRINT (N'Создать таблицу [dbo].[tSubject]')
GO
CREATE TABLE dbo.tSubject (
  idSub int NOT NULL,
  nameS nvarchar(200) NOT NULL,
  PRIMARY KEY CLUSTERED (idSub)
)
ON [PRIMARY]
GO

--
-- Создать индекс [ind_6] для объекта типа таблица [dbo].[tSubject]
--
PRINT (N'Создать индекс [ind_6] для объекта типа таблица [dbo].[tSubject]')
GO
CREATE INDEX ind_6
  ON dbo.tSubject (idSub)
  ON [PRIMARY]
GO

--
-- Создать таблицу [dbo].[tStudent]
--
PRINT (N'Создать таблицу [dbo].[tStudent]')
GO
CREATE TABLE dbo.tStudent (
  idStud int NOT NULL,
  FIO nvarchar(300) NOT NULL,
  idGroup int NOT NULL,
  PRIMARY KEY CLUSTERED (idStud)
)
ON [PRIMARY]
GO

--
-- Создать индекс [ind_5] для объекта типа таблица [dbo].[tStudent]
--
PRINT (N'Создать индекс [ind_5] для объекта типа таблица [dbo].[tStudent]')
GO
CREATE INDEX ind_5
  ON dbo.tStudent (idStud)
  ON [PRIMARY]
GO

--
-- Создать таблицу [dbo].[tProf]
--
PRINT (N'Создать таблицу [dbo].[tProf]')
GO
CREATE TABLE dbo.tProf (
  idProf int NOT NULL,
  nameP nvarchar(300) NOT NULL,
  PRIMARY KEY CLUSTERED (idProf)
)
ON [PRIMARY]
GO

--
-- Создать индекс [ind_4] для объекта типа таблица [dbo].[tProf]
--
PRINT (N'Создать индекс [ind_4] для объекта типа таблица [dbo].[tProf]')
GO
CREATE INDEX ind_4
  ON dbo.tProf (idProf)
  ON [PRIMARY]
GO

--
-- Создать таблицу [dbo].[tGroup]
--
PRINT (N'Создать таблицу [dbo].[tGroup]')
GO
CREATE TABLE dbo.tGroup (
  idGroup int NOT NULL,
  nameG nvarchar(50) NOT NULL,
  idFac int NOT NULL,
  PRIMARY KEY CLUSTERED (idGroup)
)
ON [PRIMARY]
GO

--
-- Создать индекс [ind_3] для объекта типа таблица [dbo].[tGroup]
--
PRINT (N'Создать индекс [ind_3] для объекта типа таблица [dbo].[tGroup]')
GO
CREATE INDEX ind_3
  ON dbo.tGroup (idGroup)
  ON [PRIMARY]
GO

--
-- Создать таблицу [dbo].[tBookZach]
--
PRINT (N'Создать таблицу [dbo].[tBookZach]')
GO
CREATE TABLE dbo.tBookZach (
  idBookZ int NOT NULL,
  idStud int NOT NULL,
  idSub int NOT NULL,
  idProf int NOT NULL,
  DateSd date NOT NULL,
  mark int NULL DEFAULT (2),
  PRIMARY KEY CLUSTERED (idBookZ),
  CHECK ([mark]>=(2) AND [mark]<=(5))
)
ON [PRIMARY]
GO

--
-- Создать индекс [ind_2] для объекта типа таблица [dbo].[tBookZach]
--
PRINT (N'Создать индекс [ind_2] для объекта типа таблица [dbo].[tBookZach]')
GO
CREATE INDEX ind_2
  ON dbo.tBookZach (idBookZ)
  ON [PRIMARY]
GO

--
-- Создать таблицу [dbo].[faculty]
--
PRINT (N'Создать таблицу [dbo].[faculty]')
GO
CREATE TABLE dbo.faculty (
  idFac int NOT NULL,
  nameF nvarchar(200) NOT NULL,
  PRIMARY KEY CLUSTERED (idFac)
)
ON [PRIMARY]
GO

--
-- Создать индекс [ind_1] для объекта типа таблица [dbo].[faculty]
--
PRINT (N'Создать индекс [ind_1] для объекта типа таблица [dbo].[faculty]')
GO
CREATE INDEX ind_1
  ON dbo.faculty (idFac)
  ON [PRIMARY]
GO
-- 
-- Вывод данных для таблицы faculty
--
INSERT dbo.faculty VALUES (1, N'ЭТФ')
INSERT dbo.faculty VALUES (2, N'ХТФ')
INSERT dbo.faculty VALUES (3, N'СФ')
INSERT dbo.faculty VALUES (4, N'АКФ')
INSERT dbo.faculty VALUES (5, N'МТФ')
GO
-- 
-- Вывод данных для таблицы tBookZach
--
INSERT dbo.tBookZach VALUES (1, 1, 1, 1, '2017-02-20', 2)
INSERT dbo.tBookZach VALUES (2, 2, 2, 2, '2017-02-15', 2)
INSERT dbo.tBookZach VALUES (3, 3, 3, 3, '2017-02-09', 2)
INSERT dbo.tBookZach VALUES (4, 4, 4, 4, '2017-02-01', 2)
INSERT dbo.tBookZach VALUES (5, 5, 5, 5, '2017-02-04', 2)
INSERT dbo.tBookZach VALUES (6, 2, 3, 3, '2016-02-02', 2)
INSERT dbo.tBookZach VALUES (7, 3, 4, 3, '2017-02-22', 2)
INSERT dbo.tBookZach VALUES (8, 4, 1, 1, '2017-02-22', 2)
INSERT dbo.tBookZach VALUES (9, 6, 1, 3, '2016-02-23', 2)
INSERT dbo.tBookZach VALUES (10, 2, 4, 4, '2017-02-22', 2)
INSERT dbo.tBookZach VALUES (11, 6, 4, 4, '2016-02-22', 2)
GO
-- 
-- Вывод данных для таблицы tGroup
--
INSERT dbo.tGroup VALUES (1, N'РИС', 1)
INSERT dbo.tGroup VALUES (2, N'АСУ', 1)
INSERT dbo.tGroup VALUES (3, N'АТП', 2)
INSERT dbo.tGroup VALUES (4, N'ТОК', 5)
INSERT dbo.tGroup VALUES (5, N'АД', 4)
GO
-- 
-- Вывод данных для таблицы tProf
--
INSERT dbo.tProf VALUES (1, N'Долгих ')
INSERT dbo.tProf VALUES (2, N'Перов')
INSERT dbo.tProf VALUES (3, N'Антонюк')
INSERT dbo.tProf VALUES (4, N'Козлов')
INSERT dbo.tProf VALUES (5, N'Кашпуренко')
GO
-- 
-- Вывод данных для таблицы tStudent
--
INSERT dbo.tStudent VALUES (1, N'Петров А.А.', 1)
INSERT dbo.tStudent VALUES (2, N'Сидоров А.В.', 3)
INSERT dbo.tStudent VALUES (3, N'Орлов С.С.', 5)
INSERT dbo.tStudent VALUES (4, N'Козлов А.В.', 4)
INSERT dbo.tStudent VALUES (5, N'Долгов М.М.', 4)
INSERT dbo.tStudent VALUES (6, N'Орлова Ю.Р.', 2)
GO
-- 
-- Вывод данных для таблицы tSubject
--
INSERT dbo.tSubject VALUES (1, N'Базы данных')
INSERT dbo.tSubject VALUES (2, N'Математика')
INSERT dbo.tSubject VALUES (3, N'Русский язык')
INSERT dbo.tSubject VALUES (4, N'ООП')
INSERT dbo.tSubject VALUES (5, N'Методы программирования')
GO

USE books
GO

IF DB_NAME() <> N'books' SET NOEXEC ON
GO

--
-- Создать внешний ключ для объекта типа таблица [dbo].[tGroup]
--
PRINT (N'Создать внешний ключ для объекта типа таблица [dbo].[tGroup]')
GO
ALTER TABLE dbo.tGroup
  ADD FOREIGN KEY (idFac) REFERENCES dbo.faculty (idFac)
GO

--
-- Создать внешний ключ для объекта типа таблица [dbo].[tStudent]
--
PRINT (N'Создать внешний ключ для объекта типа таблица [dbo].[tStudent]')
GO
ALTER TABLE dbo.tStudent
  ADD FOREIGN KEY (idGroup) REFERENCES dbo.tGroup (idGroup)
GO

--
-- Создать внешний ключ для объекта типа таблица [dbo].[tBookZach]
--
PRINT (N'Создать внешний ключ для объекта типа таблица [dbo].[tBookZach]')
GO
ALTER TABLE dbo.tBookZach
  ADD FOREIGN KEY (idProf) REFERENCES dbo.tProf (idProf)
GO

--
-- Создать внешний ключ для объекта типа таблица [dbo].[tBookZach]
--
PRINT (N'Создать внешний ключ для объекта типа таблица [dbo].[tBookZach]')
GO
ALTER TABLE dbo.tBookZach
  ADD FOREIGN KEY (idStud) REFERENCES dbo.tStudent (idStud)
GO

--
-- Создать внешний ключ для объекта типа таблица [dbo].[tBookZach]
--
PRINT (N'Создать внешний ключ для объекта типа таблица [dbo].[tBookZach]')
GO
ALTER TABLE dbo.tBookZach
  ADD FOREIGN KEY (idSub) REFERENCES dbo.tSubject (idSub)
GO
SET NOEXEC OFF
GO