USE [FUNewsManagement]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 3/26/2025 2:23:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NewsId] [nvarchar](20) NOT NULL,
	[UserId] [smallint] NOT NULL,
	[Content] [nvarchar](1000) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD FOREIGN KEY([NewsId])
REFERENCES [dbo].[NewsArticle] ([NewsArticleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[SystemAccount] ([AccountID])
GO
