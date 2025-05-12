delete from PrTxTrxnLines 
delete from PrTxir59
delete from PrTxTrxnHeader 
delete from PrMsEmployeeContributions 
delete from PrMsEmployeeearnings
delete from PrMsEmployeedeductions
delete from PrTxEmployeeAdvances 
delete from PrTxEmployeediscounts
delete from PrTxEmployeeHiring 
delete from PrTxEmployeeSalary 
delete from PrTxEmployeeLeave
delete from PrTxEmployeeLoan 
delete from PrMsEmployees 
delete from PrMsPeriodEarnings where PrdGrp_Code<>'202101'
delete from PrMsPerioddeductions where PrdGrp_Code<>'202101'
delete from PrMsPeriodcontributions where PrdGrp_Code<>'202101'
delete from PrMsPeriodCodes where PrdGrp_Code<>'202101'
delete from PrMsPeriodgroups where PrdGrp_Code<>'202101'

delete from PrSsNavBatch 
delete from PrTmInterface 

DBCC CHECKIDENT (prtxtrxnheader, RESEED, 0)
DBCC CHECKIDENT (PrSsNavBatch , RESEED, 0)
DBCC CHECKIDENT (PrTmInterface, RESEED, 0)
