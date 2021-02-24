
use AdventureWorks2017
go


/*
select from 
where 
group by 
having
order by
*/



select LoginID  from HumanResources.Employee
select distinct LoginID from HumanResources.Employee
go
join

declare @n1 int, @n2 int
select @n1 = count (LoginID)  from HumanResources.Employee 
select @n2 = count (distinct LoginID) from HumanResources.Employee
if(@n1 = @n2) print 'Equal' else print 'Not equal'
go

select year (BirthDate) as [Year of birth], count (year (BirthDate)) from HumanResources.Employee group by year (BirthDate)
go

select count(distinct Gender) from HumanResources.Employee
select JobTitle, BirthDate, Gender from HumanResources.Employee where Gender='M' and JobTitle like '%manager%' order by JobTitle
go

select top 100 * from HumanResources.Employee
go

select count (JobTitle) as [namber of managers], gender from HumanResources.Employee 
	where JobTitle like '%manager%' and Gender='m' group by Gender
union all
select count (JobTitle) as [namber of managers], gender from HumanResources.Employee 
	where JobTitle like '%manager%' and Gender='f' group by Gender
go

select  JobTitle, gender, count (JobTitle) as [namber of managers] from HumanResources.Employee 
	where  Gender='m' group by JobTitle, Gender
union all
select  JobTitle, gender, count (JobTitle) as [namber of managers] from HumanResources.Employee 
	where  Gender='f' group by JobTitle, Gender
go

select  JobTitle, gender, count (JobTitle) as [namber of managers] from HumanResources.Employee 
	 group by JobTitle, Gender order by JobTitle, Gender desc


go

select  JobTitle, gender, HireDate, year (getdate()) - year (HireDate) as [how long works (years)] from HumanResources.Employee 
	where (year (getdate()) - year (HireDate)) >=10 order by [how long works (years)] desc
go

/* в отдельную таблицу всех, кто долше 10 лет работает*/
drop table if exists #jobtitle_mf
create table #jobtitle_mf (
	JobTitle nvarchar(50) not null,
	gender nchar (1) not null,
	HireDate date not null,
	works_years int not null
	)
insert #jobtitle_mf select  JobTitle, gender, HireDate, (year (getdate()) - year (HireDate))  from HumanResources.Employee 
	where (year (getdate()) - year (HireDate)) >=10 
select * from #jobtitle_mf
go

select count(*) as [count peple], works_years  from #jobtitle_mf group by works_years  order by works_years desc
go




select top 10 LoginID, JobTitle, VacationHours from HumanResources.Employee order by VacationHours desc
go

select top 10 LoginID, JobTitle,  SickLeaveHours   from HumanResources.Employee order by SickLeaveHours
go


select  * from HumanResources.Employee
select * from Person.Person  
select * from [Person].[Address]
select * from [Person].[BusinessEntityAddress]

/*10 самых отдыхающих и 10 самых не больных*/
select t4.BusinessEntityID, t4.FirstName, t4.MiddleName, t4.LastName,  
				t4.JobTitle, t4.VacationHours, t4.SickLeaveHours, t4.Vacation_OR_Sick,
				t4.AddressLine1, t4.AddressLine2, t4.City
from (
	select pers.BusinessEntityID, pers.FirstName, pers.MiddleName, pers.LastName,  t3.JobTitle, 
			t3.VacationHours, t3.SickLeaveHours, t3.Vacation_OR_Sick,
			adress.AddressLine1, adress.AddressLine2, adress.City
	from (
				select t.BusinessEntityID, t.LoginID, t.JobTitle, t.VacationHours, t.SickLeaveHours, t.Vacation_OR_Sick   
					from( select top 10 BusinessEntityID, LoginID, JobTitle, VacationHours, SickLeaveHours, 'most_Vacation' as [Vacation_OR_Sick] 
							from HumanResources.Employee 
							order by VacationHours desc
					)as t
				union all
				select t2.BusinessEntityID, t2.LoginID, t2.JobTitle, t2.VacationHours, t2.SickLeaveHours, t2.Vacation_OR_Sick   
					from( select top 10 BusinessEntityID, LoginID, JobTitle, VacationHours, SickLeaveHours, 'least _Sick' as [Vacation_OR_Sick] from HumanResources.Employee 
							order by SickLeaveHours
					)as t2
			) as t3
	join Person.Person as pers on t3.BusinessEntityID=pers.BusinessEntityID
	join Person.BusinessEntityAddress as adrID on adrID.BusinessEntityID=t3.BusinessEntityID
	join Person.Address as adress on adress.AddressID=adrID.AddressID
) as t4

