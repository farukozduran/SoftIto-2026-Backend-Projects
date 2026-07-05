-- ==============================================
-- Stored Procedures for Patient
-- ==============================================

CREATE PROCEDURE sp_GetAllPatients
AS
BEGIN
    SELECT * FROM Patient;
END;
GO

CREATE PROCEDURE sp_GetPatientById
    @Id int
AS
BEGIN
    SELECT * FROM Patient WHERE Id = @Id;
END;
GO

CREATE PROCEDURE sp_InsertPatient
    @IdentityNumber nvarchar(20),
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
    @Phone nvarchar(20),
    @BirthDate datetime2
AS
BEGIN
    INSERT INTO Patient (IdentityNumber, FirstName, LastName, Phone, BirthDate)
    VALUES (@IdentityNumber, @FirstName, @LastName, @Phone, @BirthDate);
    
    SELECT CAST(SCOPE_IDENTITY() as int);
END;
GO

CREATE PROCEDURE sp_UpdatePatient
    @Id int,
    @IdentityNumber nvarchar(20),
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
    @Phone nvarchar(20),
    @BirthDate datetime2
AS
BEGIN
    UPDATE Patient
    SET IdentityNumber = @IdentityNumber,
        FirstName = @FirstName,
        LastName = @LastName,
        Phone = @Phone,
        BirthDate = @BirthDate
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE sp_DeletePatient
    @Id int
AS
BEGIN
    DELETE FROM Patient WHERE Id = @Id;
END;
GO


-- ==============================================
-- Stored Procedures for Appointment
-- ==============================================

CREATE PROCEDURE sp_GetAllAppointments
AS
BEGIN
    SELECT * FROM Appointment;
END;
GO

CREATE PROCEDURE sp_GetAppointmentById
    @Id int
AS
BEGIN
    SELECT * FROM Appointment WHERE Id = @Id;
END;
GO

CREATE PROCEDURE sp_InsertAppointment
    @AppointmentDate datetime2,
    @DoctorFullName nvarchar(100),
    @PatientFullName nvarchar(100),
    @HospitalName nvarchar(150),
    @Status nvarchar(50)
AS
BEGIN
    INSERT INTO Appointment (AppointmentDate, DoctorFullName, PatientFullName, HospitalName, Status)
    VALUES (@AppointmentDate, @DoctorFullName, @PatientFullName, @HospitalName, @Status);
    
    SELECT CAST(SCOPE_IDENTITY() as int);
END;
GO

CREATE PROCEDURE sp_UpdateAppointment
    @Id int,
    @AppointmentDate datetime2,
    @DoctorFullName nvarchar(100),
    @PatientFullName nvarchar(100),
    @HospitalName nvarchar(150),
    @Status nvarchar(50)
AS
BEGIN
    UPDATE Appointment
    SET AppointmentDate = @AppointmentDate,
        DoctorFullName = @DoctorFullName,
        PatientFullName = @PatientFullName,
        HospitalName = @HospitalName,
        Status = @Status
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE sp_DeleteAppointment
    @Id int
AS
BEGIN
    DELETE FROM Appointment WHERE Id = @Id;
END;
GO
