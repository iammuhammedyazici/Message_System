USE [DboMesajSistemi]
GO
/****** Object:  Table [dbo].[TBL_KISILER]    Script Date: 23.04.2019 02:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_KISILER](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[AD] [varchar](20) NULL,
	[SOYAD] [varchar](20) NULL,
	[NUMARA] [char](4) NULL,
	[SIFRE] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_MESAJLAR]    Script Date: 23.04.2019 02:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_MESAJLAR](
	[MESAJID] [smallint] IDENTITY(1,1) NOT NULL,
	[GONDEREN] [char](4) NULL,
	[ALICI] [char](4) NULL,
	[BASLIK] [varchar](50) NULL,
	[ICERIK] [varchar](500) NULL
) ON [PRIMARY]
GO
