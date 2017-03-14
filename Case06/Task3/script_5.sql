/*Для указанного студента вывести все его предпочтения по всем модулям.*/

SELECT s.fio as 'ФИО',m.name as 'Предпочитаемый модуль',o.name as 'Организация'
  FROM [task3].[dbo].[students] as s 
  JOIN [task3].[dbo].[choice] as ch on s.stud_id=ch.stud_id 
  JOIN [task3].[dbo].[modules]as m  on  ch.mod_id=m.mod_id 
  JOIN [task3].[dbo].[organizations]as o  on  m.org_id=o.org_id 
  WHERE s.fio = 'Студент 2' AND ch.priority_num = 1
GO

/*Для второго студента (данные по учебному плану заполнены только для студентов 1 и 2!)*/
SELECT s.fio as 'ФИО',m.name as 'Предпочитаемый модуль',o.name as 'Организация'
  FROM [task3].[dbo].[students] as s 
  JOIN [task3].[dbo].[choice] as ch on s.stud_id=ch.stud_id 
  JOIN [task3].[dbo].[modules]as m  on  ch.mod_id=m.mod_id 
  JOIN [task3].[dbo].[organizations]as o  on  m.org_id=o.org_id 
  WHERE s.fio = 'Студент 1' AND ch.priority_num = 1
GO