create table emp1(
emp_id int,
emp_name varchar(200)
);
--------------------------------------------------------------------------------------

create table emp3(
emp_id int ,
emp_name varchar(200) constraint emp3_emp_name_nk not null,
phone char(12) ,
constraint emp3_emp_id_pk primary key(emp_id),
constraint emp3_phone_uk unique (phone)
);
--------------------------------------------------------------------------------------

create table travels (
trevl_num int ,
trevl_date date,
destination varchar(20)
);
--------------------------------------------------------------------------------------

create table tickets (
tickets_num int ,
tickets_date date,
);
--------------------------------------------------------------------------------------

create table MyDepts (
Dept_ID int ,
Dept_name varchar(200) constraint MyDepts_Dept_name_nk not null,
constraint MyDepts_Dept_ID_pk primary key(Dept_ID)
);
--------------------------------------------------------------------------------------

create table MyEmps (
Emp_ID int ,
Emp_name varchar(150) constraint MyEmps_Emp_name_nk not null,
salary decimal(8,2) CHECK (salary between 3000 and 15000), 
hire_date Date default GETDATE(),
Dept_ID int,
constraint MyEmps_Emp_ID_pk primary key(Emp_ID),
constraint Fk_Dept_ID Foreign Key (Dept_ID) references MyDepts(Dept_ID),
);

--------------------------------------------------------------------------------------
alter table emp3 add email varchar(100) null;

alter table emp3 alter column email varchar(200) not null;

alter table emp3 alter column emp_name varchar(200) not null;

alter table emp3 drop column email ;

alter table emp3 drop column phone ;

alter table emp3 drop constraint emp3_phone_uk ;

alter table emp3 add phone_no char(12) not null; 

alter table emp3 add constraint emp3_phone_uk unique(phone_no);

--------------------------------------------------------------------------------------

exec sp_helpconstraint 'emp3'

--------------------------------------------------------------------------------------

create table omar (
name_no varchar(200) not null
);

drop table omar ;

--------------------------------------------------------------------------------------