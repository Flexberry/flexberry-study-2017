/* 1 */
select groupname, count(*) as sportman_count, min(date_birth) as max_age, max(date_birth) as min_age from sportsman group by groupname

/* 2 */
select is_exist, count(*) from training where id_sportsman=1 group by is_exist

/* 3 */
select t.id_training, t.training_load, t.training_date, count(ex.id_training_exercises) as exercises_count, SUM(DATEDIFF(MINUTE, '0:00:00', ex.exercise_time)) as training_time, SUM(ex.avg_pulse)/count(ex.id_training_exercises) as avg_pulse
from training as t LEFT JOIN training_exercises as ex on t.id_training = ex.id_training where t.training_date > DATEADD(day, -21, t.training_date)
group by t.id_training, t.training_load, t.training_date
order by t.training_date

 /* 4 */
select id_sportsman, max(training_load) from training group by id_sportsman order by max(training_load) desc

 /* 5 */
 select sum(training_load)/count(*), training_date from training where id_sportsman = 1 group by training_date