
use workdb
go



create table customers(
	id		int		identity not null,
	name	varchar(50) not null,
	city	varchar(50) default 'unknown',
	phone	char(13) default 'unknown'
)
go

alter table customers2 add constraint pk_customers2 primary key (id)
go

alter table customers add constraint col_city_def default 'unknown' for city
alter table customers add constraint col_phone_def default 'unknown' for phone


alter table customers2 add constraint uq_customers unique (phone)

go

insert customers values ('Asd', 'Kharkov', '+380981234567')
go

insert customers values ('qwe', 'Kyiv', '223355')
select * from customers
go

alter table customers2 drop constraint uq_customers



drop table customers
go

delete from customers where id>1000
select * from customers
go




select * from customers

select db_id('workdb')

select * from sys.dm_db_log_info(db_id('workdb'))

select * from sys.dm_exec_sql_text(

select * from sys.dm_exec_requests

select * from sys.dm_exec_query_stats


SELECT *
FROM
        sys.dm_exec_requests r
CROSS APPLY
        sys.dm_exec_sql_text(r.sql_handle) AS t
CROSS APPLY     
        sys.dm_exec_query_plan(r.plan_handle) AS p


SELECT t.[text]
FROM sys.dm_exec_cached_plans AS p
CROSS APPLY sys.dm_exec_sql_text(p.plan_handle) AS t
where t.[text] like '%customers%'



create table customers2(
	id		int		identity(1, 1) not null,
	name	varchar(50) not null,
	city	varchar(50) default 'unknown',
	phone	char(13) default 'unknown'
)
go

insert customers2 values ('qwe', 'Kyiv', '223355')
select * from customers2
go

update customers2 set phone=stuff (phone,13,1,cast(id as char(1)))
