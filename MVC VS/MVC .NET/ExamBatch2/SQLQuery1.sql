use KrunalDhote351

Select * From Authentication 

CREATE TABLE [dbo].[Answers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[questionId] [int] NULL,
	[title] [varchar](500) NULL,
	[isactive] [bit] NULL,
	[isCorrect] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 06/12/2020 11:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Questions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](500) NULL,
	[isactive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Answers] ON 

GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (1, 1, N'1', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (2, 1, N'2', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (3, 1, N'3', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (4, 1, N'4', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (5, 2, N'20', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (6, 2, N'10', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (7, 2, N'30', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (8, 2, N'40', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (9, 3, N'15', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (10, 3, N'25', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (11, 3, N'35', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (12, 3, N'10', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (13, 4, N'Tring Tring', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (14, 4, N'Tap Tap', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (15, 4, N'Click Click', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (16, 4, N'Dhak Dhak', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (17, 5, N'Tipu Sultan', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (18, 5, N'Chandragupta Maurya', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (19, 5, N'Maharana Pratap', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (20, 5, N'Ashoka', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (21, 6, N'Uttrakhand', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (22, 6, N'Arunachal Pradesh', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (23, 6, N'Jammu and Kashmir', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (24, 6, N'Sikkim', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (25, 7, N'Mere Dad Ki Maruti', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (26, 7, N'Chennai Express', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (27, 7, N'Ghanchakkar', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (28, 7, N'Race 2', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (29, 8, N'Surpanakha', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (30, 8, N'Khara', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (31, 8, N'Maricha', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (32, 8, N'Dushana', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (33, 9, N'Syed Yousaf Raza Gillani', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (34, 9, N'Benazir Bhutto', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (35, 9, N'Liaqat Ali Khan', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (36, 9, N'Nawaz Sharif', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (37, 10, N'Sloth', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (38, 10, N'Ant', 1, 0)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (39, 10, N'Spider', 1, 1)
GO
INSERT [dbo].[Answers] ([id], [questionId], [title], [isactive], [isCorrect]) VALUES (40, 10, N'Termite', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Answers] OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (1, N'1+1', 1)
GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (2, N'5*4', 1)
GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (3, N'50/5', 1)
GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (4, N'Which of these sounds would you associate with the heart ? ', 1)
GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (5, N'Who is the ''Bharat Ka Veer Putra Aaccording to the title of a 2013 TV Series ? ', 1)
GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (6, N'In 2013, where did the natural calamity known as Himalayan tsunami occur? ', 1)
GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (7, N'Which film is this song from ? ', 1)
GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (8, N'In the Ramayana, Which demon impersonated Rama''s voice, screaming, ''Lakshman! Help me''ù ?', 1)
GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (9, N'Who is the only leader to be elected Prime Minister of Pakistan three times ? ', 1)
GO
INSERT [dbo].[Questions] ([id], [title], [isactive]) VALUES (10, N'The black widow, which eats the male counterpart after mating, as a female species of which animal ?', 1)
GO
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD FOREIGN KEY([questionId])
REFERENCES [dbo].[Questions] ([id])
GO


select * from Answers
select * from Questions

Create or Alter Proc sp_GetQuistion
as
begin
	select A.questionId as QuestionId,Q.title as Qustion,A.id as OptionId,A.title as Options,A.isCorrect from Answers A 
		Join Questions Q on A.questionId=Q.id
end

sp_GetQuistion 5
