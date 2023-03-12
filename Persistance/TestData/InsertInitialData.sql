delete from ServiceMessages;
delete from GeneralClassification;
delete from Games;
delete from Players;

insert into Players(Id,Initials,CurrentPosition) VALUES ('06c2f928-e60b-47e3-b1c7-6257c60dfcfe', 'WINC', 1);
insert into Players(Id,Initials,CurrentPosition) VALUES ('131ff64c-6d01-4210-98a0-e082ad469c7f', 'MACB', 2);

insert into GeneralClassification(LeaguePositionId,PlayerId,DateFrom,Position) VALUES ('a7a46ed0-cc27-4190-9397-30b82d34d63c','06c2f928-e60b-47e3-b1c7-6257c60dfcfe', '2023-02-01', 1);
insert into GeneralClassification(LeaguePositionId,PlayerId,DateFrom,Position) VALUES ('1127f1cc-0fef-47f6-8233-0074ce9d0ca7','131ff64c-6d01-4210-98a0-e082ad469c7f', '2023-02-01', 2);

insert into Games(GameId,
ChallengeDate,
MatchDate,
ChellengingPlayerId,
ChellangedPlayerId,
ChellangingPlayerWonGemsCount,
ChellangedPlayerWonGemsCount,
Win,
Walkover)
VALUES ('ad6d3540-0928-4cd3-8ab3-c7980ed3332f', '2023-02-18','2023-02-18', '131ff64c-6d01-4210-98a0-e082ad469c7f','06c2f928-e60b-47e3-b1c7-6257c60dfcfe',6,4,1,0);


insert into ServiceMessages(MessageId,Date,Content,GameId,Discriminator) VALUES ('91a8b1eb-f8e3-49f0-8863-d8db9157c5cb','2023-02-18','MACB pokonuje WINC i awansuje na 1 miejsce. WINC spada o jedn¹ pozycje' ,'ad6d3540-0928-4cd3-8ab3-c7980ed3332f','MatchResultMessage');

update Players set CurrentPosition = 2  where Id='06c2f928-e60b-47e3-b1c7-6257c60dfcfe';
update Players set CurrentPosition = 1  where Id='131ff64c-6d01-4210-98a0-e082ad469c7f';

update GeneralClassification set DateTo = '2023-02-18', MatchResultMessageMessageId ='91a8b1eb-f8e3-49f0-8863-d8db9157c5cb' where LeaguePositionId='a7a46ed0-cc27-4190-9397-30b82d34d63c';
update GeneralClassification set DateTo = '2023-02-18', MatchResultMessageMessageId ='91a8b1eb-f8e3-49f0-8863-d8db9157c5cb' where LeaguePositionId='1127f1cc-0fef-47f6-8233-0074ce9d0ca7';

insert into GeneralClassification(LeaguePositionId,PlayerId,DateFrom,Position) VALUES ('e69c7547-1dd9-4350-b72d-df9303da5314','06c2f928-e60b-47e3-b1c7-6257c60dfcfe', '2023-02-18', 2);
insert into GeneralClassification(LeaguePositionId,PlayerId,DateFrom,Position) VALUES ('63a0d0d1-3e61-4866-927c-a05de5c03afc','131ff64c-6d01-4210-98a0-e082ad469c7f', '2023-02-18', 1);