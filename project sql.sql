-- Create the database
CREATE DATABASE payroll;
GO

USE payroll;
GO

-- Create Users table for authentication
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARBINARY(256) NOT NULL, -- Store hashed passwords
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Create Departments table
CREATE TABLE Departments (
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,   
    DepartmentName NVARCHAR(100) NOT NULL, 
    Description NVARCHAR(500),
    Status NVARCHAR(10) DEFAULT 'Active' CHECK (Status IN ('Active', 'Inactive')), -- Status column
    CreatedAt DATETIME DEFAULT GETDATE(),           
    UpdatedAt DATETIME DEFAULT GETDATE()            
);
GO

-- Create Positions table
CREATE TABLE Positions (
    PositionId INT IDENTITY(1,1) PRIMARY KEY,
    PositionName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL,
    BaseSalary DECIMAL(18, 2) NOT NULL, -- Default salary for the position
    DepartmentId INT,
    Status NVARCHAR(10) DEFAULT 'Active' CHECK (Status IN ('Active', 'Inactive')), -- Status column
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId)
);
GO

-- Create Employees table
CREATE TABLE Employees (
    EmployeeId NVARCHAR(6) PRIMARY KEY,  -- Custom ID as NVARCHAR(6)
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    DateOfEmployment DATE NOT NULL,
    DepartmentId INT NOT NULL,
    PositionId INT NOT NULL,
    Address NVARCHAR(250),
    Salary DECIMAL(18, 2) NOT NULL, -- Individual salary for the employee
    Status NVARCHAR(10) DEFAULT 'Active' CHECK (Status IN ('Active', 'Inactive')), -- Status column
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId),
    FOREIGN KEY (PositionId) REFERENCES Positions(PositionId)
);
GO

-- Create Payroll table
CREATE TABLE Payroll (
    PayrollId INT PRIMARY KEY IDENTITY,  -- Automatic ID for Payroll table
    EmployeeId NVARCHAR(6) NOT NULL,  -- Reference to custom EmployeeId
    GrossSalary DECIMAL(18, 2) NOT NULL, -- Base salary + bonuses
    Bonus DECIMAL(18, 2) DEFAULT 0,
    Tax DECIMAL(18, 2) DEFAULT 0,
    Deductions DECIMAL(18, 2) DEFAULT 0,
    NetSalary AS (GrossSalary + Bonus - Tax - Deductions), -- Computed column
    PayDate DATE NOT NULL,
    Status NVARCHAR(10) DEFAULT 'Active' CHECK (Status IN ('Active', 'Inactive')), -- Status column
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);
GO

-- Create Deductibles table
CREATE TABLE Deductibles (
    DeductibleId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId NVARCHAR(6) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    Date DATE NOT NULL,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);
GO

-- Create Bonuses table
CREATE TABLE Bonuses (
    BonusId INT IDENTITY(1,1) PRIMARY KEY,    
    EmployeeId NVARCHAR(6) NOT NULL,                    
    Amount DECIMAL(18, 2) NOT NULL, 
    Description NVARCHAR(255) NOT NULL,
    BonusDate DATE NOT NULL,               
    CreatedAt DATETIME DEFAULT GETDATE(),           
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)  
);
GO

-- Create Attendance table
CREATE TABLE Attendance (
    AttendanceId INT IDENTITY(1,1) PRIMARY KEY,        
    EmployeeId NVARCHAR(6) NOT NULL,                  
    Date DATE NOT NULL,                               
    AttendanceStatus NVARCHAR(1) NOT NULL CHECK (AttendanceStatus IN ('√', 'X', 'L')), 
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId) 
);
GO

-- Drop the trigger if it exists
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_EmployeeId_InsteadOfInsert')
BEGIN
    DROP TRIGGER trg_EmployeeId_InsteadOfInsert;
END;
GO

