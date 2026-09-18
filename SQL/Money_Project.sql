create table Budgets (
id int ,
salary int ,
food int ,
gas int ,
subscriptions int ,
entertainment int ,
insurance int ,
loan int,
constraint Budgets_id_pk primary key (id));

select * from Budgets ;

insert into Budgets Values (1, 8000, 1000, 1000, 500, 1000, 500, 1000);
