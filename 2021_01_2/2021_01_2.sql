
select sum(isInc)
from
(
  select s3.*, case when valsum > prev then 1 else 0 end isInc
  from
  (
    select s2.*, LAG (valsum) OVER (ORDER BY id) AS prev 
    from
    (
      select s1.*, val+val2+val3 valsum 
      FROM
      (
        select d1.*
        ,LAG (val, 1) OVER (ORDER BY id) AS val2
        ,LAG (val, 2) OVER (ORDER BY id) AS val3
        FROM d1
      ) s1
      where s1.val2 is not null and s1.val3 is not null 
    ) s2
  ) s3
) s4

