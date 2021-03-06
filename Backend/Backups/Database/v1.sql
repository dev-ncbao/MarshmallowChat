USE [MarshmallowChat]
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [Type]) VALUES (1, N'Normal')
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (1, N'Nguyễn Chí', N'Bảo', CAST(N'2000-10-10' AS Date), N'baob1809327@gmail.com', N'Nguyenbao1403', N'14032017', N'Nam', NULL, CAST(N'2022-03-09T21:50:53.003' AS DateTime))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (2, N'Nguyễn Chí', N'Bảo Hi', CAST(N'2000-10-10' AS Date), N'baob1809327@student.ctu.edu.vn', N'Nguyenbao2017', N'14032017', N'Nam', NULL, CAST(N'2022-03-09T21:50:53.007' AS DateTime))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (8, N'Nguyễn Chí', N'Bảo', CAST(N'2022-03-20' AS Date), N'baob18093271@gmail.com', N'Nguyenbao14032', N'Pha11111403!', N'Nam', NULL, CAST(N'2022-03-20T22:40:06.310' AS DateTime))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (9, N'Nguyễn Chí', N'Bảo', CAST(N'2022-03-20' AS Date), N'baob18093272@gmail.com', N'Nguyenbao14031', N'Pha11111403!', N'Nam', NULL, CAST(N'2022-03-20T22:44:44.270' AS DateTime))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (10, N'Nguyễn Chí', N'Bảo', CAST(N'2022-03-20' AS Date), N'baob18093273@gmail.com', N'Nguyenbao14033', N'Pha11111403!', N'Nam', NULL, CAST(N'2022-03-20T23:09:25.580' AS DateTime))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (11, N'Nguyễn Chí', N'Bảo', CAST(N'2022-03-21' AS Date), N'baob18093274@gmail.com', N'Nguyenbao14034', N'Pha11111403!', N'Nam', NULL, CAST(N'2022-03-21T20:41:18.043' AS DateTime))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (12, N'Nguyễn Chí', N'Bảo', CAST(N'2022-03-21' AS Date), N'baob18093275@gmail.com', N'Nguyenbao14035', N'Pha11111403!', N'Nam', NULL, CAST(N'2022-03-21T20:44:40.980' AS DateTime))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (13, N'Nguyễn Chí', N'Bảo', CAST(N'2022-03-21' AS Date), N'baob18093276@gmail.com', N'Nguyenbao14036', N'Pha11111403!', N'Nam', NULL, CAST(N'2022-03-21T20:47:35.963' AS DateTime))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (14, N'Nguyễn Chí', N'Bảo', CAST(N'2022-03-21' AS Date), N'baob18093277@gmail.com', N'Nguyenbao14037', N'Pha11111403!', N'Nam', NULL, CAST(N'2022-03-21T21:35:11.297' AS DateTime))
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [DayOfBirth], [Email], [Username], [Password], [Gender], [Avatar], [DateCreated]) VALUES (15, N'Nguyễn Chí', N'Bảo', CAST(N'2022-03-23' AS Date), N'baob1809327777@gmail.com', N'Nguyenbao14032000', N'180989a888925909367d6d337a2553dbaaacae8f690aeb9ebef0daddba3165ea', N'Nữ', NULL, CAST(N'2022-03-23T21:42:06.120' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Message] ON 

INSERT [dbo].[Message] ([MessageId], [RoomId], [Content], [Type], [TimeCreated], [UserId]) VALUES (1, 1, N'Chào bạn tôi là Nguyễn Chí Bảo, rất vui được làm quen với bạn.', N'Text', CAST(N'2022-03-09T21:50:54.3580461' AS DateTime2), 1)
INSERT [dbo].[Message] ([MessageId], [RoomId], [Content], [Type], [TimeCreated], [UserId]) VALUES (2, 1, N'Chào bạn tôi là Nguyễn Chí Bảo Hi, rất vui được làm quen với bạn.', N'Text', CAST(N'2022-03-09T21:50:54.3583181' AS DateTime2), 2)
SET IDENTITY_INSERT [dbo].[Message] OFF
GO
INSERT [dbo].[RoomMember] ([UserId], [RoomId]) VALUES (1, 1)
INSERT [dbo].[RoomMember] ([UserId], [RoomId]) VALUES (2, 1)
GO
INSERT [dbo].[Friendship] ([User1Id], [User2Id], [DateCreated]) VALUES (1, 2, CAST(N'2022-03-09T21:50:54.2966988' AS DateTime2))
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220309144127_Database_V1', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220311114340_Database_V2', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220317135220_Database_V3', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220319081202_Database_V4', N'5.0.14')
GO
