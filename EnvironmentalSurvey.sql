USE master
GO

DROP DATABASE IF EXISTS EnvironmentalSurvey
CREATE DATABASE EnvironmentalSurvey
GO

USE EnvironmentalSurvey
GO

CREATE TABLE AllPeople(
IdPerson NVARCHAR(250) PRIMARY KEY,
[NAME] NVARCHAR(100),
Img NVARCHAR(250),
DOB DATE,
Gender BIT,
Position NVARCHAR(50),
Class NVARCHAR(50)
)
GO 

CREATE TABLE Account(
Id INT  PRIMARY KEY IDENTITY,
UserName NVARCHAR(50),
Email NVARCHAR(100) Unique,
[Password] NVARCHAR(250),
Img NVARCHAR(250),
IdPeople NVARCHAR(250) CONSTRAINT FK_Account_AllPeople FOREIGN KEY(IdPeople) REFERENCES AllPeople(IdPerson),
Class NVARCHAR(50),
[Date] DATE,
[Role] NVARCHAR(50),
[Status] BIT Default 0,
Active BIT Default 0
)
GO



CREATE TABLE Survey(
Id INT IDENTITY PRIMARY KEY,
[NAME] NVARCHAR(50),
[Description] NVARCHAR(500),
Updated DATE,
[Status] BIT
)
GO

CREATE TABLE Question(
Id INT IDENTITY PRIMARY KEY,
Question NVARCHAR(250),
Updated DATE,
[Status] BIT
)
GO

CREATE TABLE QuestionSurvey
(
IdQuestion INT CONSTRAINT FK_QS_Question FOREIGN KEY(IdQuestion) REFERENCES Question(Id),
IdSurvey INT CONSTRAINT FK_QS_Survey FOREIGN KEY(IdSurvey) REFERENCES Survey(Id),
Updated DATE,
[Status] BIT,
PRIMARY KEY(IdQuestion,IdSurvey)
)
GO

CREATE TABLE Answer(
Id INT IDENTITY PRIMARY KEY,
IdQuestion INT CONSTRAINT FK_Answer_Question FOREIGN KEY(IdQuestion) REFERENCES Question(Id),
Answer NVARCHAR(250),
Updated DATE,
[Status] BIT
)
GO



CREATE TABLE Score(
IdAcc INT CONSTRAINT FK_Score_Account FOREIGN KEY(IdAcc) REFERENCES Account(Id),
IdSurvey INT CONSTRAINT FK_Score_Survey FOREIGN KEY(IdSurvey) REFERENCES Survey(Id),
Score INT,
[Status] BIT,
PRIMARY KEY(IdAcc, IdSurvey)
)
GO


CREATE TABLE Topic(
Id INT IDENTITY PRIMARY KEY,
Topic NVARCHAR(50),
[Status] BIT
)
GO
CREATE TABLE Seminar(
Id INT IDENTITY PRIMARY KEY,
IdTopic INT CONSTRAINT FK_Seminar_Topic FOREIGN KEY(IdTopic) REFERENCES Topic(Id),
Img NVARCHAR(250),
[Name] NVARCHAR(250),
Presenters NVARCHAR(250) CONSTRAINT FK_Seminar_AllPeople FOREIGN KEY(Presenters) REFERENCES AllPeople(IdPerson),
TimeStart TIME,
TimeEnd TIME,
[Day] DATE,
Place NVARCHAR(50),
Maximum INT,
NumberOfParticipants INT,
[Descriptoin] NVARCHAR(500),
[Status] BIT
)
GO

CREATE TABLE Img(
Id INT IDENTITY PRIMARY KEY,
[Path] NVARCHAR(250),
IdSeminar INT CONSTRAINT FK_Img_Serminar FOREIGN KEY(IdSeminar) REFERENCES Seminar(Id)
)
GO

CREATE TABLE Performer(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(100),
Gender BIT,
DOB DATE,
Img NVARCHAR(250),
[Status] BIT
)
GO

