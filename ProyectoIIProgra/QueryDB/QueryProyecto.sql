create database ProyectoIIDB

use ProyectoIIDB

CREATE TABLE SCHOOL
(
  SchoolId int IDENTITY(1,1) PRIMARY KEY,
  SchoolName varchar(50) NOT NULL UNIQUE,
  Description varchar(1000) NULL,
  Address varchar(50) NULL,
  Phone varchar(50) NULL,
  PostCode varchar(50) NULL,
  PostAddress varchar(50) NULL,
)

CREATE TABLE CLASS
(
  ClassId int IDENTITY(1,1) PRIMARY KEY,
  SchoolId int NOT NULL,
  CONSTRAINT FK_CLASS_SchoolId FOREIGN KEY (SchoolId) REFERENCES SCHOOL (SchoolId),
  ClassName varchar(50) NOT NULL UNIQUE,
  Description varchar(1000) NULL,
)

CREATE TABLE COURSE
(
  CourseId int IDENTITY(1,1) PRIMARY KEY,
  CourseName varchar(50) NOT NULL UNIQUE,
  SchoolId int NOT NULL,
  CONSTRAINT FK_COURSE_SchoolId FOREIGN KEY (SchoolId) REFERENCES SCHOOL (SchoolId),
  Description varchar(1000) NULL,
)

CREATE TABLE STUDENT
(
  StudentId int IDENTITY(1,1) PRIMARY KEY,
  ClassId int NOT NULL,
  CONSTRAINT FK_STUDENT_ClassId FOREIGN KEY (ClassId) REFERENCES CLASS (ClassId),
  StudentName varchar(100) NOT NULL,
  StudentNumber varchar(20) NOT NULL,
  TotalGrade float NULL,
  Address varchar(100) NULL,
  Phone varchar(20) NULL,
  EMail varchar(100) NULL,
)

CREATE TABLE TEACHER(
  TeacherId int IDENTITY(1,1) PRIMARY KEY,
  SchoolId int NOT NULL,
  CONSTRAINT FK_TEACHER_SchoolId FOREIGN KEY (SchoolId) REFERENCES SCHOOL (SchoolId),
  TeacherName VARCHAR(50),
  Description VARCHAR(1000) NULL,
)

CREATE TABLE STUDENT_COURSE 
(
  StudentId int NOT NULL,
  CONSTRAINT FK_STUDENT_COURSE_StudentId FOREIGN KEY (StudentId) REFERENCES STUDENT (StudentId),
  CourseId int NOT NULL,
  CONSTRAINT FK_STUDENT_COURSE_CourseId FOREIGN KEY (CourseId) REFERENCES COURSE (CourseId)
)

CREATE TABLE TEACHER_COURSE
(
  TeacherId int NOT NULL,
  CONSTRAINT FK_TEACHER_COURSE_TeacherId FOREIGN KEY (TeacherId) REFERENCES TEACHER (TeacherId),
  CourseId int NOT NULL,
  CONSTRAINT FK_TEACHER_COURSE_CourseId FOREIGN KEY (CourseId) REFERENCES COURSE (CourseId)
)

CREATE TABLE GRADE(
  GradeId int IDENTITY(1,1) PRIMARY KEY,
  StudentId int NOT NULL,
  CONSTRAINT FK_GRADE_StudentId FOREIGN KEY (StudentId) REFERENCES STUDENT (StudentId),
  CourseId int NOT NULL,
  CONSTRAINT FK_GRADE_CourseId FOREIGN KEY (CourseId) REFERENCES COURSE (CourseId),
  Grade float NOT NULL,
  Comment varchar(1000) NULL,
)

CREATE TABLE USERS
(
  ID INT IDENTITY (1,1),
  Email varchar (100) NOT NULL,
  Password varchar (100) NOT NULL,
  CONSTRAINT PK_ID PRIMARY KEY (ID),
  CONSTRAINT UQ_EMAIL UNIQUE (Email)
)

GO
INSERT INTO USERS VALUES ('test@gmail.com', '1234')
INSERT INTO USERS VALUES ('test', '1234')
GO

-- PROCEDIMIENTOS ALMACENADOS --

-- SCHOOL --
GO
CREATE PROCEDURE SP_AddSchool
(
    @SchoolName varchar(50),
    @Description varchar(1000),
    @Address varchar(50),
    @Phone varchar(50),
    @PostCode varchar(50),
    @PostAddress varchar(50)
)
AS
BEGIN
    INSERT INTO SCHOOL (SchoolName, Description, Address, Phone, PostCode, PostAddress)
    VALUES (@SchoolName, @Description, @Address, @Phone, @PostCode, @PostAddress)
END
GO

