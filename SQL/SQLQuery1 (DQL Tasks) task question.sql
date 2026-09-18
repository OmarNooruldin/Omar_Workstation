select e.job_id,COUNT(e.employee_id) as No_Of_Employees,
sum(e.salary) as SUM_S,
MIN(e.salary) as MIN_S,
MAX(e.salary) as MAX_S,
AVG(e.salary) as AVG_S
from employees e
where e.job_id in ('IT_PROG','SA_MAN','FI_ACCOUNT','HR_REP','AD_VP')
group by e.job_id
having SUM(e.salary) > 5000
order by SUM(e.salary)


select e.employee_id,e.job_id,
CASE 
        WHEN job_id = 'AD_PRES' Then 'A'
        WHEN job_id = 'ST_MAN' Then 'B'
		WHEN job_id = 'IT_PROG' Then 'C'
		WHEN job_id = 'SA_REP' Then 'D'
		WHEN job_id = 'ST_CLERK' Then 'E'
		  ELSE '0'
    END AS Grade
from employees e
order by Grade