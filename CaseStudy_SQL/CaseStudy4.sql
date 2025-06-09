-- CaseStudy4

use master

create database dbCompany

use dbCompany

--Main table creation

create table Employees(
EmpID int primary key,
EmpName varchar(100),
Department varchar(50),
Salary decimal(10,2)
);

--Audit table creation

create table EmployeeAuditLog(
LogID int identity(1,1) primary key,
EmpID int,
EmpName varchar(100),
Department varchar(50),
Salary decimal(10,2),
ActionType varchar(10),
ActionDate datetime default getdate()
);


--3 INSERT trigger creation

create trigger trg_AfterInsertEmployees_audit
on Employees
after insert
as
begin
set nocount on;
insert into EmployeeAuditLog(EmpID,EmpName,Department,Salary,ActionType,ActionDate)
select i.EmpID, i.EmpName, i.Department, i.Salary,'INS',getdate() from INSERTED i
end

--4 DELETE trigger creation
create trigger trg_AfterDeleteEmployees_audit
on Employees
after delete
as 
begin
set nocount on;
insert into EmployeeAuditLog(EmpID,EmpName,Department,Salary,ActionType,ActionDate)
select EmpID,EmpName,Department,Salary,'DEL',getdate() from DELETED
end

--5,6 testing the triggers
insert into Employees (EmpID, EmpName, Department, Salary)
values (101, 'Gokul R', 'IT', 50000.00),(102, 'Anu M', 'HR', 40000.00);

delete from Employees where EmpID = 102

select * from EmployeeAuditLog
select * from Employees