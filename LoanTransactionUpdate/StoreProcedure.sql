USE [NodPrNYS]
GO
/****** Object:  StoredProcedure [dbo].[AG_PrTxEmployeeLoan_SAVE_UPDATE]    Script Date: 07/03/2012 10:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-------------- Main Procedure starts here -------------
ALTER PROCEDURE [dbo].[AG_PrTxEmployeeLoan_SAVE_UPDATE]
@EmpLne_Id	int,
@EmpLne_Code varchar(10),
@Emp_Code varchar(16),
@TemGrp_Code varchar(6),
@PrdCod_Code varchar(6),
@PrdGrp_Code varchar(6),
@DedCod_Code varchar(6),
@TrxHdr_Id int,
@EmpLne_LoanDate datetime,
@EmpLne_Amount decimal(18, 2),
@EmpLne_Interest decimal(18, 2),
@EmpLne_TotalAmount decimal(18, 2),
@EmpLne_Description varchar(50),
@EmpLne_MonthlyAmount decimal(18, 2),
@EmpLne_Type varchar(10),
@EmpLne_Payment	decimal(18, 2),
@Usr_Id	int,
@EmpLne_Status	varchar(10),
@NewId Int OUTPUT
AS
  DECLARE @Result as Int
  Set @Result = 0
  SELECT @Result = Count(*)
  FROM PrTxEmployeeLoan
  WHERE EmpLne_id = @EmpLne_id
  IF(@Result IS NULL) OR (@Result=0)
    BEGIN
      INSERT INTO PrTxEmployeeLoan     ( EmpLne_Code,
		Emp_Code,
		TemGrp_Code,
		PrdCod_Code,
		PrdGrp_Code,
		DedCod_Code,
		TrxHdr_Id,
		EmpLne_LoanDate,
		EmpLne_Amount,
		EmpLne_Interest,
		EmpLne_TotalAmount,
		EmpLne_Description,
		EmpLne_MonthlyAmount,
		EmpLne_Type,
		EmpLne_Payment,
		Usr_Id,
		EmpLne_Status)
      VALUES (      @EmpLne_Code,
		@Emp_Code,
		@TemGrp_Code,
		@PrdCod_Code,
		@PrdGrp_Code,
		@DedCod_Code,
		@TrxHdr_Id,
		@EmpLne_LoanDate,
		@EmpLne_Amount,
		@EmpLne_Interest,
		@EmpLne_TotalAmount,
		@EmpLne_Description,
		@EmpLne_MonthlyAmount,
		@EmpLne_Type,
		@EmpLne_Payment,
		@Usr_Id,		@EmpLne_Status      )
    END
  ELSE
    BEGIN
      UPDATE PrTxEmployeeLoan      SET       EmpLne_Code=@EmpLne_Code,
		Emp_Code=@Emp_Code,
		TemGrp_Code=@TemGrp_Code,
		PrdCod_Code=@PrdCod_Code,
		PrdGrp_Code=@PrdGrp_Code,
		DedCod_Code=@DedCod_Code,
		TrxHdr_Id=@TrxHdr_Id,
		EmpLne_LoanDate=@EmpLne_LoanDate,
		EmpLne_Amount=@EmpLne_Amount,
		EmpLne_Interest=@EmpLne_Interest,
		EmpLne_TotalAmount=@EmpLne_TotalAmount,
		EmpLne_Description=@EmpLne_Description,
		EmpLne_MonthlyAmount=@EmpLne_MonthlyAmount,
		EmpLne_Type=@EmpLne_Type,
		EmpLne_Payment=@EmpLne_Payment,
		Usr_Id=@Usr_Id,
		EmpLne_Status=@EmpLne_Status      
      WHERE EmpLne_id =@EmpLne_id
  END
set @NewId=SCOPE_IDENTITY()


