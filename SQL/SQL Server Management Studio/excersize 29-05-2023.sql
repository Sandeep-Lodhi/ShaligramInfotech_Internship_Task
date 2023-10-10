use SandeepLodhi_SIT363;

--Actor: 
create table actor
(
act_id int not null primary key,
act_fname varchar(50),
act_lname varchar(50),
act_gender varchar(50)
);

-- genre:
create table genre
(
gen_id int not null primary key,
gen_title varchar(50)
);

-- director:
create table director
(
dir_id int not null primary key,
dir_fname varchar(50),
dir_lname varchar(50)
);

--movie:
create table movie
(
mov_id int not null primary key,
mov_title varchar(50),
mov_year int,
mov_time time,
mov_lang varchar(50),
mov_dt_rel date,
mov_release_country varchar(50)
);

--movie_genres:
create table movie_genres(mov_id int not null primary key,
gen_id int not null foreign key references genre(gen_id)
);

--movie_direction:
create table movie_direction
(
dir_id int not null foreign key references director(dir_id),
mov_id int not null foreign key references movie(mov_id)
);

-- reviewer :
create table reviewer(
rev_id int not null primary key,
rev_name varchar(50)
);

--rating:
create table rating
(
mov_id int not null foreign key references movie(mov_id),
rev_id int not null foreign key references reviewer(rev_id),
rev_stars decimal(5,2),
num_o_ratings int 
);

--movie_cast:
create table movie_cast
(
act_id int not null foreign key references actor(act_id),
mov_id int not null foreign key references movie(mov_id),
role varchar(60) 
);


--===================================================================================
--insert in actor:
  insert into actor (act_id,act_fname,act_lname,act_gender) values(1,'sandeep','Lodhi','M');
  insert into actor (act_id,act_fname,act_lname,act_gender) values(2,'Akshy','Kumar','M');
  insert into actor (act_id,act_fname,act_lname,act_gender) values(3,'katrina','kaif','F');
  insert into actor (act_id,act_fname,act_lname,act_gender) values(4,'divya','bharti','F');
  insert into actor (act_id,act_fname,act_lname,act_gender) values(5,'Sushant','Rajput','M');
--insert in genre:
insert into genre(gen_id,gen_title) values(1,'Web Series');
insert into genre(gen_id,gen_title) values(2,'Movie');
insert into genre(gen_id,gen_title) values(3,'Serial');
insert into genre(gen_id,gen_title) values(4,'Trailer');
insert into genre(gen_id,gen_title) values(5,'vlog');
--insert in director:
insert into director(dir_id,dir_fname,dir_lname) values(1,'karan','Johar');
insert into director(dir_id,dir_fname,dir_lname) values(2,'Reshab','Setti');
insert into director(dir_id,dir_fname,dir_lname) values(3,'Sinil','Setti');
insert into director(dir_id,dir_fname,dir_lname) values(4,'salman','Khan');
insert into director(dir_id,dir_fname,dir_lname) values(5,'akshy','kumar');
--insert in movie:
insert into movie(mov_id,mov_title,mov_year,mov_time,mov_lang,mov_dt_rel,mov_release_country)
values(1,'Tanha Ji',2021,'2:0:0','Hindi','2021-08-12','India');

insert into movie(mov_id,mov_title,mov_year,mov_time,mov_lang,mov_dt_rel,mov_release_country)
values(2,'RRR',2022,'1:56:0','Chinies','2022-04-07','China');

insert into movie(mov_id,mov_title,mov_year,mov_time,mov_lang,mov_dt_rel,mov_release_country)
values(3,'Bahubali',2019,'1:48:0','English','2021-07-02','USA');

insert into movie(mov_id,mov_title,mov_year,mov_time,mov_lang,mov_dt_rel,mov_release_country)
values(4,'Pushpa',2021,'2:10:0','Hindi','2021-04-14','India');
--insert in movie_genres:
insert into movie_genres(mov_id,gen_id) values(1,1);
insert into movie_genres(mov_id,gen_id) values(2,2);
insert into movie_genres(mov_id,gen_id) values(3,3);
insert into movie_genres(mov_id,gen_id) values(4,4);
--insert in movie_direction:
insert into movie_direction(dir_id,mov_id) values(1,1);
insert into movie_direction(dir_id,mov_id) values(2,2);
insert into movie_direction(dir_id,mov_id) values(3,3);
insert into movie_direction(dir_id,mov_id) values(4,4);
--insert in reviewer:
insert into reviewer(rev_id,rev_name) values(1,'Sandeep');
insert into reviewer(rev_id,rev_name) values(2,'Pankaj');
insert into reviewer(rev_id,rev_name) values(3,'varun');
insert into reviewer(rev_id,rev_name) values(4,'Raj');