CREATE PROCEDURE SP_DeleteSchool
(
    @SchoolId int
)
AS
BEGIN
    DELETE FROM SCHOOL WHERE SchoolId = @SchoolId
END
GO

CREATE PROCEDURE SP_GetSchoolById
(
    @SchoolId int
)
AS
BEGIN
    SELECT * FROM SCHOOL WHERE SchoolId = @SchoolId
END
GO

CREATE PROCEDURE SP_UpdateSchool
(
	@SchoolId int,
	@SchoolName varchar(50),
	@Description varchar(1000),
	@Address varchar(50),
	@Phone varchar(50),
	@PostCode varchar(50),
	@PostAddress varchar(50)
)
AS
BEGIN
	UPDATE SCHOOL SET
		SchoolName = @SchoolName,
		Description = @Description,
		Address = @Address,
		Phone = @Phone,
		PostCode = @PostCode,
		PostAddress = @PostAddress
	WHERE SchoolId = @SchoolId
END
GO

-- CLASS --
CREATE PROCEDURE SP_AddClass
(
    @SchoolId int,
    @ClassName varchar(50),
    @Description varchar(1000)
)
AS
BEGIN
    INSERT INTO CLASS (SchoolId, ClassName, Description)
    VALUES (@SchoolId, @ClassName, @Description)
END
GO

CREATE PROCEDURE SP_DeleteClass
(
    @ClassId int
)
AS
BEGIN
    DELETE FROM CLASS WHERE ClassId = @ClassId
END
GO

CREATE PROCEDURE SP_GetClassById
(
    @ClassId int
)
AS
BEGIN
    SELECT * FROM CLASS WHERE ClassId = @ClassId
END
GO

CREATE PROCEDURE SP_UpdateClass
(
    @ClassId int,
    @SchoolId int,
    @ClassName varchar(50),
    @Description varchar(1000)
)
AS
BEGIN
    UPDATE CLASS SET
        SchoolId = @SchoolId,
        ClassName = @ClassName,
        Description = @Description
    WHERE ClassId = @ClassId
END
GO

-- COURSE --
CREATE PROCEDURE SP_AddCourse
(
  @CourseName varchar(50),
  @SchoolId int,
  @Description varchar(1000)
)
AS
BEGIN
  INSERT INTO COURSE (CourseName, SchoolId, Description)
  VALUES (@CourseName, @SchoolId, @Description)
END
GO

CREATE PROCEDURE SP_DeleteCourse
(
  @CourseId int
)
AS
BEGIN
  DELETE FROM COURSE WHERE CourseId = @CourseId
END
GO

CREATE PROCEDURE SP_GetCourseById
(
  @CourseId int
)
AS
BEGIN
  SELECT * FROM COURSE WHERE CourseId = @CourseId
END
GO

CREATE PROCEDURE SP_UpdateCourse
(
  @CourseId int,
  @CourseName varchar(50),
  @SchoolId int,
  @Description varchar(1000)
)
AS
BEGIN
  UPDATE COURSE SET CourseName = @CourseName, SchoolId = @SchoolId, Description = @Description
  WHERE CourseId = @CourseId
END
GO

-- STUDENT --
CREATE PROCEDURE SP_AddStudent
(
    @ClassId int,
    @StudentName varchar(100),
    @StudentNumber varchar(20),
    @TotalGrade float = NULL,
    @Address varchar(100) = NULL,
    @Phone varchar(20) = NULL,
    @EMail varchar(100) = NULL
)
AS
BEGIN
    INSERT INTO STUDENT (ClassId, StudentName, StudentNumber, TotalGrade, Address, Phone, EMail)
    VALUES (@ClassId, @StudentName, @StudentNumber, @TotalGrade, @Address, @Phone, @EMail)
END
GO

CREATE PROCEDURE SP_DeleteStudent
(
    @StudentId int
)
AS
BEGIN
    DELETE FROM STUDENT WHERE StudentId = @StudentId
END
GO

CREATE PROCEDURE SP_GetStudentById
(
    @StudentId int
)
AS
BEGIN
    SELECT * FROM STUDENT WHERE StudentId = @StudentId
END
GO

CREATE PROCEDURE SP_UpdateStudent
(
  @StudentId int,
  @ClassId int = NULL,
  @StudentName varchar(100) = NULL,
  @StudentNumber varchar(20) = NULL,
  @TotalGrade float = NULL,
  @Address varchar(100) = NULL,
  @Phone varchar(20) = NULL,
  @EMail varchar(100) = NULL
)
AS
BEGIN
  UPDATE STUDENT SET 
    ClassId = @ClassId, 
    StudentName = @StudentName, 
    StudentNumber = @StudentNumber, 
    TotalGrade = @TotalGrade, 
    Address = @Address, 
    Phone = @Phone, 
    EMail = @EMail 
  WHERE StudentId = @StudentId
