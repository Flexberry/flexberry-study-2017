-- -----------------------------------------------------
-- Table userBase
-- -----------------------------------------------------
CREATE TABLE userBase (
  id int IDENTITY(1,1) PRIMARY KEY,
  login VARCHAR(45) NULL,
  password VARCHAR(45) NULL)

  alter table userBase  add constraint con_userBase_password unique (password)

-- -----------------------------------------------------
-- Table network
-- -----------------------------------------------------
CREATE TABLE network (
  id int IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(45) NULL,
  website VARCHAR(45) NULL)

  alter table network  add constraint con_network_website unique (name, website)

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
  network_idnetwork INT NOT NULL,
  PRIMARY KEY (id, User_id, Network_idnetwork),
  INDEX fk_Profile_User_idx (User_id ASC),
  INDEX fk_Profile_Network1_idx (Network_idnetwork ASC),
  CONSTRAINT fk_Profile_User
    FOREIGN KEY (User_id)
    REFERENCES userBase (id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Profile_Network1
    FOREIGN KEY (Network_idnetwork)
    REFERENCES network (id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- -----------------------------------------------------
-- Table contact
-- -----------------------------------------------------
CREATE TABLE contact (
  User_id1 INT NOT NULL,
  User_id2 INT NOT NULL,  
  contactName VARCHAR(45) NULL,
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
-- Table conractNetwork
-- -----------------------------------------------------
CREATE TABLE ConractNetwork (
  Contact_User_id1 INT NOT NULL,
  Contact_User_id2 INT NOT NULL,
  Network_idnetwork INT NOT NULL,
  PRIMARY KEY (Contact_User_id1, Contact_User_id2, Network_idnetwork),
  INDEX fk_ConractNetwork_Network1_idx (Network_idnetwork ASC),
  CONSTRAINT fk_ConractNetwork_Contact1
    FOREIGN KEY (Contact_User_id1 , Contact_User_id2)
    REFERENCES contact (User_id1 , User_id2)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_ConractNetwork_Network1
    FOREIGN KEY (Network_idnetwork)
    REFERENCES network (id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)

INSERT INTO userBase
VALUES 
( 'login1', 'mail1'),
( 'login2', 'mail2'),
( 'login3', 'mail3'),
( 'login4', 'mail4'),
( 'login5', 'mail5');

INSERT INTO network
VALUES 
( 'vk', 'kv.com'),
( 'facebook', 'footbook.com'),
( 'google', 'gugle.com');

INSERT INTO profile
VALUES 
( 1, 'login4', 'mail4', 'surname4', 'name1', 'patronymic4', 'f', '4.02.2004', 'sity4', 'country4', 'website4', 1),
( 1, 'login5', 'mail5', 'surname5', 'name5', 'patronymic5', 'm', '5.02.2005', 'sity5', 'country5', 'website5', 2),
( 2, 'login1', 'mail1', 'surname1', 'name1', 'patronymic1', 'm', '12.12.2000', 'sity1', 'country1', 'website1', 1),
( 3, 'login2', 'mail2', 'surname2', 'name2', '', 'f', '2.02.2002', 'sity2', 'country2', 'website2', 2),
( 2, 'login4', 'mail2', 'surname2', 'name2', '', 'f', '2.05.2002', 'sity2', 'country2', 'website2',  3);

INSERT INTO contact
VALUES 
('1', '2', 'Áðàò'),
('1', '3', ''),
('2', '1', 'ßøà'),
('3', '2', ''),
('3', '1', '');

INSERT INTO ConractNetwork
VALUES 
('1', '2', 1),
('1', '3', 2),
('2', '1', 1),
('3', '2', 2),
('3', '1', 2);


/*
1)  Declare @n as int = 1
	SELECT Top(@n) User_id1, COUNT(User_id1) From dbo.contact  GROUP BY User_id1 

2)  SELECT TOP 1  surname, COUNT(surname) count  From dbo.profile GROUP BY surname Order By count DESC

3)  Select  dbo.userBase.id, dbo.profile.name, DATEPART(YEAR, birthday) as userbirthday, gender, network.name, Count(*) as profile_count  FROM dbo.userBase 
	INNER JOIN dbo.profile
    ON dbo.userBase.id=dbo.profile.User_id	
	INNER JOIN dbo.network
    ON dbo.profile.network_idnetwork=dbo.network.id
	group by dbo.userBase.id, dbo.profile.name, DATEPART(YEAR, birthday), gender, network.name
	ORDER BY profile_count DESC, network.name, userbirthday

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