-- Create the trigger to generate EmployeeId
CREATE TRIGGER trg_EmployeeId_InsteadOfInsert
ON Employees
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @EmployeeId NVARCHAR(6), 
            @FirstName NVARCHAR(100), 
            @LastName NVARCHAR(100), 
            @Email NVARCHAR(100), 
            @DateOfEmployment DATE, 
            @DepartmentId INT, 
            @PositionId INT, 
            @Address NVARCHAR(250),
            @Salary DECIMAL(18, 2),
            @DepartmentName NVARCHAR(100);

    -- Get values from the inserted row
    SELECT 
        @FirstName = FirstName,
        @LastName = LastName,
        @Email = Email,
        @DateOfEmployment = DateOfEmployment,
        @DepartmentId = DepartmentId,
        @PositionId = PositionId,
        @Address = Address,
        @Salary = Salary
    FROM inserted;

    -- Fetch the DepartmentName using DepartmentId
    SELECT @DepartmentName = DepartmentName
    FROM Departments
    WHERE DepartmentId = @DepartmentId;

    -- Generate EmployeeId:
    -- 2 characters from LastName, 2 digits from DateOfEmployment (YYMM), 1 character from DepartmentName
    SET @EmployeeId = 
        UPPER(SUBSTRING(@LastName, 1, 2)) +   -- First 2 characters of LastName
        FORMAT(@DateOfEmployment, 'yyMM') +   -- Last 2 digits of Year and Month from DateOfEmployment
        UPPER(SUBSTRING(@DepartmentName, 1, 1)); -- First character of DepartmentName

    -- Insert the employee with the generated EmployeeId
    INSERT INTO Employees (EmployeeId, FirstName, LastName, Email, DateOfEmployment, DepartmentId, PositionId, Address, Salary)
    VALUES (@EmployeeId, @FirstName, @LastName, @Email, @DateOfEmployment, @DepartmentId, @PositionId, @Address, @Salary);
END;
GO

-- Drop the trigger if it exists
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_AddDeductionBasedOnAttendance')
BEGIN
    DROP TRIGGER trg_AddDeductionBasedOnAttendance;
END;
GO

-- Create the trigger to add deductions based on attendance
CREATE TRIGGER trg_AddDeductionBasedOnAttendance
ON Attendance
AFTER INSERT
AS
BEGIN
    DECLARE @EmployeeId NVARCHAR(6),
            @AttendanceStatus NVARCHAR(1),
            @Date DATE,
            @DeductionAmount DECIMAL(18, 2) = 50.00; -- Example: Deduct $50 for absence, $25 for being late

    -- Get values from the inserted row
    SELECT 
        @EmployeeId = EmployeeId,
        @AttendanceStatus = AttendanceStatus,
        @Date = Date
    FROM inserted;

    -- Calculate deductions based on attendance status
    DECLARE @TotalDeductions DECIMAL(18, 2) = 0;

    SET @TotalDeductions = 
        CASE 
            WHEN @AttendanceStatus = 'X' THEN @DeductionAmount -- Deduct for absence
            WHEN @AttendanceStatus = 'L' THEN @DeductionAmount / 2 -- Deduct half for being late
            ELSE 0 -- No deduction for present ('√')
        END;

    -- If there are deductions, insert them into the Deductibles table
    IF @TotalDeductions > 0
    BEGIN
        INSERT INTO Deductibles (EmployeeId, Amount, Description, Date)
        VALUES (@EmployeeId, @TotalDeductions, 'Attendance Deduction', @Date);
    END
END;
GO

-- Stored Procedure: Add User
CREATE PROCEDURE AddUser
    @Username NVARCHAR(50),
    @Password NVARCHAR(50) -- Plain text password (will be hashed)
AS
BEGIN
    DECLARE @PasswordHash VARBINARY(256);

    -- Hash the password using SHA-256
    SET @PasswordHash = HASHBYTES('SHA2_256', @Password);

    -- Insert the user into the Users table
    INSERT INTO Users (Username, PasswordHash)
    VALUES (@Username, @PasswordHash);
END;
GO

