--DML--

insert into MyDepts (Dept_ID,Dept_name)
             values (3     , 'Back_End'    )


select * 
from MyDepts 
-------------------------------------------------------------------------------------------

insert into emp3 (emp_id,emp_name,email,phone_no)
          values (2     , 'Ahmed' ,'ahmednaji',123456789000)

select * 
from emp3
-------------------------------------------------------------------------------------------

insert into MyEmps (Emp_ID,Emp_name,salary,hire_date,Dept_ID)
            values (2   ,'Omar'  ,15000 ,'2026-01-06-', 1    )

update Myemps 
set hire_date = '2025-07-16', salary = 13000, Dept_ID = 3,Emp_name = 'Ahmed'
where Emp_ID = 2


delete from Myemps 
where Emp_id = 2


select * 
from MyEmps
