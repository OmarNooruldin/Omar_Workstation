select first_name + ' ' + last_name as 'full name', phone_number, salary , salary*12 as 'annual salary' , job_id
from employees
where job_id = 'IT_PROG'

select * 
from employees
where commission_pct is not null 

select * 
from employees
where first_name like '_o%'

select * 
from employees
where salary >= 2500 And salary <= 8000

select * 
from employees
where salary between 2500 And 8000

select * 
from employees
where hire_date between '1998-01-01' and '2000-01-01'
order by hire_date desc

select * 
from employees
order by hire_date desc , first_name

declare @job nvarchar(20)='IT_PROG'
select * 
from employees
where job_id = @job 

declare @low_salary int = 5000;
declare @high_salary int = 8000;
select last_name , salary
from employees
where salary between @low_salary and @high_salary
order by salary

select UPPER(last_name) as 'Name in capital letters',LOWER(Job_id) as job , LEN(Last_name) as 'Name' 
from employees
order by 'Name in capital letters'

select UPPER(last_name) as 'Name in capital letters',LOWER(Job_id) as job , LEN(Last_name) as 'Name' 
from employees
order by 'Name'

select first_name, salary , 
 case     
 when salary >=10000 then 'High'
 when salary between 5000 and 9999 then 'Medium'
 else 'Low' 
 end as Salary_Level
from employees
order by salary

select first_name, salary , IIF(salary >= 10000, 'Top','Normal') as Salary_Level
from employees
order by salary desc

select first_name, commission_pct , IIF(commission_pct>0 , 'Has Commision','No Commision') as Commision_status
from employees
order by Commision_status 

select first_name, commission_pct , IIF(commission_pct is not null , 'Has Commision','No Commision') as Commision_status
from employees
order by Commision_status 


select salary , cast(salary as varchar) as Salary_Text , CONVERT(varchar(10), hire_date,103) as Formatted , hire_date
from employees


select first_name, hire_date , GETDATE() as Today, DATEDIFF(YEAR,hire_date,GETDATE()) as Days_worked , year(hire_date) as Hire_Year
from employees


select  COUNT(*), sum(salary)
from employees


select Count(department_id), COUNT(*), sum(salary)
from employees


select distinct department_id 
from employees



select distinct department_id, sum(salary) as sum_Of_Salary
from employees
group by department_id 



select department_id, COUNT(*), sum(salary)
from employees
group by department_id 
having COUNT(department_id)>=10



select department_id, COUNT(*) as Num_of_employee_in_department, avg(salary) as average_salary
from employees
group by department_id 
having AVG(salary) > 6000


select * 
from departments

select * 
from employees


select last_name, department_name
from employees e, departments d
where e.department_id=d.department_id


select e.last_name, d.department_name
from employees e join departments d on e.department_id=d.department_id


select e.last_name, d.department_name , l.city
from employees e
join departments d on e.department_id=d.department_id 
join locations l on d.location_id=l.location_id
where last_name like 'A%'


select e.last_name, j.job_title
from employees e cross join jobs j
where e.job_id = j.job_id 





