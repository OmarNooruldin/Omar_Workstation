create table borrowings
(
  borrowing_id int ,
  borrow_date date default Getdate() ,
  return_date date, --(return_date > borrow_date),
  status char(10),
  book_id int, 
  member_id int,
  constraint borrowings_borrowing_id_pk primary key (borrowing_id),
  constraint chk_status CHECK (status IN ('Borrowed','Returned','Late')),
  constraint borrowings_book_id_fk foreign key (book_id) references books(book_id),
  constraint borrowings_member_id_fk foreign key (member_id) references members(member_id)
  );


  
INSERT INTO Borrowings
(
    borrowing_id,
    return_date,
    status,
    book_id,
    member_id
)
VALUES
(
    1001,
    DATEADD(DAY, 7, CAST(GETDATE() AS DATE)),
    'Borrowed',
    1,
    101
);


INSERT INTO Borrowings
(
    borrowing_id,
    borrow_date,
    return_date,
    status,
    book_id,
    member_id
)
VALUES
    (1002, '2026-07-01', '2026-07-10', 'Returned', 2, 102),
    (1003, '2026-07-05', '2026-07-15', 'Late'    , 3, 103),
    (1004, '2026-07-10', '2026-07-20', 'Borrowed', 4, 104),
    (1005, '2026-07-12', '2026-07-22', 'Borrowed', 5, 105);

select *
from borrowings


update books
set price = 275 
where book_id= 1 ;


update books
set available_copies = 15 
where book_id= 2 ;



update members
set phone = '01099998888'
where member_id= 104 ;


UPDATE Members
SET membership_type = 'Premium'
WHERE member_id = 101;


UPDATE Books
SET price = price + 50
WHERE price < 350;


UPDATE Books
SET price = price * 1.10
WHERE price * 1.10 <= 1000;


UPDATE Members
SET phone = 'Not Available'
WHERE phone IS NULL;

UPDATE Borrowings
SET status = 'Returned'
WHERE borrowing_id = 1004;


UPDATE Borrowings
SET return_date = DATEADD(DAY, 5, return_date)
WHERE borrowing_id = 1005;


UPDATE Borrowings
SET return_date = DATEADD(DAY, 3, return_date)
WHERE status = 'Borrowed';



UPDATE Borrowings
SET status = 'Late'
WHERE return_date < CAST(GETDATE() AS DATE)
  AND status <> 'Returned';

  UPDATE Books
SET available_copies = available_copies - 1
WHERE book_id = 1
  AND available_copies > 1;

  
  DELETE FROM Borrowings
WHERE borrowing_id = 1006;


DELETE FROM Borrowings
WHERE status = 'Returned';


DELETE FROM Borrowings
WHERE return_date < '2026-07-10';


DELETE FROM Borrowings
WHERE member_id = 105;


DELETE FROM Borrowings
WHERE book_id = 5;



DELETE FROM Books
WHERE book_id = 5;



  select * from courses1
  
  select * from projectss
  
 