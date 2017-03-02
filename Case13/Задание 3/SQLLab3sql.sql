-- -----------------------------------------------------
-- Table userBase
-- -----------------------------------------------------
CREATE TABLE userBase (
  id INT NOT NULL,
  login VARCHAR(45) NULL,
  mail VARCHAR(45) NULL,
  surname VARCHAR(45) NULL,
  name VARCHAR(45) NULL,
  patronymic VARCHAR(45) NULL,
  gender VARCHAR(45) NULL,
  birthday DATE NULL,
  sity VARCHAR(45) NULL,
  country VARCHAR(45) NULL,
  website VARCHAR(45) NULL,
  PRIMARY KEY (id));


-- -----------------------------------------------------
-- Table profile
-- -----------------------------------------------------
CREATE TABLE profile (
  id INT NOT NULL,
  login VARCHAR(45) NULL,
  mail VARCHAR(45) NULL,
  surname VARCHAR(45) NULL,
  name VARCHAR(45) NULL,
  patronymic VARCHAR(45) NULL,
  gender VARCHAR(45) NULL,
  birthday DATE NULL,
  sity VARCHAR(45) NULL,
  country VARCHAR(45) NULL,
  website VARCHAR(45) NULL,
  User_id INT NOT NULL,  
  idnetwork INT NOT NULL,
  PRIMARY KEY (id, User_id, idnetwork));


-- -----------------------------------------------------
-- Table mydb.Contact
-- -----------------------------------------------------
CREATE TABLE contact (
  UserId INT NOT NULL,
  ContactId VARCHAR(45) NOT NULL,
  PRIMARY KEY (UserId, ContactId ));

  -- -----------------------------------------------------
-- Table mydb.network
-- -----------------------------------------------------
CREATE TABLE network (
  idnetwork INT NOT NULL,
  name VARCHAR(45) NULL,
  website VARCHAR(45) NULL,
  PRIMARY KEY (idnetwork));


INSERT INTO userBase (id, login, mail, surname, name, patronymic, gender, birthday, sity, country, website)
VALUES 
('1', 'login1', 'mail1', 'surname1', 'name1', 'patronymic1', 'm', '12.12.2000', 'sity1', 'country1', 'website1'),
('2', 'login2', 'mail2', 'surname2', 'name2', 'patronymic2', 'f', '2.02.2002', 'sity2', 'country2', 'website2'),
('3', 'login3', 'mail3', 'surname3', 'name3', 'patronymic3', 'm', '3.02.2003', 'sity3', 'country3', 'website3'),
('4', 'login4', 'mail4', 'surname4', 'name4', 'patronymic4', 'f', '4.02.2004', 'sity4', 'country4', 'website4'),
('5', 'login5', 'mail5', 'surname5', 'name5', 'patronymic5', 'm', '5.02.2005', 'sity5', 'country5', 'website5');

INSERT INTO profile (id, login, mail, surname, name, patronymic, gender, birthday, sity, country, website, User_id, idnetwork)
VALUES 
('1', 'login1', 'mail1', 'surname1', 'name1', 'patronymic1', 'm', '12.12.2000', 'sity1', 'country1', 'website1', 1, 1),
('2', 'login2', 'mail2', 'surname2', 'name2', 'patronymic2', 'f', '2.02.2002', 'sity2', 'country2', 'website2', 2, 1),
('3', 'login3', '', 'surname3', 'name3', 'patronymic3', 'm', '3.02.2003', 'sity3', 'country3', 'website3', 3, 1),
('4', 'login4', 'mail4', 'surname4', '', 'patronymic4', 'f', '4.02.2004', 'sity4', 'country4', 'website4', 4, 1),
('5', 'login5', 'mail5', 'surname5', 'name5', 'patronymic5', 'm', '5.02.2005', 'sity5', 'country5', 'website5', 5, 1),
('6', 'login1', 'mail1', 'surname1', 'name1', 'patronymic1', 'm', '12.12.2000', 'sity1', 'country1', 'website1', 1, 2),
('7', 'login2', 'mail2', 'surname2', 'name2', '', 'f', '2.02.2002', 'sity2', 'country2', 'website2', 2, 3);

INSERT INTO profile (UserId, ContactId)
VALUES 
('1', '2'),
('1', '3'),
('2', '1'),
('3', '2');


1) SELECT userID, COUNT(userID) From dbo.contact GROUP BY userID

2) SELECT TOP 1 surname, COUNT(surname) From dbo.userBase GROUP BY surname 

3)

4) SELECT COUNT(userID)/COUNT(id) From dbo.contact, dbo.userBase

5)Declare 
	@male_count INT,
	@male_percent Real,
	@female_percent Real
SELECT @male_count=COUNT(gender) From dbo.userBase  Where gender='m' GROUP BY gender
SELECT @male_percent=@male_count*100/COUNT(id), @female_percent=(COUNT(id)-@male_count)*100/COUNT(id) From dbo.userBase
PRINT N'M:'+CAST(@male_percent AS VARCHAR(2))+N'%'
PRINT N'F:'+CAST(@female_percent AS VARCHAR(2))+N'%'