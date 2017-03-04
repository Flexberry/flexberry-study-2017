/* 1. Вывести список сетевых районов, 
отсортированный по количеству объектов теплопотребления в них.*/
SELECT District, COUNT (objects.Name) AS NumberofObjects
FROM buildings
INNER JOIN objects ON objects.Address = buildings.Address
GROUP BY District
ORDER BY NumberofObjects;
/* */

/* 2. Вывести топ N объектов теплопотребления 
    с наибольшим количеством участков сети.*/
SELECT TOP 3 objects.Name, COUNT (sectors.Name) AS Namesectors
FROM objects
INNER JOIN sectors ON sectors.Name = objects.Name 
GROUP BY objects.Name
ORDER BY Namesectors DESC;
/* */

/* 3. Вывести потребителей (контрагентов), 
    у объектов которых больше всего ВНУТРЕННИХ участков сети.*/
SELECT objects.Name
FROM objects
INNER JOIN sectors ON sectors.Name = objects.Name 
WHERE sectors.MountType = 'Внутренний' 
GROUP BY objects.Name
HAVING COUNT( sectors.Number ) = (
    SELECT TOP 1 COUNT(sectors.Number) AS numberOfsectors
    FROM objects
    INNER JOIN sectors ON sectors.Name = objects.Name 
    WHERE sectors.MountType = 'Внутренний'
    GROUP BY objects.Name
    ORDER BY numberOfsectors DESC
    );
/* */

/* 4. Вывести рейтинг типов изоляций участков 
    сети по сетевым районам.*/
SELECT sectors.Insulation, COUNT (DISTINCT buildings.District) AS NumberofDistrict
FROM sectors
INNER JOIN objects ON objects.Name = sectors.Name 
INNER JOIN buildings ON objects.Address = buildings.Address 
GROUP BY Insulation
ORDER BY NumberofDistrict DESC;
/* */

/* 5. Вывести информацию о 5 зданиях, в которых больше всего
 объектов теплопотребления с наружными участками сети.*/
SELECT TOP 5 buildings.Address, COUNT (objects.Name ) AS Numberofobjects
FROM buildings
INNER JOIN objects ON objects.Address = buildings.Address 
INNER JOIN sectors ON objects.Name = sectors.Name 
WHERE sectors.MountType = 'Наружный'
GROUP BY buildings.Address
ORDER BY Numberofobjects DESC;
/* */

/* бэкап БД 
BACKUP DATABASE task03_db  
TO DISK='D:\sourse\task03_db_BACKUP.bak';
/* */

/* Удалить таблицы
DROP TABLE buildings;
DROP TABLE sectors;
DROP TABLE objects;
/* */ 