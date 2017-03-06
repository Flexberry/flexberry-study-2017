/* скрипты создания БД*/
CREATE DATABASE task03_db;
GO
USE task03_db;
GO

CREATE TABLE objects
(
    Name nvarchar(100) NOT NULL,
    Address nvarchar(100) NOT NULL,
    agent nvarchar(100) NOT NULL,
    PRIMARY KEY (Name)
); 

CREATE TABLE buildings
(
    Address nvarchar(100) NOT NULL,
    District nvarchar(100) NOT NULL,
    PRIMARY KEY (Address)
)

CREATE TABLE sectors
(
    Number int NOT NULL,
    Insulation nvarchar(100) NOT NULL,
    MountType nvarchar(10) NOT NULL,
    Name nvarchar(100) NOT NULL REFERENCES objects(Name),
    PRIMARY KEY (Number),
); 
/* */
/* заполнить базу скриптами */
/* Объекты */ 
INSERT INTO objects
VALUES ('Больница','Глинки 4', 'ТеплоСнаб');

INSERT INTO objects
VALUES ('Больница №2','Глинки 4', 'ТеплоСнаб');

INSERT INTO objects
VALUES ('Дом','Ленина 74', 'ТеплоКомплект');

INSERT INTO objects
VALUES ('Завод','Леонова 64', 'ТеплоПрофи');

INSERT INTO objects
VALUES ('Зоопарк','Ленина 12', 'ТеплоПрофи');

INSERT INTO objects
VALUES ('Отель','Свиязева 32', 'ТеплоПрофи');

INSERT INTO objects
VALUES ('Пив Завод','Леонова 3', 'ТеплоПрофи');

INSERT INTO objects
VALUES ('Школа №1','Пушкина 64', 'ТеплоКомплект');

INSERT INTO objects
VALUES ('Школа №2','Пушкина 2', 'ТеплоКомплект');
/* Объекты */ 

/* Здания */
INSERT INTO buildings
VALUES ('Пушкина 64','Свердловский');

INSERT INTO buildings
VALUES ('Пушкина 2','Свердловский');

INSERT INTO buildings
VALUES ('Ленина 12','Ленинский');

INSERT INTO buildings
VALUES ('Ленина 74','Ленинский');

INSERT INTO buildings
VALUES ('Леонова 64','Индустриальный');

INSERT INTO buildings
VALUES ('Леонова 3','Индустриальный');

INSERT INTO buildings
VALUES ('Свиязева 32','Индустриальный');

INSERT INTO buildings
VALUES ('Глинки 4','Индустриальный');
/* Здания */

/* Участки */
INSERT INTO sectors
VALUES ('4','Керамзит','Наружный','Отель');

INSERT INTO sectors
VALUES ('8','Керамзит','Наружный','Отель');

INSERT INTO sectors
VALUES ('1','Минеральная вата','Наружный','Дом');

INSERT INTO sectors
VALUES ('5','Пенопласт','Внутренний','Больница');

INSERT INTO sectors
VALUES ('10','Пенопласт','Внутренний','Больница');

INSERT INTO sectors
VALUES ('6','Стекловата','Внутренний','Больница');

INSERT INTO sectors
VALUES ('7','Стекловата','Внутренний','Завод');

INSERT INTO sectors
VALUES ('2','Стекловата','Внутренний','Завод');

INSERT INTO sectors
VALUES ('3','Стекловата','Наружный','Завод');

INSERT INTO sectors
VALUES ('9','Стекловата','Внутренний','Завод');

INSERT INTO sectors
VALUES ('11','Стекловата','Внутренний','Зоопарк');

INSERT INTO sectors
VALUES ('12','Стекловата','Внутренний','Школа №1');

INSERT INTO sectors
VALUES ('13','Пенопласт','Внутренний','Завод');

INSERT INTO sectors
VALUES ('14','Пенопласт','Внутренний','Зоопарк');
/* Участки */
/*  end ввод данных  */ 

ALTER TABLE objects
  ADD FOREIGN KEY (Address) REFERENCES buildings (Address);
