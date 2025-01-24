# Payroll Management System

![Payroll Management System](https://img.shields.io/badge/Status-Development-informational)  
![C#](https://img.shields.io/badge/Language-C%23-blue)  
![SQL](https://img.shields.io/badge/Database-SQL-orange)

The Payroll Management System is a Windows Forms application built in C# for managing employee payrolls. It allows users to generate pay slips, manage employee details, and store data in a SQL database.

---

## Features
- **Employee Management**: Add, update, and view employee details.
- **Pay Slip Generation**: Generate and export pay slips for employees.
- **Database Integration**: Store and retrieve data using a SQL database.
- **User-Friendly Interface**: Simple and intuitive UI for ease of use.

---

## Prerequisites
Before running the application, ensure you have the following installed:
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) (version 4.7.2 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) (2019 or later recommended)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any compatible SQL database system)

---

## Setup Instructions

### 1. Clone the Repository
Clone this repository to your local machine using Git:
```bash
git clone https://github.com/your-username/payroll-management-system.git
cd payroll-management-system
2. Set Up the Database
Open SQL Server Management Studio (SSMS) or your preferred SQL client.

Create a new database named PayrollDB.

Run the provided SQL script (PayrollDB.sql) to create the necessary tables and populate initial data:

sql
Copy
-- Example SQL script (PayrollDB.sql)
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Salary DECIMAL(18, 2) NOT NULL
);

INSERT INTO Employees (FirstName, LastName, Email, Salary)
VALUES ('John', 'Doe', 'john.doe@example.com', 50000.00),
       ('Jane', 'Smith', 'jane.smith@example.com', 60000.00);
3. Configure the Connection String
Update the connection string in the app.config file to match your SQL Server instance:

xml
Copy
<connectionStrings>
    <add name="PayrollDBConnection" 
         connectionString="Server=your-server-name;Database=PayrollDB;Integrated Security=True;"
         providerName="System.Data.SqlClient" />
</connectionStrings>
Run HTML
4. Build and Run the Application
Open the solution file (PayrollApp.sln) in Visual Studio.

Build the solution by pressing Ctrl + Shift + B.

Run the application by pressing F5.
