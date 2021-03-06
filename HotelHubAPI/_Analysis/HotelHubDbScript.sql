USE [HotelHubDb]
GO
/****** Object:  Table [dbo].[HotelInformations]    Script Date: 9.01.2022 21:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelInformations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [nvarchar](150) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_HotelInformations_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelRooms]    Script Date: 9.01.2022 21:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelRooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelInformationId] [int] NOT NULL,
	[RoomTypeId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[MaxAllotment] [int] NOT NULL,
	[SoldAllotment] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_HotelRooms_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_HotelRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 9.01.2022 21:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detail] [nvarchar](max) NULL,
	[Date] [date] NULL,
	[Audit] [varchar](50) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 9.01.2022 21:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelRoomId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[RoomCount] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomTypes]    Script Date: 9.01.2022 21:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RoomTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 9.01.2022 21:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[PasswordSalt] [varbinary](500) NULL,
	[PasswordHash] [varbinary](500) NULL,
	[LastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[HotelInformations] ON 

INSERT [dbo].[HotelInformations] ([Id], [HotelName], [CreatedAt], [IsDeleted]) VALUES (1, N'Hotel California', CAST(N'2022-01-08 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[HotelInformations] ([Id], [HotelName], [CreatedAt], [IsDeleted]) VALUES (2, N'Hotel Miami', CAST(N'2022-01-08 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[HotelInformations] ([Id], [HotelName], [CreatedAt], [IsDeleted]) VALUES (3, N'Hotel Antalya', CAST(N'2022-01-08 00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[HotelInformations] OFF
SET IDENTITY_INSERT [dbo].[HotelRooms] ON 

INSERT [dbo].[HotelRooms] ([Id], [HotelInformationId], [RoomTypeId], [Price], [MaxAllotment], [SoldAllotment], [CreatedAt], [IsDeleted]) VALUES (1, 1, 1, CAST(1000.00 AS Decimal(18, 2)), 50, 41, CAST(N'2022-01-08 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[HotelRooms] ([Id], [HotelInformationId], [RoomTypeId], [Price], [MaxAllotment], [SoldAllotment], [CreatedAt], [IsDeleted]) VALUES (2, 2, 1, CAST(1250.00 AS Decimal(18, 2)), 105, 54, CAST(N'2022-01-08 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[HotelRooms] ([Id], [HotelInformationId], [RoomTypeId], [Price], [MaxAllotment], [SoldAllotment], [CreatedAt], [IsDeleted]) VALUES (3, 2, 2, CAST(1500.00 AS Decimal(18, 2)), 90, 43, CAST(N'2022-01-08 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[HotelRooms] ([Id], [HotelInformationId], [RoomTypeId], [Price], [MaxAllotment], [SoldAllotment], [CreatedAt], [IsDeleted]) VALUES (4, 1, 2, CAST(1300.00 AS Decimal(18, 2)), 30, 20, CAST(N'2022-01-08 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[HotelRooms] ([Id], [HotelInformationId], [RoomTypeId], [Price], [MaxAllotment], [SoldAllotment], [CreatedAt], [IsDeleted]) VALUES (6, 3, 1, CAST(1000.00 AS Decimal(18, 2)), 50, 40, CAST(N'2022-01-08 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[HotelRooms] ([Id], [HotelInformationId], [RoomTypeId], [Price], [MaxAllotment], [SoldAllotment], [CreatedAt], [IsDeleted]) VALUES (7, 3, 2, CAST(2500.00 AS Decimal(18, 2)), 100, 83, CAST(N'2022-01-08 00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[HotelRooms] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (1, N'{
  "Message": {
    "MethodName": "GetCheapestRoomPrices",
    "LogParameters": []
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (2, N'{
  "Message": {
    "ExceptionMessage": "Index was outside the bounds of the array.",
    "MethodName": "GetCheapestRoomPrices",
    "LogParameters": []
  }
}
', CAST(N'2022-01-09' AS Date), N'ERROR')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (3, N'{
  "Message": {
    "ExceptionMessage": "Index was outside the bounds of the array.",
    "MethodName": "GetCheapestRoomPrices",
    "LogParameters": []
  }
}
', CAST(N'2022-01-09' AS Date), N'ERROR')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (4, N'{
  "Message": {
    "ExceptionMessage": "Index was outside the bounds of the array.",
    "MethodName": "GetCheapestRoomPrices",
    "LogParameters": []
  }
}
', CAST(N'2022-01-09' AS Date), N'ERROR')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (5, N'{
  "Message": {
    "MethodName": "GetCheapestRoomPrices",
    "LogParameters": []
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (6, N'{
  "Message": {
    "ExceptionMessage": "Index was outside the bounds of the array.",
    "MethodName": "GetCheapestRoomPrices",
    "LogParameters": []
  }
}
', CAST(N'2022-01-09' AS Date), N'ERROR')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (7, N'{
  "Message": {
    "MethodName": "GetCheapestRoomPrices",
    "LogParameters": []
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (8, N'{
  "Message": {
    "MethodName": "GetCheapestRoomPrices",
    "LogParameters": []
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (9, N'{
  "Message": {
    "ExceptionMessage": "Wrong logger type",
    "MethodName": "UserExists",
    "LogParameters": [
      {
        "Name": "email",
        "Value": "omersaritemur@gmail.com",
        "Type": "String"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'ERROR')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (10, N'{
  "Message": {
    "MethodName": "GetCheapestRoomPrices",
    "LogParameters": []
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (11, N'{
  "Message": {
    "MethodName": "AdvancedRoomSearch",
    "LogParameters": [
      {
        "Name": "roomTypeIds",
        "Value": [
          1
        ],
        "Type": "List`1"
      },
      {
        "Name": "selectedHotelIds",
        "Value": [
          1,
          2
        ],
        "Type": "List`1"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (12, N'{
  "Message": {
    "MethodName": "RoomAvailabilityCheck",
    "LogParameters": [
      {
        "Name": "roomTypeIds",
        "Value": [
          1
        ],
        "Type": "List`1"
      },
      {
        "Name": "requestedRoomCount",
        "Value": 3,
        "Type": "Int32"
      },
      {
        "Name": "hotelIds",
        "Value": [
          1,
          2
        ],
        "Type": "List`1"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (13, N'{
  "Message": {
    "MethodName": "RoomAvailabilityCheck",
    "LogParameters": [
      {
        "Name": "roomTypeIds",
        "Value": [
          1
        ],
        "Type": "List`1"
      },
      {
        "Name": "requestedRoomCount",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "hotelIds",
        "Value": [
          1,
          2
        ],
        "Type": "List`1"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (14, N'{
  "Message": {
    "MethodName": "CreateReservation",
    "LogParameters": [
      {
        "Name": "hotelId",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "roomTypeId",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "requestedRoomCount",
        "Value": 45,
        "Type": "Int32"
      },
      {
        "Name": "bookingDateStart",
        "Value": "2022-01-09T13:59:52.59Z",
        "Type": "DateTime"
      },
      {
        "Name": "bookingDateEnd",
        "Value": "2022-01-10T13:59:52.59Z",
        "Type": "DateTime"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (15, N'{
  "Message": {
    "MethodName": "GetHotelRoomByHotelAndRoomTypeId",
    "LogParameters": [
      {
        "Name": "hotelId",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "roomTypeId",
        "Value": 1,
        "Type": "Int32"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (16, N'{
  "Message": {
    "MethodName": "CreateReservation",
    "LogParameters": [
      {
        "Name": "hotelId",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "roomTypeId",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "requestedRoomCount",
        "Value": 2,
        "Type": "Int32"
      },
      {
        "Name": "bookingDateStart",
        "Value": "2022-01-09T13:59:52.59Z",
        "Type": "DateTime"
      },
      {
        "Name": "bookingDateEnd",
        "Value": "2022-01-10T13:59:52.59Z",
        "Type": "DateTime"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (17, N'{
  "Message": {
    "MethodName": "GetHotelRoomByHotelAndRoomTypeId",
    "LogParameters": [
      {
        "Name": "hotelId",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "roomTypeId",
        "Value": 1,
        "Type": "Int32"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (18, N'{
  "Message": {
    "MethodName": "Update",
    "LogParameters": [
      {
        "Name": "hotelRoom",
        "Value": {
          "Id": 1,
          "HotelInformationId": 1,
          "RoomTypeId": 1,
          "Price": 1000.00,
          "MaxAllotment": 50,
          "SoldAllotment": 43,
          "CreatedAt": "2022-01-08T00:00:00",
          "IsDeleted": false,
          "HotelInformation": null,
          "RoomType": null
        },
        "Type": "HotelRoom"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (19, N'{
  "Message": {
    "MethodName": "CancelReservation",
    "LogParameters": [
      {
        "Name": "reservationId",
        "Value": 3,
        "Type": "Int32"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (20, N'{
  "Message": {
    "MethodName": "GetHotelRoomById",
    "LogParameters": [
      {
        "Name": "hotelRoomId",
        "Value": 1,
        "Type": "Int32"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (21, N'{
  "Message": {
    "MethodName": "Update",
    "LogParameters": [
      {
        "Name": "hotelRoom",
        "Value": {
          "Id": 1,
          "HotelInformationId": 1,
          "RoomTypeId": 1,
          "Price": 1000.00,
          "MaxAllotment": 50,
          "SoldAllotment": 41,
          "CreatedAt": "2022-01-08T00:00:00",
          "IsDeleted": false,
          "HotelInformation": null,
          "RoomType": null
        },
        "Type": "HotelRoom"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (22, N'{
  "Message": {
    "MethodName": "CreateReservation",
    "LogParameters": [
      {
        "Name": "hotelId",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "roomTypeId",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "requestedRoomCount",
        "Value": 3,
        "Type": "Int32"
      },
      {
        "Name": "bookingDateStart",
        "Value": "2022-01-09T13:59:52.59Z",
        "Type": "DateTime"
      },
      {
        "Name": "bookingDateEnd",
        "Value": "2022-01-10T13:59:52.59Z",
        "Type": "DateTime"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (23, N'{
  "Message": {
    "MethodName": "GetHotelRoomByHotelAndRoomTypeId",
    "LogParameters": [
      {
        "Name": "hotelId",
        "Value": 1,
        "Type": "Int32"
      },
      {
        "Name": "roomTypeId",
        "Value": 1,
        "Type": "Int32"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (24, N'{
  "Message": {
    "MethodName": "Update",
    "LogParameters": [
      {
        "Name": "hotelRoom",
        "Value": {
          "Id": 1,
          "HotelInformationId": 1,
          "RoomTypeId": 1,
          "Price": 1000.00,
          "MaxAllotment": 50,
          "SoldAllotment": 44,
          "CreatedAt": "2022-01-08T00:00:00",
          "IsDeleted": false,
          "HotelInformation": null,
          "RoomType": null
        },
        "Type": "HotelRoom"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (25, N'{
  "Message": {
    "MethodName": "CancelReservation",
    "LogParameters": [
      {
        "Name": "reservationId",
        "Value": 4,
        "Type": "Int32"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (26, N'{
  "Message": {
    "MethodName": "GetHotelRoomById",
    "LogParameters": [
      {
        "Name": "hotelRoomId",
        "Value": 1,
        "Type": "Int32"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (27, N'{
  "Message": {
    "MethodName": "Update",
    "LogParameters": [
      {
        "Name": "hotelRoom",
        "Value": {
          "Id": 1,
          "HotelInformationId": 1,
          "RoomTypeId": 1,
          "Price": 1000.00,
          "MaxAllotment": 50,
          "SoldAllotment": 41,
          "CreatedAt": "2022-01-08T00:00:00",
          "IsDeleted": false,
          "HotelInformation": null,
          "RoomType": null
        },
        "Type": "HotelRoom"
      }
    ]
  }
}
', CAST(N'2022-01-09' AS Date), N'INFO')
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([Id], [HotelRoomId], [StartDate], [EndDate], [RoomCount], [CreatedAt], [IsDeleted]) VALUES (1, 1, CAST(N'2022-01-08 16:14:08.287' AS DateTime), CAST(N'2022-01-09 16:14:08.287' AS DateTime), 5, CAST(N'2022-01-08 19:14:29.393' AS DateTime), 1)
INSERT [dbo].[Reservations] ([Id], [HotelRoomId], [StartDate], [EndDate], [RoomCount], [CreatedAt], [IsDeleted]) VALUES (2, 1, CAST(N'2022-01-08 21:54:30.507' AS DateTime), CAST(N'2022-01-08 21:54:30.507' AS DateTime), 1, CAST(N'2022-01-09 00:54:43.313' AS DateTime), 0)
INSERT [dbo].[Reservations] ([Id], [HotelRoomId], [StartDate], [EndDate], [RoomCount], [CreatedAt], [IsDeleted]) VALUES (3, 1, CAST(N'2022-01-09 13:59:52.590' AS DateTime), CAST(N'2022-01-10 13:59:52.590' AS DateTime), 2, CAST(N'2022-01-09 17:17:46.143' AS DateTime), 1)
INSERT [dbo].[Reservations] ([Id], [HotelRoomId], [StartDate], [EndDate], [RoomCount], [CreatedAt], [IsDeleted]) VALUES (4, 1, CAST(N'2022-01-09 13:59:52.590' AS DateTime), CAST(N'2022-01-10 13:59:52.590' AS DateTime), 3, CAST(N'2022-01-09 17:23:01.940' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Reservations] OFF
SET IDENTITY_INSERT [dbo].[RoomTypes] ON 

INSERT [dbo].[RoomTypes] ([Id], [RoomTypeName]) VALUES (1, N'Standart')
INSERT [dbo].[RoomTypes] ([Id], [RoomTypeName]) VALUES (2, N'Deluxe')
INSERT [dbo].[RoomTypes] ([Id], [RoomTypeName]) VALUES (3, N'Suite')
INSERT [dbo].[RoomTypes] ([Id], [RoomTypeName]) VALUES (4, N'Presidential')
INSERT [dbo].[RoomTypes] ([Id], [RoomTypeName]) VALUES (5, N'Villa')
SET IDENTITY_INSERT [dbo].[RoomTypes] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [Email], [Status], [PasswordSalt], [PasswordHash], [LastName]) VALUES (1, N'Halil', N'halilakcil@gmail.com', 1, 0x41648C2A8D29A4699E82AB9398DF66C1BC525972BF6DD625394EA4E7A2AA698006335AB3563D931D0FF0770E6A91DCCA8D7549B8DEB88D34C7007BA9FDE4D1D9D8978E2C77595B3AFDFB834F762CE10E36F197606D135361310D7097857130EAF622B22B16FD1D018B1F5566D7D80F58F5408513207ECAFAFD8014EE81C4D5DF, 0x046384CE8081EA35420161A853110D89559F8DD7E5A965097366173AD2EACFB1D27B9DF26EBDDB0BE40DB4D1AF097696CF5DB7352B7A05AD61EEBED79FC3624D, N'Akcil')
INSERT [dbo].[Users] ([Id], [FirstName], [Email], [Status], [PasswordSalt], [PasswordHash], [LastName]) VALUES (2, N'Ahmet', N'ahmetunal@gmail.com', 1, 0x305F557D708625E126F12EFDF8FCE0132D88D7A73229905D6232B9EC6BF5EB744105C5893A2DE050376EADDADC011D1E6722E4591B469B1AB9FC933DC4162A946BE1B0FC74024BC0F8E3E7147C63206CC2C524149F783E7C52B6CE3A006E20436D84579CE40EB134723D00A3A356F9AE562B8789BAA047C0CB4378AE4F3D72CD, 0xFC4420725F93764E639DF167462A49D94FCFDE466E2C0B4668D506C88398CFC73BAFAE168A17FB43CCCBD24D1A6FD3D599185ED15504C41E6BE70C2D634CD7F4, N'Unal')
INSERT [dbo].[Users] ([Id], [FirstName], [Email], [Status], [PasswordSalt], [PasswordHash], [LastName]) VALUES (3, N'Omer', N'omersaritemur@gmail.com', 1, 0x722E6227D3EBFFF4310BC25A969FE3EAB17BDF8E2705990BA7C10D3A8FECCEA3410717740CED033E8DF13767500DAC0B9E78470012EDE517E461E1B5A601A201A5567EA89D4D8ECB716C93B0BC15FA91F6A3CE6315305ADE0E934880D9EE11F07681DBEF12B0EAB5C60B89C7F822C023BE00716743A583B1E1093E0F2D76872D, 0x56D471C90ABE90D069A65C9AC48F17EB6C54855AFE3DC845DD071FDC3CF4A13A6570E044AC9AEA2F8D38040B42F721D44DCBE5F8810A945590D43BBAE7464830, N'Saritemur')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[HotelRooms]  WITH CHECK ADD  CONSTRAINT [FK_HotelRooms_HotelInformations] FOREIGN KEY([HotelInformationId])
REFERENCES [dbo].[HotelInformations] ([Id])
GO
ALTER TABLE [dbo].[HotelRooms] CHECK CONSTRAINT [FK_HotelRooms_HotelInformations]
GO
ALTER TABLE [dbo].[HotelRooms]  WITH CHECK ADD  CONSTRAINT [FK_HotelRooms_RoomTypes] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomTypes] ([Id])
GO
ALTER TABLE [dbo].[HotelRooms] CHECK CONSTRAINT [FK_HotelRooms_RoomTypes]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_HotelRooms] FOREIGN KEY([HotelRoomId])
REFERENCES [dbo].[HotelRooms] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_HotelRooms]
GO