--group by t4.City
order by t4.Vacation_OR_Sick,  t4.JobTitle
go

select count(*), city from Person.Address group by City
go


select * from HumanResources.Employee 
select * from Person.Person
go

select Pers.BusinessEntityID, HumanResources.Employee.LoginID, Pers.FirstName, Pers.LastName   
from Person.Person as pers
left  join HumanResources.Employee  on pers.BusinessEntityID= HumanResources.Employee.BusinessEntityID
where LoginID is null
order by BusinessEntityID


go



/*
select 
from t1, t2
where t1.id=t2.id
*/

/*
select 
from t1.col, t2.col
join t2 on t1.col=t2.col
join t3 on t3.col=t1.col and t3.col=t2.col
--if needed where ....
group by (все из from)
order by 
go
*/



update HumanResources.Employee set VacationHours=100 where BusinessEntityID=234
go

/*
select from 
where 
group by 
having
order by
*/



/* агрегатные
count (*) - учитывает NULL
count ()
max ()
min ()
avg ()
sum ()
*/




select distinct City  from Person.Address where City like '%ari%'
go



select count (*) as cnt, addr.City   from Person.Address as addr 
--where addr.city <> 'London'
--where addr.city not like '%ondo%' and addr.City not like '%aris'
--where addr.city not in ('London', 'Paris')
group by addr.City
having count (*) >=100
order by cnt desc
go

-- в каком городе максимальное колво адресов
declare @i int
select @i =	 max (t1.cnt)  from 
			(
			select count(*) as cnt, addr.City from Person.Address as addr group by addr.City 
			) as t1

select count(*) as cnt, addr.City from Person.Address as addr 
	group by addr.City 
	having count(*)=@i

go


-- в каком городе максимальное колво адресов - VAR 2
select top 1 count(*) as cnt, addr.City from Person.Address as addr group by addr.City order by count(*) desc
go


-- в каком городе максимальное колво адресов - VAR 3
select t.cnt, t.City from(
  select count(*) as cnt, city from Person.Address  group by city
  ) t
  where t.cnt = (select max(cnt) from 
								(select count(*) as cnt, city from Person.Address  group by city) t2
				)
go



-- в каком городе максимальное колво адресов - VAR 3 
-- но не показывает город
select max (t1.cnt)  from 
	(
	select count(*) as cnt, addr.City from Person.Address as addr group by addr.City 
	) as t1
go




select max (VacationHours)  as MAXvacation, Gender, 'maxvac' as attribute  from HumanResources.Employee group by gender
union all
select min (SickLeaveHours)  as MINsick, Gender, 'minsick'  from HumanResources.Employee group by gender
order by attribute, Gender
go

	select avg (VacationHours)  as AVGvacation, Gender, 'avgvac' as attribute  from HumanResources.Employee group by gender
	union all
	select avg (SickLeaveHours)  as AVGsick, Gender, 'avgick'  from HumanResources.Employee group by gender
union all
	select avg (VacationHours)  as AVGvacation, 'f/m', 'avgvac' as attribute  from HumanResources.Employee
	union all
	select avg (SickLeaveHours)  as AVGsick, 'f/m', 'avgsick'  from HumanResources.Employee 
order by attribute, Gender
go


select count (*), Gender   from HumanResources.Employee group by Gender
go











select * from sys.tables

select * from sys.all_columns where name Like 'name'

select * from sys.check_constraints

select * from sys.objects where object_id=14623095
select * from sys.objects where object_id=1922105888
select * from sys.schemas  where schema_id=9


select  object_name(object_id) as TableName, * from sys.all_columns 
--where object_id=(object_id('Person.Address'))
where name = 'BusinessEntityID'
go


select  * from HumanResources.Employee
select * from Person.Person  
select * from [Person].[Address]
select * from [Person].[BusinessEntityAddress]
go

--US MX CA
select *  from Person.CountryRegion where CountryRegionCode in('us', 'mx', 'ca')
go

select Person.StateProvince.StateProvinceCode,  Person.StateProvince.name, 
	Person.StateProvince.CountryRegionCode, Person.CountryRegion.Name
from Person.StateProvince 
left join Person.CountryRegion 
	on Person.StateProvince.CountryRegionCode = Person.CountryRegion.CountryRegionCode
