USE [BdiExamen]
GO

/****** Object:  Table [dbo].[tblExamen]    Script Date: 6/1/2026 5:57:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblExamen](
	[idExamen] [int] NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[Descripcion] [nvarchar](255) NULL,
 CONSTRAINT [PK_tblExamen] PRIMARY KEY CLUSTERED 
(
	[idExamen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


