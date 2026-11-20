insert into courses1 (cours_id,course_title,price,duration) 
values (1,'SQL Server',1200,40)


insert into courses1 (cours_id,course_title,price,duration) 
values (2,'SQL',1500,60),
       (3,'Microsoft',900,80),
	   (4,'Query',1000,100),
	   (5,'DML',2999,120)

update courses1 
set Start_Date = '2026-7-29'
where cours_id = 1 


update courses1 
set Start_Date = GETDATE()
where cours_id = 3

update courses1 
set duration = 50
where course_title = 'SQL Server' 

update courses1 
set price = price + 100

update courses1 
set price = price + (price * 0.10)
where price < 1500


delete from courses1
where cours_id = 5

delete from courses1
where course_title = 'SQL Server'

delete from courses1
where price < 1000

delete from courses1
where  duration > 60


select *
from courses1

-----------------------------------------------------------------------------------------------------------

insert into projectss(project_id,project_name,client_name,hour_rate) 
values (101,'Hospital System','Al-Shifa Hospital',150)


insert into projectss(project_id,project_name,client_name,hour_rate) 
values (202,'Microsoft','SQL',60),
       (303,'create Table','DDL',80),
	   (404,'Query','DQL',100),
	   (505,'Insert data','DML',120)

update projectss 
set hour_rate= 1
where project_id = 101 

update projectss
set project_name = 'Create Table'
where project_id = 303 

update projectss 
set hour_rate = hour_rate + 20
where project_id = 202

update projectss
set hour_rate = hour_rate + (hour_rate * 0.10)
where hour_rate < 150


delete from projectss
where project_id = 505

delete from projectss
where project_id = 101


delete from projectss
where hour_rate = (select MIN(hour_rate) from projectss)

delete from projectss
where hour_rate < 100


select *
from projectss

-----------------------------------------------------------------------------------------------------------

insert into tasks(task_id,description,starting_date,end_date,project_id) 
values (1001,'Analyze project requirements','2026-08-01','2026-08-05',101)


insert into tasks(task_id,description,starting_date,end_date,project_id)
values (2002,'Analyze','2026-08-11','2026-08-12',202),
       (3003,'Project','2026-08-15','2026-08-30',303),
	   (4004,'Requirements','2026-09-01','2026-09-05',404),
       (5005,'Analyze project requirements','2026-09-15','2026-09-30',505)

	   
update tasks 
set end_date='2026-07-29'
where task_id = 1001 

update tasks 
set project_id = 101
where task_id = 2002 

update tasks 
set end_date = DATEADD(day, 3, end_date)
where task_id = 1001 

update tasks 
set end_date = DATEADD(day, 7, end_date)
where project_id = 101 


delete from tasks
where task_id = 5005

delete from tasks
where project_id = 101

delete from tasks
where end_date < starting_date


select *
from tasks

-----------------------------------------------------------------------------------------------------------
