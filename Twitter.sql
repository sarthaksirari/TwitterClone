sp_help
select * from Tweet
create table Following (user_id varchar(25) foreign key references Person(user_id), following_id varchar(25) foreign key references Person(user_id))
create table Tweet (tweet_id int primary key identity(1,1), user_id varchar(25) foreign key references Person(user_id), message varchar(140), created DateTime)
