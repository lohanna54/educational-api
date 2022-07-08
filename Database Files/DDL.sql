CREATE DATABASE Educational;

USE Educational;

CREATE TABLE Class (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    CurrentName VARCHAR(20) NOT NULL,
    IsActive BIT NOT NULL
);

CREATE TABLE Student (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    FullName VARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    Genre CHAR NOT NULL,
    TotalAbsences INT,
	IsActive BIT NOT NULL,
	ClassId INT FOREIGN KEY REFERENCES Class(Id) NOT NULL
);