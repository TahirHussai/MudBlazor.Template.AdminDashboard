
---------------------------------------------------Table LuCategory------------------------------------------

CREATE TABLE LuCategory(
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [Abv] [varchar](25) NOT NULL,
    [Desc] [varchar](75) NOT NULL,
 CONSTRAINT [PK_LuCategory] PRIMARY KEY CLUSTERED 
(
    [ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT tblCategory ON
GO
INSERT INTO LuCategory ([ID],[Abv],[Desc]) VALUES(N'1','Admin','Administrative')
GO
INSERT INTO LuCategory ([ID],[Abv],[Desc]) VALUES(N'2','Eng','Engineering')
GO
INSERT INTO LuCategory ([ID],[Abv],[Desc]) VALUES(N'3','IT','Information Technology')
GO
INSERT INTO LuCategory ([ID],[Abv],[Desc]) VALUES(N'4','LI','Light Industrial')
GO
INSERT INTO LuCategory  ([ID],[Abv],[Desc]) VALUES(N'5','Mfg','Manufacturing & Tooling')
GO
INSERT INTO LuCategory ([ID],[Abv],[Desc]) VALUES(N'6','Misc','Miscellaneous')
GO
INSERT INTO LuCategory ([ID],[Abv],[Desc]) VALUES(N'7','Pro','Professional')
GO
INSERT INTO LuCategory ([ID],[Abv],[Desc]) VALUES(N'8','Trades','Skilled Trades')
GO
INSERT INTO LuCategory ([ID],[Abv],[Desc]) VALUES(N'9','Sci','Science')
GO
SET IDENTITY_INSERT LuCategory OFF
GO
---------------------------------------------------Table LuSubCategory------------------------------------------

CREATE TABLE LuSubCategory(
    [SubCatID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryRID] INT,---tblCategory
    [Abv] [varchar](25) NOT NULL,
    [Desc] [varchar](75) NOT NULL,
 CONSTRAINT [PK_LuSubCategory] PRIMARY KEY CLUSTERED 
(
    [SubCatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
---------------------------------------------------Table LuSector------------------------------------------

CREATE TABLE LuSector(
    [SectorID] [int] IDENTITY(1,1) NOT NULL,
    [Abv] [varchar](25) NOT NULL,
    [Desc] [varchar](75) NOT NULL,
 CONSTRAINT [PK_LuSector] PRIMARY KEY CLUSTERED 
(
    [SectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
---------------------------------------------------Table LuRegion------------------------------------------

CREATE TABLE LuRegion(
    [RegionID] [int] IDENTITY(1,1) NOT NULL,
    [Abv] [varchar](25) NOT NULL,
    [Desc] [varchar](75) NOT NULL,
 CONSTRAINT [PK_LuRegion] PRIMARY KEY CLUSTERED 
(
    [RegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
---------------------------------------------------Table LuSubRegion------------------------------------------
CREATE TABLE LuSubRegion(
    [SubRegionID] [int] IDENTITY(1,1) NOT NULL,
	[RegionRId] INT	,--tblRegion
    [Abv] [varchar](25) NOT NULL,
    [Desc] [varchar](75) NOT NULL,
 CONSTRAINT [PK_LuSubRegion] PRIMARY KEY CLUSTERED 
(
    [SubRegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
---------------------------------------------------Table Address------------------------------------------
CREATE TABLE [dbo].[Address](
    [ADDRESSID] [int] IDENTITY(1,1) NOT NULL,
    [ADDRESS1] [varchar](50) NULL,
    [ADDRESS2] [varchar](50) NULL,
    [CITY] [varchar](50) NULL,
    [STATEID] [int] NULL,
    [POSTALCODE] [varchar](15) NULL,
    [COUNTRYID] [int] NULL,
    [CreatedByID] [int] NULL,
    [CreateDate] [datetime] NOT NULL,
	FOREIGN KEY (STATEID) REFERENCES  LuRegion(RegionID),
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
    [ADDRESSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
