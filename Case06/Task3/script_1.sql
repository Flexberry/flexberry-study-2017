/*Вывести список студентов, которые выбрали первым приоритетом указанную организацию.*/

SELECT s.*, o.name, ch.priority_num as 'Приоритет'
  FROM [task3].[dbo].[students] as s 
  JOIN [task3].[dbo].[choice] as ch on s.stud_id=ch.stud_id 
  JOIN [task3].[dbo].[modules]as m  on  ch.mod_id=m.mod_id 
  JOIN [task3].[dbo].[organizations]as o  on  m.org_id=o.org_id 
  WHERE 
			o.name = 'ИНТУИТ'
		AND
			ch.priority_num = 1
GO


