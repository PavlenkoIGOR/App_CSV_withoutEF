--create database App_CSV_withoutEF

use App_CSV_withoutEF
go

--CREATE TABLE users 
--( 
--    id int identity(1,1) primary key not null, 
--    username varchar(50) not null, 
--    userlastname varchar(50) not null, 
--    usersurname varchar(50) not null, 
--    userbirthdate Date not null, 
--    passportserial int not null, 
--    passportnumber int not null, 
--    organization_id int, 
--    FOREIGN KEY (organization_id) REFERENCES dbo.organization(id) 
--);

--alter table users
--add constraint User_Passport UNIQUE (passportserial, passportnumber);

--create table organization
--(
--	id int identity(1,1) primary key not null,
--	title varchar(250) not null,
--	inn varchar(100) not null,
--	uradress varchar(250) not null,
--	factaddress varchar(250) not null
--)

--alter table organization
--add constraint Organization_Inn UNIQUE (inn);

--EXEC sp_rename 'organization', 'organizations';

--insert into organizations (title, inn, uradress, factaddress)
--values 
--(
--	'Best Organization',
--	'123456-asd',
--	'юр адрес',
--	'факт адрес'
--)

--insert into users(username, userlastname, usersurname, userbirthdate, passportserial, passportnumber, organization_id)
--values 
--(
--	'сотрудник_1',
--	'фамилия сотрудника_1',
--	'отчество сотрудника_1',
--	CONVERT(date, '01-01-2000', 104),
--	1234,
--	567890,
--	1
--)

select * from dbo.users
--select * from dbo.organizations

--insert into organizations (title, inn, uradress, factaddress)
--values 
--(
--	'New Corp',
--	'1-as-32121',
--	'юр адрес 111',
--	'факт адрес 222'
--)