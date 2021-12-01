create table d1
( id int IDENTITY(1,1) NOT NULL,
  val int
);

insert into d1(val)
(
        select 199 v
  union select 200
  union select 208
  union select 210
  union select 200
  union select 207
  union select 240
  union select 269
  union select 260
  union select 263
);  

select b.*, case when val > prev then 1 else 0 end isInc
from
(
  select d1.*
  ,LAG (val) OVER (ORDER BY id) AS prev  
  FROM d1
) b

