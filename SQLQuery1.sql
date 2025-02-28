-- Create the Company Database
CREATE DATABASE Company;
GO
 
-- Use the Company Database
USE Company;
GO
 
-- Create the Employee Table
CREATE TABLE Employee (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Salary DECIMAL(18,2) NOT NULL,
    DepartmentID INT NOT NULL
);
GO

INSERT INTO Employee (FirstName, LastName, Salary, DepartmentID)
VALUES
('John', 'Doe', 60000.00, 1),
('Jane', 'Smith', 75000.00, 2),
('Bill', 'Gates', 150000.00, 1),
('Elon', 'Musk', 200000.00, 3),
('Steve', 'Jobs', 120000.00, 3),
('Mark', 'Zuckerberg', 110000.00, 2),
('Satya', 'Nadella', 180000.00, 1),
('Sundar', 'Pichai', 190000.00, 2),
('Tim', 'Cook', 130000.00, 3),
('Sheryl', 'Sandberg', 95000.00, 2),
('Larry', 'Page', 220000.00, 1),
('Sergey', 'Brin', 220000.00, 1),
('Jeff', 'Bezos', 230000.00, 3),
('Warren', 'Buffett', 100000.00, 2),
('Richard', 'Branson', 110000.00, 1);