--insert in rating:
insert into rating(mov_id,rev_id,rev_stars,num_o_ratings)
values(1,1,3,22354);
insert into rating(mov_id,rev_id,rev_stars,num_o_ratings)
values(2,2,5,54354);
insert into rating(mov_id,rev_id,rev_stars,num_o_ratings)
values(3,3,4,27345);
insert into rating(mov_id,rev_id,rev_stars,num_o_ratings)
values(4,4,3,22365);
-- insert into movie_cast:
insert into movie_cast(act_id,mov_id,role) 
values(1,1,'Belain');
insert into movie_cast(act_id,mov_id,role) 
values(2,2,'Hero');
insert into movie_cast(act_id,mov_id,role) 
values(3,3,'Comedian');
insert into movie_cast(act_id,mov_id,role) 
values(4,4,'Father');
--**********************==================================********************
--1)From the following table, write a SQL query to find the name and year of the movies. Return movie title, movie release year
SELECT mov_title,mov_year from movie;

--2)From the following table, write a SQL query to find when the movie specific released. Return movie release year
SELECT mov_year from movie where mov_dt_rel='2021-08-12';
--3) From the following table, write a SQL query to find the movie that was released in 1999. Return movie title.
SELECT mov_title from movie where mov_year = 1999;

--4)From the following table, write a SQL query to find those movies, which were released before 1998. Return movie title.
select mov_title from movie where mov_year < 1998;

--5)From the following tables, write a SQL query to find the name of all reviewers and movies together in a single list..

SELECT reviewer.rev_name,movie.mov_title from reviewer 
inner join movie 
ON reviewer.rev_id = movie.mov_id;

--6)From the following table, write a SQL query to find all reviewers who have rated seven or more stars to their rating. Return reviewer name.
SELECT rev_name from reviewer 
inner join rating 
ON reviewer.rev_id = rating.rev_id
where rev_stars > 7;

--7) From the following tables, write a SQL query to find the movies without any rating. Return movie title.
SELECT mov_title from movie 
inner join rating
ON movie.mov_id = rating.mov_id
where rating.rev_stars is null;

--8)From the following table, write a SQL query to find the movies with ID 905 or 907 or 917. Return movie title.
select mov_title from movie where mov_id =905 or mov_id =907 or mov_id =917;

--9)From the following table, write a SQL query to find the movie titles that contain the specific word. 
--Sort the result-set in ascending order by movie year. Return movie ID, movie title and movie release year. 

SELECT mov_id,mov_title,mov_dt_rel from movie where mov_title like 'R%' order by mov_year ASC;

--10)From the following table, write a SQL query to find those actors with the first name 'Woody' and the last name 'Allen'. Return actor ID
SELECT act_id from actor where act_fname = 'Woody' AND act_lname ='Allen';

--11) get directors who have directed movies with avrage rating higher then 5
SELECT CONCAT(dir_fname,' ',dir_lname) AS directors from director 
inner join movie_direction
ON director.dir_id = movie_direction.dir_id
inner join rating  
ON  movie_direction.mov_id = rating.mov_id
where  rating.rev_stars > 5 ;

--12)get all actors who have worked for movies that were directed by specific director

SELECT  concat(act_fname ,' ', act_lname) AS Actors from actor 
inner join movie_cast  
ON  actor.act_id = movie_cast.act_id
inner join movie_direction 
ON movie_cast.mov_id = movie_direction.mov_id 
inner join director 
ON movie_direction.dir_id = director.dir_id
where director.dir_fname = 'Karan';

--13) create a stored proc to get list of movies which is 3 years old and having rating greater than 5
alter proc moviesList 
AS
BEGIN 
SELECT mov_title from movie 
where mov_year in(select mov_year -3 from movie inner join rating  ON movie.mov_id = rating.mov_id where rating.rev_stars >3 );
END 
EXEC moviesList;
--14) create a stored proc to get list of all directors who have directed more then 2 movies

create proc DirectorList
AS
BEGIN 
 SELECT concat(dir_fname,' ',dir_lname) AS directors from director 
 inner join movie_direction 
 ON director.dir_id = movie_direction.dir_id
 inner join movie
 ON movie_direction.mov_id = movie.mov_id 
  group by dir_fname,dir_lname
  having count(director.dir_id) > 1;
