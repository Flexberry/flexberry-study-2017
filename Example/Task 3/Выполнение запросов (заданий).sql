-- Вывести топ N самых плохо учащихся студентов
SELECT TOP 3 s.FIO FROM tBookZach bz INNER JOIN tStudent s ON bz.idStud = s.idStud WHERE bz.mark = 2

-- Вывести список преподавателей, которые ставят максимальное по количеству отличных оценок.
SELECT p.nameP FROM tBookZach bz INNER JOIN tProf p ON bz.idProf = p.idProf WHERE bz.mark = 5 GROUP BY p.nameP HAVING COUNT(bz.mark) = (SELECT TOP 1 COUNT(bz.mark) FROM tBookZach bz INNER JOIN tProf p ON bz.idProf = p.idProf WHERE bz.mark = 5 GROUP BY p.nameP ORDER BY COUNT(bz.mark) DESC)

-- Вывести предметы, по которым больше всего должников за указанный период.
SELECT s.nameS FROM tBookZach bz INNER JOIN tSubject s ON bz.idSub = s.idSub WHERE bz.mark = 2 AND bz.DateSd BETWEEN CAST('01.02.2017' AS DATE) AND CAST('28.02.2017' AS DATE) GROUP BY s.nameS HAVING COUNT(bz.mark) > 2

-- Вывести рейтинг факультетов по среднему баллу студентов.
SELECT f.nameF, AVG(bz.mark) AS sred FROM tStudent s INNER JOIN tBookZach bz ON bz.idStud = s.idStud INNER JOIN tGroup g ON s.idGroup = g.idGroup INNER JOIN faculty f ON g.idFac = f.idFac GROUP BY f.nameF ORDER BY sred DESC

-- Получить средний балл для каждого студента вуза по годам.
SELECT s.FIO, YEAR(bz.DateSd) AS god, AVG(bz.mark) AS sred FROM tStudent s INNER JOIN tBookZach bz ON bz.idStud = s.idStud INNER JOIN tGroup g ON s.idGroup = g.idGroup INNER JOIN faculty f ON g.idFac = f.idFac GROUP BY YEAR(bz.DateSd), s.FIO ORDER BY god DESC, s.FIO ASC

  