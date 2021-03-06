USE [master]
GO
CREATE DATABASE [FabricaAutoPartes]
GO
USE [FabricaAutoPartes]
GO
/****** Object:  Table [dbo].[AutoPartes]    Script Date: 19/7/2021 18:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AutoPartes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_material] [int] NOT NULL,
	[numeroDeSerie] [varchar](max) NOT NULL,
	[tipo] [varchar](max) NOT NULL,
	[largo] [float] NOT NULL,
	[alto] [float] NOT NULL,
	[peso] [float] NOT NULL,
	[estaDefectuosa] [bit] NOT NULL,
	[descripcion] [varchar](max) NOT NULL,
	[tipoDeMaterial] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Materiales]    Script Date: 19/7/2021 18:28:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materiales](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[largo] [float] NOT NULL,
	[ancho] [float] NOT NULL,
	[alto] [float] NOT NULL,
	[densidad] [float] NOT NULL,
	[tipoDeMaterial] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AutoPartes] ON 

INSERT [dbo].[AutoPartes] ([ID], [ID_material], [numeroDeSerie], [tipo], [largo], [alto], [peso], [estaDefectuosa], [descripcion], [tipoDeMaterial]) VALUES (1, 1, N'HGTU280304', N'Puerta', 90, 120, 339.12, 0, N'Delantero izquierdo
', N'Acero')
INSERT [dbo].[AutoPartes] ([ID], [ID_material], [numeroDeSerie], [tipo], [largo], [alto], [peso], [estaDefectuosa], [descripcion], [tipoDeMaterial]) VALUES (2, 2, N'UVDB185673', N'Chasis', 50, 40, 21.6, 1, N'compacto', N'Aluminio')
SET IDENTITY_INSERT [dbo].[AutoPartes] OFF
SET IDENTITY_INSERT [dbo].[Materiales] ON 

INSERT [dbo].[Materiales] ([ID], [largo], [ancho], [alto], [densidad], [tipoDeMaterial]) VALUES (1, 4100, 4, 4000, 7850, N'Acero')
INSERT [dbo].[Materiales] ([ID], [largo], [ancho], [alto], [densidad], [tipoDeMaterial]) VALUES (2, 4500, 4, 4000, 2700, N'Aluminio')
SET IDENTITY_INSERT [dbo].[Materiales] OFF