-- Stored Procedure: Authenticate User
CREATE PROCEDURE AuthenticateUser
    @Username NVARCHAR(50),
    @Password NVARCHAR(50) -- Plain text password (will be hashed)
AS
BEGIN
    DECLARE @PasswordHash VARBINARY(256);

    -- Hash the input password
    SET @PasswordHash = HASHBYTES('SHA2_256', @Password);

    -- Check if the username and password hash match
    SELECT UserId, Username
    FROM Users
    WHERE Username = @Username AND PasswordHash = @PasswordHash;
END;
GO

-- Stored Procedure: Add Department
CREATE PROCEDURE AddDepartment
    @DepartmentName NVARCHAR(100),
    @Description NVARCHAR(500)
AS
BEGIN
    INSERT INTO Departments (DepartmentName, Description)
    VALUES (@DepartmentName, @Description);
END;
GO

-- Stored Procedure: Update Department
CREATE PROCEDURE UpdateDepartment
    @DepartmentId INT,
    @DepartmentName NVARCHAR(100) = NULL,
    @Description NVARCHAR(500) = NULL,
    @Status NVARCHAR(10) = NULL
AS
BEGIN
    UPDATE Departments
    SET 
        DepartmentName = ISNULL(@DepartmentName, DepartmentName),
        Description = ISNULL(@Description, Description),
        Status = ISNULL(@Status, Status),
        UpdatedAt = GETDATE()
    WHERE DepartmentId = @DepartmentId;
END;
GO

-- Stored Procedure: Add Position
CREATE PROCEDURE AddPosition
    @PositionName NVARCHAR(100),
    @Description NVARCHAR(255),
    @BaseSalary DECIMAL(18, 2),
    @DepartmentId INT
AS
BEGIN
    INSERT INTO Positions (PositionName, Description, BaseSalary, DepartmentId)
    VALUES (@PositionName, @Description, @BaseSalary, @DepartmentId);
END;
GO

-- Stored Procedure: Update Position
CREATE PROCEDURE UpdatePosition
    @PositionId INT,
    @PositionName NVARCHAR(100) = NULL,
    @Description NVARCHAR(255) = NULL,
    @BaseSalary DECIMAL(18, 2) = NULL,
    @DepartmentId INT = NULL,
    @Status NVARCHAR(10) = NULL
AS
BEGIN
    UPDATE Positions
    SET 
        PositionName = ISNULL(@PositionName, PositionName),
        Description = ISNULL(@Description, Description),
        BaseSalary = ISNULL(@BaseSalary, BaseSalary),
        DepartmentId = ISNULL(@DepartmentId, DepartmentId),
        Status = ISNULL(@Status, Status)
    WHERE PositionId = @PositionId;
END;
GO

-- Stored Procedure: Add Employee
CREATE PROCEDURE AddEmployee
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(100),
    @DateOfEmployment DATE,
    @DepartmentId INT,
    @PositionId INT,
    @Address NVARCHAR(250),
    @Salary DECIMAL(18, 2)
AS
BEGIN
    -- The trigger will handle EmployeeId generation
    INSERT INTO Employees (FirstName, LastName, Email, DateOfEmployment, DepartmentId, PositionId, Address, Salary)
    VALUES (@FirstName, @LastName, @Email, @DateOfEmployment, @DepartmentId, @PositionId, @Address, @Salary);
END;
GO

-- Stored Procedure: Update Employee
CREATE PROCEDURE UpdateEmployee
    @EmployeeId NVARCHAR(6),
    @FirstName NVARCHAR(100) = NULL,
    @LastName NVARCHAR(100) = NULL,
    @Email NVARCHAR(100) = NULL,
    @DateOfEmployment DATE = NULL,
    @DepartmentId INT = NULL,
    @PositionId INT = NULL,
    @Address NVARCHAR(250) = NULL,
    @Salary DECIMAL(18, 2) = NULL,
    @Status NVARCHAR(10) = NULL
