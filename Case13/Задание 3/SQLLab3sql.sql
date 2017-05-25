-- -----------------------------------------------------
-- Table userBase
-- -----------------------------------------------------
CREATE TABLE userBase (
  id int IDENTITY(1,1) PRIMARY KEY,
  login VARCHAR(45) NULL,
  password VARCHAR(45) NULL)

  alter table userBase  add constraint con_userBase_password unique (password)


-- -----------------------------------------------------
-- Table profile
-- -----------------------------------------------------
CREATE TABLE profile (
  id int IDENTITY(1,1),
  User_id INT NOT NULL,
  login VARCHAR(45) NULL,
  mail VARCHAR(45) NULL,
  surname VARCHAR(45) NULL,
  name VARCHAR(45) NULL,
  patronymic VARCHAR(45) NULL,
  gender VARCHAR(1) NULL,
  birthday DATE NULL,
  sity VARCHAR(45) NULL,
  country VARCHAR(45) NULL,
  website VARCHAR(45) NULL,
  network VARCHAR(45) NULL,
  networkkey VARCHAR(45) NULL,
  PRIMARY KEY (id, User_id),
  INDEX fk_Profile_User_idx (User_id ASC),
  CONSTRAINT fk_Profile_User
    FOREIGN KEY (User_id)
    REFERENCES userBase (id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table mydb.Contact
-- -----------------------------------------------------
CREATE TABLE contact (
  User_id1 INT NOT NULL,
  User_id2 INT NOT NULL,
  PRIMARY KEY (User_id1, User_id2),
  INDEX fk_Contact_User2_idx (User_id2 ASC),
  CONSTRAINT fk_Contact_User1
    FOREIGN KEY (User_id1)
    REFERENCES userBase (id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Contact_User2
    FOREIGN KEY (User_id2)
    REFERENCES userBase (id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

alter table Contact add constraint con_network_web unique (User_id1, User_id2)

  -- -----------------------------------------------------
-- Table mydb.network
-- -----------------------------------------------------
CREATE TABLE network (
  id int IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(45) NULL,
  website VARCHAR(45) NULL);

alter table network add constraint con_network_website unique (name, website)


INSERT INTO userBase
VALUES 
( 'login1', 'mail1'),
( 'login2', 'mail2'),
( 'login3', 'mail3'),
( 'login4', 'mail4'),
( 'login5', 'mail5');

INSERT INTO profile
VALUES 
( 1, 'login4', 'mail4', 'surname4', '', 'patronymic4', 'f', '4.02.2004', 'sity4', 'country4', 'website4', '1', '142435345'),
( 1, 'login5', 'mail5', 'surname5', 'name5', 'patronymic5', 'm', '5.02.2005', 'sity5', 'country5', 'website5', '2', '14242345'),
( 2, 'login1', 'mail1', 'surname1', 'name1', 'patronymic1', 'm', '12.12.2000', 'sity1', 'country1', 'website1', '0', '14235345'),
( 3, 'login2', 'mail2', 'surname2', 'name2', '', 'f', '2.02.2002', 'sity2', 'country2', 'website2', '1', '14233532345'),
( 2, 'login4', 'mail2', 'surname2', 'name2', '', 'f', '2.05.2002', 'sity2', 'country2', 'website2', '2', '14125345');

INSERT INTO contact
VALUES 
('1', '2'),
('1', '3'),
('2', '1'),
('3', '2');

INSERT INTO network
VALUES 
( 'vk', 'kv.com'),
( 'facebook', 'footbook.com'),
( 'google', 'gugle.com');

/*
1)  Declare @n as int = 1
	SELECT Top(@n) User_id1, COUNT(User_id1) From dbo.contact  GROUP BY User_id1 

2)  SELECT TOP 1  surname, COUNT(surname) count  From dbo.profile GROUP BY surname Order By count DESC

3)  Select  dbo.userBase.id, dbo.profile.name, DATEPART(YEAR, birthday), gender, Count(*) as profile_count  FROM dbo.userBase 
	INNER JOIN dbo.profile
    ON dbo.userBase.id=dbo.profile.User_id	
	group by dbo.userBase.id, dbo.profile.name, DATEPART(YEAR, birthday), gender
	ORDER BY profile_count DESC

4)  Declare 
		@contact_count real,
		@user_count real
	SELECT @contact_count=Count(user_ID1) From dbo.contact
	SELECT @user_count=Count(id) From dbo.userBase
	PRINT @contact_count/@user_count

5)	Declare 
		@percon_count INT
	SELECT  @percon_count = COUNT(gender) From dbo.profile
	SELECT  COUNT(gender)*100/@percon_count From dbo.profile  Where gender='m' GROUP BY gender	
	SELECT  COUNT(gender)*100/@percon_count From dbo.profile  Where gender='f' GROUP BY gender
	*/