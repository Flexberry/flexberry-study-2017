/*На указанную дату вывести перечень образовательных организаций, 
		с которыми есть действующий договор.*/
		
SELECT o.*, cast(year(CURRENT_TIMESTAMP) as varchar)+'-'+cast(month(CURRENT_TIMESTAMP) as varchar)+'-'+cast(day(CURRENT_TIMESTAMP) as varchar)as 'Текущая дата', 'Статус' = 
CASE
  when DATEDIFF(DAY,CURRENT_TIMESTAMP,date_end)<0 then 'Договор недействителен!' 
  when DATEDIFF(DAY,CURRENT_TIMESTAMP,date_end)>=0 then 'Договор действителен'
  end 

FROM [task3].[dbo].[organizations]as o
GO

/*Ниже вариант точно по заданию*/
SELECT o.*, cast(year(CURRENT_TIMESTAMP) as varchar)+'-'+cast(month(CURRENT_TIMESTAMP) as varchar)+'-'+cast(day(CURRENT_TIMESTAMP) as varchar)as 'Текущая дата'
FROM [task3].[dbo].[organizations]as o
WHERE DATEDIFF(DAY,CURRENT_TIMESTAMP,date_end)>=0 

GO