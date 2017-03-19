/* 1 */
select groupname, count(*) as sportman_count, min(date_birth) as max_age, max(date_birth) as min_age from sportsman group by groupname

/* 2 */
select is_exist, count(*) from training where id_sportsman=1 group by is_exist

/* 3 */
 select t.id_training, pr.program_load, SUM(DATEDIFF(MINUTE, '0:00:00', p.exercise_time)) as training_time,count(p.id_exercise) as exercise_count,
 SUM(Z.exercise_pulse)
 from training as t INNER JOIN program_exercises as p ON p.id_program = t.id_program 
 INNER JOIN program as pr ON pr.id_program = t.id_program,
 (select (min_pulse+max_pulse)/2 as exercise_pulse from zone where id_zone in (select id_zone from exercise where id_exercise in (select id_exercise from program_exercises where id_program = p.id_program))) Z
 where t.training_date > DATEADD(day, -21, t.training_date)
 group by t.id_training, pr.program_load

 /* 4 */
select t.id_sportsman, max(p.program_load) from training as t inner join program as p on p.id_program = t.id_program group by t.id_sportsman order by max(p.program_load) desc

 /* 5 */