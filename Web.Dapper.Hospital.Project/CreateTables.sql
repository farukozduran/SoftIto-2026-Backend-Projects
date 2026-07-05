-- ==============================================
-- Tables Creation
-- ==============================================

CREATE TABLE Hospital (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(150) NOT NULL,
    City nvarchar(50) NOT NULL,
    Address nvarchar(250) NOT NULL,
    Phone nvarchar(20) NOT NULL
);
GO

CREATE TABLE Doctor (
    Id int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    Branch nvarchar(100) NOT NULL,
    HospitalName nvarchar(150) NOT NULL,
    IsActive bit NOT NULL
);
GO

CREATE TABLE Patient (
    Id int IDENTITY(1,1) PRIMARY KEY,
    IdentityNumber nvarchar(20) NOT NULL,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    Phone nvarchar(20) NOT NULL,
    BirthDate datetime2 NOT NULL
);
GO

CREATE TABLE Appointment (
    Id int IDENTITY(1,1) PRIMARY KEY,
    AppointmentDate datetime2 NOT NULL,
    DoctorFullName nvarchar(100) NOT NULL,
    PatientFullName nvarchar(100) NOT NULL,
    HospitalName nvarchar(150) NOT NULL,
    Status nvarchar(50) NOT NULL
);
GO
