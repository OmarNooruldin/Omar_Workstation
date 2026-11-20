select *
from employees


select *
from departments


select *
from locations



select last_name, department_id
from employees
where department_id in (30,60,90)
order by department_id 



declare @low_s int = 5000
declare @high_s int= 7000
select *
from employees
where salary between @low_s and @high_s



select last_name, UPPER(last_name) as Name_in_u, lower(last_name) as Name_in_l
from employees
where department_id = 30 



select department_id , COUNT(employee_id) as No_Of_Employees, MAX(salary) as Maximum_s ,
                                              MIN(salary) as Minmum_s ,
											  SUM(salary) as Sum_s ,
											  AVG(salary) as avg_s 

from employees
group by department_id



select department_id , COUNT(employee_id) as No_Of_Employees, MAX(salary) as Maximum_s ,
                                                              MIN(salary) as Minmum_s ,
											                  SUM(salary) as Sum_s ,
											                  AVG(salary) as avg_s 
from employees
group by department_id
having  COUNT(employee_id)>=10 



select  department_id , COUNT(employee_id) as no_of_employees
from employees
where   salary>=5000
group by  department_id



select  department_id , COUNT(employee_id) as no_of_employees
from employees
where   salary>=5000
group by  department_id
having count(employee_id)>=3 



select last_name, case 
                 when salary between 10000 and 12000 then 'high salary'
                 when salary between 12001 and 14000 then 'very high salary'
				 else 'extreme high salary'
				 end as Salary_Level
from employees
where salary>=10000
order by salary desc



select last_name, IIF(salary>=10000,'High Salary','Normal Salary') as Salary_Level 
from employees
order by salary



select concat(first_name,last_name) , commission_pct,
IIF(commission_pct is not null , 'Have Commision','No Commision') as Commision
from employees
order by commission_pct




select first_name, hire_date ,
GETDATE() as Today,
DATEDIFF(YEAR,hire_date,GETDATE()) as Years_worked ,
year(hire_date) as Hire_Year
from employees
order by Years_worked



select last_name, salary, CAST(salary as varchar)+' $' as salary_in_dollar
from employees
order by salary



select last_name, 
                  CAST(salary as varchar)+' $' as salary_in_dollar,
				  DATEDIFF(Year,hire_date,GETDATE()) as worked_year,
				  CONVERT(varchar(10),hire_date,103) as Formatted_Date
from employees
order by salary




select e.last_name, d.department_name , l.street_address  ,l.city
from employees e
join departments d on e.department_id=d.department_id
join locations l on d.location_id=l.location_id


select e.last_name, d.department_name 
from employees e
left join departments d on e.department_id=d.department_id


select e.last_name, d.department_name 
from employees e
right join departments d on e.department_id=d.department_id


select e.last_name, d.department_name 
from employees e
full outer join departments d on e.department_id=d.department_id




select e.job_id ,e.job_id , count(e.employee_id), sum(salary),Max(salary),Min(salary),avg(salary)
from employees e join jobs j on e.job_id=j.job_id
where j.job_id in ('IT_PROG', 'SA_MAN', 'FI_ACCOUNT', 'HR_REP','AD_VP')
group by e.job_id
having sum(salary) >= 5000
order by sum(salary)


select e.job_id  , count(*), sum(salary),Max(salary),Min(salary),avg(salary)
from employees e 
where e.job_id in ('IT_PROG', 'SA_MAN', 'FI_ACCOUNT', 'HR_REP','AD_VP')
group by e.job_id
having sum(salary) >= 5000
order by sum(salary)