--ANS_1:-
select first_name + ' ' + last_name as Full_Name
from employees 


--ANS_2:-
select last_name, job_id,salary
from employees
where job_id='IT_PORG' and salary>5000 ;



--ANS_3:-
select first_name + ' ' + last_name as Full_Name, salary,hire_date
from employees 
where hire_date >='1998-01-01' and salary >=6000
order by hire_date 



--ANS_4:-
select AVG(salary) as Average_salary, department_id 
from employees 
Group by department_id
having AVG(salary) > 6000


--ANS_5:-
select job_id , COUNT(*) as No_Of_Employees
from employees 
Group by job_id


--ANS_6:-
select last_name , salary , 
CASE
     When salary>=12000 Then 'High'
	 When salary between 6000 and 11999 Then 'Medium'
	 Else 'Low'
	 End as Salary_Level
from employees
order by salary

---------------------------------------------------------------------------------
--JOIN SECETION 
--Ans_1:-
select e.first_name + ' ' +e.last_name as F_name, d.department_name
from employees e 
join departments d on e.department_id=d.department_id


--Ans_2:-
select e.first_name + ' ' +e.last_name as F_name,m.first_name + ' ' +m.last_name as F_Name_Manager
from employees e 
join employees m on e.manager_id=m.employee_id
order by F_name


--Ans_3:-
select d.department_name , e.employee_id
from departments d
LEFT join employees e on d.department_id=e.department_id
WHERE e.employee_id IS NULL


--Ans_4:-
select e.first_name + ' ' +e.last_name as F_name, d.department_name, l.city
from employees e 
join departments d on e.employee_id=d.department_id
join locations l on d.location_id=l.location_id


--Ans_5:-
select e.first_name + ' ' +e.last_name as F_name, j.job_id
from employees e 
CROSS JOIN jobs j


--Ans_6:-
select e.first_name + ' ' +e.last_name as F_name, d.department_name, l.city
from employees e 
FULL OUTER join departments d on e.employee_id=d.department_id
FULL OUTER join locations l on d.location_id=l.location_id
where l.city='Toronto'


--Ans_7:-
select * 
from employees
where salary > 12000
order by salary


--Ans_8:-
select * 
from employees
where salary NOT between 5000 and 12000
order by salary



--Ans_9:-
select * 
from employees
where job_id in ('SA_REP','ST_CLERK') AND salary NOT in (2500,3500,7000)
order by salary


--Ans_10:-
select UPPER(last_name) as Name_in_upper , LEN(last_name) as Length_name
from employees
where LEFT(last_name,1) in ('J','A','M')
order by last_name


--Ans_11:-
select e.first_name + ' ' +e.last_name as F_name, d.location_id, l.city,l.state_province,l.street_address
from employees e 
join departments d on e.employee_id=d.department_id
join locations l on d.location_id=l.location_id
order by l.city

-------------------------------------------------------------------------------------------------------------------------

--TASKS :-

select * 
from jobs
order by job_title


select job_id,COUNT(*) as No_Of_Employee
from jobs
Group by job_id 


select department_id,COUNT(*) as No_Of_Employee,
                     SUM(salary) as SUM_s,
                     MIN(salary) as MIN_s,
                     MAX(salary) as MAX_s,
                     AVG(salary) as AVG_s
from employees
Group by department_id



select job_id,COUNT(*) as No_Of_Employee
from jobs
Group by job_id 
having job_id in ('IT_PROG','SA_MAN','FI_ACCOUNT','HR_REP','AD_VP')



select e.last_name,e.salary,j.job_title
from employees e
JOIN jobs j on e.job_id=j.job_id
where e.salary>= 5000
order by salary



select *
from employees