--where Person.StateProvince.CountryRegionCode in ('us', 'mx', 'ca')
order by Person.StateProvince.name
go

-- сколько адресов в каждом городе в US CA MX, и клиенты и сотрудники - все			
select count(AddressLine1) as NumOFAddr, Person.Address.City, t1.StateProvinceID, t1.StateProvinceCode,
	t1.provname, t1.country
from Person.Address  
inner join (
			select Person.StateProvince.StateProvinceCode,  Person.StateProvince.name as provname, 
				Person.StateProvince.CountryRegionCode, Person.CountryRegion.Name as country, Person.StateProvince.StateProvinceID
			from Person.StateProvince 
			left join Person.CountryRegion 
				on Person.StateProvince.CountryRegionCode = Person.CountryRegion.CountryRegionCode
			where Person.StateProvince.CountryRegionCode in ('us', 'mx', 'ca')
			) t1
		on [Person].[Address].[StateProvinceID] = t1.StateProvinceID

group by Person.Address.City, Person.Address.City, t1.StateProvinceID, t1.StateProvinceCode,
	t1.provname, t1.country
order by t1.country, t1.provname, Person.Address.City
go			

	

select distinct Person.StateProvince.StateProvinceCode from Person.StateProvince 
select distinct Person.CountryRegion.CountryRegionCode from Person.CountryRegion 
go

select distinct * from [Production].[Product]
select distinct * from [Production].[ProductCostHistory]
go

select prod_name.ProductID, prod_name.name, prod_cost.StandardCost
from [Production].[Product] as prod_name
 right join [Production].[ProductCostHistory] as prod_cost on   prod_cost.ProductID = prod_name.ProductID
 group by prod_name.ProductID, prod_name.name, prod_cost.StandardCost
go

select prod_cost.ProductID, max (prod_cost.StandardCost), min (prod_cost.StandardCost) from [Production].[ProductCostHistory] as prod_cost
group by prod_cost.ProductID
order by prod_cost.ProductID



select prod_name.ProductID, prod_name.name, 
	max (prod_cost.StandardCost) as 'Max_Cost', min (prod_cost.StandardCost) as 'MinCost'
from [Production].[Product] as prod_name
 right join [Production].[ProductCostHistory] as prod_cost on   prod_cost.ProductID = prod_name.ProductID
 --left join 
 group by prod_name.ProductID, prod_name.Name 
 --having max (prod_cost.StandardCost) is not null
 order by prod_name.ProductID
 go

 select prod_name.ProductID, prod_name.name, 
	max (prod_cost.StandardCost) as 'Max_Cost', min (prod_cost.StandardCost) as 'MinCost',
	prod_quant.Quantity, (prod_quant.Quantity*(max (prod_cost.StandardCost) - min (prod_cost.StandardCost))) as Profit
from [Production].[Product] as prod_name
 right join [Production].[ProductCostHistory] as prod_cost on   prod_cost.ProductID = prod_name.ProductID 
 left join [Production].[ProductInventory] as prod_quant on prod_cost.ProductID = prod_quant.ProductID
 group by prod_name.ProductID, prod_name.Name, prod_quant.Quantity
 order by prod_name.ProductID
 go


 select sum (tt.Profit) as 'Total Profit' from
(
 select prod_name.ProductID, prod_name.name, 
	max (prod_cost.StandardCost) as 'Max_Cost', min (prod_cost.StandardCost) as 'MinCost',
	prod_quant.Quantity, (prod_quant.Quantity*(max (prod_cost.StandardCost) - min (prod_cost.StandardCost))) as Profit
from [Production].[Product] as prod_name
 right join [Production].[ProductCostHistory] as prod_cost on   prod_cost.ProductID = prod_name.ProductID 
 left join [Production].[ProductInventory] as prod_quant on prod_cost.ProductID = prod_quant.ProductID
 group by prod_name.ProductID, prod_name.Name, prod_quant.Quantity
) as tt
 go


select prod.ProductID, prod.Name, hist.EndDate    from [Production].[Product] as prod
left join [Production].[ProductCostHistory] as hist on prod.ProductID = hist.ProductID
where exists (select ProductID from [Production].[ProductCostHistory] as hist2 
				where prod.ProductID=hist2.ProductID and hist2.EndDate is null)
group by prod.ProductID, prod.Name, hist.EndDate
order by prod.ProductID
go

