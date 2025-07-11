
GO
/****** Object:  Table [dbo].[PrSsExtraTaxTable]    Script Date: 01/11/2012 16:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrSsExtraTaxTable](
	[ExtTbl_id] [int] IDENTITY(1,1) NOT NULL,
	[ExtTbl_Sequence] [tinyint] NOT NULL,
	[ExtTbl_BracketAmount] [decimal](10, 2) NOT NULL,
	[ExtTbl_DedRate] [decimal](10, 2) NOT NULL,
	[ExtTbl_ConRate] [decimal](10, 2) NOT NULL,
	[ExtTbl_CreationDate] [smalldatetime] NOT NULL,
	[ExtTbl_CreatedBy] [int] NOT NULL,
	[ExtTbl_AmendDate] [smalldatetime] NOT NULL,
	[ExtTbl_AmendBy] [int] NOT NULL,
 CONSTRAINT [PK_PrSsExtraTaxTable] PRIMARY KEY CLUSTERED 
(
	[ExtTbl_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO PrSsParameters
                      ( Par_Section, Par_Item, Par_Value, Par_Description, Par_System, Par_Type)
VALUES     ( 'SpecialTax', 'ConLimit', '5', 'Contribution Limit', 'Y', 'T')

INSERT INTO PrSsParameters
                      ( Par_Section, Par_Item, Par_Value, Par_Description, Par_System, Par_Type)
VALUES     ( 'SpecialTax', 'DedLimit', '5', 'Deduction Limit', 'Y', 'T')


GO
/****** Object:  StoredProcedure [dbo].[AG_PrSsExtraTaxTable_SAVE_UPDATE]    Script Date: 01/11/2012 16:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-------------- Main Procedure starts here -------------
CREATE PROCEDURE [dbo].[AG_PrSsExtraTaxTable_SAVE_UPDATE]
@ExtTbl_id int,
@ExtTbl_Sequence tinyint,
@ExtTbl_BracketAmount decimal(10,2),
@ExtTbl_DedRate decimal(10,2),
@ExtTbl_ConRate decimal(10,2),
@ExtTbl_CreationDate smalldatetime,
@ExtTbl_CreatedBy int,
@ExtTbl_AmendDate smalldatetime,
@ExtTbl_AmendBy int
,
@NewId Int OUTPUT
AS
  DECLARE @Result as Int
  Set @Result = 0
  SELECT @Result = Count(*)
  FROM PrSsExtraTaxTable
  WHERE ExtTbl_id = @ExtTbl_id
  IF(@Result IS NULL) OR (@Result=0)
    BEGIN
      INSERT INTO PrSsExtraTaxTable     (ExtTbl_Sequence,                                   --(1)      ExtTbl_BracketAmount,                              --(2)      ExtTbl_DedRate,                                --(3)	  ExtTbl_ConRate,                                --(3)      ExtTbl_CreationDate,                               --(4)      ExtTbl_CreatedBy,                                  --(5)      ExtTbl_AmendDate,                                  --(6)      ExtTbl_AmendBy                                     --(7)      )
      VALUES (      @ExtTbl_Sequence,                                   --(1)      @ExtTbl_BracketAmount,                              --(2)      @ExtTbl_DedRate,                                --(3)      @ExtTbl_ConRate,                                --(3)      @ExtTbl_CreationDate,                               --(4)      @ExtTbl_CreatedBy,                                  --(5)      @ExtTbl_AmendDate,                                  --(6)      @ExtTbl_AmendBy                                     --(7)      )
    END
  ELSE
    BEGIN
      UPDATE PrSsExtraTaxTable
      SET       ExtTbl_Sequence=@ExtTbl_Sequence,                    --(1)      ExtTbl_BracketAmount=@ExtTbl_BracketAmount,          --(2)      ExtTbl_DedRate=@ExtTbl_DedRate,              --(3)      ExtTbl_ConRate=@ExtTbl_ConRate,              --(3)      ExtTbl_CreationDate=@ExtTbl_CreationDate,            --(4)      ExtTbl_CreatedBy=@ExtTbl_CreatedBy,                  --(5)      ExtTbl_AmendDate=@ExtTbl_AmendDate,                  --(6)      ExtTbl_AmendBy=@ExtTbl_AmendBy                       --(7)
      WHERE ExtTbl_id = @ExtTbl_id
  END
set @NewId=SCOPE_IDENTITY()