END
GO

-- TEACHER --
CREATE PROCEDURE SP_AddTeacher
(
  @SchoolId INT,
  @TeacherName VARCHAR(50),
  @Description VARCHAR(1000)
)
AS
BEGIN
  INSERT INTO TEACHER (SchoolId, TeacherName, Description)
  VALUES (@SchoolId, @TeacherName, @Description)
END
GO

CREATE PROCEDURE SP_DeleteTeacher
(
  @TeacherId INT
)
AS
BEGIN
  DELETE FROM TEACHER
  WHERE TeacherId = @TeacherId
END
GO

CREATE PROCEDURE SP_GetTeacherById
(
  @TeacherId INT
)
AS
BEGIN
  SELECT * FROM TEACHER
  WHERE TeacherId = @TeacherId
END
GO

CREATE PROCEDURE SP_UpdateTeacher
(
  @TeacherId INT,
  @SchoolId INT,
  @TeacherName VARCHAR(50),
  @Description VARCHAR(1000)
)
AS
BEGIN
  UPDATE TEACHER
  SET SchoolId = @SchoolId,
      TeacherName = @TeacherName,
      Description = @Description
  WHERE TeacherId = @TeacherId
END
GO

-- STUDENT_COURSE --
CREATE PROCEDURE SP_AddStudentCourse
  @StudentId int,
  @CourseId int
AS
BEGIN
  INSERT INTO STUDENT_COURSE (StudentId, CourseId)
  VALUES (@StudentId, @CourseId)
END
GO

CREATE PROCEDURE SP_DeleteStudentCourse
  @StudentId int,
  @CourseId int
AS
BEGIN
  DELETE FROM STUDENT_COURSE
  WHERE StudentId = @StudentId AND CourseId = @CourseId
END
GO

CREATE PROCEDURE SP_GetAllStudentCourse
(
  @StudentId INT
)
AS
BEGIN
  SELECT * FROM STUDENT_COURSE
  WHERE StudentId = @StudentId
END
GO

CREATE PROCEDURE SP_UpdateStudentCourse
  @StudentId int,
  @CourseId int
AS
BEGIN
  UPDATE STUDENT_COURSE
  SET CourseId = @CourseId
  WHERE StudentId = @StudentId
END
GO

-- TEACHER_COURSE --
CREATE PROCEDURE SP_AddTeacherCourse
  @TeacherId int,
  @CourseId int
AS
BEGIN
  INSERT INTO TEACHER_COURSE (TeacherId, CourseId)
  VALUES (@TeacherId, @CourseId)
END
GO

CREATE PROCEDURE SP_DeleteTeacherCourse
  @TeacherId int,
  @CourseId int
AS
BEGIN
  DELETE FROM TEACHER_COURSE
  WHERE TeacherId = @TeacherId AND CourseId = @CourseId
END
GO

CREATE PROCEDURE SP_GetAllTeacherCourse
(
  @TeacherId INT
)
AS
BEGIN
  SELECT * FROM TEACHER_COURSE
  WHERE TeacherId = @TeacherId
END
GO

CREATE PROCEDURE SP_UpdateTeacherCourse
  @TeacherId int,
  @CourseId int
AS
BEGIN
  UPDATE TEACHER_COURSE
  SET CourseId = @CourseId
  WHERE TeacherId = @TeacherId
END
GO

-- GRADE --
CREATE PROCEDURE SP_AddGrade
  @StudentId int,
  @CourseId int,
  @Grade float,
  @Comment varchar(1000)
AS
BEGIN
  INSERT INTO GRADE (StudentId, CourseId, Grade, Comment)
  VALUES (@StudentId, @CourseId, @Grade, @Comment)
END
GO

CREATE PROCEDURE SP_DeleteGrade
  @GradeId int
AS
BEGIN
  DELETE FROM GRADE
  WHERE GradeId = @GradeId
END
GO

CREATE PROCEDURE SP_GetAllGrade
(
  @GradeId INT
)
AS
BEGIN
  SELECT * FROM GRADE
  WHERE GradeId = @GradeId
END
GO

CREATE PROCEDURE SP_UpdateGrade
  @GradeId int,
  @StudentId int,
  @CourseId int,
  @Grade float,
  @Comment varchar(1000)
AS
BEGIN
  UPDATE GRADE
  SET StudentId = @StudentId, CourseId = @CourseId, Grade = @Grade, Comment = @Comment
  WHERE GradeId = @GradeId
END
GO

-- USERS --
CREATE PROCEDURE ValidarLogin
  @Email varchar(100) = '',
  @Password varchar(100) = ''
AS
BEGIN
  SELECT Email, Password
  FROM USERS
  WHERE Email = @Email AND Password = @Password
END