--create database App_CSV_withoutEF

use App_CSV_withoutEF
go

--create table organization
--(
--	id int identity(1,1) primary key not null,
--	title varchar(250) not null,
--	inn varchar(100) not null,
--	uradress varchar(250) not null,
--	factaddress varchar(250) not null
--)

--CREATE TABLE users 
--( 
--    id int identity(1,1) primary key not null, 
--    username varchar(50) not null, 
--    userlastname varchar(50) not null, 
--    usersurname varchar(50) not null, 
--    userbirthdate Date not null, 
--    passportserial varchar(10) not null, 
--    passportnumber varchar(10) not null, 
--    organization_id int, 
--    FOREIGN KEY (organization_id) REFERENCES dbo.organizations(id) 
--);

--alter table users
--add constraint User_Passport UNIQUE (passportserial, passportnumber);



--alter table organization
--add constraint Organization_Inn UNIQUE (inn);

--EXEC sp_rename 'organization', 'organizations';

--insert into organizations (title, inn, uradress, factaddress)
--values 
--(
--	'Best Organization',
--	'123456-asd',
--	'юр адрес Best Organization',
--	'факт адрес Best Organization'
--)

--insert into users(username, userlastname, usersurname, userbirthdate, passportserial, passportnumber, organization_id)
--values 
--(
--	'сотрудник_1',
--	'фамилия сотрудника_1',
--	'отчество сотрудника_1',
--	CONVERT(date, '01-01-2000', 104),
--	'1234',
--	'567890',
--	1
--)



--insert into organizations (title, inn, uradress, factaddress)
--values 
--(
--	'Co & LTM',
--	'street 1',
--	'юр адрес Co & LTM',
--	'факт адрес Co & LTM'
--)

--insert into users(username, userlastname, usersurname, userbirthdate, passportserial, passportnumber, organization_id)
--values 
--(
--	'Пётр',
--	'Петров',
--	'Петрович',
--	CONVERT(date, '11-11-2002', 104),
--	'1200',
--	'022022',
--	2
--)

delete from dbo.users
where id = 6

select * from dbo.users
--select * from dbo.organizations

--/*бинарный поиск*/
--WITH RECURSIVE BinarySearch AS (
--    SELECT 
--        MIN(id) AS start, 
--        MAX(id) AS end, 
--        @targetPassportSerial AS targetSerial, 
--        @targetPassportNumber AS targetNumber
--    FROM users
--    UNION ALL
--    SELECT 
--        CASE WHEN targetSerial <= (SELECT passportserial FROM users WHERE id = (start + (end - start) / 2)) THEN start ELSE (start + (end - start) / 2) + 1 END, 
--        CASE WHEN targetSerial >= (SELECT passportserial FROM users WHERE id = (start + (end - start) / 2)) THEN end ELSE (start + (end - start) / 2) - 1 END, 
--        targetSerial, 
--        targetNumber
--    FROM BinarySearch
--    WHERE start <= end
--)
--SELECT TOP 1 * FROM users
--WHERE passportserial = @targetPassportSerial AND passportnumber = @targetPassportNumber
--AND id IN (SELECT start FROM BinarySearch WHERE targetSerial = @targetPassportSerial AND targetNumber = @targetPassportNumber);