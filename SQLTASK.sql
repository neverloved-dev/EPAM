IF OBJECT_ID('EmployeeInfo', 'V') IS NOT NULL
    DROP VIEW EmployeeInfo;
DROP TABLE IF EXISTS Person

--- TASK1 ---
CREATE TABLE Person(
	Id int not null CONSTRAINT PersonID primary key(Id),
	FirstName varchar(50) not null,
	LastName varchar(50) not null
)

DROP TABLE IF EXISTS Address

CREATE TABLE Address(
	Id int not null CONSTRAINT AddressId primary key(Id),
	Street nvarchar(50) not null,
	City nvarchar(20) not null,
	State nvarchar(50) not null,
	ZipCode nvarchar(50) not null
)

DROP TABLE IF EXISTS Employee

CREATE TABLE Employee(
	Id int not null CONSTRAINT EmployeeId primary key(Id),
	AddressId int not null CONSTRAINT Employee_AddressId foreign key(AddressId) references Address(Id),
	PersonId int not null CONSTRAINT Employee_PersonId foreign key (PersonId) references Person(Id),
	CompanyName nvarchar(30),
	EmployeeName nvarchar(100)
)

DROP TABLE IF EXISTS Company

CREATE TABLE Company(
	Id int not null CONSTRAINT CompanyId primary key(Id),
	Name nvarchar(20) not null,
	AddressId int not null CONSTRAINT Company_AddressId foreign key(AddressId) references Address(Id),
)
GO
---TASK 2 ---

CREATE VIEW EmployeeInfo
AS(
 SELECT E.Id AS EmployeeId,
    COALESCE(NULLIF(E.EmployeeName, ''), P.FirstName + ' ' + P.LastName) AS EmployeeFullName,
    ISNULL(A.ZipCode + '_' + A.State + ', ' + A.City + '-' + A.Street, '') AS EmployeeFullAddress,
    COALESCE(E.CompanyName + '(' + ISNULL(E.Position, '') + ')', '') AS EmployeeCompanyInfo
FROM Employee E
LEFT JOIN Person P ON E.PersonId = P.Id
LEFT JOIN Address A ON E.AddressId = A.Id
ORDER BY E.CompanyName ASC, A.City ASC);
GO


--TASK 3 --

CREATE PROCEDURE InsertEmployeeInfo
    @EmployeeName NVARCHAR(100) = NULL,
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @CompanyName NVARCHAR(20),
    @Position NVARCHAR(30) = NULL,
    @Street NVARCHAR(50),
    @City NVARCHAR(20) = NULL,
    @State NVARCHAR(50) = NULL,
    @ZipCode NVARCHAR(50) = NULL
AS
BEGIN
    -- Validate input conditions
    IF COALESCE(NULLIF(@EmployeeName, ''), NULLIF(@FirstName, ''), NULLIF(@LastName, '')) IS NOT NULL
    BEGIN
        IF LEN(@CompanyName) > 20
            SET @CompanyName = LEFT(@CompanyName, 20);

        INSERT INTO Person (FirstName, LastName)
        VALUES (COALESCE(@FirstName, ''), COALESCE(@LastName, ''));

        DECLARE @PersonId INT = SCOPE_IDENTITY();

        INSERT INTO Address (Street, City, State, ZipCode)
        VALUES (@Street, @City, @State, @ZipCode);

        DECLARE @AddressId INT = SCOPE_IDENTITY();

        INSERT INTO Employee (AddressId, PersonId, CompanyName, Position, EmployeeName)
        VALUES (@AddressId, @PersonId, @CompanyName, @Position, @EmployeeName);
    END
END;

