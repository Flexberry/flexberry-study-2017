--
--1. Вывести информацию о рабочих днях-исключениях, в которых длительность рабочего времени меньше 4 часов
--
SELECT SUM(DATEDIFF(HH,tWtS.upTime,tWTS.endTime)) AS sumHour,tED.startDate,tED.descDay FROM tWorkTimeSpans AS tWTS 
INNER JOIN tExceptionDay AS tED ON tWTS.idExcDay = tED.idExcDay
GROUP BY tED.idExcDay,tED.startDate,tED.descDay
HAVING SUM(DATEDIFF(HH,tWtS.upTime,tWTS.endTime)) < 4
--
--2. Вывести суммарное количество рабочих часов за указанный месяц.
--
USE DB_CALENDAR
GO

CREATE FUNCTION dbo.GetMonthWorkHours
(
	--Порядковый номер месяца
	@monthNumber int,
	--Год
	@yearNumber int
)
RETURNS int
AS
BEGIN
	declare @startDate DATETIME;
	set @startDate = CAST(CAST(1 AS nvarchar) + '-' +  CAST(@monthNumber AS nvarchar) + '-' + CAST(@yearNumber AS nvarchar) AS DATETIME);
	declare @lastMonthDate DATETIME;
	set @lastMonthDate = EOMONTH(@startDate);

	declare @idExcDay INT
	declare @sumHours INT
	declare @startDayDate DATETIME
	declare @endDate DATETIME
	declare @iterCount INT
	declare @iterTipe INT
	declare @inc INT
	declare @sumHoursMonth INT

	set @sumHoursMonth = 0

	declare @cursor cursor

	set @cursor = cursor scroll
	for
	select tWTS.idExcDay,SUM(DATEDIFF(HH,tWtS.upTime,tWTS.endTime)) as sumHour,tED.startDate,tED.endDate,tED.iterationCount,tED.iterationTipe,tED.inc from tWorkTimeSpans as tWTS 
	inner join tExceptionDay as tED on tWTS.idExcDay = tED.idExcDay
	group by tWTS.idExcDay,tED.startDate,tED.endDate,tED.iterationCount,tED.iterationTipe,tED.inc
	
	open @cursor

	fetch next from @cursor into @idExcDay,@sumHours,@startDayDate,@endDate,@iterCount,@iterTipe,@inc
	while @@FETCH_STATUS = 0
	begin
		declare @tempDate datetime;
		set @tempDate = @startDayDate;
		if (@endDate is null) begin
			declare @i INT
			set @i = 1
			while (@i <= @iterCount) 
			begin
				if (@tempDate >= @startDate) and (@tempDate <= @lastMonthDate) begin
					set @sumHoursMonth = @sumHoursMonth + @sumHours;
				end
				set @i = @i + 1;
				set @tempDate = 
				case @iterTipe
					when 1 then DATEADD(d,@inc,@tempDate)
					when 2 then DATEADD(d,@inc*7,@tempDate)
					when 3 then DATEADD(m,@inc,@tempDate)
					when 4 then DATEADD(YY,@inc,@tempDate)
				end
			end
		end
		else begin
			while (@tempDate <= @lastMonthDate) 
			begin
				if (@tempDate >= @startDate)
					set @sumHoursMonth = @sumHoursMonth + @sumHours;
				set @tempDate = 
				case @iterTipe
					when 1 then DATEADD(d,@inc,@tempDate)
					when 2 then DATEADD(d,@inc*7,@tempDate)
					when 3 then DATEADD(m,@inc,@tempDate)
					when 4 then DATEADD(YY,@inc,@tempDate)
				end
			end
		end
		fetch next from @cursor into @idExcDay,@sumHours,@startDayDate,@endDate,@iterCount,@iterTipe,@inc
	end
	close @cursor
	RETURN @sumHoursMonth;
