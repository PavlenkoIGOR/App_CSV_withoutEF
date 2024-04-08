--create database App_CSV_withoutEF

use App_CSV_withoutEF
go

create table users 
(
	id int identity(1,1) primary key not null,
	username varchar(50) not null,
	userlastname varchar(50) not null,
	usersurname varchar(50) not null,
	userbirthdate Date not null
)