AS
BEGIN
    UPDATE Employees
    SET 
        FirstName = ISNULL(@FirstName, FirstName),
        LastName = ISNULL(@LastName, LastName),
        Email = ISNULL(@Email, Email),
        DateOfEmployment = ISNULL(@DateOfEmployment, DateOfEmployment),
        DepartmentId = ISNULL(@DepartmentId, DepartmentId),
        PositionId = ISNULL(@PositionId, PositionId),
        Address = ISNULL(@Address, Address),
        Salary = ISNULL(@Salary, Salary),
        Status = ISNULL(@Status, Status)
    WHERE EmployeeId = @EmployeeId;
END;
GO

-- Stored Procedure: Add Bonus
CREATE PROCEDURE AddBonus
    @EmployeeId NVARCHAR(6),
    @Amount DECIMAL(18, 2),
    @Description NVARCHAR(255),
    @BonusDate DATE
AS
BEGIN
    INSERT INTO Bonuses (EmployeeId, Amount, Description, BonusDate)
    VALUES (@EmployeeId, @Amount, @Description, @BonusDate);
END;
GO

-- Stored Procedure: Add Deduction
CREATE PROCEDURE AddDeduction
    @EmployeeId NVARCHAR(6),
    @Amount DECIMAL(18, 2),
    @Description NVARCHAR(255),
    @DeductionDate DATE
AS
BEGIN
    INSERT INTO Deductibles (EmployeeId, Amount, Description, Date)
    VALUES (@EmployeeId, @Amount, @Description, @DeductionDate);
END;
GO

ALTER PROCEDURE ProcessPayroll
    @PayDate DATE
AS
BEGIN
    DECLARE @TaxRate DECIMAL(5,2) = 0.35; -- 35% tax rate

    -- Temporary table to hold employee calculations
    CREATE TABLE #PayrollData (
        EmployeeId NVARCHAR(6),
        GrossSalary DECIMAL(18,2),
        Bonus DECIMAL(18,2),
        Tax DECIMAL(18,2),
        Deductions DECIMAL(18,2)
    );

    -- Calculate payroll for all employees
    INSERT INTO #PayrollData
    SELECT 
        e.EmployeeId,
        e.Salary AS GrossSalary,
        ISNULL(b.Bonuses, 0) AS Bonus,
        e.Salary * @TaxRate AS Tax,
        ISNULL(d.Deductions, 0) AS Deductions
    FROM Employees e
    LEFT JOIN (
        SELECT EmployeeId, SUM(Amount) AS Bonuses
        FROM Bonuses
        GROUP BY EmployeeId
    ) b ON e.EmployeeId = b.EmployeeId
    LEFT JOIN (
        SELECT EmployeeId, SUM(Amount) AS Deductions
        FROM Deductibles
        GROUP BY EmployeeId
    ) d ON e.EmployeeId = d.EmployeeId;

    -- Insert into Payroll table
    INSERT INTO Payroll (EmployeeId, GrossSalary, Bonus, Tax, Deductions, PayDate, Status)
    SELECT 
        EmployeeId,
        GrossSalary,
        Bonus,
        Tax,
        Deductions,
        @PayDate,
        'Active'
    FROM #PayrollData;

    DROP TABLE #PayrollData;
END;

-- Stored Procedure: Fetch Employee Details
CREATE PROCEDURE GetEmployeeDetails
    @EmployeeId NVARCHAR(6)
AS
BEGIN
    SELECT 
        EmployeeId,
        FirstName,
        LastName,
        Email,
        DateOfEmployment,
        DepartmentId,
        PositionId,
        Address,
        Salary,
        Status
    FROM Employees
    WHERE EmployeeId = @EmployeeId;
END;
GO

CREATE PROCEDURE GetEmployeeCount
AS
BEGIN
    -- Get the total number of employees
    SELECT COUNT(*) AS EmployeeCount
    FROM Employees;
END;
GO

CREATE PROCEDURE GetTotalPayrollForMonth
AS
BEGIN
    -- Calculate total payroll for the current month
    SELECT SUM(NetSalary) AS TotalPayroll
    FROM Payroll
    WHERE PayDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) 
      AND PayDate < DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1));
