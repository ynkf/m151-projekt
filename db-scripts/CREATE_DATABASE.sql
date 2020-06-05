DROP TABLE IF EXISTS [Mark];
DROP TABLE IF EXISTS [ClassStudent];
DROP TABLE IF EXISTS [Exam];
DROP TABLE IF EXISTS [Class];
DROP TABLE IF EXISTS [Student];
DROP TABLE IF EXISTS [Teacher];
DROP TABLE IF EXISTS [User];

CREATE TABLE [User] (
	ID int IDENTITY(0,1), 
	LastName varchar(255) NOT NULL,
	FirstName varchar(255) NOT NULL,
	Email varchar(100) NOT NULL,
	Password varchar(100) NOT NULL,
	CONSTRAINT PK_User PRIMARY KEY (ID)
);

CREATE TABLE [Teacher] (
	ID int IDENTITY(0,1), 
	UserID int NOT NULL,
	CONSTRAINT PK_Teacher PRIMARY KEY (ID),
	CONSTRAINT FK_Teacher_User FOREIGN KEY (UserID) REFERENCES [User](ID) ON DELETE CASCADE
);

CREATE TABLE [Class] (
	ID int IDENTITY(0,1), 
	TeacherID int NOT NULL,
	CONSTRAINT PK_Class PRIMARY KEY (ID),
	CONSTRAINT FK_Class_Teacher FOREIGN KEY (TeacherID) REFERENCES [Teacher](ID) ON DELETE CASCADE
);

CREATE TABLE [Student] (
	ID int IDENTITY(0,1), 
	UserID int NOT NULL,	
	CONSTRAINT PK_Student PRIMARY KEY (ID),
	CONSTRAINT FK_Student_User FOREIGN KEY (UserID) REFERENCES [User](ID) ON DELETE CASCADE
);

CREATE TABLE [ClassStudent] (
	ID int IDENTITY(0,1),
	ClassID int NOT NULL,
	StudentID int NOT NULL,
	CONSTRAINT PK_ClassStudent PRIMARY KEY (ID),
	CONSTRAINT FK_ClassStudent_Class FOREIGN KEY (ClassID) REFERENCES [Class](ID),
	CONSTRAINT FK_ClassStudent_Student FOREIGN KEY (StudentID) REFERENCES [Student](ID)
);

CREATE TABLE [Exam] (
	ID int IDENTITY(0,1),
	Title varchar(100),
	Description varchar(255),
	ClassID int NOT NULL,
	CONSTRAINT PK_Exam PRIMARY KEY (ID),
	CONSTRAINT FK_Exam_Class FOREIGN KEY (ClassID) REFERENCES [Class](ID) ON DELETE CASCADE
);

CREATE TABLE [Mark] (
	ID int IDENTITY(0,1),
	StudentID int NOT NULL,
	ExamID int NOT NULL,
	Mark int,
	CONSTRAINT PK_Mark PRIMARY KEY (ID),
	CONSTRAINT FK_Mark_Student FOREIGN KEY (StudentID) REFERENCES Student(ID) ON DELETE CASCADE,
	CONSTRAINT FK_Mark_Exam FOREIGN KEY (ExamID) REFERENCES Exam(ID),
	CONSTRAINT CHK_Mark_Mark CHECK (Mark IS NULL OR (Mark >= 1 AND Mark<= 6))
);