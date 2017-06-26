CREATE DATABASE PingPong
GO

USE PingPong
GO
--
--Создем таблицу Турниров
--
CREATE TABLE Tournament(
TournamentID int not null IDENTITY(1,1) primary key,
Name nvarchar(max) not null,
StartTime datetime not null,
FinishTime datetime not null
)
GO

Alter table Tournament
Add CONSTRAINT CC1
CHECK ([FinishTime] > [StartTime]);

--
--Создем таблицу Игроков
--
CREATE TABLE Player(
PlayerID int not null IDENTITY(1,1) primary key,
PlayerFIO nvarchar(300) not null,
CurrentRating int not null
)
GO
--
--Создем индекс для талицы Игроков
--
CREATE INDEX ind_Player
  ON dbo.Player (PlayerID)
  ON [PRIMARY]
GO
--
--Создем таблицу Матчей
--
CREATE TABLE Match(
MatchID int not null IDENTITY(1,1) primary key,
Player_A int not null REFERENCES Player(PlayerID), 
Player_B int not null REFERENCES Player(PlayerID), 
WinnerPlayer int null, 
IsRegistred bit not null default('1'),
IsLongGame bit not null default('0'),
RoundToWin int not null,
MatchTime datetime not null,
Tournament int null references Tournament(TournamentID),
)
GO
--
--Создем индекс для таблицы Матчей
--
CREATE INDEX ind_Match
  ON dbo.Match (MatchID)
  ON [PRIMARY]
GO
--
--Создем таблицу Раундов
--
create table MatchRound(
RoundID int not null IDENTITY(1,1) primary key,
MatchID int not null ,
RoundNumber int not null ,
Score_A int not null check (Score_A>-1),
Score_B int not null check (Score_B>-1)
FOREIGN KEY (MatchID) REFERENCES Match(MatchID)
)
GO
--
--Создем таблицу Истории изменения рейтингов
--
create table RatingHistory(
RatingID int not null IDENTITY(1,1) primary key,
Player int not null REFERENCES Player(PlayerID), 
Match int not null REFERENCES Match(MatchID),
RatingChanges int not null
)
GO
--
--Создем индекс для таблицы Истории изменения рейтингов
--
CREATE INDEX ind_History
  ON dbo.RatingHistory (RatingID)
  ON [PRIMARY]
GO

USE PingPong
GO
-- 
--Заполняем данными таблицу Турниров
--
insert into Tournament Values ('Турнир №1','2017.04.01 15:00:00','2017.04.15 15:00:00');
insert into Tournament Values ('Турнир №2','2017.06.01 15:00:00','2017.06.15 15:00:00');
insert into Tournament Values ('Турнир №3','2017.08.01 15:00:00','2017.08.15 15:00:00');
insert into Tournament Values ('Турнир №4','2017.10.01 15:00:00','2017.10.15 15:00:00');
insert into Tournament Values ('Турнир №5','2017.12.01 15:00:00','2017.12.25 15:00:00');
-- 
--Заполняем данными таблицу Игроков
--
insert into Player Values ('Игрок 1',1460);
insert into Player Values ('Игрок 2',1380);
insert into Player Values ('Игрок 3',1400);
insert into Player Values ('Игрок 4',1380);
insert into Player Values ('Игрок 5',1380);
insert into Player Values ('Игрок 6',1400);
insert into Player Values ('Игрок 7',1380);
insert into Player Values ('Игрок 8',1420);
-- 
--Заполняем данными таблицу Матчей
--
insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (1,2,1,1,0,3,'2017.12.04 17:45:00',5);
insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (3,4,3,1,0,3,'2017.12.05 18:45:00',5);
insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (5,6,6,1,0,3,'2017.12.06 19:15:00',5);
insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (7,8,8,1,0,3,'2017.12.07 20:15:00',5);

insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (1,3,1,1,0,3,'2017.12.11 15:30:00',5);
insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (6,8,8,1,0,3,'2017.12.11 19:30:00',5);

insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (1,8,1,1,0,3,'2017.12.15 17:00:00',5);

insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (3,8,8,0,0,3,'2017.06.15 17:00:00',null);
insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (3,8,3,0,0,3,'2017.06.18 17:00:00',null);

insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (2,5,5,0,0,3,'2017.06.05 17:00:00',2);
insert into [Match] ([Player_A],[Player_B],[WinnerPlayer],[IsRegistred],[IsLongGame],[RoundToWin],[MatchTime],[Tournament]) 
			Values (2,5,5,0,0,3,'2017.06.07 17:00:00',2);
-- 
--Заполняем данными таблицу Раундов
--
insert into [MatchRound] Values (1,1,11,8);
insert into [MatchRound] Values (1,2,11,6);
insert into [MatchRound] Values (1,3,10,12);
insert into [MatchRound] Values (1,4,9,11);
insert into [MatchRound] Values (1,5,12,10);

insert into [MatchRound] Values (2,1,11,6);
insert into [MatchRound] Values (2,2,11,5);
insert into [MatchRound] Values (2,3,11,8);

insert into [MatchRound] Values (3,1,3,11);
insert into [MatchRound] Values (3,2,7,11);
insert into [MatchRound] Values (3,3,4,11);

insert into [MatchRound] Values (4,1,7,11);
insert into [MatchRound] Values (4,2,11,9);
insert into [MatchRound] Values (4,3,11,8);
insert into [MatchRound] Values (4,4,10,12);
insert into [MatchRound] Values (4,5,10,12);

insert into [MatchRound] Values (5,1,9,11);
insert into [MatchRound] Values (5,2,11,9);
insert into [MatchRound] Values (5,3,11,5);
insert into [MatchRound] Values (5,4,11,6);

insert into [MatchRound] Values (6,1,3,11);
insert into [MatchRound] Values (6,2,2,11);
insert into [MatchRound] Values (6,3,4,11);

insert into [MatchRound] Values (7,1,11,9);
insert into [MatchRound] Values (7,2,12,10);
insert into [MatchRound] Values (7,3,10,12);
insert into [MatchRound] Values (7,4,9,11);
insert into [MatchRound] Values (7,5,12,10);

insert into [MatchRound] Values (10,1,7,11);
insert into [MatchRound] Values (11,2,6,11);
insert into [MatchRound] Values (11,3,5,11);
-- 
--Заполняем данными таблицу Истории изменения рейтингов
--
insert into [RatingHistory] values (1,1,20)
insert into [RatingHistory] values (2,1,-20)
insert into [RatingHistory] values (3,2,20)
insert into [RatingHistory] values (4,2,-20)
insert into [RatingHistory] values (6,3,20)
insert into [RatingHistory] values (5,3,-20)
insert into [RatingHistory] values (8,4,20)
insert into [RatingHistory] values (7,4,-20)

insert into [RatingHistory] values (1,5,20)
insert into [RatingHistory] values (3,5,-20)
insert into [RatingHistory] values (8,6,20)
insert into [RatingHistory] values (6,6,-20)

insert into [RatingHistory] values (1,7,20)
insert into [RatingHistory] values (8,7,-20)