END

EXEC DirectorList 

--15) create a stored proc to get list of all directors which have directed a movie which have rating greater than 3.

CREATE PROC AllDirectors
AS
BEGIN 
SELECT CONCAT(director.dir_fname,'',director.dir_lname) AS Directors from director inner join movie_direction on Director.dir_id = movie_direction.dir_id
inner join movie on movie_direction.mov_id = movie.mov_id inner join rating on movie.mov_id = rating.mov_id 
where rating.rev_stars> 3
END 
 
 EXEC AllDirectors 

 --16) create a function to get worst director according to movie rating
 CREATE FUNCTION fn_WorstDirector()
 RETURNS TABLE 
  AS 
  RETURN SELECT CONCAT(director.dir_fname,' ',director.dir_lname) AS [Worst Director] from director inner join movie_direction on director.dir_id = movie_direction.dir_id
  inner join rating on movie_direction.mov_id = rating.mov_id where  rating.rev_stars = (select min(rev_stars) from rating)

  select * from  fn_WorstDirector()

  --17)create a function to get worst actor according to movie rating.
  CREATE FUNCTION fn_WorstActor()
  returns table
  AS
  return select CONCAT(actor.act_fname,' ',actor.act_lname) AS [Worst Actor] from actor 
  inner join movie_cast on actor.act_id = movie_cast.act_id 
  inner join rating on movie_cast.mov_id = rating.mov_id where rating.rev_stars = (select min(rev_stars) from rating)

  select * from fn_WorstActor();

  --18) create a parameterized stored procedure which accept genre and give movie accordingly 

  create proc GenreMovie(@gen_title varchar(60))
  AS
  BEGIN
   SELECT movie.mov_title FROM movie inner join movie_genres ON movie.mov_id = movie_genres.mov_id 
   inner join genre  on movie_genres.gen_id = genre.gen_id  
   where genre.gen_title = @gen_title
  END

  EXEC GenreMovie 'Serial';

  --19) get list of movies that start with 'a' and end with letter 'e' and movie released before 2015
  SELECT mov_title FROM movie WHERE movie.mov_title like 'a%' or movie.mov_title like 'e%' AND movie.mov_year <2015;

  --20) get a movie with highest movie cast
  select  mov_title from movie where mov_time =(select max(mov_time) from movie);               --max(mov_time)

  --21) create a function to get reviewer that has rated highest number of movies

  ALTER  FUNCTION fn_HighRating()
  returns table 
  as
  return select reviewer.rev_name from reviewer  
  inner join rating on reviewer.rev_id = rating.rev_id 
  inner join movie  on rating.mov_id = movie.mov_id 
  where reviewer.rev_id =(select rev_id  from rating where rev_stars = ( select max(rev_stars) from rating))

  select * from fn_HighRating()

  --22)From the following tables, write a query in SQL to generate a report, which contain the fields movie title, 
  --name of the female actor, year of the movie, e genrrole, movies, the director, date of release, and rating of that movie.

  select movie.mov_title,
  concat(actor.act_fname,' ',actor.act_lname) AS [Female Actor],
  movie.mov_year,
  movie_cast.role,
  genre.gen_title,
  concat(director.dir_fname,'',director.dir_lname) AS Director,
  movie.mov_dt_rel,
  rating.rev_stars
  from movie_cast
  inner join movie
  ON movie.mov_id=movie_cast.mov_id
  inner join actor 
  ON movie_cast.act_id = actor.act_id
  inner join movie_genres 
  ON movie.mov_id = movie_genres.mov_id
  inner join genre
  ON movie_genres.gen_id = genre.gen_id 
 inner join movie_direction
 ON movie.mov_id = movie_direction.mov_id
 inner join director
 ON movie_direction.dir_id =director.dir_id 
 inner join rating
 ON movie.mov_id =rating.mov_id
 inner join reviewer
 ON rating.rev_id = reviewer.rev_id
 where actor.act_gender = 'F';

 --23)From the following tables, write a SQL query to find the years when most of the ‘Mystery Movies’ produced.
 --Count the number of generic title and compute their average rating. Group the result set on movie release year, generic title.
 --Return movie year, generic title, number of generic title and average rating.

 select movie.mov_year,genre.gen_title,count(genre.gen_title) ,avg(rating.rev_stars) from movie 
 inner join movie_genres ON movie.mov_id = movie_genres.mov_id
 inner join genre ON movie_genres.gen_id =  genre.gen_id 
 inner join rating on movie.mov_id = rating.mov_id
 group by mov_year,gen_title

 --24) From the following tables, write a SQL query to find the highest-rated ‘Mystery Movies’. Return the title, year, and rating

 select  movie.mov_title,movie.mov_year,rating.rev_stars from movie 
 inner join rating ON movie.mov_id  = rating.mov_id
 where rating.rev_stars = (select max(rev_stars) from rating);

 --25)create a function which accepts genre and suggests best movie according to ratings 

 CREATE OR ALTER FUNCTION fn_BestMovie(@genre varchar(60))
 RETURNS varchar(60)
 AS
 BEGIN 
 RETURN 
 (SELECT movie.mov_title from movie
 inner join movie_genres ON movie.mov_id = movie_genres.mov_id
 inner join genre ON movie_genres.gen_id =  genre.gen_id 
 inner join rating on movie.mov_id = rating.mov_id
 where  rev_stars IN (SELECT max(rev_stars) from rating 
 inner join movie_genres ON rating.mov_id = movie_genres.mov_id 
 inner join genre ON movie_genres.gen_id =genre.gen_id  where  genre.gen_title = @genre)
 group by mov_title,gen_title)
 END

 select dbo.fn_BestMovie('Serial');

 --26)create a function which accepts genre and suggests best director according to ratings.
 CREATE  FUNCTION  fn_BestDirector(@gen_title VARCHAR(60))
 RETURNS VARCHAR(60)
 AS 
 BEGIN 
 RETURN (SELECT CONCAT(director.dir_fname,' ',director.dir_lname) AS [Best Director] from director 
inner join movie_direction ON director.dir_id = movie_direction.dir_id
inner join movie ON movie_direction.mov_id = movie.mov_id
inner join movie_genres ON movie.mov_id = movie_genres.mov_id
inner join genre ON movie_genres.gen_id = genre.gen_id
inner join rating ON movie.mov_id = rating.mov_id
where rev_stars IN
(SELECT MAX(rev_stars) FROM rating where rev_stars =(SELECT rev_stars from rating 
inner join movie_genres ON rating.mov_id = movie_genres.mov_id 
inner join genre ON movie_genres.gen_id = genre.gen_id 
where gen_title = @gen_title)))
END 

