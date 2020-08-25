sp_help
create database TwitterClone

create table ProfileCoverPic (user_id varchar(25) foreign key references Person(user_id), profilepic bit, coverpic bit)
create table Person (user_id varchar(25) primary key, password varchar(50) not null, fullName varchar(30) not null, email varchar(50) not null, joined datetime not null, active bit not null)
select * from Tweet
drop table ProfileCoverPic
drop procedure Person_Add

--------------------------------------------------------------------------------------------------

create table Person (user_id varchar(25) primary key, password varchar(50) not null, fullName varchar(30) not null, email varchar(50) not null, joined datetime not null, active bit not null)

create procedure Login @user_id varchar(25)
as begin
	select user_id, password 
	from Person 
	where user_id=@user_id
end

create procedure Person_Add @user_id varchar(25), @password binary(16), @fullName varchar(30), @email varchar(50), @joined DateTime, @active bit
as begin
	insert into Person 
	values(@user_id, @fullName, @email, @joined, @active, @password)
end

create procedure Person_Update @user_id varchar(25), @fullName varchar(30), @email varchar(50)
as begin
	update Person 
	set fullName=@fullName, email=@email 
	where user_id=@user_id
end

create procedure Person_Password_Update @user_id varchar(25), @password binary(16)
as begin
	update Person 
	set password=@password 
	where user_id=@user_id
end

create procedure Person_Details @user_id varchar(25)
as begin
	select fullName, password, email, joined 
	from Person 
	where user_id=@user_id
end

create procedure Person_List
as begin
	select Person.user_id, Person.fullName, ProfileCoverPic.profilepic
	from Person join ProfileCoverPic on 
	ProfileCoverPic.user_id=Person.user_id 
end

create procedure Person_Delete @user_id varchar(25)
as begin
	delete from Person 
	where user_id=@user_id
end

create procedure Search_User @user varchar(30)
as begin
	select user_id
	from Person 
	where user_id=@user or fullName=@user
end

create procedure Search_Results @user varchar(30)
as begin
	select Person.user_id, Person.fullName, ProfileCoverPic.profilepic
	from Person join ProfileCoverPic on 
	ProfileCoverPic.user_id=Person.user_id 
	where Person.user_id=@user or Person.fullName=@user
end

alter table Person add password binary(16)

drop table Person
drop procedure Person_Password_Update
exec Search_Results 'ss'
exec Person_Delete 3
select * from person
update Person set password = (select 1 password from person where user_id = 'sdfsdfs') where user_id = 'ssirari92'
insert into person values('2','sa','SS','ss',getdate(),1)
delete from profilecoverpic where user_id in ('dfdsf', 'sdfsdfs')
delete from person where user_id in ('dfdsf', 'sdfsdfs')


-------------------------------------------------------------------------------------------------------------

create table Tweet (tweet_id int identity(1,1) not null, user_id varchar(25) foreign key references Person(user_id) not null, message varchar(140) not null, created DateTime not null)

create procedure Tweet_Add @user_id varchar(25), @message varchar(140), @created DateTime
as begin
	insert into Tweet values(@user_id, @message, @created)
end

create procedure Tweet_Update @tweet_id int, @message varchar(140)
as begin
	update Tweet set message=@message
	where tweet_id=@tweet_id
end

create procedure Tweet_Count @user_id varchar(25)
as begin
	select count(user_id) from Tweet 
	where user_id=@user_id
end

create procedure Tweet_Delete @tweet_id int
as begin
	delete from Tweet 
	where tweet_id=@tweet_id
end

create procedure Tweet_Delete_Person @user_id varchar(25)
as begin
	delete from Tweet
	where user_id=@user_id
end

create procedure Tweet_List_Following @user_id varchar(25)
as begin
	select Tweet.tweet_id, Tweet.user_id, Tweet.message, Person.fullName, ProfileCoverPic.profilepic
	from Tweet join ProfileCoverPic on 
	ProfileCoverPic.user_id=Tweet.user_id join Person on 
	ProfileCoverPic.user_id=Person.user_id 
	where Tweet.user_id in (select following_id from Following where user_id=@user_id) order by tweet_id desc
end

create procedure Tweet_List @user_id varchar(25)
as begin
	select Tweet.tweet_id, Tweet.user_id, Tweet.message, Person.fullName, ProfileCoverPic.profilepic
	from Tweet join ProfileCoverPic on 
	ProfileCoverPic.user_id=Tweet.user_id join Person on 
	ProfileCoverPic.user_id=Person.user_id 
	where Tweet.user_id=@user_id order by tweet_id desc
end

drop procedure Tweet_Update
select * from Tweet
insert into Tweet values('2','Hello World',getdate())
Tweet_Delete 7
Tweet_List 'ssirari92'

