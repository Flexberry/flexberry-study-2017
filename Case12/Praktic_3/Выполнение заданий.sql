--1.Текущий рейтинг игроков в порядке убывания
SELECT * 
 FROM [PingPong].[dbo].[Player]
 ORDER BY [CurrentRating] DESC

--2.Последние N изменений рейтинга игрока
Declare @currentPlayer int;
set @currentPlayer =1;

SELECT Top 5 Player.PlayerFIO
	  ,Match.MatchTime
	  ,RatingHistory.RatingChanges
FROM Player
JOIN RatingHistory ON Player.PlayerID= RatingHistory.Player
JOIN Match ON RatingHistory.Match=Match.MatchID 
WHERE Player.PlayerID = @currentPlayer
ORDER BY Match.MatchTime DESC

--3.Последние N матчей игрока
Declare @selectedPlayer int;
set @selectedPlayer =8;

SELECT TOP 5 *
  FROM [PingPong].[dbo].[Match]
  where Match.Player_A = @selectedPlayer
	 or Match.Player_B=@selectedPlayer
  order by Match.MatchTime desc

--4.Последние N личных встреч между двумя игроками
DECLARE @playerA int;
SET @playerA = 3;
DECLARE @playerB int;
SET @playerB = 8;

SELECT TOP 10 *
FROM [PingPong].[dbo].[Match]
WHERE (Match.Player_A = @playerA and Match.Player_B = @playerB)
   or (Match.Player_A = @playerB and Match.Player_B = @playerA)
ORDER BY Match.MatchTime DESC

--5.Итоговая таблица турнира
Declare @tour int;
set @tour =5;

SELECT PlayerFIO, MAX(SCORE) as 'Wins count'
FROM Player
JOIN (
	SELECT DISTINCT Player AS pl,0 AS SCORE
	FROM Match
	JOIN RatingHistory ON Match.MatchID = RatingHistory.Match
	WHERE Match.Tournament = @tour
		and Match.IsRegistred='1'
UNION
	SELECT WinnerPlayer AS pl, COUNT(*) AS SCORE 
	FROM Match
	WHERE Match.Tournament= @tour
		and Match.IsRegistred='1'
	GROUP BY Match.WinnerPlayer
) AS list ON Player.PlayerID= list.pl
GROUP BY PlayerFIO
ORDER BY MAX(SCORE) DESC, Max(Player.CurrentRating) desc

--6.Все матчи турнира в хронологическом порядке
Declare @selectedTour int;
set @selectedTour =5;

SELECT *
FROM [PingPong].[dbo].[Match]
WHERE Match.Tournament = @selectedTour
ORDER BY Match.MatchTime asc