END
GO
--
--C помощью данной функции можно получать общее количество часов в месяце, указывая при этом порядковый номер месяца (1..12) и его год
--Например SELECT getMonthWorkHours(месяц, год)
--
--
--3. Написать хранимую функцию, по переданному первичному ключу повторяющегося дня-исключения и дате определяющую, соответствует ли данный день-исключение переданной дате (с учетом повторения).
--
CREATE FUNCTION [dbo].[CheckDay]
(
	@idExcDay int,
	@checkDayDate datetime
)
RETURNS bit
AS
BEGIN
	declare @startDayDate DATETIME
	declare @endDate DATETIME
	declare @iterCount INT
	declare @iterTipe INT
	declare @inc INT
	declare @check bit

	set @check = 0

	select @startDayDate = tED.startDate,@endDate = tED.endDate,@iterCount = tED.iterationCount,@iterTipe = tED.iterationTipe,@inc = tED.inc from tExceptionDay as tED
	where tED.idExcDay = @idExcDay

	declare @tempDate datetime
	set @tempDate = @startDayDate
	if (@endDate is null) begin
		declare @i INT
		set @i = 1
		while (@i <= @iterCount) 
		begin
			if (@tempDate = @checkDayDate) begin
				set @check = 1
				break
			end
			set @i = @i + 1
			set @tempDate = 
			case @iterTipe
				when 1 then DATEADD(d,@inc,@tempDate)
				when 2 then DATEADD(d,@inc*7,@tempDate)
				when 3 then DATEADD(m,@inc,@tempDate)
				when 4 then DATEADD(YY,@inc,@tempDate)
			end
		end
	end
	else if (@iterCount is not null) begin
		while (@tempDate <= @endDate) 
		begin
			if (@tempDate = @checkDayDate) begin
				set @check = 1
				break
			end
			set @tempDate = 
			case @iterTipe
				when 1 then DATEADD(d,@inc,@tempDate)
				when 2 then DATEADD(d,@inc*7,@tempDate)
				when 3 then DATEADD(m,@inc,@tempDate)
				when 4 then DATEADD(YY,@inc,@tempDate)
			end
		end
	end

	RETURN @check
END
GO
--
--4. На основе функции из пункта 3 написать запрос, вычисляющий количество дней-исключений в указанный месяц.
--
--Функция проверяет встречается ли день с указанным ID в указанный месяц
CREATE FUNCTION [dbo].[CheckMonth]
(
	@idExcDay INT,
	@month INT
)
RETURNS int
AS
BEGIN
	declare @startDayDate DATETIME
	declare @endDate DATETIME
	declare @iterCount INT
	declare @iterTipe INT
	declare @inc INT
	declare @check int

	set @check = 0

	select @startDayDate = tED.startDate,@endDate = tED.endDate,@iterCount = tED.iterationCount,@iterTipe = tED.iterationTipe,@inc = tED.inc from tExceptionDay as tED
	where tED.idExcDay = @idExcDay

	declare @tempDate DATETIME
	set @tempDate = @startDayDate
	if (@endDate is null) begin
		declare @i INT
		set @i = 1
		while (@i <= @iterCount) 
		begin
			if (DATEPART(MM,@tempDate) = @month) begin
				set @check = 1
				break
			end
			set @i = @i + 1
			set @tempDate = 
			case @iterTipe
				when 1 then DATEADD(d,@inc,@tempDate)
				when 2 then DATEADD(d,@inc*7,@tempDate)
				when 3 then DATEADD(m,@inc,@tempDate)
				when 4 then DATEADD(YY,@inc,@tempDate)
			end
		end
	end
	else if (@iterCount is not null) begin
		while (@tempDate <= @endDate) 
		begin
			if (DATEPART(MM,@tempDate) = @month) begin
				set @check = 1
				break
			end
			set @tempDate = 
			case @iterTipe
				when 1 then DATEADD(d,@inc,@tempDate)
				when 2 then DATEADD(d,@inc*7,@tempDate)
				when 3 then DATEADD(m,@inc,@tempDate)
				when 4 then DATEADD(YY,@inc,@tempDate)
			end
		end
	end

	RETURN @check
END
GO
--
--Функция вычисляет количество дней-исключений в указанный месяц
--
CREATE FUNCTION [dbo].[GetDaysCount]
(
	@month INT
)
RETURNS int
AS
BEGIN
	declare @dayCount INT
	select @dayCount = SUM(dbo.CheckMonth(tED.idExcDay,@month)) from tExceptionDay as tED
	RETURN @dayCount
END
GO