select  prodprice.ProductID, prodname.Name, prodprice.StandardPrice, vendor.Name  from  [Purchasing].[ProductVendor] as prodprice 
	join [Production].[Product] as prodname on prodname.ProductID = prodprice.ProductID
	join [Purchasing].[Vendor] as vendor on prodprice.BusinessEntityID = vendor.BusinessEntityID
	where (StandardPrice > 10) and vendor.Name like 'f%'
	order by prodprice.ProductID
go

select salper.BusinessEntityID, ppers.FirstName, ppers.LastName, ppers.MiddleName, perphone.PhoneNumber, salper.TerritoryID, 
		salter.CountryRegionCode, salter.name
from [Sales].[SalesPerson] as salper 
join [Sales].[SalesTerritory] as salter on salter.TerritoryID = salper.TerritoryID
join [Person].[Person] as ppers on ppers.BusinessEntityID = salper.BusinessEntityID
join [Person].[PersonPhone] as perphone on perphone.BusinessEntityID = salper.BusinessEntityID
	where salter.name in ('Canada', 'Australia')
go

/* SELECT statement built using a subquery. */
SELECT Name, ListPrice
FROM Production.Product
WHERE ListPrice =
    (SELECT ListPrice
     FROM Production.Product
     WHERE Name = 'Chainring Bolts' );
GO

/* SELECT statement built using a join that returns
   the same result set. */
SELECT Prd1.Name
FROM Production.Product AS Prd1
     JOIN Production.Product AS Prd2
       ON (Prd1.ListPrice = Prd2.ListPrice)
WHERE Prd2. Name = 'Chainring Bolts';
GO


SELECT LastName, FirstName
FROM Person.Person
WHERE BusinessEntityID IN
    (SELECT BusinessEntityID
     FROM HumanResources.Employee
     WHERE BusinessEntityID IN
        (SELECT BusinessEntityID
         FROM Sales.SalesPerson)
    );
go


/* задание:   вывести информацию о всех сотрудниках из отделов Sales и Marketing
отделы - в таблице [HumanResources].[Department]
*/

select * from INFORMATION_SCHEMA.COLUMNS 
where COLUMN_NAME like '%DepartmentID%'
order by TABLE_NAME
go

select HumanResources.EmployeeDepartmentHistory.BusinessEntityID, count(*) from [HumanResources].[EmployeeDepartmentHistory] 
	group by HumanResources.EmployeeDepartmentHistory.BusinessEntityID having count(*) > 1
go

select * from [HumanResources].[EmployeeDepartmentHistory] 
	where HumanResources.EmployeeDepartmentHistory.BusinessEntityID = 1
go

select empl.BusinessEntityID, pers.FirstName, pers.LastName, depart.DepartmentID, depart.Name,
	depathist.StartDate, depathist.EndDate
	from [HumanResources].[Employee] as empl 
	join [Person].[Person] as pers on empl.BusinessEntityID=pers.BusinessEntityID
	join HumanResources.EmployeeDepartmentHistory as depathist on depathist.BusinessEntityID=pers.BusinessEntityID and depathist.EndDate IS NULL
	join HumanResources.Department as depart on depart.Name in ('Sales', 'Marketing')
	
order by empl.BusinessEntityID

go



/*
[Production].[Illustration]
[Production].[ProductModelIllustration]
[Production].[ProductModel]
show all product models with illustrations and catalog descriptions
*/

	
select  prodmodillus.ProductModelID, count (ilustr.IllustrationID) as namber_of_illus, prodmod.Name/*, prodmod.CatalogDescription*/
		from 	[Production].[Illustration] as ilustr 
    join  [Production].[ProductModelIllustration] as prodmodillus on ilustr.IllustrationID = prodmodillus.IllustrationID
	join [Production].[ProductModel] as prodmod on prodmodillus.ProductModelID = prodmod.ProductModelID	
	group by prodmodillus.ProductModelID, prodmod.Name 
	order by prodmodillus.ProductModelID
go
		
select pmi.ProductModelID, pm.name, pm.CatalogDescription, i.Diagram from [Production].[ProductModelIllustration] pmi
join [Production].[ProductModel] pm on pmi.ProductModelID = pm.ProductModelID
join [Production].[Illustration] i on pmi.IllustrationID = i.IllustrationID
where pm.CatalogDescription is not null or i.Diagram is not null		
go



/*
[Production].[Illustration]
[Production].[ProductModelIllustration]
[Production].[ProductModel]
show all product models with illustrations OR catalog descriptions
*/