CREATE TABLE RegisterSeminar(
IdAcc INT CONSTRAINT FK_RegisterSeminar_Account FOREIGN KEY(IdAcc) REFERENCES Account(Id),
IdSeminar INT CONSTRAINT FK_RegisterSeminar_Seminar FOREIGN KEY(IdSeminar) REFERENCES Seminar(Id),
[Status] BIT
PRIMARY KEY(IdAcc, IdSeminar)
)
GO
CREATE TABLE PerformenSeminar(
IdPerforment INT CONSTRAINT FK_PerformenSeminar_Performer FOREIGN KEY(IdPerforment) REFERENCES Performer(Id),
IdSeminar INT CONSTRAINT FK_PerformenSeminar_Seminar FOREIGN KEY(IdSeminar) REFERENCES Seminar(Id),
[Status] BIT,
PRIMARY KEY (IdPerforment, IdSeminar)
)
GO

CREATE TABLE FAQ
(
Id INT IDENTITY PRIMARY KEY,
Faq NVARCHAR(250),
AnSwer NVARCHAR(250)
)
GO

CREATE TABLE Comment
(
Id INT PRIMARY KEY identity,
Massage NVARCHAR(Max),
IdAcc INT CONSTRAINT FK_Comment_Account FOREIGN KEY(IdAcc) REFERENCES Account(Id)
)
GO
INSERT INTO AllPeople
VALUES ('people1', 'TL1', 'avatar1.jpg','2000-06-29',1,'sv','class1'),
('people2', 'TL2', 'avatar1.jpg','2000-06-29',1,'nv',null),
('people3', 'TL3', 'avatar1.jpg','2000-06-29',1,'gv',null),
('people4', 'TL4', 'avatar1.jpg','2000-06-29',0,'sv','class1'),
('people6', 'TL2', 'avatar1.jpg','2000-06-29',0,'sv','class2'),
('people7', 'TL3', 'avatar1.jpg','2000-06-29',1,'sv','class2'),
('people8', 'TL4', 'avatar1.jpg','2000-06-29',0,'sv','class3'),
('people9', 'TL2', 'avatar1.jpg','2000-06-29',1,'sv','class3'),
('people10', 'TL3', 'avatar1.jpg','2000-06-29',1,'sv','class4'),
('people11', 'TL4', 'avatar1.jpg','2000-06-29',0,'sv','class4'),
('people12', 'TL2', 'avatar1.jpg','2000-06-29',1,'sv','class5'),
('people13', 'TL3', 'avatar1.jpg','2000-06-29',0,'sv','class5'),
('people14', 'TL4', 'avatar1.jpg','2000-06-29',1,'sv','class6'),
('people15', 'TL2', 'avatar1.jpg','2000-06-29',0,'nv',null),
('people16', 'TL3', 'avatar1.jpg','2000-06-29',0,'gv',null);
GO

INSERT INTO Account
VALUES('account1','anh.ntq31@aptechlearning.edu.vn','$2b$10$c.p0fHnLthBS8wFAsxrZWOVKobGKfHk01.9A8jm0w4wcomG.T3d9C','avatar1.jpg','people1', 'class1', '2021-12-20','admin',1,1),
('account2','anh@gmail.com','$2b$10$c.p0fHnLthBS8wFAsxrZWOVKobGKfHk01.9A8jm0w4wcomG.T3d9C','avatar1.jpg','people2', 'class1', '2021-12-20','sv',1, 0),
('account3','nhathuy16122001@gmail.com','$2b$10$c.p0fHnLthBS8wFAsxrZWOVKobGKfHk01.9A8jm0w4wcomG.T3d9C','avatar1.jpg','people3', 'class1', '2021-12-20','gv',1, 1),
('account4','abc@gmail.com','$10$B6r6V.lsqB0Y334pI3cIsu16M7.DYsgPyVxihvdOXcnuQovkGJCcS','avatar1.jpg','people4', 'class1', '2021-12-20','sv',0, 1);
GO