END;
GO

CREATE PROCEDURE GetAverageSalary
AS
BEGIN
    -- Calculate average salary
    SELECT AVG(Salary) AS AverageSalary
    FROM Employees;
END;
GO

CREATE PROCEDURE GetLastPayrollRunDate
AS
BEGIN
    -- Get the last payroll run date
    SELECT TOP 1 PayDate AS LastPayrollRunDate
    FROM Payroll
    ORDER BY PayDate DESC;
END;
GO

CREATE PROCEDURE GetNewHiresLastMonth
AS
BEGIN
    -- Get new employees hired in the last month
    SELECT COUNT(*) AS NewHiresCount
    FROM Employees
    WHERE DateOfEmployment > DATEADD(MONTH, -1, GETDATE());
END;
GO

-- Stored Procedure: Fetch Payroll Details
CREATE PROCEDURE GetPayrollDetails
    @EmployeeId NVARCHAR(6)
AS
BEGIN
    SELECT 
        PayrollId,
        EmployeeId,
        GrossSalary,
        Bonus,
        Tax,
        Deductions,
        NetSalary,
        PayDate,
        Status
    FROM Payroll
    WHERE EmployeeId = @EmployeeId;
END;
GO

-- Stored Procedure: Fetch All Employees in a Department
CREATE PROCEDURE GetEmployeesByDepartment
    @DepartmentId INT
AS
BEGIN
    SELECT 
        EmployeeId,
        FirstName,
        LastName,
        Email,
        DateOfEmployment,
        PositionId,
        Address,
        Salary,
        Status
    FROM Employees
    WHERE DepartmentId = @DepartmentId;
END;
GO

-- Stored Procedure: Fetch All Positions in a Department
CREATE PROCEDURE GetPositionsByDepartment
    @DepartmentId INT
AS
BEGIN
    SELECT 
        PositionId,
        PositionName,
        Description,
        BaseSalary,
        Status,
        CreatedDate
    FROM Positions
    WHERE DepartmentId = @DepartmentId;
END;
GO

CREATE PROCEDURE UpdateAttendance
    @AttendanceId INT,
    @AttendanceStatus NVARCHAR(1) = NULL,
    @Date DATE = NULL
AS
BEGIN
    UPDATE Attendance
    SET 
        AttendanceStatus = ISNULL(@AttendanceStatus, AttendanceStatus),
        Date = ISNULL(@Date, Date)
    WHERE AttendanceId = @AttendanceId;
END;

GO
CREATE TRIGGER trg_ReviseDeductionOnUpdateAttendance
ON Attendance
AFTER UPDATE
AS
BEGIN
    DECLARE @EmployeeId NVARCHAR(6),
            @OldAttendanceStatus NVARCHAR(1),
            @NewAttendanceStatus NVARCHAR(1),
            @Date DATE,
            @DeductionAmount DECIMAL(18, 2) = 50.00; -- Example: Deduct $50 for absence, $25 for being late

    -- Get values from the inserted (new) and deleted (old) rows
    SELECT 
        @EmployeeId = i.EmployeeId,
        @NewAttendanceStatus = i.AttendanceStatus,
        @Date = i.Date
    FROM inserted i;

    SELECT 
        @OldAttendanceStatus = d.AttendanceStatus
    FROM deleted d;

    -- Remove the old deduction (if any)
    DELETE FROM Deductibles
    WHERE EmployeeId = @EmployeeId
      AND Date = @Date
      AND Description = 'Attendance Deduction';

    -- Calculate new deductions based on the updated attendance status
    DECLARE @TotalDeductions DECIMAL(18, 2) = 0;

    SET @TotalDeductions = 
        CASE 
            WHEN @NewAttendanceStatus = 'X' THEN @DeductionAmount -- Deduct for absence
            WHEN @NewAttendanceStatus = 'L' THEN @DeductionAmount / 2 -- Deduct half for being late
            ELSE 0 -- No deduction for present ('√')
        END;

    -- If there are new deductions, insert them into the Deductibles table
    IF @TotalDeductions > 0
    BEGIN
        INSERT INTO Deductibles (EmployeeId, Amount, Description, Date)
        VALUES (@EmployeeId, @TotalDeductions, 'Attendance Deduction', @Date);
    END
