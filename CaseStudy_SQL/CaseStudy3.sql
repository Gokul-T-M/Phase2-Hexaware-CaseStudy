USE master

use EventDB

--1 stored procedures for Insertion into each table

-- Insert User
create procedure sp_insert_user
@EmailId varchar(100), @UserName varchar(50), @Role varchar(20), @Password varchar(20)
as 
insert into UserInfo(EmailId,UserName,Role,Password)
values(@EmailId,@UserName,@Role,@Password)


-- Insert Event
create procedure sp_insert_event 
@EventName varchar(50), @EventCategory varchar(50), @EventDate datetime, @Description varchar(max), @Status varchar(20)
as 
insert into EventDetails(EventName, EventCategory, EventDate, Description, Status)
values(@EventName,@EventCategory,@EventDate,@Description,@Status)


-- Insert Speaker
create procedure sp_insert_speaker
@SpeakerName varchar(50)
as 
insert into SpeakersDetails(SpeakerName)
values(@SpeakerName)


-- Insert Session
create procedure sp_insert_session
@EventId int, @SessionTitle varchar(50), @SpeakerId int, @Description varchar(max), @SessionStart datetime, @SessionEnd datetime, @SessionUrl varchar(max)
as
insert into SessionInfo (EventId,SessionTitle,SpeakerId,Description,SessionStart,SessionEnd,SessionUrl)
values(@EventId,@SessionTitle,@SpeakerId,@Description,@SessionStart,@SessionEnd,@SessionUrl)


-- Insert Participant Event
create procedure sp_insert_participant_event
@ParticipantEmailId varchar(100), @EventId int, @SessionId int, @IsAttended bit
as
insert into ParticipantEventDetails(ParticipantEmailId, EventId, SessionId, IsAttended)
values (@ParticipantEmailId, @EventId, @SessionId, @IsAttended)


--2 stored procedures for deletion

create procedure sp_delete_user
@EmailId varchar(100)
as 
begin
delete from UserInfo where EmailId=@EmailId
end


create procedure sp_delete_event 
@EventId int
as
begin
delete from EventDetails where EventId = @EventId
end

create procedure sp_delete_speaker
@SpeakerId int
as
begin
delete from SpeakersDetails where SpeakerId = @SpeakerId
end

create procedure sp_delete_session
@SessionId int 
as
begin
delete from SessionInfo where SessionId = @SessionId
end


create procedure sp_delete_participant_event
@Id int
as
begin
delete from ParticipantEventDetails where Id = @Id
end

--3 stored procedures for updation

--update UserInfo
create procedure sp_update_user
@EmailId varchar(100), @UserName varchar(50), @Role varchar(20),@Password varchar(20)
as
begin
update UserInfo
set UserName = @UserName, Role = @Role, Password = @Password
where EmailId = @EmailId
end


--update EventDetails
create procedure sp_update_event 
@EventId int, @EventName varchar(50), @EventCategory varchar(50), @EventDate datetime, @Description varchar(max), @Status varchar(20)
as
begin
update EventDetails
set EventName=@EventName,EventCategory=@EventCategory,EventDate=@EventDate,Description=@Description,Status=@Status
where EventId=@EventId
end


--update SpeakersDetails
create procedure sp_update_speaker
    @SpeakerId int, @SpeakerName varchar(50)
as
update SpeakersDetails set SpeakerName = @SpeakerName
where SpeakerId = @SpeakerId


--update SessionInfo
create procedure sp_update_session
    @SessionId int, @EventId int, @SessionTitle varchar(50), @SpeakerId int,
    @Description varchar(max), @SessionStart datetime, @SessionEnd datetime, @SessionUrl varchar(max)
as
update SessionInfo set
    EventId = @EventId, SessionTitle = @SessionTitle, SpeakerId = @SpeakerId,
    Description = @Description, SessionStart = @SessionStart, SessionEnd = @SessionEnd, SessionUrl = @SessionUrl
where SessionId = @SessionId


--update ParticipantEventDetails
create procedure sp_update_participant_event
    @Id int, @ParticipantEmailId varchar(100), @EventId int, @SessionId int, @IsAttended bit
as
update ParticipantEventDetails set
    ParticipantEmailId = @ParticipantEmailId,
    EventId = @EventId, SessionId = @SessionId, IsAttended = @IsAttended
where Id = @Id


--4 view session details of a particular event

create view vw_session_details_per_event
as
select e.EventId, e.EventName, s.SessionId, s.SessionTitle, s.SessionStart, s.SessionEnd, s.Description,s.SessionUrl
from EventDetails e 
join SessionInfo s
on e.EventId = s.EventId


--5 view speaker details of a particular session

create view vw_speaker_detail_per_session
as
select s.SessionId, s.SessionTitle, sp.SpeakerName
from SessionInfo s
join SpeakersDetails sp on s.SpeakerId = sp.SpeakerId


--6 View full event details

create view vw_full_event_details
as
select 
    e.EventId, e.EventName, e.EventCategory, e.EventDate, e.Status,
    ss.SessionId, ss.SessionTitle, ss.SessionStart, ss.SessionEnd,
    sp.SpeakerName,
    u.UserName as ParticipantName, u.EmailId, pe.IsAttended
from EventDetails e
left join SessionInfo ss on e.EventId = ss.EventId
left join SpeakersDetails sp on ss.SpeakerId = sp.SpeakerId
left join ParticipantEventDetails pe on e.EventId = pe.EventId and ss.SessionId = pe.SessionId
left join UserInfo u on pe.ParticipantEmailId = u.EmailId



--7 non clustered indexes

create nonclustered index idx_user_email on UserInfo(EmailId)

create nonclustered index idx_event_name on EventDetails(EventName)

create nonclustered index idx_session_speaker on SessionInfo(SpeakerId)

create nonclustered index idx_participant_session on ParticipantEventDetails(SessionId)
