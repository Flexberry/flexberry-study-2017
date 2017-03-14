/***Для каждого студента вывести его знак зодиака***/
 
  SELECT s.fio as 'ФИО',s.birthday as 'Дата рождения', 'Знак зодиака'=
  case  
	when (DAY(birthday) between 21 and 31 and MONTH(birthday)= 3) 
	  OR (DAY(birthday) between 1 and 20 and MONTH(birthday) = 4) then 'Овен'
	when (DAY(birthday) between 23 and 31 and MONTH(birthday)= 7) 
	  OR (DAY(birthday) between 1 and 23 and MONTH(birthday) = 8) then 'Лев'
	when (DAY(birthday) between 23 and 30 and MONTH(birthday)= 11) 
	  OR (DAY(birthday) between 1 and 21 and MONTH(birthday) = 12) then 'Стрелец'
	when (DAY(birthday) between 21 and 30 and MONTH(birthday)= 4) 
	  OR (DAY(birthday) between 1 and 20 and MONTH(birthday) = 5) then 'Телец'
	when (DAY(birthday) between 24 and 31 and MONTH(birthday)= 8) 
	  OR (DAY(birthday) between 1 and 23 and MONTH(birthday) = 9) then 'Дева'
	when (DAY(birthday) between 22 and 31 and MONTH(birthday)= 12) 
	  OR (DAY(birthday) between 1 and 20 and MONTH(birthday) = 1) then 'Козерог'
	when (DAY(birthday) between 21 and 31 and MONTH(birthday)= 5) 
	  OR (DAY(birthday) between 1 and 21 and MONTH(birthday) = 6) then 'Близнецы'
	when (DAY(birthday) between 24 and 30 and MONTH(birthday)= 9) 
	  OR (DAY(birthday) between 1 and 23 and MONTH(birthday) = 10) then 'Весы'
	when (DAY(birthday) between 21 and 31 and MONTH(birthday)= 1) 
	  OR (DAY(birthday) between 1 and 20 and MONTH(birthday) = 2) then 'Водолей'
	when (DAY(birthday) between 22 and 30 and MONTH(birthday)= 6) 
	  OR (DAY(birthday) between 1 and 22 and MONTH(birthday) = 7) then 'Рак'
	when (DAY(birthday) between 24 and 31 and MONTH(birthday)= 10) 
	  OR (DAY(birthday) between 1 and 22 and MONTH(birthday) = 11) then 'Скорпион'
	when (DAY(birthday) between 21 and 29 and MONTH(birthday)= 2) 
	  OR (DAY(birthday) between 1 and 20 and MONTH(birthday) = 3) then 'Рыбы'
	end
  FROM [task3].[dbo].[students] as s   
GO



