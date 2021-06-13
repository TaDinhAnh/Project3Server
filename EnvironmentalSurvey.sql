USE master
GO

DROP DATABASE IF EXISTS EnvironmentalSurvey
CREATE DATABASE EnvironmentalSurvey
GO

USE EnvironmentalSurvey
GO

CREATE TABLE Account(
Id INT IDENTITY PRIMARY KEY,
UserName NVARCHAR(50),
[Password] NVARCHAR(50),
IdPeople INT,
Class NVARCHAR(50),
[Date] DATE,
[Role] NVARCHAR(50),
[Status] BIT
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
Answer NVARCHAR(250),
Updated DATE,
[Status] BIT
)
GO

CREATE TABLE AnswerQuestion(
IdQuestion INT CONSTRAINT FK_AQ_Question FOREIGN KEY(IdQuestion) REFERENCES Question(Id),
IdAnswer INT CONSTRAINT FK_QS_Answer FOREIGN KEY(IdAnswer) REFERENCES Answer(Id),
[Status] BIT
PRIMARY KEY(IdQuestion, IdAnswer)
)
GO

CREATE TABLE Score(
IdAcc INT CONSTRAINT FK_Score_Account FOREIGN KEY(IdAcc) REFERENCES Account(Id),
IdSurvey INT CONSTRAINT FK_Score_Survey FOREIGN KEY(IdSurvey) REFERENCES Survey(Id),
Score INT,
[Status] BIT
)
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

CREATE TABLE Topic(
Id INT IDENTITY PRIMARY KEY,
Topic NVARCHAR(50),
[Status] BIT
)
CREATE TABLE Seminar(
Id INT IDENTITY PRIMARY KEY,
IdTopic INT CONSTRAINT FK_Seminar_Topic FOREIGN KEY(IdTopic) REFERENCES Topic(Id),
Img NVARCHAR(250),
[Name] NVARCHAR(250),
Presenters NVARCHAR(250) CONSTRAINT FK_Seminar_AllPeople FOREIGN KEY(Presenters) REFERENCES AllPeople(IdPerson),
TimeStart TIME,
TimeEnd TIME,
[Day] DATE,
Place NVARCHAR,
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
)
CREATE TABLE PerformenSeminar(
IdPerforment INT CONSTRAINT FK_PerformenSeminar_Performer FOREIGN KEY(IdPerforment) REFERENCES Performer(Id),
IdSeminar INT CONSTRAINT FK_PerformenSeminar_Seminar FOREIGN KEY(IdSeminar) REFERENCES Seminar(Id),
[Status] BIT
)
GO