-------------------------------------------------------------------------------------------------------------

create table Following (user_id varchar(25) foreign key references Person(user_id) not null, following_id varchar(25) foreign key references Person(user_id) not null)

create procedure Following_Add @user_id varchar(25), @following_id varchar(25)
as begin
	insert into Following values(@user_id, @following_id)
end

create procedure Following_Delete @user_id varchar(25), @following_id varchar(25)
as begin
	delete from Following 
	where user_id=@user_id and following_id=@following_id
end

create procedure Following_Follower_Delete @user_id varchar(25)
as begin
	delete from Following
	where user_id=@user_id or following_id=@user_id
end

create procedure Find_Following_Names @user_id varchar(25)
as begin
	select Person.user_id, Person.fullName, ProfileCoverPic.profilepic
	from Person join ProfileCoverPic on 
	ProfileCoverPic.user_id=Person.user_id 
	where Person.user_id in (select following_id from Following where user_id=@user_id)
end

create procedure Find_Followers_Names @following_id varchar(25)
as begin
	select Person.user_id, Person.fullName, ProfileCoverPic.profilepic
	from Person join ProfileCoverPic on 
	ProfileCoverPic.user_id=Person.user_id 
	where Person.user_id in (select user_id from Following where following_id=@following_id)
end

create procedure Find_Following_Count @user_id varchar(25)
as begin
	select count( distinct(following_id)) 
	from Following 
	where user_id=@user_id
end

create procedure Find_Followers_Count @following_id varchar(25)
as begin
	select count(distinct(user_id)) from Following 
	where following_id=@following_id
end

select * from Following
insert Into Following values('ssirari92','2')
drop procedure Find_Followers_Count
exec Find_Following_Names '1'
exec Following_Delete ssirari92,1

-------------------------------------------------------------------------------------------------------------

create table ProfileCoverPic (user_id varchar(25) foreign key references Person(user_id) not null, profilepic bit not null, coverpic bit not null)

create procedure ProfileCoverPic_Add @user_id varchar(25)
as begin
	insert into ProfileCoverPic values(@user_id, 0, 0)
end

create procedure ProfilePic_Update @user_id varchar(25)
as begin
	update ProfileCoverPic 
	set profilepic=1
	where user_id=@user_id
end

create procedure CoverPic_Update @user_id varchar(25)
as begin
	update ProfileCoverPic 
	set coverpic=1 
	where user_id=@user_id
end

create procedure ProfileCoverPic_Details @user_id varchar(25)
as begin
	select profilepic, coverpic 
	from ProfileCoverPic 
	where user_id=@user_id
end

create procedure ProfilePic_Delete @user_id varchar(25)
as begin
	update ProfileCoverPic 
	set profilepic=0 
	where user_id=@user_id
end

create procedure CoverPic_Delete @user_id varchar(25)
as begin
	update ProfileCoverPic 
	set coverpic=0 
	where user_id=@user_id
end

create procedure ProfileCoverPic_Delete @user_id varchar(25)
as begin
	delete from ProfileCoverPic
	where user_id=@user_id
end

select * from ProfileCoverPic
insert into ProfileCoverPic values('2', 0, 0)
drop procedure CoverPic_Details
exec ProfileCoverPic_Details '1'
exec ProfileCoverPic_Add 4

-------------------------------------------------------------------------------------------------------------

create table Reply (reply_id int primary key identity(1,1), tweet_id int foreign key references Tweet(tweet_id), user_id varchar(25) foreign key references Person(user_id), message varchar(140), created DateTime)
select * from Reply

create procedure Reply_Add @tweet_id int, @user_id varchar(25), @message varchar(140), @created DateTime
as begin
	insert into Reply values(@tweet_id, @user_id, @message, @created)
end

create procedure Reply_Delete @reply_id int
as begin
	delete from Reply 
	where reply_id=@reply_id
end

create procedure Reply_List @tweet_id int
as begin
	select * from Reply 
	where tweet_id=@tweet_id
end


-------------------------------------------------------------------------------------------------------------

select * from Tweet
drop table Reply
drop procedure Reply_Add

select user_id, tweet_id, message from Tweet select fullName from Person; select profilepic from ProfileCoverPic where user_id='ssirari92'
select Tweet.tweet_id, Tweet.user_id, Tweet.message, Person.fullName, ProfileCoverPic.profilepic from Tweet join ProfileCoverPic on ProfileCoverPic.user_id=Tweet.user_id join Person on ProfileCoverPic.user_id=Person.user_id where Tweet.user_id='ssirari92'


sp_helptext login

select * from person
insert into person values('2','sa','ss','vvxvxv',getdate(),1)

Person_Details 1