END;
GO

CREATE PROCEDURE GetEmployees
AS
BEGIN
    SELECT 
        EmployeeId,
        FirstName,
        LastName,
        Email,
        DateOfEmployment,
        DepartmentId,
        PositionId,
        Address,
        Salary,
        Status
    FROM Employees
END;
GO
Select * FROM Departments
GO
CREATE PROCEDURE GetAllDepartments
AS
BEGIN
    SELECT 
        DepartmentId, 
        DepartmentName, 
        Description, 
        Status, 
        CreatedAt, 
        UpdatedAt
    FROM Departments
    ORDER BY DepartmentName; -- Optional: Order by DepartmentName for better readability
END;
go
Alter PROCEDURE SaveAttendance
    @EmployeeId NVARCHAR(6),
    @Date DATE,
    @Status NVARCHAR(1)
AS
BEGIN
    MERGE INTO Attendance AS target
    USING (VALUES (@EmployeeId, @Date, @Status)) 
        AS source (EmployeeId, Date, AttendanceStatus)
    ON target.EmployeeId = source.EmployeeId 
        AND target.Date = source.Date
    WHEN MATCHED THEN
        UPDATE SET AttendanceStatus = source.AttendanceStatus
    WHEN NOT MATCHED THEN
        INSERT (EmployeeId, Date, AttendanceStatus)
        VALUES (source.EmployeeId, source.Date, source.AttendanceStatus);
END;
go
CREATE PROCEDURE GetAttendanceByMonthYear
    @Month INT,
    @Year INT
AS
BEGIN
    SELECT 
        EmployeeId, 
        DAY(Date) AS Day, 
        AttendanceStatus
    FROM Attendance
    WHERE MONTH(Date) = @Month AND YEAR(Date) = @Year;
END;
go
CREATE PROCEDURE ResetPassword
    @Username NVARCHAR(50),
    @NewPassword NVARCHAR(50)
AS
BEGIN
    DECLARE @PasswordHash VARBINARY(256);

    -- Hash the new password using SHA-256
    SET @PasswordHash = HASHBYTES('SHA2_256', @NewPassword);

    -- Update the user's password
    UPDATE Users
    SET PasswordHash = @PasswordHash
    WHERE Username = @Username;

    -- Check if the password was updated
    IF @@ROWCOUNT > 0
    BEGIN
        SELECT 1 AS Success; -- Password updated successfully
    END
    ELSE
    BEGIN
        SELECT 0 AS Success; -- Username not found
    END
END;
go
-- Stored Procedure 1: GetPayrollData
Alter PROCEDURE GetPayrollData
    @Month INT,
    @Year INT
AS
BEGIN
    SELECT 
        E.FirstName + ' ' + E.LastName AS EmployeeName,
        E.Salary ,
        ISNULL(B.TotalBonus, 0) AS TotalBonus,
        ISNULL(D.TotalDeductions, 0) AS TotalDeductions
    FROM Employees E
    LEFT JOIN (
        SELECT EmployeeId, SUM(Amount) AS TotalBonus
        FROM Bonuses
        WHERE MONTH(CreatedAt) = @Month AND YEAR(CreatedAt) = @Year
        GROUP BY EmployeeId
    ) B ON E.EmployeeId = B.EmployeeId
    LEFT JOIN (
        SELECT EmployeeId, SUM(Amount) AS TotalDeductions
        FROM Deductibles
        WHERE MONTH(Date) = @Month AND YEAR(Date) = @Year
        GROUP BY EmployeeId
    ) D ON E.EmployeeId = D.EmployeeId
END
GO



select * from Employees
select * from Payroll
select * from Positions
select * from Attendance
select * from Deductibles
select * from Bonuses

delete from payroll
