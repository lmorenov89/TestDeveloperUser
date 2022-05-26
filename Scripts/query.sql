CREATE TABLE Users (
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nvarchar(100) NOT NULL,
	Birthday datetime NOT NULL,
	Gender smallint NOT NULL
);

CREATE OR ALTER PROCEDURE SP_CreateUser @Name nvarchar(100), @Birthday datetime, @Gender smallint
AS
INSERT INTO Users (Name, Birthday, Gender)
VALUES(@Name, @Birthday, @Gender);

exec SP_CreateUser 'Test', '1988-07-04 00:00:00.000', 1;

CREATE OR ALTER PROCEDURE SP_UpdateUser @UserId int, @Name nvarchar(100), @Birthday datetime, @Gender smallint
AS
UPDATE Users
SET Name=@Name, Birthday=@Birthday, Gender=@Gender
WHERE Id=@UserId;

exec SP_UpdateUser 4, 'Test', '1988-05-04 00:00:00.000', 1;

CREATE OR ALTER PROCEDURE SP_DeleteUser @UserId int
AS
DELETE FROM Users
WHERE Id=@UserId;

exec SP_DeleteUser 4;