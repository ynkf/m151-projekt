USE ClassRoom;

INSERT INTO [ClassRoom].[dbo].[User] (LastName, FirstName, Email, Password)
VALUES ('Teacher', 'Tom', 'teacher@mail.com', 'pwd')
/*-> 3*/

INSERT INTO [ClassRoom].[dbo].[User] (LastName, FirstName, Email, Password)
VALUES ('Student', 'Stefan', 'studentr@mail.com', 'pwd')
/*-> 4*/

INSERT INTO [ClassRoom].[dbo].[Teacher] (UserID)
VALUES (3) 
/*-> 3*/
INSERT INTO [ClassRoom].[dbo].[Student] (UserID)
VALUES (4)
/*-> 2*/

INSERT INTO [ClassRoom].[dbo].[Class] (TeacherID, Name)
VALUES (3, '20c')
/*-> 3*/
INSERT INTO [ClassRoom].[dbo].[Class] (TeacherID, Name)
VALUES (3, '19a')
/*-> 4*/

INSERT INTO [ClassRoom].[dbo].[ClassStudent] (ClassID, StudentID)
VALUES (3, 2)
/*-> 1*/

INSERT INTO [ClassRoom].[dbo].[Exam] (Title, Description, ClassID)
VALUES ('E: Voci Unit 6', 'Buch S.268', 3)
/*-> 5*/
INSERT INTO [ClassRoom].[dbo].[Exam] (Title, Description, ClassID)
VALUES ('D: Vortrag Gustl', '', 3)
/*-> 6*/
INSERT INTO [ClassRoom].[dbo].[Exam] (Title, Description, ClassID)
VALUES ('M: Stereometrie', 'Buch S.508-520', 4)
/*-> 7*/

INSERT INTO [ClassRoom].[dbo].[Mark] (StudentID, ExamID, Mark)
VALUES (2, 5, 6)
/*-> 1*/