INSERT INTO Topic
VALUES('Topic1',1),
('Topic3',1),
('Topic2',1),
('Topic4',1);
GO

INSERT INTO Seminar
VALUES (1,'seminar1.jpg','seminar 1','people1', '08:00:00', '09:00:00','2021-06-06','HCM',100,50,'seminar 1',1),
(1,'seminar1.jpg','seminar 1','people2', '08:00:00', '09:00:00','2021-07-06','HCM',100,50,'seminar 1',1),
(1,'seminar1.jpg','seminar 1','people1', '08:00:00', '09:00:00','2021-05-06','HCM',100,50,'seminar 1',1),
(1,'seminar1.jpg','seminar 1','people3', '08:00:00', '09:00:00','2021-06-06','HCM',100,50,'seminar 1',0),
(1,'seminar1.jpg','seminar 1','people1', '08:00:00', '09:00:00','2021-06-11','HCM',100,50,'seminar 1',1);
GO

INSERT INTO Question
VALUES('question1','2021-06-17',1),
('question2','2021-06-17',1),
('question3','2021-06-17',1),
('question4','2021-06-17',1);
GO

INSERT INTO Answer
VALUES(1,'answer1','2021-03-18',0),
(1,'answer1.2','2021-03-18',1),
(1,'answer1.3','2021-03-18',0),
(1,'answer1.4','2021-03-18',0),
(2,'answer2.1','2021-03-18',0),
(2,'answer2.2','2021-03-18',0),
(2,'answer2.3','2021-03-18',0);
GO

INSERT INTO FAQ
VALUES('How to register for the survey?','You can click on the survey link that will have the link appears you fill in the link and click register.'),
('How to participate in the survey?','You are a school student and are available at the school"s account, click on the link to fill in the information that can participate in the survey.'),
('Why I am unable to participate in the survey?','Your account is expected to be locked or does not activate the account.'),
('Why my registration request is not accepted?','Maybe you are no longer a school student or you have filled the wrong information when registering, please try again.'),
('Will there be any benefit if participated in the survey?','You will have more knowledge about environmental protection and can receive reward from the school when answering the right questions.'),
('How to participate in the competitions?','You participate in the Conference related to the contest.'),
('What if there are some arrears in participating the survey?','You can contact us via support section for detailed support.');
GO

INSERT INTO Survey
VALUES ('Survey1',null,'2021-06-19',1),
('Survey2','Survey2','2021-06-19',1),
('Survey3','Survey3','2021-06-19',1),
('Survey4',null,'2021-06-19',1),
('Survey5',null,'2021-06-19',0);
GO

INSERT INTO Score
VALUES(1,1,100,1),
(2,1,70,1),
(3,1,80,1),
(1,2,100,1),
(4,2,700,1),
(2,2,800,1),
(3,2,500,1)
GO

INSERT INTO Performer
VALUES('performer1',0,'2001-06-26','performer.jpg',1),
('performer2',1,'2001-06-27','performer.jpg',1),
('performer3',0,'2001-06-28','performer.jpg',1),
('performer4',0,'2001-06-29','performer.jpg',1),
('performer5',1,'2001-06-30','performer.jpg',1),
('performer6',1,'2001-06-25','performer.jpg',1),
('performer7',1,'2001-06-24','performer.jpg',1);
GO

INSERT INTO PerformenSeminar
VALUES(1,1,1),
(1,2,1),
(2,1,1),
(3,1,1),
(1,3,1),
(2,2,1),
(4,1,1);
GO
INSERT INTO Img
VALUES ('seminar1.jpg',1),
('seminar1.jpg',1),
('seminar1.jpg',1),
('seminar1.jpg',1),
('seminar1.jpg',2),
('seminar1.jpg',2),
('seminar1.jpg',3),
('seminar1.jpg',3),
('seminar1.jpg',3),
('seminar1.jpg',4),
('seminar1.jpg',4);
GO