SELECT dbo.fn_BestDirector('Movie');
 --27). create a function that accepts a genre and give random movie according to genre


 CREATE or alter FUNCTION fn_randomMovie(@gen_title VARCHAR(60))
 RETURNS VARCHAR(60)
 AS
 BEGIN 
 RETURN (SELECT movie.mov_title from movie 
inner join movie_genres ON movie.mov_id = movie_genres.mov_id 
inner join genre ON movie_genres.gen_id = genre.gen_id
where gen_title = @gen_title) --'Movie'
 END

select dbo.fn_randomMovie('vlog');

 
 CREATE FUNCTION fn_randomMoviee
 (
   @gen_title VARCHAR(60)
 )
 returns @OutputTable TABLE
 AS
 return (SELECT movie.mov_title from movie 
inner join movie_genres ON movie.mov_id = movie_genres.mov_id 
inner join genre ON movie_genres.gen_id = genre.gen_id
where gen_title = @gen_title)
END

  create or alter function fn_name(@name varchar(200))
  returns @mytable table(mov_title varchar(200),mov_id int)
  As
  BEGIN
     insert into @mytable
	 SELECT  mov_title,movie.mov_id from movie 
     inner join movie_genres ON movie.mov_id = movie_genres.mov_id 
     inner join genre ON movie_genres.gen_id = genre.gen_id
    where gen_title = @name
	return
  END

  select * from dbo.fn_name('web series')


  --=========================*************************************=========================================
select * from actor;
select * from genre;
select * from director;
select * from movie;
select * from movie_genres;
Select * from movie_direction
select * from reviewer;
select * from rating;
select * from movie_cast;
==========================================================


-- Multy value table function ====>>>

CREATE FUNCTION getCustomerAndDate()
RETURNS @CustAndDateInfo TABLE
(
Name VARCHAR(10),
DateOrdered DATETIME
)
AS
BEGIN
INSERT INTO @CustAndDateInfo
SELECT C.FirstName, O.OrderDate
FROM Orders AS O
INNER JOIN Customers AS C
on O.CustID = C.CustID
RETURN
END