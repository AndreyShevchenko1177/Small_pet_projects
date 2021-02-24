

use AdventureWorks2017
go

select * from sys.tables
go


select * from Person.Address

select * from Person.Person
go


select FirstName, LastName,PersonType, Title from Person.Person where title='Mr.'
select count (*) as cnt from Person.Person where title='Mr.' 
go



select 'Mr.' as title,  count (*) as cnt_MrMs, PersonType from Person.Person 
where title='Mr.' group by PersonType
union all
select 'Ms' as title, count (*) as cnt_MrMs8888888888888, PersonType from Person.Person 
where title='Ms.' group by PersonType
order by cnt_MrMs desc
go

/* посмотреть все таблицы*/
select * from sys.tables 
go

select schema_id as [Schema ID], SCHEMA_NAME(schema_id) as [Name of schema], name as [Name of table] from sys.tables 
where schema_id=SCHEMA_ID('Person')
go

 

/* посмотреть все схемы*/
select * from sys.schemas
go



select * from sys.tables where ((schema_id>=5) and (schema_id<=6)) order by schema_id, name
go

select * from sys.tables where schema_id between 5 and 6 order by schema_id, name
go

select * from sys.tables where schema_id in (5, 6, 8) order by schema_id, name
go

select * from sys.all_columns where object_id=(object_id('Person.Address'))
go


select * from Person.Address where city = 'MIami' or city = 'Bothell'
go

select * from Person.Address where city IN ('MIami', 'Bothell') order by City
go

/*а есть ли там лосангелес*/
select * from Person.Address where city like 'Los%' order by AddressLine1
go

/* два резалт сета в 1*/
select OBJECT_NAME('1029578706') 
union all 
select OBJECT_NAME('1333579789') 
go

select top(100) * from Person.Address order by AddressLine1
go



select * from Person.Address
go



select SCHEMA_Name(6)

select SCHEMA_ID('HumanResources')

select city  , count (city) as  [count of city] from Person.Address 
	where postalcode <> '59140' group by  City order by [count of city] desc
go

select city  , count (city) as  [count of city] from Person.Address 
	 group by  City order by [count of city] desc
go



select distinct city from Person.Address       order by city
go
/* the same */
select city from Person.Address group by city    order by city
go





select count (t.City) as  [count of city] from (
	select distinct city from Person.Address
	)  as t
go
/*the same*/
select count(distinct city) from Person.Address
go
/*the same*/


drop table if exists #count_city_table
create table #count_city_table (
	city nvarchar(30) not null
	)

insert #count_city_table select city from Person.Address group by city  
select * from #count_city_table
select count (*) from #count_city_table
drop table #count_city_table
go







/*  having & union ---- надо делать подзапрос
select 'Mr.' as title,  count (*) as cnt_MrMs, PersonType from Person.Person 
where title='Mr.' group by PersonType
union all
select 'Ms' as title, count (*) as cnt_MrMs8888888888888, PersonType from Person.Person 
where title='Ms.' group by PersonType

having cnt_MrMs>100
order by cnt